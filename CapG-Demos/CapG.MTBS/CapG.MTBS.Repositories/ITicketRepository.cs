using CapG.MTBS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        bool Cancel(int id);
    }
}
