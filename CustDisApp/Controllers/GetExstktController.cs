using System;
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
using System.Data.SqlClient;
using CustDisApp.Models;

namespace CustDisApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/GetExstkt")]
    public class GetExstktController : ApiController
    {
        public GetExstktController()
        {

        }

        [AllowAnonymous]
        public JObject GetExistingTicket(string cid, string did)
        {
            dynamic ret = new JObject();
            if (cid == null)
                cid = "";
            if (did == null)
                did = "";

            string res = string.Empty;
            string qry = "Select TOP 3 TicketID from TRBL_TKT where Custid='" + cid + "' and status IN ('OPEN','NEW') ORDER BY CREATE_TS DESC;";
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();


            List<string> trbl = new List<string>();

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        trbl.Add(dr.GetString(0));
                    }
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

            ret.Count = trbl.Count;

            if (trbl.Count == 3)
            {
                ret.Ticket1 = trbl[0];
                ret.Ticket2 = trbl[1];
                ret.Ticket3 = trbl[2];
            }
            else if (trbl.Count == 2)
            {
                ret.Ticket1 = trbl[0];
                ret.Ticket2 = trbl[1];
            }
            else if (trbl.Count == 1)
            {
                ret.Ticket1 = trbl[0];
            }
            else
                ret.Ticket1 = "NOTICKET";

            dynamic resp = new JObject();
            resp.Response = ret;

            return resp;
        }
    }
}
