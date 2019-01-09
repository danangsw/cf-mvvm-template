using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DSW.Core.Utility.Forms
{
    public static class MessageUtility
    {
        public static bool DisplayConfirmationMsg(
            string textBody,
            string caption
            )
        {
            DialogResult result = MessageBox.Show(textBody, caption, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                return true;
            }
            else if (result == DialogResult.No) return false;
            else return false;
        }

        public static void DisplayErrorMsg(
            string textBody,
            string caption
            )
        {
            MessageBox.Show(textBody, caption,
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public static void DisplaySuccessMsg(
            string textBody,
            string caption
            )
        {
            MessageBox.Show(textBody, caption,
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
    }
}
