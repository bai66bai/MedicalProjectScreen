using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabBarCtrl : MonoBehaviour
{
    public List<TextMeshProUGUI> textMeshProUGUIs;
    public List<GameObject> SwiperItems;
    public List<Image> images;

    public GameObject CtrBtn;

    public GameObject ActiveSwiper;

    //private readonly Color _defaultColor = new(0.63f, 0.63f, 0.63f, 1f);

    private void Start()
    {
        if(TTorStore.LastSceneName == "TTOR_Scene" && SwippStore.SelectTab != "")
        {
            StartCoroutine(WaitAndExecute());
        }
    }


    // 协程方法
    private IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(0.2f);
        HandleClick(SwippStore.SelectTab);
    }
    public void HandleClick(string textContent)
    {
        textMeshProUGUIs.ForEach(textMeshPro =>
        {
            if (textMeshPro.text != textContent)
            {
                //textMeshPro.color = _defaultColor;
                textMeshPro.fontStyle = FontStyles.Normal;
            }
            else
            {
                SwippStore.SelectTab = textContent;
                int index = textMeshProUGUIs.IndexOf(textMeshPro);
                //textMeshPro.color = new(51/255f, 51/255f, 51/255f, 1f);
                textMeshPro.fontStyle = FontStyles.Bold;

             
                SwiperItems.ForEach(item =>
                {
                    int Sindex = SwiperItems.IndexOf(item);
                    if (Sindex == index)
                    {
                        ActiveSwiper = item;
                        item.SetActive(true);
                        CtrBtn.GetComponent<Turnthepage>().ChangeActive();
                        images[Sindex].enabled = true; 
                    }
                    else
                    {
                        item.SetActive(false);
                        images[Sindex].enabled = false;  
                    }
                });
            }
        });
        
    }

    private void OnDestroy()
    {
        if (TTorStore.NextSceneName != "TTOR_Scene")
            SwippStore.SelectTab = "";
    }
}
