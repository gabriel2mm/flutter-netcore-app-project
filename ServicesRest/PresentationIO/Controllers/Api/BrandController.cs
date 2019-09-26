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
    [RoutePrefix("api/Brand")]
    public class BrandController : ApiController
    {
        [Route("GetAll")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            try
            {
                List<Brand> Brands;
                using (BrandRepository repository = new BrandRepository())
                {
                    Brands = repository.GetAll().ToList<Brand>();
                }
                return request.CreateResponse<List<Brand>>(HttpStatusCode.OK, Brands);
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
                using (BrandRepository rep = new BrandRepository())
                {
                    Brand Brand = rep.Find(id);

                    if (Brand != null)
                    {
                        return request.CreateResponse<Brand>(HttpStatusCode.Accepted, Brand);
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
        [AllowAnonymous]
        [Route("Add")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage Add(HttpRequestMessage request, Brand Brand)
        {
            try
            {
                using (BrandRepository rep = new BrandRepository())
                {
                    rep.Add(Brand);
                    rep.SaveAll();
                }
                return request.CreateResponse<Brand>(HttpStatusCode.OK, Brand);
            }
            catch (Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível inserir usuário [" + e.Message + "]");
            }
        }


        [Route("Update")]
        [AcceptVerbs("PUT")]
        public HttpResponseMessage Update(HttpRequestMessage request, Brand Brand)
        {
            try
            {
                using (BrandRepository rep = new BrandRepository())
                {
                    rep.Update(Brand);
                    rep.SaveAll();
                }
                return request.CreateResponse<Brand>(HttpStatusCode.Accepted, Brand);
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
                using (BrandRepository rep = new BrandRepository())
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