USE [master]
GO
CREATE DATABASE [{0}]
GO
USE [{0}]
GO
CREATE TABLE [{1}]
(
      Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
      [start] DATETIME NOT NULL,
      [end] DATETIME NOT NULL
);
GO
INSERT INTO [{1}] ([start], [end]) VALUES ('2020-10-10', '2021-08-25');
INSERT INTO [{1}] ([start], [end]) VALUES ('2019-10-10', '2020-05-30');
INSERT INTO [{1}] ([start], [end]) VALUES ('2018-10-10', '2019-01-15');
INSERT INTO [{1}] ([start], [end]) VALUES ('2017-10-10', '2018-03-05');
INSERT INTO [{1}] ([start], [end]) VALUES ('2016-10-10', '2017-09-23');
INSERT INTO [{1}] ([start], [end]) VALUES ('2015-10-10', '2016-12-11');