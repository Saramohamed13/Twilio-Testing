using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTwilioDemo.dto;
using TestTwilioDemo.services;

namespace TestTwilioDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSservices _smsService;
        private readonly IEmailService emailService;

        public SMSController(ISMSservices smsService , IEmailService _emailService)
        {
            _smsService = smsService;
            emailService = _emailService;
        }

        [HttpPost("sendSMS")]
        public IActionResult sendSMS(SendSMSDto dto)
        {
            var result = _smsService.sendSMS(dto.MobileNumber, dto.Body);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
        [HttpPost("sendWhats")]
        public IActionResult sendWhatsApp(SendSMSDto dto)
        {
            var result = _smsService.sendWhatsApp(dto.MobileNumber, dto.Body);

            return Ok(result);
        }
        [HttpPost("sendEmail")]
        public IActionResult sendEmail(string Email)
        {
            var message = new Message(new string[] { Email }, "test smtp", "This year's semester has been cancelled");
        
            emailService.SendEmail(message);
            return Ok();
        }
    }
}
