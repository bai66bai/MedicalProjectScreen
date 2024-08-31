using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlCases : MonoBehaviour
{
    public List<Image> images;

    public void ChangeCases(string MbtnName)
    {
        images.ForEach(image =>
        {
            if (image.name == MbtnName)
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
        });
    }
}
