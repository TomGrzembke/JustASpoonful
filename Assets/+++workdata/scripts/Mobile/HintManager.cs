using MyBox;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    [SerializeField] List<EventTrigger> interactables;
    [SerializeField] List<EventTrigger> interactSpecific;
    [SerializeField] float activateSeconds = 10;
    [SerializeField] float switchSeconds = 3;
    [SerializeField] float cooldown;
    [SerializeField] Toggle toggleUI;
    EventSystem eventSystem;
    Coroutine hintRoutine;

    void Awake() => eventSystem = FindAnyObjectByType<EventSystem>();

    IEnumerator Start()
    {
        yield return new WaitForSeconds(activateSeconds);
        if (TouchCheck.Instance.UsedTouch)
            ToggleHints(true);
    }

    public void ToggleHints(Toggle toggle)
    {
        ToggleHints(toggle.isOn);
    }

    public void ToggleHints(bool toggle)
    {
        if (hintRoutine != null)
            StopCoroutine(hintRoutine);

        if (toggle)
            hintRoutine = StartCoroutine(TriggerHoverRandom());

        toggleUI.isOn = toggle;
    }

    IEnumerator TriggerHoverRandom()
    {
        int randomNumber = Random.Range(0, interactables.Count);
        int randomNumberSpecific = Random.Range(0, interactSpecific.Count);
        PointerEventData pointerData = new(eventSystem);

        interactSpecific[randomNumberSpecific].OnPointerEnter(pointerData);
        interactables[randomNumber].OnPointerEnter(pointerData);

        yield return new WaitForSeconds(switchSeconds);

        interactables[randomNumber].OnPointerExit(pointerData);
        interactSpecific[randomNumberSpecific].OnPointerExit(pointerData);

        yield return new WaitForSeconds(cooldown);

        StartCoroutine(TriggerHoverRandom());
    }

    [ButtonMethod]
    public void GatherEventTrigger()
    {
        interactables.Clear();
        interactSpecific.Clear();
        List<EventTrigger> _interactables = FindObjectsOfType<EventTrigger>().ToList();

        interactables = _interactables.ToList();
        interactSpecific = _interactables.ToList();
    }
}
