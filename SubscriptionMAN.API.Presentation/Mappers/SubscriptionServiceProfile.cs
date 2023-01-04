using AutoMapper;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Mappers;

public class SubscriptionServiceProfile : Profile
{
    public SubscriptionServiceProfile()
    {
        CreateMap<SubscriptionServiceForListingDTO, SubscriptionService>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        // Map the other way
        CreateMap<SubscriptionService, SubscriptionServiceForListingDTO>();

    }
}
