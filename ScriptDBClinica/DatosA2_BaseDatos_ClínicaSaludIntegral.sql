--==============================================================================
-- Sistema de Atención para Pacientes en Clínica Salud Integral S.A.C. 
--==============================================================================

--==============================================================================
--                           Crear Carpetas 
--==============================================================================
set nocount on 
go

xp_Create_subdir 'C:\Base'
go

xp_Create_subdir 'C:\Datos'
go

xp_Create_subdir 'C:\Base\Reporte'
go

--==============================================================================
--                                 Base de Datos
--                                 Crear BD
--==============================================================================

Create database BDClinica
on primary 
	(name = ClinicaDatos01, filename = 'C:\Base\ClinicaDatos01.mdf', size = 500MB, maxsize = 50GB, filegrowth = 512MB),
	(name = ClinicaDatos02, filename = 'C:\Datos\ClinicaDatos02.ndf', size = 500MB, maxsize = 50GB, filegrowth = 512MB),
filegroup Atenciones 
	(name = ClinicaAtenciones01, filename = 'C:\Base\ClinicaAtenciones01.ndf', size = 1000MB, maxsize = 100GB, filegrowth = 1024MB),
	(name = ClinicaAtenciones02, filename = 'C:\Datos\ClinicaAtenciones02.ndf', size = 1000MB, maxsize = 100GB, filegrowth = 1024MB),
filegroup Seguridad
	(name = ClinicaSeguridad01, filename = 'C:\Base\Reporte\ClinicaSeguridad01.ndf', size = 250MB, maxsize = 20GB, filegrowth = 256MB)
log on 
	(name = ClinicaLog01, filename = 'C:\Base\Reporte\ClinicaLog01.ldf', size = 1000MB, maxsize = 20GB, filegrowth = 512MB),
	(name = ClinicaLog02, filename = 'C:\Datos\ClinicaLog02.ldf', size = 1000MB, maxsize = 20GB, filegrowth = 512MB)
go

use BDClinica
go

--==============================================================================
--             Crear Esquemas Seguridad, Atenciones con consistencia 
--==============================================================================

if not exists
    (select name from sys.schemas where name = 'Seguridad')
    Begin 
        Execute ('Create schema Seguridad')
    End
go 

if not exists
    (select name from sys.schemas where name = 'Atenciones')
    Begin 
        Execute ('Create schema Atenciones')
    End
go 

--==============================================================================
--              Crear tabla Especialidades con consistencia 
--==============================================================================

If not exists (select * from sys.tables where name = 'Especialidades' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Especialidades
(
    EspecialidadesCodigo nchar(7),
    EspecialidadesNombre nvarchar(100) not null,
    EspecialidadesDescripcion nvarchar(250) constraint EspecialidadesDescripcionDF default '',
    EspecialidadesEstado nchar(1) constraint EspecialidadesEstadoDF default 'A',
    constraint EspecialidadesPK Primary key (EspecialidadesCodigo),
    constraint EspecialidadesNombreUQ unique (EspecialidadesNombre),
    constraint EspecialidadesEstadoCK check (EspecialidadesEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Consultorios con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Consultorios' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Consultorios
(
    ConsultoriosCodigo nchar(7),
    ConsultoriosNombre nvarchar(100)          not null,
    ConsultoriosNumero nchar(5)               not null,
    ConsultoriosUbicacion nvarchar(100)       not null,
    ConsultoriosPiso numeric(2,0)             constraint ConsultoriosPisoDF default 1,
    ConsultoriosDescripcion nvarchar(250)     constraint ConsultoriosDescripcionDF default '',
    ConsultoriosEstado nchar(1)               constraint ConsultoriosEstadoDF default 'A',
    constraint ConsultoriosPK                 Primary key (ConsultoriosCodigo),
    constraint ConsultoriosNombreUQ           Unique (ConsultoriosNombre),
    constraint ConsultoriosNumeroUQ           Unique (ConsultoriosNumero),
    constraint ConsultoriosPisoCK             Check (ConsultoriosPiso > 0),
    constraint ConsultoriosEstadoCK           Check (ConsultoriosEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Distribuidoras con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Distribuidoras' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Distribuidoras
(
    DistribuidorasCodigo nchar(7),
    DistribuidorasRUC nchar(11)               not null,
    DistribuidorasRazonSocial nvarchar(150)   not null,
    DistribuidorasTelefono nchar(9),
    DistribuidorasCorreo nvarchar(100),
    DistribuidorasDireccion nvarchar(200),
    DistribuidorasContacto nvarchar(100),
    DistribuidorasEstado nchar(1)             constraint DistribuidorasEstadoDF default 'A',
    constraint DistribuidorasPK               Primary key (DistribuidorasCodigo),
    constraint DistribuidorasRUCUQ            Unique (DistribuidorasRUC),
    constraint DistribuidorasRazonSocialUQ    Unique (DistribuidorasRazonSocial),
    constraint DistribuidorasCorreoUQ         Unique (DistribuidorasCorreo),
    constraint DistribuidorasEstadoCK         Check (DistribuidorasEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Empleados con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Empleados' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Empleados
(
    EmpleadosCodigo nchar(7),
    EmpleadosDNI nchar(8)                     not null,
    EmpleadosNombres nvarchar(100)            not null,
    EmpleadosApellidos nvarchar(100)          not null,
    EmpleadosCargo nvarchar(50)               not null,
    EmpleadosTelefono nchar(9),
    EmpleadosCorreo nvarchar(100),
    EmpleadosDireccion nvarchar(200),
    EmpleadosFechaIngreso date                not null,
    EmpleadosEstado nchar(1)                  constraint EmpleadosEstadoDF default 'A',
    constraint EmpleadosPK                    Primary key (EmpleadosCodigo),
    constraint EmpleadosDNIUQ                 Unique (EmpleadosDNI),
    constraint EmpleadosCorreoUQ              Unique (EmpleadosCorreo),
    constraint EmpleadosEstadoCK              Check (EmpleadosEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Pacientes con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Pacientes' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Pacientes
(
    PacientesCodigo nchar(7),
    PacientesDNI nchar(8)                     not null,
    PacientesNombres nvarchar(100)            not null,
    PacientesApellidos nvarchar(100)          not null,
    PacientesFechaNacimiento date             not null,
    PacientesSexo nchar(1)                    not null,
    PacientesTelefono nchar(9),
    PacientesCorreo nvarchar(100),
    PacientesDireccion nvarchar(200),
    PacientesCondiciones nvarchar(300)        constraint PacientesCondicionesDF default '',
    PacientesEstado nchar(1)                  constraint PacientesEstadoDF default 'A',
    constraint PacientesPK                    Primary key (PacientesCodigo),
    constraint PacientesDNIUQ                 Unique (PacientesDNI),
    constraint PacientesCorreoUQ              Unique (PacientesCorreo),
    constraint PacientesSexoCK                Check (PacientesSexo in ('M','F')), -- Masculino, Femenino 
    constraint PacientesEstadoCK              Check (PacientesEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla HistoriaClinica con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'HistoriaClinica' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.HistoriaClinica
(
    HistoriaClinicaCodigo nchar(7),
    PacientesCodigo nchar(7)                  not null,
    HistoriaClinicaFechaApertura date         not null,
    HistoriaClinicaGrupoSanguineo nvarchar(5),
    HistoriaClinicaAlergias nvarchar(250)     constraint HistoriaClinicaAlergiasDF default '',
    HistoriaClinicaAntecedentes nvarchar(500) constraint HistoriaClinicaAntecedentesDF default '',
    HistoriaClinicaObservaciones nvarchar(500) constraint HistoriaClinicaObservacionesDF default '',
    HistoriaClinicaEstado nchar(1)            constraint HistoriaClinicaEstadoDF default 'A',
    constraint HistoriaClinicaPK              Primary key (HistoriaClinicaCodigo),
    constraint HistoriaClinicaPacienteUQ      Unique (PacientesCodigo),
    constraint HistoriaClinicaEstadoCK        Check (HistoriaClinicaEstado in ('A','E')), -- Activo, Eliminado
    constraint HistoriaClinicaPacientesFK Foreign key (PacientesCodigo) references Atenciones.Pacientes(PacientesCodigo)
)
on Atenciones
End
Go 

--==============================================================================
--              Crear tabla Médicos con consistencia 
--==============================================================================

If not exists (select * from sys.tables where name = 'Medicos' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Medicos
(
    MedicosCodigo nchar(7),
    MedicosNombres nvarchar(100)              not null,
    MedicosApellidos nvarchar(100)            not null,
    MedicosCMP nchar(10)                      not null,
    MedicosTelefono nchar(9),
    MedicosCorreo nvarchar(100),
    EspecialidadesCodigo nchar(7)            not null,
    ConsultoriosCodigo nchar(7)              not null,
    MedicosEstado nchar(1)                    constraint MedicosEstadoDF default 'A',
    constraint MedicosPK                      Primary key (MedicosCodigo),
    constraint MedicosCMPUQ                   Unique (MedicosCMP),
    constraint MedicosCorreoUQ                Unique (MedicosCorreo),
    constraint MedicosEstadoCK                Check (MedicosEstado in ('A','E')), -- Activo, Eliminado
    constraint MedicosEspecialidadesFK Foreign key (EspecialidadesCodigo) references Atenciones.Especialidades(EspecialidadesCodigo),
    constraint MedicosConsultoriosFK Foreign key (ConsultoriosCodigo) references Atenciones.Consultorios(ConsultoriosCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Citas con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Citas' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Citas
(
    CitasCodigo nchar(7),
    PacientesCodigo nchar(7)                  not null,
    MedicosCodigo nchar(7)                    not null,
    ConsultoriosCodigo nchar(7)               not null,
    CitasFecha date                           not null,
    CitasHora time                            not null,
    CitasMotivo nvarchar(250)                 not null,
    CitasCondiciones nvarchar(300)            constraint CitasCondicionesDF default '',
    CitasEstado nchar(1)                      constraint CitasEstadoDF default 'A',
    constraint CitasPK                        Primary key (CitasCodigo),
    constraint CitasEstadoCK                  Check (CitasEstado in ('A','E')), -- Activo, Eliminado
    constraint CitasPacientesFK Foreign key (PacientesCodigo) references Atenciones.Pacientes(PacientesCodigo),
    constraint CitasMedicosFK Foreign key (MedicosCodigo) references Atenciones.Medicos(MedicosCodigo),
    constraint CitasConsultoriosFK Foreign key (ConsultoriosCodigo) references Atenciones.Consultorios(ConsultoriosCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Factura con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Factura' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Factura
(
    FacturaCodigo nchar(7),
    PacientesCodigo nchar(7)                  not null,
    EmpleadosCodigo nchar(7)                  not null,
    FacturaFecha date                         not null,
    FacturaSubtotal numeric(10,2)             constraint FacturaSubtotalDF default 0,
    FacturaIGV numeric(10,2)                  constraint FacturaIGVDF default 0,
    FacturaTotal numeric(10,2)                constraint FacturaTotalDF default 0,
    FacturaEstado nchar(1)                    constraint FacturaEstadoDF default 'A',
    constraint FacturaPK                      Primary key (FacturaCodigo),
    constraint FacturaSubtotalCK              Check (FacturaSubtotal >= 0),
    constraint FacturaIGVCK                   Check (FacturaIGV >= 0),
    constraint FacturaTotalCK                 Check (FacturaTotal >= 0),
    constraint FacturaEstadoCK                Check (FacturaEstado in ('A','E')), -- Activo, Eliminado
    constraint FacturaPacientesFK Foreign key (PacientesCodigo) references Atenciones.Pacientes(PacientesCodigo),
    constraint FacturaEmpleadosFK Foreign key (EmpleadosCodigo) references Atenciones.Empleados(EmpleadosCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla FacturaDetalle con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'FacturaDetalle' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.FacturaDetalle
(
    FacturaDetalleCodigo nchar(7),
    FacturaCodigo nchar(7)                    not null,
    FacturaDetalleConcepto nvarchar(150)      not null,
    FacturaDetalleCantidad numeric(5,0)       constraint FacturaDetalleCantidadDF default 1,
    FacturaDetallePrecio numeric(10,2)        constraint FacturaDetallePrecioDF default 0,
    FacturaDetalleImporte numeric(10,2)       constraint FacturaDetalleImporteDF default 0,
    FacturaDetalleEstado nchar(1)             constraint FacturaDetalleEstadoDF default 'A',
    constraint FacturaDetallePK               Primary key (FacturaDetalleCodigo),
    constraint FacturaDetalleCantidadCK       Check (FacturaDetalleCantidad > 0),
    constraint FacturaDetallePrecioCK         Check (FacturaDetallePrecio >= 0),
    constraint FacturaDetalleImporteCK        Check (FacturaDetalleImporte >= 0),
    constraint FacturaDetalleEstadoCK         Check (FacturaDetalleEstado in ('A','E')), -- Activo, Eliminado
    constraint FacturaDetalleFacturaFK Foreign key (FacturaCodigo) references Atenciones.Factura(FacturaCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Boleta con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Boleta' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Boleta
(
    BoletaCodigo nchar(7),
    PacientesCodigo nchar(7)                  not null,
    EmpleadosCodigo nchar(7)                  not null,
    BoletaFecha date                          not null,
    BoletaSubtotal numeric(10,2)              constraint BoletaSubtotalDF default 0,
    BoletaIGV numeric(10,2)                   constraint BoletaIGVDF default 0,
    BoletaTotal numeric(10,2)                 constraint BoletaTotalDF default 0,
    BoletaEstado nchar(1)                     constraint BoletaEstadoDF default 'A',
    constraint BoletaPK                       Primary key (BoletaCodigo),
    constraint BoletaSubtotalCK               Check (BoletaSubtotal >= 0),
    constraint BoletaIGVCK                    Check (BoletaIGV >= 0),
    constraint BoletaTotalCK                  Check (BoletaTotal >= 0),
    constraint BoletaEstadoCK                 Check (BoletaEstado in ('A','E')), -- Activo, Eliminado
    constraint BoletaPacientesFK Foreign key (PacientesCodigo) references Atenciones.Pacientes(PacientesCodigo),
    constraint BoletaEmpleadosFK Foreign key (EmpleadosCodigo) references Atenciones.Empleados(EmpleadosCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla BoletaDetalle con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'BoletaDetalle' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.BoletaDetalle
(
    BoletaDetalleCodigo nchar(7),
    BoletaCodigo nchar(7)                     not null,
    BoletaDetalleConcepto nvarchar(150)       not null,
    BoletaDetalleCantidad numeric(5,0)        constraint BoletaDetalleCantidadDF default 1,
    BoletaDetallePrecio numeric(10,2)         constraint BoletaDetallePrecioDF default 0,
    BoletaDetalleImporte numeric(10,2)        constraint BoletaDetalleImporteDF default 0,
    BoletaDetalleEstado nchar(1)              constraint BoletaDetalleEstadoDF default 'A',
    constraint BoletaDetallePK                Primary key (BoletaDetalleCodigo),
    constraint BoletaDetalleCantidadCK        Check (BoletaDetalleCantidad > 0),
    constraint BoletaDetallePrecioCK          Check (BoletaDetallePrecio >= 0),
    constraint BoletaDetalleImporteCK         Check (BoletaDetalleImporte >= 0),
    constraint BoletaDetalleEstadoCK          Check (BoletaDetalleEstado in ('A','E')), -- Activo, Eliminado
    constraint BoletaDetalleBoletaFK Foreign key (BoletaCodigo) references Atenciones.Boleta(BoletaCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla RecetaCategorias con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'RecetaCategorias' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.RecetaCategorias
(
    RecetaCategoriasCodigo nchar(7),
    RecetaCategoriasNombre nvarchar(100)      not null,
    RecetaCategoriasDescripcion nvarchar(250) constraint RecetaCategoriasDescripcionDF default '',
    RecetaCategoriasEstado nchar(1)           constraint RecetaCategoriasEstadoDF default 'A',
    constraint RecetaCategoriasPK             Primary key (RecetaCategoriasCodigo),
    constraint RecetaCategoriasNombreUQ       Unique (RecetaCategoriasNombre),
    constraint RecetaCategoriasEstadoCK       Check (RecetaCategoriasEstado in ('A','E')) -- Activo, Eliminado
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Receta con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Receta' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Receta
(
    RecetaCodigo nchar(7),
    HistoriaClinicaCodigo nchar(7)            not null,
    MedicosCodigo nchar(7)                    not null,
    RecetaCategoriasCodigo nchar(7)           not null,
    RecetaFecha date                          not null,
    RecetaDiagnostico nvarchar(300)           not null,
    RecetaIndicaciones nvarchar(500)          constraint RecetaIndicacionesDF default '',
    RecetaObservaciones nvarchar(500)         constraint RecetaObservacionesDF default '',
    RecetaEstado nchar(1)                     constraint RecetaEstadoDF default 'A',
    constraint RecetaPK                       Primary key (RecetaCodigo),
    constraint RecetaEstadoCK                 Check (RecetaEstado in ('A','E')), -- Activo, Eliminado
    constraint RecetaHistoriaClinicaFK Foreign key (HistoriaClinicaCodigo) references Atenciones.HistoriaClinica(HistoriaClinicaCodigo),
    constraint RecetaMedicosFK Foreign key (MedicosCodigo) references Atenciones.Medicos(MedicosCodigo),
    constraint RecetaCategoriasFK Foreign key (RecetaCategoriasCodigo) references Atenciones.RecetaCategorias(RecetaCategoriasCodigo)
)
on Atenciones

End
Go

--=====================================================================
--                Crear tabla RecetaLaboratorios con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'RecetaLaboratorios' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.RecetaLaboratorios
(
    RecetaLaboratoriosCodigo nchar(7),
    RecetaCodigo nchar(7)                     not null,
    RecetaLaboratoriosExamen nvarchar(150)    not null,
    RecetaLaboratoriosResultado nvarchar(300) constraint RecetaLaboratoriosResultadoDF default '',
    RecetaLaboratoriosFecha date,
    RecetaLaboratoriosObservaciones nvarchar(300) constraint RecetaLaboratoriosObservacionesDF default '',
    RecetaLaboratoriosEstado nchar(1)         constraint RecetaLaboratoriosEstadoDF default 'A',
    constraint RecetaLaboratoriosPK           Primary key (RecetaLaboratoriosCodigo),
    constraint RecetaLaboratoriosEstadoCK     Check (RecetaLaboratoriosEstado in ('A','E')), -- Activo, Eliminado
    constraint RecetaLaboratoriosRecetaFK Foreign key (RecetaCodigo) references Atenciones.Receta(RecetaCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Medicamentos con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Medicamentos' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Medicamentos
(
    MedicamentosCodigo nchar(7),
    DistribuidorasCodigo nchar(7)             not null,
    MedicamentosNombre nvarchar(100)          not null,
    MedicamentosPresentacion nvarchar(100)    not null,
    MedicamentosStock numeric(6,0)            constraint MedicamentosStockDF default 0,
    MedicamentosPrecio numeric(10,2)          constraint MedicamentosPrecioDF default 0,
    MedicamentosFechaVencimiento date         not null,
    MedicamentosDescripcion nvarchar(250)     constraint MedicamentosDescripcionDF default '',
    MedicamentosEstado nchar(1)               constraint MedicamentosEstadoDF default 'A',
    constraint MedicamentosPK                 Primary key (MedicamentosCodigo),
    constraint MedicamentosNombreUQ           Unique (MedicamentosNombre),
    constraint MedicamentosStockCK            Check (MedicamentosStock >= 0),
    constraint MedicamentosPrecioCK           Check (MedicamentosPrecio >= 0),
    constraint MedicamentosEstadoCK           Check (MedicamentosEstado in ('A','E')), -- Activo, Eliminado
    constraint MedicamentosDistribuidorasFK Foreign key (DistribuidorasCodigo) references Atenciones.Distribuidoras(DistribuidorasCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Farmacia con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Farmacia' and schema_id = schema_id('Atenciones'))
Begin
Create Table Atenciones.Farmacia
(
    FarmaciaCodigo nchar(7),
    RecetaCodigo nchar(7)                     not null,
    MedicamentosCodigo nchar(7)              not null,
    FarmaciaCantidad numeric(5,0)             constraint FarmaciaCantidadDF default 1,
    FarmaciaDosis nvarchar(100)               not null,
    FarmaciaFrecuencia nvarchar(100)          not null,
    FarmaciaDuracion nvarchar(100)            not null,
    FarmaciaObservaciones nvarchar(250)       constraint FarmaciaObservacionesDF default '',
    FarmaciaEstado nchar(1)                   constraint FarmaciaEstadoDF default 'A',
    constraint FarmaciaPK                     Primary key (FarmaciaCodigo),
    constraint FarmaciaCantidadCK             Check (FarmaciaCantidad > 0),
    constraint FarmaciaEstadoCK               Check (FarmaciaEstado in ('A','E')), -- Activo, Eliminado
    constraint FarmaciaRecetaFK Foreign key (RecetaCodigo) references Atenciones.Receta(RecetaCodigo),
    constraint FarmaciaMedicamentosFK Foreign key (MedicamentosCodigo) references Atenciones.Medicamentos(MedicamentosCodigo)
)
on Atenciones
End
Go

--=====================================================================
--                Crear tabla Usuarios con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'Usuarios' and schema_id = schema_id('Seguridad'))
Begin
Create Table Seguridad.Usuarios
(
    UsuariosCodigo nchar(7),
    UsuariosNombre nvarchar(50)              not null,
    UsuariosClave nvarchar(100)              not null,
    UsuariosRol nvarchar(30)                 not null,
    UsuariosUltimoAcceso datetime,
    UsuariosEstado nchar(1)                  constraint UsuariosEstadoDF default 'A',
    constraint UsuariosPK                    Primary key (UsuariosCodigo),
    constraint UsuariosNombreUQ              Unique (UsuariosNombre),
    constraint UsuariosEstadoCK              Check (UsuariosEstado in ('A','E')) -- Activo, Eliminado
)
on Seguridad
End
Go

--=====================================================================
--                Crear tabla UsuariosEmpleados con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'UsuariosEmpleados' and schema_id = schema_id('Seguridad'))
Begin
Create Table Seguridad.UsuariosEmpleados
(
    UsuariosEmpleadosCodigo nchar(7),
    UsuariosCodigo nchar(7)                  not null,
    EmpleadosCodigo nchar(7)                 not null,
    UsuariosEmpleadosEstado nchar(1)         constraint UsuariosEmpleadosEstadoDF default 'A',
    constraint UsuariosEmpleadosPK           Primary key (UsuariosEmpleadosCodigo),
    constraint UsuariosEmpleadosUsuariosUQ   Unique (UsuariosCodigo),
    constraint UsuariosEmpleadosEmpleadosUQ  Unique (EmpleadosCodigo),
    constraint UsuariosEmpleadosEstadoCK     Check (UsuariosEmpleadosEstado in ('A','E')), -- Activo, Eliminado
    constraint UsuariosEmpleadosUsuariosFK Foreign key (UsuariosCodigo) references Seguridad.Usuarios(UsuariosCodigo),
    constraint UsuariosEmpleadosEmpleadosFK Foreign key (EmpleadosCodigo) references Atenciones.Empleados(EmpleadosCodigo)
)
on Seguridad
End
Go

--=====================================================================
--                Crear tabla UsuariosMedicos con consistencia
--=====================================================================
If not exists (select * from sys.tables where name = 'UsuariosMedicos' and schema_id = schema_id('Seguridad'))
Begin
Create Table Seguridad.UsuariosMedicos
(
    UsuariosMedicosCodigo nchar(7),
    UsuariosCodigo nchar(7)                  not null,
    MedicosCodigo nchar(7)                   not null,
    UsuariosMedicosEstado nchar(1)           constraint UsuariosMedicosEstadoDF default 'A',
    constraint UsuariosMedicosPK             Primary key (UsuariosMedicosCodigo),
    constraint UsuariosMedicosUsuariosUQ     Unique (UsuariosCodigo),
    constraint UsuariosMedicosMedicosUQ      Unique (MedicosCodigo),
    constraint UsuariosMedicosEstadoCK       Check (UsuariosMedicosEstado in ('A','E')), -- Activo, Eliminado
    constraint UsuariosMedicosUsuariosFK Foreign key (UsuariosCodigo) references Seguridad.Usuarios(UsuariosCodigo),
    constraint UsuariosMedicosMedicosFK Foreign key (MedicosCodigo) references Atenciones.Medicos(MedicosCodigo)
)
on Seguridad
End
Go

set dateformat dmy
go

USE BDClinica
go

--=====================================================================
--                    Registros Especialidades
--=====================================================================
Insert into BDClinica.Atenciones.Especialidades
    ([EspecialidadesCodigo], [EspecialidadesNombre], [EspecialidadesDescripcion], [EspecialidadesEstado])
    values  
    ('ESP0001','Cardiología','Diagnóstico y tratamiento de enfermedades cardiovasculares','A'),
    ('ESP0002','Pediatría','Atención médica integral para niños y adolescentes','A'),
    ('ESP0003','Dermatología','Prevención y tratamiento de enfermedades de la piel','A'),
    ('ESP0004','Neurología','Diagnóstico y tratamiento de enfermedades del sistema nervioso','A'),
    ('ESP0005','Ginecología','Atención especializada en salud femenina','A'),
    ('ESP0006','Traumatología','Tratamiento de lesiones óseas y musculares','A'),
    ('ESP0007','Oftalmología','Diagnóstico y tratamiento de enfermedades visuales','A'),
    ('ESP0008','Otorrinolaringología','Tratamiento de enfermedades de oído, nariz y garganta','A'),
    ('ESP0009','Psiquiatría','Atención de trastornos de salud mental','A'),
    ('ESP0010','Medicina General','Atención médica primaria y preventiva','A')
go

--=====================================================================
--                    Registros Consultorios 
--=====================================================================
Insert into BDClinica.Atenciones.Consultorios
    ([ConsultoriosCodigo], [ConsultoriosNombre], [ConsultoriosNumero], [ConsultoriosUbicacion], [ConsultoriosPiso], [ConsultoriosDescripcion], [ConsultoriosEstado])
    values  
    ('CON0001','Consultorio Cardiología','001','Bloque A',1,'Atención especializada en enfermedades cardiovasculares','A'),
    ('CON0002','Consultorio Pediatría','002','Bloque A',1,'Atención médica integral para niños y adolescentes','A'),
    ('CON0003','Consultorio Dermatología','003','Bloque A',1,'Diagnóstico y tratamiento de enfermedades de la piel','A'),
    ('CON0004','Consultorio Neurología','004','Bloque A',1,'Diagnóstico y tratamiento del sistema nervioso','A'),
    ('CON0005','Consultorio Ginecología','005','Bloque B',2,'Atención especializada en salud femenina','A'),
    ('CON0006','Consultorio Traumatología','006','Bloque B',2,'Tratamiento de lesiones óseas y musculares','A'),
    ('CON0007','Consultorio Oftalmología','007','Bloque B',2,'Diagnóstico y tratamiento de enfermedades visuales','A'),
    ('CON0008','Consultorio Otorrinolaringología','008','Bloque B',2,'Tratamiento de enfermedades de oído, nariz y garganta','A'),
    ('CON0009','Consultorio Psiquiatría','009','Bloque C',3,'Atención de trastornos de salud mental','A'),
    ('CON0010','Consultorio Medicina General','010','Bloque C',3,'Atención médica primaria y preventiva','A')
go

--=====================================================================
--                    Registros Distribuidoras 
--=====================================================================
Insert into BDClinica.Atenciones.Distribuidoras
    ([DistribuidorasCodigo], [DistribuidorasRUC], [DistribuidorasRazonSocial], [DistribuidorasTelefono], [DistribuidorasCorreo], [DistribuidorasDireccion], 
    [DistribuidorasContacto], [DistribuidorasEstado])
    values  
    ('DIS0001','20145678901','Distribuidora Farma Perú S.A.C.','944125631','contacto1@farmaperu.com','Av. España 1250 - Trujillo','Carlos Ramírez','A'),
    ('DIS0002','20458796321','Medical Supply Norte S.A.C.','955874123','contacto2@medicalsupply.com','Av. Larco 845 - Trujillo','María Fernández','A'),
    ('DIS0003','20569874125','Pharma Life Perú S.A.C.','987456321','contacto3@pharmalife.com','Jr. Pizarro 458 - Trujillo','Luis Torres','A'),
    ('DIS0004','20635789412','Salud Integral Distribuciones S.A.C.','968741235','contacto4@saludintegral.com','Av. América Oeste 1452 - Trujillo','Patricia Rojas','A'),
    ('DIS0005','20489635741','BioMedic Perú S.A.C.','947852136','contacto5@biomedic.com','Av. Mansiche 784 - Trujillo','José Vargas','A'),
    ('DIS0006','20574123698','Distribuciones Médicas del Norte S.A.C.','965874321','contacto6@medicasnorte.com','Jr. Independencia 1145 - Trujillo','Ana Mendoza','A'),
    ('DIS0007','20125896374','Laboratorios Unidos S.A.C.','978452136','contacto7@labunidos.com','Av. Fátima 520 - Trujillo','Ricardo Castro','A'),
    ('DIS0008','20412369875','Farmacéutica Andina S.A.C.','956874123','contacto8@farmandina.com','Av. América Sur 654 - Trujillo','Carmen Díaz','A'),
    ('DIS0009','20547896321','MediExpress Perú S.A.C.','984123657','contacto9@mediexpress.com','Jr. Bolognesi 980 - Trujillo','Miguel Herrera','A'),
    ('DIS0010','20687412359','Distribuidora San Gabriel S.A.C.','974563218','contacto10@sangabriel.com','Av. Miraflores 1120 - Trujillo','Rosa Castillo','A'),
    ('DIS0011','20196325874','FarmaGlobal S.A.C.','942357861','contacto11@farmaglobal.com','Av. César Vallejo 930 - Trujillo','Jorge León','A'),
    ('DIS0012','20474125896','BioSalud Internacional S.A.C.','969852147','contacto12@biosalud.com','Jr. Orbegoso 410 - Trujillo','Elena Vega','A'),
    ('DIS0013','20596321478','Grupo Farmacéutico Perú S.A.C.','973258964','contacto13@grupofarmaceutico.com','Av. Metropolitana 760 - Trujillo','Fernando Silva','A'),
    ('DIS0014','20625874139','Distribuciones Vida Sana S.A.C.','951478236','contacto14@vidasana.com','Av. Juan Pablo II 1285 - Trujillo','Sandra Núñez','A'),
    ('DIS0015','20187452369','Medicamentos del Pacífico S.A.C.','986321457','contacto15@medpacifico.com','Jr. Gamarra 670 - Trujillo','Pedro Salazar','A')
go

--=====================================================================
--                    Registros Empleados
--=====================================================================
Insert into BDClinica.Atenciones.Empleados
    ([EmpleadosCodigo], [EmpleadosDNI], [EmpleadosNombres], [EmpleadosApellidos], [EmpleadosCargo], [EmpleadosTelefono], [EmpleadosCorreo], 
    [EmpleadosDireccion], [EmpleadosFechaIngreso], [EmpleadosEstado])
    values  
    ('EMP0001','74581236','Juan Carlos','Ramírez López','Administrador','987451236','juan.ramirez@clinicasi.com','Av. España 1250 - Trujillo','15/01/22','A'),
    ('EMP0002','78451236','María Elena','Fernández Díaz','Recepcionista','965874123','maria.fernandez@clinicasi.com','Av. Larco 845 - Trujillo','10/03/22','A'),
    ('EMP0003','74125896','Luis Alberto','Torres Ruiz','Cajero','978452136','luis.torres@clinicasi.com','Jr. Pizarro 458 - Trujillo','21/04/22','A'),
    ('EMP0004','73698521','Patricia Rosa','Rojas Vega','Secretaria','956874321','patricia.rojas@clinicasi.com','Av. América Oeste 1452 - Trujillo','05/06/22','A'),
    ('EMP0005','75896321','José Miguel','Vargas Castillo','Almacenero','984123657','jose.vargas@clinicasi.com','Av. Mansiche 784 - Trujillo','18/07/22','A'),
    ('EMP0006','76985214','Ana Lucía','Mendoza Silva','Recepcionista','951478236','ana.mendoza@clinicasi.com','Jr. Independencia 1145 - Trujillo','02/09/22','A'),
    ('EMP0007','71478523','Ricardo Javier','Castro León','Cajero','974563218','ricardo.castro@clinicasi.com','Av. Fátima 520 - Trujillo','12/11/22','A'),
    ('EMP0008','79632145','Carmen Rosa','Díaz Herrera','Secretaria','986321457','carmen.diaz@clinicasi.com','Av. América Sur 654 - Trujillo','09/01/23','A'),
    ('EMP0009','73146985','Miguel Ángel','Herrera Pérez','Administrador','944125631','miguel.herrera@clinicasi.com','Jr. Bolognesi 980 - Trujillo','25/02/23','A'),
    ('EMP0010','75236418','Rosa Elena','Castillo Núñez','Recepcionista','973258964','rosa.castillo@clinicasi.com','Av. Miraflores 1120 - Trujillo','14/04/23','A'),
    ('EMP0011','72589631','Jorge Luis','León Torres','Almacenero','942357861','jorge.leon@clinicasi.com','Av. César Vallejo 930 - Trujillo','06/05/23','A'),
    ('EMP0012','74852369','Elena Patricia','Vega Flores','Secretaria','969852147','elena.vega@clinicasi.com','Jr. Orbegoso 410 - Trujillo','19/06/23','A'),
    ('EMP0013','76321478','Fernando José','Silva Ramos','Administrador','955874321','fernando.silva@clinicasi.com','Av. Metropolitana 760 - Trujillo','11/08/23','A'),
    ('EMP0014','72658741','Sandra Milagros','Núñez Ortiz','Recepcionista','968741235','sandra.nunez@clinicasi.com','Av. Juan Pablo II 1285 - Trujillo','27/09/23','A'),
    ('EMP0015','71874523','Pedro Antonio','Salazar Medina','Cajero','947852136','pedro.salazar@clinicasi.com','Jr. Gamarra 670 - Trujillo','03/11/23','A'),
    ('EMP0016','73589624','Daniel Enrique','Paredes Ríos','Secretaria','978963214','daniel.paredes@clinicasi.com','Av. Los Incas 520 - Trujillo','08/01/24','A'),
    ('EMP0017','75412369','Claudia Beatriz','Flores García','Recepcionista','956321478','claudia.flores@clinicasi.com','Jr. Ayacucho 860 - Trujillo','15/02/24','A'),
    ('EMP0018','77214589','Víctor Manuel','Ramos Chávez','Almacenero','965214789','victor.ramos@clinicasi.com','Av. América Norte 430 - Trujillo','22/03/24','A'),
    ('EMP0019','78963214','Paola Andrea','Medina López','Administrador','984521367','paola.medina@clinicasi.com','Jr. Bolívar 740 - Trujillo','10/05/24','E'),
    ('EMP0020','74321698','Diego Sebastián','García Torres','Cajero','951236478','diego.garcia@clinicasi.com','Av. Nicolás de Piérola 950 - Trujillo','28/06/24','A')
go

--=====================================================================
--                    Registros Pacientes 
--=====================================================================
Insert into BDClinica.Atenciones.Pacientes
    ([PacientesCodigo], [PacientesDNI], [PacientesNombres], [PacientesApellidos], [PacientesFechaNacimiento], [PacientesSexo], [PacientesTelefono], 
    [PacientesCorreo], [PacientesDireccion], [PacientesCondiciones], [PacientesEstado])
    values  
    ('PAC0001','74258136','Luis Alberto','Ramírez Pérez','15/03/90','M','987456123','luis.ramirez@correo.com','Av. España 1250 - Trujillo','Hipertensión arterial','A'),
    ('PAC0002','76895412','María Elena','Torres Díaz','21/07/95','F','965874321','maria.torres@correo.com','Jr. Pizarro 458 - Trujillo','Ninguna','A'),
    ('PAC0003','71478596','Carlos Enrique','Vega López','08/12/88','M','956321478','carlos.vega@correo.com','Av. América Sur 654 - Trujillo','Diabetes tipo II','A'),
    ('PAC0004','73698524','Patricia Rosa','Fernández Ruiz','30/01/92','F','984521367','patricia.fernandez@correo.com','Av. Larco 845 - Trujillo','Asma leve','A'),
    ('PAC0005','75236984','José Miguel','Castillo León','19/09/85','M','951236478','jose.castillo@correo.com','Jr. Independencia 1145 - Trujillo','Ninguna','A'),
    ('PAC0006','78965412','Ana Lucía','Rojas Silva','12/06/97','F','978654123','ana.rojas@correo.com','Av. Fátima 520 - Trujillo','Alergia a la penicilina','A'),
    ('PAC0007','72145896','Ricardo Javier','Herrera Medina','04/11/91','M','944125631','ricardo.herrera@correo.com','Av. Mansiche 784 - Trujillo','Hipertensión arterial','A'),
    ('PAC0008','74589632','Carmen Rosa','Núñez Vargas','18/05/94','F','973258964','carmen.nunez@correo.com','Av. Juan Pablo II 1285 - Trujillo','Ninguna','A'),
    ('PAC0009','76985214','Miguel Ángel','Salazar Torres','25/02/89','M','986321457','miguel.salazar@correo.com','Jr. Gamarra 670 - Trujillo','Diabetes tipo II','A'),
    ('PAC0010','71874523','Sandra Milagros','Flores Ramos','14/10/96','F','947852136','sandra.flores@correo.com','Av. César Vallejo 930 - Trujillo','Ninguna','A'),
    ('PAC0011','73412589','Pedro Antonio','Castro Vega','07/08/87','M','969852147','pedro.castro@correo.com','Jr. Orbegoso 410 - Trujillo','Asma leve','A'),
    ('PAC0012','75698741','Elena Patricia','Mendoza Ortiz','22/04/93','F','955874321','elena.mendoza@correo.com','Av. Metropolitana 760 - Trujillo','Ninguna','A'),
    ('PAC0013','72365418','Fernando José','León García','03/01/90','M','968741235','fernando.leon@correo.com','Av. Miraflores 1120 - Trujillo','Hipertensión arterial','A'),
    ('PAC0014','74123698','Rosa Elena','Paredes Chávez','29/11/98','F','974563218','rosa.paredes@correo.com','Av. Los Incas 520 - Trujillo','Ninguna','A'),
    ('PAC0015','77589632','Daniel Enrique','Medina Flores','11/06/86','M','942357861','daniel.medina@correo.com','Jr. Ayacucho 860 - Trujillo','Diabetes tipo II','A'),
    ('PAC0016','71963258','Claudia Beatriz','Silva Herrera','05/09/91','F','956874123','claudia.silva@correo.com','Av. América Norte 430 - Trujillo','Alergia a los mariscos','A'),
    ('PAC0017','74632158','Víctor Manuel','García Torres','17/02/88','M','951478236','victor.garcia@correo.com','Jr. Bolívar 740 - Trujillo','Ninguna','A'),
    ('PAC0018','78412369','Paola Andrea','Ramos López','28/07/94','F','965214789','paola.ramos@correo.com','Av. Nicolás de Piérola 950 - Trujillo','Asma leve','A'),
    ('PAC0019','73125896','Diego Sebastián','Chávez Díaz','09/03/97','M','984123657','diego.chavez@correo.com','Av. América Oeste 1452 - Trujillo','Ninguna','A'),
    ('PAC0020','75874123','Lucía Fernanda','Ortiz Castillo','16/12/92','F','978452136','lucia.ortiz@correo.com','Jr. Bolognesi 980 - Trujillo','Hipertensión arterial','A'),
    ('PAC0021','72458963','Jorge Luis','Vargas León','01/05/89','M','944785236','jorge.vargas@correo.com','Av. Larco 920 - Trujillo','Ninguna','A'),
    ('PAC0022','76954128','Andrea Milagros','Ruiz Vega','13/08/95','F','986745123','andrea.ruiz@correo.com','Jr. Junín 320 - Trujillo','Alergia a la penicilina','A'),
    ('PAC0023','71236985','Hugo César','Morales Ramos','24/10/84','M','973654218','hugo.morales@correo.com','Av. Los Ángeles 450 - Trujillo','Diabetes tipo II','A'),
    ('PAC0024','74125874','Natalia Sofía','Pérez Medina','06/04/99','F','951369852','natalia.perez@correo.com','Jr. Grau 520 - Trujillo','Ninguna','A'),
    ('PAC0025','73569841','Kevin Alexander','Flores Ruiz','27/01/93','M','965478123','kevin.flores@correo.com','Av. Perú 840 - Trujillo','Asma leve','A'),
    ('PAC0026','75489632','Valeria Isabel','Torres Chávez','18/06/96','F','978123654','valeria.torres@correo.com','Jr. Puno 610 - Trujillo','Ninguna','A'),
    ('PAC0027','72631458','Marco Antonio','Silva Castro','10/09/87','M','984567321','marco.silva@correo.com','Av. Mansiche 910 - Trujillo','Hipertensión arterial','A'),
    ('PAC0028','74852136','Camila Alejandra','León Ortiz','02/02/98','F','956741238','camila.leon@correo.com','Jr. Ayacucho 1040 - Trujillo','Ninguna','A'),
    ('PAC0029','71984523','Renzo Gabriel','Rojas Vargas','21/11/90','M','942856317','renzo.rojas@correo.com','Av. América Sur 1080 - Trujillo','Diabetes tipo II','A'),
    ('PAC0030','76521498','Gabriela Lucía','Mendoza Pérez','12/07/94','F','969741258','gabriela.mendoza@correo.com','Jr. Independencia 780 - Trujillo','Alergia a los mariscos','A'),
    ('PAC0031','73852164','Sebastián Andrés','Castillo Vega','05/03/91','M','955632147','sebastian.castillo@correo.com','Av. España 1450 - Trujillo','Ninguna','A'),
    ('PAC0032','75149632','Mariana Lucero','Herrera Silva','19/08/95','F','987214563','mariana.herrera@correo.com','Jr. Junín 450 - Trujillo','Asma leve','A'),
    ('PAC0033','72415896','Eduardo Javier','Ramos León','11/12/88','M','965874213','eduardo.ramos@correo.com','Av. Larco 1020 - Trujillo','Hipertensión arterial','A'),
    ('PAC0034','74693258','Diana Carolina','Salazar Flores','26/06/97','F','978563214','diana.salazar@correo.com','Jr. Pizarro 670 - Trujillo','Ninguna','A'),
    ('PAC0035','71963284','Álvaro José','Torres Medina','14/01/86','M','951236874','alvaro.torres@correo.com','Av. América Norte 890 - Trujillo','Diabetes tipo II','A'),
    ('PAC0036','75821496','Melissa Andrea','Vargas Chávez','30/09/93','F','942578631','melissa.vargas@correo.com','Jr. Bolívar 580 - Trujillo','Alergia a la penicilina','A'),
    ('PAC0037','73146928','Cristian Manuel','Ortiz Rojas','22/04/90','M','984125763','cristian.ortiz@correo.com','Av. César Vallejo 1120 - Trujillo','Ninguna','A'),
    ('PAC0038','77521463','Verónica Patricia','Paredes Díaz','17/07/94','F','956874312','veronica.paredes@correo.com','Jr. Grau 840 - Trujillo','Asma leve','A'),
    ('PAC0039','74218596','Martín Alejandro','García Ruiz','08/10/89','M','973214568','martin.garcia@correo.com','Av. Fátima 920 - Trujillo','Hipertensión arterial','A'),
    ('PAC0040','76985231','Andrea Sofía','Morales Torres','24/02/98','F','986547213','andrea.morales@correo.com','Jr. Ayacucho 720 - Trujillo','Ninguna','A'),
    ('PAC0041','71452369','Felipe Enrique','Castro Herrera','09/05/87','M','968741253','felipe.castro@correo.com','Av. Los Incas 430 - Trujillo','Diabetes tipo II','A'),
    ('PAC0042','78321456','Luciana Beatriz','Silva Ramos','12/11/96','F','951478632','luciana.silva@correo.com','Jr. Independencia 950 - Trujillo','Ninguna','A'),
    ('PAC0043','72659841','Bruno Gabriel','Flores Ortiz','27/08/92','M','944125783','bruno.flores@correo.com','Av. América Oeste 680 - Trujillo','Alergia a los mariscos','A'),
    ('PAC0044','75412386','Daniela Milagros','León Pérez','16/03/95','F','978452631','daniela.leon@correo.com','Jr. Bolognesi 1030 - Trujillo','Ninguna','A'),
    ('PAC0045','73986521','Rodrigo Antonio','Medina Vargas','04/01/88','M','965874312','rodrigo.medina@correo.com','Av. Miraflores 740 - Trujillo','Hipertensión arterial','A'),
    ('PAC0046','76852149','Paula Fernanda','Chávez Castillo','21/09/97','F','984563127','paula.chavez@correo.com','Jr. Orbegoso 520 - Trujillo','Asma leve','A'),
    ('PAC0047','72145863','Iván Ricardo','Ruiz Flores','15/06/91','M','956321874','ivan.ruiz@correo.com','Av. Metropolitana 1180 - Trujillo','Ninguna','A'),
    ('PAC0048','74589613','Valentina Alejandra','Gómez León','28/12/99','F','973654281','valentina.gomez@correo.com','Jr. Gamarra 890 - Trujillo','Alergia a la penicilina','A'),
    ('PAC0049','71236958','Sergio Daniel','Pérez Mendoza','03/07/85','M','942856731','sergio.perez@correo.com','Av. Juan Pablo II 960 - Trujillo','Diabetes tipo II','A'),
    ('PAC0050','75632148','Nicole Estefanía','Ramírez Castro','18/04/94','F','969874125','nicole.ramirez@correo.com','Jr. Puno 740 - Trujillo','Ninguna','A')
go

--=====================================================================
--                    Registros Historia Clinica  
--=====================================================================
Insert into BDClinica.Atenciones.HistoriaClinica
    ([HistoriaClinicaCodigo], [PacientesCodigo], [HistoriaClinicaFechaApertura], [HistoriaClinicaGrupoSanguineo], [HistoriaClinicaAlergias], 
    [HistoriaClinicaAntecedentes], [HistoriaClinicaObservaciones], [HistoriaClinicaEstado])
    values  
    ('HCL0001','PAC0001','10/01/22','O+','','Hipertensión arterial controlada','Paciente estable con controles periódicos','A'),
    ('HCL0002','PAC0002','15/02/22','A+','','Sin antecedentes relevantes','Buen estado general','A'),
    ('HCL0003','PAC0003','20/03/22','B+','','Diabetes tipo II','Control de glucosa recomendado','A'),
    ('HCL0004','PAC0004','05/04/22','AB+','','Asma leve','Sin complicaciones recientes','A'),
    ('HCL0005','PAC0005','12/05/22','O-','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0006','PAC0006','18/06/22','A-','Penicilina','Alergia medicamentosa','Evitar administración de penicilina','A'),
    ('HCL0007','PAC0007','24/07/22','B-','','Hipertensión arterial','Requiere seguimiento cardiológico','A'),
    ('HCL0008','PAC0008','08/08/22','O+','','Sin antecedentes relevantes','Paciente estable','A'),
    ('HCL0009','PAC0009','19/09/22','A+','','Diabetes tipo II','Control nutricional recomendado','A'),
    ('HCL0010','PAC0010','03/10/22','AB-','','Sin antecedentes relevantes','Buen estado general','A'),
    ('HCL0011','PAC0011','17/11/22','O+','','Asma leve','Tratamiento inhalatorio ocasional','A'),
    ('HCL0012','PAC0012','06/12/22','A+','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0013','PAC0013','14/01/23','B+','','Hipertensión arterial','Presión arterial controlada','A'),
    ('HCL0014','PAC0014','25/02/23','O-','','Sin antecedentes relevantes','Sin observaciones','A'),
    ('HCL0015','PAC0015','09/03/23','A-','','Diabetes tipo II','Control semestral','A'),
    ('HCL0016','PAC0016','22/04/23','AB+','Mariscos','Antecedentes alérgicos','Evitar consumo de mariscos','A'),
    ('HCL0017','PAC0017','11/05/23','O+','','Sin antecedentes relevantes','Paciente en buen estado','A'),
    ('HCL0018','PAC0018','27/06/23','B+','','Asma leve','Sin crisis recientes','A'),
    ('HCL0019','PAC0019','13/07/23','A+','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0020','PAC0020','29/08/23','O+','','Hipertensión arterial','Seguimiento médico anual','A'),
    ('HCL0021','PAC0021','07/09/23','AB+','','Sin antecedentes relevantes','Sin observaciones','A'),
    ('HCL0022','PAC0022','18/10/23','A-','Penicilina','Alergia medicamentosa','Uso restringido de antibióticos','A'),
    ('HCL0023','PAC0023','05/11/23','B-','','Diabetes tipo II','Control de glucosa trimestral','A'),
    ('HCL0024','PAC0024','21/12/23','O+','','Sin antecedentes relevantes','Paciente estable','A'),
    ('HCL0025','PAC0025','16/01/24','A+','','Asma leve','Sin complicaciones','A'),
    ('HCL0026','PAC0026','28/01/24','AB-','','Sin antecedentes relevantes','Buen estado general','A'),
    ('HCL0027','PAC0027','09/02/24','O-','','Hipertensión arterial','Control cardiológico recomendado','A'),
    ('HCL0028','PAC0028','23/02/24','B+','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0029','PAC0029','10/03/24','A+','','Diabetes tipo II','Control nutricional','A'),
    ('HCL0030','PAC0030','25/03/24','O+','Mariscos','Antecedentes alérgicos','Evitar alimentos marinos','A'),
    ('HCL0031','PAC0031','06/04/24','A-','','Sin antecedentes relevantes','Paciente estable','A'),
    ('HCL0032','PAC0032','18/04/24','B+','','Hipertensión arterial','Control médico periódico','A'),
    ('HCL0033','PAC0033','30/04/24','O+','','Sin antecedentes relevantes','Buen estado general','A'),
    ('HCL0034','PAC0034','12/05/24','AB+','','Asma leve','Sin crisis recientes','A'),
    ('HCL0035','PAC0035','24/05/24','A+','','Diabetes tipo II','Control de glucosa','A'),
    ('HCL0036','PAC0036','05/06/24','O-','Penicilina','Alergia medicamentosa','Evitar antibióticos beta lactámicos','A'),
    ('HCL0037','PAC0037','17/06/24','B-','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0038','PAC0038','29/06/24','A+','','Hipertensión arterial','Seguimiento cardiológico','A'),
    ('HCL0039','PAC0039','10/07/24','O+','','Sin antecedentes relevantes','Estado estable','A'),
    ('HCL0040','PAC0040','22/07/24','AB-','','Asma leve','Tratamiento controlado','A'),
    ('HCL0041','PAC0041','03/08/24','B+','','Diabetes tipo II','Control nutricional','A'),
    ('HCL0042','PAC0042','15/08/24','A-','','Sin antecedentes relevantes','Paciente en buen estado','A'),
    ('HCL0043','PAC0043','27/08/24','O+','','Hipertensión arterial','Monitoreo continuo','A'),
    ('HCL0044','PAC0044','08/09/24','A+','','Sin antecedentes relevantes','Sin observaciones','A'),
    ('HCL0045','PAC0045','20/09/24','B-','Mariscos','Antecedentes alérgicos','Evitar alimentos marinos','A'),
    ('HCL0046','PAC0046','02/10/24','O-','','Sin antecedentes relevantes','Paciente saludable','A'),
    ('HCL0047','PAC0047','14/10/24','AB+','','Asma leve','Sin complicaciones','A'),
    ('HCL0048','PAC0048','26/10/24','A+','','Diabetes tipo II','Control periódico','A'),
    ('HCL0049','PAC0049','07/11/24','O+','','Hipertensión arterial','Seguimiento médico','A'),
    ('HCL0050','PAC0050','19/11/24','B+','','Sin antecedentes relevantes','Buen estado general','A')
go

--=====================================================================
--                    Registros Medicos
--=====================================================================
Insert into BDClinica.Atenciones.Medicos
    ([MedicosCodigo], [MedicosNombres], [MedicosApellidos], [MedicosCMP], [MedicosTelefono], [MedicosCorreo], [EspecialidadesCodigo], 
    [ConsultoriosCodigo], [MedicosEstado])
    values  
    ('MED0001','Juan Carlos','Ramírez Soto','CMP10001','987654321','jramirez@clinica.com','ESP0001','CON0001','A'),
    ('MED0002','María Fernanda','Gómez Paredes','CMP10002','987654322','mgomez@clinica.com','ESP0002','CON0002','A'),
    ('MED0003','Luis Alberto','Torres Huamán','CMP10003','987654323','ltorres@clinica.com','ESP0003','CON0003','A'),
    ('MED0004','Ana Lucía','Vargas Ríos','CMP10004','987654324','avargas@clinica.com','ESP0004','CON0004','A'),
    ('MED0005','José Miguel','Quispe León','CMP10005','987654325','jquispe@clinica.com','ESP0005','CON0005','A'),
    ('MED0006','Carmen Rosa','Flores Díaz','CMP10006','987654326','cflores@clinica.com','ESP0006','CON0006','A'),
    ('MED0007','Ricardo','Sánchez Montalvo','CMP10007','987654327','rsanchez@clinica.com','ESP0007','CON0007','A'),
    ('MED0008','Elena Patricia','Castillo Vega','CMP10008','987654328','ecastillo@clinica.com','ESP0008','CON0008','A'),
    ('MED0009','Fernando','López Navarro','CMP10009','987654329','flopez@clinica.com','ESP0009','CON0009','A'),
    ('MED0010','Karla','Reyes Mendoza','CMP10010','987654330','kreyes@clinica.com','ESP0010','CON0010','A'),
    ('MED0011','Sergio','Chávez Ortega','CMP10011','987654331','schavez@clinica.com','ESP0001','CON0002','A'),
    ('MED0012','Patricia','Morales Aguirre','CMP10012','987654332','pmorales@clinica.com','ESP0002','CON0003','A'),
    ('MED0013','Víctor','Herrera Ponce','CMP10013','987654333','vherrera@clinica.com','ESP0003','CON0004','A'),
    ('MED0014','Lucía','Rojas Medina','CMP10014','987654334','lrojas@clinica.com','ESP0004','CON0005','A'),
    ('MED0015','Andrés','Silva Campos','CMP10015','987654335','asilva@clinica.com','ESP0005','CON0006','A'),
    ('MED0016','Daniela','Ortega Paredes','CMP10016','987654336','dortega@clinica.com','ESP0006','CON0007','A'),
    ('MED0017','Héctor','Navarro Cruz','CMP10017','987654337','hnavarro@clinica.com','ESP0007','CON0008','A'),
    ('MED0018','Milagros','Ramos Vega','CMP10018','987654338','mramos@clinica.com','ESP0008','CON0009','A'),
    ('MED0019','Jorge','Espinoza Ruiz','CMP10019','987654339','jespinoza@clinica.com','ESP0009','CON0010','A'),
    ('MED0020','Valeria','Campos Flores','CMP10020','987654340','vcampos@clinica.com','ESP0010','CON0001','A')
go

--=====================================================================
--                    Registros Citas 
--=====================================================================
Insert into BDClinica.Atenciones.Citas
    ([CitasCodigo], [PacientesCodigo], [MedicosCodigo], [ConsultoriosCodigo], [CitasFecha], [CitasHora], [CitasMotivo], [CitasCondiciones], [CitasEstado])
    values  
    ('CIT0001','PAC0001','MED0001','CON0001','10/01/24','08:00','Control general','', 'A'),
    ('CIT0002','PAC0002','MED0002','CON0002','10/01/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0003','PAC0003','MED0003','CON0003','10/01/24','09:00','Chequeo diabetes','', 'A'),
    ('CIT0004','PAC0004','MED0004','CON0004','10/01/24','09:30','Dificultad respiratoria','', 'A'),
    ('CIT0005','PAC0005','MED0005','CON0005','10/01/24','10:00','Control pediátrico','', 'A'),
    ('CIT0006','PAC0006','MED0006','CON0006','11/01/24','08:00','Alergia medicamento','', 'A'),
    ('CIT0007','PAC0007','MED0007','CON0007','11/01/24','08:30','Hipertensión','', 'A'),
    ('CIT0008','PAC0008','MED0008','CON0008','11/01/24','09:00','Dolor de cabeza','', 'A'),
    ('CIT0009','PAC0009','MED0009','CON0009','11/01/24','09:30','Control glucosa','', 'A'),
    ('CIT0010','PAC0010','MED0010','CON0010','11/01/24','10:00','Revisión general','', 'A'),
    ('CIT0011','PAC0011','MED0011','CON0001','12/01/24','08:00','Asma control','', 'A'),
    ('CIT0012','PAC0012','MED0012','CON0002','12/01/24','08:30','Dolor espalda','', 'A'),
    ('CIT0013','PAC0013','MED0013','CON0003','12/01/24','09:00','Chequeo cardiaco','', 'A'),
    ('CIT0014','PAC0014','MED0014','CON0004','12/01/24','09:30','Control rutina','', 'A'),
    ('CIT0015','PAC0015','MED0015','CON0005','12/01/24','10:00','Diabetes control','', 'A'),
    ('CIT0016','PAC0016','MED0016','CON0006','13/01/24','08:00','Alergia mariscos','', 'A'),
    ('CIT0017','PAC0017','MED0017','CON0007','13/01/24','08:30','Consulta general','', 'A'),
    ('CIT0018','PAC0018','MED0018','CON0008','13/01/24','09:00','Dolor muscular','', 'A'),
    ('CIT0019','PAC0019','MED0019','CON0009','13/01/24','09:30','Chequeo anual','', 'A'),
    ('CIT0020','PAC0020','MED0020','CON0010','13/01/24','10:00','Hipertensión control','', 'A'),
    ('CIT0021','PAC0021','MED0001','CON0001','14/01/24','08:00','Control general','', 'A'),
    ('CIT0022','PAC0022','MED0002','CON0002','14/01/24','08:30','Dolor estomacal','', 'A'),
    ('CIT0023','PAC0023','MED0003','CON0003','14/01/24','09:00','Diabetes revisión','', 'A'),
    ('CIT0024','PAC0024','MED0004','CON0004','14/01/24','09:30','Asma leve','', 'A'),
    ('CIT0025','PAC0025','MED0005','CON0005','14/01/24','10:00','Control pediátrico','', 'A'),
    ('CIT0026','PAC0026','MED0006','CON0006','15/01/24','08:00','Alergia penicilina','', 'A'),
    ('CIT0027','PAC0027','MED0007','CON0007','15/01/24','08:30','Hipertensión control','', 'A'),
    ('CIT0028','PAC0028','MED0008','CON0008','15/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0029','PAC0029','MED0009','CON0009','15/01/24','09:30','Chequeo glucosa','', 'A'),
    ('CIT0030','PAC0030','MED0010','CON0010','15/01/24','10:00','Revisión general','', 'A'),
    ('CIT0031','PAC0031','MED0011','CON0001','16/01/24','08:00','Control hipertensión','', 'A'),
    ('CIT0032','PAC0032','MED0012','CON0002','16/01/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0033','PAC0033','MED0013','CON0003','16/01/24','09:00','Chequeo general','', 'A'),
    ('CIT0034','PAC0034','MED0014','CON0004','16/01/24','09:30','Asma control','', 'A'),
    ('CIT0035','PAC0035','MED0015','CON0005','16/01/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0036','PAC0036','MED0016','CON0006','17/01/24','08:00','Alergia control','', 'A'),
    ('CIT0037','PAC0037','MED0017','CON0007','17/01/24','08:30','Consulta médica','', 'A'),
    ('CIT0038','PAC0038','MED0018','CON0008','17/01/24','09:00','Dolor muscular','', 'A'),
    ('CIT0039','PAC0039','MED0019','CON0009','17/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0040','PAC0040','MED0020','CON0010','17/01/24','10:00','Control respiratorio','', 'A'),
    ('CIT0041','PAC0041','MED0001','CON0001','18/01/24','08:00','Diabetes control','', 'A'),
    ('CIT0042','PAC0042','MED0002','CON0002','18/01/24','08:30','Dolor espalda','', 'A'),
    ('CIT0043','PAC0043','MED0003','CON0003','18/01/24','09:00','Hipertensión control','', 'A'),
    ('CIT0044','PAC0044','MED0004','CON0004','18/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0045','PAC0045','MED0005','CON0005','18/01/24','10:00','Asma leve','', 'A'),
    ('CIT0046','PAC0046','MED0006','CON0006','19/01/24','08:00','Alergia revisión','', 'A'),
    ('CIT0047','PAC0047','MED0007','CON0007','19/01/24','08:30','Control médico','', 'A'),
    ('CIT0048','PAC0048','MED0008','CON0008','19/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0049','PAC0049','MED0009','CON0009','19/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0050','PAC0050','MED0010','CON0010','19/01/24','10:00','Hipertensión seguimiento','', 'A'),
    ('CIT0051','PAC0001','MED0011','CON0001','20/01/24','08:00','Control general','', 'A'),
    ('CIT0052','PAC0002','MED0012','CON0002','20/01/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0053','PAC0003','MED0013','CON0003','20/01/24','09:00','Diabetes control','', 'A'),
    ('CIT0054','PAC0004','MED0014','CON0004','20/01/24','09:30','Asma leve','', 'A'),
    ('CIT0055','PAC0005','MED0015','CON0005','20/01/24','10:00','Chequeo pediátrico','', 'A'),
    ('CIT0056','PAC0006','MED0016','CON0006','21/01/24','08:00','Alergia medicamento','', 'A'),
    ('CIT0057','PAC0007','MED0017','CON0007','21/01/24','08:30','Hipertensión control','', 'A'),
    ('CIT0058','PAC0008','MED0018','CON0008','21/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0059','PAC0009','MED0019','CON0009','21/01/24','09:30','Control glucosa','', 'A'),
    ('CIT0060','PAC0010','MED0020','CON0010','21/01/24','10:00','Revisión general','', 'A'),
    ('CIT0061','PAC0011','MED0001','CON0001','22/01/24','08:00','Asma control','', 'A'),
    ('CIT0062','PAC0012','MED0002','CON0002','22/01/24','08:30','Dolor espalda','', 'A'),
    ('CIT0063','PAC0013','MED0003','CON0003','22/01/24','09:00','Chequeo cardiaco','', 'A'),
    ('CIT0064','PAC0014','MED0004','CON0004','22/01/24','09:30','Control general','', 'A'),
    ('CIT0065','PAC0015','MED0005','CON0005','22/01/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0066','PAC0016','MED0006','CON0006','23/01/24','08:00','Alergia mariscos','', 'A'),
    ('CIT0067','PAC0017','MED0007','CON0007','23/01/24','08:30','Consulta general','', 'A'),
    ('CIT0068','PAC0018','MED0008','CON0008','23/01/24','09:00','Dolor muscular','', 'A'),
    ('CIT0069','PAC0019','MED0009','CON0009','23/01/24','09:30','Chequeo anual','', 'A'),
    ('CIT0070','PAC0020','MED0010','CON0010','23/01/24','10:00','Hipertensión control','', 'A'),
    ('CIT0071','PAC0021','MED0011','CON0001','24/01/24','08:00','Control general','', 'A'),
    ('CIT0072','PAC0022','MED0012','CON0002','24/01/24','08:30','Dolor estomacal','', 'A'),
    ('CIT0073','PAC0023','MED0013','CON0003','24/01/24','09:00','Diabetes revisión','', 'A'),
    ('CIT0074','PAC0024','MED0014','CON0004','24/01/24','09:30','Asma leve','', 'A'),
    ('CIT0075','PAC0025','MED0015','CON0005','24/01/24','10:00','Control pediátrico','', 'A'),
    ('CIT0076','PAC0026','MED0016','CON0006','25/01/24','08:00','Alergia penicilina','', 'A'),
    ('CIT0077','PAC0027','MED0017','CON0007','25/01/24','08:30','Hipertensión control','', 'A'),
    ('CIT0078','PAC0028','MED0018','CON0008','25/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0079','PAC0029','MED0019','CON0009','25/01/24','09:30','Chequeo glucosa','', 'A'),
    ('CIT0080','PAC0030','MED0020','CON0010','25/01/24','10:00','Revisión general','', 'A'),
    ('CIT0081','PAC0031','MED0001','CON0001','26/01/24','08:00','Control hipertensión','', 'A'),
    ('CIT0082','PAC0032','MED0002','CON0002','26/01/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0083','PAC0033','MED0003','CON0003','26/01/24','09:00','Chequeo general','', 'A'),
    ('CIT0084','PAC0034','MED0004','CON0004','26/01/24','09:30','Asma control','', 'A'),
    ('CIT0085','PAC0035','MED0005','CON0005','26/01/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0086','PAC0036','MED0006','CON0006','27/01/24','08:00','Alergia control','', 'A'),
    ('CIT0087','PAC0037','MED0007','CON0007','27/01/24','08:30','Consulta médica','', 'A'),
    ('CIT0088','PAC0038','MED0008','CON0008','27/01/24','09:00','Dolor muscular','', 'A'),
    ('CIT0089','PAC0039','MED0009','CON0009','27/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0090','PAC0040','MED0010','CON0010','27/01/24','10:00','Control respiratorio','', 'A'),
    ('CIT0091','PAC0041','MED0011','CON0001','28/01/24','08:00','Diabetes control','', 'A'),
    ('CIT0092','PAC0042','MED0012','CON0002','28/01/24','08:30','Dolor espalda','', 'A'),
    ('CIT0093','PAC0043','MED0013','CON0003','28/01/24','09:00','Hipertensión control','', 'A'),
    ('CIT0094','PAC0044','MED0014','CON0004','28/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0095','PAC0045','MED0015','CON0005','28/01/24','10:00','Asma leve','', 'A'),
    ('CIT0096','PAC0046','MED0016','CON0006','29/01/24','08:00','Alergia revisión','', 'A'),
    ('CIT0097','PAC0047','MED0017','CON0007','29/01/24','08:30','Control médico','', 'A'),
    ('CIT0098','PAC0048','MED0018','CON0008','29/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0099','PAC0049','MED0019','CON0009','29/01/24','09:30','Chequeo general','', 'A'),
    ('CIT0100','PAC0050','MED0020','CON0010','29/01/24','10:00','Hipertensión seguimiento','', 'A'),
    ('CIT0101','PAC0001','MED0001','CON0001','30/01/24','08:00','Control general','', 'A'),
    ('CIT0102','PAC0002','MED0002','CON0002','30/01/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0103','PAC0003','MED0003','CON0003','30/01/24','09:00','Diabetes control','', 'A'),
    ('CIT0104','PAC0004','MED0004','CON0004','30/01/24','09:30','Asma leve','', 'A'),
    ('CIT0105','PAC0005','MED0005','CON0005','30/01/24','10:00','Chequeo pediátrico','', 'A'),
    ('CIT0106','PAC0006','MED0006','CON0006','31/01/24','08:00','Alergia medicamento','', 'A'),
    ('CIT0107','PAC0007','MED0007','CON0007','31/01/24','08:30','Hipertensión control','', 'A'),
    ('CIT0108','PAC0008','MED0008','CON0008','31/01/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0109','PAC0009','MED0009','CON0009','31/01/24','09:30','Control glucosa','', 'A'),
    ('CIT0110','PAC0010','MED0010','CON0010','31/01/24','10:00','Revisión general','', 'A'),
    ('CIT0111','PAC0011','MED0011','CON0001','01/02/24','08:00','Asma control','', 'A'),
    ('CIT0112','PAC0012','MED0012','CON0002','01/02/24','08:30','Dolor espalda','', 'A'),
    ('CIT0113','PAC0013','MED0013','CON0003','01/02/24','09:00','Chequeo cardiaco','', 'A'),
    ('CIT0114','PAC0014','MED0014','CON0004','01/02/24','09:30','Control general','', 'A'),
    ('CIT0115','PAC0015','MED0015','CON0005','01/02/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0116','PAC0016','MED0016','CON0006','02/02/24','08:00','Alergia mariscos','', 'A'),
    ('CIT0117','PAC0017','MED0017','CON0007','02/02/24','08:30','Consulta general','', 'A'),
    ('CIT0118','PAC0018','MED0018','CON0008','02/02/24','09:00','Dolor muscular','', 'A'),
    ('CIT0119','PAC0019','MED0019','CON0009','02/02/24','09:30','Chequeo anual','', 'A'),
    ('CIT0120','PAC0020','MED0020','CON0010','02/02/24','10:00','Hipertensión control','', 'A'),
    ('CIT0121','PAC0021','MED0001','CON0001','03/02/24','08:00','Control general','', 'A'),
    ('CIT0122','PAC0022','MED0002','CON0002','03/02/24','08:30','Dolor estomacal','', 'A'),
    ('CIT0123','PAC0023','MED0003','CON0003','03/02/24','09:00','Diabetes revisión','', 'A'),
    ('CIT0124','PAC0024','MED0004','CON0004','03/02/24','09:30','Asma leve','', 'A'),
    ('CIT0125','PAC0025','MED0005','CON0005','03/02/24','10:00','Control pediátrico','', 'A'),
    ('CIT0126','PAC0026','MED0006','CON0006','04/02/24','08:00','Alergia penicilina','', 'A'),
    ('CIT0127','PAC0027','MED0007','CON0007','04/02/24','08:30','Hipertensión control','', 'A'),
    ('CIT0128','PAC0028','MED0008','CON0008','04/02/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0129','PAC0029','MED0009','CON0009','04/02/24','09:30','Chequeo glucosa','', 'A'),
    ('CIT0130','PAC0030','MED0010','CON0010','04/02/24','10:00','Revisión general','', 'A'),
    ('CIT0131','PAC0031','MED0011','CON0001','05/02/24','08:00','Control hipertensión','', 'A'),
    ('CIT0132','PAC0032','MED0012','CON0002','05/02/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0133','PAC0033','MED0013','CON0003','05/02/24','09:00','Chequeo general','', 'A'),
    ('CIT0134','PAC0034','MED0014','CON0004','05/02/24','09:30','Asma control','', 'A'),
    ('CIT0135','PAC0035','MED0015','CON0005','05/02/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0136','PAC0036','MED0016','CON0006','06/02/24','08:00','Alergia control','', 'A'),
    ('CIT0137','PAC0037','MED0017','CON0007','06/02/24','08:30','Consulta médica','', 'A'),
    ('CIT0138','PAC0038','MED0018','CON0008','06/02/24','09:00','Dolor muscular','', 'A'),
    ('CIT0139','PAC0039','MED0019','CON0009','06/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0140','PAC0040','MED0020','CON0010','06/02/24','10:00','Control respiratorio','', 'A'),
    ('CIT0141','PAC0041','MED0001','CON0001','07/02/24','08:00','Diabetes control','', 'A'),
    ('CIT0142','PAC0042','MED0002','CON0002','07/02/24','08:30','Dolor espalda','', 'A'),
    ('CIT0143','PAC0043','MED0003','CON0003','07/02/24','09:00','Hipertensión control','', 'A'),
    ('CIT0144','PAC0044','MED0004','CON0004','07/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0145','PAC0045','MED0005','CON0005','07/02/24','10:00','Asma leve','', 'A'),
    ('CIT0146','PAC0046','MED0006','CON0006','08/02/24','08:00','Alergia revisión','', 'A'),
    ('CIT0147','PAC0047','MED0007','CON0007','08/02/24','08:30','Control médico','', 'A'),
    ('CIT0148','PAC0048','MED0008','CON0008','08/02/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0149','PAC0049','MED0009','CON0009','08/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0150','PAC0050','MED0010','CON0010','08/02/24','10:00','Hipertensión seguimiento','', 'A'),
    ('CIT0151','PAC0001','MED0011','CON0001','09/02/24','08:00','Control general','', 'A'),
    ('CIT0152','PAC0002','MED0012','CON0002','09/02/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0153','PAC0003','MED0013','CON0003','09/02/24','09:00','Diabetes control','', 'A'),
    ('CIT0154','PAC0004','MED0014','CON0004','09/02/24','09:30','Asma leve','', 'A'),
    ('CIT0155','PAC0005','MED0015','CON0005','09/02/24','10:00','Chequeo pediátrico','', 'A'),
    ('CIT0156','PAC0006','MED0016','CON0006','10/02/24','08:00','Alergia medicamento','', 'A'),
    ('CIT0157','PAC0007','MED0017','CON0007','10/02/24','08:30','Hipertensión control','', 'A'),
    ('CIT0158','PAC0008','MED0018','CON0008','10/02/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0159','PAC0009','MED0019','CON0009','10/02/24','09:30','Control glucosa','', 'A'),
    ('CIT0160','PAC0010','MED0020','CON0010','10/02/24','10:00','Revisión general','', 'A'),
    ('CIT0161','PAC0011','MED0001','CON0001','11/02/24','08:00','Asma control','', 'A'),
    ('CIT0162','PAC0012','MED0002','CON0002','11/02/24','08:30','Dolor espalda','', 'A'),
    ('CIT0163','PAC0013','MED0003','CON0003','11/02/24','09:00','Chequeo cardiaco','', 'A'),
    ('CIT0164','PAC0014','MED0004','CON0004','11/02/24','09:30','Control general','', 'A'),
    ('CIT0165','PAC0015','MED0005','CON0005','11/02/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0166','PAC0016','MED0006','CON0006','12/02/24','08:00','Alergia mariscos','', 'A'),
    ('CIT0167','PAC0017','MED0007','CON0007','12/02/24','08:30','Consulta general','', 'A'),
    ('CIT0168','PAC0018','MED0008','CON0008','12/02/24','09:00','Dolor muscular','', 'A'),
    ('CIT0169','PAC0019','MED0009','CON0009','12/02/24','09:30','Chequeo anual','', 'A'),
    ('CIT0170','PAC0020','MED0010','CON0010','12/02/24','10:00','Hipertensión control','', 'A'),
    ('CIT0171','PAC0021','MED0011','CON0001','13/02/24','08:00','Control general','', 'A'),
    ('CIT0172','PAC0022','MED0012','CON0002','13/02/24','08:30','Dolor estomacal','', 'A'),
    ('CIT0173','PAC0023','MED0013','CON0003','13/02/24','09:00','Diabetes revisión','', 'A'),
    ('CIT0174','PAC0024','MED0014','CON0004','13/02/24','09:30','Asma leve','', 'A'),
    ('CIT0175','PAC0025','MED0015','CON0005','13/02/24','10:00','Control pediátrico','', 'A'),
    ('CIT0176','PAC0026','MED0016','CON0006','14/02/24','08:00','Alergia penicilina','', 'A'),
    ('CIT0177','PAC0027','MED0017','CON0007','14/02/24','08:30','Hipertensión control','', 'A'),
    ('CIT0178','PAC0028','MED0018','CON0008','14/02/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0179','PAC0029','MED0019','CON0009','14/02/24','09:30','Chequeo glucosa','', 'A'),
    ('CIT0180','PAC0030','MED0020','CON0010','14/02/24','10:00','Revisión general','', 'A'),
    ('CIT0181','PAC0031','MED0001','CON0001','15/02/24','08:00','Control hipertensión','', 'A'),
    ('CIT0182','PAC0032','MED0002','CON0002','15/02/24','08:30','Dolor abdominal','', 'A'),
    ('CIT0183','PAC0033','MED0003','CON0003','15/02/24','09:00','Chequeo general','', 'A'),
    ('CIT0184','PAC0034','MED0004','CON0004','15/02/24','09:30','Asma control','', 'A'),
    ('CIT0185','PAC0035','MED0005','CON0005','15/02/24','10:00','Diabetes seguimiento','', 'A'),
    ('CIT0186','PAC0036','MED0006','CON0006','16/02/24','08:00','Alergia control','', 'A'),
    ('CIT0187','PAC0037','MED0007','CON0007','16/02/24','08:30','Consulta médica','', 'A'),
    ('CIT0188','PAC0038','MED0008','CON0008','16/02/24','09:00','Dolor muscular','', 'A'),
    ('CIT0189','PAC0039','MED0009','CON0009','16/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0190','PAC0040','MED0010','CON0010','16/02/24','10:00','Control respiratorio','', 'A'),
    ('CIT0191','PAC0041','MED0011','CON0001','17/02/24','08:00','Diabetes control','', 'A'),
    ('CIT0192','PAC0042','MED0012','CON0002','17/02/24','08:30','Dolor espalda','', 'A'),
    ('CIT0193','PAC0043','MED0013','CON0003','17/02/24','09:00','Hipertensión control','', 'A'),
    ('CIT0194','PAC0044','MED0014','CON0004','17/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0195','PAC0045','MED0015','CON0005','17/02/24','10:00','Asma leve','', 'A'),
    ('CIT0196','PAC0046','MED0016','CON0006','18/02/24','08:00','Alergia revisión','', 'A'),
    ('CIT0197','PAC0047','MED0017','CON0007','18/02/24','08:30','Control médico','', 'A'),
    ('CIT0198','PAC0048','MED0018','CON0008','18/02/24','09:00','Dolor cabeza','', 'A'),
    ('CIT0199','PAC0049','MED0019','CON0009','18/02/24','09:30','Chequeo general','', 'A'),
    ('CIT0200','PAC0050','MED0020','CON0010','18/02/24','10:00','Hipertensión seguimiento','', 'A')
go

--=====================================================================
--                    Registros Factura
--=====================================================================
Insert into BDClinica.Atenciones.Factura
    ([FacturaCodigo], [PacientesCodigo], [EmpleadosCodigo], [FacturaFecha], [FacturaSubtotal], [FacturaIGV], [FacturaTotal], [FacturaEstado])
    values  
    ('FAC0001','PAC0001','EMP0001','01/01/24',100.00,18.00,118.00,'A'),
    ('FAC0002','PAC0002','EMP0002','01/01/24',120.00,21.60,141.60,'A'),
    ('FAC0003','PAC0003','EMP0003','02/01/24',80.00,14.40,94.40,'A'),
    ('FAC0004','PAC0004','EMP0004','02/01/24',150.00,27.00,177.00,'A'),
    ('FAC0005','PAC0005','EMP0005','03/01/24',200.00,36.00,236.00,'A'),
    ('FAC0006','PAC0006','EMP0006','03/01/24',90.00,16.20,106.20,'A'),
    ('FAC0007','PAC0007','EMP0007','04/01/24',110.00,19.80,129.80,'A'),
    ('FAC0008','PAC0008','EMP0008','04/01/24',130.00,23.40,153.40,'A'),
    ('FAC0009','PAC0009','EMP0009','05/01/24',140.00,25.20,165.20,'A'),
    ('FAC0010','PAC0010','EMP0010','05/01/24',160.00,28.80,188.80,'A'),
    ('FAC0011','PAC0011','EMP0001','06/01/24',170.00,30.60,200.60,'A'),
    ('FAC0012','PAC0012','EMP0002','06/01/24',180.00,32.40,212.40,'A'),
    ('FAC0013','PAC0013','EMP0003','07/01/24',190.00,34.20,224.20,'A'),
    ('FAC0014','PAC0014','EMP0004','07/01/24',200.00,36.00,236.00,'A'),
    ('FAC0015','PAC0015','EMP0005','08/01/24',210.00,37.80,247.80,'A'),
    ('FAC0016','PAC0016','EMP0006','08/01/24',220.00,39.60,259.60,'A'),
    ('FAC0017','PAC0017','EMP0007','09/01/24',230.00,41.40,271.40,'A'),
    ('FAC0018','PAC0018','EMP0008','09/01/24',240.00,43.20,283.20,'A'),
    ('FAC0019','PAC0019','EMP0009','10/01/24',250.00,45.00,295.00,'A'),
    ('FAC0020','PAC0020','EMP0010','10/01/24',260.00,46.80,306.80,'A'),
    ('FAC0021','PAC0021','EMP0001','11/01/24',270.00,48.60,318.60,'A'),
    ('FAC0022','PAC0022','EMP0002','11/01/24',280.00,50.40,330.40,'A'),
    ('FAC0023','PAC0023','EMP0003','12/01/24',290.00,52.20,342.20,'A'),
    ('FAC0024','PAC0024','EMP0004','12/01/24',300.00,54.00,354.00,'A'),
    ('FAC0025','PAC0025','EMP0005','13/01/24',310.00,55.80,365.80,'A'),
    ('FAC0026','PAC0026','EMP0006','13/01/24',320.00,57.60,377.60,'A'),
    ('FAC0027','PAC0027','EMP0007','14/01/24',330.00,59.40,389.40,'A'),
    ('FAC0028','PAC0028','EMP0008','14/01/24',340.00,61.20,401.20,'A'),
    ('FAC0029','PAC0029','EMP0009','15/01/24',350.00,63.00,413.00,'A'),
    ('FAC0030','PAC0030','EMP0010','15/01/24',360.00,64.80,424.80,'A'),
    ('FAC0031','PAC0031','EMP0001','16/01/24',370.00,66.60,436.60,'A'),
    ('FAC0032','PAC0032','EMP0002','16/01/24',380.00,68.40,448.40,'A'),
    ('FAC0033','PAC0033','EMP0003','17/01/24',390.00,70.20,460.20,'A'),
    ('FAC0034','PAC0034','EMP0004','17/01/24',400.00,72.00,472.00,'A'),
    ('FAC0035','PAC0035','EMP0005','18/01/24',410.00,73.80,483.80,'A'),
    ('FAC0036','PAC0036','EMP0006','18/01/24',420.00,75.60,495.60,'A'),
    ('FAC0037','PAC0037','EMP0007','19/01/24',430.00,77.40,507.40,'A'),
    ('FAC0038','PAC0038','EMP0008','19/01/24',440.00,79.20,519.20,'A'),
    ('FAC0039','PAC0039','EMP0009','20/01/24',450.00,81.00,531.00,'A'),
    ('FAC0040','PAC0040','EMP0010','20/01/24',460.00,82.80,542.80,'A'),
    ('FAC0041','PAC0041','EMP0001','21/01/24',470.00,84.60,554.60,'A'),
    ('FAC0042','PAC0042','EMP0002','21/01/24',480.00,86.40,566.40,'A'),
    ('FAC0043','PAC0043','EMP0003','22/01/24',490.00,88.20,578.20,'A'),
    ('FAC0044','PAC0044','EMP0004','22/01/24',500.00,90.00,590.00,'A'),
    ('FAC0045','PAC0045','EMP0005','23/01/24',510.00,91.80,601.80,'A'),
    ('FAC0046','PAC0046','EMP0006','23/01/24',520.00,93.60,613.60,'A'),
    ('FAC0047','PAC0047','EMP0007','24/01/24',530.00,95.40,625.40,'A'),
    ('FAC0048','PAC0048','EMP0008','24/01/24',540.00,97.20,637.20,'A'),
    ('FAC0049','PAC0049','EMP0009','25/01/24',550.00,99.00,649.00,'A'),
    ('FAC0050','PAC0050','EMP0010','25/01/24',560.00,100.80,660.80,'A'),
    ('FAC0051','PAC0001','EMP0001','26/01/24',570.00,102.60,672.60,'A'),
    ('FAC0052','PAC0002','EMP0002','26/01/24',580.00,104.40,684.40,'A'),
    ('FAC0053','PAC0003','EMP0003','27/01/24',590.00,106.20,696.20,'A'),
    ('FAC0054','PAC0004','EMP0004','27/01/24',600.00,108.00,708.00,'A'),
    ('FAC0055','PAC0005','EMP0005','28/01/24',610.00,109.80,719.80,'A'),
    ('FAC0056','PAC0006','EMP0006','28/01/24',620.00,111.60,731.60,'A'),
    ('FAC0057','PAC0007','EMP0007','29/01/24',630.00,113.40,743.40,'A'),
    ('FAC0058','PAC0008','EMP0008','29/01/24',640.00,115.20,755.20,'A'),
    ('FAC0059','PAC0009','EMP0009','30/01/24',650.00,117.00,767.00,'A'),
    ('FAC0060','PAC0010','EMP0010','30/01/24',660.00,118.80,778.80,'A'),
    ('FAC0061','PAC0011','EMP0001','31/01/24',670.00,120.60,790.60,'A'),
    ('FAC0062','PAC0012','EMP0002','31/01/24',680.00,122.40,802.40,'A'),
    ('FAC0063','PAC0013','EMP0003','01/02/24',690.00,124.20,814.20,'A'),
    ('FAC0064','PAC0014','EMP0004','01/02/24',700.00,126.00,826.00,'A'),
    ('FAC0065','PAC0015','EMP0005','02/02/24',710.00,127.80,837.80,'A'),
    ('FAC0066','PAC0016','EMP0006','02/02/24',720.00,129.60,849.60,'A'),
    ('FAC0067','PAC0017','EMP0007','03/02/24',730.00,131.40,861.40,'A'),
    ('FAC0068','PAC0018','EMP0008','03/02/24',740.00,133.20,873.20,'A'),
    ('FAC0069','PAC0019','EMP0009','04/02/24',750.00,135.00,885.00,'A'),
    ('FAC0070','PAC0020','EMP0010','04/02/24',760.00,136.80,896.80,'A'),
    ('FAC0071','PAC0021','EMP0001','05/02/24',770.00,138.60,908.60,'A'),
    ('FAC0072','PAC0022','EMP0002','05/02/24',780.00,140.40,920.40,'A'),
    ('FAC0073','PAC0023','EMP0003','06/02/24',790.00,142.20,932.20,'A'),
    ('FAC0074','PAC0024','EMP0004','06/02/24',800.00,144.00,944.00,'A'),
    ('FAC0075','PAC0025','EMP0005','07/02/24',810.00,145.80,955.80,'A'),
    ('FAC0076','PAC0026','EMP0006','07/02/24',820.00,147.60,967.60,'A'),
    ('FAC0077','PAC0027','EMP0007','08/02/24',830.00,149.40,979.40,'A'),
    ('FAC0078','PAC0028','EMP0008','08/02/24',840.00,151.20,991.20,'A'),
    ('FAC0079','PAC0029','EMP0009','09/02/24',850.00,153.00,1003.00,'A'),
    ('FAC0080','PAC0030','EMP0010','09/02/24',860.00,154.80,1014.80,'A'),
    ('FAC0081','PAC0031','EMP0001','10/02/24',870.00,156.60,1026.60,'A'),
    ('FAC0082','PAC0032','EMP0002','10/02/24',880.00,158.40,1038.40,'A'),
    ('FAC0083','PAC0033','EMP0003','11/02/24',890.00,160.20,1050.20,'A'),
    ('FAC0084','PAC0034','EMP0004','11/02/24',900.00,162.00,1062.00,'A'),
    ('FAC0085','PAC0035','EMP0005','12/02/24',910.00,163.80,1073.80,'A'),
    ('FAC0086','PAC0036','EMP0006','12/02/24',920.00,165.60,1085.60,'A'),
    ('FAC0087','PAC0037','EMP0007','13/02/24',930.00,167.40,1097.40,'A'),
    ('FAC0088','PAC0038','EMP0008','13/02/24',940.00,169.20,1109.20,'A'),
    ('FAC0089','PAC0039','EMP0009','14/02/24',950.00,171.00,1121.00,'A'),
    ('FAC0090','PAC0040','EMP0010','14/02/24',960.00,172.80,1132.80,'A'),
    ('FAC0091','PAC0041','EMP0001','15/02/24',970.00,174.60,1144.60,'A'),
    ('FAC0092','PAC0042','EMP0002','15/02/24',980.00,176.40,1156.40,'A'),
    ('FAC0093','PAC0043','EMP0003','16/02/24',990.00,178.20,1168.20,'A'),
    ('FAC0094','PAC0044','EMP0004','16/02/24',1000.00,180.00,1180.00,'A'),
    ('FAC0095','PAC0045','EMP0005','17/02/24',1010.00,181.80,1191.80,'A'),
    ('FAC0096','PAC0046','EMP0006','17/02/24',1020.00,183.60,1203.60,'A'),
    ('FAC0097','PAC0047','EMP0007','18/02/24',1030.00,185.40,1215.40,'A'),
    ('FAC0098','PAC0048','EMP0008','18/02/24',1040.00,187.20,1227.20,'A'),
    ('FAC0099','PAC0049','EMP0009','19/02/24',1050.00,189.00,1239.00,'A'),
    ('FAC0100','PAC0050','EMP0010','19/02/24',1060.00,190.80,1250.80,'A')
go

--=====================================================================
--                    Registros Factura Detalle 
--=====================================================================
Insert into BDClinica.Atenciones.FacturaDetalle
    ([FacturaDetalleCodigo], [FacturaCodigo], [FacturaDetalleConcepto], [FacturaDetalleCantidad], [FacturaDetallePrecio], [FacturaDetalleImporte], 
    [FacturaDetalleEstado])
    values  
    ('FAD0001','FAC0001','Consulta médica general',1,80.00,80.00,'A'),
    ('FAD0002','FAC0001','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0003','FAC0002','Consulta médica general',1,90.00,90.00,'A'),
    ('FAD0004','FAC0002','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0005','FAC0003','Consulta médica general',1,70.00,70.00,'A'),
    ('FAD0006','FAC0003','Medicamentos',1,10.00,10.00,'A'),
    ('FAD0007','FAC0004','Consulta médica general',1,120.00,120.00,'A'),
    ('FAD0008','FAC0004','Radiografía',1,30.00,30.00,'A'),
    ('FAD0009','FAC0005','Consulta médica general',1,150.00,150.00,'A'),
    ('FAD0010','FAC0005','Examen laboratorio',1,50.00,50.00,'A'),
    ('FAD0011','FAC0006','Consulta médica general',1,60.00,60.00,'A'),
    ('FAD0012','FAC0006','Medicamentos',3,10.00,30.00,'A'),
    ('FAD0013','FAC0007','Consulta médica general',1,100.00,100.00,'A'),
    ('FAD0014','FAC0007','Control presión',1,10.00,10.00,'A'),
    ('FAD0015','FAC0008','Consulta médica general',1,110.00,110.00,'A'),
    ('FAD0016','FAC0008','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0017','FAC0009','Consulta médica general',1,120.00,120.00,'A'),
    ('FAD0018','FAC0009','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0019','FAC0010','Consulta médica general',1,130.00,130.00,'A'),
    ('FAD0020','FAC0010','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0021','FAC0011','Consulta médica general',1,140.00,140.00,'A'),
    ('FAD0022','FAC0011','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0023','FAC0012','Consulta médica general',1,150.00,150.00,'A'),
    ('FAD0024','FAC0012','Radiografía',1,30.00,30.00,'A'),
    ('FAD0025','FAC0013','Consulta médica general',1,160.00,160.00,'A'),
    ('FAD0026','FAC0013','Examen laboratorio',1,30.00,30.00,'A'),
    ('FAD0027','FAC0014','Consulta médica general',1,170.00,170.00,'A'),
    ('FAD0028','FAC0014','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0029','FAC0015','Consulta médica general',1,180.00,180.00,'A'),
    ('FAD0030','FAC0015','Control presión',1,20.00,20.00,'A'),
    ('FAD0031','FAC0016','Consulta médica general',1,190.00,190.00,'A'),
    ('FAD0032','FAC0016','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0033','FAC0017','Consulta médica general',1,200.00,200.00,'A'),
    ('FAD0034','FAC0017','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0035','FAC0018','Consulta médica general',1,210.00,210.00,'A'),
    ('FAD0036','FAC0018','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0037','FAC0019','Consulta médica general',1,220.00,220.00,'A'),
    ('FAD0038','FAC0019','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0039','FAC0020','Consulta médica general',1,230.00,230.00,'A'),
    ('FAD0040','FAC0020','Radiografía',1,30.00,30.00,'A'),
    ('FAD0041','FAC0021','Consulta médica general',1,240.00,240.00,'A'),
    ('FAD0042','FAC0021','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0043','FAC0022','Consulta médica general',1,250.00,250.00,'A'),
    ('FAD0044','FAC0022','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0045','FAC0023','Consulta médica general',1,260.00,260.00,'A'),
    ('FAD0046','FAC0023','Control presión',1,20.00,20.00,'A'),
    ('FAD0047','FAC0024','Consulta médica general',1,270.00,270.00,'A'),
    ('FAD0048','FAC0024','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0049','FAC0025','Consulta médica general',1,280.00,280.00,'A'),
    ('FAD0050','FAC0025','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0051','FAC0026','Consulta médica general',1,290.00,290.00,'A'),
    ('FAD0052','FAC0026','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0053','FAC0027','Consulta médica general',1,300.00,300.00,'A'),
    ('FAD0054','FAC0027','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0055','FAC0028','Consulta médica general',1,310.00,310.00,'A'),
    ('FAD0056','FAC0028','Radiografía',1,30.00,30.00,'A'),
    ('FAD0057','FAC0029','Consulta médica general',1,320.00,320.00,'A'),
    ('FAD0058','FAC0029','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0059','FAC0030','Consulta médica general',1,330.00,330.00,'A'),
    ('FAD0060','FAC0030','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0061','FAC0031','Consulta médica general',1,340.00,340.00,'A'),
    ('FAD0062','FAC0031','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0063','FAC0032','Consulta médica general',1,350.00,350.00,'A'),
    ('FAD0064','FAC0032','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0065','FAC0033','Consulta médica general',1,360.00,360.00,'A'),
    ('FAD0066','FAC0033','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0067','FAC0034','Consulta médica general',1,370.00,370.00,'A'),
    ('FAD0068','FAC0034','Radiografía',1,30.00,30.00,'A'),
    ('FAD0069','FAC0035','Consulta médica general',1,380.00,380.00,'A'),
    ('FAD0070','FAC0035','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0071','FAC0036','Consulta médica general',1,390.00,390.00,'A'),
    ('FAD0072','FAC0036','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0073','FAC0037','Consulta médica general',1,400.00,400.00,'A'),
    ('FAD0074','FAC0037','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0075','FAC0038','Consulta médica general',1,410.00,410.00,'A'),
    ('FAD0076','FAC0038','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0077','FAC0039','Consulta médica general',1,420.00,420.00,'A'),
    ('FAD0078','FAC0039','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0079','FAC0040','Consulta médica general',1,430.00,430.00,'A'),
    ('FAD0080','FAC0040','Radiografía',1,30.00,30.00,'A'),
    ('FAD0081','FAC0041','Consulta médica general',1,440.00,440.00,'A'),
    ('FAD0082','FAC0041','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0083','FAC0042','Consulta médica general',1,450.00,450.00,'A'),
    ('FAD0084','FAC0042','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0085','FAC0043','Consulta médica general',1,460.00,460.00,'A'),
    ('FAD0086','FAC0043','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0087','FAC0044','Consulta médica general',1,470.00,470.00,'A'),
    ('FAD0088','FAC0044','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0089','FAC0045','Consulta médica general',1,480.00,480.00,'A'),
    ('FAD0090','FAC0045','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0091','FAC0046','Consulta médica general',1,490.00,490.00,'A'),
    ('FAD0092','FAC0046','Radiografía',1,30.00,30.00,'A'),
    ('FAD0093','FAC0047','Consulta médica general',1,500.00,500.00,'A'),
    ('FAD0094','FAC0047','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0095','FAC0048','Consulta médica general',1,510.00,510.00,'A'),
    ('FAD0096','FAC0048','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0097','FAC0049','Consulta médica general',1,520.00,520.00,'A'),
    ('FAD0098','FAC0049','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0099','FAC0050','Consulta médica general',1,530.00,530.00,'A'),
    ('FAD0100','FAC0050','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0101','FAC0051','Consulta médica general',1,540.00,540.00,'A'),
    ('FAD0102','FAC0051','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0103','FAC0052','Consulta médica general',1,550.00,550.00,'A'),
    ('FAD0104','FAC0052','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0105','FAC0053','Consulta médica general',1,560.00,560.00,'A'),
    ('FAD0106','FAC0053','Radiografía',1,30.00,30.00,'A'),
    ('FAD0107','FAC0054','Consulta médica general',1,570.00,570.00,'A'),
    ('FAD0108','FAC0054','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0109','FAC0055','Consulta médica general',1,580.00,580.00,'A'),
    ('FAD0110','FAC0055','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0111','FAC0056','Consulta médica general',1,590.00,590.00,'A'),
    ('FAD0112','FAC0056','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0113','FAC0057','Consulta médica general',1,600.00,600.00,'A'),
    ('FAD0114','FAC0057','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0115','FAC0058','Consulta médica general',1,610.00,610.00,'A'),
    ('FAD0116','FAC0058','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0117','FAC0059','Consulta médica general',1,620.00,620.00,'A'),
    ('FAD0118','FAC0059','Radiografía',1,30.00,30.00,'A'),
    ('FAD0119','FAC0060','Consulta médica general',1,630.00,630.00,'A'),
    ('FAD0120','FAC0060','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0121','FAC0061','Consulta médica general',1,640.00,640.00,'A'),
    ('FAD0122','FAC0061','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0123','FAC0062','Consulta médica general',1,650.00,650.00,'A'),
    ('FAD0124','FAC0062','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0125','FAC0063','Consulta médica general',1,660.00,660.00,'A'),
    ('FAD0126','FAC0063','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0127','FAC0064','Consulta médica general',1,670.00,670.00,'A'),
    ('FAD0128','FAC0064','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0129','FAC0065','Consulta médica general',1,680.00,680.00,'A'),
    ('FAD0130','FAC0065','Radiografía',1,30.00,30.00,'A'),
    ('FAD0131','FAC0066','Consulta médica general',1,690.00,690.00,'A'),
    ('FAD0132','FAC0066','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0133','FAC0067','Consulta médica general',1,700.00,700.00,'A'),
    ('FAD0134','FAC0067','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0135','FAC0068','Consulta médica general',1,710.00,710.00,'A'),
    ('FAD0136','FAC0068','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0137','FAC0069','Consulta médica general',1,720.00,720.00,'A'),
    ('FAD0138','FAC0069','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0139','FAC0070','Consulta médica general',1,730.00,730.00,'A'),
    ('FAD0140','FAC0070','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0141','FAC0071','Consulta médica general',1,740.00,740.00,'A'),
    ('FAD0142','FAC0071','Radiografía',1,30.00,30.00,'A'),
    ('FAD0143','FAC0072','Consulta médica general',1,750.00,750.00,'A'),
    ('FAD0144','FAC0072','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0145','FAC0073','Consulta médica general',1,760.00,760.00,'A'),
    ('FAD0146','FAC0073','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0147','FAC0074','Consulta médica general',1,770.00,770.00,'A'),
    ('FAD0148','FAC0074','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0149','FAC0075','Consulta médica general',1,780.00,780.00,'A'),
    ('FAD0150','FAC0075','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0151','FAC0076','Consulta médica general',1,790.00,790.00,'A'),
    ('FAD0152','FAC0076','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0153','FAC0077','Consulta médica general',1,800.00,800.00,'A'),
    ('FAD0154','FAC0077','Radiografía',1,30.00,30.00,'A'),
    ('FAD0155','FAC0078','Consulta médica general',1,810.00,810.00,'A'),
    ('FAD0156','FAC0078','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0157','FAC0079','Consulta médica general',1,820.00,820.00,'A'),
    ('FAD0158','FAC0079','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0159','FAC0080','Consulta médica general',1,830.00,830.00,'A'),
    ('FAD0160','FAC0080','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0161','FAC0081','Consulta médica general',1,840.00,840.00,'A'),
    ('FAD0162','FAC0081','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0163','FAC0082','Consulta médica general',1,850.00,850.00,'A'),
    ('FAD0164','FAC0082','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0165','FAC0083','Consulta médica general',1,860.00,860.00,'A'),
    ('FAD0166','FAC0083','Radiografía',1,30.00,30.00,'A'),
    ('FAD0167','FAC0084','Consulta médica general',1,870.00,870.00,'A'),
    ('FAD0168','FAC0084','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0169','FAC0085','Consulta médica general',1,880.00,880.00,'A'),
    ('FAD0170','FAC0085','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0171','FAC0086','Consulta médica general',1,890.00,890.00,'A'),
    ('FAD0172','FAC0086','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0173','FAC0087','Consulta médica general',1,900.00,900.00,'A'),
    ('FAD0174','FAC0087','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0175','FAC0088','Consulta médica general',1,910.00,910.00,'A'),
    ('FAD0176','FAC0088','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0177','FAC0089','Consulta médica general',1,920.00,920.00,'A'),
    ('FAD0178','FAC0089','Radiografía',1,30.00,30.00,'A'),
    ('FAD0179','FAC0090','Consulta médica general',1,930.00,930.00,'A'),
    ('FAD0180','FAC0090','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0181','FAC0091','Consulta médica general',1,940.00,940.00,'A'),
    ('FAD0182','FAC0091','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0183','FAC0092','Consulta médica general',1,950.00,950.00,'A'),
    ('FAD0184','FAC0092','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0185','FAC0093','Consulta médica general',1,960.00,960.00,'A'),
    ('FAD0186','FAC0093','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0187','FAC0094','Consulta médica general',1,970.00,970.00,'A'),
    ('FAD0188','FAC0094','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0189','FAC0095','Consulta médica general',1,980.00,980.00,'A'),
    ('FAD0190','FAC0095','Radiografía',1,30.00,30.00,'A'),
    ('FAD0191','FAC0096','Consulta médica general',1,990.00,990.00,'A'),
    ('FAD0192','FAC0096','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0193','FAC0097','Consulta médica general',1,1000.00,1000.00,'A'),
    ('FAD0194','FAC0097','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0195','FAC0098','Consulta médica general',1,1010.00,1010.00,'A'),
    ('FAD0196','FAC0098','Electrocardiograma',1,20.00,20.00,'A'),
    ('FAD0197','FAC0099','Consulta médica general',1,1020.00,1020.00,'A'),
    ('FAD0198','FAC0099','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0199','FAC0100','Consulta médica general',1,1030.00,1030.00,'A'),
    ('FAD0200','FAC0100','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0201','FAC0001','Terapia física',1,40.00,40.00,'A'),
    ('FAD0202','FAC0002','Control médico',1,35.00,35.00,'A'),
    ('FAD0203','FAC0003','Consulta adicional',1,25.00,25.00,'A'),
    ('FAD0204','FAC0004','Medicamentos adicionales',2,10.00,20.00,'A'),
    ('FAD0205','FAC0005','Examen especializado',1,60.00,60.00,'A'),
    ('FAD0206','FAC0006','Consulta control',1,30.00,30.00,'A'),
    ('FAD0207','FAC0007','Terapia respiratoria',1,45.00,45.00,'A'),
    ('FAD0208','FAC0008','Control cardiaco',1,50.00,50.00,'A'),
    ('FAD0209','FAC0009','Laboratorio adicional',1,25.00,25.00,'A'),
    ('FAD0210','FAC0010','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0211','FAC0011','Medicamentos extra',2,12.00,24.00,'A'),
    ('FAD0212','FAC0012','Radiografía adicional',1,28.00,28.00,'A'),
    ('FAD0213','FAC0013','Consulta control',1,30.00,30.00,'A'),
    ('FAD0214','FAC0014','Examen general',1,40.00,40.00,'A'),
    ('FAD0215','FAC0015','Terapia física',1,55.00,55.00,'A'),
    ('FAD0216','FAC0016','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0217','FAC0017','Control médico',1,35.00,35.00,'A'),
    ('FAD0218','FAC0018','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0219','FAC0019','Consulta adicional',1,25.00,25.00,'A'),
    ('FAD0220','FAC0020','Seguimiento',1,30.00,30.00,'A'),
    ('FAD0221','FAC0021','Terapia física',1,45.00,45.00,'A'),
    ('FAD0222','FAC0022','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0223','FAC0023','Consulta control',1,35.00,35.00,'A'),
    ('FAD0224','FAC0024','Examen laboratorio',1,25.00,25.00,'A'),
    ('FAD0225','FAC0025','Radiografía',1,30.00,30.00,'A'),
    ('FAD0226','FAC0026','Control médico',1,40.00,40.00,'A'),
    ('FAD0227','FAC0027','Consulta adicional',1,20.00,20.00,'A'),
    ('FAD0228','FAC0028','Terapia respiratoria',1,50.00,50.00,'A'),
    ('FAD0229','FAC0029','Laboratorio',1,30.00,30.00,'A'),
    ('FAD0230','FAC0030','Seguimiento',1,35.00,35.00,'A'),
    ('FAD0231','FAC0031','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0232','FAC0032','Consulta general',1,40.00,40.00,'A'),
    ('FAD0233','FAC0033','Examen adicional',1,30.00,30.00,'A'),
    ('FAD0234','FAC0034','Radiografía',1,25.00,25.00,'A'),
    ('FAD0235','FAC0035','Control médico',1,45.00,45.00,'A'),
    ('FAD0236','FAC0036','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0237','FAC0037','Terapia física',1,50.00,50.00,'A'),
    ('FAD0238','FAC0038','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0239','FAC0039','Consulta control',1,35.00,35.00,'A'),
    ('FAD0240','FAC0040','Seguimiento',1,30.00,30.00,'A'),
    ('FAD0241','FAC0041','Control médico',1,40.00,40.00,'A'),
    ('FAD0242','FAC0042','Laboratorio',1,25.00,25.00,'A'),
    ('FAD0243','FAC0043','Consulta adicional',1,35.00,35.00,'A'),
    ('FAD0244','FAC0044','Terapia física',1,50.00,50.00,'A'),
    ('FAD0245','FAC0045','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0246','FAC0046','Radiografía',1,30.00,30.00,'A'),
    ('FAD0247','FAC0047','Control general',1,45.00,45.00,'A'),
    ('FAD0248','FAC0048','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0249','FAC0049','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0250','FAC0050','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0251','FAC0051','Terapia física',1,40.00,40.00,'A'),
    ('FAD0252','FAC0052','Control médico',1,35.00,35.00,'A'),
    ('FAD0253','FAC0053','Consulta adicional',1,25.00,25.00,'A'),
    ('FAD0254','FAC0054','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0255','FAC0055','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0256','FAC0056','Radiografía',1,30.00,30.00,'A'),
    ('FAD0257','FAC0057','Control general',1,40.00,40.00,'A'),
    ('FAD0258','FAC0058','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0259','FAC0059','Terapia respiratoria',1,50.00,50.00,'A'),
    ('FAD0260','FAC0060','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0261','FAC0061','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0262','FAC0062','Consulta control',1,35.00,35.00,'A'),
    ('FAD0263','FAC0063','Examen adicional',1,25.00,25.00,'A'),
    ('FAD0264','FAC0064','Radiografía',1,30.00,30.00,'A'),
    ('FAD0265','FAC0065','Control médico',1,40.00,40.00,'A'),
    ('FAD0266','FAC0066','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0267','FAC0067','Consulta general',1,45.00,45.00,'A'),
    ('FAD0268','FAC0068','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0269','FAC0069','Terapia física',1,50.00,50.00,'A'),
    ('FAD0270','FAC0070','Seguimiento',1,30.00,30.00,'A'),
    ('FAD0271','FAC0071','Control médico',1,40.00,40.00,'A'),
    ('FAD0272','FAC0072','Laboratorio',1,25.00,25.00,'A'),
    ('FAD0273','FAC0073','Consulta adicional',1,35.00,35.00,'A'),
    ('FAD0274','FAC0074','Radiografía',1,30.00,30.00,'A'),
    ('FAD0275','FAC0075','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0276','FAC0076','Terapia física',1,45.00,45.00,'A'),
    ('FAD0277','FAC0077','Control general',1,40.00,40.00,'A'),
    ('FAD0278','FAC0078','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0279','FAC0079','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0280','FAC0080','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0281','FAC0081','Control médico',1,40.00,40.00,'A'),
    ('FAD0282','FAC0082','Laboratorio',1,25.00,25.00,'A'),
    ('FAD0283','FAC0083','Consulta adicional',1,35.00,35.00,'A'),
    ('FAD0284','FAC0084','Radiografía',1,30.00,30.00,'A'),
    ('FAD0285','FAC0085','Terapia física',1,50.00,50.00,'A'),
    ('FAD0286','FAC0086','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0287','FAC0087','Control general',1,40.00,40.00,'A'),
    ('FAD0288','FAC0088','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0289','FAC0089','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0290','FAC0090','Medicamentos',2,10.00,20.00,'A'),
    ('FAD0291','FAC0091','Control médico',1,40.00,40.00,'A'),
    ('FAD0292','FAC0092','Laboratorio',1,25.00,25.00,'A'),
    ('FAD0293','FAC0093','Consulta adicional',1,35.00,35.00,'A'),
    ('FAD0294','FAC0094','Radiografía',1,30.00,30.00,'A'),
    ('FAD0295','FAC0095','Terapia física',1,50.00,50.00,'A'),
    ('FAD0296','FAC0096','Medicamentos',2,15.00,30.00,'A'),
    ('FAD0297','FAC0097','Control general',1,40.00,40.00,'A'),
    ('FAD0298','FAC0098','Laboratorio',1,20.00,20.00,'A'),
    ('FAD0299','FAC0099','Consulta seguimiento',1,35.00,35.00,'A'),
    ('FAD0300','FAC0100','Medicamentos',2,10.00,20.00,'A')
go

--=====================================================================
--                    Registros Boleta 
--=====================================================================
Insert into BDClinica.Atenciones.Boleta
    ([BoletaCodigo], [PacientesCodigo], [EmpleadosCodigo], [BoletaFecha], [BoletaSubtotal], [BoletaIGV], [BoletaTotal], [BoletaEstado])
    values  
    ('BOL0001','PAC0001','EMP0001','01/01/24',80.00,14.40,94.40,'A'),
    ('BOL0002','PAC0002','EMP0002','01/01/24',90.00,16.20,106.20,'A'),
    ('BOL0003','PAC0003','EMP0003','02/01/24',70.00,12.60,82.60,'A'),
    ('BOL0004','PAC0004','EMP0004','02/01/24',100.00,18.00,118.00,'A'),
    ('BOL0005','PAC0005','EMP0005','03/01/24',120.00,21.60,141.60,'A'),
    ('BOL0006','PAC0006','EMP0006','03/01/24',60.00,10.80,70.80,'A'),
    ('BOL0007','PAC0007','EMP0007','04/01/24',110.00,19.80,129.80,'A'),
    ('BOL0008','PAC0008','EMP0008','04/01/24',95.00,17.10,112.10,'A'),
    ('BOL0009','PAC0009','EMP0009','05/01/24',130.00,23.40,153.40,'A'),
    ('BOL0010','PAC0010','EMP0010','05/01/24',140.00,25.20,165.20,'A'),
    ('BOL0011','PAC0011','EMP0001','06/01/24',150.00,27.00,177.00,'A'),
    ('BOL0012','PAC0012','EMP0002','06/01/24',160.00,28.80,188.80,'A'),
    ('BOL0013','PAC0013','EMP0003','07/01/24',170.00,30.60,200.60,'A'),
    ('BOL0014','PAC0014','EMP0004','07/01/24',180.00,32.40,212.40,'A'),
    ('BOL0015','PAC0015','EMP0005','08/01/24',190.00,34.20,224.20,'A'),
    ('BOL0016','PAC0016','EMP0006','08/01/24',200.00,36.00,236.00,'A'),
    ('BOL0017','PAC0017','EMP0007','09/01/24',210.00,37.80,247.80,'A'),
    ('BOL0018','PAC0018','EMP0008','09/01/24',220.00,39.60,259.60,'A'),
    ('BOL0019','PAC0019','EMP0009','10/01/24',230.00,41.40,271.40,'A'),
    ('BOL0020','PAC0020','EMP0010','10/01/24',240.00,43.20,283.20,'A'),
    ('BOL0021','PAC0021','EMP0001','11/01/24',250.00,45.00,295.00,'A'),
    ('BOL0022','PAC0022','EMP0002','11/01/24',260.00,46.80,306.80,'A'),
    ('BOL0023','PAC0023','EMP0003','12/01/24',270.00,48.60,318.60,'A'),
    ('BOL0024','PAC0024','EMP0004','12/01/24',280.00,50.40,330.40,'A'),
    ('BOL0025','PAC0025','EMP0005','13/01/24',290.00,52.20,342.20,'A'),
    ('BOL0026','PAC0026','EMP0006','13/01/24',300.00,54.00,354.00,'A'),
    ('BOL0027','PAC0027','EMP0007','14/01/24',310.00,55.80,365.80,'A'),
    ('BOL0028','PAC0028','EMP0008','14/01/24',320.00,57.60,377.60,'A'),
    ('BOL0029','PAC0029','EMP0009','15/01/24',330.00,59.40,389.40,'A'),
    ('BOL0030','PAC0030','EMP0010','15/01/24',340.00,61.20,401.20,'A'),
    ('BOL0031','PAC0031','EMP0001','16/01/24',350.00,63.00,413.00,'A'),
    ('BOL0032','PAC0032','EMP0002','16/01/24',360.00,64.80,424.80,'A'),
    ('BOL0033','PAC0033','EMP0003','17/01/24',370.00,66.60,436.60,'A'),
    ('BOL0034','PAC0034','EMP0004','17/01/24',380.00,68.40,448.40,'A'),
    ('BOL0035','PAC0035','EMP0005','18/01/24',390.00,70.20,460.20,'A'),
    ('BOL0036','PAC0036','EMP0006','18/01/24',400.00,72.00,472.00,'A'),
    ('BOL0037','PAC0037','EMP0007','19/01/24',410.00,73.80,483.80,'A'),
    ('BOL0038','PAC0038','EMP0008','19/01/24',420.00,75.60,495.60,'A'),
    ('BOL0039','PAC0039','EMP0009','20/01/24',430.00,77.40,507.40,'A'),
    ('BOL0040','PAC0040','EMP0010','20/01/24',440.00,79.20,519.20,'A'),
    ('BOL0041','PAC0041','EMP0001','21/01/24',450.00,81.00,531.00,'A'),
    ('BOL0042','PAC0042','EMP0002','21/01/24',460.00,82.80,542.80,'A'),
    ('BOL0043','PAC0043','EMP0003','22/01/24',470.00,84.60,554.60,'A'),
    ('BOL0044','PAC0044','EMP0004','22/01/24',480.00,86.40,566.40,'A'),
    ('BOL0045','PAC0045','EMP0005','23/01/24',490.00,88.20,578.20,'A'),
    ('BOL0046','PAC0046','EMP0006','23/01/24',500.00,90.00,590.00,'A'),
    ('BOL0047','PAC0047','EMP0007','24/01/24',510.00,91.80,601.80,'A'),
    ('BOL0048','PAC0048','EMP0008','24/01/24',520.00,93.60,613.60,'A'),
    ('BOL0049','PAC0049','EMP0009','25/01/24',530.00,95.40,625.40,'A'),
    ('BOL0050','PAC0050','EMP0010','25/01/24',540.00,97.20,637.20,'A'),
    ('BOL0051','PAC0001','EMP0001','26/01/24',550.00,99.00,649.00,'A'),
    ('BOL0052','PAC0002','EMP0002','26/01/24',560.00,100.80,660.80,'A'),
    ('BOL0053','PAC0003','EMP0003','27/01/24',570.00,102.60,672.60,'A'),
    ('BOL0054','PAC0004','EMP0004','27/01/24',580.00,104.40,684.40,'A'),
    ('BOL0055','PAC0005','EMP0005','28/01/24',590.00,106.20,696.20,'A'),
    ('BOL0056','PAC0006','EMP0006','28/01/24',600.00,108.00,708.00,'A'),
    ('BOL0057','PAC0007','EMP0007','29/01/24',610.00,109.80,719.80,'A'),
    ('BOL0058','PAC0008','EMP0008','29/01/24',620.00,111.60,731.60,'A'),
    ('BOL0059','PAC0009','EMP0009','30/01/24',630.00,113.40,743.40,'A'),
    ('BOL0060','PAC0010','EMP0010','30/01/24',640.00,115.20,755.20,'A'),
    ('BOL0061','PAC0011','EMP0001','31/01/24',650.00,117.00,767.00,'A'),
    ('BOL0062','PAC0012','EMP0002','31/01/24',660.00,118.80,778.80,'A'),
    ('BOL0063','PAC0013','EMP0003','01/02/24',670.00,120.60,790.60,'A'),
    ('BOL0064','PAC0014','EMP0004','01/02/24',680.00,122.40,802.40,'A'),
    ('BOL0065','PAC0015','EMP0005','02/02/24',690.00,124.20,814.20,'A'),
    ('BOL0066','PAC0016','EMP0006','02/02/24',700.00,126.00,826.00,'A'),
    ('BOL0067','PAC0017','EMP0007','03/02/24',710.00,127.80,837.80,'A'),
    ('BOL0068','PAC0018','EMP0008','03/02/24',720.00,129.60,849.60,'A'),
    ('BOL0069','PAC0019','EMP0009','04/02/24',730.00,131.40,861.40,'A'),
    ('BOL0070','PAC0020','EMP0010','04/02/24',740.00,133.20,873.20,'A'),
    ('BOL0071','PAC0021','EMP0001','05/02/24',750.00,135.00,885.00,'A'),
    ('BOL0072','PAC0022','EMP0002','05/02/24',760.00,136.80,896.80,'A'),
    ('BOL0073','PAC0023','EMP0003','06/02/24',770.00,138.60,908.60,'A'),
    ('BOL0074','PAC0024','EMP0004','06/02/24',780.00,140.40,920.40,'A'),
    ('BOL0075','PAC0025','EMP0005','07/02/24',790.00,142.20,932.20,'A'),
    ('BOL0076','PAC0026','EMP0006','07/02/24',800.00,144.00,944.00,'A'),
    ('BOL0077','PAC0027','EMP0007','08/02/24',810.00,145.80,955.80,'A'),
    ('BOL0078','PAC0028','EMP0008','08/02/24',820.00,147.60,967.60,'A'),
    ('BOL0079','PAC0029','EMP0009','09/02/24',830.00,149.40,979.40,'A'),
    ('BOL0080','PAC0030','EMP0010','09/02/24',840.00,151.20,991.20,'A'),
    ('BOL0081','PAC0031','EMP0001','10/02/24',850.00,153.00,1003.00,'A'),
    ('BOL0082','PAC0032','EMP0002','10/02/24',860.00,154.80,1014.80,'A'),
    ('BOL0083','PAC0033','EMP0003','11/02/24',870.00,156.60,1026.60,'A'),
    ('BOL0084','PAC0034','EMP0004','11/02/24',880.00,158.40,1038.40,'A'),
    ('BOL0085','PAC0035','EMP0005','12/02/24',890.00,160.20,1050.20,'A'),
    ('BOL0086','PAC0036','EMP0006','12/02/24',900.00,162.00,1062.00,'A'),
    ('BOL0087','PAC0037','EMP0007','13/02/24',910.00,163.80,1073.80,'A'),
    ('BOL0088','PAC0038','EMP0008','13/02/24',920.00,165.60,1085.60,'A'),
    ('BOL0089','PAC0039','EMP0009','14/02/24',930.00,167.40,1097.40,'A'),
    ('BOL0090','PAC0040','EMP0010','14/02/24',940.00,169.20,1109.20,'A'),
    ('BOL0091','PAC0041','EMP0001','15/02/24',950.00,171.00,1121.00,'A'),
    ('BOL0092','PAC0042','EMP0002','15/02/24',960.00,172.80,1132.80,'A'),
    ('BOL0093','PAC0043','EMP0003','16/02/24',970.00,174.60,1144.60,'A'),
    ('BOL0094','PAC0044','EMP0004','16/02/24',980.00,176.40,1156.40,'A'),
    ('BOL0095','PAC0045','EMP0005','17/02/24',990.00,178.20,1168.20,'A'),
    ('BOL0096','PAC0046','EMP0006','17/02/24',1000.00,180.00,1180.00,'A'),
    ('BOL0097','PAC0047','EMP0007','18/02/24',1010.00,181.80,1191.80,'A'),
    ('BOL0098','PAC0048','EMP0008','18/02/24',1020.00,183.60,1203.60,'A'),
    ('BOL0099','PAC0049','EMP0009','19/02/24',1030.00,185.40,1215.40,'A'),
    ('BOL0100','PAC0050','EMP0010','19/02/24',1040.00,187.20,1227.20,'A'),
    ('BOL0101','PAC0001','EMP0001','20/02/24',1050.00,189.00,1239.00,'A'),
    ('BOL0102','PAC0002','EMP0002','20/02/24',1060.00,190.80,1250.80,'A'),
    ('BOL0103','PAC0003','EMP0003','21/02/24',1070.00,192.60,1262.60,'A'),
    ('BOL0104','PAC0004','EMP0004','21/02/24',1080.00,194.40,1274.40,'A'),
    ('BOL0105','PAC0005','EMP0005','22/02/24',1090.00,196.20,1286.20,'A'),
    ('BOL0106','PAC0006','EMP0006','22/02/24',1100.00,198.00,1298.00,'A'),
    ('BOL0107','PAC0007','EMP0007','23/02/24',1110.00,199.80,1309.80,'A'),
    ('BOL0108','PAC0008','EMP0008','23/02/24',1120.00,201.60,1321.60,'A'),
    ('BOL0109','PAC0009','EMP0009','24/02/24',1130.00,203.40,1333.40,'A'),
    ('BOL0110','PAC0010','EMP0010','24/02/24',1140.00,205.20,1345.20,'A'),
    ('BOL0111','PAC0011','EMP0001','25/02/24',1150.00,207.00,1357.00,'A'),
    ('BOL0112','PAC0012','EMP0002','25/02/24',1160.00,208.80,1368.80,'A'),
    ('BOL0113','PAC0013','EMP0003','26/02/24',1170.00,210.60,1380.60,'A'),
    ('BOL0114','PAC0014','EMP0004','26/02/24',1180.00,212.40,1392.40,'A'),
    ('BOL0115','PAC0015','EMP0005','27/02/24',1190.00,214.20,1404.20,'A'),
    ('BOL0116','PAC0016','EMP0006','27/02/24',1200.00,216.00,1416.00,'A'),
    ('BOL0117','PAC0017','EMP0007','28/02/24',1210.00,217.80,1427.80,'A'),
    ('BOL0118','PAC0018','EMP0008','28/02/24',1220.00,219.60,1439.60,'A'),
    ('BOL0119','PAC0019','EMP0009','29/02/24',1230.00,221.40,1451.40,'A'),
    ('BOL0120','PAC0020','EMP0010','29/02/24',1240.00,223.20,1463.20,'A'),
    ('BOL0121','PAC0021','EMP0001','01/03/24',1250.00,225.00,1475.00,'A'),
    ('BOL0122','PAC0022','EMP0002','01/03/24',1260.00,226.80,1486.80,'A'),
    ('BOL0123','PAC0023','EMP0003','02/03/24',1270.00,228.60,1498.60,'A'),
    ('BOL0124','PAC0024','EMP0004','02/03/24',1280.00,230.40,1510.40,'A'),
    ('BOL0125','PAC0025','EMP0005','03/03/24',1290.00,232.20,1522.20,'A'),
    ('BOL0126','PAC0026','EMP0006','03/03/24',1300.00,234.00,1534.00,'A'),
    ('BOL0127','PAC0027','EMP0007','04/03/24',1310.00,235.80,1545.80,'A'),
    ('BOL0128','PAC0028','EMP0008','04/03/24',1320.00,237.60,1557.60,'A'),
    ('BOL0129','PAC0029','EMP0009','05/03/24',1330.00,239.40,1569.40,'A'),
    ('BOL0130','PAC0030','EMP0010','05/03/24',1340.00,241.20,1581.20,'A'),
    ('BOL0131','PAC0031','EMP0001','06/03/24',1350.00,243.00,1593.00,'A'),
    ('BOL0132','PAC0032','EMP0002','06/03/24',1360.00,244.80,1604.80,'A'),
    ('BOL0133','PAC0033','EMP0003','07/03/24',1370.00,246.60,1616.60,'A'),
    ('BOL0134','PAC0034','EMP0004','07/03/24',1380.00,248.40,1628.40,'A'),
    ('BOL0135','PAC0035','EMP0005','08/03/24',1390.00,250.20,1640.20,'A'),
    ('BOL0136','PAC0036','EMP0006','08/03/24',1400.00,252.00,1652.00,'A'),
    ('BOL0137','PAC0037','EMP0007','09/03/24',1410.00,253.80,1663.80,'A'),
    ('BOL0138','PAC0038','EMP0008','09/03/24',1420.00,255.60,1675.60,'A'),
    ('BOL0139','PAC0039','EMP0009','10/03/24',1430.00,257.40,1687.40,'A'),
    ('BOL0140','PAC0040','EMP0010','10/03/24',1440.00,259.20,1699.20,'A'),
    ('BOL0141','PAC0041','EMP0001','11/03/24',1450.00,261.00,1711.00,'A'),
    ('BOL0142','PAC0042','EMP0002','11/03/24',1460.00,262.80,1722.80,'A'),
    ('BOL0143','PAC0043','EMP0003','12/03/24',1470.00,264.60,1734.60,'A'),
    ('BOL0144','PAC0044','EMP0004','12/03/24',1480.00,266.40,1746.40,'A'),
    ('BOL0145','PAC0045','EMP0005','13/03/24',1490.00,268.20,1758.20,'A'),
    ('BOL0146','PAC0046','EMP0006','13/03/24',1500.00,270.00,1770.00,'A'),
    ('BOL0147','PAC0047','EMP0007','14/03/24',1510.00,271.80,1781.80,'A'),
    ('BOL0148','PAC0048','EMP0008','14/03/24',1520.00,273.60,1793.60,'A'),
    ('BOL0149','PAC0049','EMP0009','15/03/24',1530.00,275.40,1805.40,'A'),
    ('BOL0150','PAC0050','EMP0010','15/03/24',1540.00,277.20,1817.20,'A')
go

--=====================================================================
--                    Registros Boleta Detalle 
--=====================================================================
Insert into BDClinica.Atenciones.BoletaDetalle
    ([BoletaDetalleCodigo], [BoletaCodigo], [BoletaDetalleConcepto], [BoletaDetalleCantidad], [BoletaDetallePrecio], [BoletaDetalleImporte], [BoletaDetalleEstado])
    values  
    ('BOD0001','BOL0001','Consulta médica general',1,50.00,50.00,'A'),
    ('BOD0002','BOL0001','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0003','BOL0002','Consulta médica general',1,55.00,55.00,'A'),
    ('BOD0004','BOL0002','Laboratorio',1,20.00,20.00,'A'),
    ('BOD0005','BOL0003','Consulta médica general',1,60.00,60.00,'A'),
    ('BOD0006','BOL0003','Medicamentos',2,12.00,24.00,'A'),
    ('BOD0007','BOL0004','Consulta médica general',1,65.00,65.00,'A'),
    ('BOD0008','BOL0004','Radiografía',1,25.00,25.00,'A'),
    ('BOD0009','BOL0005','Consulta médica general',1,70.00,70.00,'A'),
    ('BOD0010','BOL0005','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0011','BOL0006','Consulta médica general',1,45.00,45.00,'A'),
    ('BOD0012','BOL0006','Medicamentos',2,10.00,20.00,'A'),
    ('BOD0013','BOL0007','Consulta médica general',1,75.00,75.00,'A'),
    ('BOD0014','BOL0007','Radiografía',1,30.00,30.00,'A'),
    ('BOD0015','BOL0008','Consulta médica general',1,80.00,80.00,'A'),
    ('BOD0016','BOL0008','Laboratorio',1,20.00,20.00,'A'),
    ('BOD0017','BOL0009','Consulta médica general',1,85.00,85.00,'A'),
    ('BOD0018','BOL0009','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0019','BOL0010','Consulta médica general',1,90.00,90.00,'A'),
    ('BOD0020','BOL0010','Radiografía',1,25.00,25.00,'A'),
    ('BOD0021','BOL0011','Consulta médica general',1,95.00,95.00,'A'),
    ('BOD0022','BOL0011','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0023','BOL0012','Consulta médica general',1,100.00,100.00,'A'),
    ('BOD0024','BOL0012','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0025','BOL0013','Consulta médica general',1,105.00,105.00,'A'),
    ('BOD0026','BOL0013','Radiografía',1,25.00,25.00,'A'),
    ('BOD0027','BOL0014','Consulta médica general',1,110.00,110.00,'A'),
    ('BOD0028','BOL0014','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0029','BOL0015','Consulta médica general',1,115.00,115.00,'A'),
    ('BOD0030','BOL0015','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0031','BOL0016','Consulta médica general',1,120.00,120.00,'A'),
    ('BOD0032','BOL0016','Radiografía',1,25.00,25.00,'A'),
    ('BOD0033','BOL0017','Consulta médica general',1,125.00,125.00,'A'),
    ('BOD0034','BOL0017','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0035','BOL0018','Consulta médica general',1,130.00,130.00,'A'),
    ('BOD0036','BOL0018','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0037','BOL0019','Consulta médica general',1,135.00,135.00,'A'),
    ('BOD0038','BOL0019','Radiografía',1,25.00,25.00,'A'),
    ('BOD0039','BOL0020','Consulta médica general',1,140.00,140.00,'A'),
    ('BOD0040','BOL0020','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0041','BOL0021','Consulta médica general',1,145.00,145.00,'A'),
    ('BOD0042','BOL0021','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0043','BOL0022','Consulta médica general',1,150.00,150.00,'A'),
    ('BOD0044','BOL0022','Radiografía',1,25.00,25.00,'A'),
    ('BOD0045','BOL0023','Consulta médica general',1,155.00,155.00,'A'),
    ('BOD0046','BOL0023','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0047','BOL0024','Consulta médica general',1,160.00,160.00,'A'),
    ('BOD0048','BOL0024','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0049','BOL0025','Consulta médica general',1,165.00,165.00,'A'),
    ('BOD0050','BOL0025','Radiografía',1,25.00,25.00,'A'),
    ('BOD0051','BOL0026','Consulta médica general',1,170.00,170.00,'A'),
    ('BOD0052','BOL0026','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0053','BOL0027','Consulta médica general',1,175.00,175.00,'A'),
    ('BOD0054','BOL0027','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0055','BOL0028','Consulta médica general',1,180.00,180.00,'A'),
    ('BOD0056','BOL0028','Radiografía',1,25.00,25.00,'A'),
    ('BOD0057','BOL0029','Consulta médica general',1,185.00,185.00,'A'),
    ('BOD0058','BOL0029','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0059','BOL0030','Consulta médica general',1,190.00,190.00,'A'),
    ('BOD0060','BOL0030','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0061','BOL0031','Consulta médica general',1,195.00,195.00,'A'),
    ('BOD0062','BOL0031','Radiografía',1,25.00,25.00,'A'),
    ('BOD0063','BOL0032','Consulta médica general',1,200.00,200.00,'A'),
    ('BOD0064','BOL0032','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0065','BOL0033','Consulta médica general',1,205.00,205.00,'A'),
    ('BOD0066','BOL0033','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0067','BOL0034','Consulta médica general',1,210.00,210.00,'A'),
    ('BOD0068','BOL0034','Radiografía',1,25.00,25.00,'A'),
    ('BOD0069','BOL0035','Consulta médica general',1,215.00,215.00,'A'),
    ('BOD0070','BOL0035','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0071','BOL0036','Consulta médica general',1,220.00,220.00,'A'),
    ('BOD0072','BOL0036','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0073','BOL0037','Consulta médica general',1,225.00,225.00,'A'),
    ('BOD0074','BOL0037','Radiografía',1,25.00,25.00,'A'),
    ('BOD0075','BOL0038','Consulta médica general',1,230.00,230.00,'A'),
    ('BOD0076','BOL0038','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0077','BOL0039','Consulta médica general',1,235.00,235.00,'A'),
    ('BOD0078','BOL0039','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0079','BOL0040','Consulta médica general',1,240.00,240.00,'A'),
    ('BOD0080','BOL0040','Radiografía',1,25.00,25.00,'A'),
    ('BOD0081','BOL0041','Consulta médica general',1,245.00,245.00,'A'),
    ('BOD0082','BOL0041','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0083','BOL0042','Consulta médica general',1,250.00,250.00,'A'),
    ('BOD0084','BOL0042','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0085','BOL0043','Consulta médica general',1,255.00,255.00,'A'),
    ('BOD0086','BOL0043','Radiografía',1,25.00,25.00,'A'),
    ('BOD0087','BOL0044','Consulta médica general',1,260.00,260.00,'A'),
    ('BOD0088','BOL0044','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0089','BOL0045','Consulta médica general',1,265.00,265.00,'A'),
    ('BOD0090','BOL0045','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0091','BOL0046','Consulta médica general',1,270.00,270.00,'A'),
    ('BOD0092','BOL0046','Radiografía',1,25.00,25.00,'A'),
    ('BOD0093','BOL0047','Consulta médica general',1,275.00,275.00,'A'),
    ('BOD0094','BOL0047','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0095','BOL0048','Consulta médica general',1,280.00,280.00,'A'),
    ('BOD0096','BOL0048','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0097','BOL0049','Consulta médica general',1,285.00,285.00,'A'),
    ('BOD0098','BOL0049','Radiografía',1,25.00,25.00,'A'),
    ('BOD0099','BOL0050','Consulta médica general',1,290.00,290.00,'A'),
    ('BOD0100','BOL0050','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0101','BOL0051','Consulta médica general',1,295.00,295.00,'A'),
    ('BOD0102','BOL0051','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0103','BOL0052','Consulta médica general',1,300.00,300.00,'A'),
    ('BOD0104','BOL0052','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0105','BOL0053','Consulta médica general',1,305.00,305.00,'A'),
    ('BOD0106','BOL0053','Radiografía',1,25.00,25.00,'A'),
    ('BOD0107','BOL0054','Consulta médica general',1,310.00,310.00,'A'),
    ('BOD0108','BOL0054','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0109','BOL0055','Consulta médica general',1,315.00,315.00,'A'),
    ('BOD0110','BOL0055','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0111','BOL0056','Consulta médica general',1,320.00,320.00,'A'),
    ('BOD0112','BOL0056','Radiografía',1,25.00,25.00,'A'),
    ('BOD0113','BOL0057','Consulta médica general',1,325.00,325.00,'A'),
    ('BOD0114','BOL0057','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0115','BOL0058','Consulta médica general',1,330.00,330.00,'A'),
    ('BOD0116','BOL0058','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0117','BOL0059','Consulta médica general',1,335.00,335.00,'A'),
    ('BOD0118','BOL0059','Radiografía',1,25.00,25.00,'A'),
    ('BOD0119','BOL0060','Consulta médica general',1,340.00,340.00,'A'),
    ('BOD0120','BOL0060','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0121','BOL0061','Consulta médica general',1,345.00,345.00,'A'),
    ('BOD0122','BOL0061','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0123','BOL0062','Consulta médica general',1,350.00,350.00,'A'),
    ('BOD0124','BOL0062','Radiografía',1,25.00,25.00,'A'),
    ('BOD0125','BOL0063','Consulta médica general',1,355.00,355.00,'A'),
    ('BOD0126','BOL0063','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0127','BOL0064','Consulta médica general',1,360.00,360.00,'A'),
    ('BOD0128','BOL0064','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0129','BOL0065','Consulta médica general',1,365.00,365.00,'A'),
    ('BOD0130','BOL0065','Radiografía',1,25.00,25.00,'A'),
    ('BOD0131','BOL0066','Consulta médica general',1,370.00,370.00,'A'),
    ('BOD0132','BOL0066','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0133','BOL0067','Consulta médica general',1,375.00,375.00,'A'),
    ('BOD0134','BOL0067','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0135','BOL0068','Consulta médica general',1,380.00,380.00,'A'),
    ('BOD0136','BOL0068','Radiografía',1,25.00,25.00,'A'),
    ('BOD0137','BOL0069','Consulta médica general',1,385.00,385.00,'A'),
    ('BOD0138','BOL0069','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0139','BOL0070','Consulta médica general',1,390.00,390.00,'A'),
    ('BOD0140','BOL0070','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0141','BOL0071','Consulta médica general',1,395.00,395.00,'A'),
    ('BOD0142','BOL0071','Radiografía',1,25.00,25.00,'A'),
    ('BOD0143','BOL0072','Consulta médica general',1,400.00,400.00,'A'),
    ('BOD0144','BOL0072','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0145','BOL0073','Consulta médica general',1,405.00,405.00,'A'),
    ('BOD0146','BOL0073','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0147','BOL0074','Consulta médica general',1,410.00,410.00,'A'),
    ('BOD0148','BOL0074','Radiografía',1,25.00,25.00,'A'),
    ('BOD0149','BOL0075','Consulta médica general',1,415.00,415.00,'A'),
    ('BOD0150','BOL0075','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0151','BOL0076','Consulta médica general',1,420.00,420.00,'A'),
    ('BOD0152','BOL0076','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0153','BOL0077','Consulta médica general',1,425.00,425.00,'A'),
    ('BOD0154','BOL0077','Radiografía',1,25.00,25.00,'A'),
    ('BOD0155','BOL0078','Consulta médica general',1,430.00,430.00,'A'),
    ('BOD0156','BOL0078','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0157','BOL0079','Consulta médica general',1,435.00,435.00,'A'),
    ('BOD0158','BOL0079','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0159','BOL0080','Consulta médica general',1,440.00,440.00,'A'),
    ('BOD0160','BOL0080','Radiografía',1,25.00,25.00,'A'),
    ('BOD0161','BOL0081','Consulta médica general',1,445.00,445.00,'A'),
    ('BOD0162','BOL0081','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0163','BOL0082','Consulta médica general',1,450.00,450.00,'A'),
    ('BOD0164','BOL0082','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0165','BOL0083','Consulta médica general',1,455.00,455.00,'A'),
    ('BOD0166','BOL0083','Radiografía',1,25.00,25.00,'A'),
    ('BOD0167','BOL0084','Consulta médica general',1,460.00,460.00,'A'),
    ('BOD0168','BOL0084','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0169','BOL0085','Consulta médica general',1,465.00,465.00,'A'),
    ('BOD0170','BOL0085','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0171','BOL0086','Consulta médica general',1,470.00,470.00,'A'),
    ('BOD0172','BOL0086','Radiografía',1,25.00,25.00,'A'),
    ('BOD0173','BOL0087','Consulta médica general',1,475.00,475.00,'A'),
    ('BOD0174','BOL0087','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0175','BOL0088','Consulta médica general',1,480.00,480.00,'A'),
    ('BOD0176','BOL0088','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0177','BOL0089','Consulta médica general',1,485.00,485.00,'A'),
    ('BOD0178','BOL0089','Radiografía',1,25.00,25.00,'A'),
    ('BOD0179','BOL0090','Consulta médica general',1,490.00,490.00,'A'),
    ('BOD0180','BOL0090','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0181','BOL0091','Consulta médica general',1,495.00,495.00,'A'),
    ('BOD0182','BOL0091','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0183','BOL0092','Consulta médica general',1,500.00,500.00,'A'),
    ('BOD0184','BOL0092','Radiografía',1,25.00,25.00,'A'),
    ('BOD0185','BOL0093','Consulta médica general',1,505.00,505.00,'A'),
    ('BOD0186','BOL0093','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0187','BOL0094','Consulta médica general',1,510.00,510.00,'A'),
    ('BOD0188','BOL0094','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0189','BOL0095','Consulta médica general',1,515.00,515.00,'A'),
    ('BOD0190','BOL0095','Radiografía',1,25.00,25.00,'A'),
    ('BOD0191','BOL0096','Consulta médica general',1,520.00,520.00,'A'),
    ('BOD0192','BOL0096','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0193','BOL0097','Consulta médica general',1,525.00,525.00,'A'),
    ('BOD0194','BOL0097','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0195','BOL0098','Consulta médica general',1,530.00,530.00,'A'),
    ('BOD0196','BOL0098','Radiografía',1,25.00,25.00,'A'),
    ('BOD0197','BOL0099','Consulta médica general',1,535.00,535.00,'A'),
    ('BOD0198','BOL0099','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0199','BOL0100','Consulta médica general',1,540.00,540.00,'A'),
    ('BOD0200','BOL0100','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0201','BOL0101','Consulta médica general',1,545.00,545.00,'A'),
    ('BOD0202','BOL0101','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0203','BOL0102','Consulta médica general',1,550.00,550.00,'A'),
    ('BOD0204','BOL0102','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0205','BOL0103','Consulta médica general',1,555.00,555.00,'A'),
    ('BOD0206','BOL0103','Radiografía',1,25.00,25.00,'A'),
    ('BOD0207','BOL0104','Consulta médica general',1,560.00,560.00,'A'),
    ('BOD0208','BOL0104','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0209','BOL0105','Consulta médica general',1,565.00,565.00,'A'),
    ('BOD0210','BOL0105','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0211','BOL0106','Consulta médica general',1,570.00,570.00,'A'),
    ('BOD0212','BOL0106','Radiografía',1,25.00,25.00,'A'),
    ('BOD0213','BOL0107','Consulta médica general',1,575.00,575.00,'A'),
    ('BOD0214','BOL0107','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0215','BOL0108','Consulta médica general',1,580.00,580.00,'A'),
    ('BOD0216','BOL0108','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0217','BOL0109','Consulta médica general',1,585.00,585.00,'A'),
    ('BOD0218','BOL0109','Radiografía',1,25.00,25.00,'A'),
    ('BOD0219','BOL0110','Consulta médica general',1,590.00,590.00,'A'),
    ('BOD0220','BOL0110','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0221','BOL0111','Consulta médica general',1,595.00,595.00,'A'),
    ('BOD0222','BOL0111','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0223','BOL0112','Consulta médica general',1,600.00,600.00,'A'),
    ('BOD0224','BOL0112','Radiografía',1,25.00,25.00,'A'),
    ('BOD0225','BOL0113','Consulta médica general',1,605.00,605.00,'A'),
    ('BOD0226','BOL0113','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0227','BOL0114','Consulta médica general',1,610.00,610.00,'A'),
    ('BOD0228','BOL0114','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0229','BOL0115','Consulta médica general',1,615.00,615.00,'A'),
    ('BOD0230','BOL0115','Radiografía',1,25.00,25.00,'A'),
    ('BOD0231','BOL0116','Consulta médica general',1,620.00,620.00,'A'),
    ('BOD0232','BOL0116','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0233','BOL0117','Consulta médica general',1,625.00,625.00,'A'),
    ('BOD0234','BOL0117','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0235','BOL0118','Consulta médica general',1,630.00,630.00,'A'),
    ('BOD0236','BOL0118','Radiografía',1,25.00,25.00,'A'),
    ('BOD0237','BOL0119','Consulta médica general',1,635.00,635.00,'A'),
    ('BOD0238','BOL0119','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0239','BOL0120','Consulta médica general',1,640.00,640.00,'A'),
    ('BOD0240','BOL0120','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0241','BOL0121','Consulta médica general',1,645.00,645.00,'A'),
    ('BOD0242','BOL0121','Radiografía',1,25.00,25.00,'A'),
    ('BOD0243','BOL0122','Consulta médica general',1,650.00,650.00,'A'),
    ('BOD0244','BOL0122','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0245','BOL0123','Consulta médica general',1,655.00,655.00,'A'),
    ('BOD0246','BOL0123','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0247','BOL0124','Consulta médica general',1,660.00,660.00,'A'),
    ('BOD0248','BOL0124','Radiografía',1,25.00,25.00,'A'),
    ('BOD0249','BOL0125','Consulta médica general',1,665.00,665.00,'A'),
    ('BOD0250','BOL0125','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0251','BOL0126','Consulta médica general',1,670.00,670.00,'A'),
    ('BOD0252','BOL0126','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0253','BOL0127','Consulta médica general',1,675.00,675.00,'A'),
    ('BOD0254','BOL0127','Radiografía',1,25.00,25.00,'A'),
    ('BOD0255','BOL0128','Consulta médica general',1,680.00,680.00,'A'),
    ('BOD0256','BOL0128','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0257','BOL0129','Consulta médica general',1,685.00,685.00,'A'),
    ('BOD0258','BOL0129','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0259','BOL0130','Consulta médica general',1,690.00,690.00,'A'),
    ('BOD0260','BOL0130','Radiografía',1,25.00,25.00,'A'),
    ('BOD0261','BOL0131','Consulta médica general',1,695.00,695.00,'A'),
    ('BOD0262','BOL0131','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0263','BOL0132','Consulta médica general',1,700.00,700.00,'A'),
    ('BOD0264','BOL0132','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0265','BOL0133','Consulta médica general',1,705.00,705.00,'A'),
    ('BOD0266','BOL0133','Radiografía',1,25.00,25.00,'A'),
    ('BOD0267','BOL0134','Consulta médica general',1,710.00,710.00,'A'),
    ('BOD0268','BOL0134','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0269','BOL0135','Consulta médica general',1,715.00,715.00,'A'),
    ('BOD0270','BOL0135','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0271','BOL0136','Consulta médica general',1,720.00,720.00,'A'),
    ('BOD0272','BOL0136','Radiografía',1,25.00,25.00,'A'),
    ('BOD0273','BOL0137','Consulta médica general',1,725.00,725.00,'A'),
    ('BOD0274','BOL0137','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0275','BOL0138','Consulta médica general',1,730.00,730.00,'A'),
    ('BOD0276','BOL0138','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0277','BOL0139','Consulta médica general',1,735.00,735.00,'A'),
    ('BOD0278','BOL0139','Radiografía',1,25.00,25.00,'A'),
    ('BOD0279','BOL0140','Consulta médica general',1,740.00,740.00,'A'),
    ('BOD0280','BOL0140','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0281','BOL0141','Consulta médica general',1,745.00,745.00,'A'),
    ('BOD0282','BOL0141','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0283','BOL0142','Consulta médica general',1,750.00,750.00,'A'),
    ('BOD0284','BOL0142','Radiografía',1,25.00,25.00,'A'),
    ('BOD0285','BOL0143','Consulta médica general',1,755.00,755.00,'A'),
    ('BOD0286','BOL0143','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0287','BOL0144','Consulta médica general',1,760.00,760.00,'A'),
    ('BOD0288','BOL0144','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0289','BOL0145','Consulta médica general',1,765.00,765.00,'A'),
    ('BOD0290','BOL0145','Radiografía',1,25.00,25.00,'A'),
    ('BOD0291','BOL0146','Consulta médica general',1,770.00,770.00,'A'),
    ('BOD0292','BOL0146','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0293','BOL0147','Consulta médica general',1,775.00,775.00,'A'),
    ('BOD0294','BOL0147','Laboratorio',1,30.00,30.00,'A'),
    ('BOD0295','BOL0148','Consulta médica general',1,780.00,780.00,'A'),
    ('BOD0296','BOL0148','Radiografía',1,25.00,25.00,'A'),
    ('BOD0297','BOL0149','Consulta médica general',1,785.00,785.00,'A'),
    ('BOD0298','BOL0149','Medicamentos',2,15.00,30.00,'A'),
    ('BOD0299','BOL0150','Consulta médica general',1,790.00,790.00,'A'),
    ('BOD0300','BOL0150','Laboratorio',1,30.00,30.00,'A')
go

--=====================================================================
--                    Registros Receta Categorías 
--=====================================================================
Insert into BDClinica.Atenciones.RecetaCategorias
    ([RecetaCategoriasCodigo], [RecetaCategoriasNombre], [RecetaCategoriasDescripcion], [RecetaCategoriasEstado])
    values  
    ('RCA0001','Antibióticos','Medicamentos para infecciones bacterianas','A'),
    ('RCA0002','Analgésicos','Medicamentos para aliviar el dolor','A'),
    ('RCA0003','Antiinflamatorios','Medicamentos para reducir inflamación','A'),
    ('RCA0004','Antialérgicos','Medicamentos para tratar alergias','A'),
    ('RCA0005','Vitaminas','Suplementos vitamínicos y nutricionales','A')
go

--=====================================================================
--                    Registros Receta
--=====================================================================
Insert into BDClinica.Atenciones.Receta
    ([RecetaCodigo], [HistoriaClinicaCodigo], [MedicosCodigo], [RecetaCategoriasCodigo], [RecetaFecha], [RecetaDiagnostico], [RecetaIndicaciones], [RecetaObservaciones], [RecetaEstado])
    values  
    ('REC0001','HCL0001','MED0001','RCA0002','10/01/24','Dolor muscular leve','Tomar analgésico cada 8h','','A'),
    ('REC0002','HCL0002','MED0002','RCA0003','11/01/24','Inflamación articular','Antiinflamatorio por 5 días','','A'),
    ('REC0003','HCL0003','MED0003','RCA0001','12/01/24','Infección respiratoria','Antibiótico por 7 días','Control en 1 semana','A'),
    ('REC0004','HCL0004','MED0004','RCA0004','13/01/24','Reacción alérgica leve','Antialérgico por 3 días','','A'),
    ('REC0005','HCL0005','MED0005','RCA0002','14/01/24','Dolor de cabeza','Analgésico si dolor persiste','','A'),
    ('REC0006','HCL0006','MED0006','RCA0003','15/01/24','Inflamación leve','Antiinflamatorio 5 días','','A'),
    ('REC0007','HCL0007','MED0007','RCA0001','16/01/24','Infección bacteriana','Antibiótico completo 7 días','No suspender tratamiento','A'),
    ('REC0008','HCL0008','MED0008','RCA0002','17/01/24','Dolor abdominal leve','Analgésico según necesidad','','A'),
    ('REC0009','HCL0009','MED0009','RCA0003','18/01/24','Inflamación muscular','Antiinflamatorio 5 días','','A'),
    ('REC0010','HCL0010','MED0010','RCA0004','19/01/24','Alergia estacional','Antialérgico diario','','A'),
    ('REC0011','HCL0011','MED0001','RCA0002','20/01/24','Dolor de espalda','Analgésico cada 8h','','A'),
    ('REC0012','HCL0012','MED0002','RCA0003','21/01/24','Inflamación leve','Antiinflamatorio 5 días','','A'),
    ('REC0013','HCL0013','MED0003','RCA0001','22/01/24','Infección urinaria','Antibiótico 7 días','Hidratación constante','A'),
    ('REC0014','HCL0014','MED0004','RCA0002','23/01/24','Dolor general','Analgésico si dolor','','A'),
    ('REC0015','HCL0015','MED0005','RCA0003','24/01/24','Inflamación crónica','Antiinflamatorio controlado','','A'),
    ('REC0016','HCL0016','MED0006','RCA0004','25/01/24','Alergia alimentaria','Antialérgico inmediato','','A'),
    ('REC0017','HCL0017','MED0007','RCA0001','26/01/24','Infección respiratoria','Antibiótico 7 días','','A'),
    ('REC0018','HCL0018','MED0008','RCA0002','27/01/24','Dolor muscular','Analgésico 3 veces al día','','A'),
    ('REC0019','HCL0019','MED0009','RCA0003','28/01/24','Inflamación leve','Antiinflamatorio 5 días','','A'),
    ('REC0020','HCL0020','MED0010','RCA0004','29/01/24','Alergia leve','Antialérgico nocturno','','A'),
    ('REC0021','HCL0021','MED0001','RCA0002','30/01/24','Dolor cervical','Analgésico cada 8h','','A'),
    ('REC0022','HCL0022','MED0002','RCA0003','31/01/24','Inflamación articular','Antiinflamatorio 5 días','','A'),
    ('REC0023','HCL0023','MED0003','RCA0001','01/02/24','Infección bacteriana','Antibiótico 7 días','','A'),
    ('REC0024','HCL0024','MED0004','RCA0002','02/02/24','Dolor leve','Analgésico si necesario','','A'),
    ('REC0025','HCL0025','MED0005','RCA0003','03/02/24','Inflamación muscular','Antiinflamatorio 5 días','','A'),
    ('REC0026','HCL0026','MED0006','RCA0004','04/02/24','Alergia respiratoria','Antialérgico diario','','A'),
    ('REC0027','HCL0027','MED0007','RCA0001','05/02/24','Infección urinaria','Antibiótico completo','','A'),
    ('REC0028','HCL0028','MED0008','RCA0002','06/02/24','Dolor abdominal','Analgésico leve','','A'),
    ('REC0029','HCL0029','MED0009','RCA0003','07/02/24','Inflamación leve','Antiinflamatorio','','A'),
    ('REC0030','HCL0030','MED0010','RCA0004','08/02/24','Alergia estacional','Antialérgico 3 días','','A'),
    ('REC0031','HCL0001','MED0001','RCA0002','09/02/24','Dolor muscular','Analgésico','','A'),
    ('REC0032','HCL0002','MED0002','RCA0003','10/02/24','Inflamación leve','Antiinflamatorio','','A'),
    ('REC0033','HCL0003','MED0003','RCA0001','11/02/24','Infección respiratoria','Antibiótico','','A'),
    ('REC0034','HCL0004','MED0004','RCA0002','12/02/24','Dolor leve','Analgésico','','A'),
    ('REC0035','HCL0005','MED0005','RCA0003','13/02/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0036','HCL0006','MED0006','RCA0004','14/02/24','Alergia','Antialérgico','','A'),
    ('REC0037','HCL0007','MED0007','RCA0001','15/02/24','Infección','Antibiótico','','A'),
    ('REC0038','HCL0008','MED0008','RCA0002','16/02/24','Dolor','Analgésico','','A'),
    ('REC0039','HCL0009','MED0009','RCA0003','17/02/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0040','HCL0010','MED0010','RCA0004','18/02/24','Alergia','Antialérgico','','A'),
    ('REC0041','HCL0011','MED0001','RCA0002','19/02/24','Dolor','Analgésico','','A'),
    ('REC0042','HCL0012','MED0002','RCA0003','20/02/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0043','HCL0013','MED0003','RCA0001','21/02/24','Infección','Antibiótico','','A'),
    ('REC0044','HCL0014','MED0004','RCA0002','22/02/24','Dolor','Analgésico','','A'),
    ('REC0045','HCL0015','MED0005','RCA0003','23/02/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0046','HCL0016','MED0006','RCA0004','24/02/24','Alergia','Antialérgico','','A'),
    ('REC0047','HCL0017','MED0007','RCA0001','25/02/24','Infección','Antibiótico','','A'),
    ('REC0048','HCL0018','MED0008','RCA0002','26/02/24','Dolor','Analgésico','','A'),
    ('REC0049','HCL0019','MED0009','RCA0003','27/02/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0050','HCL0020','MED0010','RCA0004','28/02/24','Alergia','Antialérgico','','A'),
    ('REC0051','HCL0021','MED0001','RCA0002','29/02/24','Dolor','Analgésico','','A'),
    ('REC0052','HCL0022','MED0002','RCA0003','01/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0053','HCL0023','MED0003','RCA0001','02/03/24','Infección','Antibiótico','','A'),
    ('REC0054','HCL0024','MED0004','RCA0002','03/03/24','Dolor','Analgésico','','A'),
    ('REC0055','HCL0025','MED0005','RCA0003','04/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0056','HCL0026','MED0006','RCA0004','05/03/24','Alergia','Antialérgico','','A'),
    ('REC0057','HCL0027','MED0007','RCA0001','06/03/24','Infección','Antibiótico','','A'),
    ('REC0058','HCL0028','MED0008','RCA0002','07/03/24','Dolor','Analgésico','','A'),
    ('REC0059','HCL0029','MED0009','RCA0003','08/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0060','HCL0030','MED0010','RCA0004','09/03/24','Alergia','Antialérgico','','A'),
    ('REC0061','HCL0001','MED0001','RCA0002','10/03/24','Dolor','Analgésico','','A'),
    ('REC0062','HCL0002','MED0002','RCA0003','11/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0063','HCL0003','MED0003','RCA0001','12/03/24','Infección','Antibiótico','','A'),
    ('REC0064','HCL0004','MED0004','RCA0002','13/03/24','Dolor','Analgésico','','A'),
    ('REC0065','HCL0005','MED0005','RCA0003','14/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0066','HCL0006','MED0006','RCA0004','15/03/24','Alergia','Antialérgico','','A'),
    ('REC0067','HCL0007','MED0007','RCA0001','16/03/24','Infección','Antibiótico','','A'),
    ('REC0068','HCL0008','MED0008','RCA0002','17/03/24','Dolor','Analgésico','','A'),
    ('REC0069','HCL0009','MED0009','RCA0003','18/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0070','HCL0010','MED0010','RCA0004','19/03/24','Alergia','Antialérgico','','A'),
    ('REC0071','HCL0011','MED0001','RCA0002','20/03/24','Dolor','Analgésico','','A'),
    ('REC0072','HCL0012','MED0002','RCA0003','21/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0073','HCL0013','MED0003','RCA0001','22/03/24','Infección','Antibiótico','','A'),
    ('REC0074','HCL0014','MED0004','RCA0002','23/03/24','Dolor','Analgésico','','A'),
    ('REC0075','HCL0015','MED0005','RCA0003','24/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0076','HCL0016','MED0006','RCA0004','25/03/24','Alergia','Antialérgico','','A'),
    ('REC0077','HCL0017','MED0007','RCA0001','26/03/24','Infección','Antibiótico','','A'),
    ('REC0078','HCL0018','MED0008','RCA0002','27/03/24','Dolor','Analgésico','','A'),
    ('REC0079','HCL0019','MED0009','RCA0003','28/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0080','HCL0020','MED0010','RCA0004','29/03/24','Alergia','Antialérgico','','A'),
    ('REC0081','HCL0021','MED0001','RCA0002','30/03/24','Dolor','Analgésico','','A'),
    ('REC0082','HCL0022','MED0002','RCA0003','31/03/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0083','HCL0023','MED0003','RCA0001','01/04/24','Infección','Antibiótico','','A'),
    ('REC0084','HCL0024','MED0004','RCA0002','02/04/24','Dolor','Analgésico','','A'),
    ('REC0085','HCL0025','MED0005','RCA0003','03/04/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0086','HCL0026','MED0006','RCA0004','04/04/24','Alergia','Antialérgico','','A'),
    ('REC0087','HCL0027','MED0007','RCA0001','05/04/24','Infección','Antibiótico','','A'),
    ('REC0088','HCL0028','MED0008','RCA0002','06/04/24','Dolor','Analgésico','','A'),
    ('REC0089','HCL0029','MED0009','RCA0003','07/04/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0090','HCL0030','MED0010','RCA0004','08/04/24','Alergia','Antialérgico','','A'),
    ('REC0091','HCL0001','MED0001','RCA0002','09/04/24','Dolor','Analgésico','','A'),
    ('REC0092','HCL0002','MED0002','RCA0003','10/04/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0093','HCL0003','MED0003','RCA0001','11/04/24','Infección','Antibiótico','','A'),
    ('REC0094','HCL0004','MED0004','RCA0002','12/04/24','Dolor','Analgésico','','A'),
    ('REC0095','HCL0005','MED0005','RCA0003','13/04/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0096','HCL0006','MED0006','RCA0004','14/04/24','Alergia','Antialérgico','','A'),
    ('REC0097','HCL0007','MED0007','RCA0001','15/04/24','Infección','Antibiótico','','A'),
    ('REC0098','HCL0008','MED0008','RCA0002','16/04/24','Dolor','Analgésico','','A'),
    ('REC0099','HCL0009','MED0009','RCA0003','17/04/24','Inflamación','Antiinflamatorio','','A'),
    ('REC0100','HCL0010','MED0010','RCA0004','18/04/24','Alergia','Antialérgico','','A')
go

--=====================================================================
--                    Registros Receta Laboratorios  
--=====================================================================
Insert into BDClinica.Atenciones.RecetaLaboratorios
    ([RecetaLaboratoriosCodigo], [RecetaCodigo], [RecetaLaboratoriosExamen], [RecetaLaboratoriosResultado], [RecetaLaboratoriosFecha], [RecetaLaboratoriosObservaciones], [RecetaLaboratoriosEstado])
    values  
    ('REL0001','REC0001','Hemograma completo','Normal','10/01/24','','A'),
    ('REL0002','REC0001','Glucosa','95 mg/dl','10/01/24','','A'),
    ('REL0003','REC0002','Proteína C Reactiva','Elevada','11/01/24','','A'),
    ('REL0004','REC0002','Velocidad de sedimentación','Alta','11/01/24','','A'),
    ('REL0005','REC0003','Hemograma completo','Leucocitosis','12/01/24','','A'),
    ('REL0006','REC0003','Cultivo de esputo','Positivo','12/01/24','Bacteriano','A'),
    ('REL0007','REC0004','IgE total','Elevada','13/01/24','','A'),
    ('REL0008','REC0004','Hemograma','Normal','13/01/24','','A'),
    ('REL0009','REC0005','Glucosa','98 mg/dl','14/01/24','','A'),
    ('REL0010','REC0005','Urea','Normal','14/01/24','','A'),
    ('REL0011','REC0006','Proteína C Reactiva','Moderada','15/01/24','','A'),
    ('REL0012','REC0006','Hemograma','Normal','15/01/24','','A'),
    ('REL0013','REC0007','Urocultivo','Positivo','16/01/24','','A'),
    ('REL0014','REC0007','EGO','Infección urinaria','16/01/24','','A'),
    ('REL0015','REC0008','Amilasa','Normal','17/01/24','','A'),
    ('REL0016','REC0008','Hemograma','Normal','17/01/24','','A'),
    ('REL0017','REC0009','PCR','Elevada','18/01/24','','A'),
    ('REL0018','REC0009','ESR','Alta','18/01/24','','A'),
    ('REL0019','REC0010','IgE','Elevada','19/01/24','','A'),
    ('REL0020','REC0010','Hemograma','Normal','19/01/24','','A'),
    ('REL0021','REC0011','Glucosa','92 mg/dl','20/01/24','','A'),
    ('REL0022','REC0011','Hemograma','Normal','20/01/24','','A'),
    ('REL0023','REC0012','PCR','Alta','21/01/24','','A'),
    ('REL0024','REC0012','ESR','Elevada','21/01/24','','A'),
    ('REL0025','REC0013','Urocultivo','Positivo','22/01/24','','A'),
    ('REL0026','REC0013','EGO','Infección','22/01/24','','A'),
    ('REL0027','REC0014','Glucosa','90 mg/dl','23/01/24','','A'),
    ('REL0028','REC0014','Hemograma','Normal','23/01/24','','A'),
    ('REL0029','REC0015','PCR','Moderada','24/01/24','','A'),
    ('REL0030','REC0015','ESR','Alta','24/01/24','','A'),
    ('REL0031','REC0016','IgE','Elevada','25/01/24','','A'),
    ('REL0032','REC0016','Hemograma','Normal','25/01/24','','A'),
    ('REL0033','REC0017','Cultivo','Positivo','26/01/24','','A'),
    ('REL0034','REC0017','Hemograma','Leucocitosis','26/01/24','','A'),
    ('REL0035','REC0018','Glucosa','94 mg/dl','27/01/24','','A'),
    ('REL0036','REC0018','Urea','Normal','27/01/24','','A'),
    ('REL0037','REC0019','PCR','Elevada','28/01/24','','A'),
    ('REL0038','REC0019','ESR','Alta','28/01/24','','A'),
    ('REL0039','REC0020','IgE','Moderada','29/01/24','','A'),
    ('REL0040','REC0020','Hemograma','Normal','29/01/24','','A'),
    ('REL0041','REC0021','Glucosa','93 mg/dl','30/01/24','','A'),
    ('REL0042','REC0021','Hemograma','Normal','30/01/24','','A'),
    ('REL0043','REC0022','PCR','Alta','31/01/24','','A'),
    ('REL0044','REC0022','ESR','Elevada','31/01/24','','A'),
    ('REL0045','REC0023','Urocultivo','Positivo','01/02/24','','A'),
    ('REL0046','REC0023','EGO','Infección','01/02/24','','A'),
    ('REL0047','REC0024','Glucosa','96 mg/dl','02/02/24','','A'),
    ('REL0048','REC0024','Hemograma','Normal','02/02/24','','A'),
    ('REL0049','REC0025','PCR','Moderada','03/02/24','','A'),
    ('REL0050','REC0025','ESR','Alta','03/02/24','','A'),
    ('REL0051','REC0026','IgE','Elevada','04/02/24','','A'),
    ('REL0052','REC0026','Hemograma','Normal','04/02/24','','A'),
    ('REL0053','REC0027','Urocultivo','Positivo','05/02/24','','A'),
    ('REL0054','REC0027','EGO','Infección','05/02/24','','A'),
    ('REL0055','REC0028','Glucosa','91 mg/dl','06/02/24','','A'),
    ('REL0056','REC0028','Hemograma','Normal','06/02/24','','A'),
    ('REL0057','REC0029','PCR','Alta','07/02/24','','A'),
    ('REL0058','REC0029','ESR','Elevada','07/02/24','','A'),
    ('REL0059','REC0030','IgE','Moderada','08/02/24','','A'),
    ('REL0060','REC0030','Hemograma','Normal','08/02/24','','A'),
    ('REL0061','REC0031','Glucosa','95 mg/dl','09/02/24','','A'),
    ('REL0062','REC0031','Hemograma','Normal','09/02/24','','A'),
    ('REL0063','REC0032','PCR','Alta','10/02/24','','A'),
    ('REL0064','REC0032','ESR','Elevada','10/02/24','','A'),
    ('REL0065','REC0033','Urocultivo','Positivo','11/02/24','','A'),
    ('REL0066','REC0033','EGO','Infección','11/02/24','','A'),
    ('REL0067','REC0034','Glucosa','92 mg/dl','12/02/24','','A'),
    ('REL0068','REC0034','Hemograma','Normal','12/02/24','','A'),
    ('REL0069','REC0035','PCR','Moderada','13/02/24','','A'),
    ('REL0070','REC0035','ESR','Alta','13/02/24','','A'),
    ('REL0071','REC0036','IgE','Elevada','14/02/24','','A'),
    ('REL0072','REC0036','Hemograma','Normal','14/02/24','','A'),
    ('REL0073','REC0037','Urocultivo','Positivo','15/02/24','','A'),
    ('REL0074','REC0037','EGO','Infección','15/02/24','','A'),
    ('REL0075','REC0038','Glucosa','94 mg/dl','16/02/24','','A'),
    ('REL0076','REC0038','Hemograma','Normal','16/02/24','','A'),
    ('REL0077','REC0039','PCR','Alta','17/02/24','','A'),
    ('REL0078','REC0039','ESR','Elevada','17/02/24','','A'),
    ('REL0079','REC0040','IgE','Moderada','18/02/24','','A'),
    ('REL0080','REC0040','Hemograma','Normal','18/02/24','','A'),
    ('REL0081','REC0041','Glucosa','93 mg/dl','19/02/24','','A'),
    ('REL0082','REC0041','Hemograma','Normal','19/02/24','','A'),
    ('REL0083','REC0042','PCR','Alta','20/02/24','','A'),
    ('REL0084','REC0042','ESR','Elevada','20/02/24','','A'),
    ('REL0085','REC0043','Urocultivo','Positivo','21/02/24','','A'),
    ('REL0086','REC0043','EGO','Infección','21/02/24','','A'),
    ('REL0087','REC0044','Glucosa','96 mg/dl','22/02/24','','A'),
    ('REL0088','REC0044','Hemograma','Normal','22/02/24','','A'),
    ('REL0089','REC0045','PCR','Moderada','23/02/24','','A'),
    ('REL0090','REC0045','ESR','Alta','23/02/24','','A'),
    ('REL0091','REC0046','IgE','Elevada','24/02/24','','A'),
    ('REL0092','REC0046','Hemograma','Normal','24/02/24','','A'),
    ('REL0093','REC0047','Urocultivo','Positivo','25/02/24','','A'),
    ('REL0094','REC0047','EGO','Infección','25/02/24','','A'),
    ('REL0095','REC0048','Glucosa','91 mg/dl','26/02/24','','A'),
    ('REL0096','REC0048','Hemograma','Normal','26/02/24','','A'),
    ('REL0097','REC0049','PCR','Alta','27/02/24','','A'),
    ('REL0098','REC0049','ESR','Elevada','27/02/24','','A'),
    ('REL0099','REC0050','IgE','Moderada','28/02/24','','A'),
    ('REL0100','REC0050','Hemograma','Normal','28/02/24','','A'),
    ('REL0101','REC0051','Hemograma','Normal','01/03/24','','A'),
    ('REL0102','REC0051','Glucosa','92 mg/dl','01/03/24','','A'),
    ('REL0103','REC0052','PCR','Alta','02/03/24','','A'),
    ('REL0104','REC0052','ESR','Elevada','02/03/24','','A'),
    ('REL0105','REC0053','Urocultivo','Positivo','03/03/24','','A'),
    ('REL0106','REC0053','EGO','Infección','03/03/24','','A'),
    ('REL0107','REC0054','Hemograma','Normal','04/03/24','','A'),
    ('REL0108','REC0054','Glucosa','95 mg/dl','04/03/24','','A'),
    ('REL0109','REC0055','PCR','Moderada','05/03/24','','A'),
    ('REL0110','REC0055','ESR','Alta','05/03/24','','A'),
    ('REL0111','REC0056','IgE','Elevada','06/03/24','','A'),
    ('REL0112','REC0056','Hemograma','Normal','06/03/24','','A'),
    ('REL0113','REC0057','Urocultivo','Positivo','07/03/24','','A'),
    ('REL0114','REC0057','EGO','Infección','07/03/24','','A'),
    ('REL0115','REC0058','Glucosa','93 mg/dl','08/03/24','','A'),
    ('REL0116','REC0058','Hemograma','Normal','08/03/24','','A'),
    ('REL0117','REC0059','PCR','Alta','09/03/24','','A'),
    ('REL0118','REC0059','ESR','Elevada','09/03/24','','A'),
    ('REL0119','REC0060','IgE','Moderada','10/03/24','','A'),
    ('REL0120','REC0060','Hemograma','Normal','10/03/24','','A'),
    ('REL0121','REC0061','Glucosa','94 mg/dl','11/03/24','','A'),
    ('REL0122','REC0061','Hemograma','Normal','11/03/24','','A'),
    ('REL0123','REC0062','PCR','Alta','12/03/24','','A'),
    ('REL0124','REC0062','ESR','Elevada','12/03/24','','A'),
    ('REL0125','REC0063','Urocultivo','Positivo','13/03/24','','A'),
    ('REL0126','REC0063','EGO','Infección','13/03/24','','A'),
    ('REL0127','REC0064','Glucosa','92 mg/dl','14/03/24','','A'),
    ('REL0128','REC0064','Hemograma','Normal','14/03/24','','A'),
    ('REL0129','REC0065','PCR','Moderada','15/03/24','','A'),
    ('REL0130','REC0065','ESR','Alta','15/03/24','','A'),
    ('REL0131','REC0066','IgE','Elevada','16/03/24','','A'),
    ('REL0132','REC0066','Hemograma','Normal','16/03/24','','A'),
    ('REL0133','REC0067','Urocultivo','Positivo','17/03/24','','A'),
    ('REL0134','REC0067','EGO','Infección','17/03/24','','A'),
    ('REL0135','REC0068','Glucosa','96 mg/dl','18/03/24','','A'),
    ('REL0136','REC0068','Hemograma','Normal','18/03/24','','A'),
    ('REL0137','REC0069','PCR','Alta','19/03/24','','A'),
    ('REL0138','REC0069','ESR','Elevada','19/03/24','','A'),
    ('REL0139','REC0070','IgE','Moderada','20/03/24','','A'),
    ('REL0140','REC0070','Hemograma','Normal','20/03/24','','A'),
    ('REL0141','REC0071','Glucosa','93 mg/dl','21/03/24','','A'),
    ('REL0142','REC0071','Hemograma','Normal','21/03/24','','A'),
    ('REL0143','REC0072','PCR','Alta','22/03/24','','A'),
    ('REL0144','REC0072','ESR','Elevada','22/03/24','','A'),
    ('REL0145','REC0073','Urocultivo','Positivo','23/03/24','','A'),
    ('REL0146','REC0073','EGO','Infección','23/03/24','','A'),
    ('REL0147','REC0074','Glucosa','95 mg/dl','24/03/24','','A'),
    ('REL0148','REC0074','Hemograma','Normal','24/03/24','','A'),
    ('REL0149','REC0075','PCR','Moderada','25/03/24','','A'),
    ('REL0150','REC0075','ESR','Alta','25/03/24','','A'),
    ('REL0151','REC0076','IgE','Elevada','26/03/24','','A'),
    ('REL0152','REC0076','Hemograma','Normal','26/03/24','','A'),
    ('REL0153','REC0077','Urocultivo','Positivo','27/03/24','','A'),
    ('REL0154','REC0077','EGO','Infección','27/03/24','','A'),
    ('REL0155','REC0078','Glucosa','92 mg/dl','28/03/24','','A'),
    ('REL0156','REC0078','Hemograma','Normal','28/03/24','','A'),
    ('REL0157','REC0079','PCR','Alta','29/03/24','','A'),
    ('REL0158','REC0079','ESR','Elevada','29/03/24','','A'),
    ('REL0159','REC0080','IgE','Moderada','30/03/24','','A'),
    ('REL0160','REC0080','Hemograma','Normal','30/03/24','','A'),
    ('REL0161','REC0081','Glucosa','94 mg/dl','31/03/24','','A'),
    ('REL0162','REC0081','Hemograma','Normal','31/03/24','','A'),
    ('REL0163','REC0082','PCR','Alta','01/04/24','','A'),
    ('REL0164','REC0082','ESR','Elevada','01/04/24','','A'),
    ('REL0165','REC0083','Urocultivo','Positivo','02/04/24','','A'),
    ('REL0166','REC0083','EGO','Infección','02/04/24','','A'),
    ('REL0167','REC0084','Glucosa','95 mg/dl','03/04/24','','A'),
    ('REL0168','REC0084','Hemograma','Normal','03/04/24','','A'),
    ('REL0169','REC0085','PCR','Moderada','04/04/24','','A'),
    ('REL0170','REC0085','ESR','Alta','04/04/24','','A'),
    ('REL0171','REC0086','IgE','Elevada','05/04/24','','A'),
    ('REL0172','REC0086','Hemograma','Normal','05/04/24','','A'),
    ('REL0173','REC0087','Urocultivo','Positivo','06/04/24','','A'),
    ('REL0174','REC0087','EGO','Infección','06/04/24','','A'),
    ('REL0175','REC0088','Glucosa','93 mg/dl','07/04/24','','A'),
    ('REL0176','REC0088','Hemograma','Normal','07/04/24','','A'),
    ('REL0177','REC0089','PCR','Alta','08/04/24','','A'),
    ('REL0178','REC0089','ESR','Elevada','08/04/24','','A'),
    ('REL0179','REC0090','IgE','Moderada','09/04/24','','A'),
    ('REL0180','REC0090','Hemograma','Normal','09/04/24','','A'),
    ('REL0181','REC0091','Glucosa','92 mg/dl','10/04/24','','A'),
    ('REL0182','REC0091','Hemograma','Normal','10/04/24','','A'),
    ('REL0183','REC0092','PCR','Alta','11/04/24','','A'),
    ('REL0184','REC0092','ESR','Elevada','11/04/24','','A'),
    ('REL0185','REC0093','Urocultivo','Positivo','12/04/24','','A'),
    ('REL0186','REC0093','EGO','Infección','12/04/24','','A'),
    ('REL0187','REC0094','Glucosa','94 mg/dl','13/04/24','','A'),
    ('REL0188','REC0094','Hemograma','Normal','13/04/24','','A'),
    ('REL0189','REC0095','PCR','Moderada','14/04/24','','A'),
    ('REL0190','REC0095','ESR','Alta','14/04/24','','A'),
    ('REL0191','REC0096','IgE','Elevada','15/04/24','','A'),
    ('REL0192','REC0096','Hemograma','Normal','15/04/24','','A'),
    ('REL0193','REC0097','Urocultivo','Positivo','16/04/24','','A'),
    ('REL0194','REC0097','EGO','Infección','16/04/24','','A'),
    ('REL0195','REC0098','Glucosa','96 mg/dl','17/04/24','','A'),
    ('REL0196','REC0098','Hemograma','Normal','17/04/24','','A'),
    ('REL0197','REC0099','PCR','Alta','18/04/24','','A'),
    ('REL0198','REC0099','ESR','Elevada','18/04/24','','A'),
    ('REL0199','REC0100','IgE','Moderada','19/04/24','','A'),
    ('REL0200','REC0100','Hemograma','Normal','19/04/24','','A')
go

--=====================================================================
--                    Registros Medicamentos  
--=====================================================================
Insert into BDClinica.Atenciones.Medicamentos
    ([MedicamentosCodigo], [DistribuidorasCodigo], [MedicamentosNombre], [MedicamentosPresentacion], [MedicamentosStock], [MedicamentosPrecio], [MedicamentosFechaVencimiento], 
    [MedicamentosDescripcion], [MedicamentosEstado])
    values  
    ('MDC0001','DIS0001','Amoxicilina','Tabletas 500mg',120,2.50,'10/01/27','Antibiótico de amplio espectro','A'),
    ('MDC0002','DIS0001','Paracetamol','Tabletas 500mg',200,1.20,'15/08/26','Analgésico y antipirético','A'),
    ('MDC0003','DIS0002','Ibuprofeno','Tabletas 400mg',180,1.80,'20/11/26','Antiinflamatorio no esteroideo','A'),
    ('MDC0004','DIS0002','Loratadina','Tabletas 10mg',150,1.50,'05/03/27','Antihistamínico','A'),
    ('MDC0005','DIS0003','Azitromicina','Tabletas 500mg',90,3.50,'12/09/26','Antibiótico macrólido','A'),
    ('MDC0006','DIS0003','Omeprazol','Cápsulas 20mg',160,2.20,'01/05/27','Protector gástrico','A'),
    ('MDC0007','DIS0004','Metformina','Tabletas 850mg',140,1.70,'30/12/26','Antidiabético oral','A'),
    ('MDC0008','DIS0004','Losartán','Tabletas 50mg',130,2.10,'18/02/27','Antihipertensivo','A'),
    ('MDC0009','DIS0005','Salbutamol','Inhalador 100mcg',75,5.50,'10/10/26','Broncodilatador','A'),
    ('MDC0010','DIS0005','Dexametasona','Ampollas 4mg',110,2.90,'22/04/27','Corticoide','A'),
    ('MDC0011','DIS0001','Ciprofloxacino','Tabletas 500mg',95,3.20,'18/09/26','Antibiótico quinolona','A'),
    ('MDC0012','DIS0002','Clorfenamina','Tabletas 4mg',170,1.10,'30/07/26','Antialérgico','A'),
    ('MDC0013','DIS0003','Diclofenaco','Tabletas 50mg',190,1.60,'01/12/26','Antiinflamatorio','A'),
    ('MDC0014','DIS0004','Aspirina','Tabletas 100mg',210,1.00,'10/06/27','Analgésico y antiagregante','A'),
    ('MDC0015','DIS0005','Tramadol','Cápsulas 50mg',80,4.80,'11/11/26','Analgésico opioide','A'),
    ('MDC0016','DIS0001','Vitamina C','Tabletas 500mg',300,0.90,'25/01/27','Suplemento vitamínico','A'),
    ('MDC0017','DIS0002','Vitamina D','Cápsulas 1000UI',260,1.30,'14/02/27','Suplemento óseo','A'),
    ('MDC0018','DIS0003','Calcio','Tabletas 600mg',240,1.40,'20/10/26','Suplemento mineral','A'),
    ('MDC0019','DIS0004','Insulina','Inyección 100UI',60,6.50,'01/09/26','Hormona antidiabética','A'),
    ('MDC0020','DIS0005','Hidrocortisona','Crema 1%',150,2.00,'30/03/27','Corticoide tópico','A'),
    ('MDC0021','DIS0001','Albendazol','Tabletas 400mg',120,1.80,'25/08/26','Antiparasitario','A'),
    ('MDC0022','DIS0002','Metronidazol','Tabletas 500mg',140,2.40,'12/01/27','Antibacteriano y antiparasitario','A'),
    ('MDC0023','DIS0003','Furosemida','Tabletas 40mg',100,1.90,'05/11/26','Diurético','A'),
    ('MDC0024','DIS0004','Enalapril','Tabletas 10mg',130,2.00,'20/02/27','Antihipertensivo','A'),
    ('MDC0025','DIS0005','Amlodipino','Tabletas 5mg',145,2.30,'01/04/27','Calcioantagonista','A'),
    ('MDC0026','DIS0001','Prednisona','Tabletas 20mg',90,2.60,'15/12/26','Corticoide','A'),
    ('MDC0027','DIS0002','Ranitidina','Tabletas 150mg',110,1.50,'08/10/26','Protector gástrico','A'),
    ('MDC0028','DIS0003','Cefalexina','Tabletas 500mg',85,3.10,'28/01/27','Antibiótico cefalosporina','A'),
    ('MDC0029','DIS0004','Azitromicina jarabe','Suspensión 200mg/5ml',70,4.20,'14/09/26','Antibiótico pediátrico','A'),
    ('MDC0030','DIS0005','Salbutamol jarabe','100ml',95,3.00,'10/05/27','Broncodilatador','A'),
    ('MDC0031','DIS0001','Lansoprazol','Cápsulas 30mg',120,2.20,'19/11/26','Protector gástrico','A'),
    ('MDC0032','DIS0002','Ketorolaco','Tabletas 10mg',100,2.70,'22/12/26','Analgésico fuerte','A'),
    ('MDC0033','DIS0003','Naproxeno','Tabletas 550mg',140,1.90,'18/03/27','Antiinflamatorio','A'),
    ('MDC0034','DIS0004','Clindamicina','Cápsulas 300mg',80,3.80,'30/10/26','Antibiótico','A'),
    ('MDC0035','DIS0005','Gentamicina','Ampollas 80mg',75,3.60,'05/02/27','Antibiótico inyectable','A'),
    ('MDC0036','DIS0001','Diazepam','Tabletas 5mg',90,2.50,'09/09/26','Ansiolítico','A'),
    ('MDC0037','DIS0002','Clonazepam','Tabletas 2mg',85,2.90,'11/12/26','Anticonvulsivo','A'),
    ('MDC0038','DIS0003','Fluconazol','Cápsulas 150mg',110,3.20,'17/01/27','Antifúngico','A'),
    ('MDC0039','DIS0004','Miconazol','Crema 2%',130,2.10,'23/03/27','Antifúngico tópico','A'),
    ('MDC0040','DIS0005','Bromhexina','Jarabe 120ml',150,2.30,'12/10/26','Mucolítico','A'),
    ('MDC0041','DIS0001','Ambroxol','Jarabe 120ml',160,2.40,'04/04/27','Expectorante','A'),
    ('MDC0042','DIS0002','Levofloxacino','Tabletas 500mg',95,4.50,'29/11/26','Antibiótico','A'),
    ('MDC0043','DIS0003','Eritromicina','Tabletas 500mg',85,3.30,'14/02/27','Antibiótico macrólido','A'),
    ('MDC0044','DIS0004','Atorvastatina','Tabletas 20mg',170,2.80,'20/05/27','Control colesterol','A'),
    ('MDC0045','DIS0005','Simvastatina','Tabletas 10mg',180,2.50,'27/09/26','Hipolipemiante','A'),
    ('MDC0046','DIS0001','Captopril','Tabletas 25mg',140,1.60,'08/12/26','Antihipertensivo','A'),
    ('MDC0047','DIS0002','Spironolactona','Tabletas 25mg',120,2.20,'01/03/27','Diurético ahorrador de potasio','A'),
    ('MDC0048','DIS0003','Dextrometorfano','Jarabe 100ml',200,2.00,'18/10/26','Antitusivo','A'),
    ('MDC0049','DIS0004','Metamizol','Ampollas 1g',110,3.10,'09/01/27','Analgésico potente','A'),
    ('MDC0050','DIS0005','Hioscina','Tabletas 10mg',130,2.60,'25/11/26','Antiespasmódico','A')
go

--=====================================================================
--                    Registros Farmacia  
--=====================================================================
Insert into BDClinica.Atenciones.Farmacia
    ([FarmaciaCodigo], [RecetaCodigo], [MedicamentosCodigo], [FarmaciaCantidad], [FarmaciaDosis], [FarmaciaFrecuencia], [FarmaciaDuracion], [FarmaciaObservaciones], [FarmaciaEstado])
    values  
    ('FAR0001','REC0001','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0002','REC0001','MDC0006',1,'20mg','Cada 24 horas','7 días','','A'),
    ('FAR0003','REC0002','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0004','REC0002','MDC0008',1,'50mg','Cada 24 horas','10 días','','A'),
    ('FAR0005','REC0003','MDC0001',3,'500mg','Cada 8 horas','7 días','Completar tratamiento','A'),
    ('FAR0006','REC0003','MDC0011',2,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0007','REC0004','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0008','REC0004','MDC0012',1,'4mg','Cada 8 horas','3 días','','A'),
    ('FAR0009','REC0005','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0010','REC0005','MDC0014',1,'100mg','Cada 24 horas','5 días','','A'),
    ('FAR0011','REC0006','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0012','REC0006','MDC0020',1,'1%','Aplicar 2 veces al día','5 días','','A'),
    ('FAR0013','REC0007','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0014','REC0007','MDC0021',1,'400mg','Dosis única','1 día','','A'),
    ('FAR0015','REC0008','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0016','REC0008','MDC0009',1,'100mcg','Cada 6 horas','5 días','','A'),
    ('FAR0017','REC0009','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0018','REC0009','MDC0018',1,'600mg','Cada 24 horas','10 días','','A'),
    ('FAR0019','REC0010','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0020','REC0010','MDC0016',1,'500mg','Cada 24 horas','7 días','','A'),
    ('FAR0021','REC0011','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0022','REC0011','MDC0013',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0023','REC0012','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0024','REC0012','MDC0017',1,'1000UI','Cada 24 horas','30 días','','A'),
    ('FAR0025','REC0013','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0026','REC0013','MDC0022',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0027','REC0014','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0028','REC0014','MDC0025',1,'5mg','Cada 24 horas','10 días','','A'),
    ('FAR0029','REC0015','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0030','REC0015','MDC0023',1,'40mg','Cada 24 horas','5 días','','A'),
    ('FAR0031','REC0016','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0032','REC0016','MDC0026',1,'20mg','Cada 24 horas','5 días','','A'),
    ('FAR0033','REC0017','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0034','REC0017','MDC0028',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0035','REC0018','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0036','REC0018','MDC0030',1,'5ml','Cada 6 horas','5 días','','A'),
    ('FAR0037','REC0019','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0038','REC0019','MDC0033',1,'550mg','Cada 24 horas','7 días','','A'),
    ('FAR0039','REC0020','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0040','REC0020','MDC0032',1,'10mg','Cada 8 horas','3 días','','A'),
    ('FAR0041','REC0021','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0042','REC0021','MDC0035',1,'80mg','Cada 24 horas','5 días','','A'),
    ('FAR0043','REC0022','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0044','REC0022','MDC0036',1,'5mg','Cada 24 horas','7 días','','A'),
    ('FAR0045','REC0023','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0046','REC0023','MDC0038',1,'150mg','Dosis única','1 día','','A'),
    ('FAR0047','REC0024','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0048','REC0024','MDC0039',1,'2%','Aplicar 2 veces','5 días','','A'),
    ('FAR0049','REC0025','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0050','REC0025','MDC0040',1,'120ml','Cada 8 horas','5 días','','A'),
    ('FAR0051','REC0026','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0052','REC0026','MDC0041',1,'120ml','Cada 8 horas','5 días','','A'),
    ('FAR0053','REC0027','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0054','REC0027','MDC0042',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0055','REC0028','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0056','REC0028','MDC0043',1,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0057','REC0029','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0058','REC0029','MDC0044',1,'20mg','Cada 24 horas','30 días','','A'),
    ('FAR0059','REC0030','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0060','REC0030','MDC0045',1,'10mg','Cada 24 horas','30 días','','A'),
    ('FAR0061','REC0031','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0062','REC0031','MDC0046',1,'25mg','Cada 24 horas','7 días','','A'),
    ('FAR0063','REC0032','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0064','REC0032','MDC0047',1,'25mg','Cada 24 horas','5 días','','A'),
    ('FAR0065','REC0033','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0066','REC0033','MDC0048',1,'100ml','Cada 6 horas','5 días','','A'),
    ('FAR0067','REC0034','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0068','REC0034','MDC0049',1,'1g','Cada 12 horas','3 días','','A'),
    ('FAR0069','REC0035','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0070','REC0035','MDC0050',1,'10mg','Cada 8 horas','5 días','','A'),
    ('FAR0071','REC0036','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0072','REC0036','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0073','REC0037','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0074','REC0037','MDC0006',1,'20mg','Cada 24 horas','7 días','','A'),
    ('FAR0075','REC0038','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0076','REC0038','MDC0007',1,'850mg','Cada 24 horas','10 días','','A'),
    ('FAR0077','REC0039','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0078','REC0039','MDC0008',1,'50mg','Cada 24 horas','10 días','','A'),
    ('FAR0079','REC0040','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0080','REC0040','MDC0009',1,'100mcg','Cada 6 horas','5 días','','A'),
    ('FAR0081','REC0041','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0082','REC0041','MDC0010',1,'4mg','Cada 12 horas','3 días','','A'),
    ('FAR0083','REC0042','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0084','REC0042','MDC0011',1,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0085','REC0043','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0086','REC0043','MDC0012',1,'4mg','Cada 8 horas','3 días','','A'),
    ('FAR0087','REC0044','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0088','REC0044','MDC0013',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0089','REC0045','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0090','REC0045','MDC0014',1,'100mg','Cada 24 horas','7 días','','A'),
    ('FAR0091','REC0046','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0092','REC0046','MDC0015',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0093','REC0047','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0094','REC0047','MDC0016',1,'500mg','Cada 24 horas','7 días','','A'),
    ('FAR0095','REC0048','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0096','REC0048','MDC0017',1,'1000UI','Cada 24 horas','30 días','','A'),
    ('FAR0097','REC0049','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0098','REC0049','MDC0018',1,'600mg','Cada 24 horas','10 días','','A'),
    ('FAR0099','REC0050','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0100','REC0050','MDC0019',1,'100UI','Cada 12 horas','según control','','A'),
    ('FAR0101','REC0051','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0102','REC0051','MDC0006',1,'20mg','Cada 24 horas','7 días','','A'),
    ('FAR0103','REC0052','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0104','REC0052','MDC0008',1,'50mg','Cada 24 horas','10 días','','A'),
    ('FAR0105','REC0053','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0106','REC0053','MDC0011',2,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0107','REC0054','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0108','REC0054','MDC0012',1,'4mg','Cada 8 horas','3 días','','A'),
    ('FAR0109','REC0055','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0110','REC0055','MDC0014',1,'100mg','Cada 24 horas','5 días','','A'),
    ('FAR0111','REC0056','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0112','REC0056','MDC0020',1,'1%','Aplicar 2 veces al día','5 días','','A'),
    ('FAR0113','REC0057','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0114','REC0057','MDC0021',1,'400mg','Dosis única','1 día','','A'),
    ('FAR0115','REC0058','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0116','REC0058','MDC0009',1,'100mcg','Cada 6 horas','5 días','','A'),
    ('FAR0117','REC0059','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0118','REC0059','MDC0018',1,'600mg','Cada 24 horas','10 días','','A'),
    ('FAR0119','REC0060','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0120','REC0060','MDC0016',1,'500mg','Cada 24 horas','7 días','','A'),
    ('FAR0121','REC0061','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0122','REC0061','MDC0013',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0123','REC0062','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0124','REC0062','MDC0017',1,'1000UI','Cada 24 horas','30 días','','A'),
    ('FAR0125','REC0063','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0126','REC0063','MDC0022',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0127','REC0064','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0128','REC0064','MDC0025',1,'5mg','Cada 24 horas','10 días','','A'),
    ('FAR0129','REC0065','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0130','REC0065','MDC0023',1,'40mg','Cada 24 horas','5 días','','A'),
    ('FAR0131','REC0066','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0132','REC0066','MDC0026',1,'20mg','Cada 24 horas','5 días','','A'),
    ('FAR0133','REC0067','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0134','REC0067','MDC0028',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0135','REC0068','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0136','REC0068','MDC0030',1,'5ml','Cada 6 horas','5 días','','A'),
    ('FAR0137','REC0069','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0138','REC0069','MDC0033',1,'550mg','Cada 24 horas','7 días','','A'),
    ('FAR0139','REC0070','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0140','REC0070','MDC0032',1,'10mg','Cada 8 horas','3 días','','A'),
    ('FAR0141','REC0071','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0142','REC0071','MDC0035',1,'80mg','Cada 24 horas','5 días','','A'),
    ('FAR0143','REC0072','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0144','REC0072','MDC0036',1,'5mg','Cada 24 horas','7 días','','A'),
    ('FAR0145','REC0073','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0146','REC0073','MDC0038',1,'150mg','Dosis única','1 día','','A'),
    ('FAR0147','REC0074','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0148','REC0074','MDC0039',1,'2%','Aplicar 2 veces','5 días','','A'),
    ('FAR0149','REC0075','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0150','REC0075','MDC0040',1,'120ml','Cada 8 horas','5 días','','A'),
    ('FAR0151','REC0076','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0152','REC0076','MDC0041',1,'120ml','Cada 8 horas','5 días','','A'),
    ('FAR0153','REC0077','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0154','REC0077','MDC0042',1,'500mg','Cada 12 horas','7 días','','A'),
    ('FAR0155','REC0078','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0156','REC0078','MDC0043',1,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0157','REC0079','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0158','REC0079','MDC0044',1,'20mg','Cada 24 horas','30 días','','A'),
    ('FAR0159','REC0080','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0160','REC0080','MDC0045',1,'10mg','Cada 24 horas','30 días','','A'),
    ('FAR0161','REC0081','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0162','REC0081','MDC0046',1,'25mg','Cada 24 horas','7 días','','A'),
    ('FAR0163','REC0082','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0164','REC0082','MDC0047',1,'25mg','Cada 24 horas','5 días','','A'),
    ('FAR0165','REC0083','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0166','REC0083','MDC0048',1,'100ml','Cada 6 horas','5 días','','A'),
    ('FAR0167','REC0084','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0168','REC0084','MDC0049',1,'1g','Cada 12 horas','3 días','','A'),
    ('FAR0169','REC0085','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0170','REC0085','MDC0050',1,'10mg','Cada 8 horas','5 días','','A'),
    ('FAR0171','REC0086','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0172','REC0086','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0173','REC0087','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0174','REC0087','MDC0006',1,'20mg','Cada 24 horas','7 días','','A'),
    ('FAR0175','REC0088','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0176','REC0088','MDC0007',1,'850mg','Cada 24 horas','10 días','','A'),
    ('FAR0177','REC0089','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0178','REC0089','MDC0008',1,'50mg','Cada 24 horas','10 días','','A'),
    ('FAR0179','REC0090','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0180','REC0090','MDC0009',1,'100mcg','Cada 6 horas','5 días','','A'),
    ('FAR0181','REC0091','MDC0002',2,'500mg','Cada 8 horas','5 días','','A'),
    ('FAR0182','REC0091','MDC0010',1,'4mg','Cada 12 horas','3 días','','A'),
    ('FAR0183','REC0092','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0184','REC0092','MDC0011',1,'500mg','Cada 12 horas','5 días','','A'),
    ('FAR0185','REC0093','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0186','REC0093','MDC0012',1,'4mg','Cada 8 horas','3 días','','A'),
    ('FAR0187','REC0094','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0188','REC0094','MDC0013',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0189','REC0095','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0190','REC0095','MDC0014',1,'100mg','Cada 24 horas','7 días','','A'),
    ('FAR0191','REC0096','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0192','REC0096','MDC0015',1,'50mg','Cada 12 horas','5 días','','A'),
    ('FAR0193','REC0097','MDC0001',3,'500mg','Cada 8 horas','7 días','','A'),
    ('FAR0194','REC0097','MDC0016',1,'500mg','Cada 24 horas','7 días','','A'),
    ('FAR0195','REC0098','MDC0002',2,'500mg','Cada 8 horas','3 días','','A'),
    ('FAR0196','REC0098','MDC0017',1,'1000UI','Cada 24 horas','30 días','','A'),
    ('FAR0197','REC0099','MDC0003',2,'400mg','Cada 12 horas','5 días','','A'),
    ('FAR0198','REC0099','MDC0018',1,'600mg','Cada 24 horas','10 días','','A'),
    ('FAR0199','REC0100','MDC0004',1,'10mg','Cada 24 horas','3 días','','A'),
    ('FAR0200','REC0100','MDC0019',1,'100UI','Cada 12 horas','según control','','A')
go

--=====================================================================
--                    Registros Usuarios 
--=====================================================================
Insert into BDClinica.Seguridad.Usuarios
    ([UsuariosCodigo], [UsuariosNombre], [UsuariosClave], [UsuariosRol], [UsuariosUltimoAcceso], [UsuariosEstado])
    values  
    ('USU0001','admin','Admin@123','Administrador','01/06/26 08:10:00','A'),
    ('USU0002','recepcion1','Rec@123','Recepcionista','02/06/26 09:15:00','A'),
    ('USU0003','recepcion2','Rec@456','Recepcionista','03/06/26 10:20:00','A'),
    ('USU0004','medico1','Med@123','Medico','04/06/26 08:30:00','A'),
    ('USU0005','medico2','Med@456','Medico','05/06/26 11:00:00','A'),
    ('USU0006','medico3','Med@789','Medico','06/06/26 12:10:00','A'),
    ('USU0007','enfermera1','Enf@123','Enfermera','07/06/26 07:45:00','A'),
    ('USU0008','enfermera2','Enf@456','Enfermera','08/06/26 08:00:00','A'),
    ('USU0009','enfermera3','Enf@789','Enfermera','09/06/26 09:30:00','A'),
    ('USU0010','caja1','Caja@123','Cajero','10/06/26 10:00:00','A'),
    ('USU0011','caja2','Caja@456','Cajero','11/06/26 10:30:00','A'),
    ('USU0012','laboratorio1','Lab@123','Laboratorista','12/06/26 08:15:00','A'),
    ('USU0013','laboratorio2','Lab@456','Laboratorista','13/06/26 08:40:00','A'),
    ('USU0014','farmacia1','Farm@123','Farmaceutico','14/06/26 09:00:00','A'),
    ('USU0015','farmacia2','Farm@456','Farmaceutico','15/06/26 09:20:00','A'),
    ('USU0016','director','Dir@123','Director','16/06/26 07:00:00','A'),
    ('USU0017','auditor1','Aud@123','Auditor','17/06/26 10:10:00','A'),
    ('USU0018','auditor2','Aud@456','Auditor','18/06/26 11:10:00','A'),
    ('USU0019','sistemas1','Sis@123','TI','18/06/26 12:00:00','A'),
    ('USU0020','sistemas2','Sis@456','TI','18/06/26 12:30:00','A'),
    ('USU0021','usuario21','User@021','Usuario','01/06/26 09:00:00','A'),
    ('USU0022','usuario22','User@022','Usuario','02/06/26 09:10:00','A'),
    ('USU0023','usuario23','User@023','Usuario','03/06/26 09:20:00','A'),
    ('USU0024','usuario24','User@024','Usuario','04/06/26 09:30:00','A'),
    ('USU0025','usuario25','User@025','Usuario','05/06/26 09:40:00','A'),
    ('USU0026','usuario26','User@026','Usuario','06/06/26 09:50:00','A'),
    ('USU0027','usuario27','User@027','Usuario','07/06/26 10:00:00','A'),
    ('USU0028','usuario28','User@028','Usuario','08/06/26 10:10:00','A'),
    ('USU0029','usuario29','User@029','Usuario','09/06/26 10:20:00','A'),
    ('USU0030','usuario30','User@030','Usuario','10/06/26 10:30:00','A'),
    ('USU0031','usuario31','User@031','Usuario','11/06/26 10:40:00','A'),
    ('USU0032','usuario32','User@032','Usuario','12/06/26 10:50:00','A'),
    ('USU0033','usuario33','User@033','Usuario','13/06/26 11:00:00','A'),
    ('USU0034','usuario34','User@034','Usuario','14/06/26 11:10:00','A'),
    ('USU0035','usuario35','User@035','Usuario','15/06/26 11:20:00','A'),
    ('USU0036','usuario36','User@036','Usuario','16/06/26 11:30:00','A'),
    ('USU0037','usuario37','User@037','Usuario','17/06/26 11:40:00','A'),
    ('USU0038','usuario38','User@038','Usuario','18/06/26 11:50:00','A'),
    ('USU0039','usuario39','User@039','Usuario','18/06/26 12:00:00','A'),
    ('USU0040','usuario40','User@040','Usuario','18/06/26 12:10:00','A')
go

--=====================================================================
--                    Registros Usuarios Empleados
--=====================================================================
Insert into BDClinica.Seguridad.UsuariosEmpleados
    ([UsuariosEmpleadosCodigo], [UsuariosCodigo], [EmpleadosCodigo], [UsuariosEmpleadosEstado])
    values  
    ('USE0001','USU0001','EMP0001','A'),
    ('USE0002','USU0002','EMP0002','A'),
    ('USE0003','USU0003','EMP0003','A'),
    ('USE0004','USU0004','EMP0004','A'),
    ('USE0005','USU0005','EMP0005','A'),
    ('USE0006','USU0006','EMP0006','A'),
    ('USE0007','USU0007','EMP0007','A'),
    ('USE0008','USU0008','EMP0008','A'),
    ('USE0009','USU0009','EMP0009','A'),
    ('USE0010','USU0010','EMP0010','A'),
    ('USE0011','USU0011','EMP0011','A'),
    ('USE0012','USU0012','EMP0012','A'),
    ('USE0013','USU0013','EMP0013','A'),
    ('USE0014','USU0014','EMP0014','A'),
    ('USE0015','USU0015','EMP0015','A'),
    ('USE0016','USU0016','EMP0016','A'),
    ('USE0017','USU0017','EMP0017','A'),
    ('USE0018','USU0018','EMP0018','A'),
    ('USE0019','USU0019','EMP0019','A'),
    ('USE0020','USU0020','EMP0020','A')
go

--=====================================================================
--                    Registros Usuarios Medicos
--=====================================================================
Insert into BDClinica.Seguridad.UsuariosMedicos
    ([UsuariosMedicosCodigo], [UsuariosCodigo], [MedicosCodigo], [UsuariosMedicosEstado])
    values  
    ('USM0001','USU0004','MED0001','A'),
    ('USM0002','USU0005','MED0002','A'),
    ('USM0003','USU0006','MED0003','A'),
    ('USM0004','USU0007','MED0004','A'),
    ('USM0005','USU0008','MED0005','A'),
    ('USM0006','USU0009','MED0006','A'),
    ('USM0007','USU0010','MED0007','A'),
    ('USM0008','USU0011','MED0008','A'),
    ('USM0009','USU0012','MED0009','A'),
    ('USM0010','USU0013','MED0010','A'),
    ('USM0011','USU0014','MED0011','A'),
    ('USM0012','USU0015','MED0012','A'),
    ('USM0013','USU0016','MED0013','A'),
    ('USM0014','USU0017','MED0014','A'),
    ('USM0015','USU0018','MED0015','A'),
    ('USM0016','USU0019','MED0016','A'),
    ('USM0017','USU0020','MED0017','A'),
    ('USM0018','USU0021','MED0018','A'),
    ('USM0019','USU0022','MED0019','A'),
    ('USM0020','USU0023','MED0020','A')
go

--=====================================================================
--                      Crear Índices Especialidades
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'EspecialidadesNombreIDXa')
    Begin
        Create index EspecialidadesNombreIDXa on BDClinica.Atenciones.Especialidades
        (EspecialidadesNombre asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index EspecialidadesNombreIDXa on BDClinica.Atenciones.Especialidades
        (EspecialidadesNombre asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Medicos
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'MedicosApellidosIDXa')
    Begin
        Create index MedicosApellidosIDXa on BDClinica.Atenciones.Medicos
        (MedicosApellidos asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index MedicosApellidosIDXa on BDClinica.Atenciones.Medicos
        (MedicosApellidos asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'MedicosNombresIDXa')
    Begin
        Create index MedicosNombresIDXa on BDClinica.Atenciones.Medicos
        (MedicosNombres asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index MedicosNombresIDXa on BDClinica.Atenciones.Medicos
        (MedicosNombres asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Pacientes
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'PacientesApellidosIDXa')
    Begin
        Create index PacientesApellidosIDXa on BDClinica.Atenciones.Pacientes
        (PacientesApellidos asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index PacientesApellidosIDXa on BDClinica.Atenciones.Pacientes
        (PacientesApellidos asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'PacientesDNIIDXa')
    Begin
        Create index PacientesDNIIDXa on BDClinica.Atenciones.Pacientes
        (PacientesDNI asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index PacientesDNIIDXa on BDClinica.Atenciones.Pacientes
        (PacientesDNI asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Citas
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'CitasFechaIDXa')
    Begin
        Create index CitasFechaIDXa on BDClinica.Atenciones.Citas
        (CitasFecha asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index CitasFechaIDXa on BDClinica.Atenciones.Citas
        (CitasFecha asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'CitasFechaIDXd')
    Begin
        Create index CitasFechaIDXd on BDClinica.Atenciones.Citas
        (CitasFecha desc) with (fillfactor = 80)
    End
Else
    Begin
        Create index CitasFechaIDXd on BDClinica.Atenciones.Citas
        (CitasFecha desc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'CitasFechaMedicoIDXa')
    Begin
        Create index CitasFechaMedicoIDXa on BDClinica.Atenciones.Citas
        (CitasFecha asc, MedicosCodigo asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index CitasFechaMedicoIDXa on BDClinica.Atenciones.Citas
        (CitasFecha asc, MedicosCodigo asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Historia Clinica
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'HistoriaClinicaFechaIDXa')
    Begin
        Create index HistoriaClinicaFechaIDXa on BDClinica.Atenciones.HistoriaClinica
        (HistoriaClinicaFechaApertura asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index HistoriaClinicaFechaIDXa on BDClinica.Atenciones.HistoriaClinica
        (HistoriaClinicaFechaApertura asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices  Empleados
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'EmpleadosApellidosIDXa')
    Begin
        Create index EmpleadosApellidosIDXa on BDClinica.Atenciones.Empleados
        (EmpleadosApellidos asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index EmpleadosApellidosIDXa on BDClinica.Atenciones.Empleados
        (EmpleadosApellidos asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices  Factura 
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'FacturaFechaIDXd')
    Begin
        Create index FacturaFechaIDXd on BDClinica.Atenciones.Factura
        (FacturaFecha desc) with (fillfactor = 80)
    End
Else
    Begin
        Create index FacturaFechaIDXd on BDClinica.Atenciones.Factura
        (FacturaFecha desc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'FacturaPacienteFechaIDXad')
    Begin
        Create index FacturaPacienteFechaIDXad on BDClinica.Atenciones.Factura
        (FacturaFecha desc, PacientesCodigo asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index FacturaPacienteFechaIDXad on BDClinica.Atenciones.Factura
        (FacturaFecha desc, PacientesCodigo asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Boleta   
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'BoletaFechaIDXd')
    Begin
        Create index BoletaFechaIDXd on BDClinica.Atenciones.Boleta
        (BoletaFecha desc) with (fillfactor = 80)
    End
Else
    Begin
        Create index BoletaFechaIDXd on BDClinica.Atenciones.Boleta
        (BoletaFecha desc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'BoletaPacienteFechaIDXad')
    Begin
        Create index BoletaPacienteFechaIDXad on BDClinica.Atenciones.Boleta
        (BoletaFecha desc, PacientesCodigo asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index BoletaPacienteFechaIDXad on BDClinica.Atenciones.Boleta
        (BoletaFecha desc, PacientesCodigo asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Receta   
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'RecetaFechaIDXd')
    Begin
        Create index RecetaFechaIDXd on BDClinica.Atenciones.Receta
        (RecetaFecha desc) with (fillfactor = 80)
    End
Else
    Begin
        Create index RecetaFechaIDXd on BDClinica.Atenciones.Receta
        (RecetaFecha desc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'RecetaMedicoFechaIDXad')
    Begin
        Create index RecetaMedicoFechaIDXad on BDClinica.Atenciones.Receta
        (RecetaFecha desc, MedicosCodigo asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index RecetaMedicoFechaIDXad on BDClinica.Atenciones.Receta
        (RecetaFecha desc, MedicosCodigo asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Medicamentos
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'MedicamentosNombreIDXa')
    Begin
        Create index MedicamentosNombreIDXa on BDClinica.Atenciones.Medicamentos
        (MedicamentosNombre asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index MedicamentosNombreIDXa on BDClinica.Atenciones.Medicamentos
        (MedicamentosNombre asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

if not exists 
    (select name from sys.indexes where name = 'MedicamentosVencimientoIDXa')
    Begin
        Create index MedicamentosVencimientoIDXa on BDClinica.Atenciones.Medicamentos
        (MedicamentosFechaVencimiento asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index MedicamentosVencimientoIDXa on BDClinica.Atenciones.Medicamentos
        (MedicamentosFechaVencimiento asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Farmacia
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'FarmaciaMedicamentoIDXa')
    Begin
        Create index FarmaciaMedicamentoIDXa on BDClinica.Atenciones.Farmacia
        (MedicamentosCodigo asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index FarmaciaMedicamentoIDXa on BDClinica.Atenciones.Farmacia
        (MedicamentosCodigo asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Distribuidoras
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'DistribuidorasRazonSocialIDXa')
    Begin
        Create index DistribuidorasRazonSocialIDXa on BDClinica.Atenciones.Distribuidoras
        (DistribuidorasRazonSocial asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index DistribuidorasRazonSocialIDXa on BDClinica.Atenciones.Distribuidoras
        (DistribuidorasRazonSocial asc) with (fillfactor = 80, Drop_existing = on)
    End 
go

--=====================================================================
--                      Crear Índices Usuarios
--=====================================================================
if not exists 
    (select name from sys.indexes where name = 'UsuariosNombreIDXa')
    Begin
        Create index UsuariosNombreIDXa on BDClinica.Seguridad.Usuarios
        (UsuariosNombre asc) with (fillfactor = 80)
    End
Else
    Begin
        Create index UsuariosNombreIDXa on BDClinica.Seguridad.Usuarios
        (UsuariosNombre asc) with (fillfactor = 80, Drop_existing = on)
    End 
go


-- SP para cada tabla: listado sin borrados, listado de borrados, inserción, edición, eliminación, recuperación 

--=====================================================================
--                      SP Tabla Boleta
--=====================================================================

-- Crear sp listado sin borrados Boleta
Create or alter procedure Atenciones.spBoletaListaSinBorrados
    with encryption 
    As 
        select 
            [BoletaCodigo], [PacientesCodigo], [EmpleadosCodigo], [BoletaFecha], [BoletaSubtotal], [BoletaIGV], [BoletaTotal], [BoletaEstado]
            from Atenciones.Boleta As B
            where B.BoletaEstado = 'A'
go

-- Crear sp listado borrados Boleta
Create or alter procedure Atenciones.spBoletaListaBorrados
    with encryption 
    As 
        select 
            [BoletaCodigo], [PacientesCodigo], [EmpleadosCodigo], [BoletaFecha], [BoletaSubtotal], [BoletaIGV], [BoletaTotal], [BoletaEstado]
            from Atenciones.Boleta As B
            where B.BoletaEstado = 'E'
go

-- Crear  sp Inserción Boleta
Create or alter procedure Atenciones.spBoletaInsertarRegistro
    (
    @BoletaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @EmpleadosCodigo nchar(7),
    @BoletaFecha date,
    @BoletaSubtotal numeric(10,2),
    @BoletaIGV numeric(10,2),
    @BoletaTotal numeric(10,2),
    @BoletaEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Boleta
            ([BoletaCodigo], [PacientesCodigo], [EmpleadosCodigo], [BoletaFecha], [BoletaSubtotal], [BoletaIGV], [BoletaTotal], [BoletaEstado])
            values 
            (@BoletaCodigo, @PacientesCodigo, @EmpleadosCodigo, @BoletaFecha, @BoletaSubtotal, @BoletaIGV, @BoletaTotal, @BoletaEstado)
go

-- Crear  sp Modificación Boleta
Create or alter procedure Atenciones.spBoletaEditarRegistro
    (
    @BoletaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @EmpleadosCodigo nchar(7),
    @BoletaFecha date,
    @BoletaSubtotal numeric(10,2),
    @BoletaIGV numeric(10,2),
    @BoletaTotal numeric(10,2)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Boleta
            set
            [PacientesCodigo] = @PacientesCodigo,
            [EmpleadosCodigo] = @EmpleadosCodigo,
            [BoletaFecha] = @BoletaFecha,
            [BoletaSubtotal] = @BoletaSubtotal,
            [BoletaIGV] = @BoletaIGV,
            [BoletaTotal] = @BoletaTotal
            where 
            [BoletaCodigo] = @BoletaCodigo
go

-- Crear  sp Eliminar Boleta
Create or alter procedure Atenciones.spBoletaEliminarRegistro
    (
    @BoletaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Boleta
            set
            BoletaEstado = 'E'
            where 
            [BoletaCodigo] = @BoletaCodigo
go

-- Crear  sp Recuperar Boleta
Create or alter procedure Atenciones.spBoletaRecuperarRegistro
    (
    @BoletaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Boleta
            set
            BoletaEstado = 'A'
            where 
            [BoletaCodigo] = @BoletaCodigo
go

--=====================================================================
--                      SP Tabla Boleta Detalle
--=====================================================================

-- Crear sp listado sin borrados Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleListaSinBorrados
    with encryption 
    As 
        select 
            [BoletaDetalleCodigo], [BoletaCodigo], [BoletaDetalleConcepto], [BoletaDetalleCantidad], [BoletaDetallePrecio], [BoletaDetalleImporte], [BoletaDetalleEstado]
            from Atenciones.BoletaDetalle As B
            where B.BoletaDetalleEstado = 'A'
go

-- Crear sp listado borrados Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleListaBorrados
    with encryption 
    As 
        select 
            [BoletaDetalleCodigo], [BoletaCodigo], [BoletaDetalleConcepto], [BoletaDetalleCantidad], [BoletaDetallePrecio], [BoletaDetalleImporte], [BoletaDetalleEstado]
            from Atenciones.BoletaDetalle As B
            where B.BoletaDetalleEstado = 'E'
go

-- Crear  sp Inserción Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleInsertarRegistro
    (
    @BoletaDetalleCodigo nchar(7), 
    @BoletaCodigo nchar(7),
    @BoletaDetalleConcepto nvarchar(150), 
    @BoletaDetalleCantidad numeric(5,0),
    @BoletaDetallePrecio numeric(10,2),
    @BoletaDetalleImporte numeric(10,2),
    @BoletaDetalleEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.BoletaDetalle
            ([BoletaDetalleCodigo], [BoletaCodigo], [BoletaDetalleConcepto], [BoletaDetalleCantidad], [BoletaDetallePrecio], [BoletaDetalleImporte], [BoletaDetalleEstado])
            values 
            (@BoletaDetalleCodigo, @BoletaCodigo, @BoletaDetalleConcepto, @BoletaDetalleCantidad, @BoletaDetallePrecio, @BoletaDetalleImporte, @BoletaDetalleEstado)
go

-- Crear  sp Modificación Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleEditarRegistro
    (
    @BoletaDetalleCodigo nchar(7), 
    @BoletaCodigo nchar(7),
    @BoletaDetalleConcepto nvarchar(150), 
    @BoletaDetalleCantidad numeric(5,0),
    @BoletaDetallePrecio numeric(10,2),
    @BoletaDetalleImporte numeric(10,2)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.BoletaDetalle
            set
            [BoletaCodigo] = @BoletaCodigo,
            [BoletaDetalleConcepto] = @BoletaDetalleConcepto,
            [BoletaDetalleCantidad] = @BoletaDetalleCantidad,
            [BoletaDetallePrecio] = @BoletaDetallePrecio,
            [BoletaDetalleImporte] = @BoletaDetalleImporte
            where 
            [BoletaDetalleCodigo] = @BoletaDetalleCodigo
go

-- Crear  sp Eliminar Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleEliminarRegistro
    (
    @BoletaDetalleCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.BoletaDetalle
            set
            BoletaDetalleEstado = 'E'
            where 
            [BoletaDetalleCodigo] = @BoletaDetalleCodigo
go

-- Crear  sp Recuperar Boleta Detalle
Create or alter procedure Atenciones.spBoletaDetalleRecuperarRegistro
    (
    @BoletaDetalleCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.BoletaDetalle
            set
            BoletaDetalleEstado = 'A'
            where 
            [BoletaDetalleCodigo] = @BoletaDetalleCodigo
go

--=====================================================================
--                      SP Tabla Citas
--=====================================================================

-- Crear sp listado sin borrados Citas
Create or alter procedure Atenciones.spCitasListaSinBorrados
    with encryption 
    As 
        select 
            [CitasCodigo], [PacientesCodigo], [MedicosCodigo], [ConsultoriosCodigo], [CitasFecha], [CitasHora], [CitasMotivo], [CitasCondiciones], [CitasEstado]
            from Atenciones.Citas As C
            where C.CitasEstado = 'A'
go

-- Crear sp listado borrados Citas
Create or alter procedure Atenciones.spCitasListaBorrados
    with encryption 
    As 
        select 
            [CitasCodigo], [PacientesCodigo], [MedicosCodigo], [ConsultoriosCodigo], [CitasFecha], [CitasHora], [CitasMotivo], [CitasCondiciones], [CitasEstado]
            from Atenciones.Citas As C
            where C.CitasEstado = 'E'
go

-- Crear  sp Inserción Citas
Create or alter procedure Atenciones.spCitasInsertarRegistro
    (
    @CitasCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @MedicosCodigo nchar(7),
    @ConsultoriosCodigo nchar(7),
    @CitasFecha date,
    @CitasHora time,
    @CitasMotivo nvarchar(250),
    @CitasCondiciones nvarchar(300),
    @CitasEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Citas
            ([CitasCodigo], [PacientesCodigo], [MedicosCodigo], [ConsultoriosCodigo], [CitasFecha], [CitasHora], [CitasMotivo], [CitasCondiciones], [CitasEstado])
            values 
            (@CitasCodigo, @PacientesCodigo, @MedicosCodigo, @ConsultoriosCodigo, @CitasFecha, @CitasHora, @CitasMotivo, @CitasCondiciones, @CitasEstado)
go

-- Crear  sp Modificación Citas
Create or alter procedure Atenciones.spCitasEditarRegistro
    (
    @CitasCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @MedicosCodigo nchar(7),
    @ConsultoriosCodigo nchar(7),
    @CitasFecha date,
    @CitasHora time,
    @CitasMotivo nvarchar(250),
    @CitasCondiciones nvarchar(300)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Citas
            set
            [PacientesCodigo] = @PacientesCodigo,
            [MedicosCodigo] = @MedicosCodigo,
            [ConsultoriosCodigo] = @ConsultoriosCodigo,
            [CitasFecha] = @CitasFecha,
            [CitasHora] = @CitasHora,
            [CitasMotivo] = @CitasMotivo,
            [CitasCondiciones] = @CitasCondiciones
            where 
            [CitasCodigo] = @CitasCodigo
go

-- Crear  sp Eliminar Citas
Create or alter procedure Atenciones.spCitasEliminarRegistro
    (
    @CitasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Citas
            set
            CitasEstado = 'E'
            where 
            [CitasCodigo] = @CitasCodigo
go

-- Crear  sp Recuperar Citas
Create or alter procedure Atenciones.spCitasRecuperarRegistro
    (
    @CitasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Citas
            set
            CitasEstado = 'A'
            where 
            [CitasCodigo] = @CitasCodigo
go

--=====================================================================
--                      SP Tabla Consultorios
--=====================================================================

-- Crear sp listado sin borrados Consultorios
Create or alter procedure Atenciones.spConsultoriosListaSinBorrados
    with encryption 
    As 
        select 
            [ConsultoriosCodigo], [ConsultoriosNombre], [ConsultoriosNumero], [ConsultoriosUbicacion], [ConsultoriosPiso], [ConsultoriosDescripcion], [ConsultoriosEstado]
            from Atenciones.Consultorios As C
            where C.ConsultoriosEstado = 'A'
go

-- Crear sp listado borrados Consultorios
Create or alter procedure Atenciones.spConsultoriosListaBorrados
    with encryption 
    As 
        select 
            [ConsultoriosCodigo], [ConsultoriosNombre], [ConsultoriosNumero], [ConsultoriosUbicacion], [ConsultoriosPiso], [ConsultoriosDescripcion], [ConsultoriosEstado]
            from Atenciones.Consultorios As C
            where C.ConsultoriosEstado = 'E'
go

-- Crear  sp Inserción Consultorios
Create or alter procedure Atenciones.spConsultoriosInsertarRegistro
    (
    @ConsultoriosCodigo nchar(7),
    @ConsultoriosNombre nvarchar(100),
    @ConsultoriosNumero nchar(5),
    @ConsultoriosUbicacion nvarchar(100),
    @ConsultoriosPiso numeric(2,0),
    @ConsultoriosDescripcion nvarchar(250),
    @ConsultoriosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Consultorios
            ([ConsultoriosCodigo], [ConsultoriosNombre], [ConsultoriosNumero], [ConsultoriosUbicacion], [ConsultoriosPiso], [ConsultoriosDescripcion], [ConsultoriosEstado])
            values 
            (@ConsultoriosCodigo, @ConsultoriosNombre, @ConsultoriosNumero, @ConsultoriosUbicacion, @ConsultoriosPiso, @ConsultoriosDescripcion, @ConsultoriosEstado)
go

-- Crear  sp Modificación Consultorios
Create or alter procedure Atenciones.spConsultoriosEditarRegistro
    (
    @ConsultoriosCodigo nchar(7),
    @ConsultoriosNombre nvarchar(100),
    @ConsultoriosNumero nchar(5),
    @ConsultoriosUbicacion nvarchar(100),
    @ConsultoriosPiso numeric(2,0),
    @ConsultoriosDescripcion nvarchar(250)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Consultorios
            set
            [ConsultoriosNombre] = @ConsultoriosNombre,
            [ConsultoriosNumero] = @ConsultoriosNumero,
            [ConsultoriosUbicacion] = @ConsultoriosUbicacion,
            [ConsultoriosPiso] = @ConsultoriosPiso,
            [ConsultoriosDescripcion] = @ConsultoriosDescripcion
            where 
            [ConsultoriosCodigo] = @ConsultoriosCodigo
go

-- Crear  sp Eliminar Consultorios
Create or alter procedure Atenciones.spConsultoriosEliminarRegistro
    (
    @ConsultoriosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Consultorios
            set
            ConsultoriosEstado = 'E'
            where 
            [ConsultoriosCodigo] = @ConsultoriosCodigo
go

-- Crear  sp Recuperar Consultorios
Create or alter procedure Atenciones.spConsultoriosRecuperarRegistro
    (
    @ConsultoriosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Consultorios
            set
            ConsultoriosEstado = 'A'
            where 
            [ConsultoriosCodigo] = @ConsultoriosCodigo
go

--=====================================================================
--                      SP Tabla Distribuidoras
--=====================================================================

-- Crear sp listado sin borrados Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasListaSinBorrados
    with encryption 
    As 
        select 
            [DistribuidorasCodigo], [DistribuidorasRUC], [DistribuidorasRazonSocial], [DistribuidorasTelefono], [DistribuidorasCorreo], [DistribuidorasDireccion], [DistribuidorasContacto], [DistribuidorasEstado]
            from Atenciones.Distribuidoras As D
            where D.DistribuidorasEstado = 'A'
go

-- Crear sp listado borrados Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasListaBorrados
    with encryption 
    As 
        select 
            [DistribuidorasCodigo], [DistribuidorasRUC], [DistribuidorasRazonSocial], [DistribuidorasTelefono], [DistribuidorasCorreo], [DistribuidorasDireccion], [DistribuidorasContacto], [DistribuidorasEstado]
            from Atenciones.Distribuidoras As D
            where D.DistribuidorasEstado = 'E'
go

-- Crear  sp Inserción Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasInsertarRegistro
    (
    @DistribuidorasCodigo nchar(7), 
    @DistribuidorasRUC nchar(11),
    @DistribuidorasRazonSocial nvarchar(150),
    @DistribuidorasTelefono nchar(9),
    @DistribuidorasCorreo nvarchar(100),
    @DistribuidorasDireccion nvarchar(200),
    @DistribuidorasContacto nvarchar(100),
    @DistribuidorasEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Distribuidoras
            ([DistribuidorasCodigo], [DistribuidorasRUC], [DistribuidorasRazonSocial], [DistribuidorasTelefono], [DistribuidorasCorreo], [DistribuidorasDireccion], [DistribuidorasContacto], [DistribuidorasEstado])
            values 
            (@DistribuidorasCodigo, @DistribuidorasRUC, @DistribuidorasRazonSocial, @DistribuidorasTelefono, @DistribuidorasCorreo, @DistribuidorasDireccion, @DistribuidorasContacto, @DistribuidorasEstado)
go

-- Crear  sp Modificación Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasEditarRegistro
    (
    @DistribuidorasCodigo nchar(7), 
    @DistribuidorasRUC nchar(11),
    @DistribuidorasRazonSocial nvarchar(150),
    @DistribuidorasTelefono nchar(9),
    @DistribuidorasCorreo nvarchar(100),
    @DistribuidorasDireccion nvarchar(200),
    @DistribuidorasContacto nvarchar(100)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Distribuidoras
            set
            [DistribuidorasRUC] = @DistribuidorasRUC,
            [DistribuidorasRazonSocial] = @DistribuidorasRazonSocial,
            [DistribuidorasTelefono] = @DistribuidorasTelefono,
            [DistribuidorasCorreo] = @DistribuidorasCorreo,
            [DistribuidorasDireccion] = @DistribuidorasDireccion,
            [DistribuidorasContacto] = @DistribuidorasContacto 
            where 
            [DistribuidorasCodigo] = @DistribuidorasCodigo
go

-- Crear  sp Eliminar Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasEliminarRegistro
    (
    @DistribuidorasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Distribuidoras
            set
            DistribuidorasEstado = 'E'
            where 
            [DistribuidorasCodigo] = @DistribuidorasCodigo
go

-- Crear  sp Recuperar Distribuidoras
Create or alter procedure Atenciones.spDistribuidorasRecuperarRegistro
    (
    @DistribuidorasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Distribuidoras
            set
            DistribuidorasEstado = 'A'
            where 
            [DistribuidorasCodigo] = @DistribuidorasCodigo
go

--=====================================================================
--                      SP Tabla Empleados
--=====================================================================

-- Crear sp listado sin borrados Empleados
Create or alter procedure Atenciones.spEmpleadosListaSinBorrados
    with encryption 
    As 
        select 
            [EmpleadosCodigo], [EmpleadosDNI], [EmpleadosNombres], [EmpleadosApellidos], [EmpleadosCargo], [EmpleadosTelefono], [EmpleadosCorreo], [EmpleadosDireccion], [EmpleadosFechaIngreso], [EmpleadosEstado]
            from Atenciones.Empleados As E
            where E.EmpleadosEstado = 'A'
go

-- Crear sp listado borrados Empleados
Create or alter procedure Atenciones.spEmpleadosListaBorrados
    with encryption 
    As 
        select 
            [EmpleadosCodigo], [EmpleadosDNI], [EmpleadosNombres], [EmpleadosApellidos], [EmpleadosCargo], [EmpleadosTelefono], [EmpleadosCorreo], [EmpleadosDireccion], [EmpleadosFechaIngreso], [EmpleadosEstado]
            from Atenciones.Empleados As E
            where E.EmpleadosEstado = 'E'
go

-- Crear  sp Inserción Empleados
Create or alter procedure Atenciones.spEmpleadosInsertarRegistro
    (
    @EmpleadosCodigo nchar(7), 
    @EmpleadosDNI nchar(8),
    @EmpleadosNombres nvarchar(100),
    @EmpleadosApellidos nvarchar(100),
    @EmpleadosCargo nvarchar(50),
    @EmpleadosTelefono nchar(9),
    @EmpleadosCorreo nvarchar(100),
    @EmpleadosDireccion nvarchar(200),
    @EmpleadosFechaIngreso date,
    @EmpleadosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Empleados
            ([EmpleadosCodigo], [EmpleadosDNI], [EmpleadosNombres], [EmpleadosApellidos], [EmpleadosCargo], [EmpleadosTelefono], [EmpleadosCorreo], [EmpleadosDireccion], [EmpleadosFechaIngreso], [EmpleadosEstado])
            values 
            (@EmpleadosCodigo, @EmpleadosDNI, @EmpleadosNombres, @EmpleadosApellidos, @EmpleadosCargo, @EmpleadosTelefono, @EmpleadosCorreo, @EmpleadosDireccion, @EmpleadosFechaIngreso, @EmpleadosEstado)
go

-- Crear  sp Modificación Empleados
Create or alter procedure Atenciones.spEmpleadosEditarRegistro
    (
    @EmpleadosCodigo nchar(7), 
    @EmpleadosDNI nchar(8),
    @EmpleadosNombres nvarchar(100),
    @EmpleadosApellidos nvarchar(100),
    @EmpleadosCargo nvarchar(50),
    @EmpleadosTelefono nchar(9),
    @EmpleadosCorreo nvarchar(100),
    @EmpleadosDireccion nvarchar(200),
    @EmpleadosFechaIngreso date
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Empleados
            set
            [EmpleadosDNI] = @EmpleadosDNI,
            [EmpleadosNombres] = @EmpleadosNombres,
            [EmpleadosApellidos] = @EmpleadosApellidos,
            [EmpleadosCargo] = @EmpleadosCargo,
            [EmpleadosTelefono] = @EmpleadosTelefono,
            [EmpleadosCorreo] = @EmpleadosCorreo,
            [EmpleadosDireccion] = @EmpleadosDireccion,
            [EmpleadosFechaIngreso] = @EmpleadosFechaIngreso
            where 
            [EmpleadosCodigo] = @EmpleadosCodigo
go

-- Crear  sp Eliminar Empleados
Create or alter procedure Atenciones.spEmpleadosEliminarRegistro
    (
    @EmpleadosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Empleados
            set
            EmpleadosEstado = 'E'
            where 
            [EmpleadosCodigo] = @EmpleadosCodigo
go

-- Crear  sp Recuperar Empleados
Create or alter procedure Atenciones.spEmpleadosRecuperarRegistro
    (
    @EmpleadosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Empleados
            set
            EmpleadosEstado = 'A'
            where 
            [EmpleadosCodigo] = @EmpleadosCodigo
go

--=====================================================================
--                      SP Tabla Especialidades
--=====================================================================

-- Crear sp listado sin borrados Especialidades
Create or alter procedure Atenciones.spEspecialidadesListaSinBorrados
    with encryption 
    As 
        select 
            [EspecialidadesCodigo], [EspecialidadesNombre], [EspecialidadesDescripcion], [EspecialidadesEstado]
            from Atenciones.Especialidades As E
            where E.EspecialidadesEstado = 'A'
go

-- Crear sp listado borrados Especialidades
Create or alter procedure Atenciones.spEspecialidadesListaBorrados
    with encryption 
    As 
        select 
            [EspecialidadesCodigo], [EspecialidadesNombre], [EspecialidadesDescripcion], [EspecialidadesEstado]
            from Atenciones.Especialidades As E
            where E.EspecialidadesEstado = 'E'
go

-- Crear  sp Inserción Especialidades
Create or alter procedure Atenciones.spEspecialidadesInsertarRegistro
    (
    @EspecialidadesCodigo nchar(7),
    @EspecialidadesNombre nvarchar(100),
    @EspecialidadesDescripcion nvarchar(250),
    @EspecialidadesEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Especialidades
            ([EspecialidadesCodigo], [EspecialidadesNombre], [EspecialidadesDescripcion], [EspecialidadesEstado])
            values 
            (@EspecialidadesCodigo, @EspecialidadesNombre, @EspecialidadesDescripcion, @EspecialidadesEstado)
go

-- Crear  sp Modificación Especialidades
Create or alter procedure Atenciones.spEspecialidadesEditarRegistro
    (
    @EspecialidadesCodigo nchar(7),
    @EspecialidadesNombre nvarchar(100),
    @EspecialidadesDescripcion nvarchar(250)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Especialidades
            set
            [EspecialidadesNombre] = @EspecialidadesNombre,
            [EspecialidadesDescripcion] = @EspecialidadesDescripcion
            where 
            [EspecialidadesCodigo] = @EspecialidadesCodigo
go

-- Crear  sp Eliminar Especialidades
Create or alter procedure Atenciones.spEspecialidadesEliminarRegistro
    (
    @EspecialidadesCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Especialidades
            set
            EspecialidadesEstado = 'E'
            where 
            [EspecialidadesCodigo] = @EspecialidadesCodigo
go

-- Crear  sp Recuperar Especialidades
Create or alter procedure Atenciones.spEspecialidadesRecuperarRegistro
    (
    @EspecialidadesCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Especialidades
            set
            EspecialidadesEstado = 'A'
            where 
            [EspecialidadesCodigo] = @EspecialidadesCodigo
go

--=====================================================================
--                      SP Tabla Factura
--=====================================================================

-- Crear sp listado sin borrados Factura
Create or alter procedure Atenciones.spFacturaListaSinBorrados
    with encryption 
    As 
        select 
            [FacturaCodigo], [PacientesCodigo], [EmpleadosCodigo], [FacturaFecha], [FacturaSubtotal], [FacturaIGV], [FacturaTotal], [FacturaEstado]
            from Atenciones.Factura As F
            where F.FacturaEstado = 'A'
go

-- Crear sp listado borrados Factura
Create or alter procedure Atenciones.spFacturaListaBorrados
    with encryption 
    As 
        select 
            [FacturaCodigo], [PacientesCodigo], [EmpleadosCodigo], [FacturaFecha], [FacturaSubtotal], [FacturaIGV], [FacturaTotal], [FacturaEstado]
            from Atenciones.Factura As F
            where F.FacturaEstado = 'E'
go

-- Crear  sp Inserción Factura
Create or alter procedure Atenciones.spFacturaInsertarRegistro
    (
    @FacturaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @EmpleadosCodigo nchar(7),
    @FacturaFecha date,
    @FacturaSubtotal numeric(10,2),
    @FacturaIGV numeric(10,2),
    @FacturaTotal numeric(10,2),
    @FacturaEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Factura
            ([FacturaCodigo], [PacientesCodigo], [EmpleadosCodigo], [FacturaFecha], [FacturaSubtotal], [FacturaIGV], [FacturaTotal], [FacturaEstado])
            values 
            (@FacturaCodigo, @PacientesCodigo, @EmpleadosCodigo, @FacturaFecha, @FacturaSubtotal, @FacturaIGV, @FacturaTotal, @FacturaEstado)
go

-- Crear  sp Modificación Factura
Create or alter procedure Atenciones.spFacturaEditarRegistro
    (
    @FacturaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @EmpleadosCodigo nchar(7),
    @FacturaFecha date,
    @FacturaSubtotal numeric(10,2),
    @FacturaIGV numeric(10,2),
    @FacturaTotal numeric(10,2)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Factura
            set
            [PacientesCodigo] = @PacientesCodigo,
            [EmpleadosCodigo] = @EmpleadosCodigo,
            [FacturaFecha] = @FacturaFecha,
            [FacturaSubtotal] = @FacturaSubtotal,
            [FacturaIGV] = @FacturaIGV,
            [FacturaTotal] = @FacturaTotal
            where 
            [FacturaCodigo] = @FacturaCodigo
go

-- Crear  sp Eliminar Factura
Create or alter procedure Atenciones.spFacturaEliminarRegistro
    (
    @FacturaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Factura
            set
            FacturaEstado = 'E'
            where 
            [FacturaCodigo] = @FacturaCodigo
go

-- Crear  sp Recuperar Factura
Create or alter procedure Atenciones.spFacturaRecuperarRegistro
    (
    @FacturaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Factura
            set
            FacturaEstado = 'A'
            where 
            [FacturaCodigo] = @FacturaCodigo
go

--=====================================================================
--                      SP Tabla Factura Detalle
--=====================================================================

-- Crear sp listado sin borrados Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleListaSinBorrados
    with encryption 
    As 
        select 
            [FacturaDetalleCodigo], [FacturaCodigo], [FacturaDetalleConcepto], [FacturaDetalleCantidad], [FacturaDetallePrecio], [FacturaDetalleImporte], [FacturaDetalleEstado]
            from Atenciones.FacturaDetalle As F
            where F.FacturaDetalleEstado = 'A'
go

-- Crear sp listado borrados Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleListaBorrados
    with encryption 
    As 
        select 
            [FacturaDetalleCodigo], [FacturaCodigo], [FacturaDetalleConcepto], [FacturaDetalleCantidad], [FacturaDetallePrecio], [FacturaDetalleImporte], [FacturaDetalleEstado]
            from Atenciones.FacturaDetalle As F
            where F.FacturaDetalleEstado = 'E'
go

-- Crear  sp Inserción Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleInsertarRegistro
    (
    @FacturaDetalleCodigo nchar(7),
    @FacturaCodigo nchar(7),
    @FacturaDetalleConcepto nvarchar(150), 
    @FacturaDetalleCantidad numeric(5,0),
    @FacturaDetallePrecio numeric(10,2),
    @FacturaDetalleImporte numeric(10,2),
    @FacturaDetalleEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.FacturaDetalle
            ([FacturaDetalleCodigo], [FacturaCodigo], [FacturaDetalleConcepto], [FacturaDetalleCantidad], [FacturaDetallePrecio], [FacturaDetalleImporte], [FacturaDetalleEstado])
            values 
            (@FacturaDetalleCodigo, @FacturaCodigo, @FacturaDetalleConcepto, @FacturaDetalleCantidad, @FacturaDetallePrecio, @FacturaDetalleImporte, @FacturaDetalleEstado)
go

-- Crear  sp Modificación Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleEditarRegistro
    (
    @FacturaDetalleCodigo nchar(7),
    @FacturaCodigo nchar(7),
    @FacturaDetalleConcepto nvarchar(150), 
    @FacturaDetalleCantidad numeric(5,0),
    @FacturaDetallePrecio numeric(10,2),
    @FacturaDetalleImporte numeric(10,2)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.FacturaDetalle
            set
            [FacturaCodigo] = @FacturaCodigo,
            [FacturaDetalleConcepto] = @FacturaDetalleConcepto,
            [FacturaDetalleCantidad] = @FacturaDetalleCantidad,
            [FacturaDetallePrecio] = @FacturaDetallePrecio,
            [FacturaDetalleImporte] = @FacturaDetalleImporte
            where 
            [FacturaDetalleCodigo] = @FacturaDetalleCodigo
go

-- Crear  sp Eliminar Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleEliminarRegistro
    (
    @FacturaDetalleCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.FacturaDetalle
            set
            FacturaDetalleEstado = 'E'
            where 
            [FacturaDetalleCodigo] = @FacturaDetalleCodigo
go

-- Crear  sp Recuperar Factura Detalle
Create or alter procedure Atenciones.spFacturaDetalleRecuperarRegistro
    (
    @FacturaDetalleCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.FacturaDetalle
            set
            FacturaDetalleEstado = 'A'
            where 
            [FacturaDetalleCodigo] = @FacturaDetalleCodigo
go

--=====================================================================
--                      SP Tabla Farmacia
--=====================================================================

-- Crear sp listado sin borrados Farmacia
Create or alter procedure Atenciones.spFarmaciaListaSinBorrados
    with encryption 
    As 
        select 
            [FarmaciaCodigo], [RecetaCodigo], [MedicamentosCodigo], [FarmaciaCantidad], [FarmaciaDosis], [FarmaciaFrecuencia], [FarmaciaDuracion], [FarmaciaObservaciones], [FarmaciaEstado]
            from Atenciones.Farmacia As F
            where F.FarmaciaEstado = 'A'
go

-- Crear sp listado borrados Farmacia
Create or alter procedure Atenciones.spFarmaciaListaBorrados
    with encryption 
    As 
        select 
            [FarmaciaCodigo], [RecetaCodigo], [MedicamentosCodigo], [FarmaciaCantidad], [FarmaciaDosis], [FarmaciaFrecuencia], [FarmaciaDuracion], [FarmaciaObservaciones], [FarmaciaEstado]
            from Atenciones.Farmacia As F
            where F.FarmaciaEstado = 'E'
go

-- Crear  sp Inserción Farmacia
Create or alter procedure Atenciones.spFarmaciaInsertarRegistro
    (
    @FarmaciaCodigo nchar(7), 
    @RecetaCodigo nchar(7),
    @MedicamentosCodigo nchar(7), 
    @FarmaciaCantidad numeric(5,0),
    @FarmaciaDosis nvarchar(100),
    @FarmaciaFrecuencia nvarchar(100),
    @FarmaciaDuracion nvarchar(100),
    @FarmaciaObservaciones nvarchar(250),
    @FarmaciaEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Farmacia
            ([FarmaciaCodigo], [RecetaCodigo], [MedicamentosCodigo], [FarmaciaCantidad], [FarmaciaDosis], [FarmaciaFrecuencia], [FarmaciaDuracion], [FarmaciaObservaciones], [FarmaciaEstado])
            values 
            (@FarmaciaCodigo, @RecetaCodigo, @MedicamentosCodigo, @FarmaciaCantidad, @FarmaciaDosis, @FarmaciaFrecuencia, @FarmaciaDuracion, @FarmaciaObservaciones, @FarmaciaEstado)
go

-- Crear  sp Modificación Farmacia
Create or alter procedure Atenciones.spFarmaciaEditarRegistro
    (
    @FarmaciaCodigo nchar(7), 
    @RecetaCodigo nchar(7),
    @MedicamentosCodigo nchar(7), 
    @FarmaciaCantidad numeric(5,0),
    @FarmaciaDosis nvarchar(100),
    @FarmaciaFrecuencia nvarchar(100),
    @FarmaciaDuracion nvarchar(100),
    @FarmaciaObservaciones nvarchar(250)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Farmacia
            set
            [RecetaCodigo] = @RecetaCodigo ,
            [MedicamentosCodigo] = @MedicamentosCodigo , 
            [FarmaciaCantidad] = @FarmaciaCantidad ,
            [FarmaciaDosis] = @FarmaciaDosis ,
            [FarmaciaFrecuencia]  = @FarmaciaFrecuencia ,
            [FarmaciaDuracion] = @FarmaciaDuracion ,
            [FarmaciaObservaciones] = @FarmaciaObservaciones 
            where 
            [FarmaciaCodigo] = @FarmaciaCodigo
go

-- Crear  sp Eliminar Farmacia
Create or alter procedure Atenciones.spFarmaciaEliminarRegistro
    (
    @FarmaciaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Farmacia
            set
            FarmaciaEstado = 'E'
            where 
            [FarmaciaCodigo] = @FarmaciaCodigo
go

-- Crear  sp Recuperar Farmacia
Create or alter procedure Atenciones.spFarmaciaRecuperarRegistro
    (
    @FarmaciaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Farmacia
            set
            FarmaciaEstado = 'A'
            where 
            [FarmaciaCodigo] = @FarmaciaCodigo
go

--=====================================================================
--                      SP Tabla Historia Clinica
--=====================================================================

-- Crear sp listado sin borrados Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaListaSinBorrados
    with encryption 
    As 
        select 
            [HistoriaClinicaCodigo], [PacientesCodigo], [HistoriaClinicaFechaApertura], [HistoriaClinicaGrupoSanguineo], [HistoriaClinicaAlergias], [HistoriaClinicaAntecedentes], [HistoriaClinicaObservaciones], [HistoriaClinicaEstado]
            from Atenciones.HistoriaClinica As H
            where H.HistoriaClinicaEstado = 'A'
go

-- Crear sp listado borrados Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaListaBorrados
    with encryption 
    As 
        select 
            [HistoriaClinicaCodigo], [PacientesCodigo], [HistoriaClinicaFechaApertura], [HistoriaClinicaGrupoSanguineo], [HistoriaClinicaAlergias], [HistoriaClinicaAntecedentes], [HistoriaClinicaObservaciones], [HistoriaClinicaEstado]
            from Atenciones.HistoriaClinica As H
            where H.HistoriaClinicaEstado = 'E'
go

-- Crear  sp Inserción Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaInsertarRegistro
    (
    @HistoriaClinicaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @HistoriaClinicaFechaApertura date, 
    @HistoriaClinicaGrupoSanguineo nvarchar(5),
    @HistoriaClinicaAlergias nvarchar(250),
    @HistoriaClinicaAntecedentes nvarchar(500),
    @HistoriaClinicaObservaciones nvarchar(500),
    @HistoriaClinicaEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.HistoriaClinica
            ([HistoriaClinicaCodigo], [PacientesCodigo], [HistoriaClinicaFechaApertura], [HistoriaClinicaGrupoSanguineo], [HistoriaClinicaAlergias], [HistoriaClinicaAntecedentes], [HistoriaClinicaObservaciones], [HistoriaClinicaEstado])
            values 
            (@HistoriaClinicaCodigo, @PacientesCodigo, @HistoriaClinicaFechaApertura, @HistoriaClinicaGrupoSanguineo, @HistoriaClinicaAlergias, @HistoriaClinicaAntecedentes, @HistoriaClinicaObservaciones, @HistoriaClinicaEstado)
go

-- Crear  sp Modificación Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaEditarRegistro
    (
    @HistoriaClinicaCodigo nchar(7),
    @PacientesCodigo nchar(7),
    @HistoriaClinicaFechaApertura date, 
    @HistoriaClinicaGrupoSanguineo nvarchar(5),
    @HistoriaClinicaAlergias nvarchar(250),
    @HistoriaClinicaAntecedentes nvarchar(500),
    @HistoriaClinicaObservaciones nvarchar(500)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.HistoriaClinica
            set
            [PacientesCodigo] = @PacientesCodigo,
            [HistoriaClinicaFechaApertura] = @HistoriaClinicaFechaApertura, 
            [HistoriaClinicaGrupoSanguineo] = @HistoriaClinicaGrupoSanguineo,
            [HistoriaClinicaAlergias] = @HistoriaClinicaAlergias,
            [HistoriaClinicaAntecedentes] = @HistoriaClinicaAntecedentes,
            [HistoriaClinicaObservaciones] = @HistoriaClinicaObservaciones 
            where 
            [HistoriaClinicaCodigo] = @HistoriaClinicaCodigo
go

-- Crear  sp Eliminar Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaEliminarRegistro
    (
    @HistoriaClinicaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.HistoriaClinica
            set
            HistoriaClinicaEstado = 'E'
            where 
            [HistoriaClinicaCodigo] = @HistoriaClinicaCodigo
go

-- Crear  sp Recuperar Historia Clinica
Create or alter procedure Atenciones.spHistoriaClinicaRecuperarRegistro
    (
    @HistoriaClinicaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.HistoriaClinica
            set
            HistoriaClinicaEstado = 'A'
            where 
            [HistoriaClinicaCodigo] = @HistoriaClinicaCodigo
go

--=====================================================================
--                      SP Tabla Medicamentos
--=====================================================================

-- Crear sp listado sin borrados Medicamentos
Create or alter procedure Atenciones.spMedicamentosListaSinBorrados
    with encryption 
    As 
        select 
            [MedicamentosCodigo], [DistribuidorasCodigo], [MedicamentosNombre], [MedicamentosPresentacion], [MedicamentosStock], [MedicamentosPrecio], [MedicamentosFechaVencimiento], [MedicamentosDescripcion], [MedicamentosEstado]
            from Atenciones.Medicamentos As M
            where M.MedicamentosEstado = 'A'
go

-- Crear sp listado borrados Medicamentos
Create or alter procedure Atenciones.spMedicamentosListaBorrados
    with encryption 
    As 
        select 
            [MedicamentosCodigo], [DistribuidorasCodigo], [MedicamentosNombre], [MedicamentosPresentacion], [MedicamentosStock], [MedicamentosPrecio], [MedicamentosFechaVencimiento], [MedicamentosDescripcion], [MedicamentosEstado]
            from Atenciones.Medicamentos As M
            where M.MedicamentosEstado = 'E'
go

-- Crear  sp Inserción Medicamentos
Create or alter procedure Atenciones.spMedicamentosInsertarRegistro
    (
    @MedicamentosCodigo nchar(7),
    @DistribuidorasCodigo nchar(7),
    @MedicamentosNombre nvarchar(100),
    @MedicamentosPresentacion nvarchar(100),
    @MedicamentosStock numeric(6,0),
    @MedicamentosPrecio numeric(10,2),
    @MedicamentosFechaVencimiento date,
    @MedicamentosDescripcion nvarchar(250),
    @MedicamentosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Medicamentos
            ([MedicamentosCodigo], [DistribuidorasCodigo], [MedicamentosNombre], [MedicamentosPresentacion], [MedicamentosStock], [MedicamentosPrecio], [MedicamentosFechaVencimiento], [MedicamentosDescripcion], [MedicamentosEstado])
            values 
            (@MedicamentosCodigo, @DistribuidorasCodigo, @MedicamentosNombre, @MedicamentosPresentacion, @MedicamentosStock, @MedicamentosPrecio, @MedicamentosFechaVencimiento, @MedicamentosDescripcion, @MedicamentosEstado)
go

-- Crear  sp Modificación Medicamentos
Create or alter procedure Atenciones.spMedicamentosEditarRegistro
    (
    @MedicamentosCodigo nchar(7),
    @DistribuidorasCodigo nchar(7),
    @MedicamentosNombre nvarchar(100),
    @MedicamentosPresentacion nvarchar(100),
    @MedicamentosStock numeric(6,0),
    @MedicamentosPrecio numeric(10,2),
    @MedicamentosFechaVencimiento date,
    @MedicamentosDescripcion nvarchar(250)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicamentos
            set
            [DistribuidorasCodigo] = @DistribuidorasCodigo,
            [MedicamentosNombre] = @MedicamentosNombre,
            [MedicamentosPresentacion] = @MedicamentosPresentacion, 
            [MedicamentosStock] = @MedicamentosStock, 
            [MedicamentosPrecio] = @MedicamentosPrecio, 
            [MedicamentosFechaVencimiento] = @MedicamentosFechaVencimiento, 
            [MedicamentosDescripcion] = @MedicamentosDescripcion 
            where 
            [MedicamentosCodigo] = @MedicamentosCodigo
go

-- Crear  sp Eliminar Medicamentos
Create or alter procedure Atenciones.spMedicamentosEliminarRegistro
    (
    @MedicamentosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicamentos
            set
            MedicamentosEstado = 'E'
            where 
            [MedicamentosCodigo] = @MedicamentosCodigo
go

-- Crear  sp Recuperar Medicamentos
Create or alter procedure Atenciones.spMedicamentosRecuperarRegistro
    (
    @MedicamentosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicamentos
            set
            MedicamentosEstado = 'A'
            where 
            [MedicamentosCodigo] = @MedicamentosCodigo
go

--=====================================================================
--                      SP Tabla Medicos
--=====================================================================

-- Crear sp listado sin borrados Medicos
Create or alter procedure Atenciones.spMedicosListaSinBorrados
    with encryption 
    As 
        select 
            [MedicosCodigo], [MedicosNombres], [MedicosApellidos], [MedicosCMP], [MedicosTelefono], [MedicosCorreo], [EspecialidadesCodigo], [ConsultoriosCodigo], [MedicosEstado]
            from Atenciones.Medicos As M
            where M.MedicosEstado = 'A'
go

-- Crear sp listado borrados Medicos
Create or alter procedure Atenciones.spMedicosListaBorrados
    with encryption 
    As 
        select 
            [MedicosCodigo], [MedicosNombres], [MedicosApellidos], [MedicosCMP], [MedicosTelefono], [MedicosCorreo], [EspecialidadesCodigo], [ConsultoriosCodigo], [MedicosEstado]
            from Atenciones.Medicos As M
            where M.MedicosEstado = 'E'
go

-- Crear  sp Inserción Medicos
Create or alter procedure Atenciones.spMedicosInsertarRegistro
    (
    @MedicosCodigo nchar(7), 
    @MedicosNombres nvarchar(100),
    @MedicosApellidos nvarchar(100),
    @MedicosCMP nchar(10),
    @MedicosTelefono nchar(9),
    @MedicosCorreo nvarchar(100),
    @EspecialidadesCodigo nchar(7),
    @ConsultoriosCodigo nchar(7),
    @MedicosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Medicos
            ([MedicosCodigo], [MedicosNombres], [MedicosApellidos], [MedicosCMP], [MedicosTelefono], [MedicosCorreo], [EspecialidadesCodigo], [ConsultoriosCodigo], [MedicosEstado])
            values 
            (@MedicosCodigo, @MedicosNombres, @MedicosApellidos, @MedicosCMP, @MedicosTelefono, @MedicosCorreo, @EspecialidadesCodigo, @ConsultoriosCodigo, @MedicosEstado)
go

-- Crear  sp Modificación Medicos
Create or alter procedure Atenciones.spMedicosEditarRegistro
    (
    @MedicosCodigo nchar(7), 
    @MedicosNombres nvarchar(100),
    @MedicosApellidos nvarchar(100),
    @MedicosCMP nchar(10),
    @MedicosTelefono nchar(9),
    @MedicosCorreo nvarchar(100),
    @EspecialidadesCodigo nchar(7),
    @ConsultoriosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicos
            set
            [MedicosNombres] = @MedicosNombres,
            [MedicosApellidos] = @MedicosApellidos,
            [MedicosCMP] = @MedicosCMP,
            [MedicosTelefono] = @MedicosTelefono,
            [MedicosCorreo] = @MedicosCorreo,
            [EspecialidadesCodigo] = @EspecialidadesCodigo,
            [ConsultoriosCodigo] = @ConsultoriosCodigo
            where 
            [MedicosCodigo] = @MedicosCodigo
go

-- Crear  sp Eliminar Medicos
Create or alter procedure Atenciones.spMedicosEliminarRegistro
    (
    @MedicosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicos
            set
            MedicosEstado = 'E'
            where 
            [MedicosCodigo] = @MedicosCodigo
go

-- Crear  sp Recuperar Medicos
Create or alter procedure Atenciones.spMedicosRecuperarRegistro
    (
    @MedicosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Medicos
            set
            MedicosEstado = 'A'
            where 
            [MedicosCodigo] = @MedicosCodigo
go

--=====================================================================
--                      SP Tabla Pacientes
--=====================================================================

-- Crear sp listado sin borrados Pacientes
Create or alter procedure Atenciones.spPacientesListaSinBorrados
    with encryption 
    As 
        select 
            [PacientesCodigo], [PacientesDNI], [PacientesNombres], [PacientesApellidos], [PacientesFechaNacimiento], [PacientesSexo], [PacientesTelefono], [PacientesCorreo], [PacientesDireccion], [PacientesCondiciones], [PacientesEstado]
            from Atenciones.Pacientes As P
            where P.PacientesEstado = 'A'
go

-- Crear sp listado borrados Pacientes
Create or alter procedure Atenciones.spPacientesListaBorrados
    with encryption 
    As 
        select 
            [PacientesCodigo], [PacientesDNI], [PacientesNombres], [PacientesApellidos], [PacientesFechaNacimiento], [PacientesSexo], [PacientesTelefono], [PacientesCorreo], [PacientesDireccion], [PacientesCondiciones], [PacientesEstado]
            from Atenciones.Pacientes As P
            where P.PacientesEstado = 'E'
go

-- Crear  sp Inserción Pacientes
Create or alter procedure Atenciones.spPacientesInsertarRegistro
    (
    @PacientesCodigo nchar(7), 
    @PacientesDNI nchar(8),
    @PacientesNombres nvarchar(100),
    @PacientesApellidos nvarchar(100),
    @PacientesFechaNacimiento date,
    @PacientesSexo nchar(1),
    @PacientesTelefono nchar(9),
    @PacientesCorreo nvarchar(100),
    @PacientesDireccion nvarchar(200),
    @PacientesCondiciones nvarchar(300),
    @PacientesEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Pacientes
            ([PacientesCodigo], [PacientesDNI], [PacientesNombres], [PacientesApellidos], [PacientesFechaNacimiento], [PacientesSexo], [PacientesTelefono], [PacientesCorreo], [PacientesDireccion], [PacientesCondiciones], [PacientesEstado])
            values 
            (@PacientesCodigo, @PacientesDNI, @PacientesNombres, @PacientesApellidos, @PacientesFechaNacimiento, @PacientesSexo, @PacientesTelefono, @PacientesCorreo, @PacientesDireccion, @PacientesCondiciones, @PacientesEstado)
go

-- Crear  sp Modificación Pacientes
Create or alter procedure Atenciones.spPacientesEditarRegistro
    (
    @PacientesCodigo nchar(7), 
    @PacientesDNI nchar(8),
    @PacientesNombres nvarchar(100),
    @PacientesApellidos nvarchar(100),
    @PacientesFechaNacimiento date,
    @PacientesSexo nchar(1),
    @PacientesTelefono nchar(9),
    @PacientesCorreo nvarchar(100),
    @PacientesDireccion nvarchar(200),
    @PacientesCondiciones nvarchar(300)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Pacientes
            set
            [PacientesDNI] = @PacientesDNI,
            [PacientesNombres] = @PacientesNombres ,
            [PacientesApellidos] = @PacientesApellidos ,
            [PacientesFechaNacimiento] = @PacientesFechaNacimiento ,
            [PacientesSexo] = @PacientesSexo,
            [PacientesTelefono] = @PacientesTelefono ,
            [PacientesCorreo] = @PacientesCorreo ,
            [PacientesDireccion] = @PacientesDireccion ,
            [PacientesCondiciones] = @PacientesCondiciones
            where 
            [PacientesCodigo] = @PacientesCodigo
go

-- Crear  sp Eliminar Pacientes
Create or alter procedure Atenciones.spPacientesEliminarRegistro
    (
    @PacientesCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Pacientes
            set
            PacientesEstado = 'E'
            where 
            [PacientesCodigo] = @PacientesCodigo
go

-- Crear  sp Recuperar Pacientes
Create or alter procedure Atenciones.spPacientesRecuperarRegistro
    (
    @PacientesCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Pacientes
            set
            PacientesEstado = 'A'
            where 
            [PacientesCodigo] = @PacientesCodigo
go

--=====================================================================
--                      SP Tabla Receta
--=====================================================================

-- Crear sp listado sin borrados Receta
Create or alter procedure Atenciones.spRecetaListaSinBorrados
    with encryption 
    As 
        select 
            [RecetaCodigo], [HistoriaClinicaCodigo], [MedicosCodigo], [RecetaCategoriasCodigo], [RecetaFecha], [RecetaDiagnostico], [RecetaIndicaciones], [RecetaObservaciones], [RecetaEstado]
            from Atenciones.Receta As R
            where R.RecetaEstado = 'A'
go

-- Crear sp listado borrados Receta
Create or alter procedure Atenciones.spRecetaListaBorrados
    with encryption 
    As 
        select 
            [RecetaCodigo], [HistoriaClinicaCodigo], [MedicosCodigo], [RecetaCategoriasCodigo], [RecetaFecha], [RecetaDiagnostico], [RecetaIndicaciones], [RecetaObservaciones], [RecetaEstado]
            from Atenciones.Receta As R
            where R.RecetaEstado = 'E'
go

-- Crear  sp Inserción Receta
Create or alter procedure Atenciones.spRecetaInsertarRegistro
    (
    @RecetaCodigo nchar(7),
    @HistoriaClinicaCodigo nchar(7), 
    @MedicosCodigo nchar(7),
    @RecetaCategoriasCodigo nchar(7), 
    @RecetaFecha date,
    @RecetaDiagnostico nvarchar(300), 
    @RecetaIndicaciones nvarchar(500),
    @RecetaObservaciones nvarchar(500),
    @RecetaEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.Receta
            ([RecetaCodigo], [HistoriaClinicaCodigo], [MedicosCodigo], [RecetaCategoriasCodigo], [RecetaFecha], [RecetaDiagnostico], [RecetaIndicaciones], [RecetaObservaciones], [RecetaEstado])
            values 
            (@RecetaCodigo, @HistoriaClinicaCodigo, @MedicosCodigo, @RecetaCategoriasCodigo, @RecetaFecha, @RecetaDiagnostico, @RecetaIndicaciones, @RecetaObservaciones, @RecetaEstado)
go

-- Crear  sp Modificación Receta
Create or alter procedure Atenciones.spRecetaEditarRegistro
    (
    @RecetaCodigo nchar(7),
    @HistoriaClinicaCodigo nchar(7), 
    @MedicosCodigo nchar(7),
    @RecetaCategoriasCodigo nchar(7), 
    @RecetaFecha date,
    @RecetaDiagnostico nvarchar(300), 
    @RecetaIndicaciones nvarchar(500),
    @RecetaObservaciones nvarchar(500)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Receta
            set
            [HistoriaClinicaCodigo] = @HistoriaClinicaCodigo , 
            [MedicosCodigo] = @MedicosCodigo ,
            [RecetaCategoriasCodigo] = @RecetaCategoriasCodigo , 
            [RecetaFecha] = @RecetaFecha ,
            [RecetaDiagnostico] = @RecetaDiagnostico ,
            [RecetaIndicaciones] = @RecetaIndicaciones ,
            [RecetaObservaciones] = @RecetaObservaciones 
            where 
            [RecetaCodigo] = @RecetaCodigo
go

-- Crear  sp Eliminar Receta
Create or alter procedure Atenciones.spRecetaEliminarRegistro
    (
    @RecetaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Receta
            set
            RecetaEstado = 'E'
            where 
            [RecetaCodigo] = @RecetaCodigo
go

-- Crear  sp Recuperar Receta
Create or alter procedure Atenciones.spRecetaRecuperarRegistro
    (
    @RecetaCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.Receta
            set
            RecetaEstado = 'A'
            where 
            [RecetaCodigo] = @RecetaCodigo
go

--=====================================================================
--                      SP Tabla Receta Categorias
--=====================================================================

-- Crear sp listado sin borrados Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasListaSinBorrados
    with encryption 
    As 
        select 
            [RecetaCategoriasCodigo], [RecetaCategoriasNombre], [RecetaCategoriasDescripcion], [RecetaCategoriasEstado]
            from Atenciones.RecetaCategorias As R
            where R.RecetaCategoriasEstado = 'A'
go

-- Crear sp listado borrados Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasListaBorrados
    with encryption 
    As 
        select 
            [RecetaCategoriasCodigo], [RecetaCategoriasNombre], [RecetaCategoriasDescripcion], [RecetaCategoriasEstado]
            from Atenciones.RecetaCategorias As R
            where R.RecetaCategoriasEstado = 'E'
go

-- Crear  sp Inserción Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasInsertarRegistro
    (
    @RecetaCategoriasCodigo nchar(7),
    @RecetaCategoriasNombre nvarchar(100),
    @RecetaCategoriasDescripcion nvarchar(250),
    @RecetaCategoriasEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.RecetaCategorias
            ([RecetaCategoriasCodigo], [RecetaCategoriasNombre], [RecetaCategoriasDescripcion], [RecetaCategoriasEstado])
            values 
            (@RecetaCategoriasCodigo, @RecetaCategoriasNombre, @RecetaCategoriasDescripcion, @RecetaCategoriasEstado)
go

-- Crear  sp Modificación Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasEditarRegistro
    (
    @RecetaCategoriasCodigo nchar(7),
    @RecetaCategoriasNombre nvarchar(100),
    @RecetaCategoriasDescripcion nvarchar(250)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaCategorias
            set
            [RecetaCategoriasNombre] = @RecetaCategoriasNombre,
            [RecetaCategoriasDescripcion] = @RecetaCategoriasDescripcion 
            where 
            [RecetaCategoriasCodigo] = @RecetaCategoriasCodigo
go

-- Crear  sp Eliminar Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasEliminarRegistro
    (
    @RecetaCategoriasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaCategorias
            set
            RecetaCategoriasEstado = 'E'
            where 
            [RecetaCategoriasCodigo] = @RecetaCategoriasCodigo
go

-- Crear  sp Recuperar Receta Categorias
Create or alter procedure Atenciones.spRecetaCategoriasRecuperarRegistro
    (
    @RecetaCategoriasCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaCategorias
            set
            RecetaCategoriasEstado = 'A'
            where 
            [RecetaCategoriasCodigo] = @RecetaCategoriasCodigo
go

--=====================================================================
--                      SP Tabla Receta Laboratorios
--=====================================================================

-- Crear sp listado sin borrados Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosListaSinBorrados
    with encryption 
    As 
        select 
            [RecetaLaboratoriosCodigo], [RecetaCodigo], [RecetaLaboratoriosExamen], [RecetaLaboratoriosResultado], [RecetaLaboratoriosFecha], [RecetaLaboratoriosObservaciones], [RecetaLaboratoriosEstado]
            from Atenciones.RecetaLaboratorios As R
            where R.RecetaLaboratoriosEstado = 'A'
go

-- Crear sp listado borrados Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosListaBorrados
    with encryption 
    As 
        select 
            [RecetaLaboratoriosCodigo], [RecetaCodigo], [RecetaLaboratoriosExamen], [RecetaLaboratoriosResultado], [RecetaLaboratoriosFecha], [RecetaLaboratoriosObservaciones], [RecetaLaboratoriosEstado]
            from Atenciones.RecetaLaboratorios As R
            where R.RecetaLaboratoriosEstado = 'E'
go

-- Crear  sp Inserción Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosInsertarRegistro
    (
    @RecetaLaboratoriosCodigo nchar(7),
    @RecetaCodigo nchar(7),
    @RecetaLaboratoriosExamen nvarchar(150), 
    @RecetaLaboratoriosResultado nvarchar(300),
    @RecetaLaboratoriosFecha date,
    @RecetaLaboratoriosObservaciones nvarchar(300), 
    @RecetaLaboratoriosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Atenciones.RecetaLaboratorios
            ([RecetaLaboratoriosCodigo], [RecetaCodigo], [RecetaLaboratoriosExamen], [RecetaLaboratoriosResultado], [RecetaLaboratoriosFecha], [RecetaLaboratoriosObservaciones], [RecetaLaboratoriosEstado])
            values 
            (@RecetaLaboratoriosCodigo, @RecetaCodigo, @RecetaLaboratoriosExamen, @RecetaLaboratoriosResultado, @RecetaLaboratoriosFecha, @RecetaLaboratoriosObservaciones, @RecetaLaboratoriosEstado)
go

-- Crear  sp Modificación Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosEditarRegistro
    (
    @RecetaLaboratoriosCodigo nchar(7),
    @RecetaCodigo nchar(7),
    @RecetaLaboratoriosExamen nvarchar(150), 
    @RecetaLaboratoriosResultado nvarchar(300),
    @RecetaLaboratoriosFecha date,
    @RecetaLaboratoriosObservaciones nvarchar(300)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaLaboratorios
            set
            [RecetaCodigo] = @RecetaCodigo,
            [RecetaLaboratoriosExamen] = @RecetaLaboratoriosExamen , 
            [RecetaLaboratoriosResultado] = @RecetaLaboratoriosResultado ,
            [RecetaLaboratoriosFecha] = @RecetaLaboratoriosFecha ,
            [RecetaLaboratoriosObservaciones] = @RecetaLaboratoriosObservaciones 
            where 
            [RecetaLaboratoriosCodigo] = @RecetaLaboratoriosCodigo
go

-- Crear  sp Eliminar Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosEliminarRegistro
    (
    @RecetaLaboratoriosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaLaboratorios
            set
            RecetaLaboratoriosEstado = 'E'
            where 
            [RecetaLaboratoriosCodigo] = @RecetaLaboratoriosCodigo
go

-- Crear  sp Recuperar Receta Laboratorios
Create or alter procedure Atenciones.spRecetaLaboratoriosRecuperarRegistro
    (
    @RecetaLaboratoriosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Atenciones.RecetaLaboratorios
            set
            RecetaLaboratoriosEstado = 'A'
            where 
            [RecetaLaboratoriosCodigo] = @RecetaLaboratoriosCodigo
go

--=====================================================================
--                      SP Tabla Usuarios
--=====================================================================

-- Crear sp listado sin borrados Usuarios
Create or alter procedure Seguridad.spUsuariosListaSinBorrados
    with encryption 
    As 
        select 
            [UsuariosCodigo], [UsuariosNombre], [UsuariosClave], [UsuariosRol], [UsuariosUltimoAcceso], [UsuariosEstado]
            from Seguridad.Usuarios As U
            where U.UsuariosEstado = 'A'
go

-- Crear sp listado borrados Usuarios
Create or alter procedure Seguridad.spUsuariosListaBorrados
    with encryption 
    As 
        select 
            [UsuariosCodigo], [UsuariosNombre], [UsuariosClave], [UsuariosRol], [UsuariosUltimoAcceso], [UsuariosEstado]
            from Seguridad.Usuarios As U
            where U.UsuariosEstado = 'E'
go

-- Crear  sp Inserción Usuarios
Create or alter procedure Seguridad.spUsuariosInsertarRegistro
    (
    @UsuariosCodigo nchar(7),
    @UsuariosNombre nvarchar(50),
    @UsuariosClave nvarchar(50),
    @UsuariosRol nvarchar(30),
    @UsuariosUltimoAcceso datetime,
    @UsuariosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Seguridad.Usuarios
            ([UsuariosCodigo], [UsuariosNombre], [UsuariosClave], [UsuariosRol], [UsuariosUltimoAcceso], [UsuariosEstado])
            values 
            (@UsuariosCodigo, @UsuariosNombre, @UsuariosClave, @UsuariosRol, @UsuariosUltimoAcceso, @UsuariosEstado)
go

-- Crear  sp Modificación Usuarios
Create or alter procedure Seguridad.spUsuariosEditarRegistro
    (
    @UsuariosCodigo nchar(7),
    @UsuariosNombre nvarchar(50),
    @UsuariosClave nvarchar(50),
    @UsuariosRol nvarchar(30),
    @UsuariosUltimoAcceso datetime
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.Usuarios
            set
            [UsuariosNombre] = @UsuariosNombre ,
            [UsuariosClave] = @UsuariosClave ,
            [UsuariosRol] = @UsuariosRol ,
            [UsuariosUltimoAcceso] = @UsuariosUltimoAcceso
            where 
            [UsuariosCodigo] = @UsuariosCodigo
go

-- Crear  sp Eliminar Usuarios
Create or alter procedure Seguridad.spUsuariosEliminarRegistro
    (
    @UsuariosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.Usuarios
            set
            UsuariosEstado = 'E'
            where 
            [UsuariosCodigo] = @UsuariosCodigo
go

-- Crear  sp Recuperar Usuarios
Create or alter procedure Seguridad.spUsuariosRecuperarRegistro
    (
    @UsuariosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.Usuarios
            set
            UsuariosEstado = 'A'
            where 
            [UsuariosCodigo] = @UsuariosCodigo
go

--=====================================================================
--                      SP Tabla Usuarios Empleados
--=====================================================================

-- Crear sp listado sin borrados Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosListaSinBorrados
    with encryption 
    As 
        select 
            [UsuariosEmpleadosCodigo], [UsuariosCodigo], [EmpleadosCodigo], [UsuariosEmpleadosEstado]
            from Seguridad.UsuariosEmpleados As U
            where U.UsuariosEmpleadosEstado = 'A'
go

-- Crear sp listado borrados Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosListaBorrados
    with encryption 
    As 
        select 
            [UsuariosEmpleadosCodigo], [UsuariosCodigo], [EmpleadosCodigo], [UsuariosEmpleadosEstado] 
            from Seguridad.UsuariosEmpleados As U
            where U.UsuariosEmpleadosEstado = 'E'
go

-- Crear  sp Inserción Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosInsertarRegistro
    (
    @UsuariosEmpleadosCodigo nchar(7), 
    @UsuariosCodigo nchar(7),
    @EmpleadosCodigo nchar(7),
    @UsuariosEmpleadosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Seguridad.UsuariosEmpleados
            ([UsuariosEmpleadosCodigo], [UsuariosCodigo], [EmpleadosCodigo], [UsuariosEmpleadosEstado])
            values 
            (@UsuariosEmpleadosCodigo, @UsuariosCodigo, @EmpleadosCodigo, @UsuariosEmpleadosEstado)
go

-- Crear  sp Modificación Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosEditarRegistro
    (
    @UsuariosEmpleadosCodigo nchar(7), 
    @UsuariosCodigo nchar(7),
    @EmpleadosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosEmpleados
            set
            [UsuariosCodigo] = @UsuariosCodigo ,
            [EmpleadosCodigo] = @EmpleadosCodigo 
            where 
            [UsuariosEmpleadosCodigo] = @UsuariosEmpleadosCodigo
go

-- Crear  sp Eliminar Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosEliminarRegistro
    (
    @UsuariosEmpleadosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosEmpleados
            set
            UsuariosEmpleadosEstado = 'E'
            where 
            [UsuariosEmpleadosCodigo] = @UsuariosEmpleadosCodigo
go

-- Crear  sp Recuperar Usuarios Empleados
Create or alter procedure Seguridad.spUsuariosEmpleadosRecuperarRegistro
    (
    @UsuariosEmpleadosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosEmpleados
            set
            UsuariosEmpleadosEstado = 'A'
            where 
            [UsuariosEmpleadosCodigo] = @UsuariosEmpleadosCodigo
go

--=====================================================================
--                      SP Tabla Usuarios Medicos
--=====================================================================

-- Crear sp listado sin borrados Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosListaSinBorrados
    with encryption 
    As 
        select 
            [UsuariosMedicosCodigo], [UsuariosCodigo], [MedicosCodigo], [UsuariosMedicosEstado]
            from Seguridad.UsuariosMedicos As U
            where U.UsuariosMedicosEstado = 'A'
go

-- Crear sp listado borrados Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosListaBorrados
    with encryption 
    As 
        select 
            [UsuariosMedicosCodigo], [UsuariosCodigo], [MedicosCodigo], [UsuariosMedicosEstado]
            from Seguridad.UsuariosMedicos As U
            where U.UsuariosMedicosEstado = 'E'
go

-- Crear  sp Inserción Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosInsertarRegistro
    (
    @UsuariosMedicosCodigo nchar(7), 
    @UsuariosCodigo nchar(7),
    @MedicosCodigo nchar(7),
    @UsuariosMedicosEstado nchar(1)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        insert into Seguridad.UsuariosMedicos
            ([UsuariosMedicosCodigo], [UsuariosCodigo], [MedicosCodigo], [UsuariosMedicosEstado])
            values 
            (@UsuariosMedicosCodigo, @UsuariosCodigo, @MedicosCodigo, @UsuariosMedicosEstado)
go

-- Crear  sp Modificación Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosEditarRegistro
    (
    @UsuariosMedicosCodigo nchar(7), 
    @UsuariosCodigo nchar(7),
    @MedicosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosMedicos
            set
            [UsuariosCodigo] = @UsuariosCodigo ,
            [MedicosCodigo] = @MedicosCodigo 
            where 
            [UsuariosMedicosCodigo] = @UsuariosMedicosCodigo
go

-- Crear  sp Eliminar Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosEliminarRegistro
    (
    @UsuariosMedicosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosMedicos
            set
            UsuariosMedicosEstado = 'E'
            where 
            [UsuariosMedicosCodigo] = @UsuariosMedicosCodigo
go

-- Crear  sp Recuperar Usuarios Medicos
Create or alter procedure Seguridad.spUsuariosMedicosRecuperarRegistro
    (
    @UsuariosMedicosCodigo nchar(7)
    )
    with encryption 
    As 
        set nocount on
        set dateformat dmy 
        update Seguridad.UsuariosMedicos
            set
            UsuariosMedicosEstado = 'A'
            where 
            [UsuariosMedicosCodigo] = @UsuariosMedicosCodigo
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Boleta Historial
--=====================================================================
Create table Atenciones.BoletaHistorial
(
    BoletaCodigo        nchar(7),
    PacientesCodigo     nchar(7),
    EmpleadosCodigo     nchar(7),
    BoletaFecha         date,
    BoletaSubtotal      numeric(10,2),
    BoletaIGV           numeric(10,2),
    BoletaTotal         numeric(10,2),
    BoletaAccion        nvarchar(20),
    BoletaEstado        nvarchar(20),
    BoletaEquipo        nvarchar(50),
    BoletaFechaHora     datetime,
    BoletaUsuario       nvarchar(50),
    BoletaAplicacion    nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thBoletasInsercion
on Atenciones.Boleta
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.BoletaHistorial
    select
        I.BoletaCodigo,        
        I.PacientesCodigo,     
        I.EmpleadosCodigo,    
        I.BoletaFecha,         
        I.BoletaSubtotal,      
        I.BoletaIGV,           
        I.BoletaTotal,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thBoletaEdicion
on Atenciones.Boleta
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.BoletaHistorial
    select
        I.BoletaCodigo,        
        I.PacientesCodigo,     
        I.EmpleadosCodigo,    
        I.BoletaFecha,         
        I.BoletaSubtotal,      
        I.BoletaIGV,           
        I.BoletaTotal,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.BoletaHistorial
    select
        D.BoletaCodigo,        
        D.PacientesCodigo,     
        D.EmpleadosCodigo,    
        D.BoletaFecha,         
        D.BoletaSubtotal,      
        D.BoletaIGV,           
        D.BoletaTotal,        
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thBoletaEliminacion
on Atenciones.Boleta
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.BoletaHistorial
    select
        D.BoletaCodigo,        
        D.PacientesCodigo,     
        D.EmpleadosCodigo,    
        D.BoletaFecha,         
        D.BoletaSubtotal,      
        D.BoletaIGV,           
        D.BoletaTotal,         
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Boleta Detalle Historial
--=====================================================================
Create table Atenciones.BoletaDetalleHistorial
(
    BoletaDetalleCodigo     nchar(7),
    BoletaCodigo            nchar(7),
    BoletaDetalleConcepto   nvarchar(150),
    BoletaDetalleCantidad   numeric(5,0),
    BoletaDetallePrecio     numeric(10,2),
    BoletaDetalleImporte    numeric(10,2),
    BoletaDetalleAccion            nvarchar(20),
    BoletaDetalleEstado            nvarchar(20),
    BoletaDetalleEquipo            nvarchar(50),
    BoletaDetalleFechaHora         datetime,
    BoletaDetalleUsuario           nvarchar(50),
    BoletaDetalleAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thBoletaDetallesInsercion
on Atenciones.BoletaDetalle
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.BoletaDetalleHistorial
    select
        I.BoletaDetalleCodigo,     
        I.BoletaCodigo,            
        I.BoletaDetalleConcepto,   
        I.BoletaDetalleCantidad,   
        I.BoletaDetallePrecio,     
        I.BoletaDetalleImporte,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thBoletaDetalleEdicion
on Atenciones.BoletaDetalle
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.BoletaDetalleHistorial
    select
        I.BoletaDetalleCodigo,     
        I.BoletaCodigo,            
        I.BoletaDetalleConcepto,   
        I.BoletaDetalleCantidad,   
        I.BoletaDetallePrecio,     
        I.BoletaDetalleImporte,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.BoletaDetalleHistorial
    select
        D.BoletaDetalleCodigo,     
        D.BoletaCodigo,            
        D.BoletaDetalleConcepto,   
        D.BoletaDetalleCantidad,   
        D.BoletaDetallePrecio,     
        D.BoletaDetalleImporte,        
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thBoletaDetalleEliminacion
on Atenciones.BoletaDetalle
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.BoletaDetalleHistorial
    select
        D.BoletaDetalleCodigo,     
        D.BoletaCodigo,            
        D.BoletaDetalleConcepto,   
        D.BoletaDetalleCantidad,   
        D.BoletaDetallePrecio,     
        D.BoletaDetalleImporte,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Citas Historial
--=====================================================================

Create table Atenciones.CitasHistorial
(
    CitasCodigo             nchar(7),
    PacientesCodigo         nchar(7),
    MedicosCodigo           nchar(7),
    ConsultoriosCodigo      nchar(7),
    CitasFecha              date,
    CitasHora               time,
    CitasMotivo             nvarchar(250),
    CitasCondiciones        nvarchar(300),
    CitasAccion            nvarchar(20),
    CitasEstado             nvarchar(20),
    CitasEquipo            nvarchar(50),
    CitasFechaHora         datetime,
    CitasUsuario           nvarchar(50),
    CitasAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thCitasInsercion
on Atenciones.Citas
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.CitasHistorial
    select
        I.CitasCodigo,             
        I.PacientesCodigo,         
        I.MedicosCodigo,          
        I.ConsultoriosCodigo,      
        I.CitasFecha,              
        I.CitasHora,               
        I.CitasMotivo,             
        I.CitasCondiciones,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thCitasEdicion
on Atenciones.Citas
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.CitasHistorial
    select
        I.CitasCodigo,             
        I.PacientesCodigo,         
        I.MedicosCodigo,          
        I.ConsultoriosCodigo,      
        I.CitasFecha,              
        I.CitasHora,               
        I.CitasMotivo,             
        I.CitasCondiciones, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.CitasHistorial
    select
        D.CitasCodigo,             
        D.PacientesCodigo,         
        D.MedicosCodigo,          
        D.ConsultoriosCodigo,      
        D.CitasFecha,              
        D.CitasHora,               
        D.CitasMotivo,             
        D.CitasCondiciones,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thCitasEliminacion
on Atenciones.Citas
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.CitasHistorial
    select
        D.CitasCodigo,             
        D.PacientesCodigo,         
        D.MedicosCodigo,          
        D.ConsultoriosCodigo,      
        D.CitasFecha,              
        D.CitasHora,               
        D.CitasMotivo,             
        D.CitasCondiciones,               
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Consultorios Historial
--=====================================================================
Create table Atenciones.ConsultoriosHistorial
(
    ConsultoriosCodigo            nchar(7),
    ConsultoriosNombre            nvarchar(100),
    ConsultoriosNumero            nchar(5),
    ConsultoriosUbicacion         nvarchar(100),
    ConsultoriosPiso              numeric(2,0),
    ConsultoriosDescripcion       nvarchar(250),
    ConsultoriosAccion            nvarchar(20),
    ConsultoriosEstado            nvarchar(20),
    ConsultoriosEquipo            nvarchar(50),
    ConsultoriosFechaHora         datetime,
    ConsultoriosUsuario           nvarchar(50),
    ConsultoriosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thConsultoriosInsercion
on Atenciones.Consultorios
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.ConsultoriosHistorial
    select
        I.ConsultoriosCodigo,      
        I.ConsultoriosNombre,      
        I.ConsultoriosNumero,      
        I.ConsultoriosUbicacion,   
        I.ConsultoriosPiso,        
        I.ConsultoriosDescripcion,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thConsultoriosEdicion
on Atenciones.Consultorios
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.ConsultoriosHistorial
    select
        I.ConsultoriosCodigo,      
        I.ConsultoriosNombre,      
        I.ConsultoriosNumero,      
        I.ConsultoriosUbicacion,   
        I.ConsultoriosPiso,        
        I.ConsultoriosDescripcion,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.ConsultoriosHistorial
    select
        D.ConsultoriosCodigo,      
        D.ConsultoriosNombre,      
        D.ConsultoriosNumero,      
        D.ConsultoriosUbicacion,   
        D.ConsultoriosPiso,        
        D.ConsultoriosDescripcion,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thConsultoriosEliminacion
on Atenciones.Consultorios
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.ConsultoriosHistorial
    select
        D.ConsultoriosCodigo,      
        D.ConsultoriosNombre,      
        D.ConsultoriosNumero,      
        D.ConsultoriosUbicacion,   
        D.ConsultoriosPiso,        
        D.ConsultoriosDescripcion,              
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Distribuidoras Historial
--=====================================================================

Create table Atenciones.DistribuidorasHistorial
(
    DistribuidorasCodigo            nchar(7),
    DistribuidorasRUC               nchar(11),
    DistribuidorasRazonSocial       nvarchar(150),
    DistribuidorasTelefono          nchar(9),
    DistribuidorasCorreo            nvarchar(100),
    DistribuidorasDireccion         nvarchar(200),
    DistribuidorasContacto          nvarchar(100),
    DistribuidorasAccion            nvarchar(20),
    DistribuidorasEstado            nvarchar(20),
    DistribuidorasEquipo            nvarchar(50),
    DistribuidorasFechaHora         datetime,
    DistribuidorasUsuario           nvarchar(50),
    DistribuidorasAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thDistribuidorasInsercion
on Atenciones.Distribuidoras
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.DistribuidorasHistorial
    select
        I.DistribuidorasCodigo, 
        I.DistribuidorasRUC,               
        I.DistribuidorasRazonSocial,       
        I.DistribuidorasTelefono,          
        I.DistribuidorasCorreo,            
        I.DistribuidorasDireccion,        
        I.DistribuidorasContacto,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thDistribuidorasEdicion
on Atenciones.Distribuidoras
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.DistribuidorasHistorial
    select
        I.DistribuidorasCodigo, 
        I.DistribuidorasRUC,               
        I.DistribuidorasRazonSocial,       
        I.DistribuidorasTelefono,          
        I.DistribuidorasCorreo,            
        I.DistribuidorasDireccion,        
        I.DistribuidorasContacto,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.DistribuidorasHistorial
    select
        D.DistribuidorasCodigo, 
        D.DistribuidorasRUC,               
        D.DistribuidorasRazonSocial,       
        D.DistribuidorasTelefono,          
        D.DistribuidorasCorreo,            
        D.DistribuidorasDireccion,        
        D.DistribuidorasContacto,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thDistribuidorasEliminacion
on Atenciones.Distribuidoras
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.DistribuidorasHistorial
    select
        D.DistribuidorasCodigo, 
        D.DistribuidorasRUC,               
        D.DistribuidorasRazonSocial,       
        D.DistribuidorasTelefono,          
        D.DistribuidorasCorreo,            
        D.DistribuidorasDireccion,        
        D.DistribuidorasContacto,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Empleados Historial
--=====================================================================

Create table Atenciones.EmpleadosHistorial
(
    EmpleadosCodigo            nchar(7),
    EmpleadosDNI               nchar(8),
    EmpleadosNombres           nvarchar(100),
    EmpleadosApellidos         nvarchar(100),
    EmpleadosCargo             nvarchar(50),
    EmpleadosTelefono          nchar(9),
    EmpleadosCorreo            nvarchar(100),
    EmpleadosDireccion         nvarchar(200),
    EmpleadosFechaIngreso      date,
    EmpleadosAccion            nvarchar(20),
    EmpleadosEstado            nvarchar(20),
    EmpleadosEquipo            nvarchar(50),
    EmpleadosFechaHora         datetime,
    EmpleadosUsuario           nvarchar(50),
    EmpleadosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thEmpleadosInsercion
on Atenciones.Empleados
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.EmpleadosHistorial
    select
        I.EmpleadosCodigo,            
        I.EmpleadosDNI,               
        I.EmpleadosNombres,           
        I.EmpleadosApellidos,         
        I.EmpleadosCargo,            
        I.EmpleadosTelefono,          
        I.EmpleadosCorreo,            
        I.EmpleadosDireccion,         
        I.EmpleadosFechaIngreso,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thEmpleadosEdicion
on Atenciones.Empleados
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.EmpleadosHistorial
    select
        I.EmpleadosCodigo,            
        I.EmpleadosDNI,               
        I.EmpleadosNombres,           
        I.EmpleadosApellidos,         
        I.EmpleadosCargo,            
        I.EmpleadosTelefono,          
        I.EmpleadosCorreo,            
        I.EmpleadosDireccion,         
        I.EmpleadosFechaIngreso, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.EmpleadosHistorial
    select
        D.EmpleadosCodigo,            
        D.EmpleadosDNI,               
        D.EmpleadosNombres,           
        D.EmpleadosApellidos,         
        D.EmpleadosCargo,            
        D.EmpleadosTelefono,          
        D.EmpleadosCorreo,            
        D.EmpleadosDireccion,         
        D.EmpleadosFechaIngreso,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thEmpleadosEliminacion
on Atenciones.Empleados
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.EmpleadosHistorial
    select
        D.EmpleadosCodigo,            
        D.EmpleadosDNI,               
        D.EmpleadosNombres,           
        D.EmpleadosApellidos,         
        D.EmpleadosCargo,            
        D.EmpleadosTelefono,          
        D.EmpleadosCorreo,            
        D.EmpleadosDireccion,         
        D.EmpleadosFechaIngreso,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Especialidades Historial
--=====================================================================
Create table Atenciones.EspecialidadesHistorial
(
    EspecialidadesCodigo            nchar(7),
    EspecialidadesNombre            nvarchar(100),
    EspecialidadesDescripcion       nvarchar(250),
    EspecialidadesAccion            nvarchar(20),
    EspecialidadesEstado            nvarchar(20),
    EspecialidadesEquipo            nvarchar(50),
    EspecialidadesFechaHora         datetime,
    EspecialidadesUsuario           nvarchar(50),
    EspecialidadesAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thEspecialidadesInsercion
on Atenciones.Especialidades
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.EspecialidadesHistorial
    select
        I.EspecialidadesCodigo,            
        I.EspecialidadesNombre,            
        I.EspecialidadesDescripcion,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thEspecialidadesEdicion
on Atenciones.Especialidades
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.EspecialidadesHistorial
    select
        I.EspecialidadesCodigo,            
        I.EspecialidadesNombre,            
        I.EspecialidadesDescripcion,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.EspecialidadesHistorial
    select
        D.EspecialidadesCodigo,            
        D.EspecialidadesNombre,            
        D.EspecialidadesDescripcion,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thEspecialidadesEliminacion
on Atenciones.Especialidades
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.EspecialidadesHistorial
    select
        D.EspecialidadesCodigo,            
        D.EspecialidadesNombre,            
        D.EspecialidadesDescripcion,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Factura Historial
--=====================================================================
Create table Atenciones.FacturaHistorial
(
    FacturaCodigo            nchar(7),
    PacientesCodigo          nchar(7),
    EmpleadosCodigo          nchar(7),
    FacturaFecha             date,
    FacturaSubtotal          numeric(10,2),
    FacturaIGV               numeric(10,2),
    FacturaTotal             numeric(10,2),
    FacturaAccion            nvarchar(20),
    FacturaEstado            nvarchar(20),
    FacturaEquipo            nvarchar(50),
    FacturaFechaHora         datetime,
    FacturaUsuario           nvarchar(50),
    FacturaAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thFacturaInsercion
on Atenciones.Factura
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.FacturaHistorial
    select
        I.FacturaCodigo,          
        I.PacientesCodigo,          
        I.EmpleadosCodigo,          
        I.FacturaFecha,            
        I.FacturaSubtotal,          
        I.FacturaIGV,               
        I.FacturaTotal,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thFacturaEdicion
on Atenciones.Factura
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.FacturaHistorial
    select
        I.FacturaCodigo,          
        I.PacientesCodigo,          
        I.EmpleadosCodigo,          
        I.FacturaFecha,            
        I.FacturaSubtotal,          
        I.FacturaIGV,               
        I.FacturaTotal, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.FacturaHistorial
    select
        D.FacturaCodigo,          
        D.PacientesCodigo,          
        D.EmpleadosCodigo,          
        D.FacturaFecha,            
        D.FacturaSubtotal,          
        D.FacturaIGV,               
        D.FacturaTotal,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thFacturaEliminacion
on Atenciones.Factura
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.FacturaHistorial
    select
        D.FacturaCodigo,          
        D.PacientesCodigo,          
        D.EmpleadosCodigo,          
        D.FacturaFecha,            
        D.FacturaSubtotal,          
        D.FacturaIGV,               
        D.FacturaTotal,                  
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Factura Detalle Historial
--=====================================================================

Create table Atenciones.FacturaDetalleHistorial
(
    FacturaDetalleCodigo            nchar(7),
    FacturaCodigo                   nchar(7),
    FacturaDetalleConcepto          nvarchar(150),
    FacturaDetalleCantidad          numeric(5,0),
    FacturaDetallePrecio            numeric(10,2),
    FacturaDetalleImporte           numeric(10,2),
    FacturaDetalleAccion            nvarchar(20),
    FacturaDetalleEstado            nvarchar(20),
    FacturaDetalleEquipo            nvarchar(50),
    FacturaDetalleFechaHora         datetime,
    FacturaDetalleUsuario           nvarchar(50),
    FacturaDetalleAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thFacturaDetalleInsercion
on Atenciones.FacturaDetalle
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.FacturaDetalleHistorial
    select
        I.FacturaDetalleCodigo,            
        I.FacturaCodigo,                   
        I.FacturaDetalleConcepto,          
        I.FacturaDetalleCantidad,          
        I.FacturaDetallePrecio,            
        I.FacturaDetalleImporte,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thFacturaDetalleEdicion
on Atenciones.FacturaDetalle
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.FacturaDetalleHistorial
    select
        I.FacturaDetalleCodigo,            
        I.FacturaCodigo,                   
        I.FacturaDetalleConcepto,          
        I.FacturaDetalleCantidad,          
        I.FacturaDetallePrecio,            
        I.FacturaDetalleImporte, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.FacturaDetalleHistorial
    select
        D.FacturaDetalleCodigo,            
        D.FacturaCodigo,                   
        D.FacturaDetalleConcepto,          
        D.FacturaDetalleCantidad,          
        D.FacturaDetallePrecio,            
        D.FacturaDetalleImporte,        
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thFacturaDetalleEliminacion
on Atenciones.FacturaDetalle
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.FacturaDetalleHistorial
    select
        D.FacturaDetalleCodigo,            
        D.FacturaCodigo,                   
        D.FacturaDetalleConcepto,          
        D.FacturaDetalleCantidad,          
        D.FacturaDetallePrecio,            
        D.FacturaDetalleImporte,                   
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Farmacia Historial
--=====================================================================
Create table Atenciones.FarmaciaHistorial
(
    FarmaciaCodigo            nchar(7),
    RecetaCodigo              nchar(7),
    MedicamentosCodigo        nchar(7),
    FarmaciaCantidad          numeric(5,0),
    FarmaciaDosis             nvarchar(100),
    FarmaciaFrecuencia        nvarchar(100),
    FarmaciaDuracion          nvarchar(100),
    FarmaciaObservaciones     nvarchar(250),
    FarmaciaAccion            nvarchar(20),
    FarmaciaEstado            nvarchar(20),
    FarmaciaEquipo            nvarchar(50),
    FarmaciaFechaHora         datetime,
    FarmaciaUsuario           nvarchar(50),
    FarmaciaAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thFarmaciaInsercion
on Atenciones.Farmacia
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.FarmaciaHistorial
    select
        I.FarmaciaCodigo,            
        I.RecetaCodigo,              
        I.MedicamentosCodigo,        
        I.FarmaciaCantidad,          
        I.FarmaciaDosis,             
        I.FarmaciaFrecuencia,        
        I.FarmaciaDuracion,          
        I.FarmaciaObservaciones,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thFarmaciaEdicion
on Atenciones.Farmacia
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.FarmaciaHistorial
    select
        I.FarmaciaCodigo,            
        I.RecetaCodigo,              
        I.MedicamentosCodigo,        
        I.FarmaciaCantidad,          
        I.FarmaciaDosis,             
        I.FarmaciaFrecuencia,        
        I.FarmaciaDuracion,          
        I.FarmaciaObservaciones, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.FarmaciaHistorial
    select
        D.FarmaciaCodigo,            
        D.RecetaCodigo,              
        D.MedicamentosCodigo,        
        D.FarmaciaCantidad,          
        D.FarmaciaDosis,             
        D.FarmaciaFrecuencia,        
        D.FarmaciaDuracion,          
        D.FarmaciaObservaciones,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thFarmaciaEliminacion
on Atenciones.Farmacia
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.FarmaciaHistorial
    select
        D.FarmaciaCodigo,            
        D.RecetaCodigo,              
        D.MedicamentosCodigo,        
        D.FarmaciaCantidad,          
        D.FarmaciaDosis,             
        D.FarmaciaFrecuencia,        
        D.FarmaciaDuracion,          
        D.FarmaciaObservaciones,                    
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Historia Clinica Historial
--=====================================================================
Create table Atenciones.HistoriaClinicaHistorial
(
    HistoriaClinicaCodigo            nchar(7),
    PacientesCodigo                  nchar(7),
    HistoriaClinicaFechaApertura     date,
    HistoriaClinicaGrupoSanguineo    nvarchar(5),
    HistoriaClinicaAlergias          nvarchar(250),
    HistoriaClinicaAntecedentes      nvarchar(500),
    HistoriaClinicaObservaciones     nvarchar(500),
    HistoriaClinicaAccion            nvarchar(20),
    HistoriaClinicaEstado            nvarchar(20),
    HistoriaClinicaEquipo            nvarchar(50),
    HistoriaClinicaFechaHora         datetime,
    HistoriaClinicaUsuario           nvarchar(50),
    HistoriaClinicaAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thHistoriaClinicaInsercion
on Atenciones.HistoriaClinica
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.HistoriaClinicaHistorial
    select
        I.HistoriaClinicaCodigo,            
        I.PacientesCodigo,                  
        I.HistoriaClinicaFechaApertura,     
        I.HistoriaClinicaGrupoSanguineo,    
        I.HistoriaClinicaAlergias,          
        I.HistoriaClinicaAntecedentes,      
        I.HistoriaClinicaObservaciones,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thHistoriaClinicaEdicion
on Atenciones.HistoriaClinica
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.HistoriaClinicaHistorial
    select
        I.HistoriaClinicaCodigo,            
        I.PacientesCodigo,                  
        I.HistoriaClinicaFechaApertura,     
        I.HistoriaClinicaGrupoSanguineo,    
        I.HistoriaClinicaAlergias,          
        I.HistoriaClinicaAntecedentes,      
        I.HistoriaClinicaObservaciones, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.HistoriaClinicaHistorial
    select
        D.HistoriaClinicaCodigo,            
        D.PacientesCodigo,                  
        D.HistoriaClinicaFechaApertura,     
        D.HistoriaClinicaGrupoSanguineo,    
        D.HistoriaClinicaAlergias,          
        D.HistoriaClinicaAntecedentes,      
        D.HistoriaClinicaObservaciones,        
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thHistoriaClinicaEliminacion
on Atenciones.HistoriaClinica
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.HistoriaClinicaHistorial
    select
        D.HistoriaClinicaCodigo,            
        D.PacientesCodigo,                  
        D.HistoriaClinicaFechaApertura,     
        D.HistoriaClinicaGrupoSanguineo,    
        D.HistoriaClinicaAlergias,          
        D.HistoriaClinicaAntecedentes,      
        D.HistoriaClinicaObservaciones,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Medicamentos Historial
--=====================================================================
Create table Atenciones.MedicamentosHistorial
(
    MedicamentosCodigo            nchar(7),
    DistribuidorasCodigo          nchar(7),
    MedicamentosNombre            nvarchar(100),
    MedicamentosPresentacion      nvarchar(100),
    MedicamentosStock             numeric(6,0),
    MedicamentosPrecio            numeric(10,2),
    MedicamentosFechaVencimiento  date,
    MedicamentosDescripcion       nvarchar(250),
    MedicamentosAccion            nvarchar(20),
    MedicamentosEstado            nvarchar(20),
    MedicamentosEquipo            nvarchar(50),
    MedicamentosFechaHora         datetime,
    MedicamentosUsuario           nvarchar(50),
    MedicamentosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thMedicamentosInsercion
on Atenciones.Medicamentos
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.MedicamentosHistorial
    select
        I.MedicamentosCodigo,            
        I.DistribuidorasCodigo,          
        I.MedicamentosNombre,            
        I.MedicamentosPresentacion,      
        I.MedicamentosStock,             
        I.MedicamentosPrecio,            
        I.MedicamentosFechaVencimiento,  
        I.MedicamentosDescripcion,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thMedicamentosEdicion
on Atenciones.Medicamentos
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.MedicamentosHistorial
    select
        I.MedicamentosCodigo,            
        I.DistribuidorasCodigo,          
        I.MedicamentosNombre,            
        I.MedicamentosPresentacion,      
        I.MedicamentosStock,             
        I.MedicamentosPrecio,            
        I.MedicamentosFechaVencimiento,  
        I.MedicamentosDescripcion, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.MedicamentosHistorial
    select
        D.MedicamentosCodigo,            
        D.DistribuidorasCodigo,          
        D.MedicamentosNombre,            
        D.MedicamentosPresentacion,      
        D.MedicamentosStock,             
        D.MedicamentosPrecio,            
        D.MedicamentosFechaVencimiento,  
        D.MedicamentosDescripcion,        
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thMedicamentosEliminacion
on Atenciones.Medicamentos
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.MedicamentosHistorial
    select
        D.MedicamentosCodigo,            
        D.DistribuidorasCodigo,          
        D.MedicamentosNombre,            
        D.MedicamentosPresentacion,      
        D.MedicamentosStock,             
        D.MedicamentosPrecio,            
        D.MedicamentosFechaVencimiento,  
        D.MedicamentosDescripcion,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Medicos Historial
--=====================================================================
Create table Atenciones.MedicosHistorial
(
    MedicosCodigo            nchar(7),
    MedicosNombres           nvarchar(100),
    MedicosApellidos         nvarchar(100),
    MedicosCMP               nchar(10),
    MedicosTelefono          nchar(9),
    MedicosCorreo            nvarchar(100),
    EspecialidadesCodigo     nchar(7),
    ConsultoriosCodigo       nchar(7),
    MedicosAccion            nvarchar(20),
    MedicosEstado            nvarchar(20),
    MedicosEquipo            nvarchar(50),
    MedicosFechaHora         datetime,
    MedicosUsuario           nvarchar(50),
    MedicosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thMedicosInsercion
on Atenciones.Medicos
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.MedicosHistorial
    select
        I.MedicosCodigo,            
        I.MedicosNombres,           
        I.MedicosApellidos,         
        I.MedicosCMP,               
        I.MedicosTelefono,          
        I.MedicosCorreo,            
        I.EspecialidadesCodigo,     
        I.ConsultoriosCodigo,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thMedicosEdicion
on Atenciones.Medicos
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.MedicosHistorial
    select
        I.MedicosCodigo,            
        I.MedicosNombres,           
        I.MedicosApellidos,         
        I.MedicosCMP,               
        I.MedicosTelefono,          
        I.MedicosCorreo,            
        I.EspecialidadesCodigo,     
        I.ConsultoriosCodigo, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.MedicosHistorial
    select
        D.MedicosCodigo,            
        D.MedicosNombres,           
        D.MedicosApellidos,         
        D.MedicosCMP,               
        D.MedicosTelefono,          
        D.MedicosCorreo,            
        D.EspecialidadesCodigo,     
        D.ConsultoriosCodigo,         
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thMedicosEliminacion
on Atenciones.Medicos
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.MedicosHistorial
    select
        D.MedicosCodigo,            
        D.MedicosNombres,           
        D.MedicosApellidos,         
        D.MedicosCMP,               
        D.MedicosTelefono,          
        D.MedicosCorreo,            
        D.EspecialidadesCodigo,     
        D.ConsultoriosCodigo,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Pacientes Historial
--=====================================================================
Create table Atenciones.PacientesHistorial
(
    PacientesCodigo            nchar(7),
    PacientesDNI               nchar(8),
    PacientesNombres           nvarchar(100),
    PacientesApellidos         nvarchar(100),
    PacientesFechaNacimiento   date,
    PacientesSexo              nchar(1),
    PacientesTelefono          nchar(9),
    PacientesCorreo            nvarchar(100),
    PacientesDireccion         nvarchar(200),
    PacientesCondiciones       nvarchar(300),
    PacientesAccion            nvarchar(20),
    PacientesEstado            nvarchar(20),
    PacientesEquipo            nvarchar(50),
    PacientesFechaHora         datetime,
    PacientesUsuario           nvarchar(50),
    PacientesAplicacion        nvarchar(50)

)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thPacientesInsercion
on Atenciones.Pacientes
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.PacientesHistorial
    select
        I.PacientesCodigo,            
        I.PacientesDNI,              
        I.PacientesNombres,           
        I.PacientesApellidos,         
        I.PacientesFechaNacimiento,  
        I.PacientesSexo,             
        I.PacientesTelefono,          
        I.PacientesCorreo,            
        I.PacientesDireccion,         
        I.PacientesCondiciones,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thPacientesEdicion
on Atenciones.Pacientes
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.PacientesHistorial
    select
        I.PacientesCodigo,            
        I.PacientesDNI,              
        I.PacientesNombres,           
        I.PacientesApellidos,         
        I.PacientesFechaNacimiento,  
        I.PacientesSexo,             
        I.PacientesTelefono,          
        I.PacientesCorreo,            
        I.PacientesDireccion,         
        I.PacientesCondiciones, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.PacientesHistorial
    select
        D.PacientesCodigo,            
        D.PacientesDNI,              
        D.PacientesNombres,           
        D.PacientesApellidos,         
        D.PacientesFechaNacimiento,  
        D.PacientesSexo,             
        D.PacientesTelefono,          
        D.PacientesCorreo,            
        D.PacientesDireccion,         
        D.PacientesCondiciones,
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thPacientesEliminacion
on Atenciones.Pacientes
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.PacientesHistorial
    select
        D.PacientesCodigo,            
        D.PacientesDNI,              
        D.PacientesNombres,           
        D.PacientesApellidos,         
        D.PacientesFechaNacimiento,  
        D.PacientesSexo,             
        D.PacientesTelefono,          
        D.PacientesCorreo,            
        D.PacientesDireccion,         
        D.PacientesCondiciones,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Receta Historial
--=====================================================================
Create table Atenciones.RecetaHistorial
(
    RecetaCodigo            nchar(7),
    HistoriaClinicaCodigo   nchar(7),
    MedicosCodigo           nchar(7),
    RecetaCategoriasCodigo  nchar(7),
    RecetaFecha             date,
    RecetaDiagnostico       nvarchar(300),
    RecetaIndicaciones      nvarchar(500),
    RecetaObservaciones     nvarchar(500),
    RecetaAccion            nvarchar(20),
    RecetaEstado            nvarchar(20),
    RecetaEquipo            nvarchar(50),
    RecetaFechaHora         datetime,
    RecetaUsuario           nvarchar(50),
    RecetaAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thRecetaInsercion
on Atenciones.Receta
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.RecetaHistorial
    select
        I.RecetaCodigo,
        I.HistoriaClinicaCodigo,   
        I.MedicosCodigo,           
        I.RecetaCategoriasCodigo,  
        I.RecetaFecha,             
        I.RecetaDiagnostico,       
        I.RecetaIndicaciones,      
        I.RecetaObservaciones,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thRecetaEdicion
on Atenciones.Receta
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.RecetaHistorial
    select
        I.RecetaCodigo,
        I.HistoriaClinicaCodigo,   
        I.MedicosCodigo,           
        I.RecetaCategoriasCodigo,  
        I.RecetaFecha,             
        I.RecetaDiagnostico,       
        I.RecetaIndicaciones,      
        I.RecetaObservaciones,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.RecetaHistorial
    select
        D.RecetaCodigo,
        D.HistoriaClinicaCodigo,   
        D.MedicosCodigo,           
        D.RecetaCategoriasCodigo,  
        D.RecetaFecha,             
        D.RecetaDiagnostico,       
        D.RecetaIndicaciones,      
        D.RecetaObservaciones,
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thRecetaEliminacion
on Atenciones.Receta
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.RecetaHistorial
    select
        D.RecetaCodigo,
        D.HistoriaClinicaCodigo,   
        D.MedicosCodigo,           
        D.RecetaCategoriasCodigo,  
        D.RecetaFecha,             
        D.RecetaDiagnostico,       
        D.RecetaIndicaciones,      
        D.RecetaObservaciones,                 
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Receta Categorias Historial
--=====================================================================
Create table Atenciones.RecetaCategoriasHistorial
(
    RecetaCategoriasCodigo            nchar(7),
    RecetaCategoriasNombre            nvarchar(100),
    RecetaCategoriasDescripcion       nvarchar(250),
    RecetaCategoriasAccion            nvarchar(20),
    RecetaCategoriasEstado            nvarchar(20),
    RecetaCategoriasEquipo            nvarchar(50),
    RecetaCategoriasFechaHora         datetime,
    RecetaCategoriasUsuario           nvarchar(50),
    RecetaCategoriasAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thRecetaCategoriasInsercion
on Atenciones.RecetaCategorias
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.RecetaCategoriasHistorial
    select
        I.RecetaCategoriasCodigo,            
        I.RecetaCategoriasNombre,            
        I.RecetaCategoriasDescripcion,          
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thRecetaCategoriasEdicion
on Atenciones.RecetaCategorias
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.RecetaCategoriasHistorial
    select
        I.RecetaCategoriasCodigo,            
        I.RecetaCategoriasNombre,            
        I.RecetaCategoriasDescripcion,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.RecetaCategoriasHistorial
    select
        D.RecetaCategoriasCodigo,            
        D.RecetaCategoriasNombre,            
        D.RecetaCategoriasDescripcion,
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thRecetaCategoriasEliminacion
on Atenciones.RecetaCategorias
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.RecetaCategoriasHistorial
    select
        D.RecetaCategoriasCodigo,            
        D.RecetaCategoriasNombre,            
        D.RecetaCategoriasDescripcion,                
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Receta Laboratorios Historial
--=====================================================================
Create table Atenciones.RecetaLaboratoriosHistorial
(
    RecetaLaboratoriosCodigo            nchar(7),
    RecetaCodigo                        nchar(7),
    RecetaLaboratoriosExamen            nvarchar(150),
    RecetaLaboratoriosResultado         nvarchar(300),
    RecetaLaboratoriosFecha             date,
    RecetaLaboratoriosObservaciones     nvarchar(300),
    RecetaLaboratoriosAccion            nvarchar(20),
    RecetaLaboratoriosEstado            nvarchar(20),
    RecetaLaboratoriosEquipo            nvarchar(50),
    RecetaLaboratoriosFechaHora         datetime,
    RecetaLaboratoriosUsuario           nvarchar(50),
    RecetaLaboratoriosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Atenciones.thRecetaLaboratoriosInsercion
on Atenciones.RecetaLaboratorios
with encryption
for insert
As
Begin
    set nocount on
    insert into Atenciones.RecetaLaboratoriosHistorial
    select
        I.RecetaLaboratoriosCodigo,           
        I.RecetaCodigo,                        
        I.RecetaLaboratoriosExamen,            
        I.RecetaLaboratoriosResultado,         
        I.RecetaLaboratoriosFecha,             
        I.RecetaLaboratoriosObservaciones,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Atenciones.thRecetaLaboratoriosEdicion
on Atenciones.RecetaLaboratorios
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Atenciones.RecetaLaboratoriosHistorial
    select
        I.RecetaLaboratoriosCodigo,           
        I.RecetaCodigo,                        
        I.RecetaLaboratoriosExamen,            
        I.RecetaLaboratoriosResultado,         
        I.RecetaLaboratoriosFecha,             
        I.RecetaLaboratoriosObservaciones,
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Atenciones.RecetaLaboratoriosHistorial
    select
        D.RecetaLaboratoriosCodigo,           
        D.RecetaCodigo,                        
        D.RecetaLaboratoriosExamen,            
        D.RecetaLaboratoriosResultado,         
        D.RecetaLaboratoriosFecha,             
        D.RecetaLaboratoriosObservaciones,
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Atenciones.thRecetaLaboratoriosEliminacion
on Atenciones.RecetaLaboratorios
with encryption
for delete
As
Begin
    set nocount on
    insert into Atenciones.RecetaLaboratoriosHistorial
    select
        D.RecetaLaboratoriosCodigo,           
        D.RecetaCodigo,                        
        D.RecetaLaboratoriosExamen,            
        D.RecetaLaboratoriosResultado,         
        D.RecetaLaboratoriosFecha,             
        D.RecetaLaboratoriosObservaciones,               
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Usuarios Historial
--=====================================================================
Create table Seguridad.UsuariosHistorial
(
    UsuariosCodigo                      nchar(7),
    UsuariosNombre                      nvarchar(50),
    UsuariosClave                       nvarchar(100),
    UsuariosRol                         nvarchar(30),
    UsuariosUltimoAcceso                datetime,
    RecetaLaboratoriosAccion            nvarchar(20),
    UsuariosEstado                      nvarchar(20),
    RecetaLaboratoriosEquipo            nvarchar(50),
    RecetaLaboratoriosFechaHora         datetime,
    RecetaLaboratoriosUsuario           nvarchar(50),
    RecetaLaboratoriosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Seguridad.thUsuariosInsercion
on Seguridad.Usuarios
with encryption
for insert
As
Begin
    set nocount on
    insert into Seguridad.UsuariosHistorial
    select
        I.UsuariosCodigo,                     
        I.UsuariosNombre,                      
        I.UsuariosClave,                       
        I.UsuariosRol,                         
        I.UsuariosUltimoAcceso,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Seguridad.thUsuariosEdicion
on Seguridad.Usuarios
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Seguridad.UsuariosHistorial
    select
        I.UsuariosCodigo,                     
        I.UsuariosNombre,                      
        I.UsuariosClave,                       
        I.UsuariosRol,                         
        I.UsuariosUltimoAcceso, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Seguridad.UsuariosHistorial
    select
        D.UsuariosCodigo,                     
        D.UsuariosNombre,                      
        D.UsuariosClave,                       
        D.UsuariosRol,                         
        D.UsuariosUltimoAcceso, 
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Seguridad.thUsuariosEliminacion
on Seguridad.Usuarios
with encryption
for delete
As
Begin
    set nocount on
    insert into Seguridad.UsuariosHistorial
    select
        D.UsuariosCodigo,                     
        D.UsuariosNombre,                      
        D.UsuariosClave,                       
        D.UsuariosRol,                         
        D.UsuariosUltimoAcceso,                
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Usuarios Empleados Historial
--=====================================================================
Create table Seguridad.UsuariosEmpleadosHistorial
(
    UsuariosEmpleadosCodigo             nchar(7),
    UsuariosCodigo                      nchar(7),
    EmpleadosCodigo                     nchar(7),
    UsuariosEmpleadosAccion            nvarchar(20),
    UsuariosEmpleadosEstado            nvarchar(20),
    UsuariosEmpleadosEquipo            nvarchar(50),
    UsuariosEmpleadosFechaHora         datetime,
    UsuariosEmpleadosUsuario           nvarchar(50),
    UsuariosEmpleadosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Seguridad.thUsuariosEmpleadosInsercion
on Seguridad.UsuariosEmpleados
with encryption
for insert
As
Begin
    set nocount on
    insert into Seguridad.UsuariosEmpleadosHistorial
    select
        I.UsuariosEmpleadosCodigo,
        I.UsuariosCodigo,                      
        I.EmpleadosCodigo,         
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Seguridad.thUsuariosEmpleadosEdicion
on Seguridad.UsuariosEmpleados
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Seguridad.UsuariosEmpleadosHistorial
    select
        I.UsuariosEmpleadosCodigo,
        I.UsuariosCodigo,                      
        I.EmpleadosCodigo, 
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Seguridad.UsuariosEmpleadosHistorial
    select
        D.UsuariosEmpleadosCodigo,
        D.UsuariosCodigo,                      
        D.EmpleadosCodigo,
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Seguridad.thUsuariosEmpleadosEliminacion
on Seguridad.UsuariosEmpleados
with encryption
for delete
As
Begin
    set nocount on
    insert into Seguridad.UsuariosEmpleadosHistorial
    select
        D.UsuariosEmpleadosCodigo,
        D.UsuariosCodigo,                      
        D.EmpleadosCodigo,               
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--                       Crear Triggers 
--              Crear tabla Usuarios Medicos Historial
--=====================================================================
Create table Seguridad.UsuariosMedicosHistorial
(
    UsuariosMedicosCodigo            nchar(7),
    UsuariosCodigo                   nchar(7),
    MedicosCodigo                    nchar(7),
    UsuariosMedicosAccion            nvarchar(20),
    UsuariosMedicosEstado            nvarchar(20),
    UsuariosMedicosEquipo            nvarchar(50),
    UsuariosMedicosFechaHora         datetime,
    UsuariosMedicosUsuario           nvarchar(50),
    UsuariosMedicosAplicacion        nvarchar(50)
)
go

-- Trigger Inserción 
Create or alter trigger Seguridad.thUsuariosMedicosInsercion
on Seguridad.UsuariosMedicos
with encryption
for insert
As
Begin
    set nocount on
    insert into Seguridad.UsuariosMedicosHistorial
    select
        I.UsuariosMedicosCodigo,            
        I.UsuariosCodigo,                   
        I.MedicosCodigo,           
        'Insercion',
        'Insertado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
End
go

-- Trigger Edición 
Create or alter trigger Seguridad.thUsuariosMedicosEdicion
on Seguridad.UsuariosMedicos
with encryption
for update
As
Begin
    set nocount on
    -- Datos cambiados
    insert into Seguridad.UsuariosMedicosHistorial
    select
        I.UsuariosMedicosCodigo,            
        I.UsuariosCodigo,                   
        I.MedicosCodigo,    
        'Edicion',
        'Cambiado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from inserted As I
    -- Datos originales
    insert into Seguridad.UsuariosMedicosHistorial
    select
        D.UsuariosMedicosCodigo,            
        D.UsuariosCodigo,                   
        D.MedicosCodigo,    
        'Edicion',
        'Original',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

-- Trigger Eliminación 
Create or alter trigger Seguridad.thUsuariosMedicosEliminacion
on Seguridad.UsuariosMedicos
with encryption
for delete
As
Begin
    set nocount on
    insert into Seguridad.UsuariosMedicosHistorial
    select
        D.UsuariosMedicosCodigo,            
        D.UsuariosCodigo,                   
        D.MedicosCodigo,                    
        'Eliminacion',
        'Eliminado',
        @@SERVERNAME,
        GETDATE(),
        SYSTEM_USER,
        APP_NAME()
    from deleted As D
End
go

--=====================================================================
--          Trigger que no permita borrar más de una cita
--=====================================================================
Create or Alter Trigger Atenciones.trCitasEliminaUnoSolo
    on Atenciones.Citas with encryption for delete
As
Begin
    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de una Cita'
        Rollback Transaction
    End
End
Go

--=====================================================================
--          Trigger que no permita borrar más de una Factura
--=====================================================================
Create or Alter Trigger Atenciones.trFacturaEliminaUnoSolo
    on Atenciones.Factura with encryption for delete
As
Begin

    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de una Factura'
        Rollback Transaction

    End

End
Go

--=====================================================================
--          Trigger que no permita borrar más de una Boleta
--=====================================================================
Create or Alter Trigger Atenciones.trBoletaEliminaUnoSolo
    on Atenciones.Boleta with encryption for delete
As
Begin

    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de una Boleta'
        Rollback Transaction

    End

End
Go

--=====================================================================
--          Trigger que no permita borrar más de una Receta
--=====================================================================
Create or Alter Trigger Atenciones.trRecetaEliminaUnoSolo
    on Atenciones.Receta with encryption for delete
As
Begin

    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de una Receta'
        Rollback Transaction

    End

End
Go

--=====================================================================
--      Trigger que no permita borrar más de un Registro Farmacia
--=====================================================================
Create or Alter Trigger Atenciones.trFarmaciaEliminaUnoSolo
    on Atenciones.Farmacia with encryption for delete
As
Begin

    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de un registro de Farmacia'
        Rollback Transaction

    End

End
Go

--=====================================================================
--          Trigger que no permita borrar más de un Usuario
--=====================================================================
Create or Alter Trigger Seguridad.trUsuariosEliminaUnoSolo
    on Seguridad.Usuarios with encryption for delete
As
Begin

    if (select count(*) from deleted) > 1
    Begin

        Print 'No se puede borrar más de un Usuario'
        Rollback Transaction

    End

End
Go

--==============================================================================
-- AUTENTICACIÓN DE USUARIOS CON CLAVE MD5
--==============================================================================

-- Convertir a MD5 las claves existentes que todavía se encuentren en texto plano.
-- Un MD5 hexadecimal válido contiene exactamente 32 caracteres hexadecimales.
UPDATE Seguridad.Usuarios
SET UsuariosClave = LOWER(CONVERT(varchar(32),
                        HASHBYTES('MD5', CONVERT(varchar(8000), UsuariosClave)), 2))
WHERE LEN(UsuariosClave) <> 32
   OR UsuariosClave LIKE '%[^0-9a-fA-F]%'
GO

-- Procedimiento de autenticación.
-- Retorna 1 si las credenciales corresponden a un usuario activo, de lo contrario retorna 0
CREATE OR ALTER PROCEDURE Seguridad.spAutenticacionUsuarios
(
    @Nombre nvarchar(50),
    @Clave  nvarchar(100)
)
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON

    IF EXISTS
    (
        SELECT 1
        FROM Seguridad.Usuarios
        WHERE UsuariosNombre = @Nombre
          AND UsuariosClave = @Clave
          AND UsuariosEstado = 'A'
    )
    BEGIN
        UPDATE Seguridad.Usuarios
        SET UsuariosUltimoAcceso = GETDATE()
        WHERE UsuariosNombre = @Nombre
          AND UsuariosEstado = 'A'

        RETURN 1
    END

    RETURN 0
END
GO

-- Insertar usuarios almacenando la clave en formato MD5.
CREATE OR ALTER PROCEDURE Seguridad.spUsuariosInsertarRegistro
(
    @UsuariosCodigo nchar(7),
    @UsuariosNombre nvarchar(50),
    @UsuariosClave nvarchar(100),
    @UsuariosRol nvarchar(30),
    @UsuariosUltimoAcceso datetime,
    @UsuariosEstado nchar(1)
)
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @ClaveMD5 nvarchar(100)

    -- Evitar aplicar MD5 por segunda vez si el valor ya es un hash hexadecimal.
    IF LEN(@UsuariosClave) = 32
       AND @UsuariosClave NOT LIKE '%[^0-9a-fA-F]%'
        SET @ClaveMD5 = LOWER(@UsuariosClave)
    ELSE
        SET @ClaveMD5 = LOWER(CONVERT(varchar(32),
                            HASHBYTES('MD5', CONVERT(varchar(8000), @UsuariosClave)), 2))

    INSERT INTO Seguridad.Usuarios
    (
        UsuariosCodigo,
        UsuariosNombre,
        UsuariosClave,
        UsuariosRol,
        UsuariosUltimoAcceso,
        UsuariosEstado
    )
    VALUES
    (
        @UsuariosCodigo,
        @UsuariosNombre,
        @ClaveMD5,
        @UsuariosRol,
        @UsuariosUltimoAcceso,
        @UsuariosEstado
    )
END
GO

-- Editar usuarios almacenando la clave en formato MD5.
CREATE OR ALTER PROCEDURE Seguridad.spUsuariosEditarRegistro
(
    @UsuariosCodigo nchar(7),
    @UsuariosNombre nvarchar(50),
    @UsuariosClave nvarchar(100),
    @UsuariosRol nvarchar(30),
    @UsuariosUltimoAcceso datetime
)
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @ClaveMD5 nvarchar(100)

    IF LEN(@UsuariosClave) = 32
       AND @UsuariosClave NOT LIKE '%[^0-9a-fA-F]%'
        SET @ClaveMD5 = LOWER(@UsuariosClave)
    ELSE
        SET @ClaveMD5 = LOWER(CONVERT(varchar(32),
                            HASHBYTES('MD5', CONVERT(varchar(8000), @UsuariosClave)), 2))

    UPDATE Seguridad.Usuarios
    SET UsuariosNombre = @UsuariosNombre,
        UsuariosClave = @ClaveMD5,
        UsuariosRol = @UsuariosRol,
        UsuariosUltimoAcceso = @UsuariosUltimoAcceso
    WHERE UsuariosCodigo = @UsuariosCodigo
END
GO

Print '-------------------------------------------------------------------------------'
Print '|                                                                              |'
Print '|    ¡Base de datos Clínica Salud Integral S.A.C. Instalada correctamente!     |'
Print '|                                                                              |'
Print '--------------------------------------------------------------------------------'