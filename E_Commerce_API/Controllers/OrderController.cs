using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<List<OrderResponeDTO>> GetAll()
        {
            var x = await _unitOfWork.CustomOrder.GetAll();
            var respone = _mapper.Map<List<OrderResponeDTO>>(x);
            return respone;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO dto)
        {
            var x = _mapper.Map<Order>(dto);
           await _unitOfWork.Order.AddObject(x);
           await _unitOfWork.Save();
            var respone = _mapper.Map<OrderResponeDTO>(x);
            return Ok(respone);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _unitOfWork.Order.GetById(id);
            var respone = _mapper.Map<OrderResponeDTO>(x);
            return Ok(respone);
        }

        [HttpPatch("Status/{id:int}")]
        public async Task<IActionResult> UpdateStatus(int id,OrderUpdateStatusDTO dto)
        {
            if(dto.OrderStatus.ToLower()!= "pending" && dto.OrderStatus.ToLower() != "cancelled" && dto.OrderStatus.ToLower() != "completed")
            {
                return BadRequest("You write a status wrong.");
            }
            var get = await _unitOfWork.Order.GetById(id);
            var Transfer = _mapper.Map(dto, get);
            await _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("Total-Revenue-Completed")]
        public async Task<IActionResult> GetTotal()
        {
            var x = await _unitOfWork.CustomOrder.TotalRevenueCompleted();
            return Ok(x);
        }
    }
}