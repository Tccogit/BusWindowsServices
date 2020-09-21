using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Xml;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;

namespace ClassLibrary
{
    public partial class JCfrmPatternFile : JBaseForm
    {
        private AcceptFile _AcceptFile;
        private enum AcceptFile
        {
            Valid,
            Invalid
        }
        private JCPatternFile _jClass;
        string strFileXmlContent;
        public JCfrmPatternFile(JCPatternFile jClass)
        {
            InitializeComponent();

            strFileXmlContent = "";
            if (jClass != null)
            {
                _jClass = jClass;
                txtTitle.Text = _jClass.Name;
                //-------------------- check box type --------------------
                if (jClass.type == ClassLibrary.Domains.JCommunication.JPatternFileType.General)
                {
                    rdoGeneral.Checked = true;
                }
                else if(jClass.type == ClassLibrary.Domains.JCommunication.JPatternFileType.Personal)
                {
                    rdoGeneral.Checked = false;
                }
                rdoPersonal.Checked = !rdoGeneral.Checked;
                //---------------------------------------------------------                
            }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitle.Text.Trim() == "")
                {
                    JMessages.Message(JLanguages._Text("Please Enter PatternFile Name"), "Error", JMessageType.Error);
                    txtTitle.Focus();
                    return;
                }
                if (State == JFormState.Insert)
                {
                    if (_AcceptFile == AcceptFile.Invalid)
                    {
                        JMessages.Message(JLanguages._Text("Invalid File Content"), "Error", JMessageType.Error);
                        return;
                    }
                    JCPatternFile tmpJCPatternFile = new  JCPatternFile();
                    //tmpJCPatternFile.Nodes = _jClass.Nodes;
                    tmpJCPatternFile.Name = txtTitle.Text.Trim();
                    tmpJCPatternFile.type = ClassLibrary.Domains.JCommunication.JPatternFileType.General;
                    tmpJCPatternFile.Pattern = strFileXmlContent;
                    tmpJCPatternFile.Insert();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (State == JFormState.Update)
                {
                    _jClass.Name = txtTitle.Text.Trim();
                    if (_AcceptFile == AcceptFile.Valid)
                          _jClass.Pattern = strFileXmlContent;
                    _jClass.Update();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (odlSelectPatternFile.ShowDialog() == DialogResult.OK)
                {
                    if (odlSelectPatternFile.CheckPathExists)
                    {
                        Word._Document oDoc;
                        Word.Application oWord = new Word.Application();
                        oWord.Visible = true;
                        Object file = odlSelectPatternFile.FileName;
                        Object oMissing = System.Reflection.Missing.Value;
                        oDoc = oWord.Documents.Open(ref file, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                ref oMissing, ref oMissing,
                                                ref oMissing);

                        strFileXmlContent = oDoc.Content.WordOpenXML;

                        lblAcceptXml.Text = JLanguages._Text("Accept File Content");
                        _AcceptFile = AcceptFile.Valid;
                        if (State == JFormState.Insert)
                            btnAction.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblAcceptXml.Text = JLanguages._Text("Invalid File Content");
                _AcceptFile = AcceptFile.Invalid;
                JSystem.Except.AddException(ex);
                if (State == JFormState.Insert)
                    btnAction.Enabled = false;
            }
        }

        private void JCfrmPatternFile_Load(object sender, EventArgs e)
        {
            _AcceptFile = AcceptFile.Invalid;
            if (State == JFormState.Insert)
            {
                btnAction.Text = JLanguages._Text("Insert");
                btnAction.Enabled = false;
            }
            else if (State == JFormState.Update)
            {
                btnAction.Text = JLanguages._Text("Update");
                btnAction.Enabled = true;
            }
        }
    }
}
