using Albergue.Administrator.Entities;
using Albergue.Administrator.Model;
using Albergue.Administrator.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.SQLite.Database.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly IMapper _mapper;
        private readonly AdministrationConsoleDbContext _context;
        private readonly ILogger<LanguageRepository> _logger;

        public LanguageRepository(
            ILogger<LanguageRepository> logger,
            AdministrationConsoleDbContext context,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Language> AddAsync(Language item, CancellationToken? cancellationToken = null)
        {
            try
            {
                cancellationToken?.ThrowIfCancellationRequested();

                var mapped = _mapper.Map<LanguageBaseEntry>(item);
                var result = await _context.Languages.AddAsync(mapped);

                await _context.SaveChangesAsync();

                var mappedResult = _mapper.Map<Language>(result.Entity);

                return mappedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new SystemException("Adding failed", ex);
            }
        }

        public async Task<int> DeleteAsync(string id, CancellationToken? cancellationToken = null)
        {
            try
            {
                cancellationToken?.ThrowIfCancellationRequested();

                var toBeDeleted = await _context
                    .Languages
                    .FirstOrDefaultAsync(p => p.Id == id, cancellationToken?? default);

                var deleted = _context.Languages.Remove(toBeDeleted);

                return await _context.SaveChangesAsync(cancellationToken?? default);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new SystemException("Deleting failed", ex);
            }
        }

        public async Task<Language[]> GetAllAsync(CancellationToken? cancellationToken)
        {
            try
            {
                cancellationToken?.ThrowIfCancellationRequested();

                var allOfThem = await _context.Languages.ToArrayAsync();
                var mapped = allOfThem.Select(p => _mapper.Map<Language>(p));

                return mapped.ToArray();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
