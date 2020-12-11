using AgriHub.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriHub.Core.Repository
{
    public interface IBroilerRepository
    {
        Task<Broiler> AddBroiler(Broiler broiler);
        Task<IEnumerable<Broiler>> GetBroiler();
        Task<Broiler> GetBroiler(string batchNo);
        Task<Broiler> GetBroiler(int id);
        Task<Broiler> DeleteBroiler(int id);
        Task<Broiler> UpdateBroiler(int Id,Broiler broiler);
        Task AddDailyChecks(BroilerTrans trans);
        Task<BroilerTrans> UpdateDailyChecks(BroilerTrans trans);
        Task<IEnumerable<BroilerTrans>> GetBroilerTrans(string batchNo);
        Task<IEnumerable<Brooder>> GetBrooder();
        Task<IEnumerable<Brooder>> GetBrooderList();
        Task<IEnumerable<PenHouse>> GetPenHouseList();
        Task<Brooder> UpdateBrooder(string Id);
        Task<IEnumerable<PenHouse>> GetPenHouse();
    }
}
