﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Interfaces.Queries;
public interface IGetTotalNumberOfUserSubscriptionServices
{
    Task<int> GetTotalNumberOfUserSubscriptionServicesAsync(string userName);
}
