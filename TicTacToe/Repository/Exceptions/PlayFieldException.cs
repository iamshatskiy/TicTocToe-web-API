using System.Security.Cryptography;

namespace TicTacToe.Repository.Exceptions
{
    public class PlayFieldException : Exception
    {
        public PlayFieldException(string _message)
            : base("[PlayFieldException] " + _message) { }
    }

    public class PlayFieldAddException : PlayFieldException
    {
        public PlayFieldAddException()
            : base("[Add] Trying to add empty NULL field!") { }
        public PlayFieldAddException(int _turn) : base("[Add] It is not possible " +
            "to add a field with a negative move number(" + _turn.ToString() + ")") { }
    }
    public class PlayFieldNotFoundException : PlayFieldException
    {
        public PlayFieldNotFoundException(int _uk)
            : base("[NotFound] Play field with Id " + _uk.ToString() + " is not found!") { }
    }
    public class PlayFiledDeleteException : PlayFieldException
    {
        public PlayFiledDeleteException(int _uk)
            : base("[Delete] Play field with Id " + _uk.ToString() + " does not exists!") { }
    }

    public class PlayFieldUpdateException : PlayFieldException
    {
        public PlayFieldUpdateException(int _uk)
            : base("[Update] Play field with Id " + _uk.ToString() + " does not exists!") { }
    }

    public class WinnerException : Exception
    {
        public WinnerException()
            : base("[Win] The game ended in a draw") { }

    }
}
