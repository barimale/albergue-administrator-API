using Albergue.Administrator.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Albergue.Administrator.SQLite.Database.Repositories
{
    public interface ILanguageRepository
    {
        Task<Language> AddAsync(Language item, CancellationToken cancellationToken);
        Task<int> DeleteAsync(Language item, CancellationToken cancellationToken);
        Task<Language[]> GetAllAsync(CancellationToken cancellationToken);
    }
}