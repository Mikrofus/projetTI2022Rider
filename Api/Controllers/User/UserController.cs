using Application.UseCases.User;
using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Ef.DTOs;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly UseCaseCreateUser _useCaseCreateUser;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UseCaseFetchAllUsers _useCaseFetchAllUser;
    
    //JWT
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;
    private string _generatedToken = null;  
    public UserController(UseCaseCreateUser useCaseCreateUser, UseCaseFetchUserById useCaseFetchUserById, UseCaseFetchAllUsers useCaseFetchAllUser, ITokenService tokenService, IConfiguration config)
    {
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseFetchAllUser = useCaseFetchAllUser;
        _tokenService = tokenService;
        _config = config;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCaseFetchAllUser.Exectue());
    }


    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchById(int id)
    {
        try
        {
            return _useCaseFetchUserById.Execute(id);
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
    public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
    {
        var output = _useCaseCreateUser.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id},
            output
        );
    }
    
    [HttpGet]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult BuildToken(string pseudo, string password)
    {
        IEnumerable<DtoOutputUser> users = _useCaseFetchAllUser.Exectue();
        DtoOutputUser u1 = users
            .Where(u => u.Pseudo.ToUpper().Equals(pseudo.ToUpper()) && u.Pass.ToUpper().Equals(password.ToUpper()))
            .FirstOrDefault();
        if (u1 != null)
        {
            string key = _config["Jwt:Key"];
            string token = _tokenService.BuildToken(key, "Oui", u1);
            Response.Cookies.Append("Kyky le cookie", token);
            return Ok("Yeaaaah ça marche !");
        }

        return Problem("PasOk");
    }

    
    
    [HttpPost]
    [Route("login")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult ValidateToken(string pseudo, string password)
    {
        return Ok("T'es accepté héhé!");
    }
    

}