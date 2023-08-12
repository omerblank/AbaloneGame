namespace AbaloneGame.Model
{
    internal class Board
    {
        private BitSet boardEdgeSet;
        private BitSet whiteSet;
        private BitSet blackSet;

        /// <summary>
        /// constructor
        /// </summary>
        public Board()
        {
            InitboardEdge();
            InitWhiteSet();
            InitBlackSet();
        }

        /// <summary>
        /// EdgeOfBoard properties
        /// </summary>
        public BitSet EdgeOfBoard
        {
            get { return this.boardEdgeSet; }
            set { this.boardEdgeSet = value; }
        }

        /// <summary>
        /// WhiteSet properties
        /// </summary>
        public BitSet WhiteSet
        {
            get { return this.whiteSet; }
            set { this.whiteSet = value; }
        }

        /// <summary>
        /// BlackSet properties
        /// </summary>
        public BitSet BlackSet
        {
            get { return this.blackSet; }
            set
            {
                this.blackSet = value;
            }
        }

        /// <summary>
        /// EdgeOfBoard initializing function
        /// </summary>
        private void InitboardEdge()
        {
            EdgeOfBoard = new BitSet();
            EdgeOfBoard.Set(12, 17);
            EdgeOfBoard.Set(23, 29);
            EdgeOfBoard.Set(34, 41);
            EdgeOfBoard.Set(45, 53);
            EdgeOfBoard.Set(56, 65);
            EdgeOfBoard.Set(68, 76);
            EdgeOfBoard.Set(80, 87);
            EdgeOfBoard.Set(92, 98);
            EdgeOfBoard.Set(104, 109);
        }

        /// <summary>
        /// WhiteSet initializing function
        /// </summary>
        private void InitWhiteSet()
        {
            WhiteSet = new BitSet();
            WhiteSet.Set(12, 14);
            WhiteSet.Set(23, 25);
            WhiteSet.Set(34, 37);
            WhiteSet.Set(45, 48);
            WhiteSet.Set(56, 59);
            WhiteSet.Set(68);
        }

        /// <summary>
        /// BlackSet initializing function
        /// </summary>
        private void InitBlackSet()
        {
            BlackSet = new BitSet();
            BlackSet.Set(52);
            BlackSet.Set(62, 65);
            BlackSet.Set(73, 76);
            BlackSet.Set(84, 87);
            BlackSet.Set(96, 98);
            BlackSet.Set(107, 109);
        }

        /// <summary>
        /// this function gives the value of the element in the given index
        /// </summary>
        /// <param name="index"> the index of the element </param>
        /// <returns> the value of the element in the given index </returns>
        public int GetCell(int index)
        {
            if (!IsInBoard(index))
                return Constants.OUT_OF_BOARD;
            if (WhiteSet.Get(index))
                return Constants.WHITE_MARBLE;
            if (BlackSet.Get(index))
                return Constants.BLACK_MARBLE;
            return Constants.EMPTY_CELL;
        }

        /// <summary>
        /// this function sets the value of the element in the given index
        /// </summary>
        /// <param name="index"> the index of the element </param>
        /// <param name="value"> the new value of the element </param>
        public void SetCell(int index, int value)
        {
            if (value == Constants.WHITE_MARBLE)
            {
                whiteSet.Set(index, true);
                blackSet.Set(index, false);
            }

            else if (value == Constants.BLACK_MARBLE)
            {
                blackSet.Set(index, true);
                whiteSet.Set(index, false);
            }

            else
            {
                whiteSet.Set(index, false);
                blackSet.Set(index, false);
            }
        }

        /// <summary>
        /// this function checks if an index exists in the board
        /// </summary>
        /// <param name="index"> the given index </param>
        /// <returns> true if the index exists in the board, false if not </returns>
        public bool IsInBoard(int index)
        {
            return EdgeOfBoard.Get(index);
        }

        /// <summary>
        /// this function checks if two indexes are neighbours in the board,
        /// neighbours - one next to other
        /// </summary>
        /// <param name="index1"> first index </param>
        /// <param name="index2"> second index </param>
        /// <returns> true if the indexes are neighbours, false if not </returns>
        public bool IsNeighbours(int index1, int index2)
        {
            int difference;
            difference = index2 - index1;
            return Constants.DIRECTIONS.Contains(difference);
        }

        /// <summary>
        /// this function gives the next position in the line (after index2)
        /// </summary>
        /// <param name="index1"> first index </param>
        /// <param name="index2"> second index </param>
        /// <returns> the next position in the line (after index2) </returns>
        public int GetNextPositionInLine(int index1, int index2)
        {
            int nextPosition;
            nextPosition = index2 - index1 + index2;
            if (!IsInBoard(nextPosition))
                return Constants.OUT_OF_BOARD;
            return nextPosition;
        }

        /// <summary>
        /// this function gives the index that's next to index1 and that's in the same direction index2Side placed relative to index 2
        /// </summary>
        /// <param name="index1"> first index </param>
        /// <param name="index2"> second index </param>
        /// <param name="index2Side"> an index that's next to index2 </param>
        /// <returns> the index that's next to index1 and that's in the same direction index2Side placed relative to index 2 </returns>
        public int GetFirstPosSide(int index1, int index2, int index2Side)
        {
            int direction;
            direction = index2Side - index2;
            if (!IsInBoard(index1 + direction))
                return Constants.OUT_OF_BOARD;
            return index1 + direction;
        }

        // pos1 and pos2 are neighbors, the function returns true if checkPos is next to pos2 in the same line.
        /// <summary>
        /// this function checks if checkIndex is in the same line where index1 and index2 at
        /// </summary>
        /// <param name="index1"> first index </param>
        /// <param name="index2"> second index </param>
        /// <param name="checkIndex"> the index we want to check </param>   
        /// <returns> true if the index is in the same line, false if not </returns>
        public bool IsInLine(int index1, int index2, int checkIndex)
        {
            return (index2 - index1) == (checkIndex - index2);
        }

        /// <summary>
        /// this function switch the values between two elements
        /// </summary>
        /// <param name="index1"> first element's index </param>
        /// <param name="index2"> second element's index </param>
        public void SwitchValues(int index1, int index2)
        {
            int value1, value2;
            value1 = GetCell(index1);
            value2 = GetCell(index2);
            SetCell(index1, value2);
            SetCell(index2, value1);
        }

        /// <summary>
        /// this function updates the board state after a move
        /// </summary>
        /// <param name="move"> the move that changes the board state </param>
        public void UpdateBoard(Move move)
        {
            int playerColor;
            playerColor = GetCell(move.Indexes[0]);
            if (move.SideStep)
            {
                for (int i = 0; i < move.AttackMarbles; i++)
                {
                    SetCell(move.Indexes[i], Constants.EMPTY_CELL);
                    SetCell(move.Indexes[i + move.AttackMarbles], playerColor);
                }
            }
            else
            {
                SetCell(move.Indexes[0], Constants.EMPTY_CELL);
                for (int i = 1; i < move.AttackMarbles + 1; i++)
                    SetCell(move.Indexes[i], playerColor);
                for (int i = 0; i < move.DefenseMarbles; i++)
                    SetCell(move.Indexes[move.AttackMarbles + 1 + i], -playerColor);
            }
        }

        /// <summary>
        /// this function gives an array with all the neighbors (their indexes) of the element in the given index
        /// </summary>
        /// <param name="index"> the element's index </param>
        /// <returns> an array with all the neighbors (their indexes) of the element in the given index </returns>
        public int[] GetNeighbors(int index)
        {
            int neighbor;
            int[] neighbors = new int[6];
            for (int i = 0; i < 6; i++)
            {
                neighbor = (index + Constants.DIRECTIONS[i]);
                if (IsInBoard(neighbor))
                    neighbors[i] = neighbor;
                else
                    neighbors[i] = Constants.OUT_OF_BOARD;
            }
            return neighbors;
        }

        /// <summary>
        /// this function makes a new board that's a clone of this board
        /// </summary>
        /// <returns> a new board that's a clone of this board </returns>
        public Board CloneBoard()
        {
            Board clonedboard = new Board();
            clonedboard.WhiteSet = this.WhiteSet.Clone();
            clonedboard.BlackSet = this.BlackSet.Clone();
            clonedboard.EdgeOfBoard = this.EdgeOfBoard.Clone();
            return clonedboard;
        }
    }
}
