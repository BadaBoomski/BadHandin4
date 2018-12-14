using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Interface;
using ProsumerInfo.Models;

namespace ProsumerInfo.Repo
{
    public class ProsumerRepo : Repository<Prosumer>, IProsumerRepo, IDisposable
    {
        protected new readonly ProsumerDbContext Context;

        public ProsumerRepo(ProsumerDbContext context) : base(context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void InsertProsumer(Prosumer prosumer)
        {
            Context.Prosumers.Add(prosumer);
        }

        public void RemoveProsumer(int id)
        {
            Context.Prosumers.Remove(Context.Prosumers.Find(id));
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void UpdateProsumer(Prosumer prosumer)
        {
            Context.Entry(prosumer).State = EntityState.Modified;
        }
    }
}
