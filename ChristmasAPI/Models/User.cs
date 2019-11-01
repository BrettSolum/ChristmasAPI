using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace ChristmasAPI.Models {
    public class User {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string First { get; set; }
        
        [Required, MaxLength(200)]
        public string Last { get; set; }
        
        public int? SpouseId { get; set; }

        public string SpouseName { get; set; }

        [Required]
        public int FamilyId { get; set; }

        public int? ExchangeUserId { get; set; }

        public string ExchangeUserName { get; set; }
    }
}
