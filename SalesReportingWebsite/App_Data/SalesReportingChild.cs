using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SKPickingBoardChild
/// </summary>
public class SalesReportingChild : SalesReportingCode
{

    public DataSet PeriodList() {
        DataSet dsPeriod = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetPeriod", sqlConn);
            da.Fill(dsPeriod);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsPeriod;
    }

    public DataSet AdjustmentTypeList() {
        DataSet dsAdjustmentType = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetAdjustmentType", sqlConn);
            da.Fill(dsAdjustmentType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsAdjustmentType;
    }

    public DataSet CountryNameList() {
        DataSet dsValueStrm = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetCountryName", sqlConn);
            da.Fill(dsValueStrm);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsValueStrm;
    }

    public DataSet SubBusinessUnitNameist() {
        DataSet dsCommCode = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetSubBusinessUnitName", sqlConn);
            da.Fill(dsCommCode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsCommCode;
    }

    public DataSet CompanyNameList() {
        DataSet dsDateRequested = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetCompanyName", sqlConn);
            da.Fill(dsDateRequested);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsDateRequested;
    }

    public DataSet SubSegmentNameList() {
        DataSet dsInventoryStatus = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetSubSegmentName", sqlConn);
            da.Fill(dsInventoryStatus);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsInventoryStatus;
    }

    public DataSet AccountSubTypeNameList()
    {
        DataSet dsAssignedTo = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetAccountSubTypeName", sqlConn);
            da.Fill(dsAssignedTo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsAssignedTo;
    }

    public DataSet SubCategoryNameList()
    {
        DataSet dsAssignedTo = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetSubCategoryName", sqlConn);
            da.Fill(dsAssignedTo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsAssignedTo;
    }

    public DataSet CurrencyNameList()
    {
        DataSet dsAssignedTo = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        try
        {
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SR_GetCurrencyName", sqlConn);
            da.Fill(dsAssignedTo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return dsAssignedTo;
    }   
}