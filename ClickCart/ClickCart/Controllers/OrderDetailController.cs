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
    public class OrderDetailController : ApiController
    {
        [HttpGet]
        [Route("api/orderdetail")]
        public HttpResponseMessage AllOrderDetails()
        {
            try
            {
                var data = OrderDetailService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [HttpGet]
        [Route("api/orderdetail/{id}")]
        public HttpResponseMessage GetOrderDetail(int id)
        {
            try
            {
                var data = OrderDetailService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Order detail not found");
            }

        }





        [HttpPost]
        [Route("api/orderdetail/add")]
        public HttpResponseMessage AddOrderDetail(OrderDetailDTO orderDetail)
        {
            try
            {
                var data = OrderDetailService.Create(orderDetail);
                return Request.CreateResponse(HttpStatusCode.OK, "Order detail has been added");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpPost]
        [Route("api/orderdetail/update")]
        public HttpResponseMessage UpdateOrderDetail(OrderDetailDTO orderDetail)
        {
            try
            {
                var data = OrderDetailService.Update(orderDetail);
                return Request.CreateResponse(HttpStatusCode.OK, "Order detail information has been updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/orderdetail/{id}")]
        public HttpResponseMessage DeleteOrderDetail(int id)
        {
            try
            {
                var data = OrderDetailService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Order detail has been deleted.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}