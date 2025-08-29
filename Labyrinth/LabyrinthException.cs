
namespace Labyrinth
{
    [Serializable]
    internal class LabyrinthException : Exception
    {
        public LabyrinthException()
        {
        }

        public LabyrinthException(string? message) : base(message)
        {
        }

        public LabyrinthException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}