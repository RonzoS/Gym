using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GymWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ExerciseController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var exerciseList = _unitOfWork.Exercise.GetAll();
            return Json(new { data = exerciseList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Exercise.GetFirstOfDefault(u => u.Id == id);
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Exercise.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
