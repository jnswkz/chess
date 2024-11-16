using UnityEngine;
public class Clicker : MonoBehaviour
{
    Camera mCamera;

    Map myMap;
    bool hasChosen = false;
    Piece chosenPiece; 
    void Awake()
    {
        mCamera = Camera.main;
    }
    private void Start()
    {
        myMap = Map.Instance;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition,Vector2.zero);
            Debug.DrawRay(mousePosition, Vector2.zero, Color.red, 2f);
            if (hit.collider != null && !hasChosen)
            {
                Debug.Log(hit.transform.name);
                chosenPiece = hit.transform.GetComponent<Piece>();
                
                if (chosenPiece)
                {
                    myMap.ShowValidMoves(chosenPiece.getValidMoves());
                }

                hasChosen = true;
            }
            else if (hasChosen)
            {
                myMap.removePreviousDot();

                Debug.Log(myMap.RealPositiontoMatrixPosition(mousePosition));
                Vector2Int newPos = myMap.RealPositiontoMatrixPosition(mousePosition);
                myMap.movePiece(chosenPiece, chosenPiece.getPos(), newPos);

               
                chosenPiece = null;
                hasChosen = false;
            }
           
        }
    }
}
