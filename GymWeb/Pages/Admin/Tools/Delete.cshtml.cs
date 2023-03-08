using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Tools
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Tool Tool { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet(int id)
        {
            var objFromDb = _unitOfWork.Tool.GetFirstOfDefault(u => u.Id == id);
            _unitOfWork.Tool.Remove(objFromDb);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }

    }
}
