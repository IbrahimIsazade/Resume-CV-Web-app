using Repositories;
using Services.ContactPost;

namespace Services.Impl
{
    public class ContactPostService(IContactPostRepository contactPostRepository) : IContactPostService
    {
        public async Task<AddContactPostResponseDto> Add(AddContactPostRequestDto model)
        {

            var post = new Domain.Entities.ContactPost
            {
                FullName = model.FullName,
                Email = model.Email,
                Subject = model.Subject,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow,
            };

            try
            {
                await contactPostRepository.AddAsync(post);
                await contactPostRepository.SaveAsync();
            }
            catch
            {
                return new AddContactPostResponseDto { Error = true, Message = "Your message hasn't been sent" };
            }

            return new AddContactPostResponseDto { Error = false, Message = "Your message has been sent" };
        }
    }
}