DROP Table AirportRoute;DROP TABLE Plane;DROP TABLE Airport;DROP TABLE Route;DROP TABLE Company;

CREATE TABLE Company
(
	CompanyId int primary key IDENTITY,
	CompanyName Varchar(256) NOT NULL
);
CREATE TABLE Route
(
	RouteId int primary key IDENTITY,
	Company_CompanyId int,
	FOREIGN KEY (Company_CompanyId) REFERENCES Company(CompanyId)
);
CREATE TABLE AirPort
(
	IATA VARCHAR(3) PRIMARY KEY,
	AirportName VARCHAR(256) NOT NULL,
	AirportAddress VARCHAR(256) NOT NULL,
	CONSTRAINT CH_IATA CHECK (DATALENGTH(IATA) = 3 AND (upper(IATA) = IATA collate Latin1_General_BIN2))
);
CREATE TABLE Plane
(
	SerialNum VARCHAR(256) PRIMARY KEY,
	Company_CompanyId int,
	Route_RouteId int,
	Airport_IATA VARCHAR(3),
	FOREIGN KEY (Company_CompanyId) REFERENCES Company(CompanyId),
	FOREIGN KEY (Route_RouteId) REFERENCES Route(RouteId),
	FOREIGN KEY (Airport_IATA) REFERENCES Airport(IATA)
);
CREATE TABLE AirportRoute
(
	AirportRouteId int primary key IDENTITY,
	Airport_IATA VARCHAR(3),
	Route_RouteId INT,
	FOREIGN KEY (Route_RouteId) REFERENCES Route(RouteId),
	FOREIGN KEY (Airport_IATA) REFERENCES Airport(IATA)
);
