using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerSafety : MonoBehaviour
    {
        [SerializeField] Transform returnPoint;
        [SerializeField] float returnSpeed = 25;

        [SerializeField] Dictionary<GameObject, Coroutine> returnList = new();

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Movable"))
            {
                if (!returnList.ContainsKey(col.gameObject))
                {
                    Coroutine dragRoutine = StartCoroutine(ReturnToPos(col.gameObject));
                    returnList.Add(col.gameObject, dragRoutine);
                }
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Movable"))
            {
                if (returnList.TryGetValue(col.gameObject, out Coroutine outRountine))
                    StopCoroutine(outRountine);

                returnList.Remove(col.gameObject);
            }
        }

        IEnumerator ReturnToPos(GameObject returnObj)
        {
            Movable currentMovable = returnObj.GetComponent<Movable>();
            float lerpProgress = 0;
            yield return new WaitUntil(() => !currentMovable.isBeingDragged);

            Vector3 currentPos = returnObj.transform.position;
            //Move Obj back logic
            while (returnObj.transform.position.magnitude != returnPoint.position.magnitude)
            {
                if (currentMovable.isBeingDragged)
                    yield break;
                lerpProgress += Time.deltaTime / returnSpeed;
                returnObj.transform.position = Vector3.Lerp(currentPos, returnPoint.position, lerpProgress);
                yield return null;
            }

            returnList.Remove(returnObj);
        }
    }
}
