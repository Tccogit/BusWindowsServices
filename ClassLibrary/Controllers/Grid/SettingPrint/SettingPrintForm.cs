using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace ClassLibrary
{
    public partial class JSettingPrintForm : JBaseForm
    {
        private DataGridView _gridView;
        private GridEX _JanusGridView;
        private string _FieldList = "";

        public JSettingPrintForm(GridEX dataGrid)
        {
            InitializeComponent();
            try
            {
                _JanusGridView = dataGrid;

                chklstFields.Items.Clear();
                for (int i = 0; i < dataGrid.Tables[0].Columns.Count; i++)                
                    chklstFields.Items.Add(dataGrid.Tables[0].Columns[i].Caption, dataGrid.Tables[0].Columns[i].Visible);                
            }
            catch
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int i  = 0;
                foreach (Janus.Windows.GridEX.GridEXColumn column in _JanusGridView.Tables[0].Columns)                
                    column.Visible = chklstFields.GetItemChecked(i++);                
                for (int j = 0; j< chklstFields.Items.Count; j++)                
                    if (chklstFields.GetItemChecked(j))
                        _FieldList = _FieldList + chklstFields.Items[j].ToString() + ",";                
                Print();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private bool Save()
        {
            JSettingPrint tmp = new JSettingPrint();
            tmp.MarginB = txtMB.Text;
            tmp.MarginT = txtMB.Text;
            tmp.MarginL = txtMB.Text;
            tmp.MarginR = txtMB.Text;
            tmp.Name = txtTitle.Text;
            tmp.Header = txtHeader.Text;
            tmp.Footer = txtFooter.Text;
            tmp.FieldList = _FieldList;
            if (chkLandEscape.Checked)
                tmp.LandScape = true;
            else
                tmp.LandScape = false;
            if (this.State == JFormState.Insert)
            {
                if (tmp.insert() > 0)
                    return true;
            }
            else
            {
                tmp.Code = ((JDynamicReport)listBoxSetting.SelectedItem).Code;
                if(tmp.Update())
                    return true;
            }
            return false;
        }

        private void Print()
        {
            GridEXPrintDocument printDoc = new GridEXPrintDocument();
            if (chkLandEscape.Checked)
                printDoc.DefaultPageSettings.Landscape = true;
            if (txtMB.Text != "")
                printDoc.DefaultPageSettings.Margins.Bottom = Convert.ToInt32(txtMB.Text);
            if (txtMT.Text != "")
                printDoc.DefaultPageSettings.Margins.Top = Convert.ToInt32(txtMT.Text);
            if (txtML.Text != "")
                printDoc.DefaultPageSettings.Margins.Left = Convert.ToInt32(txtML.Text);
            if (txtMR.Text != "")
                printDoc.DefaultPageSettings.Margins.Right = Convert.ToInt32(txtMR.Text);
            printDoc.PageHeaderCenter = txtHeader.Text;
            printDoc.PageFooterCenter = txtFooter.Text; //printDoc.Page.ToString();
            printDoc.GridEX = _JanusGridView;
            printPreviewDialog1.Document = printDoc;
            printPreviewDialog1.Document.DocumentName = "Print";            
            //if (MessageBox.Show(JLanguages._Text("DoYouWantToSaveChanges"), "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    if (!Save())                   
            //        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            printPreviewDialog1.ShowDialog();
        }

        private void JSettingPrintForm_Load(object sender, EventArgs e)
        {
            JSettingPrints DRs = new JSettingPrints();
            DRs.GetDatas();
            listBoxSetting.Items.AddRange((DRs.Items));
            listBoxSetting.DisplayMember = "Name";
        }

        private void listBoxSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSetting.SelectedItem != null && ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).Code > 0)
                {
                    if (((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).LandScape)
                        chkLandEscape.Checked = true;
                    else
                        chkLandEscape.Checked = false;
                    txtMB.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).MarginB;
                    txtMT.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).MarginT;
                    txtML.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).MarginL;
                    txtMR.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).MarginR;
                    txtTitle.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).Name;
                    txtHeader.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).Header;
                    txtFooter.Text = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).Footer;
                    string[] FieldList = ((ClassLibrary.JSettingPrint)(listBoxSetting.SelectedItem)).FieldList.Split(',');
                    for (int j = 0; j < chklstFields.Items.Count; j++)
                            chklstFields.SetItemChecked(j,false);
                    for (int i = 0; i < FieldList.Length; i++)
                        for (int j = 0; j < chklstFields.Items.Count; j++)
                            if (FieldList[i].ToString() == chklstFields.Items[j].ToString())
                                chklstFields.SetItemChecked(j, true);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
