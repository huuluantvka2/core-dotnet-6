using System.ComponentModel.DataAnnotations;

namespace DTO.User
{
    public class UserCreateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class UserItemDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserLoginSucessDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
