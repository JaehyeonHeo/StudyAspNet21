using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardDelete : System.Web.UI.Page
    {
        private string _Id; 
        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"];
            lnkCancel.NavigateUrl = $"BoardView.aspx?Id={_Id}";

            lblId.Text = _Id;

            // ToDo : 버튼 clientClick
            btnDelete.Attributes["onclick"] = "return ConfirmDelete();"; 

            if (string.IsNullOrEmpty(_Id))
            {
                Response.Redirect("BoardList.aspx"); 
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // 현재글의 ID와 Password 일치하면 삭제 
            var repo = new DbRepository();
            if (repo.DeleteNote(Convert.ToInt32(_Id), txtPassword.Text) > 0)
            {
                Response.Redirect("BoardList.aspx"); 
            }
            else
            {
                lblMessage.Text = "삭제되지 않았습니다. 비밀번호를 확인하세요"; 
            }
        }
    }
}