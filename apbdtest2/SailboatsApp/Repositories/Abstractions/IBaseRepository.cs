using System.Threading;
using System.Threading.Tasks;

namespace SailboatsApp.Repositories.Abstractions
{
    public interface IBaseRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}