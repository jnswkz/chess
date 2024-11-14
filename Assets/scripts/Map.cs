using UnityEngine;
using System.Collections.Generic;
public class Map : MonoBehaviour
{

    [SerializeField] Transform checkPoint;
    [SerializeField] float SquareWidth;

    [SerializeField] Piece[] WhitePiecesPrefaps;
    //(Prefaps of white pieces)
    [SerializeField] Piece[] BlackPiecesPrefaps;
    //(Prefaps of black pieces)
    
    //0-Pawn
    //1-King
    //2-Queen
    //3-Bishop
    //4-Knight
    //5-Rook
    [SerializeField] List<Piece> WhitePieces;
    [SerializeField] List<Piece> NiggaPieces;

    [SerializeField] int CurrentSide;

    Piece[,] ChessBoard = new Piece[9, 9];

    [SerializeField] GameObject DotPrefap;

    List<GameObject> ActiveDots = new List<GameObject>();
    public static Map Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 1; i  <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                ChessBoard[i, j] = null;
            }
        }

    }
    public void Start_Game()
    {
        for (int i = 1; i <= 8; i++)
        {
            Piece temp = Instantiate(WhitePiecesPrefaps[0], new Vector3(0, 0, 0), Quaternion.identity);
            temp.set_Position(i, 2);
            WhitePieces.Add(temp);
            
          
            
        }
        
        for (int i = 1; i <= 8; i++)
        {
            Piece temp = Instantiate(BlackPiecesPrefaps[0], new Vector3(0, 0, 0), Quaternion.identity);
            temp.set_Position(i, 7);
            NiggaPieces.Add(temp);
            

        }
        //Summon Pawns
        Piece King = Instantiate(WhitePiecesPrefaps[1], new Vector3(0, 0, 0), Quaternion.identity);
        King.set_Position(5, 1);
        WhitePieces.Add(King);
        

        King = Instantiate(BlackPiecesPrefaps[1], new Vector3(0, 0, 0), Quaternion.identity);
        King.set_Position(5, 8);
        NiggaPieces.Add(King);
        

        //Summon Kings

        Piece Queen = Instantiate(WhitePiecesPrefaps[2], new Vector3(0, 0, 0), Quaternion.identity);
        Queen.set_Position(4, 1);
        WhitePieces.Add(Queen);
     

        Queen = Instantiate(BlackPiecesPrefaps[2], new Vector3(0, 0, 0), Quaternion.identity);
        Queen.set_Position(4, 8);
        NiggaPieces.Add(Queen);
        


        //Summon Queens

        for (int i = 1; i <= 2; i++)
        {
            Piece WBishop = Instantiate(WhitePiecesPrefaps[3], new Vector3(0, 0, 0), Quaternion.identity);
            WBishop.set_Position(i * 3, 1);
            WhitePieces.Add(WBishop);
            


            Piece BBishop = Instantiate(BlackPiecesPrefaps[3], new Vector3(0, 0, 0), Quaternion.identity);
            BBishop.set_Position(i * 3, 8);
            NiggaPieces.Add(BBishop);
           
        }
        //Summon Bishops
        for (int i = 0; i <= 1; i++)
        {
            Piece W_Knight = Instantiate(WhitePiecesPrefaps[4], new Vector3(0, 0, 0), Quaternion.identity);
            W_Knight.set_Position(i *5 + 2, 1);
            WhitePieces.Add(W_Knight);
           

            Piece B_Knight = Instantiate(BlackPiecesPrefaps[4], new Vector3(0, 0, 0), Quaternion.identity);
            B_Knight.set_Position(i * 5 +2, 8);
            NiggaPieces.Add(B_Knight);
           
        }
        //Summon Knights

        for (int i = 0; i <= 1; i++)
        {
            Piece W_Rook = Instantiate(WhitePiecesPrefaps[5], new Vector3(0, 0, 0), Quaternion.identity);
            W_Rook.set_Position(i * 7 + 1, 1);
            WhitePieces.Add(W_Rook);
            

            Piece B_Rook = Instantiate(BlackPiecesPrefaps[5], new Vector3(0, 0, 0), Quaternion.identity);
            B_Rook.set_Position(i * 7 + 1, 8);
            NiggaPieces.Add(B_Rook);
           
        }
        //Summon Rooks
        Piece temp2 = Instantiate(WhitePiecesPrefaps[3], new Vector3(0, 0, 0), Quaternion.identity);
        temp2.set_Position(3, 4);


    }
    public Vector2 getRealPosition(int x, int y)
    {
        return new Vector2(checkPoint.position.x + SquareWidth * (x - 1) + (SquareWidth / 2), checkPoint.position.y + SquareWidth * (y - 1) + (SquareWidth / 2));
    }
    


    public void updateRealPosition (Piece piece, int x, int y)
    {
       
        piece.transform.position = getRealPosition(x, y) + new Vector2(0, 2f);
        piece.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Row" + y;
        
    }

    public int get_Color_At_Position(int x, int y)
    {
        if (x < 1 || x > 8 || y < 1 || y > 8)
        {
            return -2;
        }
        else if (ChessBoard[x, y] != null) return ChessBoard[x, y].get_Color();
        else return -1;
    }

    public void Replace_At(Piece NewPiece, int x, int y)
    {
        Piece currentPiece = ChessBoard[x, y];
        if (currentPiece != null)
        {
            if (currentPiece.get_Color() == 0) WhitePieces.Remove(currentPiece);
            else NiggaPieces.Remove(currentPiece);

            Destroy(currentPiece.gameObject);
        }
        ChessBoard[x, y] = NewPiece;
    }

    public void movePiece(Piece piece, Vector2Int OldPos, Vector2Int NewPos)
    {
        
        if (piece.check_Valid_Move(NewPos))
        {
            ChessBoard[OldPos.x, OldPos.y] = null;
            piece.set_Position(NewPos.x, NewPos.y);
            UpdateCurrentSide();
            Refresh_All_Valid_Moves();
        }
    } 
    public void removePreviousDot()
    {
        for (int i = 0; i  < ActiveDots.Count; i++)
        {
            GameObject tempDot = ActiveDots[i];
            ActiveDots[i] = null;
            Destroy(tempDot);
        }
    }
    
    public void Show_Valid_Moves(List<Vector2Int> ValidMoves)
    {
        Debug.Log("Show");
        removePreviousDot();
        for (int i = 0; i < ValidMoves.Count; i++)
        {
            GameObject dot = Instantiate(DotPrefap, gameObject.transform.position, Quaternion.identity);
            dot.transform.position = getRealPosition(ValidMoves[i].x, ValidMoves[i].y);
            dot.transform.position += new Vector3Int(0,0,-1);
            ActiveDots.Add(dot);
            
        }
    }//Use to show chosen pieces's valid moves

    public void Refresh_All_Valid_Moves()
    {
        for (int i = 0; i < WhitePieces.Count; i++)
        {
            WhitePieces[i].Refresh_Valid_Moves();
        }
        for (int i = 0; i < NiggaPieces.Count; i++)
        {
            NiggaPieces[i].Refresh_Valid_Moves();
        }
    }//Use to refresh all pieces's valid moves after a turn

    public Vector2Int Real_Position_to_Matrix_Position (Vector2 realPosition) 
    {
        Vector2Int MatrixPos = new Vector2Int();
        MatrixPos.x = (int)Mathf.Ceil((realPosition.x - checkPoint.position.x) / SquareWidth);
        MatrixPos.y = (int)Mathf.Ceil((realPosition.y - checkPoint.position.y) / SquareWidth);

        if (MatrixPos.x < 1 || MatrixPos.x > 8 || MatrixPos.y < 1 || MatrixPos.y > 8) return new Vector2Int(-1,-1);
        return MatrixPos;
    }
    public int GetCurrentSide()
    {
        return CurrentSide;
    }

    public void UpdateCurrentSide()
    {
        CurrentSide = (CurrentSide == 1)? 0 : 1;
    }
}
