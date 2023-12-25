USE [ShippingDB]
GO
SET IDENTITY_INSERT [dbo].[Currency] ON 

INSERT [dbo].[Currency] ([Id], [CurrencyName], [CurrencyCode], [IsDisabled]) VALUES (1, N'South African Rand', N'ZAR', 0)
INSERT [dbo].[Currency] ([Id], [CurrencyName], [CurrencyCode], [IsDisabled]) VALUES (2, N'United States Dollar', N'USD', 0)
INSERT [dbo].[Currency] ([Id], [CurrencyName], [CurrencyCode], [IsDisabled]) VALUES (3, N'Great British Pound', N'GBP', 0)
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[ShippingPorts] ON 

INSERT [dbo].[ShippingPorts] ([Id], [Port], [Country], [IsDisabled]) VALUES (1, N'Cape Town', N'South Africa', 0)
INSERT [dbo].[ShippingPorts] ([Id], [Port], [Country], [IsDisabled]) VALUES (2, N'Durban', N'South Africa', 0)
SET IDENTITY_INSERT [dbo].[ShippingPorts] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([Id], [Company], [ContactPerson], [Email], [TelephoneNumebr], [CurrencyId], [ShippingPortId]) VALUES (1, N'Sample Admin Company', N'Mohamed', N'mohamed@Amieros.co.za', N'0837985535', 1, 2)
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[FileStatuses] ON 

INSERT [dbo].[FileStatuses] ([Id], [Description]) VALUES (1, N'New')
INSERT [dbo].[FileStatuses] ([Id], [Description]) VALUES (2, N'Open')
INSERT [dbo].[FileStatuses] ([Id], [Description]) VALUES (3, N'OnHold')
INSERT [dbo].[FileStatuses] ([Id], [Description]) VALUES (4, N'Closed')
SET IDENTITY_INSERT [dbo].[FileStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Incoterms] ON 

INSERT [dbo].[Incoterms] ([Id], [InctermName], [IncotermSymbol]) VALUES (1, N'Cost Insurance Freight', N'CIF')
INSERT [dbo].[Incoterms] ([Id], [InctermName], [IncotermSymbol]) VALUES (2, N'Carriage and Freight', N'CFR')
INSERT [dbo].[Incoterms] ([Id], [InctermName], [IncotermSymbol]) VALUES (3, N'Free On Board', N'FOB')
SET IDENTITY_INSERT [dbo].[Incoterms] OFF
GO
SET IDENTITY_INSERT [dbo].[LineStatuses] ON 

INSERT [dbo].[LineStatuses] ([Id], [Description]) VALUES (1, N'New')
INSERT [dbo].[LineStatuses] ([Id], [Description]) VALUES (2, N'InProgress')
INSERT [dbo].[LineStatuses] ([Id], [Description]) VALUES (3, N'Complete')
INSERT [dbo].[LineStatuses] ([Id], [Description]) VALUES (4, N'OnHold')
INSERT [dbo].[LineStatuses] ([Id], [Description]) VALUES (5, N'Cancelled')
SET IDENTITY_INSERT [dbo].[LineStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] ON 

INSERT [dbo].[OrderStatuses] ([Id], [Description]) VALUES (1, N'New')
INSERT [dbo].[OrderStatuses] ([Id], [Description]) VALUES (2, N'InProgress')
INSERT [dbo].[OrderStatuses] ([Id], [Description]) VALUES (3, N'Complete')
INSERT [dbo].[OrderStatuses] ([Id], [Description]) VALUES (4, N'OnHold')
INSERT [dbo].[OrderStatuses] ([Id], [Description]) VALUES (5, N'Cancelled')
SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Description], [IsDisabled]) VALUES (1, N'Admin Test Product 1', 0)
INSERT [dbo].[Products] ([Id], [Description], [IsDisabled]) VALUES (2, N'Admin Test Product 2', 0)
INSERT [dbo].[Products] ([Id], [Description], [IsDisabled]) VALUES (3, N'Admin Test Product 3', 0)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
