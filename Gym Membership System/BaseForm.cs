using System;
using System.Windows.Forms;

namespace Gym_Membership_System
{
    public class BaseForm : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // ForgotAccountForm should NOT exit the application
            if (this is ForgotAccountForm)
            {
                // Let it close normally without affecting the application
                base.OnFormClosing(e);
                return;
            }

            // For ALL OTHER FORMS (including LOGIN, Form1, AddMember, SIGNUP),
            // closing the form should exit the entire application
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}