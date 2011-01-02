USE WebTV

INSERT INTO Customer (Name, Password, IsAdmin,Enabled) VALUES ('Hans Pots', 'bananas' ,1,1)
INSERT INTO Customer (Name, Password, IsAdmin,Enabled) VALUES ('Eelco', 'eelcotest', 0, 1)
INSERT INTO Customer (Name, Password, IsAdmin,Enabled) VALUES ('Robert', 'roberttest', 1, 1)
INSERT INTO Customer (Name, Password, IsAdmin,Enabled) VALUES ('Bas', 'bastest', 0, 1)
INSERT INTO Customer (Name, Password, IsAdmin,Enabled) VALUES ('Ambert', 'ambertest', 1, 1)

INSERT INTO Animation (Name, CustomerId) VALUES ('multimate', 1)
INSERT INTO Animation (Name, CustomerId, MediaGroupedBy) VALUES ('restaurant', 2, 4)

INSERT INTO Animation (Name, CustomerId) VALUES ('makelaar', 3)
INSERT INTO Animation (Name, CustomerId) VALUES ('autohandelaar', 4)

INSERT INTO PropertyDescriptor (Name) VALUES ('Naam')
INSERT INTO PropertyDescriptor (Name) VALUES ('Omschrijving')
INSERT INTO PropertyDescriptor (Name) VALUES ('Prijs')

INSERT INTO AnimationPropertyDescriptor VALUES (1, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (1, 2)
INSERT INTO AnimationPropertyDescriptor VALUES (1, 3)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 1)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 2)
INSERT INTO AnimationPropertyDescriptor VALUES (2, 3)

INSERT INTO MediaSet (Name, Message, AnimationId) VALUES ('Week 1', 'Extra korting deze week!', 1)
INSERT INTO MediaSet (Name, Message, AnimationId) VALUES ('Week 2', 'Winterse kortingen', 1)

INSERT INTO MediaSet (Name, Message, AnimationId) VALUES ('Maand december', 'Extra korting deze week!', 2)
INSERT INTO MediaSet (Name, Message, AnimationId) VALUES ('Maand januari', 'Winterse kortingen', 2)
