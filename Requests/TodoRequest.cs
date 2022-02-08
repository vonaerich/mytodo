using System.ComponentModel.DataAnnotations;

public record TodoRequest
{
  [Required]
  public string TodoItem { get; init; }
}