using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProsumerInfo.Models;

namespace ProsumerInfo.Interface
{
    public interface IProsumerSmartMeterRecordsLogRepo : IRepository<ProsumerSmartMeterRecordsLog>
    {
        void RemoveProsumerSmartMeterRecordsLog(int id);
        void UpdateProsumerSmartMeterRecordsLog(ProsumerSmartMeterRecordsLog prosumer);
        void InsertProsumerSmartMeterRecordsLog(ProsumerSmartMeterRecordsLog prosumer);
        void Dispose();
        void Save();
    }
}
