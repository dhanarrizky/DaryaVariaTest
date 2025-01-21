-- Insert dummy data for Accounts
insert into Accounts ([Name], PhoneNumber, [Address], BankAccount)
values 
('John Doe', '+6281234567890', 'Jl. Merdeka No. 1, Jakarta', '123456789012'),
('Jane Smith', '+6289876543210', 'Jl. Sudirman No. 5, Bandung', '987654321098');

-- Insert dummy data for AccountRole
insert into AccountRole ([Name]) 
values 
('Admin'), 
('User');

-- Insert dummy data for LoginAuth
insert into LoginAuth (Username, Email, PasswordHash, UserRole, AccountId)
values
('johndoe', 'johndoe@example.com', '$2a$12$eGV/.ABC123', 'Admin', 1), -- Hash bcrypt untuk 'password123'
('janesmith', 'janesmith@example.com', '$2a$12$eGV/.DEF456', 'User', 2); -- Hash bcrypt untuk 'mypassword'

-- Insert dummy data for AccountDetail
insert into AccountDetail (AccountId, AccountType) 
values 
(1, 'Individual'), 
(2, 'Company');

-- Insert dummy data for Products
insert into Products (AccountId, [Name], Price)
values 
(1, 'Product A', 50000), 
(2, 'Product B', 75000);

-- Insert dummy data for UnitType
insert into UnitType ([Name]) 
values 
('Piece'), 
('Box');

-- Insert dummy data for Inventory
insert into Inventory (ProductId, UnitTypeId, Quantity) 
values 
(1, 1, 100), 
(2, 2, 50);

-- Insert dummy data for Transactions
insert into [Transactions] (AccountId, AccountType, OrderDate, DeliveryDate, Note, Discount, Tax, TotalAmount, [Status])
values 
(1, 'Individual', '2025-01-01', '2025-01-05', 'First order', 5000, 10000, 150000, 'Checked'), 
(2, 'Company', '2025-01-10', '2025-01-15', 'Corporate order', 7500, 15000, 250000, 'Approved'),
(1, 'Individual', '2025-01-01', '2025-01-05', 'Second order', 5000, 10000, 150000, 'Panding');

-- Insert dummy data for ProductsTransaction
insert into ProductsTransaction (TransactionId, ProductId, Quantity, Price, TotalAmount)
values 
(1, 1, 2, 50000, 100000), 
(2, 2, 5, 75000, 375000);

-- Insert dummy data for InformationOfPayment
insert into InformationOfPayment (TransactionId, FromBankNumber, ToBankNumber, PaymentDate, PaymentAmount, PaymentMethod, Note)
values 
(1, '123456789012', '112233445566', '2025-01-02', 150000, 'Bank Transfer', 'Payment for order 1'), 
(2, '987654321098', '667788990011', '2025-01-11', 250000, 'Credit Card', 'Payment for corporate order');
