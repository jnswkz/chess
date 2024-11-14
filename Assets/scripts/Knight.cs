using UnityEngine;
using System.Collections.Generic;

public class Knight : Piece
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List <Vector2Int> Knight_Can_Move;
    override protected void Start()
    {
        base.Start();
        Knight_Can_Move = new List<Vector2Int>
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

   
    public override void Refresh_Valid_Moves()
    {
        base.Refresh_Valid_Moves();
        ValidMoves.Clear();
        for (int i = 0; i  < Knight_Can_Move.Count; i++)
        {
            int ColorOfTarget = myMap.get_Color_At_Position(pos.getPos().x + Knight_Can_Move[i].x, pos.getPos().y + Knight_Can_Move[i].y);
            if (ColorOfTarget != Color && ColorOfTarget != -2)
            {
                ValidMoves.Add( new Vector2Int(pos.getPos().x + Knight_Can_Move[i].x, pos.getPos().y + Knight_Can_Move[i].y) );
            }
        }
    }
}
