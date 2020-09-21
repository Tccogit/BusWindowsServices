using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ClassLibrary
{
    struct NotifyStruct
    {
        public string Title;
        public string Text;
        public JAction Action;
    }

    public class JNotifiCationManager
    {
        public int Code { get; set; }
        public int PostCode { get; set; }
        public string Message { get; set; }
        public bool Visite { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateVisite { get; set; }
        public int ObjectCode { get; set; }
        public string Action { get; set; }

        public int Insert()
        {
            return Insert(false);
        }
        public int Insert(bool pManualInsert)
        {
            JNotifyCationTable NCT = new JNotifyCationTable();
            NCT.SetValueProperty(this);
            if (pManualInsert == true) NCT.Set_ComplexInsert(false);
            return NCT.Insert();
        }

        public bool Update()
        {

            try
            {
                JNotifyCationTable NCT = new JNotifyCationTable();
                NCT.SetValueProperty(this);
                return NCT.Update();
            }
            catch
            {
            }
            return false;
        }

        public bool SetVisite(int pCode)
        {
            return false;
        }

        public System.Data.DataTable GetNew()
        {
            JDataBase db = new JDataBase();
            try
            {
                //return null;
                db.setQuery(@"select * from Notification where visite = 0 and PostCode = " + JMainFrame.CurrentPostCode.ToString()+ @"
                            UNION 
                            select R.Code,R.sender_post_code,' یک '+O.title+' از '+isnull(R.sender_full_title,''),0,send_date_time,null,object_code,null 
                            from Refer R inner join Objects O on R.object_code=O.Code
                            where status=1 and view_date_time is null and receiver_post_code = " + JMainFrame.CurrentPostCode.ToString()+
                            " update Notification set  visite = 1 , DateVisite= getDate() where  visite = 0 and PostCode = " + JMainFrame.CurrentPostCode.ToString());
                JDataTable _DT =  (JDataTable)db.Query_DataTable();
                _DT.RemoveDuplicateRows("ObjectCode");
                return _DT;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }

        public void Show(string pTitle, string pText, int pPostCode, string pAction, int pObjectCode)
        {
            Show(pTitle, pText, pPostCode, pAction, pObjectCode, false);
        }
        public void Show(string pTitle, string pText,int pPostCode, string pAction, int pObjectCode, bool pManualInsert)
        {
            Message = pText;
            PostCode = pPostCode;
            Action = pAction;
            ObjectCode = PostCode;
            DateSend = JDateTime.Now();
            DateVisite = DateTime.MinValue;
            Visite = false;
            Insert(pManualInsert);
        }
    }

    public class JNotifyCation
    {

        private static NotifyIcon Notifyicon;
        private static ContextMenuStrip ContextMenustrip;
        private static JAction CurrentAction;
        private static int TimeOut = 1000*60;
        private static NotifyStruct[] Queu = new NotifyStruct[0];
        private static Timer timer;
        private static JNotShowForm NotShowForm;

        public JNotifyCation()
        {
        }

        static Timer T;
        public static void Start()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = TimeOut;
                timer.Tick += new EventHandler(timer_Tick);

                T = new Timer();
                T.Interval = 5000;
                T.Tick += new EventHandler(T_Ticke);
            }
            timer.Start();
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            GetNew();
            if (Queu.Length == 0) return;
            while (Queu.Length>0)
            {
                NotifyStruct N = getQueu();
                ShowBaloon(N.Title, N.Text, N.Action);
            }
            T.Start();
        }
        static void T_Ticke(object sender, EventArgs e)
        {
            T.Stop();

            if (NotShowForm != null)
                NotShowForm.Close();

        }

        public static void Stop()
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }

        public static void Notifyicon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (CurrentAction != null)
                CurrentAction.run();
        }

        private static void AddQueu(string pTitle, string pText, JAction pAction)
        {
            Array.Resize(ref Queu, Queu.Length + 1);
            Queu[Queu.Length - 1].Action = pAction;
            Queu[Queu.Length - 1].Text = pText;
            Queu[Queu.Length - 1].Title = pTitle;
        }

        private static void Shift()
        {
            for (int i = 1; i < Queu.Length - 1; i++)
            {
                Queu[i - 1] = Queu[i];
            }
            Array.Resize(ref Queu, Queu.Length - 1);
        }

        private static NotifyStruct getQueu()
        {
            NotifyStruct N = new NotifyStruct();
            if (Queu.Length > 0)
            {
                N.Title = Queu[0].Title;
                N.Text = Queu[0].Text;
                N.Action = Queu[0].Action;
                Shift();
            }
            return N;
        }

        private static void ShowBaloon(string pTitle, string pText, JAction pAction)
        {
            try
            {
                System.Media.SystemSounds.Beep.Play();
                if (NotShowForm == null)
                {
                    NotShowForm = new JNotShowForm();
                }
                try
                {
                    NotShowForm.Show();
                }
                catch
                {
                    NotShowForm = null;
                    NotShowForm = new JNotShowForm();
                    NotShowForm.Show();
                }
                NotShowForm.SetText(pTitle + Environment.NewLine + pText);
                NotShowForm.TopMost = true;
            }
            catch
            {
            }
        }

        static private void GetNew()
        {
            System.Data.DataTable DT;
            try
            {
                JNotifiCationManager NCM = new JNotifiCationManager();
                if (!JDataBase.isTransaction)
                {
                    DT = NCM.GetNew();
                    if (DT != null && DT.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow _DR in DT.Rows)
                        {
                            JAction Action = null;
                            if (_DR["Action"].ToString().Length > 0)
                                Action = new JAction("Open...", (string)_DR["Action"], new object[] { Convert.ToInt32(_DR["ObjectCode"]) }, null);
                            AddQueu("", (string)_DR["Message"], Action);
                        }
                        if (DT != null)
                            DT.Dispose();
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

    }
}
