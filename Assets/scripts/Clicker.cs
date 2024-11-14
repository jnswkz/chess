using UnityEngine;
public class Clicker : MonoBehaviour
{
    Camera m_Camera;

    Map myMap;
    bool hasChosen = false;
    Piece chosenPiece; 
    void Awake()
    {
        m_Camera = Camera.main;
    }
    private void Start()
    {
        myMap = Map.Instance;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition,Vector2.zero);
            Debug.DrawRay(mousePosition, Vector2.zero, Color.red, 2f);
            if (hit.collider != null && !hasChosen)
            {
                Debug.Log(hit.transform.name);
                chosenPiece = hit.transform.GetComponent<Piece>();
                
                if (chosenPiece)
                {
                    myMap.Show_Valid_Moves(chosenPiece.getValidMoves());
                }

                hasChosen = true;
            }
            else if (hasChosen)
            {
                myMap.removePreviousDot();

                Debug.Log(myMap.Real_Position_to_Matrix_Position(mousePosition));
                Vector2Int newPos = myMap.Real_Position_to_Matrix_Position(mousePosition);
                myMap.movePiece(chosenPiece, chosenPiece.getPos(), newPos);

               
                chosenPiece = null;
                hasChosen = false;
            }
           
        }
    }
}
