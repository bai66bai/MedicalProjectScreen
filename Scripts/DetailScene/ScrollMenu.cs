using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour, IEndDragHandler, IBeginDragHandler
{
    public List<MenuItem> menuItems;

    public float transitionTime = 0.25f;

    private MenuItem currentItem;

    private ScrollRect scrollRect;

    private float nearestPos = 1f;

    private readonly List<float> itemCenterPosList = new()
    {
        1f, 0.8937244f, 0.7803621f, 0.6717234f, 0.5607229f, 0.4449991f, 0.3339984f, 0.2229982f, 0.1096361f, 0f
    };


    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }


    void Start()
    {
        // ��龲̬����ActiveDetailText���жϵ�ǰԪ��
        // 1.�����Ԫ��
        currentItem = menuItems
            .Where(m => m.Text == DetailStore.ActiveDetailText)
            .ToList()
            .First();
        currentItem.ActivateItem();

        // 2.��������Ԫ�ص�λ��
        int currentItemIndex = menuItems.IndexOf(currentItem);
        ScrollToIndex(currentItemIndex);
    }


    /// <summary>
    /// ��ʼ��ק�ص�
    /// </summary>
    /// <param name="eventData">�¼�����</param>
    public void OnBeginDrag(PointerEventData eventData) { }


    /// <summary>
    /// ������ק�ص�
    /// </summary>
    /// <param name="eventData">�¼�����</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        UpdateNearestItemCenterPos();

        ActivateItemByPos(nearestPos);

        ScrollToPos(nearestPos);
    }


    /// <summary>
    /// ���¾��뵱ǰλ�������Ԫ������λ��
    /// </summary>
    private void UpdateNearestItemCenterPos()
    {
        foreach (var item in itemCenterPosList)
        {
            if (Math.Abs(item - scrollRect.normalizedPosition.y) < Math.Abs(nearestPos - scrollRect.normalizedPosition.y))
                nearestPos = item;
        }
    }


    /// <summary>
    /// ����ָ��λ�õ�Ԫ��
    /// </summary>
    /// <param name="pos">Ԫ�ص�λ��</param>
    private void ActivateItemByPos(float pos)
    {
        currentItem.InactivateItem();

        int currentIndex = itemCenterPosList.IndexOf(pos);
        currentItem = menuItems[currentIndex];
        currentItem.ActivateItem();
    }


    /// <summary>
    /// ������ָ������
    /// </summary>
    /// <param name="index">item����</param>
    private void ScrollToIndex(int index) => StartCoroutine(ScrollToPositionIEnumerator(itemCenterPosList[index]));


    /// <summary>
    /// ������ָ��λ��
    /// </summary>
    /// <param name="pos">Ŀ��λ��</param>
    private void ScrollToPos(float pos) => StartCoroutine(ScrollToPositionIEnumerator(pos));


    /// <summary>
    /// ������ָ��λ�ã�Э�̵��ã�
    /// </summary>
    private IEnumerator ScrollToPositionIEnumerator(float pos)
    {
        float elapsedTime = 0;
        float startY = scrollRect.normalizedPosition.y;
        while (elapsedTime < transitionTime)
        {
            float newY = Mathf.Lerp(startY, pos, elapsedTime / transitionTime);
            scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, newY);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, pos);
    }

    

}
