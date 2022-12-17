# CRUD-web-api-
with search and sort

PART 2 : DYNAMIC SEARCH

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


            //This code uses reflection to get the properties of the MyModel type and loops through each property.If the property is a string type,
            //it gets the value of the property for each object in the list and checks if the query is contained in any of the property values.
            //If the query is found, it adds the object to the search results.
  
  
  PART 3 : DISTANCES 

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

        //- Choose a geolocation API that provides distance calculation functionality.There are several options available, such as the Google Maps API, the Mapbox API,            and the HERE API.Each of these APIs has its own set of pricing plans and usage limits, so be sure to choose the one that best fits your needs.

        //- Register for an API key.In order to use the geolocation API, you will need to sign up for an API key.This is usually a simple process that involves                     creating an account and agreeing to the API's terms of service.

        //- Install the API's client library. Most geolocation APIs provide client libraries that make it easier to interact with the API from your .NET Web API Core               application. For example, the Google Maps API provides a .NET client library that you can install using the NuGet package manager.

        //- Create an endpoint in your.NET Web API Core application to calculate the distance between two addresses.This endpoint should accept two addresses as input,             and use the geolocation API's distance calculation functionality to retrieve the distance between them. Here's an example of what this endpoint might look             like using the Google Maps
    }
