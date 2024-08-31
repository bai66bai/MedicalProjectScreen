using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineTCPMessageHandler : TCPMsgHandler
{

    public PipelineVideoCtrl PipelineVideoCtrl;
    public override void HandleMsg(string msg)
    {
        msg = msg.Split(":")[0];
       if(msg == "touchScreen")
        {
            PipelineVideoCtrl.TogglePlayPause();
        }
    }
}
