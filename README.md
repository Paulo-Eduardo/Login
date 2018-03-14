WebForms simples gerenciamento de usuarios

Base MySQL

Criação tabela
create table User(
Id char(36) primary key,
Login Varchar(30) not null UNIQUE,
Password Varchar(30) not null,
Created datetime,
Email Varchar(50),
Image varchar(250)
);

create table LogError(
Id char(36) primary key,
User char(36) not null,
Erro varchar(250)
)
