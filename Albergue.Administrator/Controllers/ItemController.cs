using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using Albergue.Administrator.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PubSub;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.Controllers
{
    [Route("api/shop/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdministrationConsoleDbContext _context;
        private readonly ILogger<ItemController> _logger;
        private Hub hub = Hub.Default;


        public ItemController(ILogger<ItemController> logger, AdministrationConsoleDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShopItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddItemAsync(ShopItem item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<ShopItemEntry>(item);
                mapped.Id = Guid.NewGuid().ToString();
                var result = await _context.ShopItems.AddAsync(mapped, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                hub.Publish(result.Entity);

                var mappedResult = _mapper.Map<ShopItem>(result.Entity);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShopItem))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateItemAsync(ShopItem item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var mapped = _mapper.Map<ShopItemEntry>(item);


                var existed = _context.ShopItems.AsQueryable().FirstOrDefault(p => p.Id == item.Id);
                var updated = _mapper.Map(existed, mapped);
                var result = await _context.ShopItems.AddAsync(updated);

                await _context.SaveChangesAsync();

                var mappedResult = _mapper.Map<ShopItem>(result.Entity);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteItemAsync(ShopItem item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var mapped = _mapper.Map<ShopItemEntry>(item);


                var deleted = _context.ShopItems.Remove(mapped);

                var result = await _context.SaveChangesAsync();

                if(result < 0)
                {
                    return Ok();
                }

                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShopItem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetItemByIdAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var found = await _context.ShopItems.AsQueryable().FirstOrDefaultAsync(p => p.Id == id);

                if(found == null)
                {
                    return NotFound();
                }

                var mappedResult = _mapper.Map<ShopItem>(found);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShopItem[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllItemsAsync(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                var allOfThem = await _context.ShopItems.ToArrayAsync();
                var mapped = allOfThem.Select(p => _mapper.Map<ShopItem>(p));

                return Ok(mapped.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }
    }
}
