/* Group 2-9
 Tic-Tac-Toe Simulator*/
using System;
using mission04; 
class Program
{
    static void Main(string[] args)
    {
        // Instantiating the supporting class for additional functionalities.
        SupportingClass sc = new SupportingClass();

        // Array to represent the board: 0 = blank, 1 = X, -1 = O.
        int[,] board = new int[3, 3];

        // Initializing the player; player 1 starts.
        int currentPlayer = 1;
        bool gameOver = false; // Flag to check if the game is over.
        int turns = 0; // Counter for the number of turns, maximum is 9.

        char userInput = 'X'; // Current player's symbol.

        // Displaying a welcome message to the user.
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        // Game loop continues until the game is over or 9 turns are played.
        while (!gameOver && turns < 9)
        {
            // Variables to hold the selected row and column.
            int row, col;

            // Display the current state of the board.
            sc.PrintBoard(board);

            // Informing the current player of their turn and their symbol.
            Console.WriteLine($"Player {currentPlayer}, it is your turn! You’ll place {userInput} on the board.");

            // Loop to ensure the user inputs a valid move.
            do
            {
                // Asking the user to input the row for their move.
                Console.WriteLine($"Please input which row you would like to put {userInput} on the board (0-2)");
                row = GetValidIntegerInput(); // Getting a valid row input.

                // Asking the user to input the column for their move.
                Console.WriteLine($"Please input which column you would like to put {userInput} on the board (0-2)");
                col = GetValidIntegerInput(); // Getting a valid column input.

            } while (!ValidMove(row, col, board)); // Ensuring the move is valid.

            // Updating the board with the current player's move.
            board[row, col] = userInput == 'X' ? 1 : -1;

            // Displaying the updated board.
            sc.PrintBoard(board);

            // Checking if the game has a winner.
            gameOver = sc.DeclareWinner(board);

            // Switching players if the game is not over.
            if (!gameOver)
            {
                currentPlayer = currentPlayer == 1 ? 2 : 1; // Switch player.
                userInput = userInput == 'X' ? 'O' : 'X'; // Switch symbol.
            }

            // Incrementing the turn counter.
            turns++;
        }

        // Checking if the game ended in a tie.
        if (gameOver == false)
        {
            Console.WriteLine("It's a tie. Game Over!"); // Displaying a tie message.
        }
        else
        {
            // Declaring the winner based on the current player.
            if (currentPlayer == 1)
            {
                Console.WriteLine("Player 1 won the game! Player 2 loses. Game Over!");
            }
            else
            {
                Console.WriteLine("Player 2 won the game! Player 1 loses. Game Over!");
            }
        }
    }

    // Method to get a valid integer input from the user.
    public static int GetValidIntegerInput()
    {
        while (true)
        {
            string input = Console.ReadLine(); // Reading input from the user.
            if (int.TryParse(input, out int result)) // Validating if it's an integer.
            {
                return result; // Returning the valid integer.
            }

            // Displaying an error message for invalid input.
            Console.WriteLine("Invalid input! Please enter a number between 0 and 2.");
        }
    }

    // Method to check if the move is valid.
    public static bool ValidMove(int row, int col, int[,] board)
    {
        // Checking if the row and column are within valid bounds.
        if (row < 0 || row > 2 || col < 0 || col > 2)
        {
            Console.WriteLine("Invalid Move, please put it within the ranges of (0-2)");
            return false;
        }

        // Checking if the selected position on the board is already occupied.
        if (board[row, col] != 0)
        {
            Console.WriteLine("Invalid Move, space already taken. Please try again with a blank space");
            return false;
        }

        // Returning true if the move is valid.
        return true;
    }
}
