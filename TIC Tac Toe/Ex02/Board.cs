using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex02.TIC_Tac_Toe;


namespace Ex02
{
    public class Board
    {
        private int? m_columns = null;
        private int? m_rows = null;
        internal int[,] board;
        internal void createMatrix(int m_columns, int m_rows)
        {
            board = new int[m_rows, m_columns];
        }
        internal void getColumnsOfTheBorad(int num)
        {
            m_columns = num;
        }
        internal int? getColumnsOfTheBorad(){return this.m_columns;}
        internal int? getColumnsPlusOne()
        {
            return m_columns+1;
        }
        internal void getRowsOfTheBoard(int num)
        {
            m_rows = num;
        }
        internal int? getRowsOfTheBoard(){return this.m_rows;}
        internal int? getSpecificPlace(int row, int column)
        {
            return board[row, column];
        }
        internal void changeIndex(int row, int column, int valueToChange)
        {
            board[row, column] = valueToChange;
        }
    }
}
