use HomeworkP
create table Pricings(
Id int primary key identity,
Name nvarchar(50),
price int,
priceDataDesc nvarchar(50),
BuyUrl nvarchar(100)
)

create table Features(
Id int primary key identity,
title nvarchar(100)
)

create table PricingFeatures(
Id int primary key identity,
PricingId int constraint FK_PricingFeatures_PricingId foreign key references Pricings(Id),
	FeatureId int foreign key references Features(Id)
)
insert into Pricings
values('Free',89,'per month','est.com'),
('Business',29,'per month','test.com'),
('Developer',49,'per month','tst.com')

insert into Features
values(' Quam adipiscing vitae proin'),
(' Nec feugiat nisl pretium'),
(' Nulla at volutpat diam uteera')

insert into PricingFeatures
values(1,4),
(2,5),
(3,6)



select p.Name 'Pricing Name', p.price 'Price', p.priceDataDesc' Data', f.title as 'Feature ',p.BuyUrl 'Buy Now',pf.FeatureId,pf.PricingId from PricingFeatures pf
join Pricings p
on pf.PricingId = p.Id
join Features f
on pf.FeatureId = f.Id
