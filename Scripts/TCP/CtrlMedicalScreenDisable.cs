using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMedicalScreenDisable : MonoBehaviour
{

    public TCPClient client;
    public void StopUseScreen()
    {
        client.SendMessage($"stop:ScreenCasting");
    }

    public void StartUseScreen()
    {
        client.SendMessage($"start:ScreenCasting");
    }
}
