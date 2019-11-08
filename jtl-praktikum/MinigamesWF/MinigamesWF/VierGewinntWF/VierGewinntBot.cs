using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigamesWF.VierGewinntWF
{
    class VierGewinntBot
    {
        private bool BotActive;
        private List<Button> Buttons;
        private List<Button> SavedButtons;

        public VierGewinntBot()
        {
            BotActive = false;
        }

        public void SetButtons(List<Button> Buttons)
        {
            SavedButtons = Buttons;
            ResetButtons();
        }

        public void ResetButtons() 
        {
            Buttons = new List<Button>(SavedButtons);
        }

        public void SwitchActive()
        {
            if (BotActive)
            {
                BotActive = false;
            } else 
            {
                BotActive = true;
            }
        }

        public bool IsActive()
        {
            return BotActive;
        }

        public void ExecuteMove(Coords LastPlayerMove)
        {
            if (LastPlayerMove.X == 0)
            {
                Buttons.RemoveAt(LastPlayerMove.X);
            }
            
            int len = Buttons.Count;
            
            if (len > 0)
            {   
                Random RandomGenerator = new Random();
                int MoveValue = RandomGenerator.Next(0, --len);
                Button SelectedButton = Buttons[MoveValue];
                SelectedButton.PerformClick();
            } else
            {
                Button SelectedButton = Buttons[0];
                SelectedButton.PerformClick();

            }
        }
    }
}
