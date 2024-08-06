using System.ComponentModel.DataAnnotations;

namespace Flash_Fusion.Application._System._Login.Dto
{
    public class LoginDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

    }
}
