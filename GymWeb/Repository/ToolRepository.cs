using GymWeb.Data;
using GymWeb.Model;
using GymWeb.Repository.IRepository;

namespace GymWeb.Repository
{
    public class ToolRepository : Repository<Tool>, IToolRepository
    {
        private readonly ApplicationDbContext _db;
        public ToolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tool tool)
        {
            var objFromDb = _db.Tool.FirstOrDefault(u => u.Id == tool.Id);
            objFromDb.Name = tool.Name;
        }
    }
}
