//Amy Brown, Ben Etheredge, Benz McGahey
//CS 315 - Spring 2016
//Due: Tuesday May 4, 2016
//Final project: Sudoku

using System;
using System.Windows.Forms;

namespace Sudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
