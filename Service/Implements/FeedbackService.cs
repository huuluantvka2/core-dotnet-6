using Data.Infracstructure;
using DTO.Feedback;
using Model.Entities;
using Service.Interfaces;

namespace Service.Implements
{
    public class FeedbackService : IFeedbackService
    {
        private IUnitOfWork UnitOfWork { get; set; }
        public FeedbackService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void Create(FeebbackCreateDTO dto)
        {
            var entity = new FeedBack()
            {
                Description = dto.Description,
                UserId = dto.UserId,
            };
            UnitOfWork.FeedBacksRepo.Insert(entity);
            UnitOfWork.SaveChanges();
        }

        public List<FeebbackItemDTO> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(FeebbackUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
