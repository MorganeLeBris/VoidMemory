using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
   // public Vector3 OpenPosition;
    private bool open;

    public IEnumerator OpenUp()
    {
        Vector3 OpenPosition = transform.position + new Vector3(0, 1.5f, 0);
        if (!open)
        {
            while (transform.position != OpenPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, OpenPosition, 0.05f);

                if (Vector3.Distance(transform.position, OpenPosition) <= 0.25f)
                {
                    transform.position = OpenPosition;
                    open = true;
                }
                yield return null;
            }
        }
    }

    public IEnumerator CloseUp()
    {
        Vector3 ClosePosition = transform.position + new Vector3(0, -1.5f, 0);
        if (open)
        {
            while (transform.position != ClosePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, ClosePosition, 0.05f);

                if (Vector3.Distance(transform.position, ClosePosition) <= 0.25f)
                {
                    transform.position = ClosePosition;
                    open = false;
                }
                yield return null;
            }
        }
    }
}