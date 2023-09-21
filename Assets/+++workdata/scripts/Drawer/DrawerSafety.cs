using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerSafety : MonoBehaviour
    {
        [SerializeField] Transform returnPoint;
        [SerializeField] float returnSpeed = 25;
        GameObject returnObj;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Movable"))
            {
                returnObj = col.gameObject;
                StartCoroutine(ReturnToPos());
            }
        }

        IEnumerator ReturnToPos()
        {
            Movable currentMovable = returnObj.GetComponent<Movable>();
            float lerpProgress = 0;
            yield return new WaitUntil(() => !currentMovable.isBeingDragged);

            //Move Obj back logic
            while (returnObj.transform.position.magnitude != returnPoint.position.magnitude)
            {
                if (currentMovable.isBeingDragged)
                    yield break;
                lerpProgress += Time.deltaTime / returnSpeed;
                returnObj.transform.position = Vector3.Lerp(returnObj.transform.position, returnPoint.position, lerpProgress);
                yield return null;
            }
        }
    }
}
