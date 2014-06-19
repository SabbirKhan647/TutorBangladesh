using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tutor
{
    public partial class GridViewPaging : System.Web.UI.UserControl
    {
        public event EventHandler pagingClickArgs;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                trErrorMessage.Visible = false;
                if (!IsPostBack)
                {
                    SelectedPageNo.Text = "1";
                    First.ForeColor = System.Drawing.Color.Black;
                    Previous.ForeColor = System.Drawing.Color.Black;
                    Next.ForeColor = System.Drawing.Color.RoyalBlue ;
                    Last.ForeColor = System.Drawing.Color.RoyalBlue;
                    
                    GetPageDisplaySummary();
                }
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }


    
        protected void First_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) { return; };
                SelectedPageNo.Text = "1";
                First.ForeColor = System.Drawing.Color.Black;
                Previous.ForeColor = System.Drawing.Color.Black;
                Last.ForeColor = System.Drawing.Color.RoyalBlue;
                Next.ForeColor = System.Drawing.Color.RoyalBlue ;
                GetPageDisplaySummary();
                pagingClickArgs(sender, e);
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }
        protected void Previous_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) { return; };
                if (Convert.ToInt32(SelectedPageNo.Text) > 1)
                {
                    SelectedPageNo.Text = (Convert.ToInt32(SelectedPageNo.Text) - 1).ToString();
                }
                Next.ForeColor = System.Drawing.Color.RoyalBlue;
                Last.ForeColor = System.Drawing.Color.RoyalBlue;
                GetPageDisplaySummary();
                pagingClickArgs(sender, e);
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }
        protected void SelectedPageNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) { return; };
                int currentPageNo = Convert.ToInt32(SelectedPageNo.Text);
                if (currentPageNo < GetTotalPagesCount())
                {
                    SelectedPageNo.Text = (currentPageNo).ToString();
                }
                GetPageDisplaySummary();
                pagingClickArgs(sender, e);
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }
        protected void Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) { return; };
                int currentPageNo = Convert.ToInt32(SelectedPageNo.Text);
                if (currentPageNo < GetTotalPagesCount())
                {
                    SelectedPageNo.Text = (currentPageNo + 1).ToString();
                }
                Previous.ForeColor = System.Drawing.Color.RoyalBlue;
                First.ForeColor = System.Drawing.Color.RoyalBlue;
                GetPageDisplaySummary();
                pagingClickArgs(sender, e);
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }
        protected void Last_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValid()) { return; };
                SelectedPageNo.Text = GetTotalPagesCount().ToString();
                Last.ForeColor = System.Drawing.Color.Black;
                Next.ForeColor = System.Drawing.Color.Black;
                First.ForeColor = System.Drawing.Color.RoyalBlue;;
                Previous.ForeColor = System.Drawing.Color.RoyalBlue;
                GetPageDisplaySummary();
                pagingClickArgs(sender, e);
            }
            catch (Exception ex)
            {
                ShowGridViewPagingErrorMessage(ex.Message.ToString());
            }
        }
        public int GetTotalPagesCount()
        {
            try
            {
                int pageRowSize = 4;
                int totalPages = Convert.ToInt32(TotalRows.Value) / Convert.ToInt32(pageRowSize);
                // total page item to be displyed
                int pageItemRemain = Convert.ToInt32(TotalRows.Value) % Convert.ToInt32(pageRowSize);
                // remaing no of pages
                if (pageItemRemain > 0)// set total No of pages
                {
                    totalPages = totalPages + 1;
                }
                else
                {
                    totalPages = totalPages + 0;
                }
                return totalPages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetPageDisplaySummary()
        {
            try
            {
                int pageRowSize = 4;
                PageDisplaySummary.Text = "Page " + SelectedPageNo.Text.ToString() + " of " + GetTotalPagesCount().ToString();
                int startRow = pageRowSize * (Convert.ToInt32(SelectedPageNo.Text) - 1) + 1;
                int endRow =pageRowSize  * Convert.ToInt32(SelectedPageNo.Text);
                int totalRecords = Convert.ToInt32(TotalRows.Value);
                if (totalRecords >= endRow)
                {
                    RecordDisplaySummary.Text = "Batches: " + startRow.ToString() + " - " + endRow.ToString() + " of " + totalRecords.ToString();
                }
                else
                {
                    RecordDisplaySummary.Text = "Batches: " + startRow.ToString() + " - " + totalRecords.ToString() + " of " + totalRecords.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool IsValid()
        {
            try
            {
                if (String.IsNullOrEmpty(SelectedPageNo.Text.Trim()) || (SelectedPageNo.Text == "0"))
                {
                    SelectedPageNo.Text = "1";
                    return false;
                }
                else if (!IsNumeric(SelectedPageNo.Text))
                {
                    ShowGridViewPagingErrorMessage("Please Insert Valid Page No.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool IsNumeric(string PageNo)
        {
            try
            {
                int i = Convert.ToInt32(PageNo);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void ShowGridViewPagingErrorMessage(string msg)
        {
            trErrorMessage.Visible = true;
            GridViewPagingError.Text = "Error: " + msg;
        }
    }
}