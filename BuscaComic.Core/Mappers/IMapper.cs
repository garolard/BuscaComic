namespace BuscaComic.Core.Mappers
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom source);
    }
}
