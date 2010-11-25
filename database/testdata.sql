USE WebTV

INSERT INTO Customer (Name, Password) VALUES ('Hans Pots', 'bananas',1)
INSERT INTO Customer (Name, Password) VALUES ('Eelco', 'eelcotest',0)
INSERT INTO Customer (Name, Password) VALUES ('Robert', 'robertest',1)
INSERT INTO Customer (Name, Password) VALUES ('Bas', 'bastest',0)
INSERT INTO Customer (Name, Password) VALUES ('Ambert', 'ambertest',1)

INSERT INTO Animation (Name, Message, CustomerId) VALUES ('Autohandelaar', 'Nu een halve auto voor de prijs van twee!', 1)
INSERT INTO Animation (Name, Message, CustomerId) VALUES ('Koekenbakker', 'Koeken nu voor twee euro!', 1)

INSERT INTO PropertyDescriptor (Name) VALUES ('Omschrijving')
INSERT INTO PropertyDescriptor (Name) VALUES ('Prijs')

INSERT INTO AnimationPropertyDescriptor VALUES (1, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (1, 2)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 2)

INSERT INTO MediaSet (Name, AnimationId) VALUES ('Week 1', 1)