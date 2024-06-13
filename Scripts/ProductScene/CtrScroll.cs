using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CtrScroll : MonoBehaviour
{
    public ScrollRect scrollView; 
    //Ö´ÐÐÊ±¼ä
    public float smoothTime = 1.0f; 

    void Start()
    {

        StartCoroutine(SmoothScrollCoroutine());

    }

    IEnumerator SmoothScrollCoroutine()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < smoothTime)
        {
            float t = elapsedTime / smoothTime;
            float targetPosition = Mathf.SmoothStep(1.0f, 0.0f, t);
            scrollView.horizontalNormalizedPosition = targetPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        scrollView.horizontalNormalizedPosition = 0.0f;
    }
}
