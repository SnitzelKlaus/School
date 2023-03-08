CREATE DATABASE SecuredPasswords;
go
USE SecuredPasswords;
go

CREATE TABLE Users
(
id INT IDENTITY PRIMARY KEY NOT NULL,
username VARCHAR(256) NOT NULL,
password_hash VARCHAR(256) NOT NULL,
salt VARCHAR(128) NOT NULL,
iterations INT NOT NULL,
);
