namespace Positions
{
    using System;
    using System.Collections.Generic;
    public class Positions 
    {
        public int column;//a-h
        public int row;//1-8
        
        public Positions(int column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public Positions(string position)
        {
            this.column = position[0] - 'a';
            this.row = position[1] - '1';
        }

        public Positions(Positions position)
        {
            this.column = position.column;
            this.row = position.row;
        }

        public Positions()
        {
            this.column = 0;
            this.row = 0;
        }

        /*public toString()
        {
            return (char)(column + 'a') + (char)(row + '1');
        }*/

        public bool Equals(Positions position)
        {
            return this.column == position.column && this.row == position.row;
        }

        public bool IsValid()
        {
            return column >= 0 && column < 8 && row >= 0 && row < 8;
        }

        public bool IsDiagonal(Positions position)
        {
            return Math.Abs(this.column - position.column) == Math.Abs(this.row - position.row);
        }

        public bool IsStraight(Positions position)
        {
            return this.column == position.column || this.row == position.row;
        }

        public bool IsAdjacent(Positions position)
        {
            return Math.Abs(this.column - position.column) <= 1 && Math.Abs(this.row - position.row) <= 1;
        }

    }
}
