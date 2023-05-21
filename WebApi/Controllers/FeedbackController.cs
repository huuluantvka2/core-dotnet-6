using DTO.Feedback;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost("")]
        public ActionResult Get([FromBody] FeebbackCreateDTO dto)
        {
            dto.UserId = Guid.Parse("ce5be9a5-59f7-4d57-8425-771a8e31b0d6");
            _feedbackService.Create(dto);
            return Ok(new { success = true });
        }
    }
}
