create database Libraries
use Libraries
create table Authors(
Id int  primary key identity,
Name nvarchar (50),
Surname nvarchar (50)
)

create table Books(
Id int primary key identity,
Name nvarchar(100)not null,
PageCount int check (PageCount>=10),
AuthorId int foreign key references Authors(Id)
)

insert into Books
values('Günes Ülkesi',500,1),
('Projeler ile Excel ve Makrolar',210,2),
('Analitik Psikoloji Üzerine iki Deneme',140,3),
('Önce Sen Vardin',300,4),
('Sil Bastan',400,6),
('Kaybolus',240,6),
('Zaman Çarki',450,6),
('Harry Potter ve Felsefe Tasi - 1.Kitap',600,5),
('Harry Potter ve Sirlar Odasi - 2.kitap',460,5),
('Güzel Bir Hayat',200,5)

insert into Authors
values('Tommaso','Campanella'),
('Süleyman ','Uzunköprü'),
('Carl Gustav','Jung'),
('Dogan ','Kitap'),
('J. K.','Rowling'),
('Ken','Grimwood ')

create view vw_selectAllBooks
as
select * from
(select b.Id, b.Name as Kitablar, b.PageCount as 'Sehifeler', a.Name as Ad,a.Surname as Familiya from Books as b
join Authors a
on b.AuthorId= a.Id
) as BooksTables

select * from vw_selectAllBooks

create procedure usp_selectBooksAuthorsWithLetters
@Letter nvarchar(30)
as
select * from vw_selectAllBooks
Where Kitablar like '%' + @Letter + '%' or Ad like '%' + @Letter + '%' or Familiya like '%' + @Letter + '%'

exec usp_selectBooksAuthorsWithLetters 'Rowling'


create procedure usp_addAuthor
@Name nvarchar(50) ,
@Surname nvarchar(50)
as
insert into Authors(Name, Surname)
values(@Name,@Surname)


exec usp_addAuthor 'Elxan', 'Elatli'
select * from Authors

create procedure usp_deleteAuthor
@Name nvarchar(15) = ''
as
delete from Authors
where Name = @Name

exec usp_deleteAuthor 'Elxan'
select * from Authors

create procedure usp_updateAuthor
@Name nvarchar (50),
@Surname nvarchar (50),
@Id int
as
update Authors
set Name = @Name,
 Surname= @Surname
where Id = @Id

exec usp_updateAuthor @Id = 8, @Name = 'Cingiz',@Surname='Abdullayev'

select * from Authors

create view vw_selectAllAuthorBooksCount
as
select FulName, Count(*) BooksCount,MAX(PageCount)as MaxpageCount from
(select a.Id  , a.Name+a.Surname as FulName, b.Name as BookName,b.PageCount as PageCount  from Books as b
join Authors a
on b.AuthorId =a.Id
) as AuthorBooks
group by FulName
having Count(*)>=2

select * from vw_selectAllAuthorBooksCount



