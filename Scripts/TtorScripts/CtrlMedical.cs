using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMedical : MonoBehaviour
{
    public List<GameObject> lists;

    public void ChangeMedical(string medicalName)
    {
        lists.ForEach(list =>
        {
            if(list.name == medicalName)
            {
                list.SetActive(true);
            }
            else
            {
                list.SetActive(false);
            }
        });
    }
}
