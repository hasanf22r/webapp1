using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp1.Models;

namespace webapp1.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}