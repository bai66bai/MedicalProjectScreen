using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIdle : MonoBehaviour
{
    public float timeoutSeconds = 5; // �û��޲����ĳ�ʱʱ�䣨�룩
    private float lastInteractionTime; // ��¼������ʱ��

    void Start()
    {
        SceneManager.LoadSceneAsync("IdleScene", LoadSceneMode.Additive);
        ResetTimer();
    }

    void Update()
    {


        // ����Ƿ�ʱ
        if (Time.time - lastInteractionTime > timeoutSeconds)
        {
            Idle();
        }
    }

    private void Idle()
    {
        // �����������������
        Scene targetScene = SceneManager.GetSceneByName("IdleScene");
        if (targetScene.isLoaded)
        {
            GameObject[] rootObjects = targetScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "MainObj")
                    obj.SetActive(true);
            }
        }

        // ���ص�ǰ����������
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.isLoaded)
        {
            GameObject[] rootObjects = currentScene.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                if (obj.name == "MainObj")
                    obj.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        ResetTimer();
    }

    // ���ü�ʱ��
    void ResetTimer()
    {
        lastInteractionTime = Time.time;
    }

}
