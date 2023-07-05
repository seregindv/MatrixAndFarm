using System.ComponentModel.DataAnnotations;

namespace Farm.Data;

public class CreateAnimalRequest
{
    [Required(ErrorMessage = "Animal name must not be empty")]
    public string Name { get; set; } = null!;
}
