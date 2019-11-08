using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigamesWF.TicTacToeWF
{
    class TicTacToeBot
    {
        private bool BotActive;
        private List<Button> CopyButtonList;
        private List<Button> ButtonList;
        public TicTacToeBot()
        {
            BotActive = false;
        }

        public void SetButtons(List<Button> Buttons)
        {
            CopyButtonList = Buttons;
            ResetButtonList();
        }

        public void ResetButtonList()
        {
            ButtonList = new List<Button>(CopyButtonList);
        }

        public void SwitchActive()
        {
            if (BotActive)
            {
                BotActive = false;
            }
            else
            {
                BotActive = true;
            }
        }

        public bool IsActive()
        {
            return BotActive;
        }

        public void ExecuteMove(Coordinates PlayerLastCoords, Button PlayerButton)
        {
            ButtonList.Remove(PlayerButton); //Error
            Random RandomGenerator = new Random();
            int len = ButtonList.Count;
            if (len > 0)
            {
                int Move = RandomGenerator.Next(0, --len);
                Button pressButton = ButtonList[Move];
                ButtonList.RemoveAt(Move);
                pressButton.PerformClick();
            }
            else
            {
                Button pressButton = ButtonList[0];
                ButtonList.RemoveAt(0);
                pressButton.PerformClick();
            }

        }
    }
}