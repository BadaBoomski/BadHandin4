using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGridInfo.Interfaces;
using SmartGridInfo.Models;

namespace SmartGridInfo.Repo
{
    public class SmartGridRepo : Repository<SmartGrid>, ISmartGridRepo, IDisposable
    {
        protected new readonly SmartGridDbContext Context;

        public SmartGridRepo(SmartGridDbContext context) : base(context)
        {
            Context = context;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public void InsertSmartGrid(SmartGrid t)
        {
            Context.SmartGrids.Add(t);
        }

        public void RemoveSmartGrid(int id)
        {
            Context.SmartGrids.Remove(Context.SmartGrids.Find(id));
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void UpdateSmartGrid(SmartGrid t)
        {
            Context.Entry(t).State = EntityState.Modified;
        }
    }
}
