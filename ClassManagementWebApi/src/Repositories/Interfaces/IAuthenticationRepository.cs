using ClassManagementWebApi.src.DTO.Authentication;
using ClassManagementWebApi.src.Requests.Authentication;

namespace ClassManagementWebApi.src.Repositories
{
    public interface IAuthenticationRepository
    {
        public Task<AuthenticationPostDTO> Authenticate (AuthenticationPostRequest request);
    }
}