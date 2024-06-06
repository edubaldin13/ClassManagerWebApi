using class_management_web_api.src.DTO.Authentication;
using class_management_web_api.src.Requests.Authentication;

namespace class_management_web_api.src.Repositories
{
    public interface IAuthenticationRepository
    {
        public Task<AuthenticationPostDTO> Authenticate (AuthenticationPostRequest request);
    }
}