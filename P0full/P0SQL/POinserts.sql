insert into Customer (FName,LName)
values('ashe','katchum'),('misty','williams'),('brock','sampson'),('gary','oak');

alter table Product
alter column ProductName nvarchar(20)

--CREATE TABLE Customer(
--CustomerID Int not null unique identity,
--FName varchar not null,
--LName varchar not null,
--primary key(CustomerID)

insert into StoreLocation(LocationName)
values('pallet'),('lavender'),('cerulean');

--create table StoreLocation(
--LocationID int not null unique identity,
--LocationName varchar not null,
--primary key(LocationID)


insert into Product(ProductCount, ProductPrice, productDescription, ProductName)
values(99,010.00,'pokeball','pokeball'),(99,025.00,'pokeball','greatball'),
(99,075.00,'pokeball','ultraball'),(99,999.99,'pokeball','masterball'),
(99,025.00,'repel','Repel'),(99,125.00,'repel','superrepel'),
(99,250.00,'repel','maxrepel'),(99,005.00,'potion','potion'),(99,050.00,'potion','superpotion'),
(99,200.00,'potion','MaxPotion'),(99,100.00,'revive','revive'),(99,200.00,'revive','maxrevive'),
(99,300.00,'evolution stone','Fire Stone'),(99,300.00,'evolution stone','Sun Stone'),
(99,300.00,'evolution stone','Thunder Stone'),(99,300.00,'evolution tone','Moon Stone'),
(99,300.00,'evolution stone','Duck Stone');

--create table Product(
--productCount int,
--ProductID int not null unique identity,
--ProductPrice decimal(5,2) not null,
--productDescription varchar not null,
--ProductName varchar not null,
--primary key(ProductID)

select * from Product

--create table Inventory(
--ProductID int,
--LocationID int,
--InventoryNumber int,
--InventoryID int not null unique identity,
--Primary key(InventoryID),
--foreign key(ProductID) references Product(ProductID),
--foreign key(LocationID) references StoreLocation(LocationID),

insert into Inventory(ProductID, LocationID, InventoryNumber)
values(3,3,33),(3,4,33),(3,5,33),
(4,3,33),(4,4,33),(4,5,33),
(5,3,33),(5,4,33),(5,5,33),
(6,3,33),(6,4,33),(6,5,33),
(7,3,33),(7,4,33),(7,5,33),
(8,3,33),(8,4,33),(8,5,33),
(9,3,33),(9,4,33),(9,5,33),
(10,3,33),(10,4,33),(10,5,33),
(11,3,33),(11,4,33),(11,5,33),
(12,3,33),(12,4,33),(12,5,33),
(13,3,33),(13,4,33),(13,5,33),
(14,3,33),(14,4,33),(14,5,33),
(15,3,33),(15,4,33),(15,5,33),
(16,3,33),(16,4,33),(16,5,33),
(17,3,33),(17,4,33),(17,5,33),
(18,3,33),(18,4,33),(18,5,33),
(19,3,33),(19,4,33),(19,5,33)

select ProductName from Product full join Inventory where Product.ProductID