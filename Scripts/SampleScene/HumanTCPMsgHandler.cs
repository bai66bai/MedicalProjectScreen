

using UnityEngine;

namespace Assets.Scripts.SampleScene
{
    internal class HumanTCPMsgHandler : TCPMsgHandler
    {

        public BtnControlPro BtnControl;
        public GameObject Btn1;
        public GameObject Btn2;
        public GameObject Btn3;
        public GameObject Btn4;

        public override void HandleMsg(string msg)
        {
            msg = msg.Split(":")[1];
            GameObject targetBtn = msg.Trim() switch
            {
                "CellBtn" => Btn1,
                "SkeletonBtn" => Btn2,
                "LiverBtn" => Btn3,
                "EyeballBtn" => Btn4,
                _ => throw new System.NotImplementedException()
            };
            
            BtnControl.OnClick(targetBtn);
        }
    }
}
