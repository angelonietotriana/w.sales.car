-- rent_car.dbo.car definition

-- Drop table

-- DROP TABLE rent_car.dbo.car;

CREATE TABLE rent_car.dbo.car (
	IdCar int IDENTITY(1,1) NOT NULL,
	Make nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Capacity int NOT NULL,
	Mileage int NOT NULL,
	Cost int NOT NULL,
	Model int NOT NULL,
	SubModel int NOT NULL,
	YearModel int NOT NULL,
	Available bit NOT NULL,
	CONSTRAINT PK_car PRIMARY KEY (IdCar)
);


-- rent_car.dbo.location definition

-- Drop table

-- DROP TABLE rent_car.dbo.location;

CREATE TABLE rent_car.dbo.location (
	IdLocation int IDENTITY(1,1) NOT NULL,
	Available bit NOT NULL,
	[Zone] nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Locality nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ZipCode int NOT NULL,
	CONSTRAINT PK_location PRIMARY KEY (IdLocation)
);


-- rent_car.dbo.reserve definition

-- Drop table

-- DROP TABLE rent_car.dbo.reserve;

CREATE TABLE rent_car.dbo.reserve (
	IdReserve int IDENTITY(1,1) NOT NULL,
	ReserveDate datetime2 NOT NULL,
	CollectDate datetime2 NOT NULL,
	DeliveryDate datetime2 NULL,
	IdCollectLocation int NOT NULL,
	IdDeliveryLocation int NULL,
	IdCar int NOT NULL,
	IdClient int NOT NULL,
	BaseCost real NOT NULL,
	OthersCosts real NOT NULL,
	DoSale bit NOT NULL,
	SN nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT N'' NOT NULL,
	CONSTRAINT PK_reserve PRIMARY KEY (IdReserve)
);


-- rent_car.dbo.sale definition

-- Drop table

-- DROP TABLE rent_car.dbo.sale;

CREATE TABLE rent_car.dbo.sale (
	IdSale int IDENTITY(1,1) NOT NULL,
	SaleDate datetime2 NOT NULL,
	IdCar int NOT NULL,
	IdUser int NOT NULL,
	IdVendor int NOT NULL,
	Status nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	TotalSale real NOT NULL,
	SnReserve nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	IdDeliveryLocation int NOT NULL,
	CONSTRAINT PK_sale PRIMARY KEY (IdSale)
);


-- rent_car.dbo.[user] definition

-- Drop table

-- DROP TABLE rent_car.dbo.[user];

CREATE TABLE rent_car.dbo.[user] (
	IdUser int IDENTITY(1,1) NOT NULL,
	Document int NOT NULL,
	DocumentType nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Phone nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PaymentType nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	AmountApproved real NULL,
	State nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (IdUser)
);