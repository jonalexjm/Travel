USE [TravelDb]
GO
/****** Object:  Table [dbo].[autores]    Script Date: 12/01/2022 3:20:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[apellidos] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autores_has_libros]    Script Date: 12/01/2022 3:20:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autores_has_libros](
	[autores_id] [int] NULL,
	[libros_ISBN] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[editoriales]    Script Date: 12/01/2022 3:20:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[editoriales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[sede] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 12/01/2022 3:20:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[ISBN] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](40) NULL,
	[sinopsis] [text] NULL,
	[n_paginas] [varchar](45) NULL,
	[editoriales] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [fk_autores] FOREIGN KEY([autores_id])
REFERENCES [dbo].[autores] ([id])
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [fk_autores]
GO
ALTER TABLE [dbo].[autores_has_libros]  WITH CHECK ADD  CONSTRAINT [fk_libros] FOREIGN KEY([libros_ISBN])
REFERENCES [dbo].[libros] ([ISBN])
GO
ALTER TABLE [dbo].[autores_has_libros] CHECK CONSTRAINT [fk_libros]
GO
ALTER TABLE [dbo].[libros]  WITH CHECK ADD  CONSTRAINT [fk_editoriales] FOREIGN KEY([editoriales])
REFERENCES [dbo].[editoriales] ([id])
GO
ALTER TABLE [dbo].[libros] CHECK CONSTRAINT [fk_editoriales]
GO
