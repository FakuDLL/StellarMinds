-- StellarMinds - limpieza de datos de prueba
-- No ejecuta migraciones. Ejecutar sobre una base con las migraciones aplicadas.

DELETE FROM [Observaciones];
DELETE FROM [AuditoriasPrestamo];
DELETE FROM [Prestamos];
DELETE FROM [ObjetosCelestes];
DELETE FROM [Equipos];
DELETE FROM [Usuarios];

DBCC CHECKIDENT ('[Observaciones]', RESEED, 0);
DBCC CHECKIDENT ('[AuditoriasPrestamo]', RESEED, 0);
DBCC CHECKIDENT ('[Prestamos]', RESEED, 0);
DBCC CHECKIDENT ('[ObjetosCelestes]', RESEED, 0);
DBCC CHECKIDENT ('[Equipos]', RESEED, 0);
DBCC CHECKIDENT ('[Usuarios]', RESEED, 0);
