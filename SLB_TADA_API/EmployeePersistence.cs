using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLB_TADA_API.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

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

        public List<Employee> getEmployees() {
            string getString = "SELECT * FROM Emp_details;";
            var e = new List<Employee>();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString, conn);
            MySqlDataReader fetch_query = cmd.ExecuteReader();
            while (fetch_query.Read()) {
                e.Add(
                    new Employee(
                        fetch_query["eGIN"] != DBNull.Value ? fetch_query["eGIN"].ToString() : null,
                        fetch_query["eAlias"] != DBNull.Value ? fetch_query["eAlias"].ToString() : null,
                        fetch_query["eDisplayName"] != DBNull.Value ? fetch_query["eDisplayName"].ToString() : null,
                        fetch_query["eMail"] != DBNull.Value ? fetch_query["eMail"].ToString() : null,
                        fetch_query["eJobCode"] != DBNull.Value ? fetch_query["eJobCode"].ToString() : null,
                        fetch_query["ePhone"] != DBNull.Value ? fetch_query["ePhone"].ToString() : null,
                        fetch_query["eGOLD"] != DBNull.Value ? fetch_query["eGOLD"].ToString() : null,
                        fetch_query["eOTC"] != DBNull.Value ? Convert.ToInt32(fetch_query["QuestOTC"]) : 0,
                        fetch_query["eCountry"] != DBNull.Value ? fetch_query["eCountry"].ToString() : null,
                        fetch_query["eDept"] != DBNull.Value ? fetch_query["eDept"].ToString() : null,
                        fetch_query["eEntity"] != DBNull.Value ? fetch_query["eEntity"].ToString() : null,
                        fetch_query["eProgramID"] != DBNull.Value ? fetch_query["eProgramID"].ToString() : null,
                        fetch_query["eTADACardNo"] != DBNull.Value ? fetch_query["eTADACardNo"].ToString() : null,
                        fetch_query["eTADAPIN"] != DBNull.Value ? fetch_query["eTADAPIN"].ToString() : null
                        )
                    );
            }
            return e;
        }

        public gEmployee getEmployee(string als) {
            gEmployee e = new gEmployee();
            MySql.Data.MySqlClient.MySqlDataReader getReader = null;
            string getString = "SELECT * FROM Emp_details WHERE eAlias = '" + als.ToString() + "';";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
            getReader = cmd.ExecuteReader();
            if (getReader.Read())
            {
                e.Alias = getReader.IsDBNull(0) == false ? getReader.GetString(0) : null;
                e.GIN = getReader.IsDBNull(1) == false ? getReader.GetString(1) : null;
                e.DisplayName = getReader.IsDBNull(2) == false ? getReader.GetString(2) : null;
                e.UserPrincipalName = getReader.IsDBNull(3) == false ? getReader.GetString(3) : null;
                e.JobCode = getReader.IsDBNull(4) == false ? getReader.GetString(4) : null;
                e.MobilePhone = getReader.IsDBNull(5) == false ? getReader.GetString(5) : null;
                e.GOLDMedalOwner = getReader.IsDBNull(6) == false ? getReader.GetString(6) : null;
                e.QuestOTC = getReader.IsDBNull(7) == false ? getReader.GetFloat(7) : 0;
                e.Country = getReader.IsDBNull(8) == false ? getReader.GetString(8) : null;
                e.Department = getReader.IsDBNull(9) == false ? getReader.GetString(9) : null;
                e.Entity = getReader.IsDBNull(10) == false ? getReader.GetString(10) : null;
                e.ProgramID = getReader.IsDBNull(11) == false ? getReader.GetString(11) : null;
                e.CardNo = getReader.IsDBNull(12) == false ? getReader.GetString(12) : null;
                e.PIN = getReader.IsDBNull(13) == false ? getReader.GetString(13) : null;
                return e;
            }
            else {
                return null;
            }
        }

        public long saveEmployee(addEmployee EmployeeToSave) {
            string sqlString = "INSERT into employees (DirectManager,CountryID,DepartmentID,GIN,Alias,DisplayName,UserPrincipalName,JobCode,MobilePhone,GOLDMedalOwner,QuestOTC) values(" + EmployeeToSave.DirectManager + "," + EmployeeToSave.CountryID + "," + EmployeeToSave.DepartmentID + ",'" + EmployeeToSave.GIN + "','" + EmployeeToSave.Alias + "','" + EmployeeToSave.DisplayName + "','" + EmployeeToSave.UserPrincipalName + "','" + EmployeeToSave.JobCode + "','" + EmployeeToSave.MobilePhone + "','" + EmployeeToSave.GOLDMedalOwner + "'," + EmployeeToSave.QuestOTC + "); ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString,conn);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            return id;
        }

        public bool UpdateEmployee(string als,addEmployee EmployeeToUpdate) {
            MySql.Data.MySqlClient.MySqlDataReader getReader = null;
            string getString = "SELECT * FROM employees WHERE Alias = '" + als.ToString() + "';";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
            getReader = cmd.ExecuteReader();
            if (getReader.Read()) {
                getReader.Close();
                getString = "UPDATE employees SET DirectManager=" + EmployeeToUpdate.DirectManager + ",CountryID=" + EmployeeToUpdate.CountryID + ",DepartmentID=" + EmployeeToUpdate.DepartmentID + ",GIN='" + EmployeeToUpdate.GIN + "',Alias='" + EmployeeToUpdate.Alias + "',DisplayName='" + EmployeeToUpdate.DisplayName + "',UserPrincipalName='" + EmployeeToUpdate.UserPrincipalName + "',JobCode='" + EmployeeToUpdate.JobCode + "',MobilePhone='" + EmployeeToUpdate.MobilePhone + "',GOLDMedalOwner='" + EmployeeToUpdate.GOLDMedalOwner + "',QuetOTC=" + EmployeeToUpdate.QuestOTC + " WHERE Alias = '" + als.ToString() + "'; ";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            else {
                return false;
            }
        }

        public bool deleteEmployee(string als) {
            gEmployee e = new gEmployee();
            MySql.Data.MySqlClient.MySqlDataReader getReader = null;
            string getString = "SELECT * FROM employees WHERE Alias = '" + als.ToString() + "';";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
            getReader = cmd.ExecuteReader();
            if (getReader.Read()) {
                getReader.Close();
                getString = "DELETE FROM employees WHERE Alias = '" + als.ToString() + "';";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(getString, conn);
                cmd.ExecuteNonQuery();
                return true;
            }
            else {
                return false;
            }
        }
    }
}