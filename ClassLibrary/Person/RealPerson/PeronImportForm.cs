using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary.Person.RealPerson
{
    public partial class PeronImportForm : JBaseForm
    {
        public PeronImportForm()
        {
            InitializeComponent();
            tbDesc.Text =
@"m=کارت ملی
sh=شناسنامه";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirSearch(label2.Text, 0);
        }

        private void Archive(JFile _Image, JPerson _Person, int ImageType, string Desc)
        {
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                int ArchiveCode = 0;
                if (ImageType == 1)
                {
                    ArchiveCode = archive.ArchiveDocument(_Image, _Person.GetType().FullName, _Person.Code, JLanguages._Text("PersonPicture"), true);
                    _Person.PersonImageCode = ArchiveCode;
                    _Person.Update(false);
                }
                else
                    if (ImageType == 2)
                    {
                        archive.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode();
                        ArchiveCode = archive.ArchiveDocument(_Image, _Person.GetType().FullName, _Person.Code, JLanguages._Text("SignaturePicture"), true);
                        _Person.SignatureImageCode = ArchiveCode;
                        _Person.Update(false);
                    }
                if (ImageType == 3)
                {
                    archive.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.SignatureArchiveCode.GetHashCode();
                    ArchiveCode = archive.ArchiveDocument(_Image, _Person.GetType().FullName, _Person.Code, Desc, true);
                }
            }
            finally
            {
                archive.Dispose();
            }
        }

        private List<String> DirSearch(string sDir,int pCode)
        {
            List<String> files = new List<String>();
            try
            {
                JPerson Person = null;
                if (pCode > 0)
                {
                    Person = new JPerson(pCode);
                }
                String DescImage = "";
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (Person != null)
                    {
                        string filename = Path.GetFileName(f);
                        int TypeImage = 3;
                        if (filename.IndexOf(tbImage.Text) > -1 && Path.GetExtension(filename).ToLower().Replace(".","") == "jpg")
                        {
                            TypeImage = 1;
                        }
                        else
                            if (filename.IndexOf(tbEmza.Text) > -1 && Path.GetExtension(filename).ToLower().Replace(".", "") == "jpg")
                            {
                                TypeImage = 2;
                            }
                            else
                            {
                                String[] AlDesc = tbDesc.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                                foreach (String S in AlDesc)
                                {
                                    string[] Desc = S.Split(new char[] { '=' });
                                    if (filename.IndexOf(Desc[0]) > -1)
                                    {
                                        DescImage = Desc[1];
                                        break;
                                    }
                                }
                            }
                        JFile F = new JFile();
                        F.FileName = f;
                        if (DescImage == "")
                            DescImage = filename;
                        if (filename != "Thumbs.db")
                        {
                            Archive(F, Person, TypeImage, DescImage);
                            F.Delete();
                        }
                    }
                    files.Add(f);
                }
                Person = null;
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    int tCode = 0;
                    Int32.TryParse(Path.GetFileName(d), out tCode);
                    if (tCode > 0)
                        files.AddRange(DirSearch(d, tCode));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }
    }
}
