﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for LowInventory
/// </summary>
public abstract class SalesReportingCode
{
    public SalesReportingCode()
    {
        _AdjustmentID = 0;
        _Date = DateTime.MinValue;
        _Quantity = 0;
        _AmountLCY = 0;
        _CostLCY = 0;
        _Comment = String.Empty;
        _Period = String.Empty;
        _AdjustmentTypeName = String.Empty;
        _CountryName = String.Empty;
        _SubBusinessUnitTypeName = String.Empty;
        _CompanyName = String.Empty;
        _SubSegmentName = String.Empty;
        _AccountSubTypeName = String.Empty;
        _SubCategoryName = String.Empty;
    }

    private int _AdjustmentID;
    private DateTime _Date;
    private float _Quantity;
    private float _AmountLCY;
    private float _CostLCY;
    private string _Comment;
    private string _Period;
    private string _AdjustmentTypeName;
    private string _CountryName;
    private string _SubBusinessUnitTypeName;
    private string _CompanyName;
    private string _SubSegmentName;
    private string _AccountSubTypeName;
    private string _SubCategoryName;

    public int AdjustmentID
    {
        get { return _AdjustmentID; }
        set { _AdjustmentID = value; }
    }

    public DateTime Date
    {
        get { return _Date; }
        set { _Date = value; }
    }

    public float Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }

    public float AmountLCY
    {
        get { return _AmountLCY; }
        set { _AmountLCY = value; }
    }

    public float CostLCY
    {
        get { return _CostLCY; }
        set { _CostLCY = value; }
    }

    public string Comment
    {
        get { return _Comment; }
        set { _Comment = value; }
    }

    public string Period
    {
        get { return _Period; }
        set { _Period = value; }
    }

    public string AdjustmentTypeName
    {
        get { return _AdjustmentTypeName; }
        set { _AdjustmentTypeName = value; }
    }

    public string CountryName
    {
        get { return _CountryName; }
        set { _CountryName = value; }
    }

    public string SubBusinessUnitTypeName
    {
        get { return _SubBusinessUnitTypeName; }
        set { _SubBusinessUnitTypeName = value; }
    }

    public string CompanyName
    {
        get { return _CompanyName; }
        set { _CompanyName = value; }
    }

    public string SubSegmentName
    {
        get { return _SubSegmentName; }
        set { _SubSegmentName = value; }
    }

    public string AccountSubTypeName
    {
        get { return _AccountSubTypeName; }
        set { _AccountSubTypeName = value; }
    }

    public string SubCategoryName
    {
        get { return _SubCategoryName; }
        set { _SubCategoryName = value; }
    }

    public DataSet GetSKPickingBoard(string fromDate, string toDate, string period, string fromQuantity, string toQuantity, string fromAmount, string toAmount, string adjustmentType, string countryName, string subBusinessUnitName, string companyName, string subSegmentName, string accountSubTypeName, string subCategoryName, string rblMeasurementSystemText)
    {
        DataSet ds = new DataSet();
        
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Web_SR_GetAdjustmentRecords", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (fromDate == "Select One" || String.IsNullOrEmpty(fromDate))
                    {
                        cmd.Parameters.AddWithValue("FromDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FromDate", Convert.ToDateTime(fromDate));
                    }

                    if (toDate == "Select One" || String.IsNullOrEmpty(toDate))
                    {
                        cmd.Parameters.AddWithValue("ToDate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ToDate", Convert.ToDateTime(toDate));
                    }

                    if (period == "Select One" || String.IsNullOrEmpty(period))
                    {
                        cmd.Parameters.AddWithValue("Period", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Period", period);
                    }

                    if (fromQuantity == "Select One" || String.IsNullOrEmpty(fromQuantity))
                    {
                        cmd.Parameters.AddWithValue("FromQuantity", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FromQuantity", Convert.ToInt32(fromQuantity));
                    }

                    if (toQuantity == "Select One" || String.IsNullOrEmpty(toQuantity))
                    {
                        cmd.Parameters.AddWithValue("ToQuantity", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ToQuantity", Convert.ToInt32(toQuantity));
                    }

                    if (fromAmount == "Select One" || String.IsNullOrEmpty(fromAmount))
                    {
                        cmd.Parameters.AddWithValue("FromAmount", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("FromAmount", Convert.ToInt32(fromAmount));
                    }

                    if (toAmount == "Select One" || String.IsNullOrEmpty(toAmount))
                    {
                        cmd.Parameters.AddWithValue("ToAmount", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("ToAmount", Convert.ToInt32(toAmount));
                    }

                    if (adjustmentType == "Select One" || String.IsNullOrEmpty(adjustmentType))
                    {
                        cmd.Parameters.AddWithValue("AdjustmentTypeName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AdjustmentTypeName", adjustmentType);
                    }

                    if (countryName == "Select One" || String.IsNullOrEmpty(countryName))
                    {
                        cmd.Parameters.AddWithValue("CountryName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CountryName", countryName);
                    }

                    if (subBusinessUnitName == "Select One" || String.IsNullOrEmpty(subBusinessUnitName))
                    {
                        cmd.Parameters.AddWithValue("SubBusinessUnitName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubBusinessUnitName", subBusinessUnitName);
                    }

                    if (companyName == "Select One" || String.IsNullOrEmpty(companyName))
                    {
                        cmd.Parameters.AddWithValue("CompanyName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CompanyName", companyName);
                    }

                    if (subSegmentName == "Select One" || String.IsNullOrEmpty(subSegmentName))
                    {
                        cmd.Parameters.AddWithValue("SubSegmentName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubSegmentName", subSegmentName);
                    }

                    if (accountSubTypeName == "Select One" || String.IsNullOrEmpty(accountSubTypeName))
                    {
                        cmd.Parameters.AddWithValue("AccountSubTypeName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AccountSubTypeName", accountSubTypeName);
                    }

                    if (subCategoryName == "Select One" || String.IsNullOrEmpty(subCategoryName))
                    {
                        cmd.Parameters.AddWithValue("SubCategoryName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubCategoryName", subCategoryName);
                    }

                    if (rblMeasurementSystemText == "Select One" || String.IsNullOrEmpty(rblMeasurementSystemText))
                    {
                        cmd.Parameters.AddWithValue("AdjustmentPeriod", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AdjustmentPeriod", rblMeasurementSystemText);
                    }

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        return ds;
    }

    public void UpdateSKPickingBoard(SalesReportingChild li, int memberships)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        SqlCommand sqlCmd = new SqlCommand("dbo.Web_SR_UpdateAdjustments", sqlConn);
        sqlCmd.CommandType = CommandType.StoredProcedure;

        //   if (memberships == 1 || memberships == 2)
        //   {

        sqlCmd.Parameters.Add("@AdjustmentID", SqlDbType.Int).Value = li.AdjustmentID;
        sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = li.Date;
        sqlCmd.Parameters.Add("@Quantity", SqlDbType.Float).Value = li.Quantity;

        if (li.AmountLCY == 0)
        {
            sqlCmd.Parameters.Add("@AmountLCY", SqlDbType.Money).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@AmountLCY", SqlDbType.Money).Value = li.AmountLCY;
        }
        if (li.CostLCY == 0)
        {
            sqlCmd.Parameters.Add("@CostLCY", SqlDbType.Money).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@CostLCY", SqlDbType.Money).Value = li.CostLCY;
        }
        if (li.Comment == string.Empty)
        {
            sqlCmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = li.Comment;
        }
        if (li.Period == string.Empty)
        {
            sqlCmd.Parameters.Add("@Period", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@Period", SqlDbType.VarChar).Value = li.Period;
        }
        if (li.AdjustmentTypeName == string.Empty)
        {
            sqlCmd.Parameters.Add("@AdjustmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@AdjustmentTypeName", SqlDbType.VarChar).Value = li.AdjustmentTypeName;
        }
        if (li.CountryName == string.Empty)
        {
            sqlCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = li.CountryName;
        }
        if (li.SubBusinessUnitTypeName == string.Empty)
        {
            sqlCmd.Parameters.Add("@SubBusinessUnitName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@SubBusinessUnitName", SqlDbType.VarChar).Value = li.SubBusinessUnitTypeName;
        }
        if (li.CompanyName == string.Empty)
        {
            sqlCmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = li.CompanyName;
        }
        if (li.SubSegmentName == string.Empty)
        {
            sqlCmd.Parameters.Add("@SubSegmentName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@SubSegmentName", SqlDbType.VarChar).Value = li.SubSegmentName;
        }
        if (li.AccountSubTypeName == string.Empty)
        {
            sqlCmd.Parameters.Add("@AccountSubTypeName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@AccountSubTypeName", SqlDbType.VarChar).Value = li.AccountSubTypeName;
        }
        if (!String.IsNullOrEmpty(li.SubCategoryName))
        {
            sqlCmd.Parameters.Add("@SubCategoryName", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            sqlCmd.Parameters.Add("@SubCategoryName", SqlDbType.VarChar).Value = li.SubCategoryName;
        }
        //  }

        try
        {
            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GetSKPickingBoardWithParameters(string partNum, string Planner, string CommCode)
    {
        DataSet ds = new DataSet();
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());

        try
        {
            // SqlCommand sqlCmd = new SqlCommand("Web_GetLowInventory", sqlConn);
            // sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlConn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Web_SKPB_GetSKPickBoard", sqlConn);
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlConn.Close();
        }
        return ds;
    }

    public bool AddNewAdjustment(string date, string period, string quantity, string amountLCY, string amountSpotUSD, string amountAverageUSD, string costLCY, string costSpotUSD, string costAverageUSD, string comment, string adjustmentType, string countryName, string subBusinessUnitName, string companyName, string subSegmentName, string accountSubTypeName, string subCategoryName, string currencyName)
    {
        bool isSuccessful = true;
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString()))
            try
            {
                using (SqlCommand cmd = new SqlCommand("dbo.Web_SR_AddNewAdjustment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Date", Convert.ToDateTime(date));

                    if (period == "Select One" || String.IsNullOrEmpty(period))
                    {
                        cmd.Parameters.AddWithValue("Period", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Period", period);
                    }

                    if (String.IsNullOrEmpty(quantity))
                    {
                        cmd.Parameters.AddWithValue("Quantity", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Quantity", Convert.ToSingle(quantity));
                    }

                    if (String.IsNullOrEmpty(amountLCY))
                    {
                        cmd.Parameters.AddWithValue("AmountLCY", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AmountLCY", Convert.ToSingle(amountLCY));
                    }

                    if (String.IsNullOrEmpty(amountSpotUSD))
                    {
                        cmd.Parameters.AddWithValue("AmountSpotUSD", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AmountSpotUSD", Convert.ToSingle(amountSpotUSD));
                    }

                    if (String.IsNullOrEmpty(amountAverageUSD))
                    {
                        cmd.Parameters.AddWithValue("AmountAverageUSD", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AmountAverageUSD", Convert.ToSingle(amountAverageUSD));
                    }

                    if (String.IsNullOrEmpty(costLCY))
                    {
                        cmd.Parameters.AddWithValue("CostLCY", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CostLCY", Convert.ToSingle(costLCY));
                    }

                    if (String.IsNullOrEmpty(costSpotUSD))
                    {
                        cmd.Parameters.AddWithValue("CostSpotUSD", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CostSpotUSD", Convert.ToSingle(costSpotUSD));
                    }

                    if (String.IsNullOrEmpty(costAverageUSD))
                    {
                        cmd.Parameters.AddWithValue("CostAverageUSD", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CostAverageUSD", Convert.ToSingle(costAverageUSD));
                    }

                    if (String.IsNullOrEmpty(comment))
                    {
                        cmd.Parameters.AddWithValue("Comment", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Comment", comment);
                    }

                    if (adjustmentType == "Select One" || String.IsNullOrEmpty(adjustmentType))
                    {
                        cmd.Parameters.AddWithValue("AdjustmentTypeName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AdjustmentTypeName", adjustmentType);
                    }

                    if (countryName == "Select One" || String.IsNullOrEmpty(countryName))
                    {
                        cmd.Parameters.AddWithValue("CountryName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CountryName", countryName);
                    }

                    if (subBusinessUnitName == "Select One" || String.IsNullOrEmpty(subBusinessUnitName))
                    {
                        cmd.Parameters.AddWithValue("SubBusinessUnitName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubBusinessUnitName", subBusinessUnitName);
                    }

                    if (companyName == "Select One" || String.IsNullOrEmpty(companyName))
                    {
                        cmd.Parameters.AddWithValue("CompanyName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CompanyName", companyName);
                    }

                    if (subSegmentName == "Select One" || String.IsNullOrEmpty(subSegmentName))
                    {
                        cmd.Parameters.AddWithValue("SubSegmentName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubSegmentName", subSegmentName);
                    }

                    if (accountSubTypeName == "Select One" || String.IsNullOrEmpty(accountSubTypeName))
                    {
                        cmd.Parameters.AddWithValue("AccountSubTypeName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("AccountSubTypeName", accountSubTypeName);
                    }

                    if (subCategoryName == "Select One" || String.IsNullOrEmpty(subCategoryName))
                    {
                        cmd.Parameters.AddWithValue("SubCategoryName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("SubCategoryName", subCategoryName);
                    }

                    if (currencyName == "Select One" || String.IsNullOrEmpty(currencyName))
                    {
                        cmd.Parameters.AddWithValue("CurrencyName", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("CurrencyName", currencyName);
                    }

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
                isSuccessful = false;
            }
            finally
            {
                connection.Close();
            }
        return isSuccessful;
    }
}
