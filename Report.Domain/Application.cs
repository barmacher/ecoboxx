using System.ComponentModel.DataAnnotations;

namespace Applications.Domain
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(300)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string Adress { get; set; }

        public int Number { get; set; }

        public DateTime CreationDate { get; set; }
        
        public DateTime? EditDate { get; set;}

        public int UserId { get; set; }
        public User User { get; set; }
    }
}