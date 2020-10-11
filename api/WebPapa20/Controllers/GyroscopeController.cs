using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPapa20.Models;

namespace WebPapa20.Controllers
{
    [Authorize]
    public class GyroscopeController : ApiController
    {
        // GET api/gyroscope
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/gyroscope/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/gyroscope
        public void Post([FromBody]string value)
        {
            var user = User.Identity as ApplicationUser;
            user.GyroscopeData = GetFromData(value);

            IdentityResult result = await UserManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        public static string GetFromData(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Connectors.GyropscopeDataConnector reader = Connectors.GyropscopeDataConnector.ReadAsSream())
            {
                string x = reader.GetX;
                string y = reader.GetY;

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < reader.ReadToEnd; i++)
                {
                    sb.Append(reader[i].ToString("D"));
                }
                return sb.ToString();
            }
        }

        // PUT api/gyroscope/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/gyroscope/5
        //public void Delete(int id)
        //{
        //}
    }
}
