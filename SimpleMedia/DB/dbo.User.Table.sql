USE [SimpleMedia]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2025/5/1 下午 10:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
	[Salt] [nvarchar](512) NULL,
	[CoverImage] [varbinary](max) NULL,
	[Biography] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
