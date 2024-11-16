using UnityEngine;

public class Pawn : Piece
{

    override protected void Start()
    {
        base.Start();
    }
    public override void RefreshValidMoves()
    {
        base.RefreshValidMoves();
        ValidMoves.Clear();
        

        //di thang

        if (Color == 0 && myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y + 1) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x , pos.getPos().y + 1));
            if (pos.getPos().y  == 2 && myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y + 2) == -1) ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y + 2));

        }

        if (Color == 1 && myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y - 1) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y - 1));
            if (pos.getPos().y == 7 && myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y - 2) == -1) ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y - 2));

        }
        //di cheo an linh

        if (Color == 0 && myMap.getColorAtPosition(pos.getPos().x + 1, pos.getPos().y + 1) == 1) ValidMoves.Add(new Vector2Int(pos.getPos().x + 1, pos.getPos().y + 1)); 
        
        if (Color == 0 && myMap.getColorAtPosition(pos.getPos().x - 1, pos.getPos().y + 1) == 1) ValidMoves.Add(new Vector2Int(pos.getPos().x - 1, pos.getPos().y + 1));

        if (Color == 1 && myMap.getColorAtPosition(pos.getPos().x + 1, pos.getPos().y - 1) == 0) ValidMoves.Add(new Vector2Int(pos.getPos().x + 1, pos.getPos().y - 1));
        if (Color == 1 && myMap.getColorAtPosition(pos.getPos().x - 1, pos.getPos().y - 1) == 0) ValidMoves.Add(new Vector2Int(pos.getPos().x - 1, pos.getPos().y - 1));


    }
}
