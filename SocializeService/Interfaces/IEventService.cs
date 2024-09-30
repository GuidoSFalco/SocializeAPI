using SocializeData.Entities;
using SocializeService.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Interfaces
{
    public interface IEventService
    {

        Task CreateEvent(EventDTO? eventDTO);
        //Task UpdateEvent(int eventID,string eventType, string creatorAvatar, string eventTitle, string guestsID, string creatorName, string eventDescription, string startDay, string startHour, string eventLocation, string eventPrivacity, string eventImage, string eventCharacteristics);
        Task UpdateEvent(EventDTO? eventDTO);

        Task DeleteEvent(int eventID);
        //Task<List<EventDTO>> GetAllEventsAsync(string title, string creatorName);
        Task<List<Event>> GetEvents(string? title, string? creatorName, string? eventPrivacity, int? creatorID, int? userID);
        Task<Event> GetEvent(int eventID);
    }
}
