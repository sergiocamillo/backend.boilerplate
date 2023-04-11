using Smc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smc.Application.Interfaces
{
    public interface IPersonAppService
    {
        PersonViewModel GetById(long id);
    }
}
