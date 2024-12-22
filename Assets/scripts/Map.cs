using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
public class Map : MonoBehaviour
{

    [SerializeField] Transform checkPoint;
    [SerializeField] float SquareWidth;

    [SerializeField] Piece[] WhitePiecesPrefabs;
    //(Prefaps of white pieces)
    [SerializeField] Piece[] BlackPiecesPrefabs;
    //(Prefaps of black pieces)
    
    //0-Pawn
    //1-King
    //2-Queen
    //3-Bishop
    //4-Knight
    //5-Rook
    [SerializeField] List<Piece> WhitePieces;
    [SerializeField] List<Piece> BlackPieces;

    [SerializeField] int CurrentSide;

    Piece[,] ChessBoard = new Piece[9, 9];
    public Piece WhiteKing;
    public Piece BlackKing;

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
            Piece temp = Instantiate(WhitePiecesPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity);
            temp.setPosition(i, 2);
            WhitePieces.Add(temp); 
            
          
            
        }
        
        for (int i = 1; i <= 8; i++)
        {
            Piece temp = Instantiate(BlackPiecesPrefabs[0], new Vector3(0, 0, 0), Quaternion.identity);
            temp.setPosition(i, 7);
            BlackPieces.Add(temp);
            

        }
        //Summon Pawns
        Piece King = Instantiate(WhitePiecesPrefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
        King.setPosition(5, 1);
        WhitePieces.Add(King);
        WhiteKing = King;
        

        King = Instantiate(BlackPiecesPrefabs[1], new Vector3(0, 0, 0), Quaternion.identity);
        King.setPosition(5, 8);
        BlackPieces.Add(King);
        BlackKing = King;
        

        //Summon Kings

        Piece Queen = Instantiate(WhitePiecesPrefabs[2], new Vector3(0, 0, 0), Quaternion.identity);
        Queen.setPosition(4, 1);
        WhitePieces.Add(Queen);
     

        Queen = Instantiate(BlackPiecesPrefabs[2], new Vector3(0, 0, 0), Quaternion.identity);
        Queen.setPosition(4, 8);
        BlackPieces.Add(Queen);
        


        //Summon Queens

        for (int i = 1; i <= 2; i++)
        {
            Piece WBishop = Instantiate(WhitePiecesPrefabs[3], new Vector3(0, 0, 0), Quaternion.identity);
            WBishop.setPosition(i * 3, 1);
            WhitePieces.Add(WBishop);
            


            Piece BBishop = Instantiate(BlackPiecesPrefabs[3], new Vector3(0, 0, 0), Quaternion.identity);
            BBishop.setPosition(i * 3, 8);
            BlackPieces.Add(BBishop);
           
        }
        //Summon Bishops
        for (int i = 0; i <= 1; i++)
        {
            Piece WKnight = Instantiate(WhitePiecesPrefabs[4], new Vector3(0, 0, 0), Quaternion.identity);
            WKnight.setPosition(i *5 + 2, 1);
            WhitePieces.Add(WKnight);
           

            Piece BKnight = Instantiate(BlackPiecesPrefabs[4], new Vector3(0, 0, 0), Quaternion.identity);
            BKnight.setPosition(i * 5 +2, 8);
            BlackPieces.Add(BKnight);
           
        }
        //Summon Knights

        for (int i = 0; i <= 1; i++)
        {
            Piece WRook = Instantiate(WhitePiecesPrefabs[5], new Vector3(0, 0, 0), Quaternion.identity);
            WRook.setPosition(i * 7 + 1, 1);
            WhitePieces.Add(WRook);
            

            Piece BRook = Instantiate(BlackPiecesPrefabs[5], new Vector3(0, 0, 0), Quaternion.identity);
            BRook.setPosition(i * 7 + 1, 8);
            BlackPieces.Add(BRook);
           
        }
        //Summon Rooks
        // Piece temp2 = Instantiate(WhitePiecesPrefabs[3], new Vector3(0, 0, 0), Quaternion.identity);
        // temp2.setPosition(3, 4);


    }
    public TMP_Text winText;
    public void AnnounceWin(int winner)
    {
        if (winner == 0)
        {
            winText.text = "Black Win";
        }
        else if (winner == 1)
        {
            winText.text = "White Win";
        }
        else
        {
            winText.text = "Draw";
        }
        winText.gameObject.SetActive(true); // Show the text
    }


    public void StopGame(int winner)
    {
        if (winner == 0)
        {
            FindFirstObjectByType<Map>().AnnounceWin(0);
        }
        else if (winner == 1)
        {
            Debug.Log("White Win");
            FindFirstObjectByType<Map>().AnnounceWin(1);
        }
        else
        {
            Debug.Log("Draw");
            FindFirstObjectByType<Map>().AnnounceWin(-1);
        }

        for (int i = 0; i < WhitePieces.Count; i++)
        {
            Destroy(WhitePieces[i].gameObject);
        }
        for (int i = 0; i < BlackPieces.Count; i++)
        {
            Destroy(BlackPieces[i].gameObject);
        }
        WhitePieces.Clear();
        BlackPieces.Clear();
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

    public int getColorAtPosition(int x, int y)
    {
        if (x < 1 || x > 8 || y < 1 || y > 8)
        {
            return -2;
        }
        else if (ChessBoard[x, y] != null) return ChessBoard[x, y].getColor();
        else return -1;
    }

    public void ReplaceAt(Piece NewPiece, int x, int y)
    {
        Piece currentPiece = ChessBoard[x, y];
        if (currentPiece != null)
        {
            if (currentPiece.getColor() == 0) WhitePieces.Remove(currentPiece);
            else BlackPieces.Remove(currentPiece);

            Destroy(currentPiece.gameObject);
        }
        ChessBoard[x, y] = NewPiece;
    }

    public void movePiece(Piece piece, Vector2Int OldPos, Vector2Int NewPos)
    {
        if (piece.checkValidMove(NewPos))
        {
            ChessBoard[OldPos.x, OldPos.y] = null;
            piece.setPosition(NewPos.x, NewPos.y);
            
            UpdateCurrentSide();
            RefreshAllValidMoves();
            List<int> result = CheckMate();
            if (result[0] == 1) {
                Debug.Log("Checkmate");
                Debug.Log(result[1]);
                Debug.Log(result[2]);
            }

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
    
    public void ShowValidMoves(List<Vector2Int> ValidMoves)
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

    public void RefreshAllValidMoves()
    {
        for (int i = 0; i < WhitePieces.Count; i++)
        {
            WhitePieces[i].RefreshValidMoves();
        }
        for (int i = 0; i < BlackPieces.Count; i++)
        {
            BlackPieces[i].RefreshValidMoves();
        }
    }//Use to refresh all pieces's valid moves after a turn

    public Vector2Int RealPositiontoMatrixPosition (Vector2 realPosition) 
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

    public int IsWin(){ // 1 : white, 0 : black, -1 : not win, 2 : draw (update later)
        int currentSide = GetCurrentSide();
        List<Piece> currentPieces = (currentSide == 0)? WhitePieces : BlackPieces;  
        // Zero King found
        bool kingFound = false;
        for (int i = 0; i < WhitePieces.Count; i++)
        {
            if (WhitePieces[i].GetType() == typeof(King))
            {
                kingFound = true;
                break;
            }
        }
        if (!kingFound) return 0;
        kingFound = false;
        for (int i = 0; i < BlackPieces.Count; i++)
        {
            if (BlackPieces[i].GetType() == typeof(King))
            {
                kingFound = true;
                break;
            }
        }
        if (!kingFound) return 1;

        // check draw (update later) 

        // for each piece, get all valid moves, if there's no valid move, then the other side wins. Currently we can't check this
        for (int i = 0; i < currentPieces.Count; i++)
        {
            if (currentPieces[i].getValidMoves().Count > 0) return -1;
        }
 
        return (currentSide == 0)? 1 : 0;
    }

    public List<int> CheckMate()
    {
        List<int> result = new List<int>();
        Debug.Log(CurrentSide);
        List<Piece> otherPieces = (CurrentSide == 1)? WhitePieces : BlackPieces;

        Vector2Int KingPos = (CurrentSide == 1)? BlackKing.getPos() : WhiteKing.getPos();

        for (int i = 0; i < otherPieces.Count; i++){
            List<Vector2Int> validMoves = otherPieces[i].getCanMoves();
            for (int j = 0; j < validMoves.Count; j++){
                int kx = KingPos[0];
                int ky = KingPos[1];
                int mx = validMoves[j][0];
                int my = validMoves[j][1];
                // Debug.Log(kx + " " + ky + " " + mx + " " + my);
                if ( (kx == mx) && (ky == my)) {
                    result.Add(1);
                    result.Add(CurrentSide == 1? 0 : 1);
                    result.Add(i);
                    return result;
                }
            }
        }
        result.Add(0);
        return result;
    }

    public Piece GetAt(int index, int color){
        if (color == 0) return BlackPieces[index];
        return WhitePieces[index];
    }

}   
