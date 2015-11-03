﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using CustDisApp.Models;

namespace CustDisApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        LoginDisApp logn = new LoginDisApp();

        public LoginController()
        {

        }

        [AllowAnonymous]
        //[Route("Getdet")]
        public JObject Getdet(string cid, string pwd)
        {
            //LoginDisApp ld = new LoginDisApp();

            //var ldap = new List<LoginDisApp>();
            if (cid == null)
                cid = "";
            if (pwd == null)
                pwd = "";

            string res = string.Empty;
            string qry = "Select Custid, Password from hackathon.login_det where Custid='" + cid + "';";
            string cs = ConfigurationManager.ConnectionStrings["Mysql_cs"].ToString();
            string ms_custid = string.Empty;
            string ms_passwd = string.Empty;


            MySqlConnection con = new MySqlConnection(cs);
            MySqlCommand cmd = new MySqlCommand(qry, con);
            try
            {
                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ms_custid = dr.GetString("Custid");
                    ms_passwd = dr.GetString("Password");
                }

            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            finally
            {
                con.Close();
            }

            if (string.IsNullOrEmpty(ms_custid))
            {
                res = "Please enter valid Customer Id";
                //return JsonConvert.SerializeObject(lda);
            }
            else if (ms_custid == cid && pwd == ms_passwd)
            {
                res = "Success";
                //return JsonConvert.SerializeObject(lda);
            }


            //string cid = "123";
            //if (cid == "123" && pwd == "abc")
            //{
            //    return "Success...";
            //}
            //return "working...";
            //res = "Failure";

            //JsonToken jso = new JsonToken();
            //jso.p
            //string jso = "{\"request\":{cid : \""+cid+"\",pwd : \""+pwd+"\"},\"response\":
                        
            
            //LoginDisApp[] lda = new LoginDisApp[]
            //{
            //    new LoginDisApp.requestd = cid, pswd = pwd, response= res},
            //    new LoginDisApp { custid = cid, pswd = pwd, response= res}
            //};

            LoginDisApp lda = new LoginDisApp();

            //lda.

            dynamic request = new JObject();

            request.cid = cid;
            request.pwd = pwd;

            dynamic response = new JObject();

            response.cid = ms_custid;
            response.pwd = ms_passwd;
            response.resp = res;

            //dynamic cwp = new
            //{
            //    Request = request,
            //    Response = response
            //};

            dynamic cwp = new JObject();
            cwp.Request = request;
            cwp.Response = response;


            //return JsonConvert.SerializeObject(cwp);
            return cwp;
        }

        //public IHttpActionResult ValidateLogin()
        //{
        //    int cid = 123;
        //    string pwd = "abc";
        //    string res = "success";
        //    if (cid == 123 && pwd == "abc")
        //    {
        //        return Ok(res);
        //    }
        //    return NotFound();
        //}
    }
}
