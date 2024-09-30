using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeData.Entities
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventType { get; set; }
        public string CreatorAvatar { get; set; }
        public string EventTitle { get; set; }
        public int CreatorId { get; set; }
        public string? GuestsId { get; set; }
        public string CreatorName { get; set; }
        public string EventDescription { get; set; }
        public string StartDay { get; set; }
        public string StartHour { get; set; }
        public string EventLocation { get; set; }
        public string EventPrivacity { get; set; }
        public string EventImage { get; set; }
        public string EventCharacteristics { get; set; }

    }
}
