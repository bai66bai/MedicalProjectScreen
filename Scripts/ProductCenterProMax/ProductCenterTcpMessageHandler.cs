using Assets.Scripts.ProductCenterProMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ProductCenterTcpMessageHandler : TCPMsgHandler
{
    public Swiper swiper;
    public override void HandleMsg(string msg)
    {
        string[] splitedMsg = msg.Split(":");

        switch (splitedMsg[0])
        {
            case "left":
                swiper.SwipeOnce(SwipeDirection.Left);
                break;
            case "right":
                swiper.SwipeOnce(SwipeDirection.Right);
                break;
        }
    }
}
