using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;
    public GameObject pauseMenu;
    public GameObject scoreUI;
    public StarterAssetsInputs inputs;
    
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                _isPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                inputs.cursorInputForLook = true;
                inputs.cursorLocked = false;
                if (!scoreUI.Equals(null))
                {
                    scoreUI.SetActive(true);
                }
            }
            else
            {
                pauseMenu.SetActive(true);
                if (!scoreUI.Equals(null))
                {
                    scoreUI.SetActive(false);
                }
                inputs.cursorInputForLook = false;
                inputs.cursorLocked = true;
                inputs.LookInput(Vector2.zero);
                Time.timeScale = 0f;
                _isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }
    }
}
