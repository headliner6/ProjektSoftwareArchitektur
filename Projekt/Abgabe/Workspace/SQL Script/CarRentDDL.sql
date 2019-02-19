CREATE DATABASE IF NOT EXISTS carrentdb;

USE carrentdb;

CREATE TABLE IF NOT EXISTS carrentdb.DailyPrice(
	DailyPriceId INT NOT NULL AUTO_INCREMENT,
    Waehrung VARCHAR(45) NULL,
    Preis DECIMAL NULL,
    Datum DATETIME NULL,
    PRIMARY KEY (DailyPriceId))
;

CREATE TABLE IF NOT EXISTS carrentdb.CarClass(
	CarClassId INT NOT NULL AUTO_INCREMENT,
    CarClass ENUM('Luxus', 'Normal', 'Sport'),
    FK_DailyPriceId INT NULL,
    PRIMARY KEY (CarClassId),
    FOREIGN KEY (FK_DailyPriceId) REFERENCES carrentdb.DailyPrice(DailyPriceId))
;
    
CREATE TABLE IF NOT EXISTS carrentdb.Cars (
	CarId INT NOT NULL AUTO_INCREMENT,
	Marke VARCHAR(45) NULL,
	Seriennummer VARCHAR(45) NULL,
	Farbe VARCHAR(45) NULL,
	Vermietet BOOL DEFAULT FALSE,
    FK_CarClassId INT NULL,
    PRIMARY KEY (CarId),
    FOREIGN KEY (FK_CarClassId) REFERENCES carrentdb.CarClass(CarClassId))
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
    FK_AdressId INT NULL,
    PRIMARY KEY (CustomerId),
    FOREIGN KEY (FK_AdressId) REFERENCES carrentdb.Adress(AdressID))
;

DELIMITER //
CREATE PROCEDURE InstertIntoCar
(	
	#Parameter for DailyPrice
	IN iWaehrung VARCHAR(45),
    IN iPreis DECIMAL,
    
    #Parameter for CarClass
    IN iCarClass VARCHAR(45),
    
    #Parameter for Car
    IN iMarke VARCHAR(45),
    IN iSeriennummer VARCHAR(45),
    IN iFarbe VARCHAR(45)
)
BEGIN
	DECLARE lastDailyPriceId INT;
    DECLARE lastCarClassId INT;
    
    #Existiert die Währung schon, wird der Preis und das Tagesdatum angepasst
    #Ansonsten wird die gefundene Währung updatet
    IF(EXISTS(SELECT * FROM DailyPrice WHERE Waehrung = iWaehrung))
    THEN
		UPDATE DailyPrice SET Preis = iPreis, Datum = NOW()
        WHERE Waehrung = iWaehrung;
    ELSE
		INSERT INTO DailyPrice (Waehrung, Preis, Datum)
		VALUES
			(iWaehrung, iPreis, NOW());
	END IF;
    
    SET lastDailyPriceId = (SELECT DailyPriceId FROM DailyPrice ORDER BY DailyPriceId DESC LIMIT 1);
    
    #Existiert schon eine Autoklasse mit einem bestimmten Tagespreis, wird psydomässig die AutoKlasse updatet
    #Ansonsten wird eine neue Autoklass mit dem letzten Tagespreis Kombination erstellt
    IF (EXISTS(SELECT * FROM CarClass WHERE CarClass = iCarClass AND FK_DailyPriceId = lastDailyPriceId))
    THEN
		UPDATE CarClass SET CarClass = iCarClass, FK_DailyPriceId = lastDailyPriceId
        WHERE CarClass = iCarClass AND FK_DailyPriceId = lastDailyPriceId; 
    ELSE
		INSERT INTO CarClass (CarClass, FK_DailyPriceId)
		VALUES
			(iCarClass, lastDailyPriceId);
    END IF;
    
    SET lastCarClassId = (SELECT CarClassId FROM CarClass ORDER BY CarClassId DESC LIMIT 1);
    
    INSERT INTO Cars ( Seriennummer, Marke, Farbe, FK_CarClassId)
	VALUES
		(iSeriennummer, iMarke, iFarbe, lastCarClassId);
END //
DELIMITER ;


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
    
    INSERT INTO Customer (Vorname, Nachname, Telefonnummer, FK_AdressId)
    VALUES
    (iVorname, iNachname, iTelefonnummer, lastAdressId);
END //
DELIMITER ;


