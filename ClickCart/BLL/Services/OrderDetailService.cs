using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> Get()
        {
            var data = DataAccessFactory.OrderDetailData().Get();
            return Convert(data);
        }

        public static OrderDetailDTO Get(int id)
        {
            return Convert(DataAccessFactory.OrderDetailData().Get(id));
        }


        public static bool Create(OrderDetailDTO orderDetail)
        {
            var data = Convert(orderDetail);
            return DataAccessFactory.OrderDetailData().Insert(data);
        }


        public static bool Update(OrderDetailDTO orderDetail)
        {
            var data = Convert(orderDetail);
            return DataAccessFactory.OrderDetailData().Update(data);
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDetailData().Delete(id);
        }


        static List<OrderDetailDTO> Convert(List<OrderDetail> orderDetails)
        {
            var data = new List<OrderDetailDTO>();
            foreach (var orderDetail in orderDetails)
            {
                data.Add(Convert(orderDetail));
            }
            return data;
        }


        static OrderDetailDTO Convert(OrderDetail orderDetail)
        {
            return new OrderDetailDTO()
            {
                Id = orderDetail.Id,
                Qty = orderDetail.Qty,
                Price = orderDetail.Price,
                PId = orderDetail.PId,
                OId = orderDetail.OId
            };
        }


        static OrderDetail Convert(OrderDetailDTO orderDetail)
        {
            return new OrderDetail()
            {
                Id = orderDetail.Id,
                Qty = orderDetail.Qty,
                Price = orderDetail.Price,
                PId = orderDetail.PId,
                OId = orderDetail.OId
            };
        }
    }
}
