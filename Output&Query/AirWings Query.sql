--create database
--create database AirWings

--create registration table
create table register( 
regid int identity(1,1) PRIMARY KEY,
username varchar(60) NOT NULL,
psword varchar(20) NOT NULL,
emailId varchar(255) not null,
phoneNumber varchar(10) not null);

--create flightdetails able
create table flightdetails(
flightId int identity(1001,1) PRIMARY KEY,
flightName varchar(50) not null,
economic bit not null,
business bit not null
)

--insert values into flightdetails table
insert into  flightdetails values('AirAsia',0,1)
insert into  flightdetails values('GoFirst',1,1)
insert into  flightdetails values('AirIndia',1,1)
insert into  flightdetails values('SpiceJet',1,1)
insert into  flightdetails values('IndiGo',0,1)
insert into  flightdetails values('AirAsia',1,1)
insert into  flightdetails values('SpiceJet',1,1)
insert into  flightdetails values('GoFirst',1,1)
insert into  flightdetails values('AirAsia',1,0)
insert into  flightdetails values('Vistara',1,1)

select * from flightdetails
--create tripdetails table
create table tripdetails(
tripId int identity(1,1) PRIMARY KEY,
flightId int FOREIGN KEY REFERENCES flightdetails(flightId) not null,
origin INT not null,
destination INT not null,
arrivaltime datetime not null,
departuretime datetime not null,
availableseats int not null,
businessavailableseats int not null,
fare float not null,
businessfare float not null)


--insert values into tripdetails table
insert into tripdetails values(1001,2,1, '2022-11-14 09:30:00','2022-11-14 08:00:00',10,5,10000,15000)
insert into tripdetails values(1002,1,2, '2022-11-14 09:00:00','2022-11-14 07:30:00',10,5,10000,15000)
insert into tripdetails values(1003,2,3, '2022-11-14 13:30:00','2022-11-14 11:30:00',10,5,10000,15000)
insert into tripdetails values(1004,2,4, '2022-11-14 13:30:00','2022-11-14 11:30:00',5,8,10000,15000)
insert into tripdetails values(1005,2,3, '2022-11-14 13:30:00','2022-11-14 12:30:00',7,5,5000,8000)
insert into tripdetails values(1006,5,1, '2022-11-14 7:30:00','2022-11-14 6:30:00',10,5,10000,15000)

select * from tripdetails
--create citydetails table
create table citydetails(
cityId int identity(1,1) PRIMARY KEY,
cityname varchar(30) NOT NULL)

--insert values into citydetails
insert into citydetails(cityname) values('Delhi')
insert into citydetails(cityname) values('Chennai')
insert into citydetails(cityname) values('Coimbatore')
insert into citydetails(cityname) values('Trichy')
insert into citydetails(cityname) values('Mumbai')
insert into citydetails(cityname) values('Kolkata')


--create paymentmode table
create table paymentmode(
paymodeid int identity(1,1) PRIMARY KEY,
paymode varchar(30) NOT NULL)

--insert values into paymentmode table
insert into paymentmode(paymode) values('Credit Card')
insert into paymentmode(paymode) values('Debit Card')
insert into paymentmode(paymode) values('Internet banking')


--create offer table
create table offer(
offerid int identity(1,1) PRIMARY KEY,
offername varchar(20) NOT NULL,
offerprice int NOT NULL,
isActive bit default 1)


--insert values into offer table
insert into offer(offername,offerprice) values('Diwali1000','1000')
insert into offer(offername,offerprice) values('Light700','700')
insert into offer(offername,offerprice) values('Fire1500','1500')
insert into offer(offername,offerprice) values('crack2000','2000')


--create ticket details table
create table ticketdetails(
pnr int identity(1,1) PRIMARY KEY,
tripid int FOREIGN KEY REFERENCES tripdetails(tripId) not null,
offerid int FOREIGN KEY REFERENCES offer(offerid) not null,
paymodeid int FOREIGN KEY REFERENCES paymentmode(paymodeid) not null,
fare float not null,
discount float not null,
taxamount float not null,
netamount float not null,
ticketstatus int not null,
passengername varchar(100) not null,
Emailaddress varchar(255) not null,
passengerpnumber varchar(15) not null
)

