using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex02.TIC_Tac_Toe;

namespace Ex02
{
    internal class UI
    {
        private int m_PlayerOneScore = 0;
        private int m_PlayerTwoScore = 0;
        private int m_ComputerScore = 0;
        private int[] score = new int[3];
        protected readonly int r_MinNumberOfColumnAndRows = 4;
        protected readonly int r_MaxNumberOfColumnAndRows = 8;
        internal void ScoreBoard(Board board,Logic logicObject, int choice)
        {
            if (choice == 1)
            {
                if (logicObject.isMatrixFull(board) == true)
                {
                    string drawOneWinVsRival = string.Format("it's a draw\nplayer one score is: {0}\nplayer two score is: {1}", score[0], score[1]);
                    Console.WriteLine(drawOneWinVsRival);
                }
                if (logicObject.isWin(board) == 1 || (logicObject.checkIfQuit() == true && logicObject.turnWho() % 2 == 0))
                {
                    m_PlayerOneScore = m_PlayerOneScore + 1;
                    score[0] = m_PlayerOneScore;
                    string playerOneWinVsRival = string.Format("Player one win!\nplayer one score is: {0}\nplayer two score is: {1}", score[0], score[1]);
                    Console.WriteLine(playerOneWinVsRival);
                }
                if (logicObject.isWin(board) == 2 || (logicObject.checkIfQuit() == true && logicObject.turnWho() % 2 == 1))
                {
                    m_PlayerTwoScore = m_PlayerTwoScore + 1;
                    score[1] = m_PlayerTwoScore;
                    string playerTwoWinVsRival = string.Format("Player two win!\nplayer one score is: {0}\nplayer two score is: {1}", score[0], score[1]);
                    Console.WriteLine(playerTwoWinVsRival);
                }
            }
            if (choice == 2)
            {
                if (logicObject.isMatrixFull(board) == true)
                {
                    string drawVsComputer = string.Format("it's a draw\nplayer one score is: {0}\ncomputer score is: {2}", score[0], score[1], score[2]);
                    Console.WriteLine(drawVsComputer);
                }
                if (logicObject.isWin(board) == 1)
                {
                    m_PlayerOneScore = m_PlayerOneScore + 1;
                    score[0] = m_PlayerOneScore;
                    string playerOneWinVsComputer = string.Format("Player one win!\nplayer one score is: {0}\ncomputer score is: {2}", score[0], score[1], score[2]);
                    Console.WriteLine(playerOneWinVsComputer);
                }
                if (logicObject.isWin(board) == 2 || (logicObject.checkIfQuit() == true))
                {
                    m_ComputerScore = m_ComputerScore + 1;
                    score[2] = m_ComputerScore;
                    string playerOneLossVsComputer = string.Format("The computer win!\nplayer one score is: {0}\ncomputer score is: {2}", score[0], score[1], score[2]);
                    Console.WriteLine(playerOneLossVsComputer);
                }
            }
            logicObject.setTurn(1);
        }
        internal bool anotherGame()
        {
            System.Console.WriteLine("Do you want to play anoter game?");
            System.Console.WriteLine("1 - yes");
            System.Console.WriteLine("2 - no");
            int answer = 0;
            string answerStr = System.Console.ReadLine();
            int.TryParse(answerStr, out answer);
            while (answer != 1 && answer != 2)
            {
                System.Console.WriteLine("the input is invalid, please try again");
                answerStr = System.Console.ReadLine();
                int.TryParse(answerStr, out answer);
            }
            if (answer == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal int choiceKindOfGame()
        {
            int playerChoice = 0;
            System.Console.WriteLine("Choose kind of game:");
            System.Console.WriteLine("1- 1VS1 game");
            System.Console.WriteLine("2- VS computer");
            string playerChoiceStr = System.Console.ReadLine();
            int.TryParse(playerChoiceStr, out playerChoice);
            while (playerChoice != 1 && playerChoice != 2)
            {
                System.Console.WriteLine("Please choose again it is not an option:");
                playerChoiceStr = System.Console.ReadLine();
                int.TryParse(playerChoiceStr, out playerChoice);
            }
            return playerChoice;
        }
        internal void askTheUserForTheColumnsOfTheBoard(Board board)
        {
            string columnsStr = null;
            int columns = 0;
            System.Console.WriteLine("Please enter the number of the columns (between 4 to 8)");
            columnsStr = System.Console.ReadLine();
            int.TryParse(columnsStr, out columns);
            while (columns < r_MinNumberOfColumnAndRows || columns > r_MaxNumberOfColumnAndRows || columns % 1 != 0)
            {
                System.Console.WriteLine("the input is invalid, please try again");
                columnsStr = System.Console.ReadLine();
                int.TryParse(columnsStr, out columns);
            }
            board.getColumnsOfTheBorad(columns);
        }
        internal void askTheUserForTheRowsOfTheBoard(Board board)
        {
            string rowsStr = null;
            int rows = 0;
            System.Console.WriteLine("Please enter the number of the rows (between 4 to 8)");
            rowsStr = System.Console.ReadLine();
            int.TryParse(rowsStr, out rows);
            while (rows < r_MinNumberOfColumnAndRows || rows > r_MaxNumberOfColumnAndRows || rows % 1 != 0)
            {
                System.Console.WriteLine("the input is invalid, please try again");
                rowsStr = System.Console.ReadLine();
                int.TryParse(rowsStr, out rows);
            }
            board.getRowsOfTheBoard(rows);
        }
        internal void printMatrix(Board board)
        {
            for (int columnsIndex = 0; columnsIndex < board.getColumnsOfTheBorad(); columnsIndex++)
            {
                int currentColumn = columnsIndex + 1;
                Console.Write("  " + currentColumn + " ");
            }
            Console.WriteLine();
            for (int rowsIndex = 0; rowsIndex < board.getRowsOfTheBoard(); rowsIndex++)
            {
                Console.Write("|");
                for (int columnsIndex = 0; columnsIndex < board.getColumnsOfTheBorad(); columnsIndex++)
                {
                    if (board.getSpecificPlace(rowsIndex, columnsIndex) == 0)
                    {
                        Console.Write("   |");
                    }
                    if (board.getSpecificPlace(rowsIndex, columnsIndex) == 1)
                    {
                        Console.Write(" X |");
                    }
                    if (board.getSpecificPlace(rowsIndex, columnsIndex) == 2)
                    {
                        Console.Write(" O |");
                    }
                }
                Console.WriteLine();
                Console.Write("=");
                for (int index = 0; index < board.getColumnsOfTheBorad(); index++)
                {
                    Console.Write("====");
                }
                Console.WriteLine();
            }
        }

    }
}



    
        
   


