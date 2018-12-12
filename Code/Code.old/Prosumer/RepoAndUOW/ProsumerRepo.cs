using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prosumer.Interface;
using Prosumer.Models;

namespace Prosumer.RepoAndUOW
{
    public class ProsumerRepo : Repository<Models.Prosumer>, IProsumerRepo, IDisposable
    {
        protected new readonly ProsumerDBContext Context;

        public ProsumerRepo(ProsumerDBContext context) : base(context)
        {
            this.Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void InsertProsumer(Models.Prosumer prosumer)
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

        public void UpdateProsumer(Models.Prosumer prosumer)
        {
            Context.Entry(prosumer).State = EntityState.Modified;
        }
    }
}
