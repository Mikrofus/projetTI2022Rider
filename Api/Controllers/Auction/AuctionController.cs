using Api.Controllers.User;
using Application.UseCases.Auction;
using Application.UseCases.Auction.Dto;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace projetTI2022.Controllers.Auction;

[ApiController]
[Route("api/v1/auctions")]

public class AuctionController : ControllerBase
{
    private readonly UseCaseCreateAuction _useCaseCreateAuction;
    private readonly UseCaseFetchAuctionById _useCaseFetchAuctionById;
    private readonly UseCaseFetchAllAuctions _useCaseFetchAllAuctions;
    private readonly UseCaseSetTopBidAuction _useCaseSetTopBidAuction;
    private readonly UseCaseDeleteAuction _useCaseDeleteAuction;


    public AuctionController(UseCaseCreateAuction useCaseCreateAuction, UseCaseFetchAuctionById useCaseFetchAuctionById, UseCaseFetchAllAuctions useCaseFetchAllAuctions, UseCaseSetTopBidAuction useCaseSetTopBidAuction, UseCaseDeleteAuction useCaseDeleteAuction)
    {
        _useCaseCreateAuction = useCaseCreateAuction;
        _useCaseFetchAuctionById = useCaseFetchAuctionById;
        _useCaseFetchAllAuctions = useCaseFetchAllAuctions;
        _useCaseSetTopBidAuction = useCaseSetTopBidAuction;
        _useCaseDeleteAuction = useCaseDeleteAuction;
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
    [Route("create")]
    public ActionResult<DtoOutputAuction> Create(DtoInputCreateAuction dto)
    {
        var output = _useCaseCreateAuction.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id},
            output
        );
    }


    [HttpPut]
    [Route("setTopBid")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputAuction> SetTopBid(DbAuction auction)
    {
        return _useCaseSetTopBidAuction.Execute(auction);
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputAuction> Delete(int id)
    {
        return _useCaseDeleteAuction.Execute(id);
    }




}