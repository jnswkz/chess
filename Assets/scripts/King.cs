using UnityEngine;
using System.Collections.Generic;
public class King : Piece
{
    List <Vector2Int> KingCanMove;
    override protected void Start()
    {
        base.Start();
        KingCanMove = new List<Vector2Int>
        {
            new Vector2Int(-1,1),
            new Vector2Int(0,1),
            new Vector2Int(1,1),
            new Vector2Int(-1,-1),
            new Vector2Int(0,-1),
            new Vector2Int(1,-1),
            new Vector2Int(1,0),
            new Vector2Int(-1,0)
        };
    }

    public override void RefreshValidMoves()
    {
        base.RefreshValidMoves();
        ValidMoves.Clear();
        for (int i = 0; i < KingCanMove.Count; i++)
        {
            int ColorOfTarget = myMap.getColorAtPosition(pos.getPos().x + KingCanMove[i].x, pos.getPos().y + KingCanMove[i].y);
            if (ColorOfTarget != Color && ColorOfTarget != -2)
            {
                ValidMoves.Add(new Vector2Int(pos.getPos().x + KingCanMove[i].x, pos.getPos().y + KingCanMove[i].y));
            }
        }
    }
}
