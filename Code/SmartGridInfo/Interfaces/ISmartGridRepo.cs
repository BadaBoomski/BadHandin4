using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartGridInfo.Interfaces;
using SmartGridInfo.Models;

namespace SmartGridInfo.Interfaces
{
    public interface ISmartGridRepo : IRepository<SmartGrid>
    {
        void RemoveSmartGrid(int id);
        void UpdateSmartGrid(SmartGrid t);
        void InsertSmartGrid(SmartGrid t);
        void Dispose();
        void Save();
    }
}
