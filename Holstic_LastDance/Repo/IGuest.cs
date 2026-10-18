using Holstic_LastDance.Models;

namespace Holstic_LastDance.Repo
{
    public interface IGuest : Irepo<Guest>
    {
        public Task<List<Staff>> StaffIds(List<int> Ids);

        public Task<List<Guest>> GetAllGuests();

        public Task<Guest> GetGuestById(int id);
    }
}
