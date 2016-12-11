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

        [Route("")]
        [HttpGet]
        public ProductOptions GetOptions(Guid productId)
        {
            return _productOptionsService.GetOptionsByProductId(productId);
        }
        
        [Route("{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            //Not using productId
            return _productOptionsService.GetOptionByProductOptionId(id);
        }

        [HttpPost]
        public void CreateOption(Guid productId, ProductOption option)
        {
            _productOptionsService.CreateProductOption(productId, option);
        }

        [Route("{id}")]
        [HttpPut]
        public void UpdateOption(Guid id, ProductOption option)
        {
            _productOptionsService.UpdateProductOption(id, option);
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteOption(Guid id)
        {
            _productOptionsService.DeleteProductOption(id);
        }
    }
}
