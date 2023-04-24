using System.ComponentModel.DataAnnotations;

namespace Ecobox.Domain
{
    public class BrigadeMember
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string ContactPhone { get; set; }

        [MaxLength(30)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? WorkExperience { get; set; }

        public int? BrigadeId { get; set; }
        public Brigade? Brigade { get; set; }
    }
}
