using GymWeb.Model;
using GymWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWeb.Pages.Admin.Exercises
{
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Exercise Exercise { get; set; }
        public IEnumerable<Muscle> Muscles { get; set;}
        public IEnumerable<Tool> Tools { get; set; }
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Exercise = _unitOfWork.Exercise.GetFirstOfDefault(u => u.Id == id);
            Muscles = _unitOfWork.Exercise.GetMuscleByExercise(id);
            Tools = _unitOfWork.Exercise.GetToolByExercise(id);
        }
    }
}
