using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {

        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write; //기본값 : 글쓰기

        private string _ID; // 리스트에서 넘겨주는 번호 
        protected void Page_Load(object sender, EventArgs e)
        {
            _ID = Request["Id"];  // GET / POST 모두 다 받음 

            if (!Page.IsPostBack)
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDescription.Text = "글쓰기 - 다음 필드를 입력하세요"; 
                        break;
                    case BoardWriteFormType.Modify:
                        LblTitleDescription.Text = "수정 - 아래 필드를 수정하세요";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        LblTitleDescription.Text = "답변 - 다음 필드를 입력하세요";
                        DisplayDataForReply();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayDataForReply()
        {
            throw new NotImplementedException();
        }

        private void DisplayDataForModify()
        {
            throw new NotImplementedException();
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                // todo 파일 업로드

                Note note = new Note();
                note.Id = Convert.ToInt32(_ID); // 값이 없으면 0 
                note.Name = txtName.Text;
                note.Email = txtEmail.Text;
                note.Title = txtTitle.Text; 
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text;
                note.FileName = "";
                note.FileSize = 0;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue;

                DbRepository repo = new DbRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx"); 
                        break;
                    case BoardWriteFormType.Modify:
                        break;
                    case BoardWriteFormType.Reply:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lblError.Text = "보안코드가 틀렸습니다. 다시 입력하세요"; 
            }
        }

        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated) // 이미 로그인 되었으면,,,
            {
                return true; 
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString()); 
                }
            }
            return false; // 보안코드 일치하지 않음
        }
    }
}