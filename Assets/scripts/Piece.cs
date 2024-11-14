using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Piece : MonoBehaviour
{
    [SerializeField]protected int Color; // (0 is white, 1 is black);
    protected List<Vector2Int> ValidMoves;
    protected ChessPosition pos;
    protected Map myMap;
    virtual protected void Start()
    {
        pos = new ChessPosition();
        ValidMoves = new List<Vector2Int>();
        myMap = Map.Instance;
        
    }
    public int get_Color()
    {
        return Color;
    }

    public void set_Color(int color)
    {
        Color = color;
    }
    public void set_Position(int x, int y)
    {
        if (myMap == null)
        {
            StartCoroutine(DelayedAction(0.1f, x, y));
            //Phải delay vì có thể khi mới tạo object hàm start chưa kịp khởi động, dẫn đến các biến cần dùng chưa được khởi tạo 
            //Delay để chờ các biến cần thiết được khởi tạo ở hàm Start()
        }
        else
        {

            
            pos.setPos(x, y);
            myMap.updateRealPosition(this, x, y);
            myMap.Replace_At(this, x, y);
            Refresh_Valid_Moves();
        }



    }
    public List<Vector2Int> getValidMoves()
    {
        if (myMap.GetCurrentSide() != Color)
        {
            return new List<Vector2Int>();
        }
        return ValidMoves;
    }
    virtual public void Refresh_Valid_Moves()
    {

    }

    IEnumerator DelayedAction(float delay, int x, int y)
    {
        yield return new WaitForSeconds(delay); // Delay tính theo giây
                                                // Thực hiện hành động sau delay
        set_Position(x, y);
        // Khi hết thời gian sẽ gọi lại hàm ban đầu để thực hiện những bước cần thực hiện
    }
    public bool check_Valid_Move(Vector2Int newPos)
    {
        for (int i = 0; i  < ValidMoves.Count; i++)
        {
            if (ValidMoves[i] == newPos)
            {
                return true;
            }
        }
        return false;
    } 
    public Vector2Int getPos()
    {
        return new Vector2Int (pos.getPos().x, pos.getPos().y);
    }
    // Khởi chạy coroutine
    

}
