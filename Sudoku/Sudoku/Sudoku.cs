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


        public Sudoku (int difficulty)
        {
            if (difficulty == 0)
            {
                this.solutionBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.EASY_PUZZLE_SOLUTION);
                this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.EASY_PUZZLE);
            }
            if (difficulty == 1)
            {
                this.solutionBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.MEDIUM_PUZZLE_SOLUTION);
                this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.MEDIUM_PUZZLE);
            }
            if (difficulty == 2)
            {
                this.solutionBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.HARD_PUZZLE_SOLUTION);
                this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE](Constants.HARD_PUZZLE);
            }
            else
            {
                throw new Exception("Not implemented yet");
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
                    if (playerBoard[i,j] != solutionBoard[i,j])
                    {
                        isSolved = false;
                    }
                }
            }

            return isSolved;
        }

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

        public bool CheckSpot(int value, int xCor, int yCor)
        {
            if (ValidateInput(value, xCor, yCor))
            { 
                return this.solutionBoard[xCor, yCor] == value;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="xCor"></param>
        /// <param name="yCor"></param>
        /// <returns></returns>
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





    }
}
