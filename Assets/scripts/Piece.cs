using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;

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
    public int getColor()
    {
        return Color;
    }

    public void setColor(int color)
    {
        Color = color;
    }
    public void setPosition(int x, int y)
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
            myMap.ReplaceAt(this, x, y);
            RefreshValidMoves();
        }



    }
    public List<Vector2Int> getCanMoves()
    {
        return ValidMoves;
    }
    public List<Vector2Int> getValidMoves()
    {
        if (myMap.GetCurrentSide() != Color)
        {
            return new List<Vector2Int>();
        }
        var checkMate = myMap.CheckMate();
        if (checkMate[0] == 1){
            var side = checkMate[1]; 
            var king = myMap.GetKing(side);
            var kingPos = king.getPos();
            var checkPiece = myMap.GetAt(checkMate[2], side);
            var checkPos = checkPiece.getPos();
            int movex = 0;
            int movey = 0;
            if (kingPos.x > checkPos.x){
                movex = -1;
            }
            else if (kingPos.x < checkPos.x){
                movex = 1;
            }
            if (kingPos.y > checkPos.y){
                movey = -1;
            }
            else if (kingPos.y < checkPos.y){
                movey = 1;
            }
            List <Vector2Int> checkPieceValidMoves = checkPiece.getValidMoves();
            List <Vector2Int> checkPieceCheckKing = new()
            {
                new Vector2Int(checkPos.x, checkPos.y)
            };
            if (checkPiece is not Knight && checkPiece is not Pawn){
                int i = kingPos.x + movex;
                int j = kingPos.y + movey;
                while (i != checkPos.x || j != checkPos.y){
                    var temp = new Vector2Int(i, j);
                    if (checkPieceValidMoves.Contains(temp)){
                        checkPieceCheckKing.Add(temp);
                    }
                    i += movex;
                    j += movey;
                }
            }
            List <Vector2Int> pieceValidMoves = new List<Vector2Int>();
            foreach (var move in ValidMoves){
                if (checkPieceCheckKing.Contains(move)){
                    pieceValidMoves.Add(move);
                }
            }
            return pieceValidMoves;
        }
        return ValidMoves;
    }
    virtual public void RefreshValidMoves()
    {

    }

    IEnumerator DelayedAction(float delay, int x, int y)
    {
        yield return new WaitForSeconds(delay); // Delay tính theo giây
                                                // Thực hiện hành động sau delay
        setPosition(x, y);
        // Khi hết thời gian sẽ gọi lại hàm ban đầu để thực hiện những bước cần thực hiện
    }
    public bool checkValidMove(Vector2Int newPos)
    {
        for (int i = 0; i  < getValidMoves().Count; i++)
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
