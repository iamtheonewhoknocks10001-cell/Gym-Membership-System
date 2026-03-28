using System;
using System.Windows.Forms;

namespace Gym_Membership_System
{
    internal static class Program
    {
        public static bool FirstAccountCreated { get; set; } = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start with login form
            Application.Run(new LOGIN());
        }
    }
}