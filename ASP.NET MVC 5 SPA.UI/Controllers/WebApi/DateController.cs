using ASP.NET_MVC_5_SPA.DAL.Entities;
using ASP.NET_MVC_5_SPA.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ASP.NET_MVC_5_SPA.Controllers.WebApi
{
    public class DateController : ApiController
    {
        private UnitOfWork _uOfw;       
        public DateController(UnitOfWork unitofwork)
        {
            _uOfw= unitofwork;            
        }

        public DateController()
        {
            _uOfw = new UnitOfWork();
        }

        //GET api/date
        [HttpGet]
        public IEnumerable<InfoUser> GetAll()
        {
            return _uOfw.InfoUsers.GetAll();
        }

        // GET api/date/5
        [HttpGet]
        public HttpResponseMessage GetId(int id)
        {           
            if (_uOfw.InfoUsers.GetId(id)!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _uOfw.InfoUsers.GetId(id));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found");
            }
        }

        // POST api/date
        [HttpPost]
        public HttpResponseMessage Create([FromBody]InfoUser value)
        {
            if (IsValidation(value))
            {
                try
                {
                    _uOfw.InfoUsers.Create(value);
                    _uOfw.Save();
                    return Request.CreateResponse(HttpStatusCode.Created, value);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, value);
                }                
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/date/5
        [HttpPut]
        public HttpResponseMessage Update(int id, [FromBody]InfoUser value) 
        {
            if (IsValidation(value))
            {
                if (_uOfw.InfoUsers.GetId(id) != null)
                {
                    _uOfw.InfoUsers.Update(value);
                    _uOfw.Save();
                    return Request.CreateResponse(HttpStatusCode.OK, value);                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, value);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE api/date/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (_uOfw.InfoUsers.GetId(id)!=null)
            {                
                _uOfw.InfoUsers.Delete(id);
                _uOfw.Save();
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
        }

        private bool IsValidation(InfoUser value)
        {            
            if (value.Date == null)
            {
                ModelState.AddModelError("Date", "Enter the date");
            }

            if (value.Company.Length>50)
            {
                ModelState.AddModelError("Company", "Character limit exceeded");
            }

            if (string.IsNullOrEmpty(value.FirstName))
            {
                ModelState.AddModelError("FirstName", "Can not be empty");
            }
            if (!new Regex(@"^[A-Za-zА-Яа-я]+$").IsMatch(value.FirstName))
            {
                ModelState.AddModelError("FirstName", "Allowed only text");
            }

            if (string.IsNullOrEmpty(value.SecondName))
            {
                ModelState.AddModelError("SecondName", "Can not be empty");
            }
            if (!new Regex(@"^[A-Za-zА-Яа-я]+$").IsMatch(value.FirstName))
            {
                ModelState.AddModelError("SecondName", "Allowed only text");
            }
            if (string.IsNullOrEmpty(value.LastName))
            {
                ModelState.AddModelError("LastName", "Can not be empty");
            }
            if (!new Regex(@"^[A-Za-zА-Яа-я]+$").IsMatch(value.FirstName))
            {
                ModelState.AddModelError("LastName", "Allowed only text");
            }

            if (value.Position.Length > 30)
            {
                ModelState.AddModelError("Position", "Character limit exceeded");
            }

            if (value.Email == null)
            {
                ModelState.AddModelError("Email", "Can not be empty");
            }
            if (!new Regex(@"\b[a-z0-9._]+@[a-z0-9.-]+\.[a-z]{2,4}\b").IsMatch(value.Email))
            {
                ModelState.AddModelError("Email", "Email не правильный");
            }            

            if (!ModelState.IsValid)
            {
                return false;
            }

            return true;
        }
    }
}