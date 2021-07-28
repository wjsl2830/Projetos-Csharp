
 create database LoginApp;

 use LoginApp;
 
 create table Usuario
 (
	ID INT IDENTITY PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
	Password VARCHAR(20) NOT NULL,
 );

 INSERT INTO Usuario (Username, Password) VALUES ('wendel', '3028');
 SELECT *FROM Usuario