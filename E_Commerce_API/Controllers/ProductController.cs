using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Pagination")]
        public async Task<List<ProductResponeDTO>> Pagination(
            [FromQuery] int? CategoryId,
            [FromQuery] int Pagenumber = 1 ,
            [FromQuery] int PageSize=10 ,
            [FromQuery] string? SortBy = null)
        {
            var x = await _unitOfWork.CustomProduct.
                Pagination(CategoryId,Pagenumber, PageSize, SortBy);
            var dto = _mapper.Map<List<ProductResponeDTO>>(x);
            return dto;
        }

        [HttpGet("{id:int}")]
        public async Task<ProductResponeDTO> GetByID(int id)
        {
            var x = await _unitOfWork.Product.GetById(id);
            var resp = _mapper.Map<ProductResponeDTO>(x);
            return resp;
        }

        [HttpGet("Get-Second-Expensive")]
        public async Task<ProductResponeDTO> Filter([FromQuery]int? categoryId)
        {
            var x = await _unitOfWork.CustomProduct.SecondMostExpensive(categoryId);
            var resp = _mapper.Map<ProductResponeDTO>(x);
            return resp;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create([FromBody]ProductCreateDTO dto)
        {
            var x = _mapper.Map<Product>(dto);
            await _unitOfWork.Product.AddObject(x);
            await _unitOfWork.Save();
            return Ok(dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id ,[FromBody]ProductUpdateDTO dto)
        {  
            var product = await _unitOfWork.Product.GetById(id);
            var respone = _mapper.Map(dto,product);
            await _unitOfWork.Save();
            return Ok(_mapper.Map<ProductResponeDTO>(product));
        }

        [HttpPatch("Stock/{id:int}")]
        public async Task<IActionResult> Patch([FromBody ]ProductPatchDTO dto,int id)
        {
            var product = await _unitOfWork.Product.GetById(id);
            _mapper.Map(dto,product);
            await _unitOfWork.Save();
            var respone = _mapper.Map<ProductResponeDTO>(product);
            return Ok(respone);
        }

        [HttpGet("SearchName")]
        public async Task<IActionResult> SearchName([FromQuery]string name)
        {
            var x = await _unitOfWork.CustomProduct.SearchName(name);
            var respone = _mapper.Map<List<ProductResponeDTO>>(x);
            return Ok(respone);
        }
    }
}