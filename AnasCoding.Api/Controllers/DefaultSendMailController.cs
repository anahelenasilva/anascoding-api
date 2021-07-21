using System.Net;
using System.Net.Http;
using AnasCoding.Domain.Messaging;
using AnasCoding.Infra.Interfaces;
using AnasCoding.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnasCoding.Api.Controllers
{
    [ApiController]
    [Route("mails")]
    public class DefaultSendMailController : ControllerBase
    {
        private readonly ISendMail _defaultSendMailService;

        public DefaultSendMailController(ISendMail defaultSendMailService)
        {
            _defaultSendMailService = defaultSendMailService;
        }

        [HttpPost]
        public IActionResult Send([FromBody] SendMailRequest sendMailRequest)
        {
            var result = _defaultSendMailService.SendMail(sendMailRequest);
            return Ok(result);
        }
    }
}