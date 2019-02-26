using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator) => _mediator = mediator;

        [BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        public void OnGet(string id)
        {
            var entry = AddressDb.Addresses.Where(ad => ad.Id.Equals(new Guid(id))).FirstOrDefault();
            UpdateAddressRequest = UpdateAddressRequest.Create(entry);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _ = await _mediator.Send(UpdateAddressRequest);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}