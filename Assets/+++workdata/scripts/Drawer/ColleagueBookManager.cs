using JustASpoonful;
using UnityEngine;

public class ColleagueBookManager : MonoBehaviour
{
    [SerializeField] Interactable interactable;
    [SerializeField] DrawerSpace drawerSpace;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnClick()
    {
        if (drawerSpace.GetSolved())
        {
            interactable.OnInteract();
        }

        anim.SetBool("isFree", drawerSpace.GetSolved());
        anim.SetTrigger("toggle");
    }
}
