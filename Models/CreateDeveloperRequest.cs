using System.ComponentModel.DataAnnotations;

namespace webApiDotNetTrainingGround.Models
{
    public class CreateDeveloperRequest
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Role { get; set; }
        [Required]
        public int? Experience { get; set; }
    }
}