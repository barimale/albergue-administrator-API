using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using Albergue.Administrator.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.Controllers
{
    [Authorize]
    [Route("api/shop/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdministrationConsoleDbContext _context;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, AdministrationConsoleDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategoryAsync(Category item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<CategoryEntry>(item);
                var result = await _context.Categories.AddAsync(mapped);

                await _context.SaveChangesAsync();

                var mappedResult = _mapper.Map<Category>(result.Entity);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCategoryAsync(Category item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<CategoryEntry>(item);


                var existed = _context.Categories.AsQueryable().FirstOrDefault(p => p.Id == item.Id);
                var updated = _mapper.Map(existed, mapped);
                var result = await _context.Categories.AddAsync(updated);

                await _context.SaveChangesAsync();

                var mappedResult = _mapper.Map<Category>(result.Entity);

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
        public async Task<ActionResult> DeleteCategoryAsync(Category item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<CategoryEntry>(item);


                var deleted = _context.Categories.Remove(mapped);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCategoryByIdAsync(string id, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var found = await _context
                    .Categories
                    .Include(p => p.TranslatableDetails)
                    .ThenInclude(pp => pp.Language)
                    .AsQueryable().FirstOrDefaultAsync(p => p.Id == id);

                if(found == null)
                {
                    return NotFound();
                }

                var mappedResult = _mapper.Map<Category>(found);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var allOfThem = await _context.Categories.ToArrayAsync();

                var mapped = allOfThem.Select(p => _mapper.Map<Category>(p));

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
