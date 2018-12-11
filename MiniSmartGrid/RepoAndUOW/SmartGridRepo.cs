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

    // This is pretty much copy/paste from our Handin 3.2 del1, where we had our PersonRepo.cs

    public class SmartGridRepo : Repository<SmartGrid>, ISmartGridRepo, IDisposable
    {
        private SmartGridDBContext context;

        public SmartGridRepo(SmartGridDBContext context) : base(context)
        {
            this.context = context;
        }

        public void RemoveSmartGrid(int id)
        {
            SmartGrid smartGrid = context.SmartGrids.Find(id);
            context.SmartGrids.Remove(smartGrid);
        }

        public void UpdateSmartGrid(SmartGrid mini)
        {
            context.Entry(mini).State = EntityState.Modified;
        }

        public void InsertSmartGrid(SmartGrid mini)
        {
            context.SmartGrids.Add(mini);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
