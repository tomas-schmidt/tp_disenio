using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

 
 namespace tp_disenio_1.Reportes
 {

    class Mail
     {
        private string mailAdmin;

        public Mail()
        {
            mailAdmin = "gaby_filipe@hotmail.com";
        }

    public void enviarMail(string textoDemorado)

    {
        MailMessage email = new MailMessage();
        email.To.Add(new MailAddress(mailAdmin));
        email.From = new MailAddress("gabriel_prueba00@hotmail.com");
        email.Subject = "Demora en la busqueda ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
        email.Body = "La busqueda del texto:" + textoDemorado +"esta tardando mas de lo esperado.";
        email.IsBodyHtml = true;
        email.Priority = MailPriority.Normal;

        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.outlook.com";
        smtp.Port = 587;
        smtp.EnableSsl = false;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("gabriel_prueba00@hotmail.com", "123prueba");

        string output = null;

        try
        {
            smtp.Send(email);
            email.Dispose();
            output = "Corre electrónico fue enviado satisfactoriamente.";
        }
        catch (Exception ex)
        {
            output = "Error enviando correo electrónico: " + ex.Message;
        }

        Console.WriteLine(output);

    }

    }

}

 