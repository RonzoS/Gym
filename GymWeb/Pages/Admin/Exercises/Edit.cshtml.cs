using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GymWeb.Pages.Admin.Exercises
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Exercise Exercise { get; set; }
        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            Exercise = new Exercise();
        }
        public void OnGet(int id)
        {
            Exercise = _unitOfWork.Exercise.GetFirstOfDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var objFromDb = _unitOfWork.Exercise.GetFirstOfDefault(u => u.Id == Exercise.Id);
            if (files.Count > 0)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\Exercises");
                var extension = Path.GetExtension(files[0].FileName);

                var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Exercise.Image = @"\images\Exercises\" + fileName_new + extension;
            }
            else
            {
                Exercise.Image = objFromDb.Image;
            }
            _unitOfWork.Exercise.Update(Exercise);
            _unitOfWork.Save();
            return RedirectToPage("Index");
        }
    }
}
