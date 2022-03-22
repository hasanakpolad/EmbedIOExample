using EmbedIO.Routing;
using EmbedIO.WebApi;
using System.Threading.Tasks;

namespace EmbedIOExample
{
    public class ExampleController : WebApiController
    {
        [Route(EmbedIO.HttpVerbs.Get, "/data")]
        public object GetExample() // public async Task<string> GetMethod
        {
            return new { Message = "deneme" };
            //return await Task.FromResult("Ok");
        }
    }
}
