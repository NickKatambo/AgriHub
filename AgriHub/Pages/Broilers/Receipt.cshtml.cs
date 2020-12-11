using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgriHub.Core.Repository;
using AgriHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriHub.Pages.Broilers
{
    public class ReceiptModel : PageModel
    {
        private readonly IBroilerRepository broilerRepository;

        public SelectList BrooderList { get; set; }
        public List<Brooder> BrooderStatusList { get; set; }
        public List<PenHouse> PenHouseStatusList { get; set; }
        public SelectList PinHouseList { get; set; }
        public Broiler Broiler { get; set; } = new Broiler();
        public BroilerTrans BroilerTrans { get; set; } = new BroilerTrans();

        public ReceiptModel(IBroilerRepository broilerRepository)
        {
            this.broilerRepository = broilerRepository;
        }

        public async Task OnGet()
        {
            BrooderList = new SelectList(await broilerRepository.GetBrooder(), nameof(Brooder.Id), nameof(Brooder.Id));
            PinHouseList = new SelectList(await broilerRepository.GetPenHouse(), nameof(PenHouse.Id), nameof(PenHouse.Id ));
            BrooderStatusList = ((List<Brooder>)await broilerRepository.GetBrooderList());
            PenHouseStatusList = ((List<PenHouse>) await broilerRepository.GetPenHouseList());

            Broiler.DateReceipt = DateTime.Now;
        }

        public async Task<IActionResult> OnPost(Broiler broiler)
        {
            if (ModelState.IsValid)
            {
                broiler.TransactionDate = DateTimeOffset.Now;
                broiler.LoggedBy = "Yannick Katambo";
                
                //Coming soon...
                //string brooderId = broiler.BrooderId;

                var query = await broilerRepository.AddBroiler(broiler);

                //Add broiler transaction detail here...
                if (query != null)
                {
                    BroilerTrans.BatchNo = broiler.BatchNo;
                    BroilerTrans.BroilerId = query.Id;
                    BroilerTrans.OpeningStock = broiler.QtyReceipt;
                    BroilerTrans.Mortality = 0;
                    BroilerTrans.ClosingStock = broiler.QtyReceipt;
                    BroilerTrans.AvgWeight = broiler.AvgWeight;
                    BroilerTrans.StdWeight = broiler.AvgWeight;
                    BroilerTrans.FeedCons = 0;
                    BroilerTrans.LoggedBy = "Yannick Katambo";
                    BroilerTrans.TransactionDate = DateTimeOffset.Now;

                    await broilerRepository.AddDailyChecks(BroilerTrans);
                }

                //await broilerRepository.UpdateBrooder(brooderId);

                return RedirectToPage("/Broilers/Index");
            }

            return Page();
        }
    }
}
