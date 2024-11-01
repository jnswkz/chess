namespace Pieces
{
    using Positions;
    using System.Collections.Generic;

    public abstract class Pieces 
    {
        public string Name;
        public string Color;//black or white
        public Positions pos;
        public bool haveMoved;//check if Rook/King/Pawn have moved before
        public List<List<Positions>> validMoves; // list of valid positions where pieces can travel to 

        public Pieces(string Name,string Color,Positions pos)
        {
            this.Name = Name;
            this.Color = Color;
            this.pos = pos;
            this.haveMoved = false;
            this.validMoves = [];
        }

        public abstract void Move();

    }
}
