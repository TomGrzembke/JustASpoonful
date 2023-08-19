using UnityEngine;
using UnityEngine.SceneManagement;

public class InputControl : MonoBehaviour
{
    #region Access
    public GameControl inputActions;
    EventTriggerBehavior triggerBehavior;
    #endregion

    #region stats
    public Vector2 lookDir;
    public Camera cam;
    #endregion

    #region OnEnable - disable
    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    #endregion

    private void Awake()
    {
        triggerBehavior = GetComponent<EventTriggerBehavior>();

        inputActions = new GameControl();

        inputActions.GameController.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
        inputActions.GameController.Menu.performed += ctx => Escape();

        inputActions.GameController.MoveRight.performed += ctx => MoveCamRight();
        inputActions.GameController.MoveLeft.performed += ctx => MoveCamLeft();
        //inputActions.TankActionMap.Escape.canceled += ctx => Escape();
    }


    void Look(Vector3 direction)
    {

        lookDir = cam.ScreenToWorldPoint(direction);
    }

    void Escape()
    {
        triggerBehavior.MobileToggle("menu");
    }

    void MoveCamRight()
    {
        if (triggerBehavior.closetDrawOpen == false && triggerBehavior.isInPicture == false)
        {
            triggerBehavior.ChangeCamPos("right");
        }
    }
    void MoveCamLeft()
    {
        if (triggerBehavior.closetDrawOpen == false && triggerBehavior.isInPicture == false)
        {
            triggerBehavior.ChangeCamPos("left");
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
