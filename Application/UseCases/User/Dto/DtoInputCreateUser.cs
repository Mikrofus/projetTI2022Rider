using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.User.Dto;

public class DtoInputCreateUser
{
    [Required] public string Nom { get ; set; }
    [Required] public string Prenom { get ; set; }
}