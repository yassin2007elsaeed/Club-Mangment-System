using Holstic_LastDance.AppDataContext;
using Holstic_LastDance.Models;
using Microsoft.EntityFrameworkCore;

namespace Holstic_LastDance.Repo
{
    public class StaffRepo : Repo<Staff>, IStaff
    {
        public StaffRepo(AppDataContextt context) : base(context)
        {
        }

        public async Task<Staff> GetbyIdStaff(int id)
        {
            return await _context.Staff.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
