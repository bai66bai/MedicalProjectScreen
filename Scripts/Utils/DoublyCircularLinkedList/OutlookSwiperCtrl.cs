using Assets.Scripts.Utils.DoublyCircularLinkedList;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutlookSwiperCtrl : MonoBehaviour
{
    public List<string> SceneNames;

    private DCL_Node<string> currentSwiperNode;

    // Start is called before the first frame update
    void Start()
    {
        DCL_Node<string> firstNode = new(SceneNames[0]);
        DCL_Node<string> lastNode = firstNode;
        foreach (var sceneName in SceneNames)
        {
            if (sceneName == SceneNames[0]) continue;

            DCL_Node<string> currentNode = new(sceneName);
            currentNode.Prev = lastNode;
            lastNode.Next = currentNode;

            if (sceneName == SceneNames[SceneNames.Count - 1])
            {
                currentNode.Next = firstNode;
            }
        }
    }

    public void SwipeNext()
    {
        string nextSceneName = currentSwiperNode.Next.Value;
        SceneManager.LoadScene(nextSceneName);
        currentSwiperNode = currentSwiperNode.Next;
    }

    public void SwipePrev()
    {
        string nextSceneName = currentSwiperNode.Prev.Value;
        SceneManager.LoadScene(nextSceneName);
        currentSwiperNode = currentSwiperNode.Prev;
    }
}
