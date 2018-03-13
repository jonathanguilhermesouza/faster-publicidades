using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace FasterTvIndoor.SharedKernel.Helpers
{
    public class SendEmail
    {
        public void SendEmailFromWebSite(string subject, string description, string emailUser, string phone, string name)
        {
            /*//crio objeto responsável pela mensagem de email
            MailMessage objEmail = new MailMessage();

            //rementente do email
            objEmail.From = new MailAddress("contato@fastertecnologia.com.br");

            //email para resposta(quando o destinatário receber e clicar em responder, vai para:)
            objEmail.ReplyTo = new MailAddress("contato@fastertecnologia.com.br");

            //destinatário(s) do email(s). Obs. pode ser mais de um, pra isso basta repetir a linha
            //abaixo com outro endereço
            objEmail.To.Add("jonathanguilhermesouza@gmail.com");

            //se quiser enviar uma cópia oculta pra alguém, utilize a linha abaixo:
            //objEmail.Bcc.Add("oculto@provedor.com.br");

            //prioridade do email
            objEmail.Priority = MailPriority.Normal;

            //utilize true pra ativar html no conteúdo do email, ou false, para somente texto
            objEmail.IsBodyHtml = true;

            //Assunto do email
            objEmail.Subject = "Assunto";

            //corpo do email a ser enviado
            objEmail.Body = "Conteúdo do email. Se ativar html, pode utilizar cores, fontes, etc.";

            //codificação do assunto do email para que os caracteres acentuados serem reconhecidos.
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");

            //codificação do corpo do emailpara que os caracteres acentuados serem reconhecidos.
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //cria o objeto responsável pelo envio do email
            SmtpClient objSmtp = new SmtpClient();

            //endereço do servidor SMTP(para mais detalhes leia abaixo do código)
            objSmtp.Host = "smtplw.com.br";
            objSmtp.Port = 587;
            objSmtp.Timeout = 500;

//para envio de email autenticado, coloque login e senha de seu servidor de email
//para detalhes leia abaixo do código
            objSmtp.Credentials = new NetworkCredential("contato@fastertecnologia.com.br", "@!Nf0#10");

            //envia o email
            objSmtp.Send(objEmail);*/



            //opção 2
            /*string from = "contato@fastertecnologia.com.br"; // E-mail de remetente cadastrado no painel
            string to = "jonathanguilhermesouza@gmail.com";   // E-mail do destinatário
            string user = ""; // Usuário de autenticação do servidor SMTP
            string pass = ""; // Senha de autenticação do servidor SMTP

            MailMessage message = new MailMessage(from, to, "SMTP Locaweb Teste", "Eu sou o corpo da mensagem");

            using (SmtpClient smtp = new SmtpClient("smtplw.com.br", 587))
            {
                smtp.Credentials = new NetworkCredential(user, pass);
                smtp.Send(message);
            }

            Console.WriteLine("Mensagem enviada com sucesso!");
            Console.Read();*/

            //Define os dados do e-mail
            string nomeRemetente = "Site - Faster Technology";
            string emailRemetente = "contato@fastertecnologia.com.br";

            string emailDestinatario = "contato@fastertecnologia.com.br";
            string emailComCopia = "jonathan.guilherme@fastertecnologia.com.br";
            //string emailComCopiaOculta = "wagner.rodrigues@fastertecnologia.com.br";

            string nameUser = name;
            string phoneUser = phone;

            string assuntoMensagem = subject;
            string conteudoMensagem = description;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Enviar cópia para.
            objEmail.CC.Add(emailComCopia);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            objEmail.Body = GetFormattedMessageHTML(assuntoMensagem, nameUser, phoneUser, emailUser, description);
            
            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            //objEmail.Body = conteudoMensagem;


            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagem
            //objEmail.Attachments.Add(anexo);

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, "@!Nf0#10");
            objSmtp.Host = "pop.fastertecnologia.com.br";
            objSmtp.Port = 587;
            //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
            //objEmail.EnableSsl = true;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
               // Response.Write("E-mail enviado com sucesso !");
            }
            catch (Exception ex)
            {
               // Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }

        }

        private String GetFormattedMessageHTML(string subject, string name, string phone, string email, string description)
        {
            return "<!DOCTYPE html> " +
                "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
                "<head>" +
                    "<title>Site - Faster Technology</title>" +
                "</head>" +
                "<body style=\"font-family:'Arial'\">" +
                    "<h1 style=\"text-align:center;\"> " + subject + "</h1><br />" +
                    "<h2 style=\"font-size:14px;\">" +
                        "Nome : " + name + "<br />" +
                        "Telefone : " + phone + "<br />" +
                        "Email : " + email +
                    "</h2>" +
                    "<p>" + description + "</p><br /><br /><br />" +
                    "<p>Atenciosamente,</p><br />" +
                    "<img src='https://fasterpublicidades.blob.core.windows.net/imagens/logo-faster-publicidades.png' width='100' height='100'>" +
            "</body>" +
                "</html>";
        }
    }
}
