using Api.Controllers.User;
using Application.UseCases.Auction;
using Application.UseCases.Auction.Dto;
using Microsoft.AspNetCore.Mvc;

namespace projetTI2022.Controllers.Auction;

[ApiController]
[Route("api/v1/auctions")]

public class AuctionController : ControllerBase
{
    private readonly UseCaseCreateAuction _useCaseCreateAuction;
    private readonly UseCaseFetchAuctionById _useCaseFetchAuctionById;
    private readonly UseCaseFetchAllAuctions _useCaseFetchAllAuctions;


    public AuctionController(UseCaseCreateAuction useCaseCreateAuction, UseCaseFetchAuctionById useCaseFetchAuctionById, UseCaseFetchAllAuctions useCaseFetchAllAuctions)
    {
        _useCaseCreateAuction = useCaseCreateAuction;
        _useCaseFetchAuctionById = useCaseFetchAuctionById;
        _useCaseFetchAllAuctions = useCaseFetchAllAuctions;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputAuction>> FetchAll()
    {
        return Ok(_useCaseFetchAllAuctions.Exectue());
    }


    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputAuction> FetchById(int id)
    {
        try
        {
            return _useCaseFetchAuctionById.Execute(id);
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
    public ActionResult<DtoOutputAuction> Create(DtoInputCreateAuction dto)
    {
        var output = _useCaseCreateAuction.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id},
            output
        );
    }

    
    
    
}