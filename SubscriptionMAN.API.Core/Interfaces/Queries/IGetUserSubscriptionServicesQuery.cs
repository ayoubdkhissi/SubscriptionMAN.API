using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Interfaces.Queries;
public interface IGetUserSubscriptionServicesQuery
{
    Task<IEnumerable<SubscriptionService>> 
        GetUserSubscriptionServicesAsync(string userName,
        int pageNumber = PaginationConstants.DefaultPageNumber,
        int pageSize = PaginationConstants.DefaultPageSize);
}
