using System.ComponentModel.DataAnnotations;

namespace Holstic_LastDance.Dtos
{
    public class RoomDtoPost
    {
       
        public string ?RoomNumber { get; set; }
        
        public string ?Type { get; set; }
    }

    public class RoomDtoGet
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
     
        public string Type { get; set; }

    }
}
