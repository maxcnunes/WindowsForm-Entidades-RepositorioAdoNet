USE [escolaCrud]
GO
/****** Object:  Table [dbo].[alunos]    Script Date: 01/31/2012 21:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alunos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[telefone] [varchar](50) NULL,
	[endereco] [varchar](50) NULL,
	[genero] [int] NULL,
	[ativo] [bit] NULL,
 CONSTRAINT [PK_alunos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[turmas]    Script Date: 01/31/2012 21:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[turmas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[dataInicio] [datetime] NULL,
	[ativo] [bit] NULL,
 CONSTRAINT [PK_turmas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[matriculas]    Script Date: 01/31/2012 21:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matriculas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idAluno] [int] NOT NULL,
	[idTurma] [int] NOT NULL,
	[dataMatricula] [datetime] NULL,
 CONSTRAINT [PK_matriculas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_matriculas_alunos]    Script Date: 01/31/2012 21:35:23 ******/
ALTER TABLE [dbo].[matriculas]  WITH CHECK ADD  CONSTRAINT [FK_matriculas_alunos] FOREIGN KEY([idAluno])
REFERENCES [dbo].[alunos] ([id])
GO
ALTER TABLE [dbo].[matriculas] CHECK CONSTRAINT [FK_matriculas_alunos]
GO
/****** Object:  ForeignKey [FK_matriculas_turmas]    Script Date: 01/31/2012 21:35:23 ******/
ALTER TABLE [dbo].[matriculas]  WITH CHECK ADD  CONSTRAINT [FK_matriculas_turmas] FOREIGN KEY([idTurma])
REFERENCES [dbo].[turmas] ([id])
GO
ALTER TABLE [dbo].[matriculas] CHECK CONSTRAINT [FK_matriculas_turmas]
GO
