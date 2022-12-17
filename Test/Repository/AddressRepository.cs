using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Test.Context;
using Test.Interfaces;
using Test.Models;

namespace Test.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AddressRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Address>> GetAddresses(string? street, string? housenumber, string? zipcode, string? city, string? country)
        {
            IQueryable<Address> query = applicationDbContext.Addresses;
            if (!string.IsNullOrWhiteSpace(street))
            {
                query = query.Where(e => e.street.Contains(street));

            }

            if (housenumber != null)
            {
                query = query.Where(e => e.housenumber == housenumber);
            }

            if (zipcode != null)
            {
                query = query.Where(e => e.zipcode == zipcode);
            }

            if (city != null)
            {
                query = query.Where(e => e.city == city);
            }

            if (country != null)
            {
                query = query.Where(e => e.country == country);
            }

            return await query.ToListAsync();

         


        }

        public async Task<Address> GetAddress(int id)
        {
            return await applicationDbContext.Addresses.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Address> AddAddress(Address address)
        {
            var result = await applicationDbContext.Addresses.AddAsync(address);
            await applicationDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var result = await applicationDbContext.Addresses
                .FirstOrDefaultAsync(e => e.Id == address.Id);

            if (result != null)
            {
                result.street = address.street;
                result.housenumber = address.housenumber;   
                result.zipcode = address.zipcode;
                result.city = address.city; 
                result.country = address.country;   
                
                

                await applicationDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Address> DeleteAddress(int id)
        {
            var result = await applicationDbContext.Addresses
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                applicationDbContext.Addresses.Remove(result);
                await applicationDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Address>> Search(string? street, string? housenumber, string? zipcode, string? city, string? country)
        {
            IQueryable<Address> query = applicationDbContext.Addresses;
            if (!string.IsNullOrWhiteSpace(street))
            {
                query = query.Where(e => e.street.Contains(street));

            }

            if (housenumber != null)
            {
                query = query.Where(e => e.housenumber == housenumber);
            }

            if (zipcode != null)
            {
                query = query.Where(e => e.zipcode == zipcode);
            }

            if (city != null)
            {
                query = query.Where(e => e.city == city);
            }

            if (country != null)
            {
                query = query.Where(e => e.country == country);
            }

            return await query.ToListAsync();
        }

        //public async Task<IEnumerable<Address>> SearchDynamic(List<Address> models, string query)
        //{
        //    var searchResults = new List<MyModel>();

        //    // Get the properties of the MyModel type
        //    var properties = typeof(Address).GetProperties();

        //    // Loop through each property
        //    foreach (var property in properties)
        //    {
        //        // Check if the property is a string type
        //        if (property.PropertyType == typeof(string))
        //        {
        //            // Get the value of the property for each object in the list
        //            var values = models.Select(m => property.GetValue(m, null));

        //            // Check if the query is contained in any of the property values
        //            if (values.Any(v => v.ToString().Contains(query)))
        //            {
        //                // Add the object to the search results
        //                searchResults.AddRange(models.Where(m => property.GetValue(m, null).ToString().Contains(query)));
        //            }
        //        }
        //    }

        //    return searchResults;
        //}

        //-------------------------------------------------------------------

            //This code uses reflection to get the properties of the MyModel type and loops through each property.If the property is a string type,
            //it gets the value of the property for each object in the list and checks if the query is contained in any of the property values.
            //If the query is found, it adds the object to the search results.

    }
}


