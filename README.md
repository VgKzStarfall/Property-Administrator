### WPF_Total
# Database:

Go
Use XStore

Create table Member
(
	MemberId int identity(1,1) primary key not null,
	Email varchar(100) not null,
	CompanyName varchar(40) not null,
	City varchar(15) not null,
	Country varchar(15) not null,
	Password varchar(30) not null
)
Insert into Member values('admin@gmail.com', 'ADMIN', 'Dawn', 'Night', 'admin')
Insert into Member values('vanka@gmail.com', 'Vanka', 'Dawn', 'Night', 'vanka')
Insert into Member values('giucop@gmail.com', 'Giucop', 'Dawn', 'Night', 'giucop')

Create table Property
(
	PropertyId int identity(1,1) primary key not null,
	pName varchar(15) not null,
	pLocation varchar(50) not null,
	pArea float not null,
	pPrice int not null
)
Insert into Property values('Sumeru City', 'Sumeru-Teyvat', '251.5', '353000')
Insert into Property values('Narukami Shrine', 'Inazuma-Teyvat', '101', '140000')
Insert into Property values('Starfell Valley', 'Monstadt-Teyvat', '401.2', '653000')
