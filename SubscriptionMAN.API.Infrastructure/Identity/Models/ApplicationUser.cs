using Microsoft.AspNetCore.Identity;
using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Identity.Models;
public class ApplicationUser : IdentityUser
{
    public IEnumerable<RefreshToken> RefreshTokens { get; set; }
}
