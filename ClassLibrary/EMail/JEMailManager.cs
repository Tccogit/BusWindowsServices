using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Net.Mail;
using LumiSoft.Net.POP3.Client;
using LumiSoft.Net;
using LumiSoft.Net.Mime;
using LumiSoft.Net.SMTP.Client;
using Automation;

namespace ClassLibrary.EMail
{
    public class JEMailManager
    {
        public const string _ConstClassName = "ClassLibrary.EMail.JEMailManager";

        public int Code;
        public string UID;
        public string Subject;
        public AddressList From;
        public AddressList To;
        public AddressList CC;
        public AddressList BCC;
        public string Text;
        public string HTML;
        public MimeEntity[] Attachments;
        public DateTime DateSent;

        private string _server;
        private string _user;
        private string _password;
        private List<string> _uids;

        public JEMailManager(string pServer, string pUser, string pPassword)
        {
            _server = pServer;
            _user = pUser;
            _password = pPassword;
        }
        public JEMailManager()
        {
        }

        public List<JEMailManager> GetMail(int emailCode)
        {
            using (POP3_Client c = new POP3_Client())
            {
                try
                {
                    c.Connect(_server, WellKnownPorts.POP3);
                    c.Authenticate(_user, _password, true);

                    // Get first message if there is any
                    if (c.Messages.Count > 0)
                    {
                        List<JEMailManager> jEMailManagers = new List<JEMailManager>();

                        foreach (POP3_ClientMessage message in c.Messages)
                        {
                            if (JEMailReceiveds.isEmailInDB(message.UID, emailCode) == true)
                            {
                                message.MarkForDeletion();
                                continue;
                            }
                            Mime m = Mime.Parse(message.MessageToByte());
                            jEMailManagers.Add(ProcessMessage(m, message.UID));
                            message.MarkForDeletion();
                        }
                        return jEMailManagers;
                    }
                    return null;
                }
                catch { }
                finally
                {
                    if (c.IsConnected) c.Disconnect();
                    if (!c.IsDisposed) c.Dispose();
                }
            }
            return null;
        }

        private JEMailManager ProcessMessage(Mime m, string uid)
        {
            JEMailManager jEMailManager = new JEMailManager();
            jEMailManager.Subject = m.MainEntity.Subject;
            jEMailManager.From = m.MainEntity.From;
            jEMailManager.To = m.MainEntity.To;
            jEMailManager.CC = m.MainEntity.Cc;
            jEMailManager.BCC = m.MainEntity.Bcc;

            jEMailManager.Text = m.BodyText;
            jEMailManager.HTML = m.BodyHtml;
            

            jEMailManager.DateSent = m.MainEntity.Date;
            jEMailManager.UID = uid;

            jEMailManager.Attachments = m.Attachments;
            return jEMailManager;
        }

        public void ReferShow(int pCode, int referCode)
        {
            EmailReceivedForm emailReceivedForm = new EmailReceivedForm(pCode, referCode);
            emailReceivedForm.ShowDialog();
        }
    }

    public class JEMailManagers
    {
        public JEMailManagers() { 

}
        public void ProccessEmails()
        {
            DataTable emailReceived = JEMailReceiveds.GetUnProccessedEmails();
            foreach (DataRow email in emailReceived.Rows)
            {
                DataTable dt = JEMailReceiveds.GetCustomDataTable("Code=" + email["Code"].ToString());
                // Send To WorkFlow
                SendToWrokFlow(JEMailManager._ConstClassName, 0, dt);
                JEMailReceiveds.ChangeStatusToProccessed(Convert.ToInt32(email["Code"]));
            }
        }
        public void CheckEmails()
        {
            try
            {
                DataTable emails = JEMails.GetDataTable();
                foreach (DataRow email in emails.Rows)
                {
                    if (Convert.ToBoolean(email["AutoSync"]) == false) continue;
                    List<JEMailManager> jEMailManager = new JEMailManager(email["ServerName"].ToString(), email["UserName"].ToString(), email["Password"].ToString()).GetMail(Convert.ToInt32(email["Code"]));
                    if (jEMailManager != null)
                        foreach (JEMailManager item in jEMailManager)
                        {
                            try
                            {
                                JEMailReceived jEMailReceived = new JEMailReceived();
                                jEMailReceived.BCC = GetAddresses(item.BCC);
                                jEMailReceived.CC = GetAddresses(item.CC);
                                jEMailReceived.EmailCode = Convert.ToInt32(email["Code"]);
                                jEMailReceived.HTML = item.HTML;
                                jEMailReceived.MessageFrom = GetAddresses(item.From);
                                jEMailReceived.MessageTo = GetAddresses(item.To);
                                jEMailReceived.Subject = item.Subject;
                                jEMailReceived.Text = item.Text;
                                jEMailReceived.UID = item.UID;
                                jEMailReceived.DateSent = item.DateSent;
                                jEMailReceived.Relevant_Person_Code = JEMailReceiveds.GetRelevantPerson(jEMailReceived.MessageFrom);

                                int code = jEMailReceived.Insert();
                                if (code > 0)
                                {
                                    //  Archive Attachments
                                    foreach (MimeEntity attachment in item.Attachments)
                                    {
                                        ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument("Email", 0);
                                        JFile jFile = new JFile();
                                        jFile.FileName = attachment.ContentDisposition_FileName;
                                        jFile.FileSource = JFile.JFileSource.FromMemory;
                                        jFile.Content = attachment.Data;

                                        int a = jArchiveDocument.ArchiveDocument(jFile, JEMailManager._ConstClassName, code, jFile.FileName, false);
                                    }
                                }
                            }
                            catch { }
                        }
                }
            }
            catch { }
        }

        public string GetAddresses(AddressList mailAddresses)
        {
            if (mailAddresses == null) return "";
            string str = "";
            foreach (LumiSoft.Net.Mime.MailboxAddress mailAddress in mailAddresses)
            {
                str += "," + mailAddress.EmailAddress;
            }
            if (str.Length > 1) str = str.Substring(1);
            return str;
        }

        public void SendToWrokFlow(string _ClassName, int _DynamicClassCode, DataTable _PublicDataRow)
        {
            int _ReferCode = 0;
            JWorkFlow WorkFlow = new JWorkFlow(_PublicDataRow, _ReferCode);
            WorkFlow.ClassName = _ClassName;
            WorkFlow.DynamicClassCode = _DynamicClassCode;
            WorkFlow.GetFirst();
            JDataBase db = new JDataBase();
            try
            {
                int Receiver = (new JEMail(Convert.ToInt32(_PublicDataRow.Rows[0]["EmailCode"]))).UserPostCode;
                int _ObjectCode = Convert.ToInt32(_PublicDataRow.Rows[0]["Code"]); // SMS Code
                string _title = "ایمیل دریافتی";
                string _full_title = _PublicDataRow.Rows[0]["MessageFrom"].ToString();

                Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(Receiver);

                Automation.JARefer tmprefer = new Automation.JARefer();
                tmprefer.send_date_time = JDateTime.Now();

                tmprefer.sender_code = 0;
                tmprefer.sender_full_title = _full_title;
                tmprefer.sender_post_code = 0;
                tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
                tmprefer.receiver_full_title = jeoc.full_Name;
                tmprefer.receiver_post_code = Receiver;
                tmprefer.register_user_code = 0;
                tmprefer.register_Date_Time = JDateTime.Now();
                tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                tmprefer.is_active = true;
                tmprefer.ReferGroup = 1;
                tmprefer.parent_code = 0;
                tmprefer.description = "";
                tmprefer.WorkFlowCode = WorkFlow.Code;

                tmprefer.object_code = tmprefer.SendToAutomation(_ObjectCode,
                                                                "", _title, _ClassName, _DynamicClassCode, db,
                                                                _full_title, 0,
                                                                0, false, true);
                if (tmprefer.Send(db, true, true) > 0)
                {
                    WorkFlow.RUNSQL();
                    WorkFlow.RUNACTION();
                }
                else
                {
                    // Error
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        public bool SendEMails()
        {
            using (SMTP_Client smtp = new SMTP_Client())
            {
                try
                {
                    DataTable emails = JEMailSends.GetCustomeDataTable("Status=" + Domains.JClassLibrary.JEMailStatus.ReadyForSend.ToString());
                    
                    foreach (DataRow email in emails.Rows)
                    {
                        try
                        {
                            JEMail jEMailInfo = new JEMail(Convert.ToInt32(email["EmailCode"]));
                            // If you have registered DNS host name, set it here before connecting.
                            // That name will be reported to SMTP server.
                            // smtp.LocalHostName = "mail.domain.com";

                            // You can use SMTP_Client.GetDomainHosts(... to get target receipient SMTP hosts for Connect method.
                            smtp.Connect(jEMailInfo.ServerName, WellKnownPorts.SMTP);
                            smtp.EhloHelo(jEMailInfo.ServerName);
                            // Authenticate if target server requires.
                            smtp.Authenticate(jEMailInfo.UserName, jEMailInfo.Password);

                            smtp.MailFrom(jEMailInfo.UserName, -1);
                            // Repeat this for all recipients.
                            foreach (string mailAddress in email["MessageTo"].ToString().Split(';'))
                                smtp.RcptTo(mailAddress);

                            // Send message to server.
                            // You can send any valid SMTP message here, from disk,memory, ... or
                            // you can use LumiSoft.Net.Mime mieclasses to compose valid SMTP mail message.
                            // Creating message with text and attachments
                            Mime m = new Mime();
                            MimeEntity mainEntity = m.MainEntity;
                            // Force to create From: header field
                            mainEntity.From = new AddressList();
                            mainEntity.From.Add(new MailboxAddress(jEMailInfo.UserName));
                            // Force to create To: header field
                            mainEntity.To = new AddressList();
                            foreach (string mailAddress in email["MessageTo"].ToString().Split(';'))
                                mainEntity.To.Add(new MailboxAddress(mailAddress));
                            mainEntity.Subject = email["Subject"].ToString();
                            mainEntity.ContentType = MediaType_enum.Multipart_mixed;

                            MimeEntity textEntity = mainEntity.ChildEntities.Add();
                            textEntity.ContentType = MediaType_enum.Text_plain;
                            textEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
                            textEntity.DataText = email["Text"].ToString();

                            // Add Attachments
                            ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument("Email", 0);
                            DataTable archives = jArchiveDocument.Retrieve(EmailSendForm._ConstClassName, Convert.ToInt32(email["Code"]), null);
                            if (archives != null)
                                foreach (DataRow archive in archives.Rows)
                                {
                                    JFile jFile = jArchiveDocument.RetrieveContent(Convert.ToInt32(archive["Code"]));

                                    MimeEntity attachmentEntity = mainEntity.ChildEntities.Add();
                                    attachmentEntity.ContentType = MediaType_enum.Application_octet_stream;
                                    attachmentEntity.ContentDisposition = ContentDisposition_enum.Attachment;
                                    attachmentEntity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
                                    attachmentEntity.ContentDisposition_FileName = jFile.FileName + jFile.Extension;
                                    attachmentEntity.DataFromStream((new MemoryStream(jFile.Content)));
                                }
                            MemoryStream stream = new MemoryStream();
                            m.ToStream(stream);
                            stream.Position = 0;
                            try
                            {
                                smtp.SendMessage(stream);

                                JEMailSend jEmailSend = new JEMailSend(Convert.ToInt32(email["Code"]));
                                jEmailSend.Status = Domains.JClassLibrary.JEMailStatus.Sent;
                                jEmailSend.DateSent = DateTime.Now;
                                jEmailSend.Update();
                            }
                            catch
                            {
                                JEMailSend jEmailSend = new JEMailSend(Convert.ToInt32(email["Code"]));
                                jEmailSend.Status = Domains.JClassLibrary.JEMailStatus.SendError;
                                jEmailSend.DateSent = DateTime.Now;
                                jEmailSend.Update();
                            }
                            smtp.Disconnect();
                        }
                        catch (Exception ex)
                        {
                            smtp.Disconnect();
                        }
                    }
                }
                catch (Exception er)
                {
                }
                return true;
            }
        }

        private AddressList ToAddressList(string addresses)
        {
            AddressList addressList = new AddressList();
            foreach (string email in addresses.Split(';'))
            {
                MailboxAddress mailbox = new MailboxAddress(email);
                addressList.Add(mailbox);
            }
            return addressList;
        }
    }

}
