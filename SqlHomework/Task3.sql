use HomeworkP
create table Portfolios (
Id int primary key identity,
PortfolioTitle nvarchar (50),
PortfolioSubtitle nvarchar(50),
PortfolioUrl nvarchar (100)
)

create table Categories(
Id int primary key identity,
CategoryName nvarchar (50)
)
create table PortfolioImages(
Id int primary key identity,
Images nvarchar (50)
)

create table PortfolioPortfolioImages(
Id int primary key identity ,
PortfolioId int constraint  FK_PortfolioPortfolioImages_PortfolioId foreign key references Portfolios(Id),
PortfolioImagesid int foreign key references PortfolioImages(Id)
)
create table PortfolioPortfolioImagesCategories(
Id int primary key identity ,
PortfolioPortfolioImagesId int constraint  FK_PortfolioPortfolioImagesCategories_PortfolioPortfolioImagesId foreign key references PortfolioPortfolioImages(Id),
CategoriesId int foreign key references Categories(Id)
)


select p.PortfolioTitle 'Title', p.PortfolioSubtitle 'Subtitle',  p.PortfolioUrl'Url', ps.Images,c.CategoryName 'Category'from PortfolioPortfolioImagesCategories pc
join Portfolios p
on pc.PortfolioPortfolioImagesId= p.Id
join portfolioImages ps
on pc.PortfolioPortfolioImagesId = ps.Id
join Categories c
on pc.CategoriesId=c.CategoryName

