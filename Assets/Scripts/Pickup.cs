using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            FindFirstObjectByType<ScoreUI>().IncreaseScore(); 
            Destroy(gameObject);
        }
    }
}
