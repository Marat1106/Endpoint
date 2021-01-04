using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Model
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string JsonContent { get; set; }
        public bool Handled{ get; set; }
        public DateTime AddAt{ get; set; }
        public DateTime?HandledAt { get; set; }
    }
}
