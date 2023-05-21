using Model.Abtracts;
using Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities
{
    [Table("FeedBacks")]
    public class FeedBack : AuditBase, IEntity<Guid>
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
