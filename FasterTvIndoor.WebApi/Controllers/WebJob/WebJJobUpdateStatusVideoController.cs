using FasterTvIndoor.Domain.FasterAdministration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FasterTvIndoor.WebApi.Controllers.WebJob
{
    public class WebJJobUpdateStatusVideoController : BaseController
    {
        private readonly IVideoEquipmentApplicationService _service;

        public WebJJobUpdateStatusVideoController(IVideoEquipmentApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/webjob/updatestatusvideo")]
        public Task<HttpResponseMessage> GetAll()
        {
            _service.UpdateStatusListVideo();
            return CreateResponse(HttpStatusCode.OK, null);
        }
    }
}
