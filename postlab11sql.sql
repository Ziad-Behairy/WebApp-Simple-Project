CREATE DATABASE LAB11
USE LAB11 
CREATE TABLE USERS (

ID INT PRIMARY KEY IDENTITY ,
Name VARCHAR(50) NOT NULL ,
Email VARCHAR(50) NOT NULL,
Username VARCHAR(50) UNIQUE,
Password VARCHAR(40) NOT NULL,
user_type INT NOT NULL
);

