using UnityEngine;

public class FPSCollector : MonoBehaviour
{
    private int count;
    
    // Set this in the Inspector to however many items you place in the level
    public int totalItemsToWin = 10; 
    
    // Drag your End-of-Level Canvas into this slot in the Inspector
    public GameObject winCanvas; 

    void Start()
    {
        count = 0;
        
        // Ensure the win screen is hidden when the game starts
        if (winCanvas != null)
        {
            winCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // I kept your original tag "Pick Up" (with the space) so it matches your old prefabs!
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); 
            count = count + 1;

            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        if (count >= totalItemsToWin)
        {
            // Turn on the canvas to show the stats when the level ends
            if (winCanvas != null)
            {
                winCanvas.SetActive(true);
            }
        }
    }
}