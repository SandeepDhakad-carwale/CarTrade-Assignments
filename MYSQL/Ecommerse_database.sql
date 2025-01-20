 -- create database 
CREATE DATABASE  Ecommerce;
SHOW DATABASES;

--  create schema of products table

USE Ecommerce;

CREATE TABLE products(
prdt_id int primary key, 
name varchar(100) ,
category  enum('Sports','Beauty','Food','Electronics','Furniture','Clothing','Books','Groceries'),
stock int unsigned default 0 ,
price decimal(10,2) unsigned
);






--  create schema of customers table
CREATE TABLE customers(
userId int primary key auto_increment, 
firstName varchar(100) ,
lastName varchar(100),
email varchar(100) unique ,
phone varchar(20),
address text
);

--  create schema of orders table

CREATE TABLE orders(
orderID int primary key auto_increment, 
userId int,
status enum('shipped','pending','complete','cancelled') default 'pending',
total_amount double(100,2) unsigned,
FOREIGN KEY(userId) references customers(userId) ON DELETE SET NULL

);

--  create schema of ordersDetail table that contains the information of products that included in this order

CREATE TABLE ordersDetail(
Id int primary key auto_increment,
orderID int ,
prdt_id int,
quantity int unsigned,
foreign key(orderID) references orders(orderID) ON DELETE cascade,
foreign key(prdt_id) references products(prdt_id) ON DELETE SET NULL
);


-- add order_date field in orders table
ALTER TABLE orders add column order_date datetime default current_timestamp;



-- insert data to products table 
INSERT INTO  Products values(1,'hp_laptop','Electronics',100,50000);
INSERT INTO  Products values(2,'Dell_laptop','Electronics',15,35000);
INSERT INTO  Products values(101,'cricket_ball','Sports',400,120);
INSERT INTO  Products values(201,'chair','Furniture',40,580);
INSERT INTO  Products values(301,'facewash','Beauty',400,370);




-- insert data to customers table
 
 INSERT INTO  customers 
 values(1,'Sandeep','Dhakad','sandeep@gmail.com','11111111111','mali mohalla nahagarh ,distict -mandsaur ,M.P.');
INSERT INTO  customers (firstName,lastName,email,phone,address)
 values('Rahul','Roy','rahul@gmail.com','11111111111','sector 14 ,vashi ,navi mumbai ,Maharastra');
INSERT INTO  customers (firstName,lastName,email,phone,address)
values('Kapil','Sharma','kapil@gmail.com','11111111111','sector 9 ,vashi ,navi mumbai ,Maharastra');
INSERT INTO  customers (firstName,lastName,email,phone,address)
values('Yash','Maheshwari','yash@gmail.com','11111111111','sector 2 ,vashi ,navi mumbai ,Maharastra');
INSERT INTO  customers(firstName,lastName,email,phone,address)
 values('Gulab','Jamun','gulab@gmail.com','11111111111','sector 1 ,vashi ,navi mumbai ,Maharastra');


-- insert data into orders table 
Insert into orders(userId,total_amount) values(1,100.50);
Insert into orders(userId,total_amount) values(2,30.90);
Insert into orders(userId,total_amount) values(3,456.80);
Insert into orders(userId,total_amount) values(1,40.58);


-- insert data into ordersDetail table
Insert into ordersDetail(orderID,prdt_id,quantity) value(1,2,2);
Insert into ordersDetail(orderID,prdt_id,quantity) value(1,201,1);
Insert into ordersDetail(orderID,prdt_id,quantity) value(2,301,3);
Insert into ordersDetail(orderID,prdt_id,quantity) value(3,101,1);
Insert into ordersDetail(orderID,prdt_id,quantity) value(4,301,2);
Insert into ordersDetail(orderID,prdt_id,quantity) value(4,101,6);


-- Retrieving  QUERIES 
SELECT * from products where price<500 and price>100;
Select * from products where price<1000 And stock>50;
Select * from products where category='Electronics';

-- updating queries

Update customers set phone ="3949398398" where userId=1;
Update customers set phone="8893893893" ,email="jamun@gmail.com" where userId=5;
Update products set price=540 where prdt_id=201;
Update products set stock=stock-5 where prdt_id=301;
Update orders set status="shipped" where orderID=1;


-- Delete queries
Delete from products where prdt_id=2;
Set sql_safe_updates=0;
Delete from products where stock=0;
Delete from customers where userId=3;



-- Advanced Queries and Joins:

-- 1)Retrieving orders along with the corresponding customer and product information.
 select o.orderId,c.firstName,c.lastName,p.name as Product_Name,od.quantity ,od.quantity*p.price as Total
	from orders o join customers c on (o.userId=c.userId)
    join ordersDetail od on (o.orderID=od.orderID)
    join products p on (od.prdt_id=p.prdt_id);


-- 2)Getting the total revenue for a specific time period.

  select sum(orders.total_amount) as Total_Revenue from orders where order_date between '2025-01-15' and '2025-02-15';

-- 3)Finding customers who have made multiple purchases.
select c.userId,c.firstName,c.lastName ,
count(o.orderID) as total_orders 
from customers c join orders o on(o.userId=c.userId)
group by c.userId having total_orders>1;


/* 
   Indexing and Optimization:
  
  Indexing => for searching data speedly in database we use indexing ,
  when we create an index on a colomn ,database build binary search tree structure on that colomn
  so that the time complexity of searching reduce form O(n) to O(log(n)) 
  By default ,Mysql automatically create index on the primary key colomn .
  
  we should use indexes on colomns that are frequently searched .
  
  we should not to use indexes if the colomn that are update frequently
  because do to the updates binary search tree need to re-arange itself 
  
  
  
   Suggestion  to optimize the queries for better performance.
   we can create index on price and categories field because customer search product on basis of 
   price and categories..

  
  
  
*/


