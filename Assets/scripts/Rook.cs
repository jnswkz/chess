using UnityEngine;

public class Rook : Piece
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
            ValidMoves.Add(new Vector2Int(pos.getPos().x + tempX, pos.getPos().y ));

            tempX = 1;
            while (myMap.getColorAtPosition(pos.getPos().x - tempX, pos.getPos().y) == -1)
            {
               ValidMoves.Add(new Vector2Int(pos.getPos().x - tempX, pos.getPos().y));
              tempX++;
            }
            if (myMap.getColorAtPosition(pos.getPos().x- tempX, pos.getPos().y ) == EnemyColor)
                ValidMoves.Add(new Vector2Int(pos.getPos().x - tempX, pos.getPos().y ));
    }
}
