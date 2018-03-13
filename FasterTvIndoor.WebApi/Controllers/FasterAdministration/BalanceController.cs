//using FasterTvIndoor.Domain.FasterAdministration.Enum;
//using FasterTvIndoor.Domain.FasterAdministration.Services;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace FasterTvIndoor.WebApi.Controllers.FasterAdministration
//{
//    public class BalanceController : BaseController
//    {

//        private readonly IBalanceApplicationService _service;
//        private readonly IVideoEquipmentApplicationService _service2;

//         public BalanceController(IBalanceApplicationService service, IVideoEquipmentApplicationService service2)
//        {
//            this._service = service;
//            this._service2 = service2;
//        }

//        [HttpGet]
//        [Route("api/balance")]
//        public Task<HttpResponseMessage> GetAll()
//        {
//            var balance = _service.GetAll();
//            return CreateResponse(HttpStatusCode.OK, balance);
//        }

//        [HttpGet]
//        [Route("api/balance/{skip}/{status}/{word}")]
//        public Task<HttpResponseMessage> GetByRange(int skip, int take, EStatusVideo status, string word)
//        {
//            var balance = _service.GetByRange(skip, take = 6, status, word);
//            return CreateResponse(HttpStatusCode.OK, balance);
//        }
//    }
//}