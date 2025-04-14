using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSDapper.Model;

namespace IMSDapper.Repository.Interface
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(LoginRequest request);
        Task<string?> Authenticate(LoginRequest request);
    }
}
