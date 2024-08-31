using UnityEngine;
using UnityEngine.SceneManagement;

public  class TCPMsgHandler : MonoBehaviour
{
    private LevelLoader levelLoader;
    private void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();
    }

    public virtual void HandleMsg(string msg) { }

    public virtual void OnMsg(string msg) 
    {
        string[] splitMsg = msg.Split(":");
        if (splitMsg.Length > 2)
        {
            int skipIndex = 0;
            foreach (var param in splitMsg)
            {
                if(skipIndex++>1)
                {
                    string[] paramPair = param.Split("|");
                    if (!TCPMsgParams.msgParams.ContainsKey(paramPair[0]))
                    {
                        TCPMsgParams.msgParams.Add(paramPair[0], paramPair[1]);
                    }
                    else
                    {
                        TCPMsgParams.msgParams[paramPair[0]] = paramPair[1];
                    }
                    
                }
            }
        }
        if (splitMsg[0] == "loadScene")
        {
         if(splitMsg[1] != "TTOR_Scene" || SceneManager.GetActiveScene().name != "TTOR_Scene")
            {
                TTorStore.NextSceneName = splitMsg[1];
                levelLoader.LoadNewScene(splitMsg[1]);
            }              
        }          
        else
            HandleMsg(msg);
    }
}

