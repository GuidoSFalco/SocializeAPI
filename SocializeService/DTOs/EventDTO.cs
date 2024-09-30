using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.DTOs
{
    public class EventDTO
    {
        public int EventID { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string CreatorAvatar { get; set; } // Cambio de tipo a byte[] para representar datos binarios
        public string EventTitle { get; set; } = string.Empty;
        public int CreatorId { get; set; }
        public string? GuestsId { get; set; } = string.Empty;
        public string CreatorName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public string StartDay { get; set; } = string.Empty;
        public string StartHour { get; set; } = string.Empty;
        public string EventLocation { get; set; } = string.Empty;
        public string EventPrivacity { get; set; } = string.Empty;
        public string EventImage { get; set; }
        public string EventCharacteristics { get; set; } = string.Empty;

    }
}
