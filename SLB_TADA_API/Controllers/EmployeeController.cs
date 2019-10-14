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

namespace SLB_TADA_API.Controllers
{
        public class EmployeeController : ApiController
    {
        // GET <api/employee>
        public List<Employee> Get()
        {
            MySqlConnection conn = WebApiConfig.conns();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM Emp_details";
            var emps = new List<Employee>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex){}

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                emps.Add(
                    new Employee(
                        fetch_query["eGIN"].ToString(),
                        fetch_query["eAlias"].ToString(),
                        fetch_query["eDisplayName"].ToString(),
                        fetch_query["eMail"].ToString(),
                        fetch_query["eJobCode"].ToString(),
                        fetch_query["ePhone"].ToString(),
                        fetch_query["eGOLD"].ToString(),
                        fetch_query["eOTC"] != DBNull.Value ? Convert.ToInt32(fetch_query["QuestOTC"]) : 0,
                        fetch_query["eCountry"].ToString(),
                        fetch_query["eDept"].ToString(),
                        fetch_query["eEntity"].ToString(),
                        fetch_query["eProgramID"].ToString(),
                        fetch_query["eTADACardNo"].ToString(),
                        fetch_query["eTADAPIN"].ToString()
                        )
                    );
            }
            return emps;
        }


        // GET <api/employee/{Alias}>
        public List<Employee> Get(string id)
        {
            MySqlConnection conn = WebApiConfig.conns();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM Emp_details WHERE eAlias = @als";
            query.Parameters.AddWithValue("@als",id);
            var emp = new List<Employee>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) { }
            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read()) {
                emp.Add(
                    new Employee (
                        fetch_query["eGIN"].ToString(),
                        fetch_query["eAlias"].ToString(),
                        fetch_query["eDisplayName"].ToString(),
                        fetch_query["eMail"].ToString(),
                        fetch_query["eJobCode"].ToString(),
                        fetch_query["ePhone"].ToString(),
                        fetch_query["eGOLD"].ToString(),
                        fetch_query["eOTC"] != DBNull.Value ? Convert.ToInt32(fetch_query["QuestOTC"]) : 0,
                        fetch_query["eCountry"].ToString(),
                        fetch_query["eDept"].ToString(),
                        fetch_query["eEntity"].ToString(),
                        fetch_query["eProgramID"].ToString(),
                        fetch_query["eTADACardNo"].ToString(),
                        fetch_query["eTADAPIN"].ToString()
                        )
                    );
            }
            return emp;
        }

        //POST <api/employee>
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
    }
}
