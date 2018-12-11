using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prosumer.Interfaces;
using Prosumer.Models;

namespace Prosumer.Interface
{
    public interface IProsumerRepo : IRepository<Models.Prosumer>
    {
        void RemoveProsumer(int id);
        void UpdateProsumer(Models.Prosumer prosumer);
        void InsertProsumer(Models.Prosumer prosumer);
        void Dispose();
        void Save();
    }
}
