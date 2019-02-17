CREATE DATABASE IF NOT EXISTS carrentdb;

USE carrentdb;

CREATE TABLE IF NOT EXISTS carrentdb.Cars (
	Id INT NOT NULL AUTO_INCREMENT,
	Marke VARCHAR(45) NULL,
	Seriennummer VARCHAR(45) NULL,
	Typ VARCHAR(45) NULL,
	Farbe VARCHAR(45) NULL,
	Vermietet BOOL DEFAULT FALSE,
    PRIMARY KEY (Id))
;

CREATE TABLE IF NOT EXISTS carrentdb.Adress(
	AdressId INT NOT NULL AUTO_INCREMENT,
    Strasse VARCHAR(45) NULL,
    Strassennummer VARCHAR(45) NULL,
    PLZ VARCHAR(45) NULL,
    Ort VARCHAR(45) NULL,
    PRIMARY KEY (AdressId))
;

CREATE TABLE IF NOT EXISTS carrentdb.Customer(
	CustomerId INT NOT NULL AUTO_INCREMENT,
    Vorname VARCHAR(45) NULL,
    Nachname VARCHAR(45) NULL,
    Telefonnummer VARCHAR(45) NULL,
    FK_Adressnummer INT NULL,
    PRIMARY KEY (CustomerId),
    FOREIGN KEY (FK_Adressnummer) REFERENCES carrentdb.Adress(AdressID))
;

DELIMITER //
CREATE PROCEDURE InsertIntoCustomer 
(
	IN iVorname VARCHAR(45),
    IN iNachname VARCHAR(45),
    IN iTelefonnummer VARCHAR(45),
    IN iStrasse VARCHAR(45),
    IN iStrassennummer VARCHAR(45),
    IN iPLZ VARCHAR(45),
    IN iOrt VARCHAR(45)
)
BEGIN
	DECLARE lastAdressId INT;
    
	INSERT INTO Adress (Strasse, Strassennummer, PLZ, Ort)
	VALUES
	(iStrasse, iStrassennummer, iPLZ, iOrt);
    
    SET lastAdressId = LAST_INSERT_ID();
    
    INSERT INTO Customer (Vorname, Nachname, Telefonnummer, FK_Adressnummer)
    VALUES
    (iVorname, iNachname, iTelefonnummer, lastAdressId);
    
END //
DELIMITER ;


