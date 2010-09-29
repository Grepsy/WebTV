USE WebTV

INSERT INTO Customer (Name, Password) VALUES ('Hans Pots', 'bananas')

INSERT INTO Animation (Name, Message, CustomerId) VALUES ('Autohandelaar', 'Nu een halve auto voor de prijs van twee!', 1)
INSERT INTO Animation (Name, Message, CustomerId) VALUES ('Koekenbakker', 'Koeken nu voor twee euro!', 1)

INSERT INTO PropertyDescriptor (Name) VALUES ('Omschrijving')
INSERT INTO PropertyDescriptor (Name) VALUES ('Prijs')

INSERT INTO AnimationPropertyDescriptor VALUES (1, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (1, 2)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 2)

INSERT INTO Media (AnimationId, Url) VALUES (1, 'http://www.whereisacar.com/images/cars/bill-gates-car.jpg')
INSERT INTO Media (AnimationId, Url) VALUES (2, 'http://rozekoek.nl/wp-content/uploads/2007/11/blauwe_koek_artist_impression.jpg')

INSERT INTO Property (PropertyDescriptorId, MediaId, Value) VALUES (1, 1, 'Super toffe auto!')
INSERT INTO Property (PropertyDescriptorId, MediaId, Value) VALUES (2, 1, '€ 1200,-')
INSERT INTO Property (PropertyDescriptorId, MediaId, Value) VALUES (1, 2, 'Heerlijke koek!')
INSERT INTO Property (PropertyDescriptorId, MediaId, Value) VALUES (2, 2, '5 euro')
