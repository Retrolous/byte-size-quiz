using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    public partial class frmShutdown : Form
    {
        public frmShutdown()
        {
            InitializeComponent();
            // add a lambda function to the event listener that executes when the form is shown;
            // as soon as form is fully loaded, start animation
            this.Shown += async (s, e) => await StartShutdownAnimation();
        }

        #region Form variables
        private int delayPerMessage = 300; // set in ms
        #endregion
        #region Animation logic
        // async to allow for delays, show animation then close form
        private async Task StartShutdownAnimation()
        {
            string[] messages =
            {
            "[ OK ] Stopping user services...",
            "[ OK ] Saving session state...",
            "[ OK ] Unmounting file systems...",
            "[ OK ] Sending termination signals...",
            "[ OK ] Powering off."
        };

            foreach (string msg in messages)
            {
                // add the message to the label and wait
                lblShutdown.Text += msg + Environment.NewLine;
                await Task.Delay(delayPerMessage); // Wait before next message
            }

            // invoke ensures that the action occurs on the ui thread instead of any background ones 
            // create any anonymous method (action) to shutdown the program entirely
            this.Invoke(new Action(() =>
            {
                Environment.Exit(0);
            }));
        }
        #endregion
    }
}
