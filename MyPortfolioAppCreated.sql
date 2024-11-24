use master
go

if DB_ID('MyPortfolioDb') is not NULL
BEGIN
    alter database MyPortfolioDb set single_user with ROLLBACK IMMEDIATE
    drop DATABASE MyPortfolioDb
END 
go

CREATE DATABASE MyPortfolioDb collate Turkish_CI_AS
go

use MyPortfolioDb
go 

create table AppSettings(

    Id int primary key identity,
    BrandName nvarchar(100) not null,
    HeroTitle nvarchar(300) not null,
    HeroSubtitle nvarchar(300) not null,
    HeroImageUrl nvarchar(300) not null,
    AboutText nvarchar(3000) not null,
    AboutImageUrl Nvarchar(1000) not null,
    SkillsImageUrl nvarchar(1000) not null,
    AddressDistrict nvarchar(100) not null,
    AddressProvince nvarchar(100) not null,
    PhoneNumber nvarchar(20) not null,
    Email nvarchar(100) not null,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime 

)

go

insert into AppSettings(

BrandName,
HeroTitle,
HeroSubtitle,
HeroImageUrl,
AboutText,
AboutImageUrl,
SkillsImageUrl,
AddressDistrict,
AddressProvince,
PhoneNumber,
Email
)values

(
    'Merve Türk Arpacıoğlu',
    'Yazılım Geliştirici',
    'DotNet|C#|Asp.Net Core|Asp.Net MVC|Html|Css|Javascript',
    'http://localhost:5500/ui/img/carousel-1.png',
    'Nişantaşı Üniversitesi Acundmedya Akademi bünyesinde BackEnd Yazılım Eğitimi aldım
     Aldığım eğitim boyunca çeşitli projeler yaparak kendimi geliştirdim.',
    'http://localhost:5500/ui/img/testimonial-1.png',
    'http://localhost:5500/ui/img/com-logo-4.png',
    'Bahçelievler',
    'İstanbul',
    '+90 546 669 84 55',
    'merveearp@icloud.com'
    
)
go 
create table Socials(
    Id int primary key identity,
    Name nvarchar(50) not null,
    Url nvarchar(1000)not null,
    Icon nvarchar(50) not null,
    IsActive  bit not null default 1,
    CreatedDate datetime not null default getdate(),
    ModifiedDate datetime 
)
go
insert into Socials(Name,Url,Icon)
values

    ('Github','https://github.com/merveearp','github'),
    ('LinkedIn','https://www.linkedin.com/in/merve-arpac%C4%B1o%C4%9Flu-t%C3%BCrk-8b3917199/','linkedin'),
    ('X','https://x.com/merveearp','twitter-x')
go 
create table Jobs(
    Id int primary key identity,
    Name nvarchar(100) not null 
)
go
insert into Jobs(Name)
values 
    ('Software Developer'),
    ('Automation Engineer'),
    ('Mechatronic Engineer'),
    ('Product Manager'),
    ('Marketing Manager'),
    ('PLC Control'),
    ('DevOps Engineer '),
    ('Product Manager')
go
create Table Categories(
    Id int primary key identity,
    Name nvarchar(100) not null  
)
go
insert into Categories(Name)
values
('Working'),
('Meeting'),
('Product')
go
create Table Locations(
    Id int primary key identity,
    Name nvarchar(100) not null  

)
go
insert into Locations(Name)
values
('İstanbul'),
('Ankara'),
('Kocaeli')
go
create Table Educations(
    Id int primary key identity,
    Name nvarchar(100) not null  

)
go
insert into Educations(Name)
values
('C#'),
('.NET'),
('HTML'),
('CSS'),
('PHYTON'),
('JAVASCRIPT'),
('REACT'),
('NODEJS')
go



