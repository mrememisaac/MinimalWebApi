using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models;

public class UpdateProduct
{

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public required string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(250, MinimumLength = 10)]
    public required string Description { get; set; } = string.Empty;

    [Required]
    public required int Price { get; set; }

    public UpdatePicture Picture { get; set; }
}