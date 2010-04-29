create table dbo.Data(
	Id nvarchar(32),
	GlobalId nvarchar(32) primary key,
	RevisionDate datetime,
	Number int,
	Name text,
	IsDeleted bit,
	Updated decimal
);