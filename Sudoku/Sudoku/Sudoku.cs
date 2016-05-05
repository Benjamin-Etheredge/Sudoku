//Amy Brown, Ben Etheredge, Benz McGahey
//CS 315 - Spring 2016
//Due: Tuesday May 4, 2016
//Final project: Sudoku

using System;
namespace Sudoku
{
    class Sudoku
    {
        public const int BOARD_SIZE = 9;

        //In ValidateInput, needs to be 0 because clearing a textbox re-inserts a 0;
        //In Help, has to be 0 so the hints include row & col 0
        public const int MINIMUM_VALUE = 0;

        //Different # of hints based on difficulty
        public int HINTS_LEFT;

        // boards to be utilized by program
        public int[,] solutionBoard;
        public int[,] playerBoard;

        // For generating random hints
        public Random randomObject = new Random();

        /// <summary>
        /// Game Constructor
        /// - Ben & Amy
        /// </summary>
        /// <param name="difficulty">Difficulty of board</param>
        public Sudoku (int difficulty)
        {
            this.solutionBoard = new int[BOARD_SIZE, BOARD_SIZE];
            this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE];
            if (difficulty == 0)
            {
                HINTS_LEFT = 7;
                Array.Copy(Constants.EASY_PUZZLE_SOLUTION, solutionBoard, Constants.EASY_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.EASY_PUZZLE, playerBoard, Constants.EASY_PUZZLE.Length);
            }
            else if (difficulty == 1)
            {
                HINTS_LEFT = 5;
                Array.Copy(Constants.MEDIUM_PUZZLE_SOLUTION, solutionBoard, Constants.MEDIUM_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.MEDIUM_PUZZLE, playerBoard, Constants.MEDIUM_PUZZLE.Length);
            }
            else if (difficulty == 2)
            {
                HINTS_LEFT = 3;
                Array.Copy(Constants.HARD_PUZZLE_SOLUTION, solutionBoard, Constants.HARD_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.HARD_PUZZLE, playerBoard, Constants.HARD_PUZZLE.Length);
            }
            else
            {
                throw new Exception("Not implemented yet");
            }
            SealBoards();
        }

        /// <summary>
        /// Locks the given correct values in playerBoard and all values in solutionBoard
        /// - Ben
        /// </summary>
        public void SealBoards()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    playerBoard[i, j] *= -1;
                    solutionBoard[i, j] *= -1;
                }
            }
        }

        /// <summary>
        /// Determines if the board is correctly solved
        /// - Ben & Amy
        /// </summary>
        /// <returns>Boolean value indicated whether the board is solved</returns>
        public bool IsSolved()
        {
            bool isSolved = true;
            for (int i = 0; i < BOARD_SIZE && isSolved; i++)
            {
                for (int j = 0; j < BOARD_SIZE && isSolved; j++)
                {
                    if ((Math.Abs(playerBoard[i,j]) != Math.Abs(solutionBoard[i,j])) && (Math.Abs(playerBoard[i, j]) != -Math.Abs(solutionBoard[i, j])))
                    {
                        isSolved = false;
                    }
                }
            }

            return isSolved;
        }

        /// <summary>
        /// Validates input
        /// - Ben
        /// </summary>
        /// <param name="value"></param>
        /// <param name="xCor"></param>
        /// <param name="yCor"></param>
        /// <returns></returns>
        public bool ValidateInput(int value, int xCor, int yCor)
        {
            bool isValid = false;
            if (value < MINIMUM_VALUE || value > BOARD_SIZE)
            {
                throw new Exception("Invalid input value for making a move");
            }
            else if (xCor >= BOARD_SIZE || yCor >= BOARD_SIZE || playerBoard[xCor, yCor] < 0)
            {
                throw new Exception("Invalid corrdinates for making a move");
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Checks if the players board is correct at corrdinates
        /// - Ben
        /// </summary>
        /// <param name="xCor">x cordinate of spot to check</param>
        /// <param name="yCor">y cordinate of spot to check</param>
        /// <returns>Whether that spot is correct or not</returns>
        public bool CheckSpot(int xCor, int yCor)
        {
            return Math.Abs(this.solutionBoard[xCor, yCor]) == Math.Abs((this.playerBoard[xCor, yCor])); 
        }

        /// <summary>
        /// Makes the move designated by user
        /// - Ben & Amy
        /// </summary>
        /// <param name="value">Value to be added to board</param>
        /// <param name="xCor">x cordinate of move</param>
        /// <param name="yCor">y cordinate of move</param>
        /// <returns>Boolean value of whether the move was valid</returns>
        public bool MakeMove(int value, int xCor, int yCor)
        {
            bool madeMove = false;
            if (ValidateInput(value, xCor, yCor))
            {
                if (playerBoard[xCor, yCor] >= MINIMUM_VALUE)   //has to be >= because empty spots are = 0, unlocked full spots are > 0
                {
                    this.playerBoard[xCor, yCor] = value;
                    madeMove = true;
                }
            }

            return madeMove;
        }

        /// <summary>
        /// Inserts a correct value into a random space of playerBoard
        /// - Ben & Amy
        /// </summary>
        public void Help()
        {
            bool hasHelped = false;

            while (!hasHelped && (HINTS_LEFT > 0))
            {
                // get new random cordinates
                int randomX = randomObject.Next(MINIMUM_VALUE, BOARD_SIZE);
                int randomY = randomObject.Next(MINIMUM_VALUE, BOARD_SIZE); 

                if (playerBoard[randomX, randomY] >= MINIMUM_VALUE) //has to be >= 0 because empty spots are = 0, unlocked full spots are > 0
                {
                    playerBoard[randomX, randomY] = solutionBoard[randomX, randomY];
                    hasHelped = true;   //need this line to exit loop
                    HINTS_LEFT--;
                }
            }
        }        
    }
}
