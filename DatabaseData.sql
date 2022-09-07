USE [WPFApp_Database]
GO
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([Id], [Username], [Password]) VALUES (1, N'Admin', N'Admin')
INSERT [dbo].[Table] ([Id], [Username], [Password]) VALUES (2, N'User', N'User')
INSERT [dbo].[Table] ([Id], [Username], [Password]) VALUES (3, N'Guest', N'Guest')
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
SET IDENTITY_INSERT [dbo].[TablePeople] ON 

INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (1, N'Max', N'Mustermann', N'max@mustermann.at', N'männlich', N'12.12.1990')
INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (2, N'Beate', N'Beispiel', N'beate@beispiel.com', N'weiblich', N'11.11.1989')
INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (3, N'Rainer', N'Zufall', N'rainer@zufall.at', N'männlich', N'10.10.1980')
INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (4, N'Dinge', N'Inge', N'inge@dinge.at', N'weiblich', N'09.09.1999 00:00:00')
INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (5, N'Ralph', N'Reichts', N'ralph@reichts.at', N'männlich', N'13.09.2000 00:00:00')
INSERT [dbo].[TablePeople] ([Id], [Firstname], [Lastname], [E-Mail], [Geschlecht], [Geburtstag]) VALUES (7, N'asd', N'asd', N'asd.asd@asdf.as', N'männlich', N'27.09.2000 00:00:00')
SET IDENTITY_INSERT [dbo].[TablePeople] OFF
GO
