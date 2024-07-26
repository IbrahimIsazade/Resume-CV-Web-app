﻿namespace Domain.Entities
{
    public class ContactPost
    {
        public int Id { get; set; }
        public required int SenderId { get; set; }
        public required int RecieverId { get; set; }
        public required string Email { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
