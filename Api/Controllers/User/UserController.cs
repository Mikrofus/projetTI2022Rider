using Application.UseCases.User;
using Application.UseCases.User.Dto;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly UseCaseCreateUser _useCaseCreateUser;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UseCaseFetchAllUsers _useCaseFetchAllUser;

    public UserController(UseCaseCreateUser useCaseCreateUser, UseCaseFetchUserById useCaseFetchUserById, UseCaseFetchAllUsers useCaseFetchAllUser)
    {
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseFetchAllUser = useCaseFetchAllUser;
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
    public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
    {
        var output = _useCaseCreateUser.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id},
            output
        );
    }
}