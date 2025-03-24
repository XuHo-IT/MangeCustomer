create procedure GetAllCustomers
as
begin
select * from Customer
end

exec GetAllCustomers

create procedure GetCustomerById
@Id int
as
begin
select * from Customer where Id = @Id
end

exec GetCustomerById 1

alter procedure UpdateCustomer
@Id int,
@Mobile nvarchar(100),
@Name nvarchar(100),
@Email nvarchar(100)
as
begin
 update Customer set Mobile=@Mobile, Email=@Email, Name=@Name where Id=@Id
end

exec UpdateCustomer 1 , '5656546464','xuho','john@gmail.com'
select * from Customer