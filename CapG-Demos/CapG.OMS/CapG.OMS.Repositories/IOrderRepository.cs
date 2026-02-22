using CapG.OMS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.OMS.Repositories
{
    public interface IOrderRepository : IRepository<OrderInputDto>
    {
        bool Cancel(int id);
    }
}
