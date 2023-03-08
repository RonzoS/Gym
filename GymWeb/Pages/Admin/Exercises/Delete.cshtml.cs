using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Admin.Exercises
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Exercise Exercise { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult OnGet(int id)
        {
            var objFromDb = _unitOfWork.Exercise.GetFirstOfDefault(u => u.Id == id);
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Exercise.Remove(objFromDb);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
