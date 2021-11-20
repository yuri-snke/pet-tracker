create database pettracker;

use pettracker;

create table tbl_animal(
Id int primary key auto_increment,
Tipo varchar(20) not null,
Raca varchar(50),
SRD boolean,
Nome varchar(50) not null,
Idade int,
Porte varchar(50) not null,
Sexo varchar(20) not null
)