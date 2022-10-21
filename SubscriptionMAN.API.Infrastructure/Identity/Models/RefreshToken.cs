using SubscriptionMAN.API.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Infrastructure.Identity.Models;
public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; }

    public string UserName { get; set; }
    public ApplicationUser User { get; set; }



    
}
