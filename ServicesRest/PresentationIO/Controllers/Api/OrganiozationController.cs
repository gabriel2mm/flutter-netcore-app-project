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
    [RoutePrefix("api/Organization")]
    public class OrganiozationController : ApiController
    {
        public class UsersController : ApiController
        {
            [Route("GetAll")]
            [AcceptVerbs("GET")]
            public HttpResponseMessage GetAll(HttpRequestMessage request)
            {
                try
                {
                    List<Organization> organizations;
                    using (OrganizationRepository repository = new OrganizationRepository())
                    {
                        organizations = repository.GetAll().ToList();
                    }
                    return request.CreateResponse<List<Organization>>(HttpStatusCode.OK, organizations);
                }
                catch (Exception e)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível listar as organizações [" + e.Message + "]");
                }
            }
            [AcceptVerbs("GET")]
            [Route("Find/Contact/{id}")]
            public HttpResponseMessage FindContacts(HttpRequestMessage request, int? id)
            {
                try{
                    List<Contact> contacts;
                    using (ContactRepository repository = new ContactRepository())
                    {
                        contacts = repository.Get((c => c.Organization.ID == id)).ToList<Contact>();
                    }
                    return request.CreateResponse<List<Contact>>(HttpStatusCode.OK, contacts);
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
                    using (OrganizationRepository repository = new OrganizationRepository())
                    {
                        Organization org = repository.Find(id);
                        if (org != null)
                        {
                            return request.CreateResponse<Organization>(HttpStatusCode.OK, org);
                        }
                        else
                        {
                            return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Organização não pode ser encontrada");
                        }
                    }
                }
                catch (Exception e)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
                }
            }
            public HttpResponseMessage Add(HttpRequestMessage request, Organization org)
            {
                try
                {
                    using (OrganizationRepository repository = new OrganizationRepository())
                    {
                        repository.Add(org);
                        repository.SaveAll();
                    }
                    return request.CreateResponse<Organization>(HttpStatusCode.OK, org);
                }
                catch (Exception e)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possível inserir usuário [" + e.Message + "]");
                }
            }


            [Route("Update")]
            [AcceptVerbs("POST")]
            public HttpResponseMessage Update(HttpRequestMessage request, Organization org)
            {
                try
                {
                    using (OrganizationRepository repository = new OrganizationRepository())
                    {
                        repository.Update(org);
                        repository.SaveAll();
                    }
                    return request.CreateResponse<Organization>(HttpStatusCode.OK, org);
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
                    using (OrganizationRepository rep = new OrganizationRepository())
                    {
                        Func<Organization, bool> delete = (o => o.ID == id);
                        rep.Delete(delete);
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
}
