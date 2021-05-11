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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Language))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddLanguageAsync(Language item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<LanguageEntry>(item);
                var result = await _context.Languages.AddAsync(mapped);

                await _context.SaveChangesAsync();

                var mappedResult = _mapper.Map<Language>(result.Entity);

                return Ok(mappedResult);
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
        public async Task<ActionResult> DeleteLanguageAsync(Language item, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Language[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllLanguagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var allOfThem = await _context.Languages.ToArrayAsync();
                var mapped = allOfThem.Select(p => _mapper.Map<Language>(p));

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
