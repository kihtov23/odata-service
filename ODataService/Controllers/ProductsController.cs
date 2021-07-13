using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataService.Models;

namespace ODataService.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly IQueryable<Product> _products = new List<Product>()
        {
            new Product()
            {
                ID = 1,
                Name = "Bread",
            },
            new Product()
            {
                ID = 2,
                Name = "Box",
            }, new Product()
            {
                ID = 3,
                Name = "Apple",
            },
            new Product()
            {
                ID = 4,
                Name = "Box",
            }
        }.AsQueryable();

        [EnableQuery]
        [HttpGet]
        public ActionResult<IQueryable<Product>> Get()
        {

            return new OkObjectResult(_products);
        }

        [EnableQuery]
        [HttpGet]
        [ODataRoute("Products/GetByName(Name={name})")]
        public ActionResult<IQueryable<Product>> GetProductsByName([FromODataUri] string name)
        {
            var result = _products.Where(p => p.Name == name);

            return new OkObjectResult(result);
        }
    }
}
