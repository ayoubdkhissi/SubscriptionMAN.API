using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SubscriptionMAN.API.Core.Constants;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Queries;
using SubscriptionMAN.API.Core.Interfaces.Repository;
using SubscriptionMAN.API.Infrastructure.Services.Queries;
using SubscriptionMAN.API.Presentation.Utils.Responses;

namespace SubscriptionMAN.API.Presentation.Controllers;
public class SubscriptionServiceController : Controller
{
    private readonly IMapper _mapper;
    private readonly ISubscriptionServiceRepository _subscriptionServiceRepository;
    private readonly IGetUserSubscriptionServicesQuery _getUserSubscriptionServicesQuery;
    private readonly IValidator<SubscriptionServiceForListingDTO> _subscriptionServiceValidator;
    private readonly IGetSubscriptionServiceTotalNumberOfClientsQuery _getSubscriptionServiceTotalNumberOfClientsQuery;
    private readonly IGetSubscriptionServiceNumberOfActiveClientsQuery _getSubscriptionServiceNumberOfActiveClientsQuery;

    public SubscriptionServiceController(ISubscriptionServiceRepository subscriptionServiceRepository,
        IValidator<SubscriptionServiceForListingDTO> subscriptionServiceValidator,
        IMapper mapper,
        IGetUserSubscriptionServicesQuery getUserSubscriptionServicesQuery,
        IGetSubscriptionServiceTotalNumberOfClientsQuery getSubscriptionServiceTotalNumberOfClientsQuery,
        IGetSubscriptionServiceNumberOfActiveClientsQuery getSubscriptionServiceNumberOfActiveClientsQuery)
    {
        _subscriptionServiceRepository = subscriptionServiceRepository;
        _subscriptionServiceValidator = subscriptionServiceValidator;
        _mapper = mapper;
        _getUserSubscriptionServicesQuery = getUserSubscriptionServicesQuery;
        _getSubscriptionServiceTotalNumberOfClientsQuery = getSubscriptionServiceTotalNumberOfClientsQuery;
        _getSubscriptionServiceNumberOfActiveClientsQuery = getSubscriptionServiceNumberOfActiveClientsQuery;
    }


    [Authorize]
    [HttpGet("api/getUserSubscriptionServices")]
    [EnableQuery]
    public async Task<ActionResult<List<SubscriptionServiceForListingDTO>>> GetSubscriptionServices
        (int pageNumber = PaginationConstants.DefaultPageNumber,
        int pageSize = PaginationConstants.DefaultPageSize)
    {

        // TODO: this should be removed after
        if (pageSize > 100)
        {
            pageSize = PaginationConstants.DefaultPageSize;
        }

        // get the list of subscription services of the current user
        var subscriptionServices = 
            await _getUserSubscriptionServicesQuery
            .GetUserSubscriptionServicesAsync(User.Identity.Name,
            pageNumber, pageSize);

        // map the result to a ss DTO
        var subscriptionServicesDTO = _mapper.Map<List<SubscriptionServiceForListingDTO>>(subscriptionServices);


        // populate DTOs with total number of clients and active number of clients
        for (int i= 0; i < subscriptionServices.Count(); i++)
        {
            subscriptionServicesDTO[i].TotalNumberOfClients =
                await _getSubscriptionServiceTotalNumberOfClientsQuery
                .GetSubscriptionServiceTotalNumberOfClientsAsync(subscriptionServices.ElementAt(i).Id);
            subscriptionServicesDTO[i].NumberOfActiveClients =
                await _getSubscriptionServiceNumberOfActiveClientsQuery
                .GetSubscriptionServiceNumberOfActiveClientsAsync(subscriptionServices.ElementAt(i).Id);
        }
        
        return Ok(subscriptionServicesDTO);
    }
    

    [Authorize]
    [HttpPost("api/createSS")]
    public async Task<ActionResult<SubscriptionServiceForListingDTO>> 
        CreateSubscriptionServiceAsync([FromBody] SubscriptionServiceForListingDTO subscriptionServiceDTO)
    {
        
        
        // validate DTO of Subscription Service
        ValidationResult validationResult = await _subscriptionServiceValidator.ValidateAsync(subscriptionServiceDTO);
        if(!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        // Mapping DTO to Subscription Service Entity
        var subscriptionService = new SubscriptionService(User.Identity.Name);
        _mapper.Map(subscriptionServiceDTO, subscriptionService);



        // Insert Subscription Service using the repository
        var result = await _subscriptionServiceRepository.InsertSubscriptionServiceAsync(subscriptionService);
        
        // return.
        if(!result)
        {
            return StatusCode(500, "SubscriptionService can't be added! some error has occurred");

        }
        return Ok(subscriptionServiceDTO);
    }
}
