using UnityEngine;

public class SceneController : MonoBehaviour
{
    #region Access
    public GameObject spoonOne;
    public GameObject spoonTwo;
    public GameObject spoonThree;
    public GameObject spoonFour;
    public GameObject bedOne;

    public GameObject komode;
    public GameObject bg;
    public Camera cam;
    public GameObject mobileDown, mobileUp;


    public Vector3 defaultPos;
    public Vector3 leftPos;
    public Vector3 rightPos;
    #endregion

    #region stats

    public int camSettingInt;
    #endregion

    private void Start()
    {

    }
    public void SpoonOne()
    {
        Destroy(spoonOne);
        //kommode.right = new Vector3(121.6f,0,0);

        //= new Vector3(-64.6f, 0, 0);

    }
    public void SpoonTwo()
    {
        Destroy(spoonTwo);

    }
    public void SpoonThree()
    {

    }
    public void SpoonFour()
    {

    }

    public void KommodeMove()
    {
        komode.transform.localPosition = new Vector3(-2, -2.5f, -50.89381f);


    }

    #region MobileUI
    public void MobileUp()
    {
        mobileUp.SetActive(true);
        mobileDown.SetActive(false);
    }

    public void MobileDown()
    {
        mobileDown.SetActive(true);
        mobileUp.SetActive(false);
    }
    #endregion

    #region bg Movement-Methods
    public void SetScreen(int camSetting)
    {
        camSettingInt += camSetting;

        if (camSettingInt > 1)
        {
            camSettingInt = 1;
        }

        if (camSettingInt < -1)
        {
            camSettingInt = -1;
        }

        if (camSettingInt == 0)
        {
            MainDefault();
        }
        else if (camSettingInt == -1)
        {
            MainLeft();
        }
        else if (camSettingInt == 1)
        {
            MainRight();
        }

    }

    void MainLeft()
    {
        bg.transform.localPosition = leftPos;
    }

    void MainDefault()
    {
        bg.transform.localPosition = defaultPos;
    }

    void MainRight()
    {
        bg.transform.localPosition = rightPos;
    }
    #endregion
}
