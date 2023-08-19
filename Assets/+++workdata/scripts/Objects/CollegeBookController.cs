using UnityEngine;

public class CollegeBookController : MonoBehaviour
{
    #region stats
    public int blockingObjectCounter;
    public bool isOpen;
    #endregion

    #region Access
    EventTriggerBehavior triggerBehavior;

    private void Awake()
    {
        triggerBehavior = GameObject.Find("Manager").GetComponent<EventTriggerBehavior>();
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockingObjectHard"))
        {
            blockingObjectCounter += 2;
        }
        else if (collision.CompareTag("BlockingObjectSoft"))
        {
            blockingObjectCounter++;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockingObjectHard"))
        {
            blockingObjectCounter -= 2;
        }
        else if (collision.CompareTag("BlockingObjectSoft"))
        {
            blockingObjectCounter--;
        }


    }

    public void BookCheck()
    {
        if (blockingObjectCounter >= 1 && !isOpen)
        {
            gameObject.GetComponent<Animator>().SetTrigger("isNotFree");
        }
        else if (blockingObjectCounter < 1 && !isOpen)
        {
            gameObject.GetComponent<Animator>().SetTrigger("isFree");
            gameObject.GetComponent<Animator>().SetBool("isOpen", isOpen = true);
            triggerBehavior.objectFoundActive[6].SetActive(true);
            triggerBehavior.objectFoundActive[10].SetActive(true);
            triggerBehavior.StarHoverEnd(GameObject.Find("StarsBook"));
            triggerBehavior.bookSolvedBool = true;
            triggerBehavior.EndgameCheck();
        }
        else if (isOpen)
        {
            gameObject.GetComponent<Animator>().SetBool("isOpen", isOpen = false);
        }
    }

    public void SpoonFound()
    {
        triggerBehavior.SpoonBook();
    }
}
