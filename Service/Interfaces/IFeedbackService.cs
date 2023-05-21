using DTO.Feedback;

namespace Service.Interfaces
{
    public interface IFeedbackService
    {
        void Create(FeebbackCreateDTO dto);
        void Update(FeebbackUpdateDTO dto);
        List<FeebbackItemDTO> Get();
    }
}
