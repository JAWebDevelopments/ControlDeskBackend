using ControlDesk.Domain.Entities;
using ControlDesk.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Application.Services
{
    public class SecurityService(ISecurityRepository repository)
    {
        public async Task<List<User>> GetAllAsync() => await repository.GetAllAsync();
    }
}
