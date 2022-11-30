using System;

namespace pantry_service.DTOs
{
    public class CreateIngredient
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        
        public double Amount { get; set; }
        
        public bool Volume { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}