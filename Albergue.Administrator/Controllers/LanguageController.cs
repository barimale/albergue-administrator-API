using Albergue.Administrator.Model;
using Albergue.Administrator.SQLite.Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PubSub;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.Controllers
{
    [Authorize]
    [Route("api/shop/[controller]/[action]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _repository;
        private readonly ILogger<LanguageController> _logger;
        private readonly Hub _hub;

        private LanguageController()
        {
            _hub = Hub.Default;
        }

        public LanguageController(
            ILogger<LanguageController> logger,
            ILanguageRepository repository)
            : this()
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Language))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddLanguageAsync(Language item, CancellationToken cancellationToken)
        {
            try
            {
                var added = await _repository.AddAsync(item, cancellationToken);
                _hub.Publish(added);

                return Ok(added);
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
                var deleted = await _repository.DeleteAsync(item, cancellationToken);

                if (deleted < 0)
                {
                    _hub.Publish(item);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return StatusCode(400);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Language[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllLanguagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var allOfThem = await _repository.GetAllAsync(cancellationToken);

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
