using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGridInfo.Interfaces;
using SmartGridInfo.Models;

namespace SmartGridInfo.RepoAndUOW
{
    public class SmartGridProsumerRepo : Repository<SmartGridProsumer>, ISmartGridProsumerRepo, IDisposable
    {
        protected new readonly SmartGridDbContext Context;

        public SmartGridProsumerRepo(SmartGridDbContext context) : base(context)
        {
            Context = context;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public void InsertSmartGridProsumer(SmartGridProsumer t)
        {
            Context.SmartGridProsumers.Add(t);
        }

        public void RemoveSmartGridProsumer(int id)
        {
            Context.SmartGridProsumers.Remove(Context.SmartGridProsumers.Find(id));
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void UpdateSmartGridProsumer(SmartGridProsumer t)
        {
            Context.Entry(t).State = EntityState.Modified;
        }
    }
}
