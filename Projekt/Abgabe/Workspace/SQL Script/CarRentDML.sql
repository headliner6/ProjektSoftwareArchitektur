USE carrentdb;

INSERT INTO Cars ( Seriennummer, Marke, Typ, Farbe)
VALUES
	('AUSE12388', 'VW', 'Sport', 'Blau'),
    ('OIIEW88457', 'BMW', 'Sport', 'Schwarz');

INSERT INTO Adress (Strasse, Strassennummer, PLZ, Ort)
VALUES
	('HANS MUSTER STRASSE', '2', '9000', 'St. Gallen'),
    ('FRITZ TEST STRASSE', '6', '9000', 'St. Gallen');

INSERT INTO Customer (Vorname, Nachname, Telefonnummer, FK_Adressnummer)
VALUES
	('Hans', 'Muster', '+41 HANS MUSTER', 1),
    ('Fritz', 'Test', '+41 FRITZ TEST', 2);
    
    #SELECT * FROM Cars;
    #SELECT * FROM Adress;
    #SELECT * FROM Customer;
    #DELETE FROM Customer WHERE CustomerId = 3;
    #SELECT * FROM Customer INNER JOIN Adress ON Customer.CustomerId = Adress.AdressId
   