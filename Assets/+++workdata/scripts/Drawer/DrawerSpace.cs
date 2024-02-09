using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JustASpoonful
{
    public class DrawerSpace : MonoBehaviour
    {
        [SerializeField] DrawerSpaceManager drawerSpaceManager;
        [SerializeField] ObjID objIDNeeded;
        [SerializeField] List<Movable> objOnSpace;
        [SerializeField] bool solved;
        [SerializeField] UnityEvent onUnsolved;
        [SerializeField] UnityEvent onSolved;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Movable movable))
            {
                objOnSpace.Add(movable);
                CheckSolved();
            }
        }

        void OnTriggerExit2D(Collider2D col)
        {
            if (objOnSpace.Remove(col.GetComponent<Movable>()))
                CheckSolved();
        }

        void CheckSolved()
        {
            if (objIDNeeded == ObjID.Nothing)
                if (objOnSpace.Count != 0)
                    return;
                else
                {
                    solved = true;
                    onSolved?.Invoke();
                    return;
                }

            for (int i = 0; i < objOnSpace.Count; i++)
            {
                if (objIDNeeded == objOnSpace[i].GetObjID())
                {
                    solved = true;
                    onSolved?.Invoke();
                }
                else
                {
                    solved = false;
                    onUnsolved?.Invoke();
                    break;
                }
            }

            if (solved && objIDNeeded != ObjID.Nothing)
                if (objOnSpace.Count < 1)
                {
                    solved = false;
                    onUnsolved?.Invoke();
                }

            if (drawerSpaceManager)
                drawerSpaceManager.CheckSolved();
        }

        public bool GetSolved()
        {
            return solved;
        }
    }
}
