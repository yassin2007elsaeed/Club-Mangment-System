using Holstic_LastDance.Models;

namespace Holstic_LastDance.Repo
{
    public interface IStaff : Irepo<Staff>
    {
        public Task<Staff> GetbyIdStaff(int id);
    }
}
