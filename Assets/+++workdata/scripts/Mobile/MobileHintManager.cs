using MyBox;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileHintManager : MonoBehaviour
{
    [SerializeField] List<EventTrigger> interactables;
    [SerializeField] float activateSeconds = 10;
    [SerializeField] float switchSeconds = 3;
    EventSystem eventSystem;

    void Awake() => eventSystem = FindAnyObjectByType<EventSystem>();

    IEnumerator Start()
    {
        yield return new WaitForSeconds(activateSeconds);
        if (TouchCheck.Instance.UsedTouch)
            StartCoroutine(TriggerHoverRandom());
    }

    IEnumerator TriggerHoverRandom()
    {
        int randomNumber = Random.Range(0, interactables.Count + 1);
        //Debug.Log(interactables[randomNumber].gameObject.name);
        interactables[randomNumber].OnPointerEnter(new PointerEventData(eventSystem));
        yield return new WaitForSeconds(switchSeconds);
        interactables[randomNumber].OnPointerExit(new PointerEventData(eventSystem));
        StartCoroutine(TriggerHoverRandom());
    }



    [ButtonMethod]
    public void GatherEventTrigger()
    {
        interactables = FindObjectsOfType<EventTrigger>().ToList();
    }
}
