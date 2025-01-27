using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mission04
{
    internal class SupportingClass
    {
        // Print board method
        public void PrintBoard(int[,] board)
        {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe Board:");
            Console.WriteLine();

            for (int row = 0; row < 3; row++) // for rows 1-3
            {
                for (int col = 0; col < 3; col++) // for columns 1-3
                {
                    char symbol = board[row, col] == 1 ? 'X' : (board[row, col] == -1 ? 'O' : ' '); // If the array has a 1 (player X) print a X, if the array has a -1 (player O) print an O
                    if (col < 2) Console.Write("|"); // column separator
                }

                Console.WriteLine();

                if (row < 2) Console.WriteLine("---+---+---");  // row separator
            }

            Console.WriteLine(); // white space
        }
        public bool DeclareWinner(int[,] board)
        {
            for (int i = 0 ; i < 3; i++)

                {

                if (Math.Abs(board[i, 0] + board[i, 1] + board[i, 2]) == 3 || // check if there is a winner with rows
                (Math.Abs(board[0, i] + board[1, i] + board[2, i]) == 3)) // check if there is a winner with columns
                    {
                    return true;
                    }

                }

            if (Math.Abs(board[0,0] + board[1,1] + board[2,2]) == 3 || // check if there is a winner diagonally
               (Math.Abs(board[0,2] + board[1,1] + board[2,0]) == 3))
                    {
                    return true;
                    }
            else
                {
                return false; 
                }
        }   
    }
}

