use  master
create database kucni_budzet
use kucni_budzet
create table promet(
id int identity(1,1) primary key,
datum datetime not null,
novcanik int not null,
osoba int not null,
trosak int not null,
org int,
firma int,
ulaz money,
izlaz money,
future char)
create table novcanik(
id int identity(1,1) primary key,
naziv nvarchar(30))
create table osoba(
id int identity(1,1) primary key,
naziv nvarchar(30))

create table trosak(
id int identity(1,1) primary key,
naziv nvarchar(30))
create table org(
id int identity(1,1) primary key,
naziv nvarchar(30))
create table firma(
id int identity(1,1) primary key,
naziv nvarchar(30))