using CapG.MTBS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public interface IUserRepository
    {
        string Login(LoginDto login);
    }
}
