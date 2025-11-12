using ControlDesk.Domain.Interfaces;
using System;

namespace ControlDesk.Infrastructure.Data
{
    public class UnitOfWork(ControlDeskContext context) : IUnitOfWork
    {
        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
    }
}
