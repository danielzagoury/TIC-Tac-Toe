using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex02.TIC_Tac_Toe;

namespace Ex02
{
    public class Logic
    {
        private int m_Turn = 1;
        protected bool isQuit = false;
        internal void setTurn(int turnToChange)
        {
            m_Turn = turnToChange; 
        }
        internal int turnWho()
        {
            return m_Turn;
        }
        internal bool checkIfQuit()
        {
            return isQuit;
        }
        internal void PlayTurn(Board board)
        {
            isQuit = false;
            int? columns = board.getColumnsOfTheBorad();
            int? rows = board.getRowsOfTheBoard();
            int index = 0;
            if (m_Turn % 2 == 1)
            {
                System.Console.WriteLine("It's player one turn:");
                Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine("It's player two turn:");
                Console.WriteLine();
            }
            int playerChoice = 0;
            System.Console.WriteLine("Please enter the column that you want to insert the coin:");
            string playerChoiceStr = System.Console.ReadLine();
            if (playerChoiceStr == "q" || playerChoiceStr == "Q")
            {
                isQuit = true;
                return;
            }
            int.TryParse(playerChoiceStr, out playerChoice);
            while (playerChoice < 1 || playerChoice > columns)
            {
                System.Console.WriteLine("Please choice again it out of range:");
                playerChoiceStr = System.Console.ReadLine();
                int.TryParse(playerChoiceStr, out playerChoice);
            }
            for (index = (int)rows - 1; index >= 0; index--)
            {
                if (board.getSpecificPlace(index, playerChoice - 1) == 0)
                {
                    board.changeIndex(index, playerChoice - 1, m_Turn % 2 * -1 + 2);
                    m_Turn++;
                    return;
                }
            }
            System.Console.WriteLine("The column is full, please try anoter column:");
            PlayTurn(board);
        }
        internal void playTurnWithComputer(Board board)
        {
            isQuit = false;
            int? columns = board.getColumnsOfTheBorad();
            int? rows = board.getRowsOfTheBoard();
            int index = 0;
            int playerChoice = 0;
            int computerChoice = computerTurn(board);
            if (m_Turn % 2 == 1)
            {
                System.Console.WriteLine("It's your turn:");
                Console.WriteLine();
                System.Console.WriteLine("Please enter the column that you want to insert the coin:");
                string playerChoiceStr = System.Console.ReadLine();
                playerChoice = 0;
                if (playerChoiceStr == "q" || playerChoiceStr == "Q")
                {
                    isQuit = true;
                    return;
                }
                int.TryParse(playerChoiceStr, out playerChoice);
                while (playerChoice < 1 || playerChoice > columns)
                {
                    System.Console.WriteLine("Please choice again it out of range:");
                    playerChoiceStr = System.Console.ReadLine();
                    int.TryParse(playerChoiceStr, out playerChoice);
                }
            }
            else
            {
                playerChoice = computerChoice;
            }
            for (index = (int)rows - 1; index >= 0; index--)
            {
                if (board.getSpecificPlace(index, playerChoice - 1) == 0)
                {
                    board.changeIndex(index, playerChoice - 1, m_Turn % 2 * -1 + 2);

                    m_Turn++;
                    return;
                }
            }
            computerTurn(board);
        }
        internal int isWin(Board board)
        {
            int? columns = board.getColumnsOfTheBorad();
            int? rows = board.getRowsOfTheBoard();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= columns - 4; col++)
                {
                    if (board.getSpecificPlace(row, col) == 1 && (board.getSpecificPlace(row, col + 1) == 1 && (board.getSpecificPlace(row, col + 2) == 1 && (board.getSpecificPlace(row, col + 3) == 1))))
                    {
                        return 1;
                    }
                    if (board.getSpecificPlace(row, col) == 2 && (board.getSpecificPlace(row, col + 1) == 2 && (board.getSpecificPlace(row, col + 2) == 2 && (board.getSpecificPlace(row, col + 3) == 2))))
                    {
                        return 2;
                    }
                }
            }
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row <= rows - 4; row++)
                {
                    if (board.getSpecificPlace(row, col) == 1 && (board.getSpecificPlace(row + 1, col) == 1 && (board.getSpecificPlace(row + 2, col) == 1 && (board.getSpecificPlace(row + 3, col) == 1))))
                    {
                        return 1;
                    }
                    if (board.getSpecificPlace(row, col) == 2 && (board.getSpecificPlace(row + 1, col) == 2 && (board.getSpecificPlace(row + 2, col) == 2 && (board.getSpecificPlace(row + 3, col) == 2))))
                    {
                        return 2;
                    }
                }
            }
            for (int row = 0; row <= rows - 4; row++)
            {
                for (int col = 0; col <= columns - 4; col++)
                {
                    if (board.getSpecificPlace(row, col) == 1 && (board.getSpecificPlace(row + 1, col + 1) == 1 && (board.getSpecificPlace(row + 2, col + 2) == 1 && (board.getSpecificPlace(row + 3, col + 3) == 1))))
                    {
                        return 1;
                    }
                    if (board.getSpecificPlace(row, col) == 2 && (board.getSpecificPlace(row + 1, col + 1) == 2 && (board.getSpecificPlace(row + 2, col + 2) == 2 && (board.getSpecificPlace(row + 3, col + 3) == 2))))
                    {
                        return 2;
                    }
                }
            }
            for (int row = (int)rows - 1; row >= 3; row--)
            {
                for (int col = 0; col <= columns - 4; col++)
                {
                    if (board.getSpecificPlace(row, col) == 1 && (board.getSpecificPlace(row - 1, col + 1) == 1 && (board.getSpecificPlace(row - 2, col + 2) == 1 && (board.getSpecificPlace(row - 3, col + 3) == 1))))
                    {
                        return 1;
                    }
                    if (board.getSpecificPlace(row, col) == 2 && (board.getSpecificPlace(row - 1, col + 1) == 2 && (board.getSpecificPlace(row - 2, col + 2) == 2 && (board.getSpecificPlace(row - 3, col + 3) == 2))))
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }
        internal bool isMatrixFull(Board board)
        {
            int? columns = board.getColumnsOfTheBorad();
            int? rows = board.getRowsOfTheBoard();

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int columnsIndex = 0; columnsIndex < columns; columnsIndex++)
                {
                    if (board.getSpecificPlace(rowIndex, columnsIndex) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        internal bool gameOver(Board board)
        {
            return (isMatrixFull(board) || isWin(board) == 1 || isWin(board) == 2 || isQuit == true);
        }
        internal void isQuitGame()
        {
            isQuit = false;
        }
        internal int computerTurn(Board board)
        {
            Random computerChoice = new Random();
            int randomNumber = computerChoice.Next(1, (int)board.getColumnsPlusOne());
            return randomNumber;
        }
    }
}



