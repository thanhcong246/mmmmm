using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class PageBase : System.Web.UI.Page
{
    #region Sorting Methods
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }
        return newSortDirection;
    }

    private string GridViewSortDirection
    {
        get { return ViewState["SortDirection"] as string ?? "ASC"; }
        set { ViewState["SortDirection"] = value; }
    }

    private string GridViewSortExpression
    {
        get { return ViewState["SortExpression"] as string ?? string.Empty; }
        set { ViewState["SortExpression"] = value; }
    }

    private string GetSortDirection()
    {
        switch (GridViewSortDirection)
        {
            case "ASC": GridViewSortDirection = "DESC";
                break;
            case "DESC": GridViewSortDirection = "ASC";
                break;
        }
        return GridViewSortDirection;
    }

    protected void PageGrid(object sender, GridViewPageEventArgs e)
    {
        GridView gView = (GridView)sender;

        gView.DataSource = SortDataTable(gView.DataSource as DataTable, true);

        gView.PageIndex = e.NewPageIndex;

        gView.DataBind();
    }

    protected DataView SortDataTable(DataTable dataTable, bool isPageIndexChanging)
    {
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);

            if (GridViewSortExpression != string.Empty)
            {
                if (isPageIndexChanging)
                {
                    dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection);
                }
                else
                {
                    dataView.Sort = string.Format("{0} {1}", GridViewSortExpression, GetSortDirection());
                }
            }
            return dataView;
        }
        else
        {
            return new DataView();
        }
    }

    protected void SortGrid(object sender, GridViewSortEventArgs e)
    {
        GridView gView = (GridView)sender;

        GridViewSortExpression = e.SortExpression;
        int pageIndex = gView.PageIndex;

        gView.DataSource = SortDataTable(gView.DataSource as DataTable, false);

        gView.DataBind();

        gView.PageIndex = pageIndex;
    }

    public void Grid_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        GridView myGrid = (GridView)sender;
        // Use the RowType property to determine whether the 
        // row being created is the header row. 
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // Call the GetSortColumnIndex helper method to determine
            // the index of the column being sorted.
            int sortColumnIndex = GetSortColumnIndex(myGrid);
        }
    }

    // This is a helper method used to determine the index of the
    // column being sorted. If no column is being sorted, -1 is returned.
    int GetSortColumnIndex(GridView myGrid)
    {
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in myGrid.Columns)
        {
            if (field.SortExpression == myGrid.SortExpression)
            {
                return myGrid.Columns.IndexOf(field);
            }
        }

        return -1;
    }

    /// <summary>
    ///  Lookup the Current Sort Expression to determine the Order of a specific item.
    /// </summary>
    protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder, out int sortOrderNo)
    {
        sortOrder = "";
        sortOrderNo = -1;
        for (int i = 0; i < sortColumns.Length; i++)
        {
            if (sortColumns[i].StartsWith(sortColumn))
            {
                sortOrderNo = i + 1;
                //if (AllowMultiColumnSorting)
                //    sortOrder = sortColumns[i].Substring(sortColumn.Length).Trim();
                //else
                sortOrder = GetSortDirection();//((SortDirection == SortDirection.Ascending) ? "ASC" : "DESC");
            }
        }
    }
    #endregion
}