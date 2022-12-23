using Application.UseCases.Auction.Dto;
using Application.UseCases.AuctionPayment.Dto;
using AutoMapper;
using Domain;
using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef.DbEntities;

namespace Application;

public static class Mapper
{
    private static AutoMapper.Mapper _instance;

    public static AutoMapper.Mapper GetInstance()
    {
        return _instance ??= CreateMapper();
    }

    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Source, Destination
            // User
            cfg.CreateMap<User, DtoOutputUser>();
            cfg.CreateMap<DbUser, DtoOutputUser>();
            cfg.CreateMap<DbUser, User>();
            
            // Auction
            cfg.CreateMap<Auction, DtoOutputAuction>();
            cfg.CreateMap<DbAuction, DtoOutputAuction>();
            cfg.CreateMap<DbAuction, Auction>();
            
            // Auction Payment
            cfg.CreateMap<AuctionPayment, DtoOutPutAuctionPayment>();
            cfg.CreateMap<DbAuctionPayment, DtoOutPutAuctionPayment>();
            cfg.CreateMap<DbAuctionPayment, AuctionPayment>();

        });
        return new AutoMapper.Mapper(config);
    }
}