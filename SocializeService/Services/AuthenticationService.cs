using AutoMapper;
using SocializeData.Entities;
using SocializeData.Interfaces;
using SocializeService.DTOs;
using SocializeService.Exceptions;
using SocializeService.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _AuthRepo;
        private readonly IMapper _mapper;

        public AuthenticationService( IAuthenticationRepository authRepo, IMapper mapper)
        {
            _AuthRepo = authRepo;
            _mapper = mapper;
        }
        //GET
        public async Task<User> LoginUser(string user, string password)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                var userDto = await _AuthRepo.FindByCondition(x => x.Email == user & x.Pass == password).FirstOrDefaultAsync();
                if (userDto == null) return null; 
                return userDto;
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
        public async Task<User> GetUserData(int userID)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                var userDto = await _AuthRepo.FindByCondition(x => x.UserID == userID).FirstOrDefaultAsync();
                if (userDto == null) return null;
                return userDto;
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


        //POST
        public async Task RegisterUser(UserDTO userDTO)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                if (userDTO == null)
                {
                    throw new NotFoundException($"The OccupationId: {userDTO} does not exist.");
                }

                var newUser = _mapper.Map<User>(userDTO);

                _AuthRepo.Add(newUser);
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


        //GET
        public async Task<List<User>> GetUsers(int? userID)
        {
            try
            {
                if (userID != null)
                {
                    var users = await _AuthRepo.FindByCondition(x => x.UserID != userID).ToListAsync();
                    return users;
                } else
                {

                    var userDto = await _AuthRepo.GetAllAsync();

                    //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                    if (userDto == null) return null;
                    return userDto;
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


        public async Task DeleteUser(int userID)
        {
            try
            {
                // var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);
                var deleteUser = await _AuthRepo.FindByCondition(x => x.UserID == userID).FirstOrDefaultAsync();
                //var deleteEvent = _mapper.Map<Event>(eventID);

                await _AuthRepo.RemoveByIdAsync(deleteUser.UserID);
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


        public async Task UpdateUser(UserDTO? userDTO)
        //public async Task UpdateEvent(int eventID, string eventType, string creatorAvatar, string eventTitle, string guestsID, string creatorName, string eventDescription, string startDay, string startHour, string eventLocation, string eventPrivacity, string eventImage, string eventCharacteristics)
        {
            try
            {
                //var occupation = await _occupationRepo.FindByIdAsync(prescriptionDto.OccupationId);

                var updateUser = _mapper.Map<User>(userDTO);
                //var updateEvent = await _AuthRepo.FindByCondition(x => x.EventID == eventID).FirstOrDefaultAsync();
                _AuthRepo.Update(updateUser);
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
    }
}
