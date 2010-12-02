USE WebTV

INSERT INTO Customer (Name, Password, IsAdmin) VALUES ('Hans Pots', 'bananas' ,1)
INSERT INTO Customer (Name, Password, IsAdmin) VALUES ('Eelco', 'eelcotest', 0)
INSERT INTO Customer (Name, Password, IsAdmin) VALUES ('Robert', 'robertest', 1)
INSERT INTO Customer (Name, Password, IsAdmin) VALUES ('Bas', 'bastest', 0)
INSERT INTO Customer (Name, Password, IsAdmin) VALUES ('Ambert', 'ambertest', 1)

INSERT INTO Animation (Name, CustomerId) VALUES ('Autohandelaar', 1)
INSERT INTO Animation (Name, CustomerId, MediaGroupedBy) VALUES ('Koekenbakker', 1, 4)

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