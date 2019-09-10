using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Infra.Data.Security;
using Domain.Entity;
using System.Net;

namespace PresentationIO.Controllers.Api
{
    [RoutePrefix("api/Auth")]
    public class GetTokenController
    {
        [Route("Token")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage Authenticate(HttpRequestMessage request, [FromBody]string login, [FromBody]string password)
        {
            IGenerateToken credentials = new GenerateToken();
            User user = credentials.GetCredentials(login, password);

            if (user != null)
            {
                string token = credentials.CreateToken(user);
                return request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Não autorizado");
            }
        }
    }
}