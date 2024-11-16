using UnityEngine;

public class Queen : Piece
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override protected void Start()
    {
        base.Start();
    }

    public override void RefreshValidMoves()
    {
        ValidMoves.Clear();
        int EnemyColor = Color == 0 ? 1 : 0;
        // di thang

        int tempY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y + tempY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y + tempY));
            tempY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y + tempY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y + tempY));

        tempY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y - tempY) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y - tempY));
            tempY++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x, pos.getPos().y - tempY) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x, pos.getPos().y - tempY));

        //di ngang
        int tempX = 1;
        while (myMap.getColorAtPosition(pos.getPos().x + tempX, pos.getPos().y) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempX, pos.getPos().y));
            tempX++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x + tempX, pos.getPos().y) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempX, pos.getPos().y));

        tempX = 1;
        while (myMap.getColorAtPosition(pos.getPos().x - tempX, pos.getPos().y) == -1)
        {
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempX, pos.getPos().y));
            tempX++;
        }
        if (myMap.getColorAtPosition(pos.getPos().x - tempX, pos.getPos().y) == EnemyColor)
            ValidMoves.Add(new Vector2Int(pos.getPos().x - tempX, pos.getPos().y));

        //di cheo

        ////Cheo tren trai
        int tempXY = 1;
        while (myMap.getColorAtPosition(pos.getPos().x - tempXY, pos.getPos().y+tempXY) == -1)
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
