using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClickCart.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage AllProduct()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage GetProduct(int id)
        {
            try
            {
                var data = ProductService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");
            }

        }





        [HttpPost]
        [Route("api/product/add")]
        public HttpResponseMessage AddProduct(ProductDTO product)
        {
            try
            {
                var data = ProductService.Create(product);
                return Request.CreateResponse(HttpStatusCode.OK, "Product has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/product/update")]
        public HttpResponseMessage UpdateProduct(ProductDTO product)
        {
            try
            {
                var data = ProductService.Update(product);
                return Request.CreateResponse(HttpStatusCode.OK, "Product information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/product/{id}")]
        public HttpResponseMessage DeleteProduct(int id)
        {
            try
            {
                var data = ProductService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
