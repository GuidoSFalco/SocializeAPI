using AutoMapper;
using SocializeData.Entities;
using SocializeData.Interfaces;
using SocializeService.DTOs;
using SocializeService.Exceptions;
using SocializeService.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _AuthRepo;
        private readonly IMapper _mapper;

        public EventService(IEventRepository authRepo, IMapper mapper)
        {
            _AuthRepo = authRepo;
            _mapper = mapper;
        }

        //GET
        public async Task<List<Event>> GetEvents(string? title, string? creatorName, string? eventPrivacity, int? creatorID, int? userID)
        {
            try
            {
                if (title != null || creatorName != null || eventPrivacity != null || creatorID != null)
                {
                    //var eventD = await _AuthRepo.FindByCondition(x => x.EventTitle.Contains(title) || x.CreatorName.Contains(creatorName) || x.EventPrivacity == eventPrivacity || x.CreatorId == creatorID).ToListAsync();
                    var eventD = await _AuthRepo.FindByCondition(x => x.EventTitle.Contains(title) || x.CreatorName.Contains(creatorName) || x.EventPrivacity == eventPrivacity || x.CreatorId == creatorID).ToListAsync();
                    return eventD;

                } else
                {

                    var eventDto = await _AuthRepo.GetAllAsync();

                    //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                    if (eventDto == null) return null;
                    return eventDto;
                }
        }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding prescription", ex);
            }
        }

        //GET
        public async Task<Event> GetEvent(int eventID)
        {
            try
            {
                
                var eventDto = await _AuthRepo.FindByCondition(x => x.EventID == eventID).FirstOrDefaultAsync();
                return eventDto;

                
                if (eventDto == null) return null;

            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding prescription", ex);
            }
        }
        
        //PUT
        public async Task CreateEvent(EventDTO? eventDTO)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                if (eventDTO == null)
                {
                    throw new NotFoundException($"The OccupationId: {eventDTO} does not exist.");
                }

                var newEvent = _mapper.Map<Event>(eventDTO);

                _AuthRepo.Add(newEvent);
                //Save changes to the database
                await _AuthRepo.CommitAsync();
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding prescription", ex);
            }
            // throw new NotImplementedException();
        }

        //DELETE
        public async Task DeleteEvent(int eventID)
        {
            try
            {
                // var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                if (eventID == null)
                {
                    throw new NotFoundException($"The OccupationId: {eventID} does not exist.");
                }
                var deleteEvent = await _AuthRepo.FindByCondition(x => x.EventID == eventID).FirstOrDefaultAsync();
                //var deleteEvent = _mapper.Map<Event>(eventID);

                 await _AuthRepo.RemoveByIdAsync(eventID);
                //Save changes to the database
                await _AuthRepo.CommitAsync();
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding prescription", ex);
            }
        }



        //UPDATE
        public async Task UpdateEvent(EventDTO eventDTO)
        //public async Task UpdateEvent(int eventID, string eventType, string creatorAvatar, string eventTitle, string guestsID, string creatorName, string eventDescription, string startDay, string startHour, string eventLocation, string eventPrivacity, string eventImage, string eventCharacteristics)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);

                var updateEvent = _mapper.Map<Event>(eventDTO);
                //var updateEvent = await _AuthRepo.FindByCondition(x => x.EventID == eventID).FirstOrDefaultAsync();
                _AuthRepo.Update(updateEvent);
                //Save changes to the database
                await _AuthRepo.CommitAsync();
                

            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding prescription", ex);
            }
            // throw new NotImplementedException();
        }
         
         

        /*
        public async Task DeleteEvent(int EventId)
        {
            try
            {
                if (EventId == null)
                {
                    throw new NotFoundException($"The Event ID: {EventId} does not exist.");
                }
                else
                {
                    var eventDto = await _AuthRepo.FindByCondition(x => x.EventID == EventId).FirstOrDefaultAsync();

                    if (eventDto != null)
                    {
                        _AuthRepo.Remove(eventDto);
                        await _AuthRepo.CommitAsync();
                    }
                    else
                    {
                        throw new NotFoundException($"The Event with ID: {EventId} was not found.");
                    }
                }
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the event", ex);
            }
        }
         */


    }
}
