using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using Albergue.Administrator.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Albergue.Administrator.Controllers
{
    [ApiController]
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdministrationConsoleDbContext _context;
        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger, AdministrationConsoleDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("/add")]
        public async Task<ActionResult> AddItemAsync(ShopItem item)
        {
            try
            {
                var mapped = _mapper.Map<ShopItemEntry>(item);
                var result = await _context.ShopItems.AddAsync(mapped);

                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/update")]
        public async Task<ActionResult> UpdateItemAsync(ShopItem item)
        {
            try
            {
                var mapped = _mapper.Map<ShopItemEntry>(item);


                var existed = _context.ShopItems.AsQueryable().FirstOrDefault(p => p.Id == item.Id);
                var updated = _mapper.Map(existed, mapped);
                var result = await _context.ShopItems.AddAsync(updated);

                await _context.SaveChangesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("/item/{id}")]
        public async Task<ActionResult> GetItemByIdAsync(string id)
        {
            try
            {
                var found = _context.ShopItems.AsQueryable().FirstOrDefault(p => p.Id == id);

                if(found == null)
                {
                    return NotFound();
                }

                return Ok(found);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("/items")]
        public async Task<ActionResult> GetAllItemsAsync()
        {
            try
            {
                var allOfThem = _context.ShopItems.AsQueryable().ToArray();

                return Ok(allOfThem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("/categories")]
        public async Task<ActionResult> GetAllCategoriesAsync()
        {
            try
            {
                var allOfThem = _context.Categories.AsQueryable().ToArray();

                return Ok(allOfThem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(500);
            }
        }
    }
}
