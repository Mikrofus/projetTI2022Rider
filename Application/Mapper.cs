using Application.UseCases.Auction.Dto;
using Application.UseCases.User.Dto;
using AutoMapper;
using Domain;
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

        });
        return new AutoMapper.Mapper(config);
    }
}