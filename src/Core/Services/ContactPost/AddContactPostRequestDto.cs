using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ContactPost
{
    public class AddContactPostResponseDto
    {
        public required bool Error { get; set; }
        public required string Message { get; set; }
    }
    public class AddContactPostRequestDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Subject { get; set; }
        public required string Content { get; set; }

    }
}
