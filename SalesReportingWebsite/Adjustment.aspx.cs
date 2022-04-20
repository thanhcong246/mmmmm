using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace SalesReportingWebsite
{
    public partial class Adjustments : PageBase
    {
        public int memberships;
        protected void Page_Load(object sender, EventArgs e)
        {

            //VBFunctions.ADFunctions obj = new VBFunctions.ADFunctions();
            //string userID = obj.GetUserName();
            //// string dirEntry = obj.GetDirectoryEntry();
            //memberships = obj.VerifyGroupMemberships("LDAP://192.168.100.3/ou=Cooper Network Users,dc=coopersurgical1,dc=com", "coopservice", "^CSIServ2016!", userID);

            btnAddNewAdjustments.Focus();
            if (!IsPostBack)
            {
                SalesReportingChild li = new SalesReportingChild();

                ddlPeriod.DataSource = li.PeriodList().Tables[0];
                ddlPeriod.DataTextField = "Period";
                ddlPeriod.DataBind();

                newPeriod.DataSource = ddlPeriod.DataSource;
                newPeriod.DataTextField = "Period";
                newPeriod.DataBind();

                ddlAdjustmentType.DataSource = li.AdjustmentTypeList().Tables[0];
                ddlAdjustmentType.DataTextField = "AdjustmentTypeName";
                ddlAdjustmentType.DataBind();

                newAdjustmentType.DataSource = ddlAdjustmentType.DataSource;
                newAdjustmentType.DataTextField = "AdjustmentTypeName";
                newAdjustmentType.DataBind();

                ddlCountryName.DataSource = li.CountryNameList().Tables[0];
                ddlCountryName.DataTextField = "CountryName";
                ddlCountryName.DataBind();

                newCountryName.DataSource = ddlCountryName.DataSource;
                newCountryName.DataTextField = "CountryName";
                newCountryName.DataBind();

                ddlSubBusinessUnitName.DataSource = li.SubBusinessUnitNameist().Tables[0];
                ddlSubBusinessUnitName.DataTextField = "SubBusinessUnitName";
                ddlSubBusinessUnitName.DataBind();

                newSubBusinessUnitName.DataSource = ddlSubBusinessUnitName.DataSource;
                newSubBusinessUnitName.DataTextField = "SubBusinessUnitName";
                newSubBusinessUnitName.DataBind();

                ddlCompanyName.DataSource = li.CompanyNameList().Tables[0];
                ddlCompanyName.DataTextField = "CompanyName";
                ddlCompanyName.DataBind();

                newCompanyName.DataSource = ddlCompanyName.DataSource;
                newCompanyName.DataTextField = "CompanyName";
                newCompanyName.DataBind();

                ddlSubSegmentName.DataSource = li.SubSegmentNameList().Tables[0];
                ddlSubSegmentName.DataTextField = "SubSegmentName";
                ddlSubSegmentName.DataBind();

                newSubSegmentName.DataSource = ddlSubSegmentName.DataSource;
                newSubSegmentName.DataTextField = "SubSegmentName";
                newSubSegmentName.DataBind();

                ddlAccountSubTypeName.DataSource = li.AccountSubTypeNameList().Tables[0];
                ddlAccountSubTypeName.DataTextField = "AccountSubTypeName";
                ddlAccountSubTypeName.DataBind();

                newAccountSubTypeName.DataSource = ddlAccountSubTypeName.DataSource;
                newAccountSubTypeName.DataTextField = "AccountSubTypeName";
                newAccountSubTypeName.DataBind();

                ddlSubCategoryName.DataSource = li.SubCategoryNameList().Tables[0];
                ddlSubCategoryName.DataTextField = "SubCategoryName";
                ddlSubCategoryName.DataBind();

                newSubCategoryName.DataSource = ddlSubCategoryName.DataSource;
                newSubCategoryName.DataTextField = "SubCategoryName";
                newSubCategoryName.DataBind();

                newCurrencyName.DataSource = li.CurrencyNameList().Tables[0];
                newCurrencyName.DataTextField = "CurrencyName";
                newCurrencyName.DataBind();

                BindGridView();
            }
        }

        protected void btnSaveNewAdjustment_Click(object sender, EventArgs e)
        {
            bool isFormFilled = true;
            SalesReportingChild li = new SalesReportingChild();
            string date = Request.Form[newDate.UniqueID];
            string period = newPeriod.SelectedValue.ToString();
            string quantity = newQuantity.Text;
            string amountLCY = newAmountLCY.Text;
            string amountSpotUSD = newAmountSpotUSD.Text;
            string amountAverageUSD = newAmountAverageUSD.Text;
            string costLCY = newCostLCY.Text;
            string costSpotUSD = newCostSpotUSD.Text;
            string costAverageUSD = newCostAverageUSD.Text;
            string comment = newComment.Text;
            string adjustmentType = newAdjustmentType.SelectedValue.ToString();
            string countryName = newCountryName.SelectedValue.ToString();
            string subBusinessUnitName = newSubBusinessUnitName.SelectedValue.ToString();
            string companyName = newCompanyName.SelectedValue.ToString();
            string subSegmentName = newSubSegmentName.SelectedValue.ToString();
            string accountSubTypeName = newAccountSubTypeName.SelectedValue.ToString();
            string subCategoryName = newSubCategoryName.SelectedValue.ToString();
            string currencyName = newCurrencyName.SelectedValue.ToString();
            if (String.IsNullOrEmpty(date) || period.Equals("Select One") || adjustmentType.Equals("Select One") || countryName.Equals("Select One")
                || companyName.Equals("Select One") || subSegmentName.Equals("Select One") || accountSubTypeName.Equals("Select One")
                || currencyName.Equals("Select One"))
            {
                string display = "Please select all the mandatory fields ";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + display + "');", true);
                isFormFilled = false;
            }
            else if (String.IsNullOrEmpty(amountLCY) && String.IsNullOrEmpty(amountAverageUSD))
            {
                string display = "Please enter values for \"Amount LCY\" or \"Amount Average USD\"";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + display + "');", true);
                isFormFilled = false;
            }
            else if (companyName.Equals("Cooper Surgical"))
            {
                if (subBusinessUnitName.Equals("Select One") || subCategoryName.Equals("Select One"))
                {
                    string display = "Please select \"Sub Business Unit Name\" and \"Sub Category\" ";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('" + display + "');", true);
                    isFormFilled = false;
                }
            }

            if (isFormFilled)
            {
                bool result = li.AddNewAdjustment(date, period, quantity, amountLCY, amountSpotUSD, amountAverageUSD, costLCY, costSpotUSD, costAverageUSD, comment, adjustmentType, countryName, subBusinessUnitName, companyName, subSegmentName, accountSubTypeName, subCategoryName, currencyName);
            }
        }

        protected void btnAddNewAdjustments_Click(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //string dt = Request.Form[txtDate.UniqueID];
        }
                
        #region EventHandling

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvSKPickingBoard.EditIndex >= -1)
            {
                gvSKPickingBoard.EditIndex = -1;
            }
            BindGridView();
        }

        protected void gvSKPickingBoard_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSKPickingBoard.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = gvSKPickingBoard.Rows[e.NewEditIndex];

            BindGridView();
        }

        protected void gvAdjustment_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AdjustmentGridView.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = AdjustmentGridView.Rows[e.NewEditIndex];

            BindAdjustmentGridView();
        }

        protected void gvSKPickingBoard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSKPickingBoard.EditIndex = -1;
            BindGridView();
        }

        protected void gvAdjustment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            AdjustmentGridView.EditIndex = -1;
            BindAdjustmentGridView();
        }

        protected void gvAdjustment_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                SalesReportingChild li = new SalesReportingChild();
                GridViewRow row = AdjustmentGridView.Rows[e.RowIndex];
            }
            AdjustmentGridView.EditIndex = -1;
            BindAdjustmentGridView();
        }
        protected void gvSKPickingBoard_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Page.IsValid)
            {
                SalesReportingChild li = new SalesReportingChild();
                GridViewRow row = gvSKPickingBoard.Rows[e.RowIndex];
                
                try
                {
                    li.AdjustmentID = Convert.ToInt32(gvSKPickingBoard.DataKeys[e.RowIndex].Values[0]);
                    if (((TextBox)row.FindControl("AdjustmentDate")).Text != string.Empty)
                    {
                        li.Date = Convert.ToDateTime(((TextBox)row.FindControl("AdjustmentDate")).Text);
                    }
                    else
                    {
                        li.Date = DateTime.MinValue;
                    }

                    if (((TextBox)row.FindControl("AdjustmentQuantity")).Text != string.Empty)
                    {
                        li.Quantity = Convert.ToInt32(((TextBox)row.FindControl("AdjustmentQuantity")).Text);
                    }
                    else
                    {
                        li.Quantity = 0;
                    }
                  
                    if (((TextBox)row.FindControl("AdjustmentAmountLCY")).Text != string.Empty)
                    {
                        li.AmountLCY = Convert.ToSingle(((TextBox)row.FindControl("AdjustmentAmountLCY")).Text);
                    }
                    else
                    {
                        li.AmountLCY = 0;
                    }

                    if (((TextBox)row.FindControl("AdjustmentCostLCY")).Text != string.Empty)
                    {
                        li.CostLCY = Convert.ToSingle(((TextBox)row.FindControl("AdjustmentCostLCY")).Text);
                    }
                    else
                    {
                        li.CostLCY = 0;
                    }

                    if (((TextBox)row.FindControl("AdjustmentComment")).Text != string.Empty)
                    {
                        li.Comment = ((TextBox)row.FindControl("AdjustmentComment")).Text;
                    }
                    else
                    {
                        li.Comment = String.Empty;
                    }

                    if (((DropDownList)row.FindControl("ddlPeriods")).SelectedValue != "Select One")
                    {
                        li.Period = ((DropDownList)row.FindControl("ddlPeriods")).SelectedValue;
                    }
                    else
                    {
                        li.Period = String.Empty;
                    }

                    if (((DropDownList)row.FindControl("ddlAdjustmentTypeNames")).SelectedValue != "Select One")
                    {
                        li.AdjustmentTypeName = ((DropDownList)row.FindControl("ddlAdjustmentTypeNames")).SelectedValue;
                    }
                    else
                    {
                        li.AdjustmentTypeName = String.Empty;
                    }

                    if (((DropDownList)row.FindControl("ddlCountryNames")).SelectedValue != "Select One")
                    {
                        li.CountryName = ((DropDownList)row.FindControl("ddlCountryNames")).SelectedValue;
                    }
                    else
                    {
                        li.CountryName = String.Empty;
                    }

                    if (((DropDownList)row.FindControl("ddlSubBusinessUnitNames")).SelectedValue != "Select One")
                    {
                        li.SubBusinessUnitTypeName = ((DropDownList)row.FindControl("ddlSubBusinessUnitNames")).SelectedValue;
                    }
                    else
                    {
                        li.SubBusinessUnitTypeName = String.Empty;
                    }

                    if (((DropDownList)row.FindControl("ddlCompanyNames")).SelectedValue != "Select One")
                    {
                        li.CompanyName = ((DropDownList)row.FindControl("ddlCompanyNames")).SelectedValue;
                    }
                    else
                    {
                        li.CompanyName = String.Empty;
                    }
                    
                    if (((DropDownList)row.FindControl("ddlSubSegmentNames")).SelectedValue != "Select One")
                    {
                        li.SubSegmentName = ((DropDownList)row.FindControl("ddlSubSegmentNames")).SelectedValue;
                    }
                    else
                    {
                        li.SubSegmentName = String.Empty;
                    }
                    
                    if (((DropDownList)row.FindControl("ddlAccountSubTypeNames")).SelectedValue != "Select One")
                    {
                        li.AccountSubTypeName = ((DropDownList)row.FindControl("ddlAccountSubTypeNames")).SelectedValue;
                    }
                    else
                    {
                        li.AccountSubTypeName = String.Empty;
                    }
                    
                    if (((DropDownList)row.FindControl("ddlSubCategoryNames")).SelectedValue != "Select One")
                    {
                        li.SubCategoryName = ((DropDownList)row.FindControl("ddlSubCategoryNames")).SelectedValue;
                    }
                    else
                    {
                        li.SubCategoryName = String.Empty;
                    }
                    li.UpdateSKPickingBoard(li, memberships);
                    //if (memberships > 0)
                    //{
                    //    li.UpdateSKPickingBoard(li, memberships);
                    //}
                    //else
                    //{
                    //    string display = "You must be a member of SK_Picking _Operations or SK_Picking_Warehouse groups to make changes.";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + display + "');", true);
                    //}

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                gvSKPickingBoard.EditIndex = -1;
                BindGridView();
            }
        }

        protected void gvSKPickingBoard_SortData(object sender, GridViewSortEventArgs e)
        {
            if (gvSKPickingBoard.EditIndex >= -1)
            {
                gvSKPickingBoard.EditIndex = -1;
            }
            BindGridView();
            SortGrid(sender, e);
        }

        protected void gvAdjustment_SortData(object sender, GridViewSortEventArgs e)
        {
            if (AdjustmentGridView.EditIndex >= -1)
            {
                AdjustmentGridView.EditIndex = -1;
            }
            BindAdjustmentGridView();
            SortGrid(sender, e);
        }

        protected void gvAdjustment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && AdjustmentGridView.EditIndex == e.Row.RowIndex)
            {

            }
        }
        protected void gvSKPickingBoard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvSKPickingBoard.EditIndex == e.Row.RowIndex)
            {
                SalesReportingChild li = new SalesReportingChild();

                //Find the DropDownList in the Row
                DropDownList ddlPeriodList = (DropDownList)e.Row.FindControl("ddlPeriods");
                ddlPeriodList.DataSource = li.PeriodList().Tables[0];
                //ddlPeriodList.DataSource = table;
                ddlPeriodList.DataTextField = "Period";
                ddlPeriodList.DataValueField = "Period";
                ddlPeriodList.DataBind();

                //Add Default Item in the DropDownList
                ddlPeriodList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string period = (e.Row.FindControl("lblPeriod") as Label).Text;
                ddlPeriodList.Items.FindByValue(period).Selected = true;

                //Find the DropDownList in the Row
                DropDownList ddlAdjustmentTypeNameList = (e.Row.FindControl("ddlAdjustmentTypeNames") as DropDownList);
                ddlAdjustmentTypeNameList.DataSource = li.AdjustmentTypeList().Tables[0];
                ddlAdjustmentTypeNameList.DataTextField = "AdjustmentTypeName";
                ddlAdjustmentTypeNameList.DataValueField = "AdjustmentTypeName";
                ddlAdjustmentTypeNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlAdjustmentTypeNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string adjustmentTypeNames = (e.Row.FindControl("lblAdjustmentTypeName") as Label).Text;
                ddlAdjustmentTypeNameList.Items.FindByValue(adjustmentTypeNames).Selected = true;

                //Find the DropDownList in the Row
                DropDownList ddlCountryNameList = (e.Row.FindControl("ddlCountryNames") as DropDownList);
                ddlCountryNameList.DataSource = li.CountryNameList().Tables[0];
                ddlCountryNameList.DataTextField = "CountryName";
                ddlCountryNameList.DataValueField = "CountryName";
                ddlCountryNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlCountryNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string countryNames = (e.Row.FindControl("lblCountryName") as Label).Text;
                ddlCountryNameList.Items.FindByValue(countryNames).Selected = true;


                //Find the DropDownList in the Row
                DropDownList ddlSubBusinessUnitNameList = (e.Row.FindControl("ddlSubBusinessUnitNames") as DropDownList);
                ddlSubBusinessUnitNameList.DataSource = li.SubBusinessUnitNameist().Tables[0];
                ddlSubBusinessUnitNameList.DataTextField = "SubBusinessUnitName";
                ddlSubBusinessUnitNameList.DataValueField = "SubBusinessUnitName";
                ddlSubBusinessUnitNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlSubBusinessUnitNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string subBusinessUnitNames = (e.Row.FindControl("lblSubBusinessUnitName") as Label).Text;
                ddlSubBusinessUnitNameList.Items.FindByValue(subBusinessUnitNames).Selected = true;


                //Find the DropDownList in the Row
                DropDownList ddlCompanyNameList = (e.Row.FindControl("ddlCompanyNames") as DropDownList);
                ddlCompanyNameList.DataSource = li.CompanyNameList().Tables[0];
                ddlCompanyNameList.DataTextField = "CompanyName";
                ddlCompanyNameList.DataValueField = "CompanyName";
                ddlCompanyNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlCompanyNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string companyNames = (e.Row.FindControl("lblCompanyName") as Label).Text;
                ddlCompanyNameList.Items.FindByValue(companyNames).Selected = true;


                //Find the DropDownList in the Row
                DropDownList ddlSubSegmentNameList = (e.Row.FindControl("ddlSubSegmentNames") as DropDownList);
                ddlSubSegmentNameList.DataSource = li.SubSegmentNameList().Tables[0];
                ddlSubSegmentNameList.DataTextField = "SubSegmentName";
                ddlSubSegmentNameList.DataValueField = "SubSegmentName";
                ddlSubSegmentNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlSubSegmentNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string subSegmentNames = (e.Row.FindControl("lblSubSegmentName") as Label).Text;
                ddlSubSegmentNameList.Items.FindByValue(subSegmentNames).Selected = true;


                //Find the DropDownList in the Row
                DropDownList ddlAccountSubTypeNameList = (e.Row.FindControl("ddlAccountSubTypeNames") as DropDownList);
                ddlAccountSubTypeNameList.DataSource = li.AccountSubTypeNameList().Tables[0];
                ddlAccountSubTypeNameList.DataTextField = "AccountSubTypeName";
                ddlAccountSubTypeNameList.DataValueField = "AccountSubTypeName";
                ddlAccountSubTypeNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlAccountSubTypeNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string accountSubTypeNames = (e.Row.FindControl("lblAccountSubTypeName") as Label).Text;
                ddlAccountSubTypeNameList.Items.FindByValue(accountSubTypeNames).Selected = true;


                //Find the DropDownList in the Row
                DropDownList ddlSubCategoryNameList = (e.Row.FindControl("ddlSubCategoryNames") as DropDownList);
                ddlSubCategoryNameList.DataSource = li.SubCategoryNameList().Tables[0];
                ddlSubCategoryNameList.DataTextField = "SubCategoryName";
                ddlSubCategoryNameList.DataValueField = "SubCategoryName";
                ddlSubCategoryNameList.DataBind();

                //Add Default Item in the DropDownList
                ddlSubCategoryNameList.Items.Insert(0, new ListItem("Select One"));

                //Select the Country of Customer in DropDownList
                string subCategoryNames = (e.Row.FindControl("lblSubCategoryName") as Label).Text;
                ddlSubCategoryNameList.Items.FindByValue(subCategoryNames).Selected = true;


            }
        }

        protected void gvSKPickingBoard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (gvSKPickingBoard.EditIndex >= -1)
            {
                gvSKPickingBoard.EditIndex = -1;
            }
            BindGridView();
            PageGrid(sender, e);
        }

        protected void gvAdjustment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (AdjustmentGridView.EditIndex >= -1)
            {
                AdjustmentGridView.EditIndex = -1;
            }
            BindAdjustmentGridView();
            PageGrid(sender, e);
        }

        protected void chkBoxResetCheckedChanged(object sender, EventArgs e)
        {
            if (gvSKPickingBoard.EditIndex >= -1)
            {
                gvSKPickingBoard.EditIndex = -1;
            }
            txtFromDate.Text = "Select One";
            txtToDate.Text = "Select One";
            ddlPeriod.SelectedIndex = 0;
            txtFromQuantity.Text = "0";
            txtToQuantity.Text = "99999999";
            txtFromAmount.Text = "0";
            txtToAmount.Text = "99999999";
            ddlAdjustmentType.SelectedIndex = 0;
            ddlCountryName.SelectedIndex = 0;
            ddlSubBusinessUnitName.SelectedIndex = 0;
            ddlCompanyName.SelectedIndex = 0;
            ddlSubSegmentName.SelectedIndex = 0;
            ddlAccountSubTypeName.SelectedIndex = 0;
            ddlSubCategoryName.SelectedIndex = 0;
            chkBoxReset.Checked = false;
            BindGridView();
        }

        #endregion

        private void BindAdjustmentGridView()
        {

        }

        private void BindGridView()
        {
            int count;
            SalesReportingChild obj = new SalesReportingChild();
            // BaseClass.LowInventoryChild obj = null;
            
            string fromDate = Request.Form[txtFromDate.UniqueID];
            string toDate = Request.Form[txtToDate.UniqueID];
            string period = ddlPeriod.SelectedValue.ToString();
            string fromQuantity = txtFromQuantity.Text;
            string toQuantity = txtToQuantity.Text;
            string fromAmount = txtFromAmount.Text;
            string toAmount = txtToAmount.Text;
            string adjustmentType = ddlAdjustmentType.SelectedValue.ToString();
            string countryName = ddlCountryName.SelectedValue.ToString();
            string subBusinessUnitName = ddlSubBusinessUnitName.SelectedValue.ToString();
            string companyName = ddlCompanyName.SelectedValue.ToString();
            string subSegmentName = ddlSubSegmentName.SelectedValue.ToString();
            string accountSubTypeName = ddlAccountSubTypeName.SelectedValue.ToString();
            string subCategoryName = ddlSubCategoryName.SelectedValue.ToString();
            string rblMeasurementSystemText = string.Empty;
            if (rblMeasurementSystem.SelectedItem != null)
            {
                rblMeasurementSystemText = rblMeasurementSystem.SelectedItem.Text;
            }
            DataSet ds = obj.GetSKPickingBoard(fromDate, toDate, period, fromQuantity, toQuantity, fromAmount, toAmount, adjustmentType, countryName, subBusinessUnitName, companyName, subSegmentName, accountSubTypeName, subCategoryName, rblMeasurementSystemText);
            gvSKPickingBoard.DataSource = ds.Tables[0];
            gvSKPickingBoard.DataBind();
            count = ds.Tables[0].Rows.Count;
            if (count > 1)
            {
                lblRecordCount.Text = "Record Count: " + count;
            }
            else
            {
                lblRecordCount.Text = "Record Count: " + count;
            }
            txtFromDate.Text = fromDate;
            txtToDate.Text = toDate;
            txtFromQuantity.Text = fromQuantity;
            txtToQuantity.Text = toQuantity;
            txtFromAmount.Text = fromAmount;
            txtToAmount.Text = toAmount;
        }

        private DateTime convertTwoDigitYr(string strDate)
        {
            DateTime dt = new DateTime();
            int lstindx = strDate.LastIndexOf("/");
            string yr = strDate.Substring(lstindx + 1);
            if (yr.Length == 2)
            {
                yr = "20" + yr;
                strDate = strDate.Substring(0, lstindx + 1) + yr;
            }
            dt = DateTime.Parse(strDate);
            return dt;
        }

        protected void cstm_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            string controlDate = e.Value;
            DateTime dt;
            CustomValidator cv = (CustomValidator)sender;
            if (controlDate != string.Empty)
            {
                try
                {
                    dt = DateTime.Parse(controlDate);

                    if (convertTwoDigitYr(controlDate) < DateTime.Parse("12/31/1999"))
                    {
                        cv.ErrorMessage = "* Date needs to be after year 2000";
                        e.IsValid = false;
                        return;
                    }

                    if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        cv.ErrorMessage = "* Weekend days not allowed";
                        e.IsValid = false;
                        return;
                    }
                }
                catch
                {
                    cv.ErrorMessage = "* Invalid Date/DateFormat";
                    e.IsValid = false;
                    return;
                }
            }
            e.IsValid = true;
        }
        protected void btnAdjustments_Click(object sender, EventArgs e)
        {
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SalesReportingChild obj = new SalesReportingChild();
            DataSet ds = obj.GetSKPickingBoard("Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One", "Select One");

            WorkbookEngine we = new WorkbookEngine();
            we.ExportDataSetToExcel(ds.Tables[0], "Sales Reporting");
        }
    }
}