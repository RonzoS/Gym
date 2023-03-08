using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Tools
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Tool Tool { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Tool = _unitOfWork.Tool.GetFirstOfDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            _unitOfWork.Tool.Update(Tool);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
