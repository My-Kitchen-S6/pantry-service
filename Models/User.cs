using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pantry_service.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Auth0Id { get; set; }
        
        public string UserName { get; set; }
        
        public ICollection<Ingredient> Pantry { get; set; }
    }
}