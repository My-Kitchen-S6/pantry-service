using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pantry_service.Models
{
    public class Ingredient
    {
        [Required] 
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        
        public User User { get; set; }
        
        public string Name { get; set; }
        
        public double Amount { get; set; }
        
        public bool Volume { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}