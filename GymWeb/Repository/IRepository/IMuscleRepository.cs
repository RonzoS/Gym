using GymWeb.Model;

namespace GymWeb.Repository.IRepository
{
    public interface IMuscleRepository : IRepository<Muscle>
    {
        void Update(Muscle muscle);
    }
}
