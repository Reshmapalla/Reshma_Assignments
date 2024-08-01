select * from [dbo].[Product]

create procedure GetAllProducts
As 
begin 
select * from Product
end 

exec GetAllProducts

create procedure GetProductByname(@name varchar(20))

as
begin
select * from Product where pname=@name
end

exec GetProductByname 'chair'


create procedure GetAllProductGeraterThanInputPrice(@price int)
as 
begin
select * from product
Where price>@price
end 

exec GetAllProductGeraterThanInputPrice 230


create procedure DeleteProdyctById(@id int)
as 
begin
delete from product
where pid=@id
end

exec DeleteProdyctById @id=106



create Procedure UpdateProduct(@id int,@price int,@catid int)
as
begin
update  product
set price=@price,catid=@catid
where pid=@id
end

exec UpdateProduct 102,200,10

