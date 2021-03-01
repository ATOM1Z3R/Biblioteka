using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{
    [Authorize(Roles = "emp")]
    public class AuthorController : Controller
    {
        private readonly IWriteAuthorData _writeAuthorData;
        private readonly IReadListAuthorData _readListAuthorData;
        private readonly IDeleteAuthorData _deleteAuthorData;
        private readonly IUpdateAuthorData _updateAuthorData;
        private readonly IReadDetailAuthorData _readDetailAuthorData;

        public AuthorController(IWriteAuthorData writeAuthorData , IReadListAuthorData readListAuthorData, 
                                IDeleteAuthorData deleteAuthorData, IUpdateAuthorData updateAuthorData, IReadDetailAuthorData readDetailAuthorData)
        {
            _writeAuthorData = writeAuthorData;
            _readListAuthorData = readListAuthorData;
            _deleteAuthorData = deleteAuthorData;
            _updateAuthorData = updateAuthorData;
            _readDetailAuthorData = readDetailAuthorData;
        }
        public IActionResult Index()
        {
            var authors = _readListAuthorData.ReadAllAuthors();
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId", "FirstName", "LastName")] Author author)
        {
            if (ModelState.IsValid)
            {
                await _writeAuthorData.AddAuthorAsync(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = await _readDetailAuthorData.ReadAuthorDetailAsync((int)id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("AuthorId", "FirstName", "LastName")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (await _updateAuthorData.UpdateAuthorAsync(id, author))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _readDetailAuthorData.ReadAuthorDetailAsync((int)id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            await _deleteAuthorData.DeleteAuthorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
