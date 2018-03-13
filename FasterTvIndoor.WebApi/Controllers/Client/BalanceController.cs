using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FasterTvIndoor.WebApi.Controllers.Client
{
    public class BalanceController : BaseController
    {

        private readonly IBalanceApplicationService _service;

        public BalanceController(IBalanceApplicationService service)
        {
            this._service = service;
        }

        //[HttpGet]
        //[Route("api/balance")]
        //public Task<HttpResponseMessage> GetAll()
        //{
        //    var balance = _service.GetAll();
        //    return CreateResponse(HttpStatusCode.OK, balance);
        //}

        [HttpGet]
        //[ActionName("all")]
        [Route("api/balance/getbyrange/{skip}/{take}/{status}/{id}")]
        public Task<HttpResponseMessage> GetByRange(int skip, int take, EStatusVideo status, int id)
        {
            var balance = _service.GetByRange(skip, take, status, id, "");
            return CreateResponse(HttpStatusCode.OK, balance);
        }

        [HttpGet]
        [Route("api/balance/getcount/{id}/{word}")]
        public Task<HttpResponseMessage> GetCount(string word,int id)
        {
            var countBalance = _service.GetCount(word,id);
            return CreateResponse(HttpStatusCode.OK, countBalance);
        }
    }
}