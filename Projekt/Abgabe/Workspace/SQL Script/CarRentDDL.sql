CREATE DATABASE IF NOT EXISTS CarRentDB;

USE CarRentDB;

CREATE TABLE CarRentDB.Cars (
	Id INT NOT NULL AUTO_INCREMENT,
	Marke VARCHAR(45) NULL,
	Seriennummer VARCHAR(45) NULL,
	Typ VARCHAR(45) NULL,
	Farbe VARCHAR(45) NULL,
	Vermietet BOOL DEFAULT FALSE,
    PRIMARY KEY (Id))
;
INSERT INTO Cars ( Seriennummer, Marke, Typ, Farbe)
VALUES
	('Tumasch', 'Buchli', 'Herr', 'tumasch,buchli@lelek.ch');
    
    SELECT * FROM Cars;