using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
using SLB_TADA_API.Models;
using System.Net.Http.Headers;
using System.Collections;

namespace SLB_TADA_API.Controllers
{
        public class EmployeeController : ApiController
    {
        // GET </employee/getall>
        [ActionName("GetAll")]
        public List<Employee> get()
        {
            EmployeePersistence ge = new EmployeePersistence();
            List<Employee> emp = ge.getEmployees();
            return emp;
        }

        // GET </employee/getemp/{Alias}>
        [ActionName("GetEmp")]
        public gEmployee get(string id) 
        {
            EmployeePersistence ge = new EmployeePersistence();
            gEmployee emp = ge.getEmployee(id);
            return emp;
        }

        //POST </employee/add>
        [ActionName("Add")]
        public HttpResponseMessage Post([FromBody]addEmployee value) 
        {
            EmployeePersistence ep = new EmployeePersistence();
            long id;
            id = ep.saveEmployee(value);
            value.empID = id;
            var resp = new HttpResponseMessage()
            {
                Content = new StringContent("[{\"Status\": 200},{\"Message\":\"New employee record has been added to database!\"}]")
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return resp;
        }

        //DELETE </employee/del> body{"@alias"}
        [ActionName("Del")]
        public HttpResponseMessage delete([FromBody]string alias) 
        {
            EmployeePersistence ep = new EmployeePersistence();
            bool recordExisted = false;
            recordExisted = ep.deleteEmployee(alias);
            HttpResponseMessage response;
            if (recordExisted) {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }

        //PUT </employee/update/{Alias}>
        [ActionName("Update")]
        public HttpResponseMessage put(string id, [FromBody]addEmployee value) 
        {
            EmployeePersistence ep = new EmployeePersistence();
            bool recordExisted = false;
            recordExisted = ep.UpdateEmployee(id, value);
            HttpResponseMessage response;
            if (recordExisted) {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else {
                response = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return response;
        }
    }
}
