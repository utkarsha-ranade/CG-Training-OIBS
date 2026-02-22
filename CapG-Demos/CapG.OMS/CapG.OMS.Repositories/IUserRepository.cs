using CapG.OMS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.OMS.Repositories
{
    public interface IUserRepository
    {
        string Login(LoginDto login);
    }
}
