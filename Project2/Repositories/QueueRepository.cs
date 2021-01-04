using Project2.Data;
using Project2.Model;
using Project2.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly DataContext _context;
        public QueueRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddMessage(Message message)
        {
            _context.Messages.Add(message);
            return (await _context.SaveChangesAsync()) > 0;
        }
        public Task<Message> GetUnHandledEmailMessage()
        {
            var message = await _context.Message.Where(x => !x.Handled && x.Type == "email").OrderBy(x => x.AddAt).FirstOrDefaultAsync();
            return message;
        }

        public Task<Message> GetUnHandledLoggingMessage()
        {
            var message = await _context.Message.Where(x => !x.Handled && x.Type == "login").OrderBy(x => x.AddAt).FirstOrDefaultAsync();
            return message;

        }

        public Task<bool> SetHandled(Guid messageId)
        {
            var message = _context.Messages.Where(x => x.Id == messageId).FirstOrDefault();
            if (message == null)
                return false;
                message.Handled = true;
                message.HandledAt = DateTime.Now;
                return (await _context.SaveChangesAsync())>0;
            
        }

        
    }
}
