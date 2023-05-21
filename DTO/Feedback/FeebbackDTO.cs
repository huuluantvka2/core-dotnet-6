using Model.Abtracts;

namespace DTO.Feedback
{
    public class FeebbackCreateDTO
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
    }

    public class FeebbackUpdateDTO
    {
        public string Description { get; set; }
    }

    public class FeebbackItemDTO : AuditBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
    }
}
