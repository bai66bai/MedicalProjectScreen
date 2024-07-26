using UnityEngine;

public class IdleCtrl : MonoBehaviour
{
    public GameObject IdleObj;
    public float timeoutSeconds = 5; // �û��޲����ĳ�ʱʱ�䣨�룩
    private static float lastInteractionTime; // ��¼������ʱ��

    void Start()
    {
        BreakAndReset();
    }

    void Update()
    {
        IdleObj.SetActive(Time.time - lastInteractionTime > timeoutSeconds);
    }

    // ���ü�ʱ��
    public static void BreakAndReset()
    {
        lastInteractionTime = Time.time;
    }
}
