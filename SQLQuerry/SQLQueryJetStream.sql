USE SkiServicePA;
GO

insert into dbo.Service(ServiceName)
Values
('Kleiner-Service'),
('Grosser-Service'),
('Rennski-Service'),
('Bindugen montieren und Einstellen'),
('Heisswachsen'),
('Fell zuschneiden');
GO

insert into dbo.Priority(PriorityName)
Values
('Express'),
('Standard'),
('Tief');
GO

insert into dbo.Status(StatusName)
Values
('Offen'),
('In Arbeit'),
('Fertig'),
('Gelöscht');
GO

insert into dbo.Users(UserName, Password)
Values
('Raphi', 'M295');
GO

Select * from dbo.Service;
GO
Select * from dbo.Priority;
GO
Select * from dbo.Users;
GO
GO
Select * from dbo.Status;
GO
Select * from dbo.Registration;
GO