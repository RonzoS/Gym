using GymWeb.Model;

namespace GymWeb.Repository.IRepository
{
    public interface IToolRepository : IRepository<Tool>
    {
        void Update(Tool tool);
    }
}
