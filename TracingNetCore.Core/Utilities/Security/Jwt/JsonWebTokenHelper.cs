using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TracingNetCore.Core.Concrete;

namespace TracingNetCore.Core.Utilities.Security.Jwt
{
    public class JsonWebTokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }

        private TokenOptions _tokenOptions;

        public JsonWebTokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection(key:"TokenOption").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            throw new NotImplementedException();
        }
    }
}
