using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class UpdateAddressHandler
        : IRequestHandler<UpdateAddressRequest, Guid>
    {
        public async Task<Guid> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var entry = AddressBookEntry.Create(new Guid(request.Id), request.Line1, request.Line2, request.City, request.State, request.PostalCode);
            int index = AddressDb.Addresses.FindIndex(ab => ab.Id.Equals(new Guid(request.Id)));
            AddressDb.Addresses[index] = entry;
            return await Task.FromResult(entry.Id);
        }
    }
}
