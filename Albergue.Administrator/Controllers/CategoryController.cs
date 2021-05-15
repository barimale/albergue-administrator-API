﻿using Albergue.Administrator.Model;
using Albergue.Administrator.SQLite.Database.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(
            ILogger<CategoryController> logger,
            ICategoryRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategoryAsync(Category item, CancellationToken cancellationToken)
        {
            try
            {
                var added = await _repository.AddAsync(item, cancellationToken);

                return Ok(added);
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
                var updated = await _repository.UpdateAsync(item, cancellationToken);

                return Ok(updated);
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
                var result = await _repository.DeleteAsync(item, cancellationToken);

                if (result < 0)
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
                var found = await _repository.GetByIdAsync(id, cancellationToken);

                if (found == null)
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllCategoriesAsync(CancellationToken cancellationToken)
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
