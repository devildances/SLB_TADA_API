using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLB_TADA_API.Models
{
//===============================Employee models===========================================
    public class Employee
    {
        public string GIN { get; set; }
        public string Alias { get; set; }
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string JobCode { get; set; }
        public string MobilePhone { get; set; }
        public string GOLDMedalOwner { get; set; }
        public float QuestOTC { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Entity { get; set; }
        public string ProgramID { get; set; }
        public string CardNo { get; set; }
        public string PIN { get; set; }

        public Employee(string _GIN, string _Alias, string _DisplayName, string _UserPrincipalName, string _JobCode, string _MobilePhone, string _GOLDMedalOwner, float _QuestOTC, string _Country, string _Department, string _Entity, string _ProgramID, string _CardNo, string _PIN)
        {
            this.GIN = _GIN;
            this.Alias = _Alias;
            this.DisplayName = _DisplayName;
            this.UserPrincipalName = _UserPrincipalName;
            this.JobCode = _JobCode;
            this.MobilePhone = _MobilePhone;
            this.GOLDMedalOwner = _GOLDMedalOwner;
            this.QuestOTC = _QuestOTC;
            this.Country = _Country;
            this.Department = _Department;
            this.Entity = _Entity;
            this.ProgramID = _ProgramID;
            this.CardNo = _CardNo;
            this.PIN = _PIN;
        }

    }

    public class gEmployee
    {
        public string GIN { get; set; }
        public string Alias { get; set; }
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string JobCode { get; set; }
        public string MobilePhone { get; set; }
        public string GOLDMedalOwner { get; set; }
        public float QuestOTC { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Entity { get; set; }
        public string ProgramID { get; set; }
        public string CardNo { get; set; }
        public string PIN { get; set; }
    }

    public class addEmployee
    {
        public long empID { get; set; }
        public long DirectManager { get; set; }
        public long CountryID { get; set; }
        public long DepartmentID { get; set; }
        public string GIN { get; set; }
        public string Alias { get; set; }
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string JobCode { get; set; }
        public string MobilePhone { get; set; }
        public string GOLDMedalOwner { get; set; }
        public float QuestOTC { get; set; }
        public string Country { get; set; }
        public string Department { get; set; }
        public string Entity { get; set; }
        public string ProgramID { get; set; }
        public string CardNo { get; set; }
        public string PIN { get; set; }

        public addEmployee(long _empID, long _DirectManager,long _CountryID,long _DepartmentID,string _GIN, string _Alias, string _DisplayName, string _UserPrincipalName, string _JobCode, string _MobilePhone, string _GOLDMedalOwner, float _QuestOTC)
        {
            this.empID = _empID;
            this.DirectManager = _DirectManager;
            this.CountryID = _CountryID;
            this.DepartmentID = _DepartmentID;
            this.GIN = _GIN;
            this.Alias = _Alias;
            this.DisplayName = _DisplayName;
            this.UserPrincipalName = _UserPrincipalName;
            this.JobCode = _JobCode;
            this.MobilePhone = _MobilePhone;
            this.GOLDMedalOwner = _GOLDMedalOwner;
            this.QuestOTC = _QuestOTC;
        }

    }
    //=================================Department Models===============================================
    public class getAllDepts 
    {
        public string DName { get; set; }
        public string DEntity { get; set; }
        public string ProgramID { get; set; }

        public getAllDepts(string _DName, string _DEntity, string _ProgramID) 
        {
            this.DName = _DName;
            this.DEntity = _DEntity;
            this.ProgramID = _ProgramID;
        }
    }

    public class getSingleDept 
    {
        public string DName { get; set; }
        public string DEntity { get; set; }
        public string ProgramID { get; set; }
    }

    public class Department 
    { 
        public long DepartmentID { get; set; }
        public string DName { get; set; }
        public string DEntity { get; set; }

        public Department(long _DepartmentID,string _DName, string _DEntity)
        {
            this.DepartmentID = _DepartmentID;
            this.DName = _DName;
            this.DEntity = _DEntity;
        }
    }
//==================================Country Models====================================================
    public class Country
    {
        public long _CountryID { get; set; }
        public string _Alias { get; set; }
        public string _CName { get; set; }
    }

    public class EmpMedalsSent
    {
        public long _EmpMedalsSentID { get; set; }
        public long _empID { get; set; }
        public int _GoldSent { get; set; }
        public int _SilverSent { get; set; }
        public int _BronzeSent { get; set; }
    }

    public class EmpMedalsReceived
    {
        public long _EmpMedalsReceivedID { get; set; }
        public long _empID { get; set; }
        public int _GoldReceived { get; set; }
        public int _SilverReceived { get; set; }
        public int _BronzeReceived { get; set; }
    }

    public class EmpMedalsRecord
    {
        public long _EmpMedalsRecID { get; set; }
        public long _empID { get; set; }
        public long _MedalCatID { get; set; }
        public int _GoldSent { get; set; }
        public int _SilverSent { get; set; }
        public int _BronzeSent { get; set; }
        public int _GoldReceived { get; set; }
        public int _SilverReceived { get; set; }
        public int _BronzeReceived { get; set; }
    }

    public class TADAProduction
    {
        public long _TADAProdID { get; set; }
        public long _DepartmentID { get; set; }
        public string _ProgramID { get; set; }
    }

    public class EmpTADA
    {
        public long _empTADAID { get; set; }
        public long _empID { get; set; }
        public long _TADAProdID { get; set; }
        public string _TADACardNo { get; set; }
        public string _PIN { get; set; }
    }
}