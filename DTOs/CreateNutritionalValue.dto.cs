namespace pantry_service.DTOs
{
    public class CreateNutritionalValue
    {
        public int IngredientId { get; set; }
        public double Calories { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Salt { get; set; }
        public double DietaryFibers { get; set; }
    }
}