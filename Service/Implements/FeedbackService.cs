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
            };
            UnitOfWork.FeedBacksRepo.Insert(entity);
            UnitOfWork.SaveChanges();
        }

        public List<FeebbackItemDTO> Get()
        {
            var entities = UnitOfWork.FeedBacksRepo.GetAll().Select(x => new FeebbackItemDTO()
            {
                Id = x.Id,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy,
                UserId = x.UserId
            }).ToList();
            return entities;
        }

        public void Update(FeebbackUpdateDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
