using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartGridInfo.Models;
namespace SmartGridInfo.Interfaces
{
    public interface ISmartGridProsumerRepo : IRepository<SmartGridProsumer>
    {
        void RemoveSmartGridProsumer(int id);
        void UpdateSmartGridProsumer(SmartGridProsumer t);
        void InsertSmartGridProsumer(SmartGridProsumer t);
        void Dispose();
        void Save();

    }
}
