CREATE TABLE INVENTORY(
inventory_PID int Primary Key NOT NULL,
i_productName varchar(50) NOT NULL,
i_productBrand varchar(50) NOT NULL,
i_productModel varchar(50) NOT NULL,
productOrdered int NOT NULL,
productQTY int,
lastUpdated datetime NOT NULL
);

CREATE TABLE PRODUCT(
productName varchar(50) NOT NULL,
productBrand varchar(50) NOT NULL,
PID int primary key NOT NULL,
productCost decimal(6, 2) NOT NULL,
productModel varchar(50) NOT NULL,
modelNumber varchar(50) NOT NULL
);

CREATE TABLE SUPPLIER (
supplierID int NOT NULL Primary key,
order_Num int NOT NULL,
supplierName varchar(50) NOT NULL,
productName varchar(50) NOT NULL,
S_streetNum int NOT NULL,
S_streetName varchar(50) NOT NULL,
S_City varchar(50) NOT NULL,
S_State varchar(25) NOT NULL,
S_zipCode int NOT NULL
);

CREATE TABLE STORE (
storeID int primary key,
storeName varchar(50) NOT NULL,
store_streetNum int NOT NULL,
store_streetName varchar(50) NOT NULL,
store_City varchar(50)NOT NULL,
store_State varchar(25)NOT NULL,
store_Zip int NOT NULL,
);

CREATE TABLE CUSTOMER (
fName varchar(25) NOT NULL,
mInit char,
lName varchar(25) NOT NULL,
phone_Number varchar(10) NOT NULL,
customerID int primary key NOT NULL,
c_streeName varchar(30) NOT NULL,
c_streeNum int NOT NULL,
c_City varchar(50) NOT NULL,
c_State varchar(25) NOT NULL,
c_zipCode int NOT NULL
);

CREATE TABLE EMPLOYEE (
employeeID int primary key NOT NULL,
storeID int NOT NULL,
firstName varchar(25) NOT NULL,
mInit char,
lastName varchar(25) NOT NULL,
jobTitle varchar(25) NOT NULL,
supervisor varchar(25) NOT NULL,
e_StreetNum int NOT NULL,
e_StreetName varchar(50) NOT NULL, 
e_City_State varchar(25) NOT NULL
);

CREATE TABLE SALES (
s_productName varchar(50) NOT NULL,
s_productModel varchar(50) NOT NULL,
s_productBrand varchar(50) NOT NULL,
s_productCost decimal(6, 2) NOT NULL,
orderTotal decimal(6, 2) NOT NULL,
discountPercentage decimal(6,2),
transactionID int NOT NULL,
transactionDate AS getdate(),
sales_PID int NOT NULL,
customerID int NOT NULL, 
employeeID int NOT NULL,
retailCost decimal(6, 2) NOT NULL,
salesUpdate int NOT NULL Foreign Key References INVENTORY(inventory_PID)
);

CREATE TABLE SUP_TRANS(
transaction_PID int NOT NULL,
productName varchar(50) NOT NULL,
orderNum int NOT NULL primary key,
supplierUpdate int NOT NULL Foreign Key References INVENTORY(inventory_PID)
);

ALTER TABLE SALES ADD FOREIGN KEY(sales_PID) REFERENCES PRODUCT (PID);
ALTER TABLE SALES ADD FOREIGN KEY(customerID) REFERENCES CUSTOMER (customerID);
ALTER TABLE SALES ADD FOREIGN KEY(employeeID) REFERENCES EMPLOYEE (employeeID);
ALTER TABLE EMPLOYEE ADD FOREIGN KEY(storeID) REFERENCES STORE (storeID);
ALTER TABLE SUPPLIER ADD FOREIGN KEY (order_Num) REFERENCES SUP_TRANS (orderNum);
ALTER TABLE SUP_TRANS ADD FOREIGN KEY (transaction_PID) REFERENCES PRODUCT (PID);
ALTER TABLE INVENTORY ADD FOREIGN KEY (productOrdered) REFERENCES PRODUCT (PID);