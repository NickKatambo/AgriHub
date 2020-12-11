using AgriHub.Core.Models;
using AgriHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriHub.Core.Repository
{
    public class BroilerRepository : IBroilerRepository
    {
        private readonly AppDbContext appDbContext;

        public BroilerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Broiler> AddBroiler(Broiler broiler)
        {
            var query = (await appDbContext.Broilers.AddAsync(broiler));
            await appDbContext.SaveChangesAsync();
            return query.Entity;
        }

        public async Task AddDailyChecks(BroilerTrans trans)
        {
            await appDbContext.Database.ExecuteSqlRawAsync("sp_AddBroilerTransaction {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10} ",
                trans.BroilerId, trans.BatchNo, trans.TransactionDate, trans.OpeningStock, trans.Mortality, trans.ClosingStock, trans.AvgWeight, trans.StdWeight, trans.FeedCons, trans.Comment, trans.LoggedBy);
        }

        public async Task<Broiler> DeleteBroiler(int id)
        {
            var query = await appDbContext.Broilers.FirstOrDefaultAsync(b => b.Id == id);
            if (query != null)
            {
                var subQuery = appDbContext.BroilerTrans.Where(bt => bt.BatchNo == query.BatchNo);
                appDbContext.Broilers.Remove(query);
                appDbContext.BroilerTrans.Remove((BroilerTrans)subQuery);

                await appDbContext.SaveChangesAsync();

                return query;
            }

            return null;
        }

        public async Task<IEnumerable<Broiler>> GetBroiler()
        {
            return (await appDbContext.Broilers.ToListAsync());
        }

        public async Task<Broiler> GetBroiler(string batchNo)
        {
            return (await appDbContext.Broilers
                .Include(bb => bb.Brooder)
                .Include(pp => pp.PinHouse)
                .FirstOrDefaultAsync(b => b.BatchNo == batchNo));
        }

        public async Task<Broiler> GetBroiler(int id)
        {
            return await appDbContext.Broilers
                .Include(bb => bb.Brooder)
                .Include(pp => pp.PinHouse)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BroilerTrans>> GetBroilerTrans(string batchNo)
        {
            return await appDbContext.BroilerTrans.Where(t => t.BatchNo == batchNo).ToListAsync();
        }

        public async Task<IEnumerable<Brooder>> GetBrooder()
        {
            return await appDbContext.Brooders.Where(b => b.Status == false).ToListAsync();
        }

        public async Task<IEnumerable<Brooder>> GetBrooderList()
        {
            return await appDbContext.Brooders.ToListAsync();
        }

        public async Task<IEnumerable<PenHouse>> GetPenHouse()
        {
            return await appDbContext.PenHouses.ToListAsync();
        }

        public async Task<IEnumerable<PenHouse>> GetPenHouseList()
        {
            return await appDbContext.PenHouses.ToListAsync();
        }

        public Task<Broiler> UpdateBroiler(int Id, Broiler broiler)
        {
            throw new NotImplementedException();
        }

        public async Task<Brooder> UpdateBrooder(string Id)
        {
            var query = await appDbContext.Brooders.FirstOrDefaultAsync(b => b.Id == Id);
            if (query != null)
            {
                if (query.Status)
                {
                    query.Status = false;
                }
                else
                {
                    query.Status = true;
                }
                await appDbContext.SaveChangesAsync();
                return query;
            }
            return null;
        }

        public Task<BroilerTrans> UpdateDailyChecks(BroilerTrans trans)
        {
            throw new NotImplementedException();
        }
    }
}
