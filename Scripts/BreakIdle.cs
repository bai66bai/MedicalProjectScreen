using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakIdle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            // ���ش�������������
            Scene targetScene = SceneManager.GetSceneByName("IdleScene");
            if (targetScene.isLoaded)
            {
                GameObject[] rootObjects = targetScene.GetRootGameObjects();
                foreach (GameObject obj in rootObjects)
                {
                    if (obj.name == "MainObj")
                        obj.SetActive(false);
                }
            }

            // ���ǰ����������
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.isLoaded)
            {
                GameObject[] rootObjects = currentScene.GetRootGameObjects();
                foreach (GameObject obj in rootObjects)
                {
                    if (obj.name == "MainObj")
                        obj.SetActive(true);
                }
            }
        }


    }
}
