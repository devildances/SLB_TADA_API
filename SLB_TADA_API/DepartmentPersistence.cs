﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLB_TADA_API.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Configuration;

namespace SLB_TADA_API
{
    public class DepartmentPersistence
    {
        //private MySql.Data.MySqlClient.MySqlConnection conn;
        /*public DepartmentPersistence()
        {
            string feashConn;
            feashConn = "server=localhost;port=3306;database=fea_starhub;username=root;password=135246;";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = feashConn;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { throw ex; }
        }*/

        public ArrayList allDepts() {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string feashConn;
            feashConn = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = feashConn;
                conn.Open();
                ArrayList d = new ArrayList();
                MySql.Data.MySqlClient.MySqlDataReader getReader = null;
                string getString = "SELECT * FROM Dept_ProgramID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString, conn);
                getReader = cmd.ExecuteReader();
                while (getReader.Read())
                {
                    getSingleDept adept = new getSingleDept();
                    adept.DName = getReader.IsDBNull(0) == false ? getReader.GetString(0) : null;
                    adept.DEntity = getReader.IsDBNull(1) == false ? getReader.GetString(1) : null;
                    adept.ProgramID = getReader.IsDBNull(2) == false ? getReader.GetString(2) : null;
                    d.Add(adept);
                }
                return d;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { throw ex; }
            finally { conn.Close(); }
        }

        public List<getAllDepts> OneDeptName(string als) {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string feashConn;
            feashConn = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = feashConn;
                conn.Open();
                string getString = "SELECT * FROM Dept_ProgramID WHERE DeptName = '" + als.ToString() + "';";
                var d = new List<getAllDepts>();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
                MySqlDataReader fetch_query = cmd.ExecuteReader();
                while (fetch_query.Read()) {
                    d.Add(
                        new getAllDepts(
                            fetch_query["DeptName"] != DBNull.Value ? fetch_query["DeptName"].ToString() : null,
                            fetch_query["DeptEntity"] != DBNull.Value ? fetch_query["DeptEntity"].ToString() : null,
                            fetch_query["DeptProgramID"] != DBNull.Value ? fetch_query["DeptProgramID"].ToString() : null
                            )
                        );
                }
                return d;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { throw ex; }
            finally { conn.Close(); }
        }

        public List<getAllDepts> OneEntName(string als)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string feashConn;
            feashConn = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = feashConn;
                conn.Open();
                string getString = "SELECT * FROM Dept_ProgramID WHERE DeptEntity = '" + als.ToString() + "';";
                var d = new List<getAllDepts>();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString, conn);
                MySqlDataReader fetch_query = cmd.ExecuteReader();
                while (fetch_query.Read())
                {
                    d.Add(
                        new getAllDepts(
                            fetch_query["DeptName"] != DBNull.Value ? fetch_query["DeptName"].ToString() : null,
                            fetch_query["DeptEntity"] != DBNull.Value ? fetch_query["DeptEntity"].ToString() : null,
                            fetch_query["DeptProgramID"] != DBNull.Value ? fetch_query["DeptProgramID"].ToString() : null
                            )
                        );
                }
                return d;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { throw ex; }
            finally { conn.Close(); }
        }

        public getSingleDept oneProgID(string als) {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string feashConn;
            feashConn = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            try
            {
                conn.ConnectionString = feashConn;
                conn.Open();
                getSingleDept d = new getSingleDept();
                MySql.Data.MySqlClient.MySqlDataReader getReader = null;
                string getString = "SELECT * FROM Dept_ProgramID WHERE DeptProgramID = '" + als.ToString() + "';";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(getString,conn);
                getReader = cmd.ExecuteReader();
                if (getReader.Read()) {
                    d.DName = getReader.IsDBNull(0) == false ? getReader.GetString(0) : null;
                    d.DEntity = getReader.IsDBNull(1) == false ? getReader.GetString(1) : null;
                    d.ProgramID = getReader.IsDBNull(2) == false ? getReader.GetString(2) : null;
                    return d;
                }
                else {
                    return null;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            { throw ex; }
            finally { conn.Close(); }
        }

    }
}