using Assets.Scripts.ProductCenterProMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class ProductCenterTcpMessageHandler : TCPMsgHandler
{
    public Swiper swiper;

    int num = 0;
    public override void HandleMsg(string msg)
    {
        string[] splitedMsg = msg.Split(":");
        
        if(splitedMsg[0] == "left")
        {
            num++;
        }
        else if (splitedMsg[0] == "right")
        {
            num--;
        }
        ProductMaxStore.SwiperCount = num;
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
