using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSelectedTab : MonoBehaviour
{
    public void TabSelect(int index)
    {
        SwiperStore.SelectedTab = index;
    }
}
