using Repositories;
using Services.ContactPost;
using Domain.Entities;

namespace Services.Impl
{
    public class ContactPostService(IContactPostRepository contactPostRepository) : IContactPostService
    {
        public async Task<AddContactPostResponseDto> Add(AddContactPostRequestDto model, int id)
        {

            var post = new Domain.Entities.ContactPost
            {
                SenderId = id,
                RecieverId = 1,
                Title = model.Title,
                Email = model.Email,
                Content = model.Content
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