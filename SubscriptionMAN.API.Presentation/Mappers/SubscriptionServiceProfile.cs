using AutoMapper;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Presentation.Utils.Requests;

namespace SubscriptionMAN.API.Presentation.Mappers;

public class SubscriptionServiceProfile : Profile
{
    public SubscriptionServiceProfile()
    {
        CreateMap<SubscriptionServiceDTO, SubscriptionService>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

    }
}
