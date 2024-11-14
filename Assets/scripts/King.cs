using UnityEngine;
using System.Collections.Generic;
public class King : Piece
{
    List <Vector2Int> King_Can_Move;
    override protected void Start()
    {
        base.Start();
        King_Can_Move = new List<Vector2Int>
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

    public override void Refresh_Valid_Moves()
    {
        base.Refresh_Valid_Moves();
        ValidMoves.Clear();
        for (int i = 0; i < King_Can_Move.Count; i++)
        {
            int ColorOfTarget = myMap.get_Color_At_Position(pos.getPos().x + King_Can_Move[i].x, pos.getPos().y + King_Can_Move[i].y);
            if (ColorOfTarget != Color && ColorOfTarget != -2)
            {
                ValidMoves.Add(new Vector2Int(pos.getPos().x + King_Can_Move[i].x, pos.getPos().y + King_Can_Move[i].y));
            }
        }
    }
}
