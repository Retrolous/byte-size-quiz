using System.Linq;
using System.Windows.Forms;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    // this form does not follow typical naming conventions for a user form as it is to be used as a base form; it has no controls or functionality of its own
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            // when a new form is instantiated, this constructor will also be executed. consequently, this allows for
            // the panel and close button functionality to be applied to all forms derived from BaseForm without manually adding it to each


            // add a lambda function to the load event of all derived forms (equivalent of a js arrow function) to add functionality to panel and close buttons

            this.Load += (s, e) =>
            {
                AttachDragEventHandlers();
                AttachCloseButtonEventHandler();
            };
        }
        #region Form closing logic
        // store initial position for dragging and boolean for checking if dragging applies
        private bool dragging = false;
        private int curPosX, curPosY;

        // attach the logic to execute when a form closes to any btnClose on the form
        private void AttachCloseButtonEventHandler()
        {
            var btnCloseControl = Controls.Find("btnClose", true).FirstOrDefault() as Button; // find the first button named "btnClose" in the form
            if (btnCloseControl != null)
            {
                btnCloseControl.Click += (s, e) => Close(); // add a lambda expression to simply close the form; custom close logic is implemented in OnFormClosing
            }
        }

        // overrides the close event listener to show the shutdown form before closing the application
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // help forms appear as pop-ups, thus checks must be added to ensure that closing a help form will not close the entire program
            if (!(this is frmHelp1 || this is frmHelp2 || this is frmHelp3 || this is frmHelpMain))
            {
                e.Cancel = true; // prevent immediate closing by cancelling the event

                // loop through each open form and hide it; if using only this.Hide() while, for example, a help form is open as well, the help form will remain open, looking tacky
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Application.OpenForms[i].Hide();
                }
                new frmShutdown().ShowDialog(); // show shutdown animation; ShowDialog() executes the form as a modal dialogue box, preventing further execution of logic in the main form
            }
            else
            {
                base.OnFormClosing(e); // proceed with the normal closing for help forms by executing the closing logic for a regular Form object
            }
        }
        #endregion

        #region Panel dragging logic

        // attach event listeners to all pnlToolbars
        private void AttachDragEventHandlers()
        {
            // ensure the panel exists and attach the event handlers
            var pnlToolbarControl = Controls.Find("pnlToolbar", true).FirstOrDefault() as Panel; // find the first panel named "pnlToolbar" in the form
            if (pnlToolbarControl != null)
            {
                pnlToolbarControl.MouseMove += pnlToolbar_MouseMove; // attach the appropriate event listeners
                pnlToolbarControl.MouseUp += pnlToolbar_MouseUp;
                pnlToolbarControl.MouseDown += pnlToolbar_MouseDown;
            }
        }

        // change the position of the entire form when the cursor moves while dragging
        private void pnlToolbar_MouseMove(object sender, MouseEventArgs e)
        {
            // ensure that the user has clicked on the panel before moving the panel with the cursor
            if (sender is Panel && e.Button == MouseButtons.Left && dragging)
            {

                Left += Cursor.Position.X - curPosX;
                curPosX = Cursor.Position.X;
                Top += Cursor.Position.Y - curPosY;
                curPosY = Cursor.Position.Y;

            }
        }

        // stop dragging when mouse is raised
        private void pnlToolbar_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Panel && e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        // start dragging when mouse is down
        private void pnlToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Panel && e.Button == MouseButtons.Left)
            {
                dragging = true;
                curPosX = Cursor.Position.X;
                curPosY = Cursor.Position.Y;
            }
        }
        #endregion
    }
}
