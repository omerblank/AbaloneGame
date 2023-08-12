using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame
{
    internal class Exceptions
    {
        //exception for trying to move marbles that are not in the same line
        public class MarblesNotInLineExceptions : Exception
        {
            public MarblesNotInLineExceptions(string message)
                : base(message) { }
        }

        //exception for having a sequence of more than 3 marbles in the same color
        public class MoreThanThreeSameException : Exception
        {
            public MoreThanThreeSameException(string message)
                : base(message) { }
        }

        //exception for trying to move own marbles out of board
        public class SuicideException : Exception
        {
            public SuicideException(string message)
                : base(message) { }
        }

        //exception for having a trapped marble in a marbles sequence, for example: -white-, -white-, -black-, -white- as we see the black marble is trapped.
        public class TrappedMarbleException : Exception
        {
            public TrappedMarbleException(string message)
                : base(message) { }
        }

        //exception for trying to move enemy's ball
        public class NotOwnMarbleException : Exception
        {
            public NotOwnMarbleException(string message)
                : base(message) { }
        }

        public class IllegalMoveException : Exception
        {
            public IllegalMoveException(string message)
                : base(message) { }
        }

        public class CannotPushException : Exception
        {
            public CannotPushException(string message)
                : base(message) { }
        }
    }
}
