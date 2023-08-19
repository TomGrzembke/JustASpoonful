using UnityEngine;

public class GlobeAnimcontroller : MonoBehaviour
{
    public void StopSpinning()
    {
        gameObject.GetComponent<Animator>().SetBool("isSpinning", false);
    }

}
