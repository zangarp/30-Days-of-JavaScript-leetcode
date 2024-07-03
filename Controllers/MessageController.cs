using FinOpsAPI.Models;
using FinOpsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinOpsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;

        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetMessages")]
        public async Task<IEnumerable<Message>> GetMessages(string filter)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessages(connectionString, filter);
        }

        [HttpGet("GetMessageById")]
        public async Task<string> GetMessageById(double messageId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessageById(connectionString, messageId);
        }

        [HttpGet("GetMessageV6ById")]
        public async Task<MessageModel.MessageModel> GetMessageV6ById(int messageId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessageV6ById(connectionString, messageId);
        }

        [HttpGet("GetCodeDesc")]
        public async Task<string> GetCodeDesc(Guid messageVersion, double dataCode, double codeDirct)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetCodeDesc(connectionString, messageVersion, dataCode, codeDirct);
        }

        [HttpGet("GetAnswer")]
        public async Task<IEnumerable<Answer>> GetAnswer(double dataCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetAnswer(connectionString, dataCode);
        }

        [HttpGet("GetStatus")]
        public async Task<string> GetStatus(string status, string workstage, string messtype)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetStatus(connectionString, status, workstage, messtype);
        }

        [HttpGet("ToNextStage")]
        public async Task<string> ToNextStage(double dataCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.ToNextStage(connectionString, dataCode);
        }

        [HttpGet("ToPreviousStage")]
        public async Task<string> ToPreviousStage(double dataCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.ToPreviousStage(connectionString, dataCode);
        }

        [HttpGet("Exclude")]
        public async Task<string> Exclude(double dataCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.Exclude(connectionString, dataCode);
        }

        [HttpPost("AddAnswer")]
        public async Task<string> AddAnswer(Root root)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.AddAnswer(connectionString, root);
        }

        [HttpPost("UpdateAnswer")]
        public async Task<string> UpdateAnswer(double dataCode, [FromBody] Root root)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.UpdateAnswer(connectionString, dataCode, root);
        }

        [HttpPost("UpdateMessage")]
        public async Task<string> UpdateMessage(double messageId, [FromBody] string encodedXml)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.UpdateMessage(connectionString, messageId, encodedXml);
        }

        [HttpPost("UpdateMessageV6")]
        public async Task<string> UpdateMessage(double messageId, [FromBody] MessageModel.MessageModel data)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.UpdateMessage(connectionString, messageId, data);
        }

        [HttpGet("GetMessageByIdJson")]
        public async Task<Root> GetMessageByIdJson(double messageId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessageByIdJson(connectionString, messageId);
        }

        [HttpPost("SendMessages")]
        public async Task<string> SendMessages([FromBody] List<double> messagesId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.SendMessages(connectionString, messagesId);
        }

        [HttpGet("GetError")]
        public async Task<string> GetError(double errorCode)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetError(connectionString, errorCode);
        }

        [HttpGet("GetMessageFormInfo")]
        public async Task<MessageFormInfo> GetMessageFormInfo(double pmessid)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessageFormInfo(connectionString, pmessid);
        }

        [HttpGet("GetMessageTypeById")]
        public async Task<double> GetMessageTypeById(double messageId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetMessageTypeById(connectionString, messageId);
        }

        [HttpGet("GetRelationMessagesTree")]
        public async Task<IEnumerable<MessageHistory>> GetRelationMessagesTree(double messageId)
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.GetRelationMessagesTree(connectionString, messageId);
        }

        [HttpPost("SaveMessage")]
        public async Task<string> SaveMessage()
        {
            var connectionString = HttpContext.Items["ConnectionString"] as string;
            return await _messageService.SaveMessage(connectionString);
        }
    }
}
