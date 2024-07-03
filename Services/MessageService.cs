using FinOpsAPI.Interfaces;
using FinOpsAPI.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;

namespace FinOpsAPI.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> GetMessages(string connectionString, string filter)
        {
            var msgFilter = JsonConvert.DeserializeObject<MessageFilter>(filter);
            if (msgFilter.ForLastDays)
            {
                msgFilter.ReceiveDateBegin = DateTime.Today.AddDays(-msgFilter.LastDays);
            }

            return await _messageRepository.GetMessagesAsync(connectionString, msgFilter);
        }

        public async Task<string> GetMessageById(string connectionString, double messageId)
        {
            return await _messageRepository.GetMessageById(connectionString, messageId);
        }

        public async Task<MessageModel.MessageModel> GetMessageV6ById(string connectionString, int messageId)
        {
            return await _messageRepository.GetMessageV6ById(connectionString, messageId);
        }

        public async Task<string> GetCodeDesc(string connectionString, Guid messageVersion, double dataCode, double codeDirct)
        {
            return await _messageRepository.GetCodeDesc(connectionString, messageVersion, dataCode, codeDirct);
        }

        public async Task<IEnumerable<Answer>> GetAnswer(string connectionString, double dataCode)
        {
            return await _messageRepository.GetAnswer(connectionString, dataCode);
        }
        public async Task<string> GetStatus(string connectionString, string status, string workstage, string messtype)
        {
            return await _messageRepository.GetStatus(connectionString, status, workstage, messtype);
        }
        public async Task<string> ToNextStage(string connectionString, double dataCode)
        {
            return await _messageRepository.ToNextStage(connectionString, dataCode);
        }

        public async Task<string> ToPreviousStage(string connectionString, double dataCode)
        {
            return await _messageRepository.ToPreviousStage(connectionString, dataCode);
        }

        public async Task<string> Exclude(string connectionString, double dataCode)
        {
            return await _messageRepository.Exclude(connectionString, dataCode);
        }

        public async Task<string> AddAnswer(string connectionString, Root root)
        {
            return await _messageRepository.AddAnswer(connectionString, root);
        }
        public async Task<string> UpdateAnswer(string connectionString, double dataCode, Root? root = null)
        {
            return await _messageRepository.UpdateAnswer(connectionString, dataCode, root);
        }

        public async Task<string> UpdateMessage(string connectionString, double messageId, string encodedXml)
        {
            byte[] data = Convert.FromBase64String(encodedXml);
            var xml = System.Text.Encoding.UTF8.GetString(data);

            return await _messageRepository.UpdateMessage(connectionString, messageId, xml);
        }

        public async Task<string> UpdateMessage(string connectionString, double messageId, MessageModel.MessageModel data)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(MessageModel.MessageModel));
            var xml = String.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data);
                    xml = sww.ToString(); // Your XML
                }
            }

            return await _messageRepository.UpdateMessage(connectionString, messageId, xml);
        }

        public async Task<Root> GetMessageByIdJson(string connectionString, double messageId)
        {
            return await _messageRepository.GetMessageByIdJson(connectionString, messageId);
        }

        public async Task<string> SendMessages(string connectionString, List<double> messagesId)
        {
            return await _messageRepository.SendMessages(connectionString, messagesId);
        }
        public async Task<string> GetError(string connectionString, double errorCode)
        {
            return await _messageRepository.GetError(connectionString, errorCode);
        }
        
        public async Task<MessageFormInfo> GetMessageFormInfo(string connectionString, double pmessid)
        {
            return await _messageRepository.GetMessageFormInfo(connectionString, pmessid);
        }

        public async Task<double> GetMessageTypeById(string connectionString, double messageId)
        {
            return await _messageRepository.GetMessageTypeById(connectionString, messageId);
        }

        public async Task<IEnumerable<MessageHistory>> GetRelationMessagesTree(string connectionString, double messageId)
        {
            return await _messageRepository.GetRelationMessagesTree(connectionString, messageId);
        }

        public async Task<string> SaveMessage(string connectionString)
        {
            return await _messageRepository.SaveMessage(connectionString);
        }

    }
}
