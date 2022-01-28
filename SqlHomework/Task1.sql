create database HomeworkP

use HomeworkP

create table  Employes(
Id int primary key identity,
FullName nvarchar check(FullName>=3) not null,
Salary int check(Salary>=0),
DepartamentId int constraint FK_Employeess_DepartamentId  foreign key references Departmentss(Id),
)

create table Departmentss(
Id int primary key identity,
Name nvarchar check(Name>=2) not null
)

create table Products(
Id int primary key identity,
Name nvarchar(50),
price decimal,
ProductCount int,
BrandId int constraint FK_Products_BrandId foreign key references Brands(Id)
)
create table Brands(
Id int primary key identity,
Name nvarchar(50) not null
)

insert into Products
values('Samsung Galaxy Note 10 Lite',999,5,1),
('Remi Note 10',799,8,3),
('Samsung Galaxy A52',899,8,1),
('Nokia 6300',140,7,2),
('Nokia 215',98,7,2)

insert into Brands
values('Samsung'),
('Nokia'),
('Redmi')

SELECT Products.Id,Products.Name,Products.price,Products.ProductCount, Brands.Name 
FROM Products
INNER JOIN Brands ON Products.BrandId=Brands.Id;




















