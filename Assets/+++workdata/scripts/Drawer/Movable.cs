using UnityEngine;

namespace JustASpoonful
{
    public enum ObjID
    {
        Nothing,
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
        Collider2D thisCollider2D;
        SpriteRenderer sr;
        int originalOrderInLayer;
        #endregion

        [SerializeField] ObjID objID;
        public bool isBeingDragged { get; private set; }

        void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            originalOrderInLayer = sr.sortingOrder;
            thisCollider2D = GetComponent<Collider2D>();
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
            SetIsBeingDragged(true);
            if (!mainCam)
                mainCam = Camera.main;
            newObjPos = mainCam.ScreenToWorldPoint(cursorPos);
            newObjPos = new(newObjPos.x, newObjPos.y, 0);
            transform.position = newObjPos;
        }

        public ObjID GetObjID()
        {
            return objID;
        }

        public void SetIsBeingDragged(bool condition)
        {
            sr.sortingOrder = condition ? originalOrderInLayer + 100 : originalOrderInLayer;
            isBeingDragged = condition;
            thisCollider2D.enabled = !condition;
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
