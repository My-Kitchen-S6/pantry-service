using System.ComponentModel.DataAnnotations;

namespace pantry_service.Models
{
    public class NutritionalValue
    {
        [Required]
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
        public double DietaryFibers { get; set; }
    }
}