using DotNetNote.Models;
using System;
using System.Web.UI;

namespace DotNetNote.Controls
{
    public partial class CommentControl : System.Web.UI.UserControl
    {
        private DbRepository _repo;

        public CommentControl()
        {
            _repo = new DbRepository(); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ctlCommentList.DataSource = _repo.GetNoteComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind(); 
            }
        }

        protected void btnWriteComment_Click1(object sender, EventArgs e)
        {
            NoteComment comment = new NoteComment();
            comment.BoardId = Convert.ToInt32(Request["Id"]);  // 게시글 번호 
            comment.Name = txtName.Text;
            comment.Password = txtPassword.Text;
            comment.Opinion = txtOpinion.Text; // 댓글 내용 

            _repo.AddNoteComment(comment); //DB 저장 

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}"); // Boardview.aspx 동적으로 웹페이지 이름 할당

        }
    }
}