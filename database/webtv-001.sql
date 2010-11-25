USE master

CREATE DATABASE WebTV
GO

USE WebTV

CREATE TABLE Customer (
  CustomerId INT PRIMARY KEY IDENTITY(1,1),
  Name NVARCHAR(255) NOT NULL,
  Password NVARCHAR(255) NOT NULL
)

CREATE TABLE Animation (
  AnimationId INT PRIMARY KEY IDENTITY(1,1),
  CustomerId INT NOT NULL,
  Name NVARCHAR(255) NOT NULL,
  HasMedia BIT
  FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
)

CREATE TABLE PropertyDescriptor (
  PropertyDescriptorId INT PRIMARY KEY IDENTITY(1,1),
  Name NVARCHAR(255) NOT NULL,
  DefaultValue NVARCHAR(255),
  Required BIT,
  ValidationRegEx NVARCHAR(255)
)

CREATE TABLE AnimationPropertyDescriptor (
  AnimationId INT NOT NULL,
  PropertyDescriptorId INT NOT NULL,
  PRIMARY KEY (AnimationId, PropertyDescriptorId),
  FOREIGN KEY (AnimationId) REFERENCES Animation(AnimationId),
  FOREIGN KEY (PropertyDescriptorId) REFERENCES PropertyDescriptor(PropertyDescriptorId)
)

CREATE TABLE MediaSet (
  MediaSetId INT PRIMARY KEY IDENTITY(1,1),
  AnimationId INT NOT NULL,
  Name NVARCHAR(255) NOT NULL DEFAULT '',
  Message NVARCHAR(255),
  StartDate DATE,
  EndDate DATE,
  FOREIGN KEY (AnimationId) REFERENCES Animation(AnimationId) ON DELETE CASCADE
)

CREATE TABLE Media (
  MediaId INT PRIMARY KEY IDENTITY(1,1),
  MediaSetId INT NOT NULL,
  Filename NVARCHAR(255),
  MimeType NVARCHAR(255),
  Active BIT NOT NULL DEFAULT 1,
  FOREIGN KEY (MediaSetId) REFERENCES MediaSet(MediaSetId) ON DELETE CASCADE
)

CREATE TABLE Property (
  PropertyId INT PRIMARY KEY IDENTITY(1,1),
  PropertyDescriptorId INT NOT NULL,
  MediaId INT NOT NULL,
  Value NVARCHAR(255),
  FOREIGN KEY (PropertyDescriptorId) REFERENCES PropertyDescriptor(PropertyDescriptorId) ON DELETE CASCADE,
  FOREIGN KEY (MediaId) REFERENCES Media(MediaId) ON DELETE CASCADE
)

CREATE TABLE Log (
  PlayLogId INT PRIMARY KEY IDENTITY(1,1),
  AnimationId INT NOT NULL,
  PlayedAt DATETIME NOT NULL,
  FOREIGN KEY (AnimationId) REFERENCES Animation(AnimationId)
)