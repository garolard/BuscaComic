using System.Threading.Tasks;

namespace BuscaComic.Core.Infrastructure
{
    public interface IRestFacade
    {
        Task<string> Get(string url);
        Task<string> Post<TReq>(string url, TReq requestBody);
    }
}
