using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Social
    {
        public int Id { get; set; }
        public required int ResumeId { get; set; }
        public required string Url { get; set; }
    }
}
