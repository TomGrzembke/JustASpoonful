using UnityEngine;

public class SoundSave : MonoBehaviour
{
    #region stats 
    public float volume;
    #endregion

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        //currentVolume = GameObject.Find("MenuManager").GetComponent<MenuController>().currentVolume;
        //soundSlider.GetComponentInChildren<Slider>().value = currentVolume;
    }
}
