using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgriHub.Core.Repository;
using AgriHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgriHub.Pages.Broilers
{
    public class ListModel : PageModel
    {
        private readonly IBroilerRepository broilerRepository;

        public IEnumerable<Broiler> BroilersList { get; set; }

        public ListModel(IBroilerRepository broilerRepository)
        {
            this.broilerRepository = broilerRepository;
        }

        public async Task OnGet()
        {
            BroilersList = await broilerRepository.GetBroiler();
        }
    }
}
