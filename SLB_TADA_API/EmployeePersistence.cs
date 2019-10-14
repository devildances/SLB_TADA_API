using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLB_TADA_API.Models;
using MySql.Data;

namespace SLB_TADA_API
{
    public class EmployeePersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;

        public EmployeePersistence() {
            string feashConn;
            feashConn = "server=localhost;port=3306;database=fea_starhub;username=root;password=135246;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = feashConn;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { }
        }

        public long saveEmployee(addEmployee EmployeeToSave) {
            string sqlString = "INSERT into employees (DirectManager,CountryID,DepartmentID,GIN,Alias,DisplayName,UserPrincipalName,JobCode,MobilePhone,GOLDMedalOwner,QuestOTC) values(" + EmployeeToSave.DirectManager + "," + EmployeeToSave.CountryID + "," + EmployeeToSave.DepartmentID + ",'" + EmployeeToSave.GIN + "','" + EmployeeToSave.Alias + "','" + EmployeeToSave.DisplayName + "','" + EmployeeToSave.UserPrincipalName + "','" + EmployeeToSave.JobCode + "','" + EmployeeToSave.MobilePhone + "','" + EmployeeToSave.GOLDMedalOwner + "'," + EmployeeToSave.QuestOTC + "); ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString,conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }
    }
}