using UnityEngine;
using System.Collections.Generic;

public class Knight : Piece
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List <Vector2Int> KnightCanMove;
    override protected void Start()
    {
        base.Start();
        KnightCanMove = new List<Vector2Int>
            {
                new Vector2Int(-1, 2),
                new Vector2Int(-2,1),
                new Vector2Int(1, 2),
                new Vector2Int(2,1),
                new Vector2Int(-1, -2),
                new Vector2Int(-2,-1),
                new Vector2Int(1, -2),
                new Vector2Int(2,-1)
            };
    }

   
    public override void RefreshValidMoves()
    {
        base.RefreshValidMoves();
        ValidMoves.Clear();
        for (int i = 0; i  < KnightCanMove.Count; i++)
        {
            int ColorOfTarget = myMap.getColorAtPosition(pos.getPos().x + KnightCanMove[i].x, pos.getPos().y + KnightCanMove[i].y);
            if (ColorOfTarget != Color && ColorOfTarget != -2)
            {
                ValidMoves.Add( new Vector2Int(pos.getPos().x + KnightCanMove[i].x, pos.getPos().y + KnightCanMove[i].y) );
            }
        }
    }
}
