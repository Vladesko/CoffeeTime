using Application.Interfaces;
using Application.Models.Create;
using Application.Models.Delete;
using Application.Models.Queries.GetOrder.GetListOrders;
using Application.Models.Queries.GetOrder.GetOrder;
using Application.Models.Queries.GetOrder.ListOrders;
using Application.Models.Update;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Create;
using WebApi.Models.Delete;
using WebApi.Models.Queries.GetDetailsOrder;
using WebApi.Models.Update;

namespace WebApi.Controllers
{
    public class OrderController : BaseApiController 
    {
        private readonly IMapper mapper;
        public OrderController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommandModelDto dto)
        {
            var command = mapper.Map<CreateOrderModel>(dto);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateOrderCommandModelDto dto)
        {
            var coomand = mapper.Map<UpdateOrderModel>(dto);
            await Mediator.Send(coomand);
            return NoContent();
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteOrderCommandModelDto dto)
        {
            var command = new DeleteOrderModel()
            {
                Id = dto.Id,
            };
            await Mediator.Send(command);

            return NoContent();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDetailsDto>> Get(Guid id)
        {
            var query = new OrderDetailsModel() 
            {
                Id = id
            };
            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ListOrderModel>> GetAll()
        {
            var query = new ListOrderModel();
            var viewModel = await Mediator.Send(query);

            return Ok(viewModel);
        }
    }
}
