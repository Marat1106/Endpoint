using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Dto
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string JsonContent { get; set; }

    }
}
