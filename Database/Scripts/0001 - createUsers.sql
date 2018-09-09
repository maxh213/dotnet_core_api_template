create table users (
	Id SERIAL,
	FirstName varchar,
	LastName varchar,
	Email varchar,
	SignUpDate datetime DEFAULT now()
);


