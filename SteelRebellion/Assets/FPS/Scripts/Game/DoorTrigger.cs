using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject objectToActivate; // The GameObject you want to activate
    public string playerTag = "Player";  // Tag to identify the player

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            ActivateObject();
        }
    }

    // Activate the GameObject
    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);  // Set the object to active
        }
    }
}
