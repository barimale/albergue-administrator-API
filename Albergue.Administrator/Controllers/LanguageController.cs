using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using Albergue.Administrator.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Albergue.Administrator.Controllers
{
    [Route("api/shop/[controller]/[action]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AdministrationConsoleDbContext _context;
        private readonly ILogger<LanguageController> _logger;

        public LanguageController(
            ILogger<LanguageController> logger,
            AdministrationConsoleDbContext context,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageEntry))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddLanguageAsync(Category item)
        {
            try
            {
                var mapped = _mapper.Map<LanguageEntry>(item);
                var result = await _context.Languages.AddAsync(mapped);

                await _context.SaveChangesAsync();

                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteLanguageAsync(Language item)
        {
            try
            {
                var mapped = _mapper.Map<LanguageEntry>(item);


                var deleted = _context.Languages.Remove(mapped);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageEntry))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetLanguageByIdAsync(string id)
        {
            try
            {
                var found = await _context.Languages.AsQueryable().FirstOrDefaultAsync(p => p.Id == id);

                if(found == null)
                {
                    return NotFound();
                }

                return Ok(found);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LanguageEntry[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllLanguagesAsync()
        {
            try
            {
                var allOfThem = await _context.Languages.ToArrayAsync();

                return Ok(allOfThem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return StatusCode(400);
            }
        }
    }
}
