using System;
using System.Collections.Generic;
using System.Text;

namespace AddressManagementSystem.Entity
{
    public interface IAddressBookRepository
    {
        Task SaveAsync(List<Contact> contacts);
        Task<List<Contact>> LoadAsync();
    }
}
