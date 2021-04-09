using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserId = "";
            string strPassword = string.Empty;  // = "";
            string strName = "";
            string strAge = "";
            
            strUserId = Request.QueryString["TxtUserID"]; // GET 형식만 가지고옴 !!
            strPassword = Request.Params["TxtPassword"]; // 1. GET, POST 뭐든지 불러옴
            strName = Request.Form["TxtName"];  // POST 형식만 가지고옴 !! 
            strAge = Request["TxtAge"]; // 2. GET, POST 뭐든지 불러옴
            
            var result = $@"입력하신 ID : {strUserId}, <br />
                                   암호 : {strPassword}, <br />
                                   이름 : {strName}, <br />
                                   나이 : {strAge} <br />";
            LblResult.Text = result;

            LblIpAddress.Text = Request.UserHostAddress; 
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}