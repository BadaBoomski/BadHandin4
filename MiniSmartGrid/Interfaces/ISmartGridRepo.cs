using MiniSmartGrid.Models;
using MiniSmartGrid.RepoAndUOW;
using System.Collections.Generic;

namespace MiniSmartGrid.Interfaces
{
    public interface ISmartGridRepo : IRepository<SmartGrid>
    {
        void RemoveSmartGrid(int id);
        void UpdateSmartGrid(SmartGrid mini);
        void InsertSmartGrid(SmartGrid mini);
        void Dispose();
        void Save();
    }
}