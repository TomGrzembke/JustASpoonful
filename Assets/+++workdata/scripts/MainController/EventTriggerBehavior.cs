using Cinemachine;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventTriggerBehavior : MonoBehaviour
{
    #region stats
    public float currentVolume;
    public bool mainDoorBlocked, isInPicture;
    public bool wateringCanBool, puzzlePieceBool, fishFoodBool, closetDrawOpen, kasetteBool, teaBool;
    public bool collegeBookFreeBool;
    public bool bagOnGround, lighterUIOn;
    public bool puzzleSolvedBool, wateringSolvedBool, aquariumSolvedBool, sealSolvedBool, cakeSolvedBool, guitarSolvedBool, teaSolvedBool, radioSolvedBool, giftSolvedBool;
    public bool bookSolvedBool;
    public bool mobileActive;
    bool guitarMusic = true;
    bool stopMusic, teaBoxOpen, teaStarsBool = true;
    bool flashLightOn, CDOpenBool;
    public int collegeBookFreeInt, posCounterSchrank, camCounter;
    int sealumPetCounter = 0;
    int volumeStorageCounter;
    public Vector3 lookDir;
    public Vector3 drawMiddleVec;
    public Vector3 objSafeSpotVec;
    public Vector3 camRoomLeft;
    public Vector3 camRoomMiddle;
    public Vector3 camRoomRight;
    public Vector3 camPicture;
    public Vector3 flowerStance2;
    public Vector3 closetRight, closetLeft, closetMiddle;
    public Vector3 mobileUPVec, mobileDownVec;
    public GameObject focusObj;
    public string teaColor;
    #endregion

    #region Access
    public AudioMixer audioMixer;
    public CinemachineVirtualCamera cam;
    public GameObject lastOpened;
    InputControl inputControl;
    MainAudioController mainAudioController;
    public GameObject cmCam;
    public GameObject camTarget;
    public GameObject schrank;
    public GameObject schrankUI_right, schrankUI_left;
    public GameObject arrowUiRight, arrowUiLeft;
    public GameObject mobile, homeMobile, messageSelect, anonMessages, momMessages, crisisMessages, coachMessages, settings, galerySelect, spoonRecap, galery;
    public GameObject wateringCan, plant, wateringCanUI;
    public GameObject puzzlePiece, puzzlePieceUI, completionPiece, puzzle;
    public GameObject sealum;
    public GameObject aquarium;
    public GameObject fishFood, fishFoodUI;
    public GameObject draw, stars, teaStars, starsFishfood, starsAquarium;
    public GameObject collegeBook;
    public GameObject lighter, cake, bag, lighterUI, bagInRoom;
    public GameObject TeaBox, TeaboxHitboxes;
    public GameObject kasette, kasetteUI;
    public GameObject aquariumActiveIcon;
    public GameObject filter, endButton, endTransition;
    public GameObject soundSlider;
    public GameObject[] TeaUI;
    public GameObject[] objectFoundActive;
    public GameObject[] spoons;
    public GameObject[] spoonsActive;

    private void Awake()
    {

        inputControl = GetComponent<InputControl>();
        mainAudioController = GetComponent<MainAudioController>();


        for (int i = 0; i < Object.FindObjectsOfType<MenuController>().Length; i++)
        {
            Object.FindObjectsOfType<MenuController>()[i].Destroy();
        }
    }

    private void Start()
    {
        currentVolume = GameObject.Find("MenuManager").GetComponent<MenuController>().currentVolume;
        soundSlider.GetComponentInChildren<Slider>().value = currentVolume;
        SetVolume(currentVolume);
    }
    #endregion

    #region CamPos

    void Look(Vector3 direction)
    {

        lookDir = cmCam.GetComponent<Camera>().ScreenToWorldPoint(direction);

    }
    public void ChangeCamPos(string direction)
    {
        if (direction == "right")
        {
            camCounter++;

            if (camCounter >= 1)
            {
                arrowUiLeft.SetActive(true);
                arrowUiRight.SetActive(false);
                camCounter = 1;
                camTarget.transform.position = camRoomRight;
            }
            else if (camCounter == 0)
            {
                camTarget.transform.position = camRoomMiddle;
                arrowUiLeft.SetActive(true);
                arrowUiRight.SetActive(true);
            }

        }
        else if (direction == "left")
        {
            camCounter--;

            if (camCounter <= -1)
            {
                camCounter = -1;
                camTarget.transform.position = camRoomLeft;
                arrowUiLeft.SetActive(false);
                arrowUiRight.SetActive(true);
            }
            else if (camCounter == 0)
            {
                camTarget.transform.position = camRoomMiddle;
                arrowUiLeft.SetActive(true);
                arrowUiRight.SetActive(true);
            }
        }

    }

    #region FilterControl
    void FilterBrightens()
    {
        filter.GetComponent<Animator>().SetTrigger("isSolved");
    }

    #endregion

    #endregion

    #region Endgame
    public void EndgameCheck()
    {
        if (puzzleSolvedBool && wateringSolvedBool && aquariumSolvedBool && sealSolvedBool && cakeSolvedBool && guitarSolvedBool && teaSolvedBool && radioSolvedBool && giftSolvedBool && bookSolvedBool)
        {
            endButton.SetActive(true);
        }
    }
    public void Endgame1()
    {
        endTransition.SetActive(true);
        Invoke("Endgame2", 2f);
        endButton.SetActive(false);
    }
    void Endgame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion

    #region Mobile
    public void MobileToggle(string activate)
    {
        if (mobileActive == false)
        {
            mobile.SetActive(true);
            mobileActive = true;

            if (activate == "home")
            {
                lastOpened.SetActive(true);
                settings.SetActive(false);
            }

            if (activate == "menu")
            {
                homeMobile.SetActive(false);
                settings.SetActive(true);
            }
        }
        else if (mobileActive == true)
        {
            if (activate == "menu" && homeMobile.activeInHierarchy)
            {
                homeMobile.SetActive(false);
                settings.SetActive(true);
                mobileActive = true;
            }
            else if (activate == "menu" && (messageSelect.activeInHierarchy || coachMessages.activeInHierarchy || momMessages.activeInHierarchy || crisisMessages.activeInHierarchy || anonMessages.activeInHierarchy || spoonRecap.activeInHierarchy || galerySelect.activeInHierarchy))
            {
                messageSelect.SetActive(false);
                anonMessages.SetActive(false);
                coachMessages.SetActive(false);
                momMessages.SetActive(false);
                crisisMessages.SetActive(false);
                galerySelect.SetActive(false);
                spoonRecap.SetActive(false);
                settings.SetActive(true);
                mobileActive = true;
            }
            else if (activate != "menu" && (coachMessages.activeInHierarchy || momMessages.activeInHierarchy || crisisMessages.activeInHierarchy || anonMessages.activeInHierarchy || spoonRecap.activeInHierarchy || galerySelect.activeInHierarchy))
            {
                mobile.SetActive(false);
                messageSelect.SetActive(false);
                anonMessages.SetActive(false);
                coachMessages.SetActive(false);
                momMessages.SetActive(false);
                crisisMessages.SetActive(false);
                settings.SetActive(false);
                galerySelect.SetActive(false);
                spoonRecap.SetActive(false);
                mobileActive = false;
            }
            else
            {
                mobile.SetActive(false);
                mobileActive = false;
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        GameObject.Find("SoundSaveMain").GetComponent<SoundSave>().volume = volume;
    }

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ToHomeMobile()
    {
        homeMobile.SetActive(true);
        messageSelect.SetActive(false);
        anonMessages.SetActive(false);
        momMessages.SetActive(false);
        crisisMessages.SetActive(false);
        coachMessages.SetActive(false);
        settings.SetActive(false);
        galerySelect.SetActive(false);
        spoonRecap.SetActive(false);
        galery.SetActive(false);

        lastOpened = homeMobile;
    }

    public void ToGalerySelect()
    {
        galerySelect.SetActive(true);
        spoonRecap.SetActive(false);
        homeMobile.SetActive(false);
        galery.SetActive(false);

        lastOpened = galerySelect;
    }

    public void ToSpoonRecap()
    {
        spoonRecap.SetActive(true);
        galerySelect.SetActive(false);

        lastOpened = spoonRecap;
    }

    public void ToGalery()
    {
        galerySelect.SetActive(false);
        galery.SetActive(true);

        lastOpened = galery;
    }

    public void ToMessageSelect()
    {
        messageSelect.SetActive(true);
        homeMobile.SetActive(false);
        anonMessages.SetActive(false);
        momMessages.SetActive(false);
        crisisMessages.SetActive(false);
        coachMessages.SetActive(false);
        settings.SetActive(false);

        lastOpened = messageSelect;
    }


    public void ToAnonMessages()
    {
        messageSelect.SetActive(false);
        anonMessages.SetActive(true);
    }

    public void ToMomMessages()
    {
        messageSelect.SetActive(false);
        momMessages.SetActive(true);
    }

    public void ToCrisisMessages()
    {
        messageSelect.SetActive(false);
        crisisMessages.SetActive(true);
    }

    public void ToCoachMessages()
    {
        messageSelect.SetActive(false);
        coachMessages.SetActive(true);
    }

    #endregion

    #region IconHover
    public void IconHover(GameObject icon)
    {
        icon.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void IconHoverExit(GameObject icon)
    {
        icon.transform.GetChild(0).gameObject.SetActive(false);
    }
    #endregion

    #region Stars
    public void StarHover(GameObject star)
    {
        star.SetActive(true);
    }

    public void StarHoverEnd(GameObject star)
    {
        star.SetActive(false);
    }
    public void StarHoverPuzzle(GameObject star)
    {
        if (puzzlePieceBool)
        {
            star.SetActive(true);
        }
    }
    public void StarHoverPlant(GameObject star)
    {
        if (wateringCanBool)
        {
            star.SetActive(true);
        }
    }
    public void StarHoverCake(GameObject star)
    {
        if (lighterUI.activeInHierarchy)
        {
            star.SetActive(true);
        }
    }
    public void StarHoverAquarium(GameObject star)
    {
        if (fishFoodBool && !aquariumSolvedBool)
        {
            star.SetActive(true);
        }
    }
    public void StarHoverCDRecorder(GameObject star)
    {
        if (kasetteBool)
        {
            star.SetActive(true);
        }
    }

    public void StarHoverCup(GameObject star)
    {
        if (teaBool)
        {
            star.SetActive(true);
        }
    }
    #endregion

    #region Puzzle 
    //ID0
    public void PuzzlePickup()
    {
        puzzlePieceBool = true;
        puzzlePiece.SetActive(false);
        puzzlePieceUI.SetActive(true);

        DropFishFood();
        DropWateringCan();
        DropTeaUI();
        KasetteDrop();
    }
    public void PuzzleDrop()
    {
        if (puzzleSolvedBool == false)
        {
            puzzlePieceBool = false;
            puzzlePiece.SetActive(true);
            puzzlePieceUI.SetActive(false);
        }
        else if (puzzleSolvedBool == true)
        {
            puzzlePieceBool = false;
            puzzlePiece.SetActive(false);
            puzzlePieceUI.SetActive(false);
        }
    }
    public void PuzzleComplete()
    {
        if (puzzlePieceBool == true)
        {
            puzzleSolvedBool = true;
            puzzlePieceBool = false;
            puzzle.GetComponent<Animator>().SetTrigger("isCompleted");
            puzzlePieceUI.SetActive(false);
            StarHoverEnd(GameObject.Find("StarsPuzzle"));

            objectFoundActive[0].SetActive(true);
        }
    }

    public void SpoonPuzzle()
    {
        spoons[0].SetActive(true);
        spoonsActive[0].SetActive(true);
        FilterBrightens();
        EndgameCheck();
    }
    #endregion

    #region Schrank
    public void Schrank_UI_On()
    {
        if (posCounterSchrank == 0)
        {
            schrankUI_left.SetActive(false);
            schrankUI_right.SetActive(true);
        }
        else if (posCounterSchrank == -1)
        {
            schrankUI_left.SetActive(false);
            schrankUI_right.SetActive(true);
        }
    }
    public void Schrank_UI_Off()
    {
        schrankUI_left.SetActive(false);
        schrankUI_right.SetActive(false);
    }

    public void ClosetOpen()
    {
        if (closetDrawOpen == false)
        {
            closetDrawOpen = true;
            schrank.GetComponent<Animator>().SetBool("closetOpen", true);
        }
        else if (closetDrawOpen == true)
        {
            closetDrawOpen = false;
            schrank.GetComponent<Animator>().SetBool("closetOpen", false);
        }
    }

    public void MoveCloset()
    {
        if (inputControl.lookDir.x < -6)
        {
            posCounterSchrank = 0;
            mainDoorBlocked = true;

            if (posCounterSchrank <= 0)
            {
                schrankUI_right.SetActive(true);
                schrankUI_left.SetActive(false);
                schrank.GetComponent<Animator>().SetFloat("closetStance", 0);
                //schrank.transform.localPosition = closetMiddle;
            }

        }
        else if (inputControl.lookDir.x > -6)
        {

            posCounterSchrank++;
            mainDoorBlocked = true;
            if (posCounterSchrank == 0)
            {
                schrank.GetComponent<Animator>().SetFloat("closetStance", 0);
                schrankUI_right.SetActive(true);
                schrankUI_left.SetActive(false);
                //schrank.transform.localPosition = closetMiddle;
            }
            else if (posCounterSchrank >= 1)
            {
                schrank.GetComponent<Animator>().SetFloat("closetStance", -1);
                posCounterSchrank = 1;
                schrankUI_right.SetActive(false);
                //schrank.transform.localPosition = closetRight;
            }

        }
    }
    #region Globus
    public void GlobusSpin(GameObject globus)
    {
        globus.GetComponent<Animator>().SetBool("isSpinning", true);
    }
    #endregion

    #region Sprite
    public void Sprite_Highlighted(GameObject newSprite)
    {
        focusObj = newSprite;
        Debug.Log(newSprite.name);
        newSprite.GetComponent<Animator>().SetBool("Highlighted", true);
        //ObjectInformation objectInformation = focusObj.GetComponent<ObjectInformation>();
    }

    public void Sprite_PointerExit(GameObject newSprite)
    {
        newSprite.GetComponent<Animator>().SetBool("Highlighted", false);
        focusObj = null;
    }

    public void Sprite_OnClick(GameObject newSprite)
    {
        #region SchrankPos
        focusObj = newSprite;
        if (focusObj.name == "UI_right")
        {

            posCounterSchrank++;
            mainDoorBlocked = true;
            if (posCounterSchrank == 0)
            {
                schrank.GetComponent<Animator>().SetFloat("closetStance", 0);
                schrankUI_right.SetActive(true);
                schrankUI_left.SetActive(false);
                //schrank.transform.localPosition = closetMiddle;
            }
            else if (posCounterSchrank >= 1)
            {
                schrank.GetComponent<Animator>().SetFloat("closetStance", -1);
                posCounterSchrank = 1;
                schrankUI_right.SetActive(false);
                //schrank.transform.localPosition = closetRight;
            }

        }

        if (focusObj.name == "UI_left")
        {
            posCounterSchrank--;
            mainDoorBlocked = true;

            if (posCounterSchrank == 0)
            {
                schrankUI_right.SetActive(true);
                schrankUI_left.SetActive(false);
                schrank.GetComponent<Animator>().SetFloat("closetStance", 0);
                //schrank.transform.localPosition = closetMiddle;
            }
            /*else if (posCounterSchrank == -1)
            {
                posCounterSchrank = -1;
                schrankUI_left.SetActive(false);
                schrank.GetComponent<Animator>().SetFloat("closetStance", 1);
                //schrank.transform.localPosition = closetLeft;
            }*/
        }
        #endregion
    }
    #endregion
    #endregion

    #region Plant 
    //ID1
    public void Grow()
    {
        if (wateringCanBool == true)
        {
            wateringSolvedBool = true;
            plant.GetComponent<Animator>().SetBool("isGrown", true);
            wateringCan.GetComponent<PolygonCollider2D>().enabled = false;
            StarHoverEnd(GameObject.Find("StarsPlant"));

            wateringCanUI.SetActive(false);
            Invoke("ResetWateringCan", 1f);

            objectFoundActive[1].SetActive(true);
        }
    }

    public void ResetWateringCan()
    {
        wateringCan.SetActive(true);
        wateringCanUI.SetActive(false);
        wateringCanBool = (false);

        if (wateringSolvedBool == true)
        {
            wateringCan.transform.localPosition = flowerStance2;
            wateringCan.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SpoonPlant()
    {
        spoons[1].SetActive(true);
        spoonsActive[1].SetActive(true);
        FilterBrightens();
        EndgameCheck();
    }
    #endregion

    #region Watering Can
    public void PickupWateringCan()
    {
        wateringCanBool = true;
        wateringCanUI.SetActive(true);
        wateringCan.SetActive(false);

        DropFishFood();
        PuzzleDrop();
        DropTeaUI();
        KasetteDrop();
    }
    public void DropWateringCan()
    {
        if (wateringCanBool == true)
        {
            wateringCan.SetActive(true);
            wateringCanBool = false;
            wateringCanUI.SetActive(false);
            StarHoverEnd(GameObject.Find("StarsWatering"));
        }
    }

    #endregion

    #region sealum 
    //ID2
    public void SealumClick()
    {
        if (sealumPetCounter == 0)
        {
            sealum.GetComponent<Animator>().SetBool("isPetted1", true);
            sealumPetCounter++;
            StarHoverEnd(GameObject.Find("StarHeatSeal"));
        }
        else if (sealumPetCounter == 1)
        {
            sealum.GetComponent<Animator>().SetBool("isPetted2", true);
            sealumPetCounter++;
            StarHoverEnd(GameObject.Find("StarHeatSeal"));
            sealSolvedBool = true;
            EndgameCheck();

            objectFoundActive[2].SetActive(true);
        }
        else if (sealumPetCounter >= 2)
        {
            sealum.GetComponent<Animator>().SetTrigger("freePet");
            StarHoverEnd(GameObject.Find("StarHeatSeal"));
            objectFoundActive[2].SetActive(true);
            EndgameCheck();
        }
    }

    public void Seal2Click(GameObject seal2)
    {
        seal2.GetComponent<Animator>().SetTrigger("isClicked");
    }
    public void SpoonSeal()
    {
        spoons[2].SetActive(true);
        spoonsActive[2].SetActive(true);
        objectFoundActive[2].SetActive(true);
        sealSolvedBool = true;
        FilterBrightens();
        EndgameCheck();
    }
    #endregion

    #region Picture 
    //ID3, ID9
    public void PictureClicked()
    {
        cmCam.GetComponent<Animator>().SetBool("isZoomed", true);
        isInPicture = true;
        arrowUiLeft.SetActive(false);
        arrowUiRight.SetActive(false);
        DropFishFood();
        DropWateringCan();
        PuzzleDrop();
        DropTeaUI();
        KasetteDrop();
    }

    public void BackFromPicture()
    {
        cmCam.GetComponent<Animator>().SetBool("isZoomed", false);
        arrowUiLeft.SetActive(true);
        isInPicture = false;
        arrowUiRight.SetActive(true);

        DropLighter();
    }

    public void PickupLighter()
    {
        lighter.SetActive(false);
        lighterUI.SetActive(true);
        lighterUIOn = true;
    }

    public void DropLighter()
    {
        lighter.SetActive(true);
        lighterUI.SetActive(false);
        lighterUIOn = false;
        StarHoverEnd(GameObject.Find("StarsLighter"));
    }

    public void Bag()
    {
        bag.GetComponent<Animator>().SetTrigger("bagOnGround");
        bagOnGround = true;
        bagInRoom.SetActive(true);
    }

    public void BagClicked()
    {
        spoons[9].SetActive(true);
        spoonsActive[9].SetActive(true);
        objectFoundActive[9].SetActive(true);
        giftSolvedBool = true;
        EndgameCheck();
        bagInRoom.GetComponent<Animator>().SetTrigger("stopIdle");
        FilterBrightens();
    }

    public void CakeCheck()
    {
        if (lighterUIOn)
        {
            cake.GetComponent<Animator>().SetTrigger("isLit");
            DropLighter();
            StarHoverEnd(GameObject.Find("StarsCake"));

            objectFoundActive[3].SetActive(true);
        }
    }

    public void SpoonCake()
    {
        spoons[3].SetActive(true);
        spoonsActive[3].SetActive(true);
        FilterBrightens();
        cakeSolvedBool = true;
        EndgameCheck();
    }
    #endregion

    #region FishFood, Aquarium 
    //ID4
    public void PickupFishFood()
    {
        fishFoodBool = true;
        fishFoodUI.SetActive(true);
        fishFood.SetActive(false);

        DropWateringCan();
        PuzzleDrop();
        DropTeaUI();
        KasetteDrop();
    }

    public void DropFishFood()
    {
        if (fishFoodBool == true)
        {
            fishFood.SetActive(true);
            fishFoodBool = false;
            fishFoodUI.SetActive(false);
            StarHoverEnd(GameObject.Find("StarsAquarium"));
            StarHoverEnd(GameObject.Find("StarsFishfood"));
        }
    }
    public void DropFishFoodAnim()
    {
        if (fishFoodBool == true)
        {

            fishFoodBool = false;
            fishFoodUI.SetActive(false);
            StarHoverEnd(GameObject.Find("StarsAquarium"));
            StarHoverEnd(GameObject.Find("StarsFishfood"));
        }
    }

    public void AquariumFed()
    {
        if (fishFoodBool && aquariumSolvedBool == false)
        {
            aquarium.GetComponent<Animator>().SetTrigger("isFed");
            aquariumSolvedBool = true;
            DropFishFoodAnim();

            objectFoundActive[4].SetActive(true);
            spoonsActive[4].SetActive(true);
        }
        else if (fishFoodBool && aquariumSolvedBool)
        {
            DropFishFood();
        }
    }

    public void SpoonAquarium()
    {
        spoons[4].SetActive(true);
        spoonsActive[4].SetActive(true);
        objectFoundActive[4].SetActive(true);
        StarHoverEnd(starsAquarium);
        StarHoverEnd(starsFishfood);
        FilterBrightens();
        EndgameCheck();
    }
    #endregion

    #region Guitar 
    //ID5
    public void GuitarClick()
    {
        if (guitarMusic)
        {
            guitarMusic = false;
            mainAudioController.ChangeToGuitar();
            spoons[5].SetActive(true);
            spoonsActive[5].SetActive(true);
            FilterBrightens();
            objectFoundActive[5].SetActive(true);
            StarHoverEnd(GameObject.Find("StarsGuitar"));
            guitarSolvedBool = true;
            EndgameCheck();
        }
        else if (!guitarMusic)
        {
            EndgameCheck();
            guitarMusic = true;
            mainAudioController.ChangeToDefault();
            StarHoverEnd(GameObject.Find("StarsGuitar"));
        }
    }

    #endregion

    #region Draw 
    public void StarsActive()
    {
        stars.SetActive(true);
    }
    public void StarsInactive()
    {
        stars.SetActive(false);
    }
    public void DrawOpen()
    {
        closetDrawOpen = true;
        draw.SetActive(true);
        draw.GetComponent<Animator>().SetBool("isDrawn", true);

        arrowUiLeft.SetActive(false);
        arrowUiRight.SetActive(false);
        mobile.SetActive(false);

        DropFishFood();
        DropWateringCan();
        PuzzleDrop();
        DropTeaUI();
    }
    public void DrawClose()
    {
        closetDrawOpen = false;
        draw.GetComponent<Animator>().SetBool("isDrawn", false);

        arrowUiLeft.SetActive(true);
        arrowUiRight.SetActive(true);
    }
    #endregion

    #region InDraw 
    //ID6
    public void MoveObject(GameObject movedObject)
    {
        movedObject.transform.position = inputControl.lookDir;
    }

    public void FlashLightToggle(GameObject flashLight)
    {
        if (flashLightOn == false)
        {
            flashLightOn = true;
            flashLight.GetComponent<Animator>().SetBool("isOn", true);
        }
        else if (flashLightOn == true)
        {
            flashLightOn = false;
            flashLight.GetComponent<Animator>().SetBool("isOn", false);
        }
    }

    public void SpoonBook()
    {
        spoons[6].SetActive(true);
        spoonsActive[6].SetActive(true);
        spoonsActive[10].SetActive(true);
        EndgameCheck();
        FilterBrightens();
    }
    #endregion

    #region Teabox 
    //ID7
    public void TeaboxClicked()
    {
        TeaBox.GetComponent<Animator>().SetTrigger("isOpened");
        teaBoxOpen = true;
        teaStars.SetActive(false);
    }

    public void TeaBagChosen(string col)
    {
        if (col == "blue")
        {
            TeaUI[0].SetActive(true);
            TeaUI[1].SetActive(false);
            TeaUI[2].SetActive(false);
            TeaUI[3].SetActive(false);
            TeaUI[4].SetActive(false);
            TeaUI[5].SetActive(false);

            teaColor = "blue";
        }
        else if (col == "occa")
        {
            TeaUI[0].SetActive(false);
            TeaUI[1].SetActive(true);
            TeaUI[2].SetActive(false);
            TeaUI[3].SetActive(false);
            TeaUI[4].SetActive(false);
            TeaUI[5].SetActive(false);

            teaColor = "occa";
        }
        else if (col == "green")
        {
            TeaUI[0].SetActive(false);
            TeaUI[1].SetActive(false);
            TeaUI[2].SetActive(true);
            TeaUI[3].SetActive(false);
            TeaUI[4].SetActive(false);
            TeaUI[5].SetActive(false);

            teaColor = "green";
        }
        else if (col == "red")
        {
            TeaUI[0].SetActive(false);
            TeaUI[1].SetActive(false);
            TeaUI[2].SetActive(false);
            TeaUI[3].SetActive(true);
            TeaUI[4].SetActive(false);
            TeaUI[5].SetActive(false);

            teaColor = "red";
        }
        else if (col == "pink")
        {
            TeaUI[0].SetActive(false);
            TeaUI[1].SetActive(false);
            TeaUI[2].SetActive(false);
            TeaUI[3].SetActive(false);
            TeaUI[4].SetActive(true);
            TeaUI[5].SetActive(false);

            teaColor = "pink";
        }
        else if (col == "lightGreen")
        {
            TeaUI[0].SetActive(false);
            TeaUI[1].SetActive(false);
            TeaUI[2].SetActive(false);
            TeaUI[3].SetActive(false);
            TeaUI[4].SetActive(false);
            TeaUI[5].SetActive(true);

            teaColor = "light green";
        }

        teaBool = true;
        DropFishFood();
        DropWateringCan();
        PuzzleDrop();
        KasetteDrop();
    }

    public void DropTeaUI()
    {
        TeaUI[0].SetActive(false);
        TeaUI[1].SetActive(false);
        TeaUI[2].SetActive(false);
        TeaUI[3].SetActive(false);
        TeaUI[4].SetActive(false);
        TeaUI[5].SetActive(false);
        teaBool = false;
        EndgameCheck();
    }

    public void TeaStarsToggle()
    {
        if (teaStarsBool && !teaBoxOpen)
        {
            teaStarsBool = false;
            teaStars.SetActive(true);
        }
        else if (!teaStarsBool && !teaBoxOpen)
        {
            teaStarsBool = true;
            teaStars.SetActive(false);
        }
    }

    public void TeaPot(GameObject teaPot)
    {
        if (teaBool)
        {
            teaPot.GetComponent<Animator>().SetTrigger(teaColor);

            teaBool = false;
            DropTeaUI();
            spoons[7].SetActive(true);
            spoonsActive[7].SetActive(true);
            objectFoundActive[7].SetActive(true);
            teaSolvedBool = true;
            FilterBrightens();
            EndgameCheck();
        }
    }
    #endregion

    #region Kasette
    public void KasettePickup()
    {
        kasetteBool = true;
        kasette.SetActive(false);
        kasetteUI.SetActive(true);


        DropFishFood();
        DropWateringCan();
        DropTeaUI();
        PuzzleDrop();
    }
    public void KasetteDrop()
    {
        kasetteBool = false;
        kasette.SetActive(true);
        kasetteUI.SetActive(false);
    }

    public void KasettePlay()
    {
        mainAudioController.ChangeToKasette();
        EndgameCheck();
    }
    public void SpoonRadio()
    {
        spoons[8].SetActive(true);
        spoonsActive[8].SetActive(true);
        FilterBrightens();
        radioSolvedBool = true;
        EndgameCheck();
    }
    #endregion

    #region CD_Recorder 
    //ID8
    public void CD_RecorderToggle(GameObject cD_Recorder)
    {
        if (kasetteBool == false)
        {

            if (stopMusic == false)
            {
                mainAudioController.stopMusic();
                stopMusic = true;
            }
            else if (stopMusic == true)
            {
                mainAudioController.unstopMusic();
                stopMusic = false;
            }

        }
        else if (CDOpenBool == false && kasetteBool)
        {
            CDOpenBool = true;
            cD_Recorder.GetComponent<Animator>().SetBool("isOpen", true);
            kasetteUI.SetActive(false);
            KasettePlay();

            objectFoundActive[8].SetActive(true);
        }
        else if (CDOpenBool == true && kasetteBool)
        {
            CDOpenBool = false;
            cD_Recorder.GetComponent<Animator>().SetBool("isOpen", false);
            kasetteUI.SetActive(true);
            kasetteBool = true;
            mainAudioController.ChangeToDefault();
            guitarMusic = true;
        }
    }
    #endregion

}