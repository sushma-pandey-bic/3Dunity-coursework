using UnityEngine;
using UnityEngine.InputSystem;

public class GateWelcome : MonoBehaviour
{
    public GameObject welcomeCanvas;
    public Transform player;
    public float triggerDistance = 20f;

    private bool playerInside = false;
    private bool hasStarted = false;

    void Update()
    {
        if (hasStarted) return;

        float distance = Vector3.Distance(transform.position, player.position);

        Debug.Log("Distance to gate: " + distance);

        if (distance < triggerDistance)
        {
            if (!playerInside)
            {
                playerInside = true;
                Debug.Log("Player entered gate zone.");
                if (welcomeCanvas != null)
                    welcomeCanvas.SetActive(true);
                else
                    Debug.Log("welcomeCanvas is empty, not assigned");
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("E pressed!!!");
                StartExperience();
            }
        }
        else
        {
            playerInside = false;
        }
    }

    void StartExperience()
    {
        hasStarted = true;
        if (welcomeCanvas != null)
            welcomeCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}