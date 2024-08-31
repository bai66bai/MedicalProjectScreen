using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator animator;

    public float transitionTime = 1f;

    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
   
    public void GoBack()
    {
        LoadNewScene(LevelStore.LastSceneName);
    }

    IEnumerator LoadLevel(string sceneName)
    {
        // ���Ŷ���
        animator.SetTrigger("StartTrigger");

        // �ȴ������������
        yield return new WaitForSeconds(transitionTime);

        LevelStore.LastSceneName = SceneManager.GetActiveScene().name;
        TTorStore.LastSceneName = SceneManager.GetActiveScene().name;

        // �л�����
        SceneManager.LoadScene(sceneName);
    }
}
