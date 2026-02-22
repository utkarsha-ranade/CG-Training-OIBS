using Capgemini.OIBS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.OIBS.Repositories
{
    public interface IAuthRepository
    {
        string Login(LoginDTO dto);
        bool Update(LoginDTO dto);
    }
}
