using Holstic_LastDance.Dtos;
using Holstic_LastDance.Models;
using Holstic_LastDance.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holstic_LastDance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly Irepo<Department> _repo;

        public DepartmentController(Irepo<Department> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartment(DepartmentDto dto)
        {
            if (dto == null) return BadRequest("Empty data");

            Department department = new Department();

            department.Name = dto.Name;
            department.Description = dto.Description;
            await _repo.Create(department);
            await _repo.Save();

            return Ok("Department Created successfuly");
        }
    }
}
