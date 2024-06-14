using System.Collections.Generic;

namespace Assets.Scripts.SwiperScene
{
    internal class SwiperTCPMessageHandler : TCPMsgHandler
    {

        public List<TouchSwiper> touchSwipers;
        public TabBarCtrl tabBarCtrl;
        
        public override void HandleMsg(string msg)
        {
            string[] splitedMsg = msg.Split(":");
            TouchSwiper enabledSwiper = null;
            foreach (var item in touchSwipers)
            {
                if (item.transform.parent.gameObject.activeSelf == true)
                {
                    enabledSwiper = item;
                    break;
                }
            }

            switch (splitedMsg[0])
            {
                case "left":
                    enabledSwiper.SwipeToLeft();
                    break;
                case "right":
                    enabledSwiper.SwipeToRight();
                    break;
                case "btnName":
                    tabBarCtrl.HandleClick(splitedMsg[1]);
                    break;
            }
        }

    }
}
