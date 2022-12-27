using ISIParkAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ISIParkAPI.Data.Repositories.Interfaces
{
    public interface IUserMessageRepository
    {
        Task<IEnumerable<UserMessage>> GetAllUserMessage();
        Task<UserMessage> GetUserMessageID(int utilizadorid);
        Task<bool> InsertUserMessage(UserMessage userMessage);
        Task<bool> UpdateUserMessage(UserMessage userMessage);
        Task<bool> DeleteUserMessage(UserMessage userMessage);
    }
}
