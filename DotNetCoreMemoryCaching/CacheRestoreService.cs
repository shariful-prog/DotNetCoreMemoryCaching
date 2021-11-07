
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace DotNetCoreMemoryCaching
{
    public class CacheRestoreService
    {

        MemoryCacheService memoryCacheService = new MemoryCacheService();
        public List<string> GetListHome()
        {
            List<string> authors = new List<string>(5);
            authors.Add("Home_Mahesh Chand");
            authors.Add("Home_Chris Love");
            authors.Add("Home_Allen O'neill");
            authors.Add("Home_Naveen Sharma");
            authors.Add("Home_Monica Rathbun");
            authors.Add("Home_David McCarter");

            return authors;
        }

        public List<string> GetListPostCast()
        {
            List<string> authors = new List<string>(5);
            authors.Add("Postcase_Mahesh Chand");
            authors.Add("Postcase_Chris Love");
            authors.Add("Postcase_Allen O'neill");
            authors.Add("Postcase_Naveen Sharma");
            authors.Add("Postcase_Monica Rathbun");
            authors.Add("Postcase_David McCarter");

            return authors;
        }

        public void CacheRestore(string param)
        {
            try
            {
                if (param == "Home")
                {
                    memoryCacheService = new MemoryCacheService();

                    Task.Run(() =>
                    {
                        var homeList = GetListHome();
                        memoryCacheService.Set($"HomeKey", homeList);
                        Trace.WriteLine("home cache");
                    });
                }
                else if (param == "podcast")
                {
                    var homeList = GetListPostCast();
                    memoryCacheService.Set($"PodcastKey", homeList);
                    Trace.WriteLine("podcast cache");

                }
            }
            catch { }
            finally { }
        }
    }
}