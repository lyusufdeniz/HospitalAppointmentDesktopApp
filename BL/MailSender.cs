using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MailSender
    {
   
        public bool sendMail(string mail,string adsoyad,DateTime tarih,string bulgu,string yorum,string ilac)
        {
            try
            {
                MailAddress to = new MailAddress(mail);
                MailAddress from = new MailAddress("foreverapp@yandex.com");
                IronPdf.ChromePdfRenderer Renderer = new IronPdf.ChromePdfRenderer();
                // add a footer too
                Renderer.RenderingOptions.TextFooter.DrawDividerLine = true;
                Renderer.RenderingOptions.TextFooter.FontFamily = "Arial";
                Renderer.RenderingOptions.TextFooter.FontSize = 16;
                Renderer.RenderingOptions.TextFooter.LeftText = "{date} {time}";
                Renderer.RenderingOptions.TextFooter.RightText = "{page} of {total-pages}";
                string htmlText = "<h2 style=\"text-align:center\"><span style=\"font-size:14px\"><strong>HASTANE OTOMASYONU BİLGİ MESAJI</strong></span></h2>\r\n\r\n<p><em><span style=\"font-size:14px\">MERHABA SAYIN " + adsoyad + " " + tarih + " TARİHLİ RANDEVUNUZUN MUAYENE BULGULARI AŞAĞIDA BELİRTİŞMİŞTİR</span></em></p>\r\n\r\n<h3><strong>TANILAR</strong></h3>\r\n\r\n<p>" + bulgu + "</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<h3><strong>İLA&Ccedil;LAR</strong></h3>\r\n\r\n<p>" + ilac + "</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<h3><strong>YORUMLAR</strong></h3>\r\n\r\n<p>" + yorum + "</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<p style=\"text-align:right\">SAĞLIKLI G&Uuml;NLER DİLERİZ</p>\r\n"; ;
               Renderer.RenderHtmlAsPdf(htmlText).SaveAs("output.pdf");
                MailMessage email = new MailMessage(from, to);
                email.Subject = "MUAYENE BULGULARI";
                email.Body ="Muayene Bulguları Ektedir" ;
                email.Attachments.Add(new Attachment("output.pdf"));
                email.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.yandex.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("foreverapp@yandex.com", "FR74KHC5");
              
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(email);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
           
    }

