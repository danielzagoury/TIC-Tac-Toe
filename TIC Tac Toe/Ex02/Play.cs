using Ex02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex02.TIC_Tac_Toe;

namespace Ex02
{
    public class Play
    {
        internal static void PlayGame()
        { 
            Logic logicObject = new Logic();
            UI uiObject = new UI();
            Board board = new Board();
            int playerChoice = uiObject.choiceKindOfGame();
            uiObject.askTheUserForTheColumnsOfTheBoard(board);
            uiObject.askTheUserForTheRowsOfTheBoard(board);
            board.createMatrix((int)board.getColumnsOfTheBorad(), (int)board.getRowsOfTheBoard());
            if (playerChoice == 1)
            {
                while (!logicObject.gameOver(board))
                {
                    logicObject.isQuitGame();
                    ConsoleUtils.Screen.Clear();
                    uiObject.printMatrix(board);
                    logicObject.PlayTurn(board);
                    ConsoleUtils.Screen.Clear();
                }
                uiObject.printMatrix(board);
                uiObject.ScoreBoard(board, logicObject,playerChoice);
                while (uiObject.anotherGame() == true)
                {
                    logicObject.isQuitGame();
                    ConsoleUtils.Screen.Clear();
                    board.createMatrix((int)board.getColumnsOfTheBorad(), (int)board.getRowsOfTheBoard());
                    while (!logicObject.gameOver(board))
                    {
                        ConsoleUtils.Screen.Clear();
                        uiObject.printMatrix(board);
                        logicObject.PlayTurn(board);
                        ConsoleUtils.Screen.Clear();
                    }
                    uiObject.printMatrix(board);
                    uiObject.ScoreBoard(board, logicObject, playerChoice);
                }
            }
            if (playerChoice == 2)
            {
                while (!logicObject.gameOver(board))
                {
                    logicObject.isQuitGame();
                    ConsoleUtils.Screen.Clear();
                    uiObject.printMatrix(board);
                    logicObject.playTurnWithComputer(board);
                    ConsoleUtils.Screen.Clear();
                }
                uiObject.printMatrix(board);
                uiObject.ScoreBoard(board, logicObject, playerChoice);
                while (uiObject.anotherGame() == true)
                {
                    logicObject.isQuitGame();
                    ConsoleUtils.Screen.Clear();
                    board.createMatrix((int)board.getColumnsOfTheBorad(), (int)board.getRowsOfTheBoard());
                    while (!logicObject.gameOver(board))
                    {
                        ConsoleUtils.Screen.Clear();
                        uiObject.printMatrix(board);
                        logicObject.playTurnWithComputer(board);
                        ConsoleUtils.Screen.Clear();
                    }
                    uiObject.printMatrix(board);
                    uiObject.ScoreBoard(board, logicObject, playerChoice);
                }
            }
        }
    }
}
