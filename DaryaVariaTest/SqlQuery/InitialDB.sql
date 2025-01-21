use master;

use DaryaVariaApp;

create database DaryaVariaApp;

-- users table group

create table Accounts(
    AccountId int identity(1,1) primary key,
    [Name] varchar(100) not null,
    PhoneNumber varchar(16) not null unique check (PhoneNumber like '+[0-9]%' or PhoneNumber like '[0-9]%'),
    [Address] varchar(max) not null,
    BankAccount varchar(20) not null unique,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime,
);


create table AccountRole(
    Id int identity(1,1) primary key,
    [Name] varchar(15) not null,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime
);

create table LoginAuth(
    Username varchar(50) not null unique,
    Email varchar(255) not null unique,
    PasswordHash varchar(200) not null unique,
    UserRole varchar(15) not null,
    AccountId int not null,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime,
    foreign key (AccountId) references Accounts(AccountId)
);

create table AccountDetail(
    Id int identity(1,1) primary key,
    AccountId int not null,
    AccountType varchar(15) check (AccountType = 'Individual' or AccountType = 'Company'),
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime,
    foreign key (AccountId) references Accounts(AccountId),
)


-- product table group
create table Products (
    Id int identity(1,1) primary key,
    AccountId int not null,
    [Name] varchar(15) not null,
    Price decimal not null,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime,
    foreign key (AccountId) references Accounts(AccountId)
);

create table UnitType(
    Id int identity(1,1) primary key,
    [Name] varchar(10) not null,
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime
);

create table Inventory (
    Id int identity(1,1) primary key,
    ProductId int not null,
    UnitTypeId int not null,
    Quantity int default 0,
    foreign key (ProductId) references Products(Id),
    foreign key (UnitTypeId) references UnitType(Id),
    CreatedAt datetime not null default current_timestamp,
    UpdatedAt datetime default current_timestamp,
    DeletedAt datetime
);

-- transaction table group
-- Setiap Transaksi harus menyimpan informasi tanggal pemesanan , tanggal pengiriman , informasi Term Of Payment , catatan dan jumlah nominal.

create table [Transactions] (
    Id int identity(1,1) primary key,
    AccountId int not null,
    AccountType varchar(15) check (AccountType = 'Individual' or AccountType = 'Company'),
    OrderDate datetime not null,
    DeliveryDate datetime,
    Note varchar(max),
    Discount decimal(18,2) not null,
    Tax decimal(18,2) not null,
    TotalAmount decimal(18,2) not null,
    [Status] varchar(15),
    foreign key (AccountId) references Accounts(AccountId)
)

create table ProductsTransaction(
    Id int identity(1,1) primary key,
    TransactionId int not null,
    ProductId int not null,
    quantity int default 1,
    Price decimal(18,2),
    TotalAmount decimal(18,2) not null,
    foreign key (TransactionId) references [Transactions](Id)
        on delete cascade on update cascade,
    foreign key (ProductId) references Products(Id)
        on delete cascade on update cascade
)

create table InformationOfPayment (
    Id int identity(1,1) primary key,
    TransactionId int not null,
    FromBankNumber varchar(20) not null,
    ToBankNumber varchar(20) not null, 
    PaymentDate datetime not null,
    PaymentAmount decimal(18,2) not null,
    paymentMethod varchar(50),
    Note varchar(max),
    foreign key (TransactionId) references [Transactions](Id)
        on delete cascade on update cascade
)
