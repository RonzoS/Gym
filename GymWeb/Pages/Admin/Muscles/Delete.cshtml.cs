using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Muscles
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Muscle Muscle { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet(int id)
        {
            var objFromDb = _unitOfWork.Muscle.GetFirstOfDefault(u=>u.Id==id);
            _unitOfWork.Muscle.Remove(objFromDb);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
