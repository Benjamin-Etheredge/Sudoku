using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Sudoku
    {
        public const int BOARD_SIZE = 9;

        public const int MINIMUM_VALUE = 1;


        public int[,] solutionBoard;
        public int[,] playerBoard;

        public Random randomObject = new Random();

        public Sudoku (int difficulty)
        {
            this.solutionBoard = new int[BOARD_SIZE, BOARD_SIZE];
            this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE];
            if (difficulty == 0)
            {
                Array.Copy(Constants.EASY_PUZZLE_SOLUTION, solutionBoard, Constants.EASY_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.EASY_PUZZLE, playerBoard, Constants.EASY_PUZZLE.Length);
            }
            else if (difficulty == 1)
            {
                Array.Copy(Constants.MEDIUM_PUZZLE_SOLUTION, solutionBoard, Constants.MEDIUM_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.MEDIUM_PUZZLE, playerBoard, Constants.MEDIUM_PUZZLE.Length);
            }
            else if (difficulty == 2)
            {
                Array.Copy(Constants.HARD_PUZZLE_SOLUTION, solutionBoard, Constants.HARD_PUZZLE_SOLUTION.Length);
                Array.Copy(Constants.HARD_PUZZLE, playerBoard, Constants.HARD_PUZZLE.Length);
            }
            else
            {
                throw new Exception("Not implemented yet");
            }
            SealBoards();

        }

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
        /// </summary>
        /// <returns>Boolean value indicated whether the board is solved</returns>
        public bool IsSolved()
        {
            bool isSolved = true;
            for (int i = 0; i < BOARD_SIZE && isSolved; i++)
            {
                for (int j = 0; j < BOARD_SIZE && isSolved; j++)
                {
                    if (Math.Abs(playerBoard[i,j]) != Math.Abs(solutionBoard[i,j]))
                    {
                        isSolved = false;
                    }
                }
            }

            return isSolved;
        }

        /// <summary>
        /// Validates input
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
                if (playerBoard[xCor, yCor] > 0)
                {
                    this.playerBoard[xCor, yCor] = value;
                    madeMove = true;
                }
            }

            return madeMove;
        }


        public void Help()
        {
            bool hasHelped = false;

            while (!hasHelped)
            {
                // get new random cordinates
                int randomX = randomObject.Next(MINIMUM_VALUE, BOARD_SIZE);
                int randomY = randomObject.Next(MINIMUM_VALUE, BOARD_SIZE);

                if (playerBoard[randomX, randomY] > 0)
                {
                    playerBoard[randomX, randomY] = solutionBoard[randomX, randomY];
                }
            }
            
        }




    }
}
