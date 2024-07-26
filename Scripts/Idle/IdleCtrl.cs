using UnityEngine;

public class IdleCtrl : MonoBehaviour
{
    public GameObject IdleObj;
    public float timeoutSeconds = 5; // 用户无操作的超时时间（秒）
    private static float lastInteractionTime; // 记录最后操作时间

    void Start()
    {
        BreakAndReset();
    }

    void Update()
    {
        IdleObj.SetActive(Time.time - lastInteractionTime > timeoutSeconds);
    }

    // 重置计时器
    public static void BreakAndReset()
    {
        lastInteractionTime = Time.time;
    }
}
