using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mission04
{
    internal class SupportingClass
    {
        public void PrintBoard(int[,] board)
        {
            Console.Clear();
            Console.WriteLine("Tic-Tac-Toe Board:");
            Console.WriteLine();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    char symbol = board[row, col] == 1 ? 'X' : (board[row, col] == -1 ? 'O' : ' ');
                    if (col < 2) Console.Write("|"); // Add column separator
                }

                Console.WriteLine();

                if (row < 2) Console.WriteLine("---+---+---"); // Add row separator
            }

            Console.WriteLine();
        }
        public bool DeclareWinner(int[,] board)
        {
            for (int i = 0 ; i < 3; i++)
                {
                if (Math.Abs(board[i, 0] + board[i, 1] + board[i, 2]) == 3 ||
                (Math.Abs(board[0, i] + board[1, i] + board[2, i]) == 3))
                    {
                    return true;
                    }
                }
                
                if (Math.Abs(board[0,0] + board[1,1] + board[2,2]) == 3 ||
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

