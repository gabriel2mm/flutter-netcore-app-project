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
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        [Route("GetAll")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                List<Category> Categorys;
                using (CategoryRepository repository = new CategoryRepository())
                {
                    Categorys = repository.GetAll().ToList<Category>();
                }
                return request.CreateResponse<List<Category>>(HttpStatusCode.OK, Categorys);
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
                using (CategoryRepository rep = new CategoryRepository())
                {
                    Category Category = rep.Find(id);

                    if (Category != null)
                    {
                        return request.CreateResponse<Category>(HttpStatusCode.Accepted, Category);
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
        public HttpResponseMessage Add(HttpRequestMessage request, Category Category)
        {
            try
            {
                using (CategoryRepository rep = new CategoryRepository())
                {
                    rep.Add(Category);
                    rep.SaveAll();
                }
                return request.CreateResponse<Category>(HttpStatusCode.OK, Category);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível inserir usuário [" + e.Message + "]");
            }
        }


        [Route("Update")]
        [AcceptVerbs("PUT")]
        public HttpResponseMessage Update(HttpRequestMessage request, Category Category)
        {
            try
            {
                using (CategoryRepository rep = new CategoryRepository())
                {
                    rep.Update(Category);
                    rep.SaveAll();
                }
                return request.CreateResponse<Category>(HttpStatusCode.Accepted, Category);
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
                using (CategoryRepository rep = new CategoryRepository())
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