using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.UserDTO;

public class DtoInputCreateUser
{
    [Required] public string Pseudo { get ; set; }
    [Required] public string Mail { get ; set; }
    [Required] public string Pass { get ; set; }
}