﻿using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Enums;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Order;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Domain.Models.ResponseModels.Order;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderLinesRepository orderLinesRepository;

        public OrderService(IOrderRepository orderRepository, IOrderLinesRepository orderLinesRepository)
        {
            this.orderRepository = orderRepository;
            this.orderLinesRepository = orderLinesRepository;
        }

        

        public OrderResponseModel CreateOrder(CreateOrderRequestModel request)
        {
            OrderResponseModel responseModel = new OrderResponseModel
            {
                Code = 0,
                Message = "Successfully Created Order."
            };

            if (request != null)
            {
                OrderDto orderDto = new OrderDto
                {
                    OrderDate = DateTime.Now,
                    OrderStatusId = (int)OrderStatus.New,
                    CurrencyId = request.CurrencyId,
                    IncotermId = request.IncotermId,
                    InternalOrderReference = request.InternalOrderReference,
                    PortDestination = request.PortDestination,
                    PortOfOrigin = request.PortOfOrigin,
                    SupplierId = request.SupplierId,
                    OrderLines = request.OrderLines,
                };

                var result = orderRepository.Add(orderDto);

                if (result != null)
                {
                    responseModel.Code = result.Code;
                    responseModel.Message = result.Message;
                }

            }
            else
            {
                responseModel.Message = "Request object is null";
                responseModel.Code = 1;
            }

            return responseModel;
        }


        public BaseResponseModel ConfirmPurchaseOrder(ConfirmPurchaseOrderModel request)
        {

            BaseResponseModel response = new BaseResponseModel();

            response.Code = 0;

            if (request is null || request.OrderId <= 0 || string.IsNullOrEmpty(request.IndentNumber))
            {
                response.Code = 1;
                response.Message = "Invalid request model, check all inputs";
            }

            if (response.Code == 0)
            {
                var result = orderRepository.ConfirmPurchaseOrder(request.OrderId, request.IndentNumber);
                response.Code=  result.Code;    
                response.Message = result.Message;
            }


            return response;
        }
    }
}
