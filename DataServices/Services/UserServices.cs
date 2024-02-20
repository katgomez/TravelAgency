﻿using System.ServiceModel;
using DataServices.Errors;
using DataServices.Model;
using DataServices.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DataServices.Service
{
    public class UserServices : IUserServices
    {
        DataContext _dbContext;
        public UserServices()
        {
            _dbContext = new DataContext();
        }
        public UserServices(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.Password))
            {
                return -1;
            }
            User checkedUser = _dbContext.Users.FirstOrDefault(p => p.Email.ToLower().Equals(user.Email.ToLower()));
            if (checkedUser != null)
                throw new FaultException(new FaultReason("User already exists!!!"), new FaultCode("400"), "");
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public User[] GetUsers()
        {
            return _dbContext.Users.ToArray();
        }

        public void UpdateUser(User user)
        {
            User checkedUser = _dbContext.Users.FirstOrDefault(p => p.Id == user.Id);
            if (checkedUser == null)
                throw new FaultException(new FaultReason("User not found!!!"), new FaultCode("404"), "");
            _dbContext.Entry(checkedUser).State = EntityState.Detached;
            _dbContext.Users.Attach(user);
            _dbContext.SaveChangesAsync();
        }

        public void DeleteUser(int id)
        {
            User checkedUser = _dbContext.Users.FirstOrDefault(p => p.Id == id);
            if (checkedUser == null)
                throw new FaultException(new FaultReason(
                "User not found!!!"), new FaultCode("404"), "");
            _dbContext.Users.Remove(checkedUser);

        }

        public User GetUserByEmail(string email)
        {
            User user = _dbContext.Users.FirstOrDefault(p => p.Email == email);
            if (user == null)
            {
                throw new NotFoundException("User not found for the specified email address.");
            }
            return user;
            
        }

        public User GetUserById(int id)
        {
            User user = _dbContext.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                throw new NotFoundException("User not found for the specified email address.");
            }
            return user;
        }

        public CheckCredentialsResult CheckCredentials(UserCredentials userCredentials)
        {
            if (userCredentials.email != null) { 
                User checkedUser = GetUserByEmail(userCredentials.email);
                return new CheckCredentialsResult
                {
                    IsValidUser = (checkedUser.Password == userCredentials.Password),
                    UserId = checkedUser.Id
                };
            }
            return new CheckCredentialsResult
            {
                IsValidUser = false,
                UserId = 0
            };
        }

    }
}
