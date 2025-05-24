using System.Collections;
using UnityEngine;

public class ClickFeedback : MonoBehaviour
{
    [SerializeField] AnimationCurve feedbackStrengthCurve;
    [SerializeField] float wiggleSpace = 1;
    [SerializeField] float wiggleTime;
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

        while (timeWentBy < wiggleTime / 2)
        {
            transform.position = Vector3.Slerp(currentStartPos,
                currentStartPos + new Vector3(GetRandomWiggleRange(), GetRandomWiggleRange(), 0),
                timeWentBy / wiggleTime);

            timeWentBy += Time.deltaTime;
            yield return null;
        }

        timeWentBy = 0;
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
        return Random.Range(-1, 1f) * wiggleSpace;
    }
}
