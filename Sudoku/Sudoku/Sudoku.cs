using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Sudoku
    {
        public const int BOARD_SIZE = 9;



        public int[,] solutionBoard;
        public int[,] playerBoard;


        public Sudoku ()
        {

            this.playerBoard = new int[BOARD_SIZE, BOARD_SIZE];



        }





    }

    class Constants
    {
        
    }
}
