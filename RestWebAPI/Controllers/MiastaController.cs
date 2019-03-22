using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RestWebAPI.Controllers
{
    public class MiastaController : ApiController
    {
        /*
         * Aby uzyc wiecej niz jeden get requset tzeba uzywac route
         * [Route("api/miasta/GetAllMiasta")]
         * Http z informacje czy to jets rquest posr, get , delete
           [HttpGet]
         */
        const string miastaRepoName = "miastarepo";

        private List<string> GetRepoMiasta()
        {
            var miasta = new List<string>();
            if (HttpContext.Current.Cache[miastaRepoName] != null)
            {
                miasta = (List<string>)HttpContext.Current.Cache[miastaRepoName];
            }

            return miasta;
        }

        private void SaveRepoMiasta(List<string> miasta)
        {
            HttpContext.Current.Cache[miastaRepoName] = miasta;
        }

        [Route("api/miasta/GetAllMiasta")]
        [HttpGet]
        public string[] GetAllMiasta()
        {
            return GetRepoMiasta().ToArray();
        }

        [Route("api/miasta/GetMiastaJson")]
        [HttpGet]
        public string GetMiastaJson()
        {
            var miasta = GetRepoMiasta();

            var json = JsonConvert.SerializeObject(miasta);

            return json;
        }

        [Route("api/miasta/GetFirstMiasto")]
        [HttpGet]
        public string GetFirstMiasto()
        {
            return GetRepoMiasta().First();
        }

        [Route("api/miasta/AddMiasto")]
        [HttpPost]
        public void AddMiasto(string nazwa)
        {
            var miasta = GetRepoMiasta();
            miasta.Add(nazwa);
            SaveRepoMiasta(miasta);
        }

        [Route("api/miasta/DeleteMiasto")]
        [HttpPost]
        public void DeleteMiasto(string nazwa)
        {
            var miasta = GetRepoMiasta();
            miasta.Remove(nazwa);
            SaveRepoMiasta(miasta);
        }
    }
}
