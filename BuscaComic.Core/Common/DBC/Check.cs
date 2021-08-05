namespace BuscaComic.Core.Common.DBC
{
    public class Check
    {
        public static void Require(bool precondition, string message)
        {
            if (!precondition)
                throw new PreconditionException("Precondition: " + message);
        }
    }
}
