using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace AIMS.WebApi.Services
{
    public class CommonServices
    {
        public bool ValidateToken(HttpRequestHeaders httpHeaders)
        {
            //The header line we want to parse is this format:
            //"Authorization: token <user guid>-<aims int user id>"
            //“Authorization: token ba4604e8e433g9c892e360d53463oec5-145“

            if (httpHeaders.Contains("Authorization"))
                //TODO create more meaningful auth here
                //IEnumerable<string> tokens = httpHeaders.GetValues("Authorization");

                //check if guid is valid and that it's not expired
                return true;
            else
                return false;
        }
    }
}