//using FasterTvIndoor.Domain.FasterAdministration.Enum;
//using FasterTvIndoor.Domain.FasterAdministration.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;

//namespace FasterTvIndoor.WebApi.Controllers.Client
//{
//    public class BalanceVideoEquipmentController : BaseController
//    {

//        private readonly IBalanceApplicationService _service;

//        public BalanceVideoEquipmentController(IBalanceApplicationService service)
//        {
//            this._service = service;
//        }

//        [HttpGet]
//        [Route("api/balance/{id}")]
//        public Task<HttpResponseMessage> GetByRange(int id)
//        {
//            var balance = _service.GetByRange(1, 6, EStatusVideo.Ativo, "");
//            return CreateResponse(HttpStatusCode.OK, balance);
//        }

//    }
//}