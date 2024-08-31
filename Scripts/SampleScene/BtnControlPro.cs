using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnControlPro : MonoBehaviour
{
    public List<GameObject> buttons;
    //¿ØÖÆ°´Å¥
    public List<GameObject> ShowContents;


    private void Start()
    {
        if (TTorStore.LastSceneName == "TTOR_Scene" && HumanBodyStore.HunmanBtnName != "")
        {
            buttons.ForEach(t =>
            {
                if(t.name == HumanBodyStore.HunmanBtnName)
                {
                    OnClick(t);
                }
            });
        }
    }

    public void OnClick(GameObject go)
    {
            buttons.ForEach(p =>
            {

                if (p.name == go.name)
                {
                    int tIndex = buttons.IndexOf(p);
                    ShowContents[tIndex].SetActive(true);
                    Image[] images = p.GetComponentsInChildren<Image>();
                    images[0].enabled = true;
                    images[1].enabled = false;
                }
                else
                {
                    int tIndex = buttons.IndexOf(p);
                    ShowContents[tIndex].SetActive(false);
                    Image[] images = p.GetComponentsInChildren<Image>();
                    images[0].enabled = false;
                    images[1].enabled = true;
                }
            });        
    }

    private void OnDestroy()
    {
        if (TTorStore.NextSceneName != "TTOR_Scene")
            HumanBodyStore.HunmanBtnName = "";
    }
}
