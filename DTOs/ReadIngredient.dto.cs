using System.Collections.Generic;

namespace pantry_service.DTOs
{
    public class ReadIngredient
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public double Amount { get; set; }
        
        public bool Volume { get; set; }
        
        public ReadNutritionalValue NutritionalValue { get; set; }
    }
}