using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddAsync(User user)
        {
            var userLooked =  _userRepository.GetUserByEmailAsync(user.Email);

            if (userLooked is not null)
            {
                throw new ExistException("This user already exist");
            }

            _userRepository.Add(user);
            await _userRepository.SavechangesAsync();

            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            var userLooked = await _userRepository.GetUserByEmailAsync(user.Email);

            if (userLooked is null)
            {
                throw new NotFoundException("The user does not exist");
            }
            _userRepository.DeleteAsync(userLooked);
            await _userRepository.SavechangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            if (users is null)
            {
                throw new NotFoundException("There are no registered users yet");
            }
            return users;
        }

        public async Task<User?> GetByIdAsync(int Id)
        {
            var user = await _userRepository.GetByIdAsync(Id);

            if (user is null)
            {
                throw new NotFoundException("The user does not exist");
            }

            return user;
        }

        public async Task<User?> GetByUserNameAsync(string Name)
        {
            var user = await _userRepository.GetByUserNameAsync(Name);

            if (user is null)
            {
                throw new NotFoundException("The user does not exist");
            }

            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string Email)
        {
            var user =await _userRepository.GetUserByEmailAsync(Email);

            if (user is null)
            {
                throw new NotFoundException("The user does not exist");
            }

            return user;
        }

        public Task SavechangesAsync()
        {
            return _userRepository.SavechangesAsync();     
               
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userLooked = await _userRepository.GetUserByEmailAsync(user.Email);

            if (userLooked is null)
            {
                throw new NotFoundException("The user does not exist");
            }

            userLooked.Name = user.Name;
            userLooked.PhoneNumber = user.PhoneNumber;
            userLooked.Password = user.Password;
 
            _userRepository.UpdateAsync(userLooked);
            await _userRepository.SavechangesAsync();

            return user;
        }
    }
}
