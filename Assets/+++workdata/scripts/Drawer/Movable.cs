using UnityEngine;

namespace JustASpoonful
{
    public enum ObjID
    {
        Blocker,
        Seal,
        Garbage,
        Spoons
    }

    public class Movable : MonoBehaviour
    {
        #region Cashed Vars
        GameControl gameControl;
        Vector2 cursorPos;
        Camera mainCam;
        Vector3 newObjPos;
        #endregion

        [SerializeField] ObjID objID;
 
        void Awake()
        {
            mainCam = Camera.main;
            gameControl = new();
            gameControl.GameController.Look.performed += ctx => SetCursorPos(ctx.ReadValue<Vector2>());
        }

        void SetCursorPos(Vector2 pos)
        {
            cursorPos = pos;
        }

        public void MoveAlongCursor()
        {
            newObjPos = mainCam.ScreenToWorldPoint(cursorPos);
            newObjPos = new(newObjPos.x, newObjPos.y, 0);
            transform.position = newObjPos;
        }

        public ObjID GetObjID()
        {
            return objID;
        }

        #region OnEnable/Disable
        void OnEnable()
        {
            gameControl.Enable();
        }
        void OnDisable()
        {
            gameControl.Disable();
        }
        #endregion
    }
}
