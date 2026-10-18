using Holstic_LastDance.Dtos;
using Holstic_LastDance.Models;
using Holstic_LastDance.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holstic_LastDance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly Irepo<Guest> _repo;
        private readonly IGuest _GuestRepo;
        private readonly Irepo<Room> _roomRepo;

        public GuestController(Irepo<Guest> repo, IGuest guestRepo, Irepo<Room> roomRepo)
        {
            _repo = repo;
            _GuestRepo = guestRepo;
            _roomRepo = roomRepo;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuest(GuestDtoPost dto)
        {
            if (dto == null) return BadRequest("Empty data");

            Guest guest = new Guest();
            guest.Name = dto.Name;
            guest.EmailAddress = dto.EmailAddress;

            if (dto.StaffIds != null && dto.StaffIds.Any())
            {
                var r = await _GuestRepo.StaffIds(dto.StaffIds);
                if (dto.StaffIds.Count() != r.Count())
                {
                    return BadRequest("Staff IDs not found");
                }
                else
                {
                    guest.Staffs = r;
                }
            }

            if (dto.Room != null && !string.IsNullOrEmpty(dto.Room.RoomNumber))
            {
                var rr = await _roomRepo.GetAllAsync();
                var check = rr.FirstOrDefault(x => x.RoomNumber == dto.Room.RoomNumber);

                if (check == null)
                {
                    Room room = new Room
                    {
                        RoomNumber = dto.Room.RoomNumber,
                        Type = dto.Room.Type
                    };
                    guest.Room = room;
                }
                else
                {
                    return BadRequest("Room number is already assigned");
                }
            }

            await _GuestRepo.Create(guest);
            await _GuestRepo.Save();

            return Ok("Guest created successfully");
        }
        [HttpGet]
        public async Task<ActionResult> GetAllGuests()
        {
            var r = await _GuestRepo.GetAllGuests();
            if (r == null) return BadRequest("No Guests yet");

            var guest = r.Select(x => new GuestDtoGet
            {
                Id = x.Id,
                Name = x.Name,
                EmailAddress = x.EmailAddress,
                Staffs = x.Staffs.Select(u => new StaffDtoGetguest
                {
                    Id = u.Id,
                    Name = u.Name,
                    EmailAddress = u.EmailAddress,
                    phone = u.phone,
                }).ToList(),
                Roomm =x.Room ==null ? null : new RoomDtoGet
                {
                    Id = x.Room.Id,
                    RoomNumber = x.Room.RoomNumber,
                    Type = x.Room.Type,
                }
            }).ToList();

            return Ok(guest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGuest(int id, GuestDtoPost dto)
        {
            if (dto == null) return BadRequest("Empty data");

            var r = await _GuestRepo.GetGuestById(id);
            if (r == null) return BadRequest("Guest Id not found");

            r.Name = dto.Name;
            r.EmailAddress = dto.EmailAddress;

            if (dto.StaffIds != null)
            {
                if (dto.StaffIds.Any())
                {
                    var Ids = await _GuestRepo.StaffIds(dto.StaffIds);
                    if (dto.StaffIds.Count != Ids.Count())
                    {
                        return BadRequest("Staff IDs not found");
                    }
                    r.Staffs = Ids;
                }
                else
                {
                    r.Staffs?.Clear();
                }
            }

            if (dto.Room != null && !string.IsNullOrEmpty(dto.Room.RoomNumber))
            {
                var rr = await _roomRepo.GetAllAsync();
                var check = rr.FirstOrDefault(x => x.RoomNumber == dto.Room.RoomNumber);

                if (r.Room != null)
                {
                    if (check != null && check.Id != r.Room.Id)
                    {
                        return BadRequest("Room number is already assigned to another guest");
                    }

                    r.Room.RoomNumber = dto.Room.RoomNumber;
                    r.Room.Type = dto.Room.Type;
                }
                else
                {
                    if (check != null)
                    {
                        return BadRequest("Room number is already assigned to another guest");
                    }

                    Room room = new Room
                    {
                        RoomNumber = dto.Room.RoomNumber,
                        Type = dto.Room.Type
                    };
                    r.Room = room;
                }
            }

            await _GuestRepo.Update(r);
            await _GuestRepo.Save();

            return Ok("Guest updated successfully");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteGuest(int id)
        {
            var r = await _GuestRepo.GetById(id);
            if (r == null) return BadRequest("Guest Id not found");

            await _GuestRepo.Delete(r);
            await _GuestRepo.Save();

            return Ok("Guest Deleted Successfuly");
        }
        
    }
}
