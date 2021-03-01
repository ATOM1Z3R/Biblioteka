using Biblioteka.BLL.ReservationBLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{

    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IReadListData _readList;
        private readonly IWriteData _writeData;

        public ReservationController(IReadListData readList, IWriteData writeData)
        {
            _readList = readList;
            _writeData = writeData;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("emp"))
            {
                return View(_readList.ReadAllReservations());
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(_readList.ReadUserReservations(userId));

        }

        public async Task<IActionResult> Reserve(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = User;
            string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _writeData.AddReservationAsync((int)id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
