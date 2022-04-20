﻿<%@ Page Title="Adjustment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adjustment.aspx.cs" Inherits="SalesReportingWebsite.Adjustments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Table ID="Table1" runat="server" Width="100%" Style="margin-bottom: 0px">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnAddNewAdjustments" runat="server" Text="Add new Adjustments" />
                </asp:TableCell>
                <asp:TableCell CssClass="dateCell">
                    <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="DateLabel" AutoPostBack="True" Text="Select One" OnTextChanged="ddl_SelectedIndexChanged"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="DateLabel" AutoPostBack="True" Text="Select One" OnTextChanged="ddl_SelectedIndexChanged"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Period     "></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlPeriod" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell CssClass="dateCell">
                    <asp:Label ID="Label4" runat="server" Text="From Quantity"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFromQuantity" runat="server" CssClass="DateLabel" Text="0" AutoPostBack="True" OnTextChanged="ddl_SelectedIndexChanged"  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="To Quantity"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtToQuantity" runat="server" CssClass="DateLabel" Text="99999999" AutoPostBack="True" OnTextChanged="ddl_SelectedIndexChanged"  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell CssClass="dateCell">
                    <asp:Label ID="Label6" runat="server" Text="From Amount"></asp:Label>
                    <asp:TextBox ID="txtFromAmount" runat="server" CssClass="DateLabel" Text="0" AutoPostBack="True" OnTextChanged="ddl_SelectedIndexChanged"  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="To Amount"></asp:Label>
                    <asp:TextBox ID="txtToAmount" runat="server" CssClass="DateLabel" Text="99999999" AutoPostBack="True" OnTextChanged="ddl_SelectedIndexChanged"  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label8" runat="server" Text="Adjustment Type"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlAdjustmentType" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label9" runat="server" Text="Country Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label10" runat="server" Text="Sub Business Unit Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlSubBusinessUnitName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="Company Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlCompanyName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label12" runat="server" Text="Sub Segment Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlSubSegmentName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label13" runat="server" Text="Account Sub Type Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlAccountSubTypeName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label14" runat="server" Text="Sub Category Name"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlSubCategoryName" runat="server" AutoPostBack="true" AppendDataBoundItems="true"
                        OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="rblMeasurementSystem" runat="server">
                        <asp:ListItem Text="Daily" Value="Daily" />
                        <asp:ListItem Text="Monthly" Value="Monthly" />
                    </asp:RadioButtonList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnAdjustments" runat="server" Text="Adjustments" OnClick="btnAdjustments_Click" />
                    <br />

                    <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                    <br />

                    <asp:CheckBox ID="chkBoxReset" runat="server" OnCheckedChanged="chkBoxResetCheckedChanged" AutoPostBack="true" />
                    Reset Selection
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <div>
            <b>
                <asp:Label ID="lblRecordCount" runat="server" Text=""></asp:Label></b>
        </div>
        <asp:GridView ID="gvSKPickingBoard" runat="server" AutoGenerateColumns="false"
            Width="98%" Style="margin: 0% 1% 0% 1%" OnRowEditing="gvSKPickingBoard_RowEditing"
            OnRowCancelingEdit="gvSKPickingBoard_RowCancelingEdit" OnRowDataBound="gvSKPickingBoard_RowDataBound"
            OnRowUpdating="gvSKPickingBoard_RowUpdating" AllowPaging="true"
            PageSize="20" AllowSorting="true"
            OnPageIndexChanging="gvSKPickingBoard_PageIndexChanging"
            OnSorting="gvSKPickingBoard_SortData" DataKeyNames="AdjustmentID">
            <HeaderStyle CssClass="gridHeader" />
            <Columns>
                <asp:CommandField ShowEditButton="true" ItemStyle-Width="50" />
                <asp:BoundField DataField="AdjustmentID" HeaderText="Adjustment ID" Visible="false" ReadOnly="true">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lnl1" Text='<%#DataBinder.Eval(Container.DataItem, "AdjustmentDate").ToString()%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AdjustmentDate" runat="server" ReadOnly="true" Text='<%#Bind("AdjustmentDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Period">
                    <ItemTemplate>
                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("Period")%>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlPeriods" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="AdjustmentQuantity" Text='<%# Eval("AdjustmentQuantity")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AdjustmentQuantity" runat="server" Text='<%# Eval("AdjustmentQuantity")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount LCY">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="AdjustmentAmountLCY" Text='<%# Eval("AdjustmentAmountLCY")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AdjustmentAmountLCY" runat="server" Text='<%# Eval("AdjustmentAmountLCY")%>'  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AdjustmentAmountSpotUSD" HeaderText="Amount Spot USD" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="AdjustmentAmountAvgUSD" HeaderText="Amount Avg USD" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Cost LCY">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="AdjustmentCostLCY" Text='<%# Eval("AdjustmentCostLCY")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AdjustmentCostLCY" runat="server" Text='<%# Eval("AdjustmentCostLCY")%>'  onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AdjustmentCostSpotUSD" HeaderText="Cost Spot USD" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="AdjustmentCostAvgUSD" HeaderText="Cost Avg USD" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Comment">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="AdjustmentComment" Text='<%# Eval("AdjustmentComment")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="AdjustmentComment" Columns="20" Rows="5" runat="server" Text='<%# Eval("AdjustmentComment")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adjustment Type">
                    <ItemTemplate>
                        <asp:Label ID="lblAdjustmentTypeName" runat="server" Text='<%# Eval("AdjustmentTypeName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblAdjustmentTypeName" runat="server" Text='<%# Eval("AdjustmentTypeName")%>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlAdjustmentTypeNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Currency Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCurrencyName" runat="server" Text='<%# Eval("CurrencyName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("CountryName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("CountryName")%>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlCountryNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sub Business Unit Name">
                    <ItemTemplate>
                        <asp:Label ID="lblSubBusinessUnitName" runat="server" Text='<%# Eval("SubBusinessUnitName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblSubBusinessUnitName" runat="server" Text='<%# Eval("SubBusinessUnitName")%>' Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlSubBusinessUnitNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>' Visible="false" />
                        <asp:DropDownList ID="ddlCompanyNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sub Segment Name">
                    <ItemTemplate>
                        <asp:Label ID="lblSubSegmentName" runat="server" Text='<%# Eval("SubSegmentName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblSubSegmentName" runat="server" Text='<%# Eval("SubSegmentName") %>' Visible="false" />
                        <asp:DropDownList ID="ddlSubSegmentNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Sub Type Name">
                    <ItemTemplate>
                        <asp:Label ID="lblAccountSubTypeName" runat="server" Text='<%# Eval("AccountSubTypeName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblAccountSubTypeName" runat="server" Text='<%# Eval("AccountSubTypeName") %>' Visible="false" />
                        <asp:DropDownList ID="ddlAccountSubTypeNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sub Category Name">
                    <ItemTemplate>
                        <asp:Label ID="lblSubCategoryName" runat="server" Text='<%# Eval("SubCategoryName")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblSubCategoryName" runat="server" Text='<%# Eval("SubCategoryName") %>' Visible="false" />
                        <asp:DropDownList ID="ddlSubCategoryNames" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UpdateUser" HeaderText="Update User" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="UpdateDate" HeaderText="Update Date" ReadOnly="true" ItemStyle-Width="100">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <%-- <PagerSettings Mode="NextPrevious" FirstPageText="First" LastPageText="Last" NextPageText=" Next &gt;" PreviousPageText="&lt; Prev "/> --%>
            <PagerStyle CssClass="gridPager" />
        </asp:GridView>
    </div>

    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnAddNewAdjustments"
        CancelControlID="btnClose" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
        <asp:Table ID="Table2" runat="server">
            <asp:TableHeaderRow TableSection="TableHeader">
                <asp:TableCell runat="server">Adjustment</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Groupings</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Date:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newDate" runat="server" CssClass="DateLabel" OnTextChanged="ddl_SelectedIndexChanged"></asp:TextBox></asp:TableCell>
                <asp:TableCell runat="server">Adjustment Type:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newAdjustmentType" runat="server" AppendDataBoundItems="true" AutoPostBack="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Period:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newPeriod" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell runat="server">Country Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newCountryName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Quantity:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newQuantity" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Sub Business Unit Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newSubBusinessUnitName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Amount LCY:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newAmountLCY" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Company Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newCompanyName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Amount Spot USD:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newAmountSpotUSD" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Sub Segment Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newSubSegmentName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Amount Average USD:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newAmountAverageUSD" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Account Sub Type Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newAccountSubTypeName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Cost LCY:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newCostLCY" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Sub Category Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newSubCategoryName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Cost Spot USD:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newCostSpotUSD" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server">Currency Name:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:DropDownList ID="newCurrencyName" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Cost Average USD:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newCostAverageUSD" runat="server" onkeypress="return onlyDotsAndNumbers(event)"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Comment:</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="newComment" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnSaveNewAdjustment" runat="server" Text="Save" OnClick="btnSaveNewAdjustment_Click" />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </asp:Panel>
    <!-- ModalPopupExtender -->

    <!-- ModalPopupExtender -->
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="btnAdjustments"
        CancelControlID="btnAdjClose" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        <div>
            <div>
                <b>
                    <asp:Label ID="lblAdjustmentCount" runat="server" Text=""></asp:Label></b>
            </div>
            <asp:GridView ID="AdjustmentGridView" runat="server" AutoGenerateColumns="false" Width="98%" Style="margin: 0% 1% 0% 1%" OnRowEditing="gvAdjustment_RowEditing"
                OnRowCancelingEdit="gvAdjustment_RowCancelingEdit" OnRowDataBound="gvAdjustment_RowDataBound" OnRowUpdating="gvAdjustment_RowUpdating" AllowPaging="true"
                PageSize="20" AllowSorting="true" OnPageIndexChanging="gvAdjustment_PageIndexChanging" OnSorting="gvAdjustment_SortData" DataKeyNames="AdjustmentTemplateID">
                <HeaderStyle CssClass="gridHeader" />
                <Columns>
                    <asp:CommandField ShowEditButton="true" ItemStyle-Width="50" />
                    <asp:BoundField DataField="AdjustmentTemplateID" HeaderText="Adjustment ID" Visible="false" ReadOnly="true">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="popAdjustmentQuantity" Text='<%# Eval("AdjustmentQuantity")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="popAdjustmentQuantity" runat="server" Text='<%# Eval("AdjustmentQuantity")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="popAdjustmentAmount" Text='<%# Eval("AdjustmentAmount")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="popAdjustmentAmount" runat="server" Text='<%# Eval("AdjustmentAmount")%>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Frequency">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="AdjustmentFrequency" Text='<%# Eval("AdjustmentFrequency")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lnl1" Text='<%#DataBinder.Eval(Container.DataItem, "AdjustmentDate").ToString()%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>    
                    <asp:TemplateField HeaderText="Adjustment Type">
                        <ItemTemplate>
                            <asp:Label ID="lblpopAdjustmentTypeName" runat="server" Text='<%# Eval("AdjustmentTypeName")%>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblpopAdjustmentTypeName" runat="server" Text='<%# Eval("AdjustmentTypeName")%>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlpopAdjustmentTypeNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Country Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopCountryName" runat="server" Text='<%# Eval("CountryName")%>'></asp:Label>
                        </ItemTemplate>
                       <%-- <EditItemTemplate>
                            <asp:Label ID="lblpopCountryName" runat="server" Text='<%# Eval("CountryName")%>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlpopCountryNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub Business Unit Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopSubBusinessUnitName" runat="server" Text='<%# Eval("SubBusinessUnitName")%>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblpopSubBusinessUnitName" runat="server" Text='<%# Eval("SubBusinessUnitName")%>' Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlpopSubBusinessUnitNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopCompanyName" runat="server" Text='<%# Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblpopCompanyName" runat="server" Text='<%# Eval("CompanyName") %>' Visible="false" />
                            <asp:DropDownList ID="ddlpopCompanyNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub Segment Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopSubSegmentName" runat="server" Text='<%# Eval("SubSegmentName")%>'></asp:Label>
                        </ItemTemplate>
<%--                        <EditItemTemplate>
                            <asp:Label ID="lblpopSubSegmentName" runat="server" Text='<%# Eval("SubSegmentName") %>' Visible="false" />
                            <asp:DropDownList ID="ddlpopSubSegmentNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Sub Type Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopAccountSubTypeName" runat="server" Text='<%# Eval("AccountSubTypeName")%>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblpopAccountSubTypeName" runat="server" Text='<%# Eval("AccountSubTypeName") %>' Visible="false" />
                            <asp:DropDownList ID="ddlpopAccountSubTypeNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sub Category Name">
                        <ItemTemplate>
                            <asp:Label ID="lblpopSubCategoryName" runat="server" Text='<%# Eval("SubCategoryName")%>'></asp:Label>
                        </ItemTemplate>
                        <%--<EditItemTemplate>
                            <asp:Label ID="lblpopSubCategoryName" runat="server" Text='<%# Eval("SubCategoryName") %>' Visible="false" />
                            <asp:DropDownList ID="ddlpopSubCategoryNames" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UpdateUser" HeaderText="Update User" ReadOnly="true" ItemStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="UpdateDate" HeaderText="Update Date" ReadOnly="true" ItemStyle-Width="100">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:BoundField>
                </Columns>
                <%-- <PagerSettings Mode="NextPrevious" FirstPageText="First" LastPageText="Last" NextPageText=" Next &gt;" PreviousPageText="&lt; Prev "/> --%>
                <PagerStyle CssClass="gridPager" />
            </asp:GridView>
        </div>
        <asp:Button ID="btnAdjClose" runat="server" Text="Close" />
    </asp:Panel>
    <!-- ModalPopupExtender -->
</asp:Content>
