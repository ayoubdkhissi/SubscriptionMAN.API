using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionMAN.API.Core.Common;
public class Result
{
    public bool Success => !Errors.Any();

    public ICollection<string> Errors { get; set; }


    public string Message { get; set; }

    public Result(string message)
    {
        Errors = new List<string>();
        Message = message;
    }
    public Result()
    {
        Errors = new List<string>();
        Message = "";
    }

}
