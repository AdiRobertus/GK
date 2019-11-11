using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK
{
    public partial class Core : Form
    {
        protected LKSN2018Entities db = new LKSN2018Entities();
        public Core()
        {
            InitializeComponent();
        }
    }

    public static class Extention
    {
        public static bool IsAnyEmpty(this Control.ControlCollection controls, params Control[] exceptions)
        {
            foreach(Control control in controls)
            {
                if (!exceptions.Contains(control) && control is TextBox && control.Text.Trim() == "")
                {
                    return true;
                }
            }
            return false;
        }

        public static void ClearFields(this Control.ControlCollection controls, params Control[] exceptions)
        {
            foreach (Control control in controls)
            {
                if(!exceptions.Contains(control) && control is TextBox)
                {
                    control.Text = "";
                }
            }
        }

        public static void ChangeState(this Control.ControlCollection controls,bool state, params Control[] exceptions)
        {
            foreach (Control control in controls)
            {
                if (!exceptions.Contains(control) && control is TextBox || control is ComboBox)
                {
                    control.Enabled = state;
                }
            }
        }

        public static bool IsEmail(this string text)
        {
            var email = new EmailAddressAttribute();
            if (email.IsValid(text))
            {
                return true;
            }

            return false;
        }

        public static bool IsNumber(this string text)
        {
            if (text.All(char.IsNumber) && text.Trim() != "")
            {
                return true;
            }
            return false;
        }

        public static string ToHash(this string text)
        {
            SHA256 hash = SHA256.Create();
            var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(bytes);
        }
    }
}
