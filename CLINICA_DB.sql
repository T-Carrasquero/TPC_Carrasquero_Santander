Create Database TPC_CLINICA_DB
go
Use TPC_CLINICA_DB
go

Create Table Especialidades(
	Id bigint not null primary key identity (1, 1),
	Descripcion varchar(50) not null
)
go
Create Table Localidades(
    Id bigint not null primary key,
	CodigoPostal int not null,
	Nombre varchar(50) not null,
	Provincia varchar(50) not null,
	Pais varchar(50) not null
)
go
Create Table Medicos(
	Dni varchar(10) not null primary key,
	Apellidos varchar(50) not null,
	Nombres varchar(50) not null,
	Sexo varchar(1) not null,
	Idlocalidad bigint foreign key references Localidades(Id),
	Direccion varchar(50),
	Email varchar(50),
	Telefono varchar(50),
	Matricula varchar(50)
)
go
create table EspecialidadesPorMedico(
    DniMedico varchar(10) not null foreign key references Medicos(Dni),
    IdEspecialidad bigint not null foreign key references Especialidades(Id),
    primary key (DniMedico, IdEspecialidad)
)