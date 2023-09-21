using UnityEngine;
using UnityEngine.Events;

namespace JustASpoonful
{
    public class DrawerSpaceManager : MonoBehaviour
    {
        [SerializeField] DrawerSpace[] drawerSpace;
        [SerializeField] bool solved;
        [SerializeField] UnityEvent OnSolved;

        public void CheckSolved()
        {
            for (int i = 0; i < drawerSpace.Length; i++)
            {
               if( drawerSpace[i].GetSolved())
                    solved = true;
                else
                {
                    solved = false;
                    break;
                }

            }

            if( solved)
            {
                OnSolved.Invoke();
            }
        }
    }
}
