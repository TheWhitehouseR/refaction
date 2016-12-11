using System;
using System.Net;
using System.Web.Http;
using ProductsApi.Models;
using ProductsApi.Contracts;

namespace ProductsApi.Controllers
{
    [RoutePrefix("products/{productId:guid}/options")]
    public class ProductOptionsController : ApiController
    {
        private IProductOptionsService _productOptionsService;

        public ProductOptionsController(IProductOptionsService productOptionsService)
        {
            _productOptionsService = productOptionsService;
        }

        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            var options = _productOptionsService.GetOptionsByProductId(productId);

            /*if (options == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/

            return options;
        }
        
        [Route("{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            return _productOptionsService.GetOptionByProductOptionId(productId, id);
        }

        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productOptionsService.CreateOption(productId, option);
        }

        [Route("{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            _productOptionsService.UpdateOption(id, option);
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            _productOptionsService.DeleteOption(id);
        }
    }
}
