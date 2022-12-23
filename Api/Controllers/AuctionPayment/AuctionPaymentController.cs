using Application.UseCases.AuctionPayment;
using Application.UseCases.AuctionPayment.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AuctionPayment;

[ApiController]
[Route("api/v1/auctionPayment")]

public class AuctionPaymentController : ControllerBase
{

    private readonly UseCaseFetchAllAuctionPayment _useCaseFetchAllAuctionPayment;
    private readonly UseCaseCreateAuctionPayment _useCaseCreateAuctionPayment;
    private readonly UseCaseFetchByIdAuctionPayment _useCaseFetchByIdAuctionPayment;

    public AuctionPaymentController(UseCaseFetchAllAuctionPayment useCaseFetchAllAuctionPayment, UseCaseCreateAuctionPayment useCaseCreateAuctionPayment, UseCaseFetchByIdAuctionPayment useCaseFetchByIdAuctionPayment)
    {
        _useCaseFetchAllAuctionPayment = useCaseFetchAllAuctionPayment;
        _useCaseCreateAuctionPayment = useCaseCreateAuctionPayment;
        _useCaseFetchByIdAuctionPayment = useCaseFetchByIdAuctionPayment;
    }
    
    
    [HttpGet]
    [Authorize]
    [Route("fetchAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<DtoOutPutAuctionPayment>> FetchAll()
    {
        try
        {
            var idUser = User.Claims.First(claim => claim.Type == "IdUser").Value;

            return Ok(_useCaseFetchAllAuctionPayment.Execute(Convert.ToInt32(idUser)));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutPutAuctionPayment> FetchById(int id)
    {
        try
        {
            return _useCaseFetchByIdAuctionPayment.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    
    [HttpPost]
    [Route("create")]
    public ActionResult <DtoOutPutAuctionPayment> Create(DtoInputCreateAuctionPayment dto)
    {
        var output = _useCaseCreateAuctionPayment.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }
}