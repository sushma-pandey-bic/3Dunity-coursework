using UnityEngine;
using TMPro;

public class InfoObject : MonoBehaviour
{
    public GameObject tajmahalInfo; // drag HintText here in Inspector

    private bool playerIsNear = false;

    void Update()
    {
        // Show the text only when player is nearby
        if (tajmahalInfo != null)
        {
            tajmahalInfo.SetActive(playerIsNear);
        }
    }

    // Player enters the trigger zone → show text
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    // Player leaves the trigger zone → hide text
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}