using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Models;

namespace WebApplication3
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DataTable dt = DBLayer.SelectRecords();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dt = DBLayer.SelectRecords();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ClearTextData();
        }
        protected void Insert(object sender, EventArgs e)
        {
            
            ContactModel oContactModel = new ContactModel();
            oContactModel.FirstName = txtFirstName1.Text;
            oContactModel.LastName = txtLastName1.Text;
            oContactModel.PhoneNumber = txtPhoneNumber1.Text;
            oContactModel.Status = txtStatus1.Text;
            DBLayer.Insert(oContactModel);
            DataTable dt = DBLayer.SelectRecords();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ClearTextData();

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ContactModel oContactModel = new ContactModel();

            GridViewRow row = GridView1.Rows[e.RowIndex];
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            oContactModel.FirstName  = (row.FindControl("txtFirstName") as TextBox).Text;
            oContactModel.LastName = (row.FindControl("txtLastName") as TextBox).Text;
            oContactModel.PhoneNumber = (row.FindControl("txtPhoneNumber") as TextBox).Text;
            oContactModel.Status = (row.FindControl("txtStatus") as TextBox).Text;
            DBLayer.Update(oContactModel, Id);            
            GridView1.EditIndex = -1;
            DataTable dt = DBLayer.SelectRecords();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            DBLayer.Delete(Id);
            DataTable dt = DBLayer.SelectRecords();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            //{
            //    (e.Row.Cells[2].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            //}
            //DataTable dt = DBLayer.SelectRecords();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataTable dt = DBLayer.SelectRecords();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void ClearTextData()
        {
            txtFirstName1.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtPhoneNumber1.Text = string.Empty;
            txtStatus1.Text = string.Empty;
        }
    }
}