create proc [dbo].[TraerData]
( @Tabla nvarchar(20) )
as
declare @sentencia nvarchar(200)
set @sentencia='select * from ' + @Tabla 
execute (@sentencia)


