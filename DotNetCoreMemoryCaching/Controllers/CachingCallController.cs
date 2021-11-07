using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMemoryCaching.Controllers
{
    [ApiController]
    public class CachingCallController : ControllerBase
    {
        [Route("api/cachie/getArtist")]
        public List<string> GetArt()
        {

            MemoryCacheService memoryCacheService = new MemoryCacheService();
            List<string> aResponse = new List<string>();

            try
            {
                string cacheKey = "HomeKey";
                if (memoryCacheService.Exists(cacheKey))
                {
                    aResponse = (List<string>)memoryCacheService.Get(cacheKey);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            Trace.WriteLine("Home API CALL");

            return aResponse;
        }


        [Route("api/cachie/getps")]
        public List<string> getps()
        {

            MemoryCacheService memoryCacheService = new MemoryCacheService();
            List<string> aResponse = new List<string>();

            try
            {
                string cacheKey = "PodcastKey";
                if (memoryCacheService.Exists(cacheKey))
                {
                    aResponse = (List<string>)memoryCacheService.Get(cacheKey);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


            Trace.WriteLine("PS API CALL");

            return aResponse;
        }
    }
}
