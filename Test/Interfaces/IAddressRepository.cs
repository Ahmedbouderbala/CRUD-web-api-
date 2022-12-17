using System.Reflection;
using Test.Models;

namespace Test.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses(string? street,string? housenumber, string? zipcode, string? city,  string? country);
        Task<Address> GetAddress(int id);
        Task<Address> AddAddress(Address address);
        Task<Address> UpdateAddress(Address address);
        Task<Address> DeleteAddress(int id);



        Task<IEnumerable<Address>> Search(string? street, string? housenumber, string? zipcode, string? city, string? country);

       

    }
}
