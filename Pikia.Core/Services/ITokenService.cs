using Microsoft.AspNetCore.Identity;
using Pikia.Core.Entities.Indentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user , UserManager<AppUser> usermanager);
    }
}
