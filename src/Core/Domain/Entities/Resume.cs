using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string Bio { get; set; }
    }
}
