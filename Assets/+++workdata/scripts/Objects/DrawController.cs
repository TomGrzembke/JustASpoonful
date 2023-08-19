using UnityEngine;

public class DrawController : MonoBehaviour
{
    public void DrawDeactive()
    {
        gameObject.SetActive(false);
    }

    public void Hint()
    {
        gameObject.GetComponent<Animator>().SetTrigger("hint");
    }
}
