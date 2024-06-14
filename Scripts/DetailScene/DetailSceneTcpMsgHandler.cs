
using System.Linq;
using UnityEditor;

namespace Assets.Scripts.DetailScene
{
    internal class DetailSceneTcpMsgHandler : TCPMsgHandler
    {
        public ScrollMenu scrollMenu;

        public override void HandleMsg(string msg)
        {
            string[] splitedMsg = msg.Split(":");
            if (splitedMsg[0] != "detail") throw new System.NotImplementedException();
            MenuItem currentItem = scrollMenu.menuItems
            .Where(m => m.Text == splitedMsg[1])
            .ToList()
            .First();

            MenuItem beforeItem = scrollMenu.menuItems
            .Where(m => m.Text == DetailStore.ActiveDetailText)
            .ToList()
            .First();

            beforeItem.InactivateItem();

            int pos = scrollMenu.menuItems.IndexOf(currentItem);
            currentItem.ActivateItem();
        }
    }
}
