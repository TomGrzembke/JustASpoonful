using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerSpace : MonoBehaviour
    {
        [SerializeField] DrawerSpaceManager drawerSpaceManager;
        [SerializeField] ObjID objIDNeeded;
        [SerializeField] List<Movable> objOnSpace;
        [SerializeField] bool solved;

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
            if (objIDNeeded == ObjID.Nothing && objOnSpace.Count == 0)
            {
                solved = true;
                return;
            }
            else if (objIDNeeded == ObjID.Nothing)
                return;

            for (int i = 0; i < objOnSpace.Count; i++)
            {
                if (objIDNeeded == objOnSpace[i].GetObjID())
                    solved = true;
                else
                {
                    solved = false;
                    break;
                }
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
