using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Model;
using PetShop.Business;

namespace PetShop.Products
{
    public static class GetProducts
    {
        [FunctionName("GetProducts")]
        public static async Task<IList<Product>> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request: GetProducts");


            //string requestBody = new StreamReader(req.Body).ReadToEnd();
            //log.LogInformation("Input:" + requestBody);
            //var products = JsonConvert.DeserializeObject<Product>(requestBody);

            var productService = new ProductService();
           var list = await Task.FromResult(productService.GetData()).ConfigureAwait(true);
           return list;

        }

    }
}