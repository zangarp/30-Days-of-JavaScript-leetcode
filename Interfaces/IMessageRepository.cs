using FinOpsAPI.Models;
using MessageModel.Models;

namespace FinOpsAPI.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync(string connString, MessageFilter filter);

        Task<string> GetMessageById(string connString, double messageId);
        Task<MessageModel.MessageModel> GetMessageV6ById(string connString, double messageId);

        Task<string> GetCodeDesc(string connString, Guid messageVersion, double dataCode, double codeDirct);
        Task<IEnumerable<Answer>> GetAnswer(string connString, double dataCode);
        Task<string> GetStatus(string connString, string status, string workstage, string messtype);
        Task<string> ToNextStage(string connString, double dataCode);
        Task<string> ToPreviousStage(string connString, double messageId);
        Task<string> Exclude(string connString, double messageId);
        Task<string> AddAnswer(string connString, Root root);
        Task<string> UpdateAnswer(string connString, double messageId, Root? root = null);
        Task<string> UpdateMessage(string connString, double messageId, string xml);
        Task<Root> GetMessageByIdJson(string connString, double messageId);
        Task<string> SendMessages(string connString, List<double> messagesId);
        Task<string> GetError(string connString, double errorCode);
        Task<MessageFormInfo> GetMessageFormInfo(string connString, double pmessid);
        Task<double> GetMessageTypeById(string connString, double messageId);
        Task<IEnumerable<MessageHistory>> GetRelationMessagesTree(string connString, double messageId);
        Task<string> SaveMessage(string connString);
    }
}
