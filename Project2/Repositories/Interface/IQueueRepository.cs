using Project2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Repositories.Interface
{
    public interface IQueueRepository
    {
        Task<bool> AddMessage(Message message);
        Task<bool> SetHandled(Guid messageId);
        Task<Message> GetUnHandledEmailMessage();
        Task<Message> GetUnHandledLoggingMessage();
        Task GetUnhandledEmailMessage();
    }


}
