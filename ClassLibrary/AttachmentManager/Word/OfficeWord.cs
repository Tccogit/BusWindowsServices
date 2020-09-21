using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;
using ClassLibrary;
using Word = Microsoft.Office.Interop.Word;


namespace ClassLibrary
{
    public class JCOfficeWord
    {
        /// تعریف متغیر ها و خصوصیات
        #region peroperties
        /// جهت شناسایی فایلی که جهت ویرایش باز شده
        public int Code;
        ///نوع باز کردن فایل ورد
        public enum JDocumentState
        {
            New,
            Update
        }
        Object oMissing = System.Reflection.Missing.Value;
        public DocumentWord File;
        /// <summary>
        /// 
        /// </summary>
        public struct DocumentWord
        {
            public string FileContent;
            public string FileText;
        }
        /// <summary>
        /// وضعیت ایجاد کلاس
        /// </summary>
        public JDocumentState State;
        private Word.Application oWord;
        #endregion peroperties
        /// رویداد های کلاس
        #region MyEvent
        /// <summary>
        /// رویداد قبل از ثبت برای کلاس
        /// </summary>
        public event EventHandler BeforSave;
        /// <summary>
        /// رویداد قبل از ثبت  
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="SaveAsUI"></param>
        /// <param name="Cancel"></param>
        private void oWord_DocumentBeforeSave(Word.Document doc, ref bool SaveAsUI, ref bool Cancel)
        {
           
            Cancel = true;
            SaveAsUI = false;
            object True = true;
            object False = false;
            try
            {
                File.FileText = doc.Content.Text;
                File.FileContent = doc.Content.get_XML(false).ToString();
            }
            finally
            {
                doc.Application.Quit(ref False, ref oMissing, ref oMissing);
                //JFiles.DeleteFile((string)TempFileName);
            }
            if (BeforSave != null)
            {
                IAsyncResult res;                
                res = BeforSave.BeginInvoke(this, null, null, null);
            }
        }

        #endregion MyEvent
        /// سازنده
        #region Constructor
        /// <summary>
        /// سازنده
        /// </summary>
        public JCOfficeWord()
        {

        }
        /// <summary>
        /// فایل جدید
        /// </summary>
        public void New()
        {
            File.FileContent = "";
            State = JDocumentState.New;
            Show();
        }
        /// <summary>
        /// ایجاد فایل جدید از روی محتوای فایل الگو
        /// </summary>
        /// <param name="PatternXml">فایل الگو xml</param>
        public void New(string PatternXml)
        {
            File.FileContent = PatternXml;
            State = JDocumentState.New;
            Show();
        }
        /// <summary>
        /// باز کردن فایل از روی محتوای فایل انتخاب شده
        /// </summary>
        /// <param name="ContentXml">فایل xml</param>
        public void Update(string ContentXml, int pCode)
        {
            Code = pCode;
            File.FileContent = ContentXml;
            State = JDocumentState.Update;
            Show();
        }
        /// <summary>
        /// انتخاب فایل جدید از روی محتوای فایل موجود
        /// </summary>
        /// <param name="pDocumentContent">XML</param>
        /// <param name="pDocumentText">TXET ONLY</param>
        public void NewFromExistingFile(string pDocumentContent, string pDocumentText)
        {
            File.FileContent = pDocumentContent;
            File.FileText = pDocumentText;     
            State = JDocumentState.New;
            if (BeforSave != null)
                BeforSave.BeginInvoke(this, null, null, null);            
        }
        #endregion Constructor
        /// توابع نوشته شده
        #region Functions
        /// <summary>
        /// نمایش
        /// </summary>
        private void Show()
        {
            try
            {
                oWord = new Word.Application();
                oWord.Visible = true;

                Word._Document oDoc;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,ref oMissing, ref oMissing); // Clean document

                if ((State == JDocumentState.Update) || (State == JDocumentState.New && File.FileContent != ""))
                {
                    oDoc.Content.InsertXML(File.FileContent, ref oMissing);
                }

                oDoc = null;
                oWord.DocumentBeforeSave +=
                    new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(
                    oWord_DocumentBeforeSave);
                //oWord.DocumentChange +=
                //    new Word.ApplicationEvents4_DocumentChangeEventHandler(
                //    oWord_DocumentChange);
                //oWord.WindowBeforeDoubleClick +=
                //    new Word.ApplicationEvents4_WindowBeforeDoubleClickEventHandler(
                //    oWord_WindowBeforeDoubleClick);
                //oWord.WindowBeforeRightClick +=
                //    new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(
                //    oWord_WindowBeforeRightClick);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
        #endregion MyFunctions



 



    }
}
