using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using ms_notificaciones.Models;


[ApiController]
[Route("[controller]")]
public class NotificacionesController : ControllerBase
{
    [Route("correo")]
    [HttpPost]
   public async Task<IActionResult> EnviarCorreo(ModeloCorreo datos)
   {
            var apiKey = Environment.GetEnvironmentVariable("SENGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("adsinotificaciones@gmail.com", "Adsi");
            var subject = datos.asuntoCorreo;
            var to = new EmailAddress(datos.correoDestino, datos.nombreDestino);
            var plainTextContent = "plain text content";
            var htmlContent = datos.contenidoCorreo;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
            if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                return Ok("Correo enviado correctamente" + datos.correoDestino);
            }
            else
            {
                var responseBody = await response.Body.ReadAsStringAsync();
                return BadRequest($"No se pudo enviar el correo a la dirección: {datos.correoDestino}. Código de estado: {response.StatusCode}. Error: {responseBody}");
            }
   }
}