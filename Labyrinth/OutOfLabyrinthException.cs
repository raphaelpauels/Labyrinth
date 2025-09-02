
namespace Labyrinth
{
    [Serializable]
    internal class OutOfLabyrinthException : Exception
    {
        public OutOfLabyrinthException()
        {
        }

        public OutOfLabyrinthException(string? message) : base(message)
        {
        }

        public OutOfLabyrinthException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}