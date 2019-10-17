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
    public class DepartmentController : ApiController
    {
        // GET: /Department/getall
        [ActionName("GetAll")]
        public ArrayList Get()
        {
            DepartmentPersistence de = new DepartmentPersistence();
            return de.allDepts();
        }

        // GET: /Department/getdept/{DepartmentName}
        [ActionName("GetDept")]
        public List<getAllDepts> GetDept(string id) 
        {
            DepartmentPersistence de = new DepartmentPersistence();
            List<getAllDepts> dept = de.OneDeptName(id);
            if (dept == null) {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dept;
        }

        // GET: /Department/getent/{EntityName}
        [ActionName("GetEnt")]
        public List<getAllDepts> GetEnt(string id) {
            DepartmentPersistence de = new DepartmentPersistence();
            List<getAllDepts> dept = de.OneEntName(id);
            if (dept == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dept;
        }

        // GET: /Department/getprog/{ProgramID}
        [ActionName("GetProg")]
        public getSingleDept GetProg(string id)
        {
            DepartmentPersistence de = new DepartmentPersistence();
            getSingleDept dept = de.oneProgID(id);
            if (dept == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return dept;
        }
//====================================================================================================================
        // POST: /Department

        // PUT: /Department/5

        // DELETE: /Department/5
    }
}
