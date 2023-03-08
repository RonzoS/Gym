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
        public void OnGet(int id)
        {
            Muscle = _unitOfWork.Muscle.GetFirstOfDefault(u=>u.Id==id);
        }

        public async Task<IActionResult> OnPost()
        {
            var muscleFromDb = _unitOfWork.Muscle.GetFirstOfDefault(u=>u.Id==Muscle.Id);
            if (muscleFromDb != null)
            {
                _unitOfWork.Muscle.Remove(muscleFromDb);
                _unitOfWork.Save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
