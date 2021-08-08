namespace BuscaComic.Core.DTOs
{
    public enum ItemType
    {
        Character,
        Comic,
        Movie
    }

    public interface IElementInListDTO
    {
        string Name { get; }
        string Description { get; }
        string ImageUrl { get; }
        ItemType Type { get; }
    }
}
