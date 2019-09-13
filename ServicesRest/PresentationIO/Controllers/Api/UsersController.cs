using Autopecas.Utils.Encrypt;
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

    [Authorize]
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
                    foreach (User u in users)
                    {
                        u.Password = null;
                    }
                }
                return request.CreateResponse<List<User>>(HttpStatusCode.OK, users);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível listar os usuários [" + e.Message + "]");
            }
        }
        [AcceptVerbs("GET")]
        [Route("Find/{id}")]
        public HttpResponseMessage Find(HttpRequestMessage request, int id)
        {
            try
            {
                using (UserRepository rep = new UserRepository())
                {
                    User user = rep.Find(id);
                    user.Password = null;

                    if (user != null)
                    {
                        return request.CreateResponse<User>(HttpStatusCode.Accepted, user);
                    }
                    else
                    {
                        return request.CreateErrorResponse(HttpStatusCode.NotFound, "Não foi possível localizar usuário!");
                    }
                }
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        public HttpResponseMessage Add(HttpRequestMessage request, User user)
        {
            try
            {
                using (UserRepository rep = new UserRepository())
                {
                    user.Password = HashingPassword.HashPassword(user.Password);
                    rep.Add(user);
                    rep.SaveAll();
                }
                user.Password = null;
                return request.CreateResponse<User>(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível inserir usuário [" + e.Message + "]");
            }
        }


        [Route("Update")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage Update(HttpRequestMessage request, User user, int? modify)
        {
            try
            {
                using (UserRepository rep = new UserRepository())
                {
                    rep.Update(user);
                    rep.SaveAll();
                }
                return request.CreateResponse<User>(HttpStatusCode.Accepted, user);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [Route("Delete/{id}")]
        [AcceptVerbs("DELETE")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            try
            {
                using (UserRepository rep = new UserRepository())
                {
                    rep.Delete((u => u.ID == id));
                    rep.SaveAll();
                }
                return request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
