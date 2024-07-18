create database Sql_Assignments
use Sql_Assignments
--1.creating tables
Create table Customers(
Customerid char(5) not null,
CompanyName Varchar(40) not null,
ContactName char (30) null,
[Address] Varchar (60) null,
City char(15) null,
Phone Char(24) null,
Fax Char(24) null)

Create table Orders(
OrderId int not null,
CustomerId Char(5) not null,
Orderdate datetime null,
Shippeddate datetime null,
Freight money null,
Shipname Varchar(40) null,
Shipaddres varchar(60) null,
Quantity integer null)

select * from Customers  
select * from Orders
--2.add new column to table
alter table Orders add shipregion int  null
--3.change data type of column
alter table Orders alter column shipregion Char(8);

--4.delete cloumn
alter table Orders 
 drop column shipregion 

--5.inserting new row
insert into Orders values(1,1,'01-01-2023','07-01-2023',1000.00,'Shivani','Vizag',2)
select *from Orders
--6.add contraint
alter table Orders 
add constraint df_con default getdate() for Orderdate ;
--rename column
sp_rename 'Customers.city','town','column'






