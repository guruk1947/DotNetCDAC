
-- create table _emp(id int primary key auto_increment, name varchar(10), designation varchar(10), salary int, city varchar(20));
drop procedure if exists selectPro1;
delimiter $
CREATE PROCEDURE selectPro1()
BEGIN
	select * from _emp;
end$
delimiter ;


drop procedure if exists inData;
delimiter $
create procedure inData(in nm varchar(10), in ds varchar(10), in sal int, in ct varchar(20))
BEGIN
	insert into _emp(name, designation, salary, city) values(nm, ds, sal, ct);
end$
delimiter ;


drop procedure if exists delData;
delimiter $
create procedure delData(in x int)
begin
	delete from _emp where id=x;
end$
delimiter ;


drop procedure if exists selectById;
delimiter $
create procedure selectById(in x int, out nm varchar(10))
begin
	select name into nm from _emp where id=x;
end$
delimiter ;


drop procedure if exists upData;
delimiter $
create procedure upData(in x int, in nm varchar(10), in sal int)
begin
	update _emp set name=nm, salary=sal where id=x;
end$
delimiter ;


-- select * from _emp;
-- call selectPro1();
-- call inData('Raj', 'GET', 15000, 'Mumbai');
-- call delData(5);
-- call selectById(3, @nm);
-- select @nm;
-- call upData(1, 'Das', 18000);