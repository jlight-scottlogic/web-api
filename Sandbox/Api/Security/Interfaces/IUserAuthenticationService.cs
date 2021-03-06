﻿using Api.Data.Entities;
using System.Threading.Tasks;

namespace Api.Security.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<User> Authenticate(string username, string password);
    }
}