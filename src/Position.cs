namespace position
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    public class Position 
    {
        public int column;//a-h
        public int row;//1-8
        
        public Position(int column, int row)
        {
            this.column = column;
            this.row = row;
        }

        public Position(string position)
        {
            this.column = position[0] - 'a';
            this.row = position[1] - '1';
        }

        public Position(Position position)
        {
            this.column = position.column;
            this.row = position.row;
        }

        public Position()
        {
            this.column = 0;
            this.row = 0;
        }

        public toString()
        {
            return (char)(column + 'a') + (char)(row + '1');
        }

        public bool Equals(Position position)
        {
            return this.column == position.column && this.row == position.row;
        }

        public bool IsValid()
        {
            return column >= 0 && column < 8 && row >= 0 && row < 8;
        }

        public bool IsDiagonal(Position position)
        {
            return Math.Abs(this.column - position.column) == Math.Abs(this.row - position.row);
        }

        public bool IsStraight(Position position)
        {
            return this.column == position.column || this.row == position.row;
        }

        public bool IsAdjacent(Position position)
        {
            return Math.Abs(this.column - position.column) <= 1 && Math.Abs(this.row - position.row) <= 1;
        }
s
    }
}
