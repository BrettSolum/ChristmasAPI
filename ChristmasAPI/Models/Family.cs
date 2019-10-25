using System.ComponentModel.DataAnnotations;

namespace ChristmasAPI.Models {
    public class Family {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
