using UnityEngine;

public class ForcePortrait : MonoBehaviour
{
    void Awake()
    {
#if UNITY_ANDROID
        Screen.SetResolution(1080,1920, true);
#endif
        
    }
}
