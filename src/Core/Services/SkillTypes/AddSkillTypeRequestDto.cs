namespace Services.Skills
{
    public class AddSkillTypeRequestDto
    {
        public required string Name { get; set; }
    }
    public class AddSkillTypeResponseDto
    {
        public required bool Error { get; set; }
    }
}
