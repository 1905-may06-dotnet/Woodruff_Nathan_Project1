using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public enum Location
    {
        Dallas,
        [Display(Name = "Ft. Worth")]
        FtWorth,
        Arlington,
        Irving,
        Garland,
        Plano
    }

    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username can be a maximum of 50 characters", MinimumLength = 1)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password can be a maximum of 50 characters", MinimumLength = 1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
    }
}
