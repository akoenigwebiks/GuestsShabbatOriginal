create table Guests(ID int primary key identity, name varchar(20))
create table Categories(ID int primary key identity, name varchar(20))
create table Food(ID int primary key identity,
Guest_ID int foreign key references Guests(ID),
Category_ID int foreign key references Categories(ID),
name varchar(20))

--הכנסת קטגוריה בתנאי שלא קיימת לפני
declare @name_category varchar(20)
if(@name_category != '')
	begin
	if not exists(select name from Categories where name=@name_category)
		begin
			insert into Categories values(@name_category)
		end
	end


	declare @name varchar(20)='ד'
	select name from categories where name like '%'+@name+'%'
	select * from Categories


--הכנסת אורח בתנאי שלא קיים לפני בטבלה
declare @name_guest varchar(20)
if(@name_guest != '')
	begin
	if not exists(select name from Guests where name=@name_guest)
		begin
			insert into Guests values(@name_guest)
		end
	end

--תוצאות
declare @category_name varchar(20)='דגים', @guest_name varchar(20)='אוהד'
select Food.name as 'שם מאכל'
from Food inner join Categories on Food.Category_ID=Categories.ID
inner join Guests on Food.Guest_ID = Guests.ID
where Categories.name=@category_name
and Guests.name=@guest_name


--הכנסת מאכל
insert into Food values((select ID from Guests where name= 'אוהד'),
(select ID from Categories where name= 'F'),'S')
select * from Food