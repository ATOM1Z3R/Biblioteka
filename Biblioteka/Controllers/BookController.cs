using Biblioteka.BLL.AuthorBLL.Interfaces;
using Biblioteka.BLL.BookBLL.Interfaces;
using Biblioteka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{
    public class BookController : Controller
    {
        private readonly IReadDetailData _readDetail;
        private readonly IReadListData _readList;
        private readonly IWriteData _writeData;
        private readonly IUpdateData _updateData;
        private readonly IDeleteData _deleteData;
        private readonly IAuthorDbSet _authorDbSet;

        public BookController(IReadDetailData readDetail, IReadListData readList, IWriteData writeData, 
                              IUpdateData updateData, IDeleteData deleteData, IAuthorDbSet authorDbSet)
        {
            _readDetail = readDetail;
            _readList = readList;
            _writeData = writeData;
            _updateData = updateData;
            _deleteData = deleteData;
            _authorDbSet = authorDbSet;
        }
        public IActionResult Index()
        {
            var books = _readList.ReadAllBooks();
            return View(books);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Book book;
            if (User != null && User.IsInRole("emp"))
            {
                book = await _readDetail.ReadBookReservationsAsync((int)id);
            }
            else
            {
                book = await _readDetail.ReadBookDetailAsync((int)id);
            }

            if(book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize(Roles = "emp")]
        public IActionResult Create()
        {
            ViewData["Authors"] = new SelectList(_authorDbSet.returnDbSetAuthor(), "AuthorId", "FirstAndLastName");
            return View();
        }

        [Authorize(Roles = "emp")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId", "Name", "ReleaseDate", "AuthorId", "Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _writeData.AddBookAsync(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_authorDbSet.returnDbSetAuthor(), "AuthorId", "AuthorId");
            return View(book);
        }

        [Authorize]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _readDetail.ReadBookDetailAsync((int)id);
            if(book == null)
            {
                return NotFound();
            }
            ViewData["Authors"] = new SelectList(_authorDbSet.returnDbSetAuthor(), "AuthorId", "FirstAndLastName");
            return View(book);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("BookId", "Name", "ReleaseDate", "AuthorId", "Description")] Book book)
        {
            if(id != book.BookId)
            {
                return NotFound();
            }

            ViewData["Authors"] = new SelectList(_authorDbSet.returnDbSetAuthor(), "AuthorId", "FirstAndLastName");
            if (await _updateData.UpdateBookAsync(id, book))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "emp")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var book = await _readDetail.ReadBookDetailAsync((int)id);
            if (id == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize(Roles = "emp")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            await _deleteData.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
