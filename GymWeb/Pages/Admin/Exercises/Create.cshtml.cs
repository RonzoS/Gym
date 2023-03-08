using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymWeb.Pages.Exercises
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Exercise Exercise { get; set; }
        public int muscleId { get; set; }
        public int toolId { get; set; }
        public IEnumerable<SelectListItem> MusclesList { get; set; }
        public IEnumerable<SelectListItem> ToolsList { get; set; }
        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public async void OnGet()
        {
            MusclesList = _unitOfWork.Muscle.GetAll().Select(i=> new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name,
            });
            ToolsList = _unitOfWork.Tool.GetAll().Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name,
            });
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\Exercises");
            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new+extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }
            Exercise.Image = @"\images\Exercises\" + fileName_new + extension;
            _unitOfWork.Exercise.Add(Exercise, muscleId, toolId);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
