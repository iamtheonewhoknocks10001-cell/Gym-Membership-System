


using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace Gym_Membership_System
{
    public static class ThemeManager
    {
        private static bool _isDarkMode = true;
        private static List<Form> _registeredForms = new List<Form>();

        public static event Action<bool> ThemeChanged;

        public static bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    ThemeChanged?.Invoke(_isDarkMode);

                    // Apply to all registered forms
                    for (int i = _registeredForms.Count - 1; i >= 0; i--)
                    {
                        var form = _registeredForms[i];
                        if (form == null || form.IsDisposed)
                        {
                            _registeredForms.RemoveAt(i);
                        }
                        else
                        {
                            ApplyThemeToForm(form, _isDarkMode);
                        }
                    }
                }
            }
        }

        public static void RegisterForm(Form form)
        {
            if (form != null && !_registeredForms.Contains(form))
            {
                _registeredForms.Add(form);
                form.FormClosed += (s, e) => UnregisterForm(form);
                // Apply current theme immediately
                ApplyThemeToForm(form, _isDarkMode);
            }
        }

        public static void UnregisterForm(Form form)
        {
            if (_registeredForms.Contains(form))
            {
                _registeredForms.Remove(form);
            }
        }

        public static void ApplyThemeToForm(Form form, bool isDarkMode)
        {
            if (form == null || form.IsDisposed) return;

            if (form is Form1 mainForm)
            {
                mainForm.ApplyTheme(isDarkMode);
            }
            else if (form is FormPayments paymentsForm)
            {
                paymentsForm.ApplyTheme(isDarkMode);
            }
        } 
    }
}