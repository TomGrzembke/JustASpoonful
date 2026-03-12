using UnityEngine;

public enum ObjID
{
    Nothing = 0,
    Blocker = 10,
    Seal = 20,
    Garbage = 30,
    Spoons = 40,
}

/// <summary> Moves Objects, acts as a Drag n Drop </summary>
public class Movable : MonoBehaviour
{
    GameControl gameControl;
    Vector2 cursorPos;
    Camera mainCam;
    Vector3 newObjPos;
    Collider2D col;
    SpriteRenderer sr;
    int originalOrderInLayer;
    Vector3 lastDragPos;
    Vector3 secondLastDragPos;
    bool isSolved;

    [SerializeField] ObjID objID;

    /// <summary> -1 means ignore here </summary>
    [SerializeField] int newOrderInLayer = -1;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float throwStrength = 40;
    public bool isBeingDragged { get; private set; }

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalOrderInLayer = sr.sortingOrder;
        col = GetComponent<Collider2D>();
        
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
        if (isSolved) return;

        SetIsBeingDragged(true);

        if (mainCam == null)
        {
            mainCam = Camera.main;
        }

        newObjPos = (Vector2)mainCam.ScreenToWorldPoint(cursorPos);
        transform.position = newObjPos;

        secondLastDragPos = lastDragPos;
        lastDragPos = transform.position;
    }

    public ObjID GetObjID()
    {
        return objID;
    }

    public void SetIsBeingDragged(bool condition)
    {
        var currentOrderInLayer = newOrderInLayer == -1 ? originalOrderInLayer : newOrderInLayer;
        sr.sortingOrder = condition ? originalOrderInLayer + 100 : currentOrderInLayer;
        isBeingDragged = condition;
        col.enabled = !condition;

        TryAddForce();
    }

    void TryAddForce()
    {
        if (rb == null) return;

        rb.AddForce((lastDragPos - secondLastDragPos) * throwStrength);
    }

    public void SetIsSolved(bool condition)
    {
        isSolved = true;
    }

    void OnEnable()
    {
        gameControl.Enable();
    }

    void OnDisable()
    {
        gameControl.Disable();
    }
}