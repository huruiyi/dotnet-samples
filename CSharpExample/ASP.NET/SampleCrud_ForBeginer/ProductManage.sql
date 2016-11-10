USE [ProductManage]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 03/25/2016 15:03:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Autokey] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Producttype] [int] NOT NULL,
	[ImagePath] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Autokey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


