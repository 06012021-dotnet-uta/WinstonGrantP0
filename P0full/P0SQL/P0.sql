CREATE TABLE Customer(
CustomerID Int not null unique identity,
FName varchar not null,
LName varchar not null,
primary key(CustomerID)
);
create table StoreLocation(
LocationID int not null unique identity,
LocationName varchar not null,
primary key(LocationID)
);
create table CustomerOrder(
CustomerOrderID int not null unique identity,
CustomerOrdertime date,
CustomerID int,
LocationID int,
primary key(CustomerOrderID),
foreign key(CustomerID) references Customer (CustomerID),
foreign key(LocationID) references StoreLocation(LocationID)
);
create table Product(
ProductID int not null unique identity,
ProductPrice decimal(5,2) not null,
productDescription varchar not null,
ProductName varchar not null,
primary key(ProductID) 
);
create table OrderedProduct(
productID int,
CustomerOrderID int,
CustomerID int,
QuantityOfItems int,
primary key(CustomerOrderID, QuantityOfItems),
foreign key(ProductID) references Product(ProductID),
foreign key(CustomerID) references Customer(CustomerID),
foreign key(CustomerOrderID) references CustomerOrder(CustomerOrderID)
);
create table Inventory(
ProductID int,
LocationID int,
InventoryNumber int,
InventoryID int not null unique identity,
Primary key(InventoryID),
foreign key(ProductID) references Product(ProductID),
foreign key(LocationID) references StoreLocation(LocationID),
);

