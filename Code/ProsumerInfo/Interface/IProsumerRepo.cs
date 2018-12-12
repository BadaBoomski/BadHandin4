using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProsumerInfo.Models;

namespace ProsumerInfo.Interface
{
    public interface IProsumerRepo : IRepository<Prosumer>
    {
        void RemoveProsumer(int id);
        void UpdateProsumer(Prosumer prosumer);
        void InsertProsumer(Prosumer prosumer);
        void Dispose();
        void Save();
    }
}
