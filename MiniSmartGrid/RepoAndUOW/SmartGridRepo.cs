using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniSmartGrid.Interfaces;
using MiniSmartGrid.Models;
using Microsoft.EntityFrameworkCore;
using MiniSmartGrid.RepoAndUOW;

namespace MiniSmartGrid.RepoAndUOW
{
    public class SmartGridRepo : Repository<SmartGrid>, ISmartGridRepo, IDisposable
    {
        private SmartGridDBContext context;

        public SmartGridRepo(SmartGridDBContext context) : base(context)
        {
            this.context = context;
        }

        public void RemoveSmartGrid(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSmartGrid(SmartGrid mini)
        {
            throw new NotImplementedException();
        }

        public void InsertSmartGrid(SmartGrid mini)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
