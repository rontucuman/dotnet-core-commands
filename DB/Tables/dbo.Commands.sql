CREATE TABLE [dbo].[Commands] (
  [Id] [int] IDENTITY,
  [HowTo] [nvarchar](250) NOT NULL,
  [Line] [nvarchar](max) NOT NULL,
  [Platform] [nvarchar](max) NOT NULL,
  CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED ([Id])
)
ON [PRIMARY]
TEXTIMAGE_ON [PRIMARY]
GO