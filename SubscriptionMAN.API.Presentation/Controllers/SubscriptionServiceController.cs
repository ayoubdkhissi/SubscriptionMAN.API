using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubscriptionMAN.API.Core.Entities;
using SubscriptionMAN.API.Core.Interfaces.Repository;
using SubscriptionMAN.API.Presentation.Utils.Requests;

namespace SubscriptionMAN.API.Presentation.Controllers;
public class SubscriptionServiceController : Controller
{
    private readonly ISubscriptionServiceRepository _subscriptionServiceRepository;
    private readonly IValidator<SubscriptionServiceDTO> _subscriptionServiceValidator;
    private readonly IMapper _mapper;

    public SubscriptionServiceController(ISubscriptionServiceRepository subscriptionServiceRepository, 
        IValidator<SubscriptionServiceDTO> subscriptionServiceValidator, 
        IMapper mapper)
    {
        _subscriptionServiceRepository = subscriptionServiceRepository;
        _subscriptionServiceValidator = subscriptionServiceValidator;
        _mapper = mapper;
    }




    [Authorize]
    [HttpPost("api/createSS")]
    public async Task<ActionResult<SubscriptionServiceDTO>> 
        CreateSubscriptionServiceAsync([FromBody] SubscriptionServiceDTO subscriptionServiceDTO)
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
