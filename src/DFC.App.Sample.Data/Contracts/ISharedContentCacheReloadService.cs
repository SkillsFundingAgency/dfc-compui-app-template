using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.Contracts
{
    public interface ISharedContentCacheReloadService
    {
        Task Reload(CancellationToken stoppingToken);
    }
}
