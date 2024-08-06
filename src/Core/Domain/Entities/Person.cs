using Domain.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : ICreateEntity
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required byte Experience { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public string? Location { get; set; }
        public required Degrees Degree { get; set; }
        public required string Bio { get; set; }
        public required string Fax { get; set; }
        public string? Website { get; set; }
        public string? AttachmentPath { get; set; }
        public required CareerLevels CareerLevel { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
