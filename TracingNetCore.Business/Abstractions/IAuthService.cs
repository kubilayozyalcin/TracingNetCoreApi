using TracingNetCore.Core.Concrete;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Core.Utilities.Security.Jwt;
using TracingNetCore.Entities.Dtos;

namespace TracingNetCore.Business.Abstractions
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegister, string password);

        IDataResult<User> Login(UserForLoginDto userForLogin);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
