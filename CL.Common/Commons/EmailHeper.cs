using System;
using System.Web.Mail;
using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace CL.Common
{

    /// <summary>
    /// 作者：张学林
    /// 日期：2014-10-10
    /// 说明：
    /// ①C#邮件发送类 V1.0
    /// ②支持批量(发送、抄送、密送)
    /// ③支持多语言、带多个附件
    /// ④支持smtp发送邮件服务器验证
    /// </summary>
    public class EmailHeper
    {
        #region 邮件发送必备
        /// <summary>
        /// 构造函数
        /// </summary>
        public EmailHeper()
        { }

        /**/
        /// <summary>
        /// 邮件发送结果。如果发送过程出现错误，该值为捕获到的异常提示；否则，该值为“OK”。
        /// </summary>
        public string SendMailResult
        {
            get
            {
                return this.m_SendMailResult;
            }
            set
            {
                this.m_SendMailResult = value;
            }
        }
        private string m_SendMailResult;

        #endregion
          
        #region 邮件发送时，额外的功能属性设置#region 邮件发送时，额外的功能属性设置
        /**/
        /// <summary>
        /// 抄送地址(集合)
        /// </summary>
        public List<string> Cc
        {
            set
            {
                this.m_Cc = value;
            }
        }
        private List<string> m_Cc;

        /**//// <summary>
        /// 密送地址，多个以逗号隔开
        /// </summary>
        public List<string> Bcc
        {
            set
            {
                this.m_Bcc = value;
            }
        }
        private List<string> m_Bcc;

        /**//// <summary>
        /// 邮件格式。可以赋值为“1”或“2”，“1”表示Html格式，“2”表示Text格式。
        /// </summary>
        public int BodyFormat
        {
            set
            {
                this.m_BodyFormat = value;
            }
        }
        private int m_BodyFormat = 1;

        /**//// <summary>
        /// 邮件格式。可以赋值为“1”、“2”或“3”。
        ///“1”表示不紧急邮件，“2”表示普通邮件， “3”表示紧急邮件
        /// </summary>
        public int MailPriority
        {
            set
            {
                this.m_MailPriority = value;
            }
        }
        private int m_MailPriority = 2;

        /**//// <summary>
        /// 附件地址列表，用该属性Add方法加入多个附件，附件地址必须是绝对路径
        /// </summary>
        public ArrayList AttachFiles
        {
            get
            {
                return this.m_AttachFiles;
            }
            set
            {
                this.m_AttachFiles = value;
            }
        }
        ArrayList m_AttachFiles = new ArrayList();

        #endregion

        #region 邮件发送的方法
        /**/
        /// <summary>
        /// 发送邮件方法,方法中几个参数是发邮件时所必须的
        /// </summary>
        /// <param name="p_From">发件人</param>
        /// <param name="p_To">邮件人，多个收件人逗号隔开</param>
        /// <param name="p_Subject">邮件标题</param>
        /// <param name="p_Body">正文</param>
        /// <param name="p_SmtpServer">发送邮件服务器</param>
        /// <param name="p_SmtpUsername">发件服务器登录名</param>
        /// <param name="p_SmtpPassword">发件服务器登录密码</param>
        /// <returns></returns>
        public bool SendMail(string p_From, List<string> p_To, string p_Subject, string p_Body, string p_SmtpHost,int p_SmtpPot, string p_SmtpUsername, string p_SmtpPassword)
        {
            try
            {
                SmtpClient smtpServer = new SmtpClient(p_SmtpHost, p_SmtpPot);                  //发送邮件服务器
                smtpServer.Credentials = new NetworkCredential(p_SmtpUsername, p_SmtpPassword);  //服务器用户名、密码

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();            //待发邮件对象                               
                mail.From = new MailAddress(p_From);                                             //发件人
                foreach (var item in p_To)                                                       //收件人
                {
                    mail.To.Add(item);
                }
                mail.Subject = p_Subject;                                                        //邮件主题
                mail.Body = p_Body;                                                              //邮件内容

                //以上是发邮件时所必需的，下面是额外的一些功能设置

                //抄送
                if (this.m_Cc != null && this.m_Cc.Count > 0)
                {
                    foreach (var item in this.m_Cc)
                    {
                        mail.CC.Add(new MailAddress(item));
                    }

                }
                //密送
                if (this.m_Bcc != null && this.m_Bcc.Count > 0)
                {
                    foreach (var item in this.m_Bcc)
                    {
                        mail.Bcc.Add(new MailAddress(item));
                    }
                }

                //邮件主题的格式
                switch (this.m_BodyFormat)
                {
                    case 1:
                        mail.IsBodyHtml = true;
                        break;
                    case 2:
                        mail.IsBodyHtml = false;
                        break;
                    default:
                        break;
                }

                //邮件优先级
                switch (this.m_MailPriority)
                {
                    case 1:
                        mail.Priority = System.Net.Mail.MailPriority.Low;
                        break;
                    case 2:
                        mail.Priority = System.Net.Mail.MailPriority.Normal;
                        break;
                    case 3:
                        mail.Priority = System.Net.Mail.MailPriority.High;
                        break;
                    default:
                        break;
                }

                //附件
                if (this.m_AttachFiles.Count > 0)
                {
                    foreach (string file in m_AttachFiles)
                    {
                        if (file.Trim() != "")
                        {
                            //循环添加附件
                            mail.Attachments.Add(new Attachment(file.Trim()));
                        }
                    }
                }

                //发送
                smtpServer.Send(mail);

                //返回的结果
                this.m_SendMailResult = "OK";
                return true;
            }

            //获取到邮件发送的异常结果
            catch (Exception ex)
            {
                this.m_SendMailResult = ex.ToString();
                return false;
            }

        }
        #endregion
    }
}