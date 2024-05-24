using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Requests.Authentication;

namespace class_management_web_api.src.Repositories
{
    public interface IAuthenticationPostRepository
    {
        public Task<AuthenticationPostDTO> Authenticate (AuthenticationPostRequest request);
    }
}