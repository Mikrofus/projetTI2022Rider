using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.UseCases.User;
using Domain.Dto;
using Domain.Dto.UserDTO;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Ef.DTOs;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
    private readonly UseCaseLogin _useCaseLogin;
    public UserController(UseCaseCreateUser useCaseCreateUser, UseCaseFetchUserById useCaseFetchUserById, UseCaseFetchAllUsers useCaseFetchAllUser, ITokenService tokenService, IConfiguration config, UseCaseLogin useCaseLogin)
    {
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseFetchAllUser = useCaseFetchAllUser;
        _tokenService = tokenService;
        _config = config;
        _useCaseLogin = useCaseLogin;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCaseFetchAllUser.Exectue());
    }


    // [HttpGet]
    // [Route("{id:int}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public ActionResult<DtoOutputUser> FetchById(int id)
    // {
    //     try
    //     {
    //         return _useCaseFetchUserById.Execute(id);
    //     }
    //     catch (KeyNotFoundException e)
    //     {
    //         return NotFound(new
    //         {
    //             e.Message
    //         });
    //     }
    // }
    //
    
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

    private String CreateToken(DtoOutputUser user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("IdUser", user.Id.ToString()),
            new Claim("Email", user.Mail)
        };


        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
       
        return jwtToken;
    }

    
    
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ValidateToken(DtoLoginUser dto)
    {
        var user = _useCaseLogin.Execute(dto);
        
        if (user != null)
        {
            string token = this.CreateToken(user);
            Response.Cookies.Append("SuperCookie", token, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true
            });

            return Ok(user);
        }

        return Unauthorized();
    }
    
    
    [HttpGet]
    [Authorize]
    [Route("fetchById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchById()
    {
        try
        {
            var idUser = User.Claims.First(claim => claim.Type == "IdUser").Value;

            return Ok(_useCaseFetchUserById.Execute(Convert.ToInt32(idUser)));
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    
    [HttpDelete]
    [Route("disconnect")]
    [ProducesResponseType((StatusCodes.Status200OK))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Disconnect()
    {
        Response.Cookies.Delete("SuperCookie");
        return Ok();
    }

    
    

    

}