use master 
go 
alter database [WindowsOrders] set single_user with rollback immediate;
go 
alter database [WindowsOrders] set multi_user with rollback immediate;
go 
drop database [WindowsOrders];