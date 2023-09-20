using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerSpace : MonoBehaviour
    {
        [SerializeField] ObjID objIDNeeded;
        [SerializeField] List<Movable> objOnSpace;
        [SerializeField] bool solved;

        void OnTriggerEnter2D(Collider2D col)
        {
            print("a");
            objOnSpace.Add(col.GetComponent<Movable>());
            CheckSolved();
        }

        void OnTriggerExit2D(Collider2D col)
        {
            objOnSpace.Remove(col.GetComponent<Movable>());
            CheckSolved();
        }

        void CheckSolved()
        {
            for (int i = 0; i < objOnSpace.Count; i++)
            {
                if(objIDNeeded == objOnSpace[i].GetObjID())
                    solved = true;
                else
                {
                    solved = false;
                    break;
                }
            }
        }
    }
}
