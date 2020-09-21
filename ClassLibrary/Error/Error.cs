using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary 
{
    public class JError: JCore
    {
        //public static readonly string SET_SQL = "";
    }

    public enum JMessageResualt
    {
        MrOk = DialogResult.OK, MrYes = DialogResult.Yes, MrNo = DialogResult.No, MrCancel = DialogResult.Cancel
    }
    public enum JMessageType
    {
        Information, Error, Question, Warning, Confirmation
    }
    public static class JMessages
    {
        public static int Property
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {

            }
        }
        static public DialogResult Message(string msgText, string msgTitle, JMessageType msgType)
        {
			if (JMainFrame.IsWeb())
			{
				return DialogResult.None;
			}
            string _msgText = JLanguages._Text(msgText);
            string _msgTitle = JLanguages._Text(msgTitle);
            switch (msgType)
            {
                case JMessageType.Error:
                    return MessageBox.Show(_msgText, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                case JMessageType.Information:
                    return MessageBox.Show(_msgText, _msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                case JMessageType.Question:
                    return MessageBox.Show(_msgText, _msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                case JMessageType.Warning:
                    return MessageBox.Show(_msgText, _msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                case JMessageType.Confirmation:
                    return MessageBox.Show(_msgText, _msgTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                default:
                    return DialogResult.None;
            }
        }
        static public void Error(string errorText, string errorTitle)
        {
            JMessages.Message(errorText, errorTitle, JMessageType.Error);
            //MessageBox.Show(errorText, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static public void Information(string errorText, string errorTitle)
        {
            JMessages.Message(errorText, errorTitle, JMessageType.Information);
            //MessageBox.Show(errorText, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static public DialogResult Question(string msgText, string msgTitle)
        {
            return JMessages.Message(msgText, msgTitle, JMessageType.Question);
            //return MessageBox.Show(msgText, msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        static public DialogResult Warning(string msgText, string msgTitle)
        {
            return JMessages.Message(msgText, msgTitle, JMessageType.Warning);
            //return MessageBox.Show(msgText, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        static public DialogResult Confirm(string msgText, string msgTitle)
        {
            return JMessages.Message(msgText, msgTitle, JMessageType.Confirmation);
            //return MessageBox.Show(msgText, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public static void ShowErrorMessage(Exception ex)
        {
            //"HelpLink.ProdName"
            //"HelpLink.ProdVer"
            //"HelpLink.EvtSrc"
            //"HelpLink.EvtID"
            //"HelpLink.BaseHelpUrl"
            //"HelpLink.LinkId"

            string Message = "";
            string Title = "";
            try
            {
                int EvtID = int.Parse(ex.Data["HelpLink.EvtID"].ToString());
                switch (EvtID)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 547:
                        Message = "امکان حذف اطلاعات مورد نظر به علت ثبت در قسمتهای دیگر سیستم وجود ندارد" + (char)13 + ex.Message;
                        break;
                    default:
                        Message = ex.Message;
                        Title = ex.Source;
                        break;
                }

                JMessages.Message(Message, Title, JMessageType.Error);
            }
            catch
            {
            }
        }

        private static string TranslateMessage(string pText)
        {
            return pText;
        }
    }

}
