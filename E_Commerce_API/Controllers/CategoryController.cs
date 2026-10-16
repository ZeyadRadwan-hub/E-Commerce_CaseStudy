using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<CategoryResponeDTO>> GetAll()
        {
            var category = await _unitOfWork.CustomCategory.GetAll();
            var respone = _mapper.Map<List<CategoryResponeDTO>>(category);
            return respone;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _unitOfWork.Category.AddObject(category);
            await _unitOfWork.Save();
            return Ok(dto);
        }
    }
}
