using System.ComponentModel.DataAnnotations;
using Applications.Domain;

namespace Ecobox.Domain
{
    public class Brigade : User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? InformalName { get; set; }

        public ICollection<BrigadeMember> BrigadeMembers { get; set; }

        public ICollection<Application> AssignedApplications { get; set; }
    }
}
