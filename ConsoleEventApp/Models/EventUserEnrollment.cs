using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEventApp.Models
{
    public class EventUserEnrollment
    {
        public int EventId  { get; set; }
        public Event Event { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
