using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlContentChange : MonoBehaviour
{

    public List<GameObject> Contents;

    public void ShowContent(string content)
    {
        Contents.ForEach(u =>
        {
            if(u.name == content)
            {
                u.gameObject.SetActive(true);
            }
            else
            {
                u.gameObject.SetActive(false);
            }
        });
    }
}
