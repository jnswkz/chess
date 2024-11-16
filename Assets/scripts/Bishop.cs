using UnityEngine;

public class Bishop : Piece
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override protected void Start()
    {
        base.Start();
    }

    public override void RefreshValidMoves()
    {
        base.RefreshValidMoves();

        ValidMoves.Clear();

        int EnemyColor = Color == 0 ? 1 : 0;

        int tempXY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x - tempXY, pos.getPos().y + tempXY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempXY, pos.getPos().y + tempXY));
            tempXY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x - tempXY, pos.getPos().y + tempXY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempXY, pos.getPos().y + tempXY));
        ////Cheo tren phai
        tempXY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x + tempXY, pos.getPos().y + tempXY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempXY, pos.getPos().y + tempXY));
            tempXY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x + tempXY, pos.getPos().y + tempXY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempXY, pos.getPos().y + tempXY));
        ////Cheo duoi trai
        tempXY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x - tempXY, pos.getPos().y - tempXY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempXY, pos.getPos().y - tempXY));
            tempXY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x - tempXY, pos.getPos().y - tempXY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempXY, pos.getPos().y - tempXY));
        ////Cheo duoi phai
        tempXY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x + tempXY, pos.getPos().y - tempXY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempXY, pos.getPos().y - tempXY));
            tempXY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x + tempXY, pos.getPos().y - tempXY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempXY, pos.getPos().y - tempXY));

    }
}
