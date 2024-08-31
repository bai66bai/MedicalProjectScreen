using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlDefualtActive : MonoBehaviour
{
    public GameObject All;

    private void Awake()
    {
        if(TTorStore.LastSceneName != "TTOR_Scene" || SwippStore.SelectTab == "")
        {
            All.SetActive(true);
        }
    }
}
