using UnityEngine;

public class GameObjectSelector : MonoBehaviour
{
    public Furniture selectedFurniture;
    void Update()
    {
        // Check if the cursor is visible and the left mouse button is clicked
        if (Cursor.visible && Input.GetMouseButtonDown(0))
        {
            SelectGameObjectUnderCursor();
        }
    }

    void SelectGameObjectUnderCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            selectedFurniture = hit.collider.gameObject.GetComponent<Furniture>();
            if(selectedFurniture == null)
            {
                return;
            }
        }
    }
}