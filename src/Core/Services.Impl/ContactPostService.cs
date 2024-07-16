using Repositories;
using Domain.Entities;
using Services.ContactPost;

namespace Services.Impl
{
    public class ContactPostService(IContactPostRepository contactPostRepository) : IContactPostService
    {
        public async Task<AddContactPostResponseDto> Add(AddContactPostRequestDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var post = new Domain.Entities.ContactPost
            {
                FullName = model.FullName,
                Email = model.Email,
                Subject = model.Subject,
                Content = model.Content,
                CreatedAt = DateTime.Now,
            };

            await contactPostRepository.AddAsync(post);
            await contactPostRepository.SaveAsync();

            return new AddContactPostResponseDto { FullName = post.FullName };
        }
    }
}
