using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TtorTCPMsgHandler : TCPMsgHandler
{
    public List<CtrlContentChange> ctrlContentChanges;
    public CtrlMedical ctrlMedical;
    public LevelLoader levelLoader;
    public CtrlMedicalScreenDisable ctrlMedicalScreenDisable;
    CtrlContentChange ctrlContentChange = null;
    private string ID = "";
    private void Start()
    {
        if(ID == "")
        {
                    ID = TCPMsgParams.msgParams["ID"];
                    ctrlMedicalScreenDisable.StopUseScreen();
                    string BtnName = TCPMsgParams.msgParams["TBtnName"];
                    string MedicalName = TCPMsgParams.msgParams["MedicalName"];
                    ctrlMedical.ChangeMedical(MedicalName);
        
                    foreach (var item in ctrlContentChanges)
                    {
                        if (item.gameObject.activeSelf == true)
                        {
                            ctrlContentChange = item;
                            break;
                        }
                    }
                    ctrlContentChange.ShowContent(BtnName);
                    TCPMsgParams.msgParams.Clear();
        }
        
    }


    public override void HandleMsg(string msg)
    {

        string[] splitedMsg = msg.Split(":");
        string[] content = splitedMsg[1].Split("-");
        if (content[1] == ID)
        {
            switch (splitedMsg[0])
                    {
                        case "close":
                            if (SceneManager.GetActiveScene().name == "TTOR_Scene")
                            {
                                ID = "";
                                ctrlMedicalScreenDisable.StartUseScreen();
                                levelLoader.LoadNewScene(TTorStore.LastSceneName);
                    }
                            break;
                        case "TBtnName":
                            {
                                ctrlContentChange.ShowContent(content[0]);
                            }
                            break;
                        case "MbtnName":
                            {
                         ctrlContentChange.GetComponentInChildren<CtrlCases>().ChangeCases(content[0]);
                            }
                    break;
                    }
        }
        
    }
  
}
