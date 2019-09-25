using System.Threading.Tasks;

namespace Snappet.Core.Queries
{
    public interface IAsyncQuery<in TInput, TOutput>
    {
        Task<TOutput> Ask(TInput input);
    }
}
