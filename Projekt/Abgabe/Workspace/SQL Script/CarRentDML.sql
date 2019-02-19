USE carrentdb;

INSERT INTO DailyPrice (Waehrung, Preis, Datum)
VALUES
	('CHF', 125.00, NOW());
    
INSERT INTO CarClass (CarClass, FK_DailyPriceId)
VALUES
	('Sport', 1),
	('Luxus', 1);

INSERT INTO Cars ( Seriennummer, Marke, Farbe, FK_CarClassId)
VALUES
	('AUSE12388', 'VW', 'Blau', 2),
    ('OIIEW88457', 'BMW', 'Schwarz', 1);

INSERT INTO Adress (Strasse, Strassennummer, PLZ, Ort)
VALUES
	('HANS MUSTER STRASSE', '2', '9000', 'St. Gallen'),
    ('FRITZ TEST STRASSE', '6', '9000', 'St. Gallen');

INSERT INTO Customer (Vorname, Nachname, Telefonnummer, FK_AdressId)
VALUES
	('Hans', 'Muster', '+41 HANS MUSTER', 1),
    ('Fritz', 'Test', '+41 FRITZ TEST', 2);
    

    #SELECT * FROM Cars;
    #SELECT * FROM DailyPrice;
    #SELECT * FROM CarClass;
    #SELECT * FROM Adress;
    #SELECT * FROM Customer;
    #DELETE FROM Customer WHERE CustomerId = 3;
    #SELECT * FROM Customer INNER JOIN Adress ON Customer.CustomerId = Adress.AdressId
   