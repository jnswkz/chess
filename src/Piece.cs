namespace piece
{
    using position;
    using UnityEngine;
    using System.Collections.Generic;

    public abstract class Piece : MonoBehaviour
    {
        public string Name;
        public string Color;
        public Position pos;
        public bool isMoved;
        public List<List<Position>> validMoves;

        Piece(string Name,string Color,Position pos)
        {
            this.Name = Name;
            this.Color = Color;
            this.pos = pos;
            this.isMoved = false;
            this.validMoves = new List<List<Position>>();
        }

        public abstract void move();

    }
}