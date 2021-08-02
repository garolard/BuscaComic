using System.Threading.Tasks;

namespace BuscaComic.Core.Infraestructure
{
    public interface IRestFacade
    {
        Task<TRes> Get<TRes>(string url);
        Task<TRes> Post<TRes, TReq>(string url, TReq requestBody);
    }
}
