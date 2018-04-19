using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;

namespace TimeManagementSystem.BLL.Interfaces
{
    interface ITeammateService
    {
        void Delete(TeammateDTO teammateDTO);
        void Edit(TeammateDTO teammate);
    }
}
