USE [caisys]
GO
/****** Object:  Table [dbo].[AccountCharts]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountCharts](
	[AccountNo] [nchar](25) NOT NULL,
	[ParentNo] [nchar](25) NOT NULL,
	[NameAr] [nvarchar](255) NOT NULL,
	[NameEn] [nvarchar](255) NOT NULL,
	[AccountType] [int] NOT NULL,
	[DetailAccount] [bit] NOT NULL,
	[AccountLevel] [int] NOT NULL,
	[CostCenter] [int] NOT NULL,
 CONSTRAINT [PK_AccountsChart] PRIMARY KEY CLUSTERED 
(
	[AccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogs]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogs](
	[Id] [nchar](36) NOT NULL,
	[ActionId] [int] NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[UserId] [nchar](10) NOT NULL,
 CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralLedgers]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedgers](
	[Id] [nchar](36) NOT NULL,
	[EntryNo] [int] NOT NULL,
	[AccountNo] [nchar](25) NOT NULL,
	[Debit] [decimal](18, 0) NOT NULL,
	[Credit] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_GeneralLedgers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invetories]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invetories](
	[Id] [nchar](36) NOT NULL,
	[ProductCode] [nvarchar](10) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[QuantityIn] [int] NOT NULL,
	[TotalCost] [decimal](18, 0) NOT NULL,
	[UnitsSold] [int] NOT NULL,
	[SellingPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Invetories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[DetailId] [nchar](36) NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[PorductCode] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceNo] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[CustomerAccount] [int] NOT NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Discount] [decimal](18, 0) NOT NULL,
	[NetAmount] [decimal](18, 0) NOT NULL,
	[Posted] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journals]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journals](
	[EntryNo] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[AccountNo] [nchar](25) NOT NULL,
	[Explanation] [nvarchar](50) NOT NULL,
	[Debit] [decimal](18, 0) NOT NULL,
	[Credit] [decimal](18, 0) NOT NULL,
	[Posted] [bit] NOT NULL,
 CONSTRAINT [PK_Journals] PRIMARY KEY CLUSTERED 
(
	[EntryNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogActions]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogActions](
	[ActionId] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LogActions] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductCode] [nvarchar](10) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[SupplierCode] [int] NOT NULL,
	[Barcode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 18-Aug-2019 8:27:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierCode] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountCharts] ADD  CONSTRAINT [DF_AccountsChart_CostCenter]  DEFAULT ((0)) FOR [CostCenter]
GO
ALTER TABLE [dbo].[ActivityLogs]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLogs_LogActions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[LogActions] ([ActionId])
GO
ALTER TABLE [dbo].[ActivityLogs] CHECK CONSTRAINT [FK_ActivityLogs_LogActions]
GO
ALTER TABLE [dbo].[GeneralLedgers]  WITH CHECK ADD  CONSTRAINT [FK_GeneralLedgers_GeneralLedgers] FOREIGN KEY([AccountNo])
REFERENCES [dbo].[AccountCharts] ([AccountNo])
GO
ALTER TABLE [dbo].[GeneralLedgers] CHECK CONSTRAINT [FK_GeneralLedgers_GeneralLedgers]
GO
ALTER TABLE [dbo].[GeneralLedgers]  WITH CHECK ADD  CONSTRAINT [FK_GeneralLedgers_Journals] FOREIGN KEY([EntryNo])
REFERENCES [dbo].[Journals] ([EntryNo])
GO
ALTER TABLE [dbo].[GeneralLedgers] CHECK CONSTRAINT [FK_GeneralLedgers_Journals]
GO
ALTER TABLE [dbo].[Invetories]  WITH CHECK ADD  CONSTRAINT [FK_Invetories_Invetories] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[Products] ([ProductCode])
GO
ALTER TABLE [dbo].[Invetories] CHECK CONSTRAINT [FK_Invetories_Invetories]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceNo])
REFERENCES [dbo].[Invoices] ([InvoiceNo])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[Journals]  WITH CHECK ADD  CONSTRAINT [FK_Journals_AccountsChart] FOREIGN KEY([AccountNo])
REFERENCES [dbo].[AccountCharts] ([AccountNo])
GO
ALTER TABLE [dbo].[Journals] CHECK CONSTRAINT [FK_Journals_AccountsChart]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierCode])
REFERENCES [dbo].[Suppliers] ([SupplierCode])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
