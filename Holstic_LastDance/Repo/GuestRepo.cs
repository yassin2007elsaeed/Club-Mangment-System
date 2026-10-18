using Holstic_LastDance.AppDataContext;
using Holstic_LastDance.Models;
using Microsoft.EntityFrameworkCore;

namespace Holstic_LastDance.Repo
{
    public class GuestRepo : Repo<Guest>, IGuest
    {
        public GuestRepo(AppDataContextt context) : base(context)
        {
        }

        public async Task<List<Guest>> GetAllGuests()
        {
            return await _context.Guests.Include(x=> x.Staffs).Include(x=> x.Room).ToListAsync();
        }

        public async Task<Guest> GetGuestById(int id)
        {
          return  await _context.Guests.Include(x=> x.Staffs).Include(x=> x.Room).FirstOrDefaultAsync(x=> x.Id ==  id);
        }

        public async Task<List<Staff>> StaffIds(List<int> Ids)
        {
            return await _context.Staff.Where(x=> Ids.Contains(x.Id)).ToListAsync();
        }
    }
}
