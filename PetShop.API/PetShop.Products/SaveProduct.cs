using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Business;
using PetShop.Model;

namespace PetShop.Products
{
    public static class SaveProduct
    {
        [FunctionName("SaveProduct")]
        public static async Task<bool>   Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            log.LogInformation("Input:" + requestBody);
            var product = JsonConvert.DeserializeObject<Product>(requestBody);

            var productService = new ProductService();
            return await Task.FromResult(productService.AddProduct(product));
        }
    }
}