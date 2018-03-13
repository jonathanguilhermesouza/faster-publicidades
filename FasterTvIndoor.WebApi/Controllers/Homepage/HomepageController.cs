using FasterTvIndoor.Domain.Homepage;
using FasterTvIndoor.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.Homepage
{
    public class HomepageController : BaseController
    {

        [HttpPost]
        [Route("api/homepage/")]
        public Task<HttpResponseMessage> SendEmail([FromBody]dynamic body)
        {


            var email = new Email(
                subject: (string)body.subject,
                description: (string)body.description,
                phone: (string)body.phone,
                email: (string)body.email,
                name: (string)body.name
                );

            SendEmail send = new SendEmail();
            send.SendEmailFromWebSite(email.Subject,email.Description, email.EmailUser, email.Phone, email.Name);

            return CreateResponse(HttpStatusCode.OK, email);
        }
    }
}
