using JustASpoonful;
using MyBox;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    [SerializeField] PostProcessVolume processVolume;
    [SerializeField] MinMaxFloat temperatureRange;
    [SerializeField] MinMaxFloat saturationRange;
    ColorGrading colorGrading;
    [SerializeField] float neededRewardAmount;
    [SerializeField] float rewardAmount;

    void Awake()
    {
        Initialize();
    }

    void Start()
    {
        neededRewardAmount = GameStateManager.Instance.InteractInstigatorAmount;
    }

    void OnValidate()
    {
        Initialize();
    }

    void Initialize()
    {
        processVolume.profile.TryGetSettings(out colorGrading);
        temperatureRange.Min = colorGrading.temperature;
        saturationRange.Min = colorGrading.saturation;
    }

    [ButtonMethod]
    public void Reward()
    {
        rewardAmount++;
        float step = rewardAmount / neededRewardAmount;
        colorGrading.temperature.value = Mathf.Lerp(temperatureRange.Min, temperatureRange.Max, step);
        colorGrading.saturation.value = Mathf.Lerp(saturationRange.Min, saturationRange.Max, step);
    }
}
