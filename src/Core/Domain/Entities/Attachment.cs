using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public required int ResumeId { get; set; }
        public required string Title { get; set; }
        public required string FilePath { get; set; }
    }
}
