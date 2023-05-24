using DTO.Feedback;
using Model.Entities;

namespace UnitTest.MockData
{
    public class FeedbackMockData
    {
        public static List<FeebbackItemDTO> GetFeedBacks()
        {
            var userId = Guid.NewGuid();
            return new List<FeebbackItemDTO>()
            {
                new FeebbackItemDTO()
                {
                    Id = Guid.NewGuid(),
                    Description = "Mo ta 1",
                    CreatedAt = DateTime.Now,
                    CreatedBy = userId.ToString(),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = userId.ToString(),
                    UserId = userId
                },
                new FeebbackItemDTO()
                {
                    Id = Guid.NewGuid(),
                    Description = "Mo ta 2",
                    CreatedAt = DateTime.Now,
                    CreatedBy = userId.ToString(),
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = userId.ToString(),
                    UserId = userId
                }
            };
        }

        public static List<FeedBack> GetFeedBackEntities()
        {
            var feedbackEntities = new List<FeedBack>
            {
                new FeedBack
                {
                    Id = Guid.NewGuid(),
                    Description = "Feedback 1",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "User1",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "User2",
                    UserId = Guid.NewGuid()
                },
                new FeedBack
                {
                    Id = Guid.NewGuid(),
                    Description = "Feedback 2",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "User2",
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = "User1",
                    UserId = Guid.NewGuid()
                }
            };
            return feedbackEntities;
        }
        public static List<FeebbackItemDTO> GetFeedBacksEmpty()
        {
            return new List<FeebbackItemDTO>() { };
        }
    }
}