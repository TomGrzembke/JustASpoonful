using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerManager : MonoBehaviour
    {
        [SerializeField] Sprite drawerOpen;
        [SerializeField] Sprite drawerClosed;
        [SerializeField] SpriteRenderer drawerSprite;
        [SerializeField] Collider2D drawerCollider;
        [SerializeField] Transform drawerTrans;
        [SerializeField] GameObject drawerHitbox;
        [SerializeField] float dragWidth = 5;
        [SerializeField] float moveTime;

        Vector3 lastDragPos;
        Vector3 initialPos;
        Vector3 rightPosition;
        Coroutine dragRoutine;

        void Start()
        {
            initialPos = drawerTrans.position;
            rightPosition = initialPos.ChangeAxis(Axis.X, initialPos.x + dragWidth);
        }

        public void OnClick()
        {
            drawerSprite.sprite = drawerHitbox.activeSelf ? drawerClosed : drawerOpen;

            drawerHitbox.SetActive(!drawerHitbox.activeSelf);
            drawerCollider.enabled = !drawerHitbox.activeSelf;

            lastDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        public void OnDrag()
        {
            Vector3 newDragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            bool toRight = lastDragPos.x - newDragPos.x < 0;

            if (dragRoutine != null)
                StopCoroutine(dragRoutine);
            dragRoutine = StartCoroutine(LerpToTarget(toRight));
        }
        public void DragFully()
        {
            if (dragRoutine != null)
                StopCoroutine(dragRoutine);
            dragRoutine = StartCoroutine(LerpToTarget(true));
        }

        IEnumerator LerpToTarget(bool toRight)
        {
            float timeSpent = 0;
            Vector3 drawerPos = drawerTrans.position;

            while (timeSpent < moveTime)
            {
                timeSpent += Time.deltaTime;
                drawerTrans.position = Vector3.Lerp(drawerPos, toRight ? rightPosition : initialPos, timeSpent / moveTime);
                yield return null;
            }
        }

        public void DestroyObj(GameObject objToDestroy)
        {
            Destroy(objToDestroy);
        }
    }
}
