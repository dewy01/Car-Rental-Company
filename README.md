# CarRentalCompany
ASP .NET based website

Implementation includes:
CSS,
CRUD operations,
ADO NET,
Entity Framework Core,
Stored procedures,
One to many relation,
Many to many relation,
Authorization and authentication,
Server and client based validation,
Cookies.

STORED PROCEDURES

CREATE PROCEDURE [dbo].[SelectAllColours]
AS
	SELECT * from Colours
RETURN 0


CREATE PROCEDURE [dbo].[SelectColorById]
	@ColourId int
AS
	SELECT * from Colours where @ColourId = Id
RETURN 0
