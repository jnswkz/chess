namespace position
{
using UnityEngine;

public class Position : MonoBehaviour
{
    int x, y;
    void Start()
    {
        x = 0;
        y = 0;
    }

    public void setPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 getPos()
    {
        return new Vector2(x, y); 
    }
}
}
