using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Interface;
using ProsumerInfo.Models;

namespace ProsumerInfo.Repo
{
    public class ProsumerSmartMeterRecordsLogRepo : Repository<ProsumerSmartMeterRecordsLog>, IProsumerSmartMeterRecordsLogRepo, IDisposable
    {
        protected new readonly ProsumerDbContext Context;

        public ProsumerSmartMeterRecordsLogRepo(ProsumerDbContext context) : base(context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void InsertProsumerSmartMeterRecordsLog(ProsumerSmartMeterRecordsLog prosumer)
        {
            Context.ProsumerSmartMeterRecordsLogs.Add(prosumer);
        }

        public void RemoveProsumerSmartMeterRecordsLog(int id)
        {
            Context.ProsumerSmartMeterRecordsLogs.Remove(Context.ProsumerSmartMeterRecordsLogs.Find(id));
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void UpdateProsumerSmartMeterRecordsLog(ProsumerSmartMeterRecordsLog prosumer)
        {
            Context.Entry(prosumer).State = EntityState.Modified;
        }
    }
}
