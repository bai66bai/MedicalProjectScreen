using TMPro;
using UnityEngine;

public class TabBarItem : MonoBehaviour
{
    // ���������TabBar������
    public TabBarCtrl tabBarCtrl;
    private TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        tabBarCtrl = transform.parent.gameObject.GetComponent<TabBarCtrl>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // ������¼������ø�������������
    public void ItemHandleClick()
    {
        tabBarCtrl.HandleClick(textMeshProUGUI.text);
    }
}