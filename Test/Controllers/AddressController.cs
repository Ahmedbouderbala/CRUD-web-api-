using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Security.Principal;
using Test.Context;
using Test.Interfaces;
using Test.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;

        private readonly ApplicationDbContext _applicationDbContext;

        public AddressController(IAddressRepository addressRepository, ApplicationDbContext applicationDbContext)
        {
            this.addressRepository = addressRepository;

            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAddresses(string? order, string? street, string? housenumber, string? zipcode, string? city, string? country)
        {
            try
            {
                if (order == "DESC")
                {

                    var add = _applicationDbContext.Addresses.OrderByDescending(a => a.country).ToList();


                }
                else if (order == "ASC")
                {
                    var addr = _applicationDbContext.Addresses.OrderBy(a => a.country).ToList();
                }

                var result = await addressRepository.Search(street, housenumber, zipcode, city, country);

                return Ok(await addressRepository.GetAddresses(street, housenumber, zipcode, city, country));

            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            try
            {
                var result = await addressRepository.GetAddress(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
            try
            {
                if (address == null)
                    return BadRequest();

                var createdAddress = await addressRepository.AddAddress(address);

                return CreatedAtAction(nameof(GetAddress),
                    new { id = createdAddress.Id }, createdAddress);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> UpdateAddress(int id, Address address)
        {
            try
            {
                if (id != address.Id)
                    return BadRequest("Employee ID mismatch");

                var addressToUpdate = await addressRepository.UpdateAddress(address);

                if (addressToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await addressRepository.UpdateAddress(address);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            try
            {
                var addressToDelete = await addressRepository.GetAddress(id);

                if (addressToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await addressRepository.DeleteAddress(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        //[HttpGet]
        //   public async Task<IActionResult> CalculateDistance(string address1, string address2)
        //{
        //    // Create a new distance matrix request
        //    var request = new DistanceMatrixRequest
        //    {
        //        // Set the origin and destination addresses
        //        Origins = new[] { address1 },
        //        Destinations = new[] { address2 },

        //        // Set the distance unit to kilometers
        //        Units = Units.Metric
        //    };

        //    // Initialize the Google Maps API client
        //    var client = new GoogleMapsClient("YOUR_API_KEY_HERE");

        //    // Execute the request and retrieve the response
        //    var response = await client.DistanceMatrix.QueryAsync(request);

        //    // Extract the distance from the response
        //    var distance = response.Rows.First().Elements.First().Distance.Value;

        //    // Return the distance in kilometers
        //    return Ok(distance / 1000.0);
        //}

        //----------------------------------------------------------------------------------

        //create an endpoint that can retrieve the distance between two addresses using a public geolocation API in .NET Web API Core, you can follow these steps:

        //- Choose a geolocation API that provides distance calculation functionality.There are several options available, such as the Google Maps API, the Mapbox API, and the HERE API.Each of these APIs has its own set of pricing plans and usage limits, so be sure to choose the one that best fits your needs.

        //- Register for an API key.In order to use the geolocation API, you will need to sign up for an API key.This is usually a simple process that involves creating an account and agreeing to the API's terms of service.

        //- Install the API's client library. Most geolocation APIs provide client libraries that make it easier to interact with the API from your .NET Web API Core application. For example, the Google Maps API provides a .NET client library that you can install using the NuGet package manager.

        //- Create an endpoint in your.NET Web API Core application to calculate the distance between two addresses.This endpoint should accept two addresses as input, and use the geolocation API's distance calculation functionality to retrieve the distance between them. Here's an example of what this endpoint might look like using the Google Maps
    }
}
