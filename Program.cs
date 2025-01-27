/* NAME
 DESCRIPTION*/
using System;
using mission04; 
class Program
{
    static void Main(string[] args)
    {
        //instantiating supporting class 
        SupportingClass sc = new SupportingClass();
        
        //0 = blank, 1 = X, 2 = Os
        //array to keep track of choices 
        int[,] board = new int[3, 3];
        
        //initializing player, starting off with player 1 
        int currentPlayer = 1;
        bool gameOver = false;
        int turns = 0; //turns ++ until 9 rounds 

        char userInput = 'X'; 
        
        
        
        //welcome user to game 
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        while(!gameOver && turns < 9)
        {
            // initializing positions 
            int row, col; 
            
            //call the print method from supporting class 
            sc.PrintBoard(board); 
            
            Console.WriteLine($"Player {currentPlayer}, it is your turn! You will put {userInput}" );
            
            // asking for user choice  
            do
            {
                Console.WriteLine($"Please input which row you would like to put {userInput} on the board (0-2)");
                row = int.Parse(Console.ReadLine());
                    
                Console.WriteLine($"Please input which column you would like to put {userInput} on the board (0-2)");
                col = int.Parse(Console.ReadLine());
                
            } while (!ValidMove(row, col, board)); //checking for Bad Input

            board[row, col] = userInput == 'X' ? 1 : -1;



            //switch players 
            if (!gameOver)
            {
                currentPlayer = currentPlayer == 1 ? 2 : 1;
                userInput = userInput == 'X' ? 'O': 'X';
            }
            turns++;
        }  
        
    }
    
    
    //creating a method to make sure they have valid input
    public static bool ValidMove(int row, int col, int [,] board)
    {
        if (row < 0 || row > 2 || col < 0 || col > 2)
        {
            Console.WriteLine("Invalid Move, please put it within the ranges of (0-2)");
            return false;
        }

        if (board[row, col] != 0)
        {
            Console.WriteLine("Invalid Move, space already taken. Please try again with a blank space");
            return false;
        }

        return true;
    }
}


