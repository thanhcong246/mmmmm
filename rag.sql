--------------------------
CREATE PROCEDURE dbo.Web_SR_AddNewAdjustment @Date DATETIME
	,@Period NVARCHAR(100) = NULL
	,@Quantity FLOAT(53) = NULL
	,@AmountLCY MONEY = NULL
	,@AmountSpotUSD MONEY = NULL
	,@AmountAverageUSD MONEY = NULL
	,@CostLCY MONEY = NULL
	,@CostSpotUSD MONEY = NULL
	,@CostAverageUSD MONEY = NULL
	,@Comment NVARCHAR(MAX) = NULL
	,@AdjustmentTypeName NVARCHAR(100) = NULL
	,@CountryName NVARCHAR(100) = NULL
	,@SubBusinessUnitName NVARCHAR(100) = NULL
	,@CompanyName NVARCHAR(100) = NULL
	,@SubSegmentName NVARCHAR(100) = NULL
	,@AccountSubTypeName NVARCHAR(100) = NULL
	,@SubCategoryName NVARCHAR(100) = NULL
	,@CurrencyName NVARCHAR(100) = NULL
	,@UpdateUser NVARCHAR(100) = NULL
AS
SET NOCOUNT ON;

DECLARE @PeriodID INT = NULL;
DECLARE @AdjustmentTypeID INT = NULL;
DECLARE @CountryID INT = NULL;
DECLARE @SubBusinessUnitID INT = NULL;
DECLARE @CompanyID INT = NULL;
DECLARE @SubSegmentID INT = NULL;
DECLARE @AccountSubTypeID INT = NULL;
DECLARE @SubCategoryID INT = NULL;
DECLARE @CurrencyID INT = NULL;
DECLARE @AdjustmentAmountSpotUSD MONEY = NULL;
DECLARE @AdjustmentCostSpotUSD MONEY = NULL;
DECLARE @AdjustmentID INT;
IF (@Period IS NOT NULL)
BEGIN
	SET @PeriodID = (
			SELECT TOP 1 [PeriodID]
			FROM [dbo].[Period]
			WHERE [Period] = @Period
			);
END

IF (@AdjustmentTypeName IS NOT NULL)
BEGIN
	SET @AdjustmentTypeID = (
			SELECT TOP 1 [AdjustmentTypeID]
			FROM [dbo].[AdjustmentType]
			WHERE [AdjustmentTypeName] = @AdjustmentTypeName
			);
END

IF (@CountryName IS NOT NULL)
BEGIN
	SET @CountryID = (
			SELECT TOP 1 [CountryID]
			FROM [dbo].[Country]
			WHERE [CountryName] = @CountryName
			);
END

IF (@SubBusinessUnitName IS NOT NULL)
BEGIN
	SET @SubBusinessUnitID = (
			SELECT TOP 1 [SubBusinessUnitID]
			FROM [dbo].[SubBusinessUnit]
			WHERE [SubBusinessUnitName] = @SubBusinessUnitName
			);
END

IF (@CompanyName IS NOT NULL)
BEGIN
	SET @CompanyID = (
			SELECT TOP 1 [CompanyID]
			FROM [dbo].[Company]
			WHERE [CompanyName] = @CompanyName
			);
END

IF (@SubSegmentName IS NOT NULL)
BEGIN
	SET @SubSegmentID = (
			SELECT TOP 1 [SubSegmentID]
			FROM [dbo].[SubSegment]
			WHERE [SubSegmentName] = @SubSegmentName
			);
END

IF (@AccountSubTypeName IS NOT NULL)
BEGIN
	SET @AccountSubTypeID = (
			SELECT TOP 1 [AccountSubTypeID]
			FROM [dbo].[AccountSubType]
			WHERE [AccountSubTypeName] = @AccountSubTypeName
			);
END

IF (@SubCategoryName IS NOT NULL)
BEGIN
	SET @SubCategoryID = (
			SELECT TOP 1 [SubCategoryID]
			FROM [dbo].[SubCategory]
			WHERE [SubCategoryName] = @SubCategoryName
			);
END

IF (@CurrencyID IS NOT NULL)
BEGIN
	SET @CurrencyID = (
			SELECT TOP 1 [CurrencyID]
			FROM [dbo].[Currency]
			WHERE [CurrencyName] = @CurrencyName
			);
END

INSERT INTO [CSIDW].[dbo].[Adjustment] (
	[AdjustmentDate]
	,[PeriodID]
	,[AdjustmentQuantity]
	,[AdjustmentAmountLCY]
	,[AdjustmentAmountAvgUSD]
	,[AdjustmentCostLCY]
	,[AdjustmentCostAvgUSD]
	,[AdjustmentComment]
	,[AdjustmentTypeID]
	,[CountryID]
	,[SubBusinessUnitID]
	,[CompanyID]
	,[SubSegmentID]
	,[AccountSubTypeID]
	,[SubCategoryID]
	,[CurrencyID]
	,[UpdateUser]
	,[UpdateDate]
	)
VALUES (
	@Date
	,@PeriodID
	,@Quantity
	,@AmountLCY
	,@AmountAverageUSD
	,@CostLCY
	,@CostAverageUSD
	,@Comment
	,@AdjustmentTypeID
	,@CountryID
	,@SubBusinessUnitID
	,@CompanyID
	,@SubSegmentID
	,@AccountSubTypeID
	,@SubCategoryID
	,@CurrencyID
	,@UpdateUser
	,GETDATE()
	);

SET @AdjustmentID = SCOPE_IDENTITY();

SET @AdjustmentAmountSpotUSD = (
		SELECT TOP 1 a.AdjustmentAmountLCY * d.SpotRate
		FROM Adjustment a
		LEFT JOIN Company b ON a.CompanyID = b.CompanyID
		LEFT JOIN Currency c ON b.CompanyLocalCurrency = c.CurrencyCode
		LEFT JOIN CurrencyRate d ON c.CurrencyCode = d.FromCurrencyCode
		WHERE YEAR(a.AdjustmentDate) = YEAR(d.CurrencyRateDate)
			AND MONTH(a.AdjustmentDate) = MONTH(d.CurrencyRateDate)
			AND a.[AdjustmentID] = @AdjustmentID
		);
SET @AdjustmentCostSpotUSD = (
		SELECT TOP 1 a.AdjustmentCostLCY * d.SpotRate
		FROM Adjustment a
		LEFT JOIN Company b ON a.CompanyID = b.CompanyID
		LEFT JOIN Currency c ON b.CompanyLocalCurrency = c.CurrencyCode
		LEFT JOIN CurrencyRate d ON c.CurrencyCode = d.FromCurrencyCode
		WHERE YEAR(a.AdjustmentDate) = YEAR(d.CurrencyRateDate)
			AND MONTH(a.AdjustmentDate) = MONTH(d.CurrencyRateDate)
			AND a.[AdjustmentID] = @AdjustmentID
		);

UPDATE [CSIDW].[dbo].[Adjustment]
SET [AdjustmentAmountSpotUSD] = @AdjustmentAmountSpotUSD
	,[AdjustmentCostSpotUSD] = @AdjustmentCostSpotUSD
WHERE [AdjustmentID] = @AdjustmentID;


GO


--------------------------------

CREATE PROCEDURE dbo.Web_SR_AdjustmentFrequency
@Frequency NVARCHAR(100) 
AS
SET NOCOUNT ON;

SELECT A.[AdjustmentTemplateID], A.[AdjustmentQuantity], A.[AdjustmentAmount], A.[AdjustmentCost], A.[AdjustmentFrequency], 
	A.[AdjustmentTypeID], AT.[AdjustmentTypeName],
    A.[CountryID], CO.[CountryName], 
	A.[SubBusinessUnitID], T.[SubBusinessUnitName],
	A.[SubSegmentID], SSN.[SubSegmentName],
	A.[AccountSubTypeID], AST.[AccountSubTypeName],
	A.[SubCategoryID], SCN.[SubCategoryName],
	A.[CompanyID], COM.[CompanyName],
	A.[UpdateUser], A.[UpdateDate]
	FROM [CSIDW].[dbo].[AdjustmentTemplate] A
	LEFT OUTER JOIN [CSIDW].[dbo].[AdjustmentType] AT ON AT.[AdjustmentTypeID] = A.[AdjustmentTypeID]
    LEFT OUTER JOIN [CSIDW].[dbo].[Country] CO ON CO.[CountryID] = A.[CountryID] 
	LEFT OUTER JOIN [CSIDW].[dbo].[SubBusinessUnit] T ON T.[SubBusinessUnitID] = A.[SubBusinessUnitID]
	LEFT OUTER JOIN [CSIDW].[dbo].[SubSegment] SSN ON SSN.[SubSegmentID] = A.[SubSegmentID]
	LEFT OUTER JOIN [CSIDW].[dbo].[AccountSubType] AST ON AST.[AccountSubTypeID] = A.[AccountSubTypeID]
	LEFT OUTER JOIN [CSIDW].[dbo].[SubCategory] SCN ON SCN.[SubCategoryID] = A.[SubCategoryID]
	LEFT OUTER JOIN [CSIDW].[dbo].[Company] COM ON COM.[CompanyID] = A.[CompanyID]
	WHERE A.[AdjustmentFrequency] = @Frequency

GO

----------------------------------