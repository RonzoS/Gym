using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class MuscleRepository : Repository<Muscle>, IMuscleRepository
    {
        private readonly ApplicationDbContext _db;
        public MuscleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Muscle muscle)
        {
            var objFromDb = _db.Muscle.FirstOrDefault(u => u.Id == muscle.Id);
            objFromDb.Name = muscle.Name;
        }
    }
}
