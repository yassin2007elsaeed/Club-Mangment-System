using Holstic_LastDance.Dtos;
using Holstic_LastDance.Models;
using Holstic_LastDance.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holstic_LastDance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly Irepo<Staff> _repo;
        private readonly Irepo<Department> _department;
        private readonly IStaff _StaffRepo;

        public StaffController(Irepo<Staff> repo, Irepo<Department> department, IStaff staffRepo)
        {
            _repo = repo;
            _department = department;
            _StaffRepo = staffRepo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateStaff(StaffDtos dto)
        {
            if (dto == null) return BadRequest("Empty data");

            var r = await _department.GetById(dto.DepartmentId);
            if (r == null) return BadRequest("Departmnet Id not found");

            Staff staff = new Staff()
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId,
                EmailAddress = dto.EmailAddress,
                phone = dto.phone,

            };

            await _repo.Create(staff);
            await _repo.Save();

            return Ok("Staff member created Successfuly");

        }
        [HttpGet]
        public async Task<ActionResult> GetStaffById(int id)
        {
            var r  = await _StaffRepo.GetbyIdStaff(id);
            if (r == null) return BadRequest("Staff Id not found");

            var staff = new StaffDtoGet
            {
                Id = r.Id,
                Name = r.Name,
                EmailAddress = r.EmailAddress,
                phone = r.phone,
                Department = new DepartmentDtoGet
                {
                    Id = r.Department.Id,
                    Name = r.Department.Name,
                    Description = r.Department.Description,
                }
            };

            return Ok(staff);
        }
    }
}
