using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DbRepository _repo;
        // 검색모드 : true, 보통 : false
        public bool SearchMode { get; set; } = false;
        public string SearchField { get; set; }
        public string SearchQuery { get; set; }

        public int RecordCount = 0; // 총 레코드 수 
        public int PageIndex = 0;  // 페이징할때 반드시 필요한 값, 현재 보여줄 페이지 번호

        public BoardList()
        {
            _repo = new DbRepository();   //SqlConnection 생성 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // 검색모드 결정 true검색, false일반모드
            SearchMode = (!string.IsNullOrEmpty(Request["SearchField"]) &&
                           !string.IsNullOrEmpty(Request["SearchQuery"]));
            if (SearchMode)
            {
                SearchField = Request["SearchField"];
                SearchQuery = Request["SearchQuery"]; 
            }
            if (!SearchMode )
            {
                RecordCount = _repo.GetCountAll(); 
            }
            else
            {
                RecordCount = _repo.GetCountBySearch(SearchField, SearchQuery); 
            }

            LblTotalRecord.Text = $"Total Record : {RecordCount}";

            if (Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1; 
            }
            else
            {
                PageIndex = 0; // 1페이지
            }

            // TO DO!! 쿠키 사용해서 리스트 페이지번호 유지 

            // 페이징 처리 
            PagingControl.PageIndex = PageIndex;
            PagingControl.RecordCount = RecordCount; 

            if (!Page.IsPostBack) //postBack이 아니면 = 최초로드이면
            {
                DisplayData(); 
            }
        }

        private void DisplayData()
        {
            if (!SearchMode)
            {
                GrvNotes.DataSource = _repo.GetAll(PageIndex); 
            }
            else
            {
                GrvNotes.DataSource = _repo.GetSeachAll(PageIndex, SearchField, SearchQuery); //검색결과 리스트
            }

            GrvNotes.DataBind(); 
        }
    }
}