using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SubscriptionMAN.API.Core.Common;
using SubscriptionMAN.API.Core.Interfaces;
using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Services;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Result> RegisterAsync(string userName, string email, string phoneNumber, string password)
    {
        var result = new Result();


        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            PhoneNumber = phoneNumber,
        };


        var user_creation_result = await _userManager.CreateAsync(user, password);
        if(!user_creation_result.Succeeded)
        {
            result.Message = "User Registration Failed!";
            for(int i=0; i<user_creation_result.Errors.Count(); i++)
            {
                result.Errors.Add(user_creation_result.Errors.ElementAt(i).Description);
            }
        }

        return result;


    }
    public async Task<Result> AuthenticateAsync(string userName, string password)
    {
        var result = new Result();

        var auth_result = await _signInManager.PasswordSignInAsync(userName, password, false, true);
        
        if(!auth_result.Succeeded)
        {
            result.Errors = new List<string>() { "User name or password is incorrect" };
        }

        return result;
    }
}
