using Domain.Entity;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Documents;

namespace PresentationIO.Controllers.Api
{
    
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [Route("GetAll")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                List<User> users;
                using (UserRepository repository = new UserRepository())
                {
                    users = repository.GetAll().ToList<User>();
                }
                return request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível listar os usuários [" + e.Message + "]");
            }
        }
    }
}
