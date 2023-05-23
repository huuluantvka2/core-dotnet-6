using Microsoft.AspNetCore.Identity;
using Model.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities.Identities
{
    [Table("Users")]
    public class User : IdentityUser<Guid>, IEntity<Guid>, IAudit
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
