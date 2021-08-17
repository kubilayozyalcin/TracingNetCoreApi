using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracingNetCore.Business.Abstractions;
using TracingNetCore.Business.Constants;
using TracingNetCore.Core.Concrete;
using TracingNetCore.Core.Utilities.Hashing;
using TracingNetCore.Core.Utilities.Results;
using TracingNetCore.Core.Utilities.Security.Jwt;
using TracingNetCore.Entities.Dtos;

namespace TracingNetCore.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(DataMessages.AccessTokenCreated);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegister, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsStatus = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(DataMessages.UserRegistered);   
        }

        public IDataResult<User> Login(UserForLoginDto userForLogin)
        {
            var userToCheck = _userService.GetByEmail(userForLogin.Email);
            if (userToCheck == null) return new ErrorDataResult<User>(DataMessages.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<User>(DataMessages.PasswordError);

            return new SuccessDataResult<User>(DataMessages.SuccessfulLogin);  
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
                return new ErrorResult(DataMessages.UserAlreadyExists);
            return new SuccessResult();
        }
    }
}
