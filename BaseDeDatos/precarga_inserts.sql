-- StellarMinds - precarga definitiva de datos de prueba
-- Supone SQL Server y esquema EF aplicado por migraciones.
-- PasswordHash usa BCrypt. Estas cuentas son exclusivamente de demostración local.

SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [NombreCompleto], [Direccion], [Telefono], [Email], [NombreUsuario], [PasswordHash], [Rol]) VALUES
(1, N'Admin StellarMinds', N'Av. Observatorio 1000', N'099100001', N'admin@stellarminds.test', N'admin', N'$2a$11$MAA.HwVnGv0GW1A6UXGl8.TVFnJQbvDDdjJBCp4iz6AUMDYBgDTmm', 1),
(2, N'Coordinador Principal', N'Av. Observatorio 1100', N'099100002', N'coordinador@stellarminds.test', N'coordinador', N'$2a$11$4tt191TFAih.CqJ1fLVYXuSbbinsqFdCTkP1IzQcMK5dQtfqquB5i', 2),
(3, N'Socio Principal', N'Calle Lunar 120', N'099100003', N'socio@stellarminds.test', N'socio', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(4, N'Coordinadora Norte', N'Ruta Astral 44', N'099100004', N'coord.norte@stellarminds.test', N'coordnorte', N'$2a$11$4tt191TFAih.CqJ1fLVYXuSbbinsqFdCTkP1IzQcMK5dQtfqquB5i', 2),
(5, N'Ana Ribeiro', N'Orion 15', N'099100005', N'ana.ribeiro@stellarminds.test', N'aribeiro', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(6, N'Bruno Silva', N'Vega 23', N'099100006', N'bruno.silva@stellarminds.test', N'bsilva', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(7, N'Carla Medina', N'Polaris 8', N'099100007', N'carla.medina@stellarminds.test', N'cmedina', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(8, N'Diego Pereira', N'Andromeda 71', N'099100008', N'diego.pereira@stellarminds.test', N'dpereira', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(9, N'Elena Costa', N'Centauri 34', N'099100009', N'elena.costa@stellarminds.test', N'ecosta', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(10, N'Federico Torres', N'Kepler 56', N'099100010', N'federico.torres@stellarminds.test', N'ftorres', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(11, N'Gabriela Nuñez', N'Cassini 19', N'099100011', N'gabriela.nunez@stellarminds.test', N'gnunez', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3),
(12, N'Hugo Alvarez', N'Hubble 91', N'099100012', N'hugo.alvarez@stellarminds.test', N'halvarez', N'$2a$11$HzLHcC9VrVWU1vhsC7e9O.GDp1htGd/WDNRJyg253qVAdhb0DCX9u', 3);
SET IDENTITY_INSERT [Usuarios] OFF;

SET IDENTITY_INSERT [Equipos] ON;
INSERT INTO [Equipos] ([Id], [Marca], [Modelo], [CantidadDisponible], [TipoEquipo], [AperturaMm], [RelacionFocal], [DistanciaFocalMm], [PesoKg], [TipoMontura], [CargaUtilKg], [EsComputarizado], [TipoSensor], [Resolucion], [TamanoPixelMicras], [DiametroMm], [AnguloVisionGrados]) VALUES
(1, N'Celestron', N'NexStar 8SE', 0, N'Telescopio', 203.20, 10.00, 2032.00, 10.40, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, N'Sky-Watcher', N'Evostar 120', 0, N'Telescopio', 120.00, 8.30, 1000.00, 5.10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, N'Mead', N'LX90 8', 0, N'Telescopio', 203.00, 10.00, 2030.00, 9.50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, N'Orion', N'StarBlast 6', 1, N'Telescopio', 150.00, 5.00, 750.00, 6.00, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, N'Explore Scientific', N'AR102', 1, N'Telescopio', 102.00, 6.50, 663.00, 4.20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, N'William Optics', N'ZenithStar 73', 0, N'Telescopio', 73.00, 5.90, 430.00, 2.50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(7, N'Takahashi', N'FSQ-85', 1, N'Telescopio', 85.00, 5.30, 450.00, 4.00, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(8, N'Sky-Watcher', N'Dobson 200P', 2, N'Telescopio', 200.00, 6.00, 1200.00, 11.00, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(9, N'Bresser', N'Messier 152', 1, N'Telescopio', 152.00, 5.00, 760.00, 7.50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(10, N'Vixen', N'R200SS', 1, N'Telescopio', 200.00, 4.00, 800.00, 5.30, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(11, N'Sky-Watcher', N'EQ6-R Pro', 0, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 20.00, 1, NULL, NULL, NULL, NULL, NULL),
(12, N'Celestron', N'AVX', 0, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 13.50, 1, NULL, NULL, NULL, NULL, NULL),
(13, N'iOptron', N'CEM40', 0, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 18.00, 1, NULL, NULL, NULL, NULL, NULL),
(14, N'Sky-Watcher', N'AZ-GTi', 1, N'Montura', NULL, NULL, NULL, NULL, N'Azimutal', 5.00, 1, NULL, NULL, NULL, NULL, NULL),
(15, N'Orion', N'Atlas Pro', 1, N'Montura', NULL, NULL, NULL, NULL, N'Hibrida', 20.00, 1, NULL, NULL, NULL, NULL, NULL),
(16, N'Losmandy', N'GM811G', 0, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 22.00, 1, NULL, NULL, NULL, NULL, NULL),
(17, N'Mead', N'LX85', 1, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 15.00, 1, NULL, NULL, NULL, NULL, NULL),
(18, N'Bresser', N'EXOS-2', 1, N'Montura', NULL, NULL, NULL, NULL, N'Ecuatorial', 13.00, 1, NULL, NULL, NULL, NULL, NULL),
(19, N'Vixen', N'Porta II', 2, N'Montura', NULL, NULL, NULL, NULL, N'Azimutal', 9.00, 0, NULL, NULL, NULL, NULL, NULL),
(20, N'ZWO', N'AM5', 1, N'Montura', NULL, NULL, NULL, NULL, N'Hibrida', 13.00, 1, NULL, NULL, NULL, NULL, NULL),
(21, N'ZWO', N'ASI533MC Pro', 0, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'3008x3008', 3.76, NULL, NULL),
(22, N'ZWO', N'ASI224MC', 0, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'1304x976', 3.75, NULL, NULL),
(23, N'QHY', N'QHY268C', 0, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'6280x4210', 3.76, NULL, NULL),
(24, N'Canon', N'EOS Ra', 1, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'6720x4480', 5.36, NULL, NULL),
(25, N'Nikon', N'D5600 Astro', 1, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'6000x4000', 3.89, NULL, NULL),
(26, N'Atik', N'Infinity', 0, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CCD', N'1392x1040', 6.45, NULL, NULL),
(27, N'SVBONY', N'SV305 Pro', 1, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'1920x1080', 2.90, NULL, NULL),
(28, N'Player One', N'Mars-C II', 1, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'1936x1096', 2.90, NULL, NULL),
(29, N'Omegon', N'veTEC 571C', 1, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'6248x4176', 3.76, NULL, NULL),
(30, N'MallinCam', N'DS10c', 2, N'Camara', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'CMOS', N'3856x2764', 4.63, NULL, NULL),
(31, N'Baader', N'Hyperion 13mm', 0, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 13.00, 68.00),
(32, N'Tele Vue', N'Nagler 7mm', 0, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7.00, 82.00),
(33, N'Celestron', N'Luminos 15mm', 0, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 15.00, 82.00),
(34, N'Explore Scientific', N'24mm 68', 1, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 24.00, 68.00),
(35, N'Orion', N'Sirius Plossl 25mm', 1, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 25.00, 52.00),
(36, N'Vixen', N'SLV 10mm', 0, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10.00, 50.00),
(37, N'Mead', N'UWA 5.5mm', 1, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 5.50, 82.00),
(38, N'Sky-Watcher', N'Super 10mm', 1, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10.00, 52.00),
(39, N'Pentax', N'XW 20mm', 1, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 20.00, 70.00),
(40, N'APM', N'Ultra Flat 30mm', 2, N'Ocular', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 30.00, 70.00);
SET IDENTITY_INSERT [Equipos] OFF;

SET IDENTITY_INSERT [ObjetosCelestes] ON;
INSERT INTO [ObjetosCelestes] ([Id], [Nombre], [Tipo], [MagnitudAparente]) VALUES
(1, N'Luna', 5, -12.74),
(2, N'Júpiter', 1, -2.20),
(3, N'Saturno', 1, 0.46),
(4, N'Galaxia M42', 3, 4.00),
(5, N'Polaris', 4, 1.98),
(6, N'Marte', 1, -1.20),
(7, N'Venus', 1, -4.40),
(8, N'Galaxia de Andrómeda', 2, 3.44),
(9, N'Nebulosa de la Laguna', 3, 6.00),
(10, N'Sirio', 4, -1.46);
SET IDENTITY_INSERT [ObjetosCelestes] OFF;

SET IDENTITY_INSERT [Prestamos] ON;
INSERT INTO [Prestamos] ([Id], [FechaInicio], [FechaFin], [Estado], [SocioId], [TelescopioId], [MonturaId], [CamaraId], [OcularId]) VALUES
(1, '2026-06-01T00:00:00', '2026-06-20T00:00:00', 1, 3, 1, 11, 21, 31),
(2, '2026-06-05T00:00:00', '2026-06-15T00:00:00', 1, 5, 2, 12, NULL, 32),
(3, '2026-05-01T00:00:00', '2026-05-07T00:00:00', 1, 3, 3, 13, 23, NULL),
(4, '2026-05-10T00:00:00', '2026-05-14T00:00:00', 2, 3, 1, 11, NULL, 34),
(5, '2026-04-01T00:00:00', '2026-04-08T00:00:00', 2, 7, 4, 15, 24, NULL),
(6, '2026-03-12T00:00:00', '2026-03-18T00:00:00', 2, 5, 1, 11, 25, 35),
(7, '2026-04-20T00:00:00', '2026-04-30T00:00:00', 1, 8, 6, 16, 26, 36),
(8, '2026-02-01T00:00:00', '2026-02-06T00:00:00', 2, 9, 7, 17, NULL, 37),
(9, '2026-01-15T00:00:00', '2026-01-21T00:00:00', 2, 10, 8, 19, NULL, 38),
(10, '2026-06-01T00:00:00', '2026-06-05T00:00:00', 1, 3, 1, 11, 22, NULL),
(11, '2026-06-02T00:00:00', '2026-06-07T00:00:00', 2, 11, 9, 18, 27, NULL),
(12, '2026-06-10T00:00:00', '2026-06-25T00:00:00', 1, 6, 1, 20, NULL, 33),
(13, '2026-05-22T00:00:00', '2026-05-28T00:00:00', 2, 12, 10, 20, 28, 39),
(14, '2026-06-03T00:00:00', '2026-06-09T00:00:00', 2, 5, 5, 15, 29, 40);
SET IDENTITY_INSERT [Prestamos] OFF;

SET IDENTITY_INSERT [AuditoriasPrestamo] ON;
INSERT INTO [AuditoriasPrestamo] ([Id], [Fecha], [Accion], [PrestamoId], [CoordinadorId]) VALUES
(1, '2026-06-01T09:00:00', 1, 1, 2),
(2, '2026-06-05T10:00:00', 1, 2, 2),
(3, '2026-05-01T09:30:00', 1, 3, 4),
(4, '2026-05-10T08:45:00', 1, 4, 2),
(5, '2026-05-14T18:00:00', 2, 4, 2),
(6, '2026-04-01T11:00:00', 1, 5, 4),
(7, '2026-04-08T17:00:00', 2, 5, 4),
(8, '2026-03-12T10:15:00', 1, 6, 2),
(9, '2026-03-18T16:30:00', 2, 6, 2),
(10, '2026-04-20T12:00:00', 1, 7, 4),
(11, '2026-02-01T09:20:00', 1, 8, 2),
(12, '2026-02-06T15:45:00', 2, 8, 2),
(13, '2026-01-15T09:10:00', 1, 9, 4),
(14, '2026-01-21T14:30:00', 2, 9, 4),
(15, '2026-06-01T13:00:00', 1, 10, 2),
(16, '2026-06-02T09:40:00', 1, 11, 4),
(17, '2026-06-07T18:15:00', 2, 11, 4),
(18, '2026-06-10T08:00:00', 1, 12, 2),
(19, '2026-05-22T10:00:00', 1, 13, 4),
(20, '2026-05-28T16:00:00', 2, 13, 4),
(21, '2026-06-03T09:30:00', 1, 14, 2),
(22, '2026-06-09T17:30:00', 2, 14, 2);
SET IDENTITY_INSERT [AuditoriasPrestamo] OFF;

SET IDENTITY_INSERT [Observaciones] ON;
INSERT INTO [Observaciones] ([Id], [Fecha], [PrestamoId], [ObjetoCelesteId], [IndicadorIA], [DetalleEvaluacion]) VALUES
(1, '2026-06-02T00:00:00', 1, 1, 1, N''),
(2, '2026-06-03T00:00:00', 1, 2, 1, N''),
(3, '2026-06-04T00:00:00', 1, 4, 2, N'Cielo suburbano; recomendable usar filtro.'),
(4, '2026-06-06T00:00:00', 2, 3, 2, N'Ocular adecuado, aumento algo exigente.'),
(5, '2026-06-07T00:00:00', 2, 1, 1, N''),
(6, '2026-05-02T00:00:00', 3, 8, 3, N'Magnitud alta para la apertura disponible.'),
(7, '2026-05-04T00:00:00', 3, 4, 2, N'Equipo suficiente con exposición moderada.'),
(8, '2026-04-22T00:00:00', 7, 9, 2, N'Cámara sensible; conviene cielo oscuro.'),
(9, '2026-04-23T00:00:00', 7, 8, 3, N'Objeto extenso y tenue para la configuración.'),
(10, '2026-06-02T00:00:00', 10, 2, 1, N''),
(11, '2026-06-03T00:00:00', 10, 6, 1, N''),
(12, '2026-06-10T00:00:00', 12, 1, 1, N''),
(13, '2026-06-10T00:00:00', 12, 10, 2, N'Objeto brillante, ocular de campo medio.'),
(14, '2026-06-11T00:00:00', 12, 2, 1, N''),
(15, '2026-06-12T00:00:00', 12, 7, 2, N'Horizonte bajo; observar temprano.'),
(16, '2026-06-13T00:00:00', 1, 1, 1, N''),
(17, '2026-06-14T00:00:00', 1, 2, 1, N''),
(18, '2026-06-15T00:00:00', 1, 5, 2, N'Buena estrella guía, seeing variable.');
SET IDENTITY_INSERT [Observaciones] OFF;
