using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


 public class WorkbookEngine
    {
        public void ExportDataSetToExcel(System.Data.DataTable dt, string filename)
        {
            HttpResponse response = HttpContext.Current.Response;

            response.Clear();
            response.Charset = "";

            // set the response mime type for excel               
            response.ContentType = "application/ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + ".xls");
            // create a string writer   
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid   
                    System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
                    dg.Font.Size = 8;
                    dg.Font.Name = "Arial";
                    dg.RowDataBound += new GridViewRowEventHandler(dg_RowDataBound);
                    dg.GridLines = System.Web.UI.WebControls.GridLines.Both;                   
                    dg.DataSource = dt;
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }
        }

        protected void dg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
          //      DataRowView drv = e.Row.DataItem as DataRowView;
          //      DateTime reqDate = new DateTime();
          //      DateTime.TryParse(drv["AdjustmentDate"].ToString(), out reqDate);
          ////      e.Row.Cells[2].Attributes["style"] = "mso-number-format:\\@";
          /////*      e.Row.Cells[4].Attributes["style"] = "mso-number-format:\\@";
          ////      e.Row.Cells[11].Attributes["style"] = "mso-number-format:\\@"; */
          ////      e.Row.Cells[4].Style["mso-number-format"] = "mm\\/dd\\/yy";
          ////      e.Row.Cells[11].Style["mso-number-format"] = "mm\\/dd\\/yy";
          //      if (reqDate.Date < System.DateTime.Now.Date && reqDate.Date != DateTime.MinValue)
          //      {                
          //         e.Row.Cells[11].BackColor = System.Drawing.Color.Yellow;
          //      }

          //      /*
          //      if (float.Parse(drv["Qty_Onhand_Less_Orders"].ToString()) < 0)
          //      {                   
          //          e.Row.Cells[4].Text = "(" + int.Parse(drv["Qty_Onhand_Less_Orders"].ToString()) * (-1) + ")";
          //          e.Row.Cells[5].Text = "(" + drv["Mths_Onhand_Less_Orders"].ToString().Substring(1) + ")";                   
          //          e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
          //          e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
          //      }*/
            }
        }
    }

