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
        protected new readonly SmartGridDBContext Context;

        public SmartGridRepo(SmartGridDBContext context) : base(context)
        {
            this.Context = context;
        }

        public void RemoveSmartGrid(int id)
        {
            Context.SmartGrids.Remove(Context.SmartGrids.Find(id));
        }

        public void UpdateSmartGrid(SmartGrid mini)
        {
            Context.Entry(mini).State = EntityState.Modified;
        }

        public void InsertSmartGrid(SmartGrid mini)
        {
            Context.SmartGrids.Add(mini);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
