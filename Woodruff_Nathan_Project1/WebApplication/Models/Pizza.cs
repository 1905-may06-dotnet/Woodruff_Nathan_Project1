using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public enum PizzaType
    {
        vegetarian,
        margherita,
        supreme,
        hawaiian,
        mediterranean,
        cheese
    }

    public enum Crust
    {
        crispy,
        fluffy,
        [Display(Name = "Cheese-Stuffed")]
        cheesestuffed
    }

    public enum Size
    {
        small,
        medium,
        large
    }

    public class Pizzas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Size is required")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Crust is required")]
        public string Crust { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        public decimal? Cost { get; set; }
    }
}
