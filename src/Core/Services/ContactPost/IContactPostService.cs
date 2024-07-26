namespace Services.ContactPost
{
    public interface IContactPostService
    {
        Task<AddContactPostResponseDto> Add(AddContactPostRequestDto model, int id);
    }
}
