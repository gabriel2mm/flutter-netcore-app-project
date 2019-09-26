using Domain.Entity;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Model")]
    public class ModelController : ApiController
    {
        [Route("GetAll")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                List<Model> Models;
                using (ModelRepository repository = new ModelRepository())
                {
                    Models = repository.GetAll().ToList<Model>();
                }
                return request.CreateResponse<List<Model>>(HttpStatusCode.OK, Models);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível listar os usuários [" + e.Message + "]");
            }
        }
        [AcceptVerbs("GET")]
        [Route("FindByBrand/{id}")]
        public HttpResponseMessage findByBrand(HttpRequestMessage request, int id)
        {
            try
            {
                using (ModelRepository repository = new ModelRepository())
                {
                    List<Model> models = repository.Get((m => m.Brand.ID == id)).ToList<Model>();
                    return request.CreateResponse<List<Model>>(HttpStatusCode.OK, models);
                }
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
        [AcceptVerbs("GET")]
        [Route("FindByCategory/{id}")]
        public HttpResponseMessage FindByCategory(HttpRequestMessage request, int id)
        {
            try
            {
                using (ModelRepository repository = new ModelRepository())
                {
                    List<Model> models = repository.Get((m => m.Category.ID == id)).ToList<Model>();
                    return request.CreateResponse<List<Model>>(HttpStatusCode.OK, models);
                }
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [AcceptVerbs("GET")]
        [Route("Find/{id}")]
        public HttpResponseMessage Find(HttpRequestMessage request, int id)
        {
            try
            {
                using (ModelRepository rep = new ModelRepository())
                {
                    Model Model = rep.Find(id);

                    if (Model != null)
                    {
                        return request.CreateResponse<Model>(HttpStatusCode.Accepted, Model);
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

        [Route("Add")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage Add(HttpRequestMessage request, Model Model)
        {
            try
            {
                using (ModelRepository rep = new ModelRepository())
                {
                    rep.Add(Model);
                    rep.SaveAll();
                }
                return request.CreateResponse<Model>(HttpStatusCode.OK, Model);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível inserir usuário [" + e.Message + "]");
            }
        }


        [Route("Update")]
        [AcceptVerbs("PUT")]
        public HttpResponseMessage Update(HttpRequestMessage request, Model Model)
        {
            try
            {
                using (ModelRepository rep = new ModelRepository())
                {
                    rep.Update(Model);
                    rep.SaveAll();
                }
                return request.CreateResponse<Model>(HttpStatusCode.Accepted, Model);
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
                using (ModelRepository rep = new ModelRepository())
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