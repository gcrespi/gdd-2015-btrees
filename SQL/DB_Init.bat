sqlcmd -S localhost\SQLSERVER2012 -U gd -P gd2015 -i All_Drop.sql,Tables_Create.sql,Views_Create.sql,Sp_Estadisticas_Create.sql,SP_GetListas_Create.sql,SP_Login_Create.sql,SP_TraerData_Create.sql,SP_GetsManejoCompras.sql,SP_GetsManejoViajes.sql,SP_GetsManejoCancelacion.sql,SP_Clientes_Manage.sql,SP_Compras_Create.sql,SP_Rol_JOIN_Funcionalidad.sql,SP_Rol_Create.sql,FUNC_ExistsNameWithOtherID.sql,SP_ManejoRegLlegada.sql,TR_RemoverRolesInhabilitados.sql,SP_Manejo_Millas.sql  -a 32767 -o Initialization_Result.txt


