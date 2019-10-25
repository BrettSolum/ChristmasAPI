using System.ComponentModel.DataAnnotations;

namespace ChristmasAPI.Models {
    public class User {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string First { get; set; }
        
        [Required]
        public string Last { get; set; }
        
        [Required]
        public int SpouseId { get; set; }
        
        [Required]
        public int Family { get; set; }
        
        [Required]
        public int Exchange { get; set; }
    }
}
