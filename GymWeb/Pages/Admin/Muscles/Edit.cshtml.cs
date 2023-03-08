using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Muscles
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Muscle Muscle { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Muscle = _unitOfWork.Muscle.GetFirstOfDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            _unitOfWork.Muscle.Update(Muscle);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
