using UnityEngine;

[System.Serializable]
public class ChessPosition 
{
    [SerializeField]int x, y;

    

    public void setPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2Int getPos()
    {
        return new Vector2Int(x, y); 
    }
    public ChessPosition ()
    {
        x = 0;
        y = 0;
    }
}
