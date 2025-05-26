using System.Collections;
using UnityEngine;

public class ClickFeedback : MonoBehaviour
{
    [SerializeField] float wiggleSpace = 1;
    [SerializeField] float wiggleTime = 3;
    [SerializeField] AnimationCurve feedbackStrengthCurve = AnimationCurve.EaseInOut(0,0, 1, 1);
    [SerializeField] int interactMaxStrengthTimes = 20;
    int currentInteractStrengthTimes = 0;
    Vector3 startPos;
    Coroutine wiggleRoutine;

    private void Start()
    {
        startPos = transform.position;
    }

    public void Wiggle()
    {
        if (wiggleRoutine != null) 
        { 
            StopCoroutine(wiggleRoutine);
        }

        wiggleRoutine = StartCoroutine(WiggleCor());
    }

    IEnumerator WiggleCor()
    {
        var currentStartPos = transform.position;
        var timeWentBy = 0f;
        var randomRangeX = GetRandomWiggleRange();
        var randomRangeY = GetRandomWiggleRange();

        currentInteractStrengthTimes++;
        while (timeWentBy < wiggleTime / 2)
        {
            transform.position = Vector3.Slerp(currentStartPos,
                currentStartPos + new Vector3(randomRangeX, randomRangeY, 0),
                timeWentBy / wiggleTime);

            timeWentBy += Time.deltaTime;
            yield return null;
        }

        timeWentBy = 0f;
        while (timeWentBy < wiggleTime / 2)
        {
            transform.position = Vector3.Slerp(transform.position, startPos,
                timeWentBy / wiggleTime);

            timeWentBy += Time.deltaTime;
            yield return null;
        }
    }

    public float GetRandomWiggleRange() 
    {
        var strength = feedbackStrengthCurve.Evaluate((float)currentInteractStrengthTimes / interactMaxStrengthTimes);
        return Random.Range(-1, 1f) * wiggleSpace * strength;
    }
}
