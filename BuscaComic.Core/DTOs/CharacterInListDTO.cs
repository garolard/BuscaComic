namespace BuscaComic.Core.DTOs
{
    public class CharacterInListDTO : IElementInListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ItemType Type { get; set; }
    }
}
