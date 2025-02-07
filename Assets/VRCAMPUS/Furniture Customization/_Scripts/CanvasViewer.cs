using UnityEngine;

public class CanvasViewer : MonoBehaviour
{
    public Canvas canvas;
    public GameObjectSelector gameObjectSelector;
    public int currentIndex = 0;

    void Start()
    {
        // Ensure the canvas is initially disabled
        canvas.enabled = false;
    }

    void Update()
    {
        // Enable the canvas if the cursor is visible, otherwise disable it
        canvas.enabled = Cursor.visible;
    }

    public void ModelChanger(int activeIndex)
    {
        foreach (Transform gameObjectTransform in gameObjectSelector.selectedFurniture.allFurnitureModels)
        {
            gameObjectTransform.gameObject.SetActive(false);
        }
        gameObjectSelector.selectedFurniture.allFurnitureModels[activeIndex].gameObject.SetActive(true);
    }
    public void incrementIndex()
    {
        if(gameObjectSelector.selectedFurniture == null || gameObjectSelector.selectedFurniture.allFurnitureModels.Length == 0)
        {
            return;
        }
        currentIndex++;
        if (currentIndex >= gameObjectSelector.selectedFurniture.allFurnitureModels.Length)
        {
            currentIndex = 0;
        }
        ModelChanger(currentIndex);
    }
    public void decrementIndex()
    {
        if(gameObjectSelector.selectedFurniture == null || gameObjectSelector.selectedFurniture.allFurnitureModels.Length == 0)
        {
            return;
        }
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = gameObjectSelector.selectedFurniture.allFurnitureModels.Length - 1;
        }
        ModelChanger(currentIndex);
    }
}