using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathologicalCrtl : MonoBehaviour
{
    public GameObject PathologicalImage;

    public void ShowImageActive()
    {
        PathologicalImage.SetActive(true);
    }
    public void DisableImageActive()
    {
        PathologicalImage.SetActive(false);
    }

}
