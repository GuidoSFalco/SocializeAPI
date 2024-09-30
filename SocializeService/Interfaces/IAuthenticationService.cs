using SocializeData.Entities;
using SocializeService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> LoginUser(string email, string password);
        Task RegisterUser(UserDTO userDTO);
        Task<List<User>> GetUsers(int? userID);
        Task<User> GetUserData(int userID);
        Task DeleteUser(int eventID);
        Task UpdateUser(UserDTO? userDTO);
    }
}
