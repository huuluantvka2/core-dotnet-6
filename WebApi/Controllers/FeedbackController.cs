using DTO.Feedback;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApi.Controllers
{
    [Authorize]
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
        public ActionResult Create([FromBody] FeebbackCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _feedbackService.Create(dto);
            return Ok(new { success = true });
        }

        [HttpGet("")]
        public async Task<ActionResult> GetFeedBacks()
        {
            var data = await _feedbackService.GetFeedBacks();
            if (data.Count == 0)
            {
                return NoContent();
            }
            return Ok(new { success = true, data = data });
        }
    }
}
