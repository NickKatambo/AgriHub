using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriHub.Core.Repository;
using AgriHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgriHub.Pages.Broilers
{
    public class DetailModel : PageModel
    {
        private readonly IBroilerRepository broilerRepository;

        public Broiler broiler { get; set; } = new Broiler();

        [BindProperty]
        public BroilerTrans broilerTrans { get; set; } = new BroilerTrans();

        public SelectList BrooderList { get; set; }

        public SelectList PinHouseList { get; set; }

        public DetailModel(IBroilerRepository broilerRepository)
        {
            this.broilerRepository = broilerRepository;
        }

        public async Task OnGet(int? id)
        {
            BrooderList = new SelectList(await broilerRepository.GetBrooder(), nameof(Brooder.Id), nameof(Brooder.Id));
            PinHouseList = new SelectList(await broilerRepository.GetPenHouse(), nameof(PenHouse.Id), nameof(PenHouse.Id));

            if(!string.IsNullOrEmpty(id.ToString()))
                broiler = await broilerRepository.GetBroiler(int.Parse(id.Value.ToString()));

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                broilerTrans.BatchNo = broiler.BatchNo;
                broilerTrans.BroilerId = broiler.Id;


                var formData = broilerTrans;
            }

            return Page();
        }
    }
}
