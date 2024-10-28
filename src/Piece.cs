namespace piece
{
    using position;
    using UnityEngine;
    using System.Collections.Generic;

    public abstract class Piece : MonoBehaviour
    {
        public string Name;
        public string Color;//black or white
        public Position pos;
        public bool haveMoved;//check if Rook/King/Pawn have moved before
        public List<List<Position>> validMoves; // list of valid positions where pieces can travel to 

        Piece(string Name,string Color,Position pos)
        {
            this.Name = Name;
            this.Color = Color;
            this.pos = pos;
            this.haveMoved = false;
            this.validMoves = new List<List<Position>>();
        }

        public abstract void move();

    }
}
