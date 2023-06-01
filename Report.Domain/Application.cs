using System.ComponentModel.DataAnnotations;
using Ecobox.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Applications.Domain
{
    [Index(nameof(BrigadeId), IsUnique = false)]
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

        public ApplicationStatus Status{ get; set; }
        public bool IsActive { get; set; } = true;

        public int UserId { get; set; }
        public User User { get; set; }

        public int? BrigadeId { get; set; }

    }
}