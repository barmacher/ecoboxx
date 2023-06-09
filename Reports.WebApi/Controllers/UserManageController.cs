﻿using Applications.Domain;
using Ecobox.Domain;
using Ecobox.Domain.Enums;
using EcoboxPersistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserManageController : ControllerBase
    {
        public readonly UserManager<User> _userManager;
        private readonly ApplicationsDbContext _dbContext;

        public UserManageController(UserManager<User> userManager, ApplicationsDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpPost("register/client")]
        [AllowAnonymous]
        public async Task RegisterClient(string email, string password)
        {
            var user = new User()
            {
                Email = email,
                UserName = email
            };

            var existingUser = await _userManager.FindByNameAsync(user.UserName);

            if (existingUser != null)
                throw new Exception("User with such email already exists");

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }

            result = await _userManager.AddToRoleAsync(user, RoleType.Client.ToString());
            
            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }
        }

        [HttpPost("register/brigade")]
        [Authorize(Roles = "Manager, Admin")]
        public async Task RegisterBrigadeAccount(string email, string password, string brigaderName, string brigaderSurname, string? informalName)
        {
            var brigadeAccount = new Brigade()
            {
                Email = email,
                UserName = email,
                InformalName = informalName,
            };

            var existingUser = await _userManager.FindByNameAsync(brigadeAccount.UserName);

            if (existingUser != null)
                throw new Exception("User with such email already exists");

            var result = await _userManager.CreateAsync(brigadeAccount, password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }

            result = await _userManager.AddToRoleAsync(brigadeAccount, RoleType.BrigadeAccount.ToString());

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }

            var createdAcc = _userManager.FindByEmailAsync(email);
            await _dbContext.SaveChangesAsync();
            //var firstBrigadeMember = new BrigadeMember()
            //{
            //    Email = email,
            //    FirstName = brigaderName,
            //    LastName = brigaderSurname,
            //    BrigadeId = createdAcc.Id
            //};

            //await _dbContext.BrigadeMembers.AddAsync(firstBrigadeMember);
            //await _dbContext.SaveChangesAsync();
        }
        [HttpPost("register/manager")]
        [Authorize(Roles = "Manager, Admin")]
        public async Task RegisterManagerAccount(string email, string password)
        {
            var managerAccount = new User()
            {
                Email = email,
                UserName = email,
            };

            var existingUser = await _userManager.FindByNameAsync(managerAccount.UserName);

            if (existingUser != null)
                throw new Exception("User with such email already exists");

            var result = await _userManager.CreateAsync(managerAccount, password);

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }

            result = await _userManager.AddToRoleAsync(managerAccount, RoleType.Manager.ToString());

            if (!result.Succeeded)
            {
                throw new Exception(
                    result.Errors
                        .Select(error => error.Description)
                        .Aggregate((x, y) => x + ";" + y));
            }

            var createdAcc = await _userManager.FindByIdAsync(email);
            var deletedAcc =  await _userManager.DeleteAsync(createdAcc);
            await _dbContext.SaveChangesAsync();
        }
        [HttpPost("delete")]
        [Authorize(Roles = "Manager, Admin")]
        public async Task DeleteByUserName(string email)
        {

            //var createdAcc = await _dbContext.Users.FindAsync(email);
            //if (createdAcc != null)
            //    throw new Exception("User with such email is not found");
            //var deletedAcc = await _userManager.DeleteAsync(createdAcc);
            //if (!deletedAcc.Succeeded)
            //{
            //    throw new Exception("Error");
            //}
            //await _dbContext.SaveChangesAsync();
            var createdAcc = await _userManager.FindByEmailAsync(email);
            if (createdAcc == null)
                throw new Exception("User with such email is not found");
            var deletedAcc = await _userManager.DeleteAsync(createdAcc);
            if (!deletedAcc.Succeeded)
            {
                throw new Exception("Error");
            }
            await _dbContext.SaveChangesAsync();

        }
    }
}
