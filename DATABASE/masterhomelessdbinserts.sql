print '' print '*** Insert Records ***'
print '' print '*** using database masterhomelessdb ***'
GO
USE [masterhomelessdb]
GO

/*
    CREATOR: ???
    CREATED: ???
    SUMMARY: initial creation
    LAST UPDATED BY: Liam Easton
    LAST UPDATED: 4/11/2024
    WHAT WAS CHANGED: added more rows to fill out datagrids
*/
print '' print '*** inserting LogConfiscatedItem test records ***'
GO
INSERT INTO	[dbo].[LogConfiscatedItem]
		([ItemsConfiscated], [ConfiscationDate], [ReasonForConfiscation])
	VALUES
		('flashlight, toothbrush, and some tape', '2024-01-24', 'he was fighting someone with them'),
		('Gun', '2023-02-16', 'the individual was threatening others, and we dont allow weapons in the shelter'),		
		('Knife', '2021-06-16', 'she stole one from the kitchen, and the member is not allowed to carry weapons'),
        ('cell phone and charger', '2022-11-30', 'caught using it during quiet hours'),
	    ('alcohol bottles', '2023-04-05', 'found hidden in personal belongings'),
        ('illegal drugs', '2023-07-19', 'discovered during routine room inspection'),
        ('stolen electronics', '2024-03-12', 'items reported missing by other shelter residents'),
        ('chemical substances', '2022-03-28', 'unknown substances, confiscated for safety analysis'),
	    ('fireworks', '2022-07-04', 'confiscated before Independence Day celebrations for safety concerns'),
        ('sharp objects', '2023-11-15', 'potential danger to residents')
GO

/*
    CREATOR: Matthew Baccam
    CREATED: 1/25/2023
    SUMMARY: initial creation
    LAST UPDATED BY: Darryl Shirley
    LAST UPDATED: 2/07/2024
    WHAT WAS CHANGED: Added more events
    LAST UPDATED BY: Liam Easton
    LAST UPDATED: 4/11/2024
    WHAT WAS CHANGED: Added more events
*/
print '' print '*** inserting Event test records ***'
GO
INSERT INTO [dbo].[Event] 
    ([EventName], [Description], [VolunteersNeeded]) 
    VALUES  ('Food drive', 'Canned food collection', 9),
            ('Blanket drive', 'Collecting blankets for shelters', 15),
            ('5K run/walk', 'Annual fundraising run/walk event', 25),
            ('10k run/walk', 'Annual fundraising run/walk event', 20),
            ('15k run/walk', 'Annual fundraising run/walk event', 0),
		    ('Fight Club', 'We dont talk about fight club', 0),
		    ('Jobs Fair', 'Hosting a local jobs fair for our clients', 0) ,
            ('Community Cleanup', 'Cleaning up local parks and streets', 30),
            ('Holiday Toy Drive', 'Collecting toys for children in need', 12),
            ('Health Fair', 'Providing health screenings and education', 8),
            ('Can Drive', 'Recycling cans to help raise money, and clean up the streets', 15)
GO

/*
    <summary>
    Creator: ???
    Created: ???
    Summary: initial creation
    Last Updated By: Liam Easton
    Last Updated: 4/11/2024
    What Was Changed: Added more rows to match the event table inserts
    </summary>
*/
print '' print '*** inserting EventSchedule test records ***'
GO
INSERT INTO [dbo].[EventSchedule]
        ([EventID], [StartTime], [EndTime], [EventDay])
    VALUES
        (100000, '2024-01-06 13:00:00', '2024-01-06 13:00:00', '2024-01-06'),
        (100001, '2024-02-06 13:30:00', '2024-02-06 13:30:00', '2024-02-06'),
        (100002, '2024-03-06 13:00:00', '2024-03-06 13:00:00', '2024-03-06'),
        (100003, '2024-04-06 13:30:00', '2024-04-06 13:00:00', '2024-04-06'),
        (100004, '2024-05-06 13:00:00', '2024-05-06 13:00:00', '2024-05-06'),
        (100005, '2024-06-06 13:00:00', '2024-06-06 13:00:00', '2024-06-06'),
        (100006, '2024-07-06 13:00:00', '2024-07-06 13:00:00', '2024-07-06'),
        (100007, '2024-08-06 13:30:00', '2024-08-06 13:30:00', '2024-08-06'),
        (100008, '2024-09-06 13:30:00', '2024-09-06 13:00:00', '2024-09-06'),
        (100009, '2024-10-06 13:30:00', '2024-10-06 13:00:00', '2024-10-06'),
        (100010, '2024-11-06 13:30:00', '2024-11-06 13:30:00', '2024-11-06')
GO

/*
    <summary>
    Creator: Donald Winchester
    Created: 1/26/2024
    Summary: This inserts data into the ServiceType table
    Last Updated By: Donald Winchester
    Last Updated: 4/11/2024
    What Was Changed: Adding more rows to fill out datagrids
    </summary>
*/
print '' print '*** inserting ServiceType test records ***'
GO
INSERT INTO [dbo].[ServiceType]
    ([TypeName], [Description])
VALUES 
    ('Housing Assistance', 'Assistance programs providing housing support for individuals and families in need.'),
    ('Food Aid', 'Services providing food assistance to those facing hunger or food insecurity.'),
    ('Counseling Services', 'Support services offering counseling and therapy for mental health and emotional well-being.'),
    ('Job Training', 'Programs aimed at providing skills training and employment assistance to help individuals secure employment.'),
    ('Medical Care', 'Services offering medical care and treatment for physical health needs.'),
    ('Legal Assistance', 'Providing legal aid and advice for various legal matters.'),
    ('Transportation Support', 'Assistance with transportation needs for individuals who lack access.'),
    ('Educational Programs', 'Offering educational opportunities and resources to support lifelong learning.'),
    ('Spiritual Counselor', 'Offering spiritual guidance for those seeking support.'),
    ('Hair Stylist', 'Professional hair styling services for clients requesting.')
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 1/26/2024
    Summary: This inserts data into the Location table
    Last Updated By: Liam Easton
    Last Updated: 4/11/2024
    What Was Changed: Added more rows
    </summary>
*/
print '' print '*** inserting location test records ***'
GO
INSERT INTO [dbo].[Location]
		([LocationName], [Address], [City], [State], [ZipCode])
	VALUES 
		('Homes For The Homeless', '7072 Posuere Av', 'Cedar Rapids', 'Iowa', 52345),
		('Test Shelter', '1247 4th Ave SE', 'Cedar Rapids', 'Iowa', 52403),
		('Kirkwood Community College', '1247 4th Ave SE', 'Cedar Rapids', 'Iowa', 52402),
		('Homes For The Homless', '1247 4th Ave SE', 'Cedar Rapids', 'Iowa', 52403),
		('Different Shelter', '7072 Posuere Av', 'Cedar Rapids', 'Iowa', 52403),
		('Testing Shelter', '7072 Posuere Av', 'Cedar Rapids', 'Iowa', 11111), /* This location has no Hours of Operation, so it should not come up when looking up the ZIP*/
        ('City Community Center', '123 Main St', 'Cedar Rapids', 'Iowa', 52404),
        ('Hope House', '456 Hope St', 'Cedar Rapids', 'Iowa', 52405),
        ('Unity Church', '789 Unity Ave', 'Cedar Rapids', 'Iowa', 52406),
        ('Downtown Library', '101 Library Blvd', 'Cedar Rapids', 'Iowa', 52407),
        ('Community Park', '222 Park Ave', 'Cedar Rapids', 'Iowa', 52408)
GO 

/*
    <summary>
    Creator: ???
    Created: ???
    Summary: initial creation
    Last Updated By: Liam Easton
    Last Updated: 4/11/2024
    What Was Changed: Wrote comment to this, not sure who initially created it
    </summary>
*/
print '' print '*** inserting skills test records ***'
GO
INSERT INTO [dbo].[Skills]
        ([SkillName])
	VALUES
	    ('Reading'),
		('Typing'),
		('Fork-lift Certified'),
		('Language Translator'),
		('Truck Driver')
GO

/* 
    Creator:            Anthony Talamantes
    Created:            01/24/2024
    Summary:            Insert data for Applicant table
    Last Updated By:    Liam Easton
    Last Updated:       04/11/2024
    What Was Changed:   Added more rows
*/
print '' print '*** inserting Applicant test records ***'
GO
INSERT INTO [dbo].[Applicant]
    ([GivenName], [FamilyName], [PhoneNumber], [Email])
VALUES
    ('Tyler', 'Baccam', '555-111-1111', 'applicant1@example.com'),
    ('Matt', 'Barz', '555-222-2222', 'applicant2@example.com'),
    ('Andrew', 'Nearney', '555-333-3333', 'applicant3@example.com'),
    ('Liam', 'Logorithms', '555-444-4444', 'applicant4@example.com'),
    ('Seth', 'Easton', '555-555-5555', 'applicant5@example.com'),
    ('John', 'Doe', '555-1234', 'john.doe@example.com'),
    ('Jane', 'Smith', '555-5678', 'jane.smith@example.com'),
    ('Mike', 'Johnson', '555-9012', 'mike.johnson@example.com'),
    ('Emily', 'Brown', '555-3456', 'emily.brown@example.com'),
    ('David', 'Williams', '555-7890', 'david.williams@example.com')
GO

/* 
    Creator:            ???
    Created:            ???
    Summary:            initial creation
    Last Updated By:    Liam Easton
    Last Updated:       04/11/2024
    What Was Changed:   Added more rows
*/
print '' print '*** inserting Transport Vehicle test records ***'
GO
INSERT INTO [dbo].[TransportVehicle]
         ([VehicleIdentificationNumber], [InsurancePolicyNumber], [VehicleYear], [VehicleMake], [VehicleModel], [VehicleColor])
		 VALUES
            ('17654AS43', '6435RT324', '2023', 'Toyota', 'Camry', 'white'),
            ('543RD344', '34D5677', '2020', 'Toyota', 'Corrella','Silver'),
            ('98654HY', '4567FR3', '2022', 'kia', 'Tucosn','brown'),
            ('ASDF1234', '894327561', '2017', 'Nissan', 'Altima', 'Gray'),
            ('QWER5678', '654890213', '2016', 'Subaru', 'Outback', 'Green'),
            ('ZXCV9012', '123456789', '2020', 'Jeep', 'Wrangler', 'Yellow'),
            ('POIU3456', '987654321', '2019', 'BMW', 'X5', 'Black'),
            ('LKJH7890', '345678912', '2018', 'Mercedes-Benz', 'GLE', 'Silver'),
            ('NMBV1234', '567890123', '2021', 'Audi', 'Q7', 'White'),
            ('GHJK5678', '890123456', '2022', 'Volkswagen', 'Tiguan', 'Blue')
GO

/*
    <summary>
    CREATOR: Sagan Dewald
    CREATED: 1/24/2023
    SUMMARY: Vendor test records initial creation
    LAST UPDATED BY: Liam Easton
    LAST UPDATED: 04/04/2024
    WHAT WAS CHANGED: Added more rows
    </summary>
*/
print '' print '*** inserting Vendor test records ***'
GO
INSERT INTO [dbo].[Vendor]
    ([VendorName], [VendorAddress], [VendorContactPhone], [VendorContactName], [VendorEmail])
VALUES
    ('KMart', '46901 37 South Hilldale Avenue', '14632173666', 'Nicholas Pearson', 'pearson@gmail.com'),
    ('Walmart', '37830 62 Whitemarsh Ave', '14234563360', 'Zachary Wood', 'zwood@gmail.com'),
    ('Quik Mart', '07202 660 Honey Creek Drive', '12016288810', 'Cain Crosby', 'ccby@yahoo.net'),
    ('Mega Mart', '16066 9205 Edgefield Street', '12152165533', 'Delilah Solomon', 'delsol@hotmail.com'),
    ('QMart', '16065 92 Edgefield Street', '12152165533', 'Delilah Solomon', 'delsol@hotmail.com'),
    ('Target', '8743 Birchwood Lane, Springfield', '2175557890', 'Alexander Johnson', 'ajohnson@example.com'),
    ('Best Buy', '1234 Electronics Boulevard', '1234567890', 'Emily Carter', 'ecarter@example.com'),
    ('Home Depot', '5678 Construction Street', '0987654321', 'Michael Anderson', 'manderson@example.com'),
    ('Costco', '91011 Wholesale Avenue', '9876543210', 'Olivia White', 'owhite@example.com'),
    ('Amazon', '1213 E-commerce Road', '1122334455', 'Daniel Martinez', 'dmartinez@example.com'),
    ('Lowes', '1415 Home Improvement Drive', '5544332211', 'Sophia Taylor', 'staylor@example.com'),
    ('Kroger', '1617 Grocery Lane', '9988776655', 'Aiden Brown', 'abrown@example.com')
GO

/* 
    Creator:            Andres Garcia
    Created:            01/23/2024
    Summary:            Create test records for Order table
    Last Updated By:    Liam Easton
    Last Updated:       04/11/2024
    What Was Changed:   Added more rows 
*/
print '' print '*** creating Order test records ***'
GO
INSERT INTO [dbo].[Order]
        ([OrderDate], [VendorID], [TotalItems], [OrderNotes])
    VALUES
        ('2024-01-09', 100000, 10, 'Order for Shelter rooms 1 and 2, bed sheets and pillow cases'),
		('2024-01-10', 100000, 5, 'Order for Shelter rooms, twin bed sheets'),
		('2024-01-11', 100000, 10, 'Order for kitchen, dinnerplates'),
		('2024-01-12', 100000, 5, 'Order for Shelter rooms, queen bed sheets'),
		('2024-01-13', 100000, 5, 'Order for Shelter rooms, kings bed sheets'),
        ('2024-01-14', 100000, 8, 'Order for Shelter rooms, blankets'),
        ('2024-01-15', 100000, 12, 'Order for Shelter rooms, towels and washcloths'),
        ('2024-01-16', 100000, 6, 'Order for Shelter rooms, pillows'),
        ('2024-01-17', 100000, 10, 'Order for Shelter rooms, pillowcases'),
        ('2024-01-18', 100000, 15, 'Order for Shelter rooms, mattresses'),
        ('2024-01-19', 100000, 20, 'Order for Shelter rooms, curtains')
GO

/* 
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create test records for Item table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   initial creation 
Last Updated By:    Liam Easton
Last Updated:       04/04/2024
What Was Changed:   Added more rows
*/
print '' print '*** creating Item test records ***'
GO
INSERT INTO [dbo].[Item]
        ([ItemName], [ItemDescription], [QtyOnHand], [NormalStockQty], [ReorderPoint], [OnOrder])
    VALUES
        ('Pillow Case', 'Pillow cases used for the shelter bedrooms', 5, 20, 5, 15),
		('Queen Bed Sheet', 'Bed sheet used for queen beds', 5, 20, 5, 15),
        ('Twin Bed Sheet', 'Bed sheet used for twin beds', 5, 20, 5, 15),
		('King Bed Sheet', 'Bed sheet used for king beds', 10, 20, 5, 0),
		('Dinner Plates', 'Plates used for dinner', 90, 100, 50, 0),
		('Flashlights', 'Lights used to see when power is out', 500, 1000, 50, 0),
        ('Coffee Mugs', 'Mugs used for serving coffee', 50, 100, 20, 10),
		('Toilet Paper Rolls', 'Toilet paper rolls for bathroom use', 100, 200, 50, 20),
        ('Bath Towels', 'Towels used for drying after bathing', 30, 50, 10, 5),
		('Laundry Detergent', 'Detergent used for washing clothes', 20, 30, 10, 5),
		('Trash Bags', 'Bags used for collecting trash', 50, 100, 20, 10),
		('Hand Soap', 'Soap for handwashing', 40, 60, 15, 5)
GO

/* 
    Creator:            Ethan McElree
    Created:            01/19/2024
    Summary:            Creation for KitchenInventoryItem table test records
    Last Updated By:    Ethan McElree
    Last Updated:       01/26/2024
    What Was Changed:   Updated the test records 
*/
print '' print '*** inserting KitchenInventoryItem test records ***'
GO
INSERT INTO [dbo].[KitchenInventoryItem]
		([ItemName], [QuantityInStock], [Category], [UnitCost], [Supplier], [ReorderQuantity])
	VALUES
		('Plastic Forks', 65, 'Supplies', 5.99, 'Walmart', 35),
		('Apple', 50, 'Food', 4.59, 'HyVee', 20),
		('Flour', 5, 'Ingredient', 8.00, 'Cargill', 5),
		('Plastic cups', 75, 'Supplies', 7.00, 'HyVee', 25),
		('Sugar', 7, 'Ingredient', 5.00, 'Aldi', 3)
GO

/* 
    <summary>
    Creator:            Ethan McElree
    Created:            01/19/2024
    Summary:            Creation for WeekFoodMenu table test records
    Last Updated By:    Andrew Larson
    Last Updated:       02/09/2024
    What Was Changed:   Updated insert for using an IDENTITY field of type int.
    </summary>
*/
print '' print '*** inserting WeekFoodMenu test records ***'
GO
INSERT INTO [dbo].[WeekFoodMenu]
		([DayOfMeal], [MenuName], [MenuType], [DateLastModified])
	VALUES
		('Monday', 'Breakfast Menu', 'Breakfast', '2024-02-10'),
		('Tuesday', 'Lunch Menu', 'Lunch', '2024-02-11'),
		('Wednesday', 'Dinner Menu', 'Dinner', '2024-02-12'),
		('Thursday', 'Thanksgiving Menu', 'Dinner', '2024-02-13'),
		('Friday', 'Supper Menu', 'Supper', '2024-02-14')
GO

/* 
    <summary>
    Creator:            Jared Harvey
    Created:            01/26/2024
    Summary:            Create Shelter Test Records
    Last Updated By:    Jared Harvey
    Last Updated:       01/23/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting Shelter test records ***'
GO
INSERT INTO [dbo].[Shelter]
		([ShelterID], [Address], [Capacity])
	VALUES
		('Test Homeless Shelter', '123 Homeless Dr.', 100),
		('Test Homeless Shelter #2', '123 Homeless Ave', 100),
		('Test Homeless Shelter #3', '123 First Ave', 100),
		('Test Homeless Shelter #4', '123 Second Ave', 100),
		('Test Homeless Shelter #5', '123 Third Ave', 100)
GO

/* 
Creator:            Donald??
Created:            ??
Summary:            Create test records for Department table
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   Changed DepartmentID to an INT and added ShelterID
*/

print " " print '***inserting Department test records***'
GO
INSERT INTO [dbo].[Department]
    ([DepartmentName], [ShelterID], [Description])
    VALUES 
        ('Housekeeping', 'Test Homeless Shelter', 'Desc 1'),
        ('Maintenance', 'Test Homeless Shelter', 'Desc 2'),
        ('Transportation', 'Test Homeless Shelter', 'Desc 3'),
        ('Front Desk', 'Test Homeless Shelter', 'Desc 4'),
        ('Security', 'Test Homeless Shelter', 'Desc 5'),
        ('Inventory', 'Test Homeless Shelter', 'Desc 6'),
        ('The Board', 'Test Homeless Shelter', 'Desc 7'),
        ('Kitchen', 'Test Homeless Shelter', 'Desc 8')
GO

/*
    Creator: Wyatt Asher
    Created: 1/22/2024
    Summary: This is the insert statement for the employee sample data.
    Last Updated By: Jared Harvey
    Last Updated: 02/07/2024
    What Was Changed: Added more records so that I could assign each a unique role for testing.
    Last Updated By: Liam Easton
    Last Updated: 04/11/2024
    What Was Changed: Added even more fields to fill out datagrid
*/
print '' print '*** Inserting Employee Test Records ***'
GO
INSERT INTO [dbo].[Employee]
        ([EmployeeID], [Fname], [Lname], [Phone], [Gender],
        [PasswordHash], [AccountStatus], [ZipCode], [Address],
        [StartDate], [EndDate])
    VALUES
        ('john@company.com', 'John', 'Doe', '(319) 555-5522', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 55555, '555 Street St', '2000-01-01', NULL),
        ('jane@company.com', 'Jane', 'Doe', '(319) 555-5533', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 55555, '555 Street St', '2000-01-01', NULL),
        ('jack@home.com', 'Jack', 'Guy', '(319) 555-2251', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            0, 55500, '555 Circle St', '2010-12-31', '2017-08-20'),
        ('bill@company.com', 'Bill', 'Person', '(555) 319-5544', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 33355, '555 Rocky St', '2008-11-11', NULL),
        ('shannon@company.com', 'Shannon', 'Lumm', '(319) 555-4444', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 44145, '540 Street St', '2001-10-20', NULL),
        ('jill@company.com', 'Jill', 'Here', '(319) 555-2021', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 35846, '100 Street St', '2003-07-21', NULL),
        ('guy@company.com', 'Guy', 'Man', '(319) 555-5552', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 15648, '365 Mountain Dr', '2020-04-30', NULL),
        ('janet@company.com', 'Janet', 'Note', '(319) 555-1645', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 51864, '156 Ocean Av', '2011-03-21', NULL),
        ('kevin@company.com', 'Kevin', 'Lumm', '(319) 555-5616', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 51552, '165 Main St', '2012-02-07', NULL),
        ('melissa@company.com', 'Melissa', 'Thane', '(319) 555-6516', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 15625, '654 Rainbow Rd', '2015-03-10', NULL),
		('joe@company.com', 'Joe', 'Kuhl', '(319) 555-4674', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 51864, '156 Ocean Av', '2011-03-21', NULL),
        ('bob@company.com', 'Bob', 'Hulk', '(319) 555-5616', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 51552, '165 Main St', '2012-02-07', NULL),
        ('gill@company.com', 'Gill', 'Mool', '(319) 555-6516', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 234563, '3596 Broken Dreams Bvld', '2015-03-10', NULL),
        ('Jirard@company.com', 'Jirard', 'Norton', '(319) 555-1928', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 34567, '1234 Elm Street', '2019-12-08', NULL),
        ('Samantha@company.com', 'Samantha ', 'Johnson', '(319) 555-7482', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 34567, '123 Oak Street', '2019-08-25', NULL),
        ('Marcus@company.com', 'Marcus ', 'Chen', '(319) 555-9786', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 74895, '456 Maple Avenue', '2022-04-17', NULL),
        ('Emily@company.com', 'Emily ', 'Patel', '(319) 555-2765', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 27735, '789 Pine Road', '2017-11-30', NULL),
        ('Michael@company.com', 'Michael', 'Smith', '(319) 555-1234', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 54321, '567 Cedar Lane', '2023-06-15', NULL),
        ('Sarah@company.com', 'Sarah', 'Brown', '(319) 555-5678', 0, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 98765, '890 Elm Street', '2018-09-20', NULL),
        ('Christopher@company.com', 'Christopher', 'Lee', '(319) 555-9876', 1, 
            '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
            1, 12345, '678 Pine Avenue', '2020-12-10', NULL)
GO

/* 
    <summary>
    Creator:            Jared Harvey
    Created:            01/26/2024
    Summary:            Create ShelterEmployee Test Records
    Last Updated By:    Jared Harvey
    Last Updated:       01/23/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting ShelterEmployee test records ***'
GO
INSERT INTO [dbo].[ShelterEmployee]
		([EmployeeID], [ShelterID])
	VALUES
		('john@company.com', 'Test Homeless Shelter'),
		('jane@company.com', 'Test Homeless Shelter'),
		('jack@home.com', 'Test Homeless Shelter #2'),
		('bill@company.com', 'Test Homeless Shelter #2'),
		('shannon@company.com', 'Test Homeless Shelter #2')
GO

/* 
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Insert data for Reminder table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   ???
*/
print '' print '*** inserting Reminder test records ***'
GO
INSERT INTO [dbo].[Reminder]
    ([EmailTo], [EmailFrom], [Title], [Message], [Frequency], [Date], [Read], [Deactivate])
VALUES
    ('user1@example.com', 'admin@example.com', 'Daily Reminder', 'Example', 'Daily', '2023-01-01', 0, 0),
    ('user2@example.com', 'admin@example.com', 'Weekly Reminder', 'Example.', 'Weekly', '2023-01-02', 0, 0),
    ('user3@example.com', 'admin@example.com', 'Monthly Reminder', 'Example', 'Monthly', '2023-01-03', 0, 0),
    ('user4@example.com', 'admin@example.com', 'Quarterly Reminder', 'Example', 'Quarterly', '2023-01-04', 0, 0),
    ('user5@example.com', 'admin@example.com', 'Yearly Reminder', 'Example', 'Yearly', '2023-01-05', 0, 0)
GO

/* 
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Insert data for Message table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   ???
*/
print '' print '*** inserting Message test records ***'
GO
INSERT INTO [dbo].[Message]
    ([EmailTo], [EmailFrom], [Title], [Message], [Date], [Read], [CheckedOff], [RemindOnDate], [HideFromView])
VALUES
    ('user1@example.com', 'admin@example.com', 'Welcome', 'Example', '2023-01-01', 0, 0, '2023-01-05', 0),
    ('user2@example.com', 'admin@example.com', 'Important Update', 'Example.', '2023-01-02', 0, 0, '2023-01-10', 0),
    ('user3@example.com', 'admin@example.com', 'Action Required', 'Example.', '2023-01-03', 0, 0, '2023-01-15', 0),
    ('user4@example.com', 'admin@example.com', 'Event Reminder', 'Example', '2023-01-04', 0, 0, '2023-01-20', 0),
    ('user5@example.com', 'admin@example.com', 'Feedback Request', 'Example', '2023-01-05', 0, 0, '2023-01-25', 0)
GO

/*
    <summary>
    Creator: Darryl Shirley
    created: 01/22/2024
    Summary: Service provider test data
    Last updated By: Darryl Shirley
    Last Updated: 1-26-2024
    What was changed/updated: 
    </summary>
*/
PRINT '' PRINT '*** Inserting ServiceProviders records ***'
GO
INSERT INTO [dbo].[ServiceProviders]
		([ServiceProviderID], [ServiceDate], [ContactPerson], [ContactEmail], [ContactPhone], [Address], [ProviderType])
	VALUES
		('Kennys BarberShop', '2023-09-21', 'Random Barber', 'darryl@kirkwood.com', '111-222-3333', 'Dreary Lane', 'Barber'),
		('Papa Johns', '2023-08-13', 'Kane Smith', 'Smith@company.com', '222-333-4444', 'Kacy Street', 'Food'),
		('Kings of Comedy', '2023-06-05', 'Bernie Mac', 'Mac@comedy.com', '121-345-2458', 'Funny Road', 'Entertainment'),
		('Subway', '2023-08-13', 'Payne Jolly', 'Jolly@company.com', '222--4444', 'Kacy Street', 'Food'),
		('Doctors Abroad', '2024-1-02', 'Jimmy Healer', 'healer@doctor.com', '111-111-1111', 'Doctor Street', 'Medicine')
		
GO

/* 
    <summary>
    Creator:            Tyler Barz
    Created:            01/19/2024
    Summary:            Creation for Role insert data
    Last Updated By:    Jared Harvey
    Last Updated:       02/07/2024
    What Was Changed:   I added the departmentID to the inserts and added more test records.
    </summary>
*/
print '' print 'Inserting into Role'
GO
INSERT INTO Role
    ([RoleID], [DepartmentID], [Description], [PositionsAvailable])
VALUES
    ('CEO', 100006, 'Chief Executive Officer', 0),
    ('Maintenance Manager', 100001, 'Manage maintenance workers', 1),
    ('Inventory Manager', 100005, 'Manage all in-house inventory', 0),
    ('Cook', 100007, 'Kitchen staff', 3),
    ('Driver', 100002, 'Delivery Driver', 5),
    ('Maintenance Technician', 100001, 'Perform routine maintenance', 1),
    ('Kitchen Manager', 100007, 'Manage all kitchen staff', 0),
    ('Security Manager', 100004, 'Manage all security staff, and incidents', 0),
	('Security Guard', 100004, 'In-house on-site security', 3),
	('Transportation Coordinator', 100002, 'Coordinate transportation', 1),
	('Housekeeping Coordinator', 100000, 'Coordinate housekeeping staff', 1),
	('Housekeeping Staff', 100000, 'In-charge of cleaning, and up-keeping work areas', 5),
	('Front Desk Rep', 100003, 'Front of house receptionist', 4)
	
GO

/*
    <summary>
    Creator:            Kirsten Stage
    Created:            02/01/2024
    Summary:            Create Room Status Test Records
    Last Updated By:    Suliman Suliman
    Last Updated:       03/06/2024
    What Was Changed:   Adding new room Status(Deactivated)
    </summary>
*/
print '' print '*** inserting RoomStatus test records ***'
GO
INSERT INTO [dbo].[RoomStatus]
		([Status])
	VALUES
		('Available'),
		('Occupied'),
		('Needs Maintenance'),
		('Needs Housekeeping'),
		('Deactivated')
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/12/2024
    Summary:            Create CleaningStatus Test Records
    Last Updated By:    Jared Harvey
    Last Updated:       02/12/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** inserting CleaningStatus test records ***'
GO
INSERT INTO [dbo].[CleaningStatus]
		([Status])
	VALUES
		('Dirty'),
		('In Cleaning'),
		('Needs Inspected'),
		('Clean')
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Insertion of test data into the ResourceCategory table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
PRINT '*** Inserting test records into Resource Category ***'
GO
INSERT INTO [dbo].[ResourceCategory]
		([Category])
	VALUES
		('Everyday Needs'),
		('Cleaning Products'),
		('Winter Needs'),
		('Childrens Needs'),
		('Adult Needs')
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Insertion of test data into the ResourcesNeeded table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
PRINT '*** Inserting test records into Resources Needed ***'
GO
INSERT INTO [dbo].[ResourcesNeeded]
		([ResourceID], [Category])
	VALUES
		('Toilet Paper', 'Everyday Needs'),
		('Toothpaste', 'Everyday Needs'),
		('Cases of Water Bottles', 'Everyday Needs'),
		('Disinfecting Wipes', 'Cleaning Products'),
		('Laundry Detergent', 'Cleaning Products'),
		('Winter Coats', 'Winter Needs'),
		('Childrens Shoes', 'Childrens Needs'),
		('Formula', 'Childrens Needs'),
		('Mens Jeans', 'Adult Needs'),
		('Womens Work Clothes', 'Adult Needs')
GO

/* 
    <summary>
    Creator:            Jared Harvey
    Created:            01/26/2024
    Summary:            Create Room Test Records
    Last Updated By:    Jared Harvey
    Last Updated:       02/12/2024
    What Was Changed:   Changed statuses to match the foreign key constraint
    </summary>
*/
print '' print '*** inserting Room test records ***'
GO
INSERT INTO [dbo].[Room]
		([ShelterID], [RoomNumber], [Status])
	VALUES
		('Test Homeless Shelter', 101, 'Available'),	
		('Test Homeless Shelter', 102, 'Occupied'),	
		('Test Homeless Shelter', 201, 'Occupied'),
		('Test Homeless Shelter', 202, 'Occupied'),
		('Test Homeless Shelter', 203, 'Occupied'),
		('Test Homeless Shelter #2', 101, 'Available'),	
		('Test Homeless Shelter #2', 102, 'Needs Maintenance'),	
		('Test Homeless Shelter #2', 201, 'Available'),
		('Test Homeless Shelter #2', 202, 'Needs Housekeeping')		
GO

/* 
Creator:            Tyler Barz
Created:            01/19/2024
Summary:            Creation for Volunteer insert data
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   Replaced the INT RoleID values with NVARCHAR(50) values 
*/
print '' print 'Inserting into Volunteer'
GO
INSERT INTO Volunteer
    ([VolunteerID], [FirstName], [LastName], [Phone], [Gender], [PasswordHash], [AccountStatus], [RoleID], [ZipCode], [Address], [RegistrationDate])
VALUES
    ("his@gmail.com", "Jim", "Glascow", "000-000-0000", 0, "9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e", 1, 'Cook', 55555, "skid street 123", '2023-05-15'),
    ("someones@gmail.com", "Rick", "James", "000-000-1111", 1, "hash here", 0, 'Cook', 55555, "bum street 123", '2023-05-15'),
    ("hers@gmail.com", "Mariah", "Carey", "000-000-2222", 1, "hash here", 0, 'Cook', 55555, "data street 123", '2023-05-15'),
    ("random@gmail.com", "John", "Doe", "000-000-3333", 1, "hash here", 0, 'Cook', 55555, "fake street 123", '2023-05-15'),
    ("guest@gmail.com", "Jane", "Foster", "000-000-4444", 1, "hash here", 1, 'Cook', 55555, "real street 123",  '2023-05-15')
GO
/*
Creator: Wyatt Asher
Created: 1/25/2024
Summary: This is the insert statement for the Incident table sample data.
Last Updated By: Liam Easton
Last Updated: 3/08/2024
What Was Changed: Added more data to populate datagrid further
*/
print '' print '*** Inserting Incident Test Records ***'
GO
INSERT INTO [dbo].[Incident]
        ([Description], [IncidentStatus], [Reported], [ReportedBy],
        [Feedback], [Severity])
    VALUES
        ('A cook burnt herself with a vat of oil', 'Handled', 'man@client.com', 'john@company.com', NULL, 3),
        ('A gang member stole a shippment of cleaning supplies', 'processing', 'fish@client.com', 'guy@company.com', 'We will need to install more cameras in the storage area', 2),
        ('A resident slippped on a recently mopped floor', 'processing', 'woman@client.com', 'melissa@company.com', NULL, 1),
        ('There have been several break-ins regarding the homes of residents', 'Handled', 'furniture@client.com', 'kevin@company.com', 'We will need to install more security measures near the homes of residents', 4),
        ('One of the residents choked on a piece of metal found in his food', 'processing', 'woman@client.com', 'kevin@company.com', NULL, 3),
        ('A cook burnt herself with a vat of oil', 'Handled', 'john@company.com', 'shannon@company.com', NULL, 3),
        ('A gang member stole a shipment of cleaning supplies', 'processing', 'john@company.com', 'guy@company.com', 'We will need to install more cameras in the storage area', 2),
        ('A resident slipped on a recently mopped floor', 'processing', 'john@company.com', 'melissa@company.com', NULL, 1),
        ('There have been several break-ins regarding the homes of residents', 'Handled', 'melissa@company.com', 'melissa@company.com', 'We will need to install more security measures near the homes of residents', 4),
        ('One of the residents choked on a piece of metal found in his food', 'processing', 'melissa@company.com', 'melissa@company.com', NULL, 3),
        ('A customer slipped on a wet floor near the entrance', 'processing', 'john@company.com', 'melissa@company.com', NULL, 1),
        ('A cook burnt herself with a vat of oil', 'Handled', 'john@company.com', 'shannon@company.com', NULL, 3),
        ('A gang member stole a shipment of cleaning supplies', 'processing', 'john@company.com', 'guy@company.com', 'We will need to install more cameras in the storage area', 2),
        ('A resident slipped on a recently mopped floor', 'processing', 'john@company.com', 'melissa@company.com', NULL, 1),
        ('A car accident occurred in the parking lot', 'processing', 'john@company.com', 'melissa@company.com', 'Review CCTV footage for details', 2),
        ('An employee experienced an electric shock from faulty wiring', 'Handled', 'john@company.com', 'melissa@company.com', 'Electrician to inspect and repair wiring', 3),
        ('A customer slipped on a wet floor near the entrance', 'processing', 'john@company.com', 'melissa@company.com', NULL, 1),
        ('Vandalism reported in the restroom area', 'processing', 'john@company.com', 'melissa@company.com', 'Increase surveillance in restroom facilities', 2),
        ('A package was stolen from the reception area', 'Handled', 'john@company.com', 'melissa@company.com', 'Enhance security protocols for package handling', 3),
        ('A suspicious package was found in the lobby', 'processing', 'woman@client.com', 'melissa@company.com', 'Follow established protocol for handling suspicious items', 2),
        ('A fire drill triggered panic among occupants', 'Handled', 'man@client.com', 'melissa@company.com', 'Conduct training sessions on emergency procedures', 3),
        ('A customer reported a malfunctioning vending machine', 'processing', 'man@client.com', 'melissa@company.com', 'Repair or replace the vending machine', 2),
        ('Unattended children in common areas causing disturbance', 'processing', 'melissa@company.com', 'shannon@company.com', 'Remind residents of community rules regarding children', 1),
        ('A water leak was discovered in the basement storage area', 'Handled', 'melissa@company.com', 'shannon@company.com', 'Fix the leak and assess potential damage', 3),
        ('A suspicious person was seen loitering near the entrance', 'processing', 'melissa@company.com', 'shannon@company.com', 'Increase security patrols near the entrance', 2),
        ('A customer accidentally locked their keys in their car in the parking lot', 'processing', 'melissa@company.com', 'shannon@company.com', 'Assist the customer in unlocking their car', 1),
        ('A resident reported a strange odor', 'processing', 'woman@client.com', 'melissa@company.com', 'Investigate and address the source of the odor', 2),
        ('Unauthorized parking in designated handicapped spaces', 'Handled', 'melissa@company.com', 'shannon@company.com', 'Enforce parking regulations and tow unauthorized vehicles', 4)
GO

/*
Creator: Wyatt Asher
Created: 1/25/2024
Summary: This is the insert statement for the IncidentParty
table sample data.
Last Updated By: Wyatt Asher
Last Updated: 1/26/2024
What Was Changed: Initial Commit
*/
print '' print '*** Inserting IncidentParty Test Records ***'
GO
INSERT INTO [dbo].[IncidentParty]
        ([IncidentID], [Description], [IncidentRole])
    VALUES
        (100000, 'The employee who was mopping the floor claimed that they clearly marked the spot with a sign', 'Perpitrator'),
        (100001, 'According to a witness, the employee was drunk at the time', 'witness'),
        (100002, 'The owner of the dog came to the building and apologized. He offered to pay for the damages', 'Perpitrator'),
        (100003, 'The cook who had prepared the residents food claimed that they never saw any metal when they sent it to the server', 'Perpitrator'),
        (100004, 'One of the residents claimed that they saw the person who had broken in', 'Victim')
GO

/* 
Creator:            Jared Harvey
Created:            01/23/2024
Summary:            Inserting data for HousekeepingTask Table
Last Updated By:    Jared Harvey
Last Updated:       03/03/2024
What Was Changed:   Added Urgency field
*/
print '' print '*** inserting MaintenanceRequest test records ***'
GO
INSERT INTO [dbo].[MaintenanceRequest]
		([RoomID], [Urgency], [Status], [Requester], [Phone], [TimeCreated], [Description])
	VALUES
		(100000, 'Low', 'Pending', 'Joe', '3192471283', '20120618 10:34:09 AM', 'Test description'),
		(100001, 'Low', 'Pending', 'Jim', '3198274837', '20120618 10:34:09 AM', 'Test description'),
		(100002, 'Medium', 'Pending', 'Joe', '3192471283', '20120618 10:34:09 AM', 'Test description'),
		(100003, 'High', 'In Progress', 'Bob', '3192471283', '20120618 10:34:09 AM', 'Test description'),
		(100004, 'Medium', 'Completed', 'Bill', '3192471283', '20120618 10:34:09 AM', 'Test description')
GO

/* 
Creator:            Tyler Barz
Created:            01/26/2024
Summary:            Creation for EmployeeRole insert data
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   Added more EmployeeRole test records since I added more Roles. 
*/
print '' print 'Inserting into EmployeeRole'
GO
INSERT INTO EmployeeRole
    ([EmployeeID], [RoleID])    
VALUES
    ('john@company.com', 'CEO'),
    ('jane@company.com', 'Maintenance Manager'),
    ('jane@company.com', 'Inventory Manager'),
    ('jane@company.com', 'Security Manager'),
    ('jack@home.com', 'Inventory Manager'),
    ('bill@company.com', 'Cook'),
    ('shannon@company.com', 'Driver'),
	('jill@company.com', 'Maintenance Technician'),
	('guy@company.com', 'Kitchen Manager'),
	('janet@company.com', 'Security Manager'),
	('kevin@company.com', 'Security Guard'),
	('melissa@company.com', 'Transportation Coordinator'),
	('joe@company.com', 'Housekeeping Coordinator'),
	('bob@company.com', 'Housekeeping Staff'),
	('gill@company.com', 'Front Desk Rep')
	
GO

/* 
Creator:            Jared Harvey
Created:            01/23/2024
Summary:            Inserting data for HousekeepingTask Table
Last Updated By:    Jared Harvey
Last Updated:       02/12/2024
What Was Changed:   Changed statuses to follow the foreign key constraint
*/
print '' print 'Inserting into HousekeepingTask'
INSERT INTO [dbo].[HousekeepingTask]
		([RoomID], [EmployeeID], [Type], [Description], [Date], [Status])
	VALUES
		(100000, null, 'test type', 'Test description', '20120618 10:34:09 AM', 'Dirty'),
		(100001, 'jane@company.com', 'test type', 'Test description', '20120618 10:34:09 AM', 'In Cleaning'),
		(100002, 'jack@home.com', 'test type', 'Test description', '20120618 10:34:09 AM', 'Needs Inspected'),
		(100003, 'bill@company.com', 'test type', 'Test description', '20120618 10:34:09 AM', 'Clean'),
		(100004, null, 'test type', 'Test description', '20120618 10:34:09 AM', 'Dirty')
GO
/* 
Creator:            Ethan McElree
Created:            01/19/2024
Summary:            Creation for Recipe table test records
Last Updated By:    Andrew Larson
Last Updated:       02/02/2024
What Was Changed:   Fixed various issues that were causing errors on the Insert statments
*/
print '' print '*** inserting Recipe test records ***'
GO
INSERT INTO [dbo].[Recipe]
	([MenuID], [RecipeName], [RecipeDescription], [Calories], [Allergens], [Vegen], [PrepTime], [Category], [KitchenItemID], [RecipeImage], [RecipeSteps])
VALUES
	(100000,'Enchilada', 'Mexican rolled up corn tortilla', 10500, 'Cheese', 0, 50, 'Dinner', 100000, 'Enchilada.jpg', 'Prepare the oven and enchilada sauce. Then, saute the filling mixture. After that, assemble the enchiladas. Bake the assembled enchiladas, and finally, serve.'),
	(100001,'Taco', 'small hand-sized corn or wheat-based tortilla with a filling', 12000, 'None', 0, 30, 'Breakfast', 100001, 'Taco.jpg', 'Cook the protein, season it, prepare the taco shells, assemble the taco shells, add toppings, and finally, serve.'),
	(100002,'Cheese Burger', 'hamburger with a slice of melted cheese on top of the meat patty', 15000, 'Cheese', 1, 40, 'Lunch', 100002, 'CheeseBurger.jpg', 'Cook the beef patty, season it with salt and pepper, toast the burger buns, place cheese on the cooked patty, assemble the burger with lettuce, tomato, and onion, add ketchup and mayonnaise, and then serve.'),	
	(100003,'Ravioli', 'Stuffed pasta', 12300, 'Eggs', 0, 45, 'Dinner', 100003, 'Ravioli.jpg', 'Cook the ravioli pasta, mix ricotta cheese with salt and pepper, stuff each raviolo with the ricotta mixture, warm the tomato sauce, place the ravioli in the sauce to heat, sprinkle with Parmesan cheese, and add fresh basil if desired. Finally, serve.'),
	(100004,'Cheese cake', 'dessert made with a soft fresh cheese, eggs, and sugar', 10500, 'cheese', 0, 65, 'Dessert', 100004, 'CheeseCake.jpg', 'Prepare a graham cracker crust. Mix cream cheese, sugar, and vanilla extract until well combined. Add eggs one at a time, ensuring thorough mixing. Gently fold in sour cream. Pour the mixture into the crust. Bake until the cheesecake is set. Allow it to cool, then chill in the refrigerator. Serve when ready.')
GO

/* 
Creator:            Ethan McElree
Created:            01/19/2024
Summary:            Creation for MenuMeal table test records
Last Updated By:    Ethan McElree
Last Updated:       01/26/2024
What Was Changed:   Added another test record  
*/
print '' print '*** inserting MenuMeal test records ***'
GO
INSERT INTO [dbo].[MenuMeal]
		([MenuID], [RecipeID], [EmployeeID], [Category])
	VALUES
		(100000, 100000, 'john@company.com', 'Dinner'),
		(100001, 100001, 'jane@company.com', 'Breakfast'),
		(100002, 100002, 'jack@home.com', 'Lunch'),
		(100003, 100003, 'bill@company.com', 'Supper'),
		(100004, 100004, 'shannon@company.com', 'Desert')
GO


/* 
Creator:            Andrew Larson
Created:            02/10/2024
Summary:            Inserting test data for RecipeIngredients
Last Updated By:    Andrew Larson
Last Updated:       02/10/2024
What Was Changed:   Initial Creation  
*/
print '*** inserting RecipeIngredients test records ***'
GO

INSERT INTO [dbo].[RecipeIngredients]
    ([IngredientID], [RecipeID], [Quantity], [UnitOfMeasurement])
VALUES
    ('Chicken', 100000, 1, 1),
    ('Onions', 100000, 1, 1),
    ('Beans', 100000, 1, 1),
    ('Tortillas', 100000, 1, 1),
    ('Cheese', 100000, 1, 1),
    ('Enchilada Sauce', 100000, 1, 1),
    
    ('Taco Shells', 100001, 1, 1),
    ('Ground Beef or Chicken', 100001, 1, 1),
    ('Taco Seasoning', 100001, 1, 1),
    ('Shredded Lettuce', 100001, 1, 1),
    ('Diced Tomatoes', 100001, 1, 1),
    ('Shredded Cheese', 100001, 1, 1),
    ('Sour Cream', 100001, 1, 1),
    ('Salsa', 100001, 1, 1),
    
    ('Burger Buns', 100002, 1, 1),
    ('Ground Beef', 100002, 1, 1),
    ('Salt and Pepper', 100002, 1, 1),
    ('Cheese Slices', 100002, 1, 1),
    ('Lettuce', 100002, 1, 1),
    ('Tomato Slices', 100002, 1, 1),
    ('Onion Slices', 100002, 1, 1),
    ('Ketchup', 100002, 1, 1),
    ('Mayonnaise', 100002, 1, 1),
    
    ('Ravioli Paste', 100003, 1, 1),
    ('Tomato Sauce', 100003, 1, 1),
    ('Parmesan Cheese', 100003, 1, 1),
    ('Fresh Basil Leaves', 100003, 1, 1),
    ('Ricotta Cheese', 100003, 1, 1),
    
    ('Graham Cracker Crust', 100004, 1, 1),
    ('Cream Cheese', 100004, 1, 1),
    ('Sugar', 100004, 1, 1),
    ('Vanilla Extract', 100004, 1, 1),
    ('Eggs', 100004, 1, 1)
GO

/* 
Creator:            Ethan McElree
Created:            01/19/2024
Summary:            Creation for RecipeIngredients table test records
Last Updated By:    Ethan McElree
Last Updated:       01/26/2024
What Was Changed:   Added two more test records  

print '' print '*** inserting RecipeIngredients test records ***'
GO
INSERT INTO [dbo].[RecipeIngredients]
		([RecipeID], [Quantity], [UnitOfMeasurement])
	VALUES
		(100000, 50.00, 'grams'),
		(100001, 30.50, 'cups'),
		(100002, 40.20, 'teaspoons'),
		(100003, 45.00, 'tablespoons'),
		(100004, 55.30, 'pint')
GO
*/

/* 
    Creator:            ???
    Created:            ???
    Summary:            Creation of Client test records
    Last Updated By:    Sagan DeWald
    Last Updated:       03/29/2024
    What Was Changed:   Changed password hashes to actually be SHA256 hashes.
    Last Updated By:    Liam Easton
    Last Updated:       04/11/2024
    What Was Changed:   Added more clients for fill out datagrids
*/
print '' print '*** inserting Client test records ***'
GO
INSERT INTO [dbo].[Client] 
    ([ClientID], [Fname], [Lname], [PasswordHash], [Gender], [Accomodations], [AccountStatus], [RegistrationDate], [ExitDate])
    VALUES
        ('john.doe@email.com', 'John', 'Doe', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-01-27', '2024-02-15'),
        ('john@company.com', 'John', 'Doe', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-01-27', '2024-02-15'),
        ('jane.smith@email.com', 'Jane', 'Smith', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Double bed', 1, '2024-01-28', '2024-03-10'),
        ('mike.johnson@email.com', 'Mike', 'Johnson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Shared room', 1, '2024-02-01', '2024-02-28'),
        ('emily.brown@email.com', 'Emily', 'Brown', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Single bed', 1, '2024-02-05', '2024-04-15'),
        ('chris.miller@email.com', 'Chris', 'Miller', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Double bed', 1, '2024-02-10', '2024-03-20'),
        ('sarah.jones@email.com', 'Sarah', 'Jones', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Single bed', 1, '2024-02-15', '2024-03-30'),
        ('david.wilson@email.com', 'David', 'Wilson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Double bed', 1, '2024-02-20', '2024-04-05'),
        ('lisa.thompson@email.com', 'Lisa', 'Thompson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Shared room', 1, '2024-02-25', '2024-03-15'),
        ('kevin.evans@email.com', 'Kevin', 'Evans', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-03-01', '2024-04-10'),
        ('amanda.clark@email.com', 'Amanda', 'Clark', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Double bed', 1, '2024-03-05', '2024-04-20'),
        ('steven.roberts@email.com', 'Steven', 'Roberts', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-03-10', '2024-03-25'),
        ('sophia.smith@email.com', 'Sophia', 'Smith', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Single bed', 1, '2024-03-15', '2024-04-05'),
        ('ryan.johnson@email.com', 'Ryan', 'Johnson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Double bed', 1, '2024-03-20', '2024-04-15'),
        ('olivia.brown@email.com', 'Olivia', 'Brown', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Shared room', 1, '2024-03-25', '2024-04-10'),
        ('ethan.wilson@email.com', 'Ethan', 'Wilson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-04-01', '2024-04-20'),
        ('ava.thompson@email.com', 'Ava', 'Thompson', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Double bed', 1, '2024-04-05', '2024-04-25'),
        ('noah.evans@email.com', 'Noah', 'Evans', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Single bed', 1, '2024-04-10', '2024-04-30'),
        ('mia.clark@email.com', 'Mia', 'Clark', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Shared room', 1, '2024-04-15', '2024-05-05'),
        ('lucas.roberts@email.com', 'Lucas', 'Roberts', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Double bed', 1, '2024-04-20', '2024-05-10'),
        ('amelia.jones@email.com', 'Amelia', 'Jones', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 0, 'Single bed', 1, '2024-04-25', '2024-05-15'),
        ('jayden.smith@email.com', 'Jayden', 'Smith', '9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e', 1, 'Shared room', 1, '2024-04-30', '2024-05-20')
GO

/* 
Creator:            Jared Harvey
Created:            02/19/2024
Summary:            Creation of Stay test records
Last Updated By:    Jared Harvey
Last Updated:       02/26/2024
What Was Changed:   ?? 
*/
print '' print '*** inserting Stay test records ***'
GO
INSERT INTO [dbo].[Stay] 
    ([ClientID], [RoomID], [InDate], [OutDate], [CheckedOut])
    VALUES
		('john.doe@email.com', 100000, '2024-02-18', '2024-02-19', 1),
		('jane.smith@email.com', 100001, '2024-02-20', '2024-02-21', 0),
		('mike.johnson@email.com', 100002, '2024-02-21', '2024-02-22', 0),
		('emily.brown@email.com', 100003, '2024-02-22', '2024-02-23', 0),
		('chris.miller@email.com', 100004, '2024-02-23', '2024-02-24', 0),
		('john.doe@email.com', 100004, '2024-02-23', '2024-02-24', 1)
GO


/* 
Creator:            Liam Easton
Created:            01/24/2024
Summary:            initial creation of the UserSettings test records
Last Updated By:    Jared Harvey
Last Updated:       04/04/2024
What Was Changed:   Added comment to this, but did this back in january
*/
print '' print '*** inserting UserSettings test records ***'
GO
INSERT INTO [dbo].[UserSettings]
		([ClientID], [UIMode])
	VALUES 
		('john.doe@email.com', '1'),		
		('jane.smith@email.com', '0'),		
		('mike.johnson@email.com', '1'),		
		('emily.brown@email.com', '1'),		
		('chris.miller@email.com', '0')
GO 

/* 
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Insert data for GroupAppointment table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   Initial Creation
*/
print '' print '*** inserting GroupAppointment test records ***'
GO
INSERT INTO [dbo].[GroupAppointment]
    ([ClientID], [LocationID], [AppointmentDateTime], [AppointmentType])
VALUES
    ('john.doe@email.com', 100000, '2023-02-10 15:00:00', 'Group Session'),
    ('jane.smith@email.com', 100001, '2023-02-15 16:00:00', 'Workshop'),
    ('mike.johnson@email.com', 100002, '2023-02-20 17:00:00', 'Training'),
    ('emily.brown@email.com', 100003, '2023-02-25 18:00:00', 'Seminar'),
    ('chris.miller@email.com', 100004, '2023-03-01 19:00:00', 'Group Session')
GO

print '' print '*** inserting MembersLine test records ***'
INSERT INTO	[dbo].[MembersLine]
		([ClientID], [GroupAppointmentID], [ClientAttendend])
	VALUES
		('john.doe@email.com', 100000, 0),
		('jane.smith@email.com', 100001, 1),
		('mike.johnson@email.com', 100002, 0),
		('emily.brown@email.com', 100003, 0),
		('chris.miller@email.com', 100004, 1)
GO

/* 
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Insert data for Appointment table
Last Updated By:    Seth Nerney
Last Updated:       02/13/2024
What Was Changed:   AppointmentEndTime And AppointmentStartTime
*/
print '' print '*** inserting Appointment test records ***'
GO
INSERT INTO [dbo].[Appointment]
    ([ClientID], [LocationID], [AppointmentStartTime], [AppointmentEndTime], [AppointmentType],
	[Status], [EmployeeID])
VALUES
    ('john.doe@email.com', 100000, '2023-02-01 10:00:00', '2023-02-01 14:00:00', 'Regular', 1, 'john@company.com'),
    ('jane.smith@email.com', 100001, '2023-02-02 11:00:00', '2023-02-02 15:00:00', 'Checkup', 1, 'jane@company.com'),
    ('mike.johnson@email.com', 100002, '2023-02-03 12:00:00', '2023-02-03 16:00:00', 'Consultation', 1, 'jack@home.com'),
    ('emily.brown@email.com', 100003, '2023-02-04 13:00:00', '2023-02-04 17:00:00',  'Follow-up', 1, 'bill@company.com'),
    ('chris.miller@email.com', 100004, '2023-02-05 14:00:00', '2023-02-05 18:00:00', 'Regular', 1, 'shannon@company.com')
GO



/*
PRINT '' PRINT 'Inserting DonationLine sample data'
GO
Inserting DonationLine sample data
CREATOR: Matthew Baccam
CREATED: 1/25/2023
SUMMARY: ??
LAST UPDATED BY: ??
LAST UPDATED: ??
WHAT WAS CHANGED: ??

INSERT INTO DonationLine ([DonationID])
VALUES (100000), (100001), (100002), (100003), (100004)
GO
*/



/*
PRINT '' PRINT 'Inserting ContactDescription sample data'
GO
Inserting ContactDescription sample data
CREATOR: Matthew Baccam
CREATED: 1/25/2023
SUMMARY: ??
LAST UPDATED BY: ??
LAST UPDATED: ??
WHAT WAS CHANGED: ??
INSERT INTO ContactDescription ([Description], [PartnerID])
VALUES ('Main contact', 100000), 
       ('Secondary contact', 100001),
       ('Main contact', 100002),
       ('Secondary contact', 100003),
       ('Tertiary contact', 100004)
GO
*/



/* 
Creator:            Darryl Shirley
Created:            04/04/2024
Summary:            Creation for VolunteerSkills insert data
Last Updated By:    Darryl Shirley
Last Updated:       04/04/2024
What Was Changed:   Initial Creation
*/
INSERT INTO [dbo].[VolunteerSkills]
         ([VolunteerID], [SkillID])
	VALUES
	    ('random@gmail.com', 100000),
		('his@gmail.com', 100001),
		('his@gmail.com', 100002),
		('someones@gmail.com', 100003),
		('hers@gmail.com', 100003)
GO



/*
print '' print '*** inserting VendorLine test records ***'
INSERT INTO [dbo].[VendorLine]
        ([VendorID], [ProductID], [ProductName], [Price])
    VALUES
        (100000, 101, 'Product A', 10.99),
        (100001, 102, 'Product B', 15.50),
        (100002, 201, 'Product C', 8.75),
        (100003, 202, 'Product D', 12.25),
        (100004, 301, 'Product E', 9.99)
GO*/



/*
PRINT '' PRINT 'Inserting EventType sample data' 
GO
Inserting EventType sample data
CREATOR: Matthew Baccam
CREATED: 1/25/2023
SUMMARY: ??
LAST UPDATED BY: ??
LAST UPDATED: ??
WHAT WAS CHANGED: ??
*/
print '' print '*** inserting EventType test records ***'
GO
INSERT INTO [dbo].[EventType] ([EventTypeID], [EventID], [Information])
VALUES ('Food', 100000, 'Collecting non-perishable canned and boxed foods'),
       ('Supplies', 100001, 'Collecting new and gently used blankets'),
       ('Fundraiser', 100002, '5K run/walk to raise money for local shelters'),
       ('Rehab', 100003, 'Helps clients to become homed.'),
       ('Bake Sale', 100004, 'Collecting funds to support the shelter.')
GO



/*
print '' print '*** inserting EventLocation test records ***'
GO
INSERT INTO [dbo].[EventLocation]
        ([EventID], [LocationID], [LocationName], [Address], [Capacity])
    VALUES
    (100000, 100000, 'Convention Center', '123 Main St', 500),
    (100001, 100001, 'Community Hall', '456 Elm St', 200),
    (100002, 100002, 'Park Pavilion', '789 Oak St', 100),
    (100003, 100003, 'Conference Room', '101 Pine St', 50),
    (100004, 100004, 'Banquet Hall', '555 Maple St', 300)
GO*/



/*
print '' print '*** inserting RequestEvent test records ***'
INSERT INTO [dbo].[RequestEvent]
        ([RequestID], [EventID], [RequesterName], [RequestDate], [Status])
    VALUES
    (1, 100000, 'John Doe', '2024-01-20', 'Pending'),
    (2, 100001, 'Jane Smith', '2024-01-21', 'Approved'),
    (3, 100002, 'Mike Johnson', '2024-01-22', 'Pending'),
    (4, 100003, 'Emily Brown', '2024-01-23', 'Rejected'),
    (5, 100004, 'David Lee', '2024-01-24', 'Approved')
GO*/



/* 
Creator:            Abdalgader Ibrahim
Created:            02/27/2024
Summary:            Insert data for VolunteerEventLine table
Last Updated By:    Abdalgader Ibrahim
Last Updated:       02/27/2024
What Was Changed:   
*/

print '' print '*** inserting VolunteerEventLine test records ***'
GO
INSERT INTO [dbo].[VolunteerEventLine]
         ([VolunteerID], [EventID])
	VALUES
	    ('random@gmail.com', 100000),
		('guest@gmail.com', 100000),
		('someones@gmail.com', 100000),
		('random@gmail.com', 100001),
		('guest@gmail.com', 100001),
		('hers@gmail.com', 100001),
		('his@gmail.com', 100001),
		('someones@gmail.com', 100001),
		('hers@gmail.com', 100002),
		('his@gmail.com', 100002),
		('someones@gmail.com', 100002),
		('random@gmail.com', 100003),
		('guest@gmail.com', 100003),
		('someones@gmail.com', 100003),
		('random@gmail.com', 100004),
		('someones@gmail.com', 100004)
GO



/*
Creator: Wyatt Asher
Created: 1/22/2024
Summary: This is the insert statement for the EmployeeEventLine 
sample data.
Last Updated By: Wyatt Asher
Last Updated: 1/22/2024
What Was Changed: Initial Commit
*/
print '' print '*** Inserting EmployeeEventLine Test Records ***'
GO
INSERT INTO [dbo].[EmployeeEventLine]
        ([EmployeeID], [EventID])
    VALUES
        ('john@company.com', 100000),
        ('jane@company.com', 100001),
        ('jack@home.com', 100002),
        ('bill@company.com', 100003),
        ('shannon@company.com', 100004)
GO

PRINT '' PRINT '*** Inserting EventParticipants records ***'
GO
INSERT INTO [dbo].[EventParticipants] (EventID, ParticipantName, Email, RegistrationDate)
VALUES
	(100000, 'John Doe', 'johndoe@example.com', '2024-01-20'),
	(100001, 'Jane Smith', 'janesmith@example.com', '2024-01-21'),
	(100002, 'Jack Johnson', 'mikejohnson@example.com', '2024-01-22'),
	(100003, 'Bill Brown', 'emilybrown@example.com', '2024-01-23'),
	(100004, 'Shannon Lee', 'davidlee@example.com', '2024-01-24')
 GO

PRINT '' PRINT '*** Inserting Source records ***'
GO
INSERT INTO [dbo].[Source] (SourceName, Description)
VALUES
	('Job Board', 'Found through a job board'),
	('Employee Referral', 'Referred by a current employee'),
	('Company Website', 'Applied through the company website'),
	('Recruitment Agency', 'Recruited by a staffing agency'),
	('Social Media', 'Discovered through social media')
 GO

PRINT '' PRINT '*** Inserting Type records ***'
GO
INSERT INTO [dbo].[Type] (TypeName, Description)
VALUES
	('Full-Time', 'Regular full-time employee'),
	('Part-Time', 'Regular part-time employee'),
	('Contractor', 'Contractor or freelancer'),
	('Intern', 'Intern or temporary employee'),
	('Consultant', 'Consultant or specialist')
GO

/* 
    Creator:            Andres Garcia
    Created:            01/23/2024
    Summary:            Create test records for SpecialRequestLine table
    Last Updated By:    Andres Garcia
    Last Updated:       01/23/2024
    What Was Changed:   initial creation 
*/
print '' print '*** creating SpecialRequestLine test records ***'
GO
INSERT INTO [dbo].[SpecialRequestLine]
        ([SpecialPurchaseNo], [SprQtyOrdered],[SprQtyShipped],[ItemID])
    VALUES
        (100000, 30, 30, 100000),
		(100000, 15, 15, 100000),
		(100001, 20, 10, 100001),
		(100002, 20, 20, 100002),
		(100002, 5, 5, 100003)
GO

/* 
    Creator:            Andres Garcia
    Created:            01/23/2024
    Summary:            Create test records for OrderLineItem table
    Last Updated By:    Andres Garcia
    Last Updated:       01/23/2024
    What Was Changed:   initial creation
*/
print '' print '*** creating OrderLineItem test records ***'
GO
INSERT INTO [dbo].[OrderLineItem]
        ([OrderNo], [QtyOrdered], [QtyShipped], [ItemID])
    VALUES
        (100000, 10, 5, 100000),
		(100000, 5, 5,  100002),
		(100001, 5, 5,  100002),
		(100002, 10, 5, 100002),
		(100003, 5, 5, 	100002)
GO

/* 
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create test records for ExceptionLine table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   ???  
*/

print '' print '*** creating ExceptionLine test records ***'
GO
INSERT INTO [dbo].[ExceptionLine]
        ([Sequence], [QtyDifference])
    VALUES
        (100000, 15),
		(100001, 0),
		(100002, 0),
		(100003, 5),
		(100004, 0)
GO

/*
PRINT '*** Inserting test records into VendorLine ***'
GO
INSERT INTO [dbo].[VendorLine] ([VendorID], [EventID]) VALUES 
(100000, 101),
(100001, 102),
(100002, 103),
(100003, 104),
(100004, 105)
GO

-- Insert test records into VendorLocation
PRINT '*** Inserting test records into VendorLocation ***'
GO
INSERT INTO [dbo].[VendorLocation] ([StreetAddress], [VendorID], [City], 
[State], [Zipcode], [Notes]) VALUES 
('123 Main St', 100000, 'Anytown', 'NY', '12345', 'Near central park'),
('456 Elm St', 100002, 'Othertown', 'CA', '54321', 'Close to the beach'),
('789 Oak St', 100003, 'Thistown', 'TX', '11111', 'Next to the museum'),
('101 Pine St', 100004, 'Thatown', 'FL', '22222', 'In the downtown area'),
('202 Maple St', 100005, 'Heretown', 'WA', '33333', 'Near the university')
GO*/

-- Insert test records into EventLocation
PRINT '*** Inserting test records into EventLocation ***'
GO
INSERT INTO [dbo].[EventLocation] ([Address], [Zipcode]) VALUES 
('100 Event Blvd', 12345),
('200 Gala Rd', 23456),
('300 Fest Ave', 34567),
('400 Celebration St', 45678),
('500 Party Pl', 56789)
GO

/*-- Insert test records into RequestEvent
PRINT '*** Inserting test records into RequestEvent ***'
GO
INSERT INTO [dbo].[RequestEvent] ([ClientID], [EventTypeID], [Information]) 
VALUES 
(1, 'et001', 'Wedding request with outdoor setting'),
(2, 'et002', 'Corporate event for product launch'),
(3, 'et003', 'Birthday party with live music'),
(4, 'et004', 'Charity gala with silent auction'),
(5, 'et005', 'Conference with multiple speakers')
GO
*/

/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            01/31/2024
	Summary:            Insertion of test data into the PartsInventory table
	Last Updated By:    Mitchell Stirmel
	Last Updated:       01/31/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
PRINT '*** Inserting test records into PartsInventory ***'
GO
INSERT INTO [dbo].[PartsInventory] ([Category], [PartID], [Qty], [StockType]) VALUES 
('Safety Equipment', 'Safety Glasses', 6, 'In Stock'),
('Safety Equipment', 'Gloves', 3, 'In Stock'),
('Safety Equipment', 'Ear Proctection', 1, 'Almost out of Stock'),
('Cleaning Supplies', 'Solvent', 1, 'Almost out of Stock'),
('Cleaning Supplies', 'Degreaser', 0, 'Out of Stock'),
('Tools', 'Wrench', 7, 'In Stock'),
('Tools', 'Screwdriver', 5, 'In Stock'),
('Tools', 'Plier', 4, 'In Stock'),
('Fasteners and Hardware', 'Nuts', 12, 'In Stock'),
('Fasteners and Hardware', 'Bolts', 10, 'In Stock'),
('Fasteners and Hardware', 'Screws', 11, 'In Stock'),
('Fasteners and Hardware', 'Washers', 10, 'In Stock'),
('Electrical Components', 'Fuses', 0, 'Out of Stock'),
('Electrical Components', 'Wiring Connectors', 4, 'In Stock'),
('Electrical Components', 'Switches', 1, 'Almost out of Stock')
GO

/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            02/07/2024
	Summary:            Insertion of test data into the PartsInventoryUpdated table, we will only have one row in this table that gets updated.
	Last Updated By:    Mitchell Stirmel
	Last Updated:       02/07/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
PRINT '*** Inserting test records into PartsInventoryUpdatedDate ***'
GO
INSERT INTO [dbo].[PartsInventoryUpdatedDate] ([UpdatedDate]) VALUES 
(GETDATE())
GO

/* 
Creator:            Andrew Larson
Created:            01/29/2024
Summary:            Inserting data for HoursOfOperation Table
Last Updated By:    Andrew Larson
Last Updated:       01/29/2024
What Was Changed:   Initial Creation  */
PRINT '*** Inserting test records into HoursOfOperation ***'
GO
INSERT INTO [dbo].[HoursOfOperation]
		([HoursOfOperationString], [LocationID])
	VALUES
	("6:00AM - 6:00PM", 100000),
	("6:00AM - 7:00PM", 100001),
	("7:00AM - 7:00PM", 100002),
	("8:00AM - 6:00PM", 100003)
GO

/*
Creator:            Andrew Larson
Created:            02/18/2024
Summary:            Inserting data for ResourceCategory Table
Last Updated By:    Andrew Larson
Last Updated:       02/18/2024
What Was Changed:   Initial Creation  
PRINT '*** Inserting test records into ResourceCategory ***'
GO
INSERT INTO [dbo].[ResourceCategory]
		(Category)
	VALUES
	("Kitchen"),
	("Office"),
	("Event"),
	("Appointment"),
	("Room")
GO

Creator:            Andrew Larson
Created:            02/18/2024
Summary:            Inserting data for ResourcesNeeded Table
Last Updated By:    Andrew Larson
Last Updated:       02/18/2024
What Was Changed:   Initial Creation
PRINT '*** Inserting test records into ResourcesNeeded ***'
GO
INSERT INTO [dbo].[ResourcesNeeded]
		([ResourceID], [Category])
	VALUES
	("Pans", "Kitchen"),
	("Printer Paper", "Office"),
	("Disposable Cups", "Event"),
	("White Board", "Appointment"),
	("Sheets", "Room")
GO
*/

/* 
	<summary>
	Creator:            Abdalgader Ibrahim
	Created:            02/06/2024
	Summary:            Insertion of test data into the DonationType table
	Last Updated By:    Abdalgader Ibrahim
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
PRINT '*** Inserting test records into Donation Type ***'
GO
INSERT INTO [dbo].[DonationType] ([TypeName])  VALUES
('Cash'),
('Credit card'),
('Furniture'),
('Clothing'),
('Other')
GO

/* 
	<summary>
	Creator:            Abdalgader Ibrahim
	Created:            02/06/2024
	Summary:            Insertion of test data into the Donator table
	Last Updated By:    Abdalgader Ibrahim
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
PRINT '*** Inserting test records into Donator ***'
GO
INSERT INTO [dbo].[Donator] ([FamilyName],[PhoneNumber],[Email],[Address])  VALUES
('John', '3155151236', 'john@example.com', '125 Main St, Iowa City, IA, 52222'),
('Emily', '3155151237', 'emily@example.com', '126 Main St, Iowa City, IA, 52222'),
('Michael', '3155151238', 'michael@example.com', '128 Main St, Iowa City, IA, 52222'),
('Jessica', '3155151239', 'jessica@example.com', '129 Main St, Iowa City, IA, 52222'),
('Daniel', '3155151240', 'daniel@example.com', '130 Main St, Iowa City, IA, 52222'),
('Sarah', '3155151241', 'sarah@example.com', '131 Main St, Iowa City, IA, 52222'),
('William', '3155151242', 'william@example.com', '132 Main St, Iowa City, IA, 52222'),
('Ashley', '3155151243', 'ashley@example.com', '133 Main St, Iowa City, IA, 52222'),
('David', '3155151244', 'david@example.com', '134 Main St, Iowa City, IA, 52222'),
('Megan', '3155151245', 'megan@example.com', '135 Main St, Iowa City, IA, 52222'),
('Matthew', '3155151246', 'matthew@example.com', '136 Main St, Iowa City, IA, 52222'),
('Lauren', '3155151247', 'lauren@example.com', '137 Main St, Iowa City, IA, 52222'),
('Ryan', '3155151248', 'ryan@example.com', '138 Main St, Iowa City, IA, 52222'),
('Kayla', '3155151249', 'kayla@example.com', '139 Main St, Iowa City, IA, 52222'),
('Christopher', '3155151250', 'christopher@example.com', '140 Main St, Iowa City, IA, 52222'),
('Samantha', '3155151251', 'samantha@example.com', '141 Main St, Iowa City, IA, 52222'),
('Nicholas', '3155151252', 'nicholas@example.com', '142 Main St, Iowa City, IA, 52222'),
('Brittany', '3155151253', 'brittany@example.com', '143 Main St, Iowa City, IA, 52222'),
('Justin', '3155151254', 'justin@example.com', '144 Main St, Iowa City, IA, 52222'),
('Taylor', '3155151255', 'taylor@example.com', '145 Main St, Iowa City, IA, 52222'),
('Brandon', '3155151256', 'brandon@example.com', '146 Main St, Iowa City, IA, 52222')
GO

/* 
	<summary>
	Creator:            Abdalgader Ibrahim
	Created:            02/06/2024
	Summary:            Insertion of test data into the Donations table
	Last Updated By:    Abdalgader Ibrahim
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
PRINT '*** Inserting test records into Donations ***'
GO
INSERT INTO [dbo].[Donations] ([DonationTypeID],[DonatorID],[DonationName],[Amount],[DonationsDate],[Active])  VALUES
(100000,100000,'Moe','125','03/01/2024',1),
(100001,100001,'Doe','50','04/01/2024',1),
(100002,100002,'Jone','75', '04/11/2024',1),
(100003,100003,'Minh','25', '04/06/2024',1),
(100004,100004,'Reddi','65', '01/12/2024',1),
(100001,100005,'John','75','01/25/2024',1),
(100002,100006,'Jane','100','03/14/2024',1),
(100003,100007,'Jack','50','02/05/2024',1),
(100004,100008,'Jill','80','02/22/2024',1),
(100001,100009,'Bill','60','03/02/2024',1),
(100002,100010,'Emily','90','03/10/2024',1),
(100003,100011,'Tom','40','03/18/2024',1),
(100004,100012,'Jerry','55','03/26/2024',1),
(100001,100013,'David','70','02/12/2024',1),
(100002,100014,'Sarah','85','02/28/2024',1),
(100003,100015,'Michael','45','03/15/2024',1),
(100004,100016,'Rachel','95','04/29/2024',1),
(100001,100017,'Chris','65','01/20/2024',1),
(100002,100018,'Emma','110','01/05/2024',1),
(100003,100019,'Alex','30','02/10/2024',1),
(100003,100019,'Alex','30','04/10/2024',1)
GO

/* 
Creator:            Ibrahim Albashair
Created:            02/10/2024
Summary:            Inserting data for Visits Table
Last Updated By:    Ibrahim Albashair
Last Updated:       02/10/2024
What Was Changed:   Initial Creation  */
PRINT '*** Inserting test records into Visit ***'
GO
INSERT INTO [dbo].[Visit]
		([FirstName], [LastName], [CheckIn], [CheckOut], [VisitReason])
	VALUES
	("Jackson", "Davis", "04-23-2024", "04-23-2024", "Visit Client"),
	("Lip", "Gallagher", "04-25-2024", "", "Visit Client"),
	("Andrew", "Thomas", "04-28-2024", "", "Visit Client"),
	    ("Jacob", "Jim", "04-27-2024", "", "Visit Client"),
	("Jackson", "Davis", "04-28-2024", "", "Visit Client"),
	("Emily", "Johnson", "04-28-2024", "", "Visit Client")
GO

/* 
    <summary>
    Creator:            Ethan McElree
    Created:            02/13/2024
    Summary:            Created Schedule Test Records
    Last Updated By:    Ethan McElree
    Last Updated:       02/13/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting Schedule test records ***'
GO
INSERT INTO [dbo].[Schedule]
    ([ScheduleMonth], [ScheduleWeek], [ScheduleYear], [ScheduleStartDate], [ScheduleEndDate])
VALUES
    ('January', 1, 2024, '2024-01-01','2024-01-07'),
	('February', 1, 2024,'2024-02-05','2024-02-11'),
	('March', 3, 2024,'2024-03-18','2024-03-24'),
	('April', 4, 2024,'2024-04-22','2024-04-28'),
	('May', 2, 2024,'2024-05-06','2024-05-12'),
	('June', 4, 2024,'2024-06-24','2024-06-30'),
	('July', 1, 2024,'2024-07-01','2024-07-07'),
	('August', 2, 2024,'2024-08-05','2024-08-11'),
	('September', 1, 2024,'2024-09-02','2024-09-08'),
	('October', 3, 2024,'2024-10-21','2024-10-27'),
	('November', 1, 2024,'2024-11-04','2024-11-10'),
	('December', 4, 2024,'2024-12-23','2024-12-29')
GO
/* 
    <summary>
    Creator:            Jared Harvey
    Created:            02/06/2024
    Summary:            Create Shift Test Records
    Last Updated By:    Jared Harvey
    Last Updated:       02/06/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting Shift test records ***'
GO
INSERT INTO [dbo].[Shift]
    ([EmployeeID], [StartTime], [EndTime],[ScheduleID])
VALUES
    ('john@company.com', '20240206 8:00:00 AM', '20240206 4:00:00 PM', 100001),
	('jane@company.com', '20240207 8:00:00 AM', '20240207 4:00:00 PM', 100001),
	('jack@home.com', '20240208 8:00:00 AM', '20240208 4:00:00 PM', 100001),
	('bill@company.com', '20240209 8:00:00 AM', '20240209 4:00:00 PM', 100001),
	('shannon@company.com', '20240210 8:00:00 AM', '20240210 4:00:00 PM', 100001),
	('joe@company.com', '20240205 8:00:00 AM', '20240205 4:00:00 PM', 100001),
	('bob@company.com', '20240206 8:00:00 AM', '20240206 4:00:00 PM', 100001),
	('joe@company.com', '20240206 8:00:00 AM', '20240206 4:00:00 PM', 100001),
	('bob@company.com', '20240206 8:00:00 AM', '20240206 4:00:00 PM', 100001),
	('joe@company.com', '20240207 8:00:00 AM', '20240207 4:00:00 PM', 100001),
	('bob@company.com', '20240207 8:00:00 AM', '20240207 4:00:00 PM', 100001),
	('joe@company.com', '20240208 8:00:00 AM', '20240208 4:00:00 PM', 100001),
	('bob@company.com', '20240209 8:00:00 AM', '20240209 4:00:00 PM', 100001)
GO
/* 
    <summary>
    Creator:            Darryl Shirley
    Created:            03/22/2024
    Summary:            Created Applicant Records
    Last Updated By:    Darryl Shirley
    Last Updated:       03/22/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting Applicant records ***'
GO
INSERT INTO [dbo].[Applicant]
    ([GivenName], [FamilyName], [PhoneNumber], [Email])
VALUES
    ('Jim', 'Carrey',  '111-222-3333', 'funnyman@hotmail.com'),
	('Rick', 'Ross',  '000-222-3333', 'rapper@beats.com'),
	('This', 'Guy',  '012-334-4456', 'thisguy@company.com'),
	('That', 'Guy',  '012-345-6789', 'thatguy@company.com'),
	('Carl', 'Wheezer',  '111-222-3333', 'wheezer@nick.com')
GO

/*
CREATOR: Kirsten Stage
CREATED: 3/29/2024
SUMMARY: Inserting test data into the EventMeal table
LAST UPDATED BY: Kirsten Stage
LAST UPDATED: 3/29/2024
WHAT WAS CHANGED: Initial Creation
*/
print '' print '*** inserting EventMeal test records ***'
GO
INSERT INTO [dbo].[EventMeal] 
	([EventID], [Food], [Beverages]) 
	VALUES 
		(100000, 'Fresh Fruit, Charcuterie Board, and Pretzel Bites', 'Water, Soda, and Lemonade'),
		(100001, 'Grilled Cheese and Tomato Soup', 'Water, Soda, and Hot Chocolate'),
		(100002, 'Smoothie Bowl Bar', 'Water and Coffee'),
		(100003, 'BBQ Chicken Salad Bar and Fresh Fruit', 'Water, Energy Drinks, and Gatorade'),
		(100004, 'Taco Bar and Caesar Salads', 'Water, Energy Drinks, and Gatorade')
GO

/*
	<summary>
	Creator:            Sagan DeWald
	Created:            03/19/2024
	Summary:            ClientPriority test records.
	Last Updated By:    Sagan DeWald
	Last Updated:       04/25/2024
	What Was Changed:   New records.
	</summary>
*/
print '' print '*** inserting ClientPriority test records ***'
GO
INSERT INTO [dbo].[ClientPriority] 
    ([Client], [BasePriority], [Deductions], [NotableConvictions], [OtherHousingSituation])
VALUES
    ('john.doe@email.com', 1, 0, '', ''), 
    ('jane.smith@email.com', 2, 0, 'Assault', ''), 
    ('mike.johnson@email.com', 3, 0, '', ''),
    ('emily.brown@email.com', 4, 0, '', 'Fleeing from domestic abuse.'),
    ('chris.miller@email.com', 0, 0, '', ''),
    ('sarah.jones@email.com', 1, 0, '', ''), 
    ('david.wilson@email.com', 2, 0, 'Theft', ''), 
    ('lisa.thompson@email.com', 3, 0, '', ''), 
    ('kevin.evans@email.com', 4, 0, '', ''), 
    ('amanda.clark@email.com', 0, 0, '', ''),
    ('steven.roberts@email.com', 2, 0, '', ''), 
    ('sophia.smith@email.com', 3, 0, '', ''), 
    ('ryan.johnson@email.com', 4, 0, '', ''), 
    ('olivia.brown@email.com', 0, 0, '', ''),
    ('ethan.wilson@email.com', 2, 0, '', ''), 
    ('ava.thompson@email.com', 3, 0, '', ''), 
    ('noah.evans@email.com', 4, 0, '', ''), 
    ('mia.clark@email.com', 0, 0, '', ''),
    ('lucas.roberts@email.com', 3, 0, '', ''), 
    ('amelia.jones@email.com', 4, 0, '', ''), 
    ('jayden.smith@email.com', 0, 0, '', '')
GO

/* 
    <summary>
    Creator:            Darryl Shirley
    Created:            03/22/2024
    Summary:            Created VolunteerApplication Records
    Last Updated By:    Mitchell Stirmel
    Last Updated:       04/03/2024
    What Was Changed:   Updated to fit the new VolunteerApplication table data requirements.  
    </summary>
*/
print '' print '*** inserting VolunteerApplication records ***'
GO
INSERT INTO [dbo].[VolunteerApplication]
    ([ApplicantID], [ApplicationReason], [HoursDesired], [VolunteerConcerns])
VALUES
    (100006, "RandomAppReason", 40, "I have no concerns"),
	(100007, "I wish to help homeless people", 15, "Sampleconcerns"),
	(100008, "Blah blah blah", 5, "adausdnadjawd"),
	(100009, "Lorem Ipsum", 20, "iu ui iuer")
GO

/* 
    <summary>
    Creator:            Liam Easton
    Created:            04/04/2024
    Summary:            Created TransportItem Records
    Last Updated By:    Liam Easton
    Last Updated:       04/04/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting TransportItem records ***'
GO
INSERT INTO [dbo].[TransportItem]
    ([ClientID], [LocationID], [DayPosted], [DayToPickUp], [DayDroppedOff], [AssignedDriver], [Fulfilled])
VALUES
    ('sarah.jones@email.com', 100000, '2024-03-15', '2024-03-20', '2024-03-25', 'john@company.com', 1),
    ('david.wilson@email.com', 100001, '2024-03-16', '2024-03-21', null, 'jane@company.com', 0),
    ('lisa.thompson@email.com', 100002, '2024-03-17', '2024-03-22', '2024-03-27', 'jack@home.com', 1),
    ('kevin.evans@email.com', 100003, '2024-03-18', '2024-03-23', null, 'bill@company.com', 0),
    ('amanda.clark@email.com', 100004, '2024-03-19', '2024-03-24', '2024-03-29', 'shannon@company.com', 1),
    ('steven.roberts@email.com', 100005, '2024-03-20', '2024-03-25', null, 'joe@company.com', 0),
    ('sarah.jones@email.com', 100000, '2024-03-21', '2024-03-26', '2024-03-31', 'john@company.com', 1),
    ('david.wilson@email.com', 100001, '2024-03-22', '2024-03-27', null, 'jane@company.com', 0),
    ('lisa.thompson@email.com', 100002, '2024-03-23', '2024-03-28', '2024-04-02', 'jack@home.com', 1),
    ('kevin.evans@email.com', 100003, '2024-03-24', '2024-03-29', null, 'bill@company.com', 0),
    ('amanda.clark@email.com', 100004, '2024-03-25', '2024-03-30', '2024-04-04', 'shannon@company.com', 1),
    ('steven.roberts@email.com', 100005, '2024-03-26', '2024-03-31', null, 'joe@company.com', 0)
GO

/*
    <summary>
    Creator:            Liam Easton
    Created:            04/04/2024
    Summary:            Created TransportLine Records
    Last Updated By:    Liam Easton
    Last Updated:       04/04/2024
    What Was Changed:   Initial Creation  
    </summary>
*/
print '' print '*** inserting TransportLine records ***'
GO
INSERT INTO [dbo].[TransportLine]
    ([LineItemAmount], [ItemID], [TransportItemID], [VendorID])
VALUES
    (100.50, 100000, 100000, 100000),
    (200.75, 100001, 100001, 100001),
    (150.25, 100002, 100002, 100002),
    (101.90, 100003, 100003, 100003),
    (223.35, 100004, 100004, 100004),
    (10.40,  100005, 100005, 100005),
    (100.50, 100006, 100006, 100006),
    (200.75, 100007, 100007, 100007),
    (150.25, 100008, 100008, 100008),
    (101.90, 100009, 100009, 100009),
    (223.35, 100010, 100010, 100010),
    (10.40, 100011, 100011, 100011)
GO

/* 
    <summary>
    Creator:            Kirsten Stage
    Created:            04/11/2024
    Summary:            Inserting FundraisingEvent Records
    Last Updated By:    Kirsten Stage
    Last Updated:       04/11/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** inserting FundraisingEvent records ***'
GO
INSERT INTO [dbo].[FundraisingEvent]
	([EventName], [FundraisingGoal], [EventAddress], [EventDate], [StartTime], [EndTime], [EventDescription])
VALUES
	('Event1', 50000, '123 45th St. Cedar Rapids, IA 63122', '2024-06-15', '09:00:00', '17:00:00', 'Help end homelessness in Iowa. Your support is more than money. Its a gift of hope.'),
	('Event2', 50000, '123 45th St. Cedar Rapids, IA 63122', '2024-12-14', '09:00:00', '17:00:00', 'Help end homelessness in Iowa. Your support is more than money. Its a gift of hope.'),
	('Event3', 50000, '123 45th St. Cedar Rapids, IA 63122', '2025-06-14', '09:00:00', '17:00:00', 'Help end homelessness in Iowa. Your support is more than money. Its a gift of hope.'),
	('Event4', 50000, '123 45th St. Cedar Rapids, IA 63122', '2025-12-13', '09:00:00', '17:00:00', 'Help end homelessness in Iowa. Your support is more than money. Its a gift of hope.')
GO

/* 
    <summary>
    Creator:            Donald Winchester
    Created:            04/15/2024
    Summary:            Inserting MembershipApplication Records
    Last Updated By:    Donald Winchester
    Last Updated:       04/15/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** inserting MembershipApplications records ***'
GO
INSERT INTO [dbo].[MembershipApplications]
	([FirstName], [LastName], [DateOfBirth], [Sex], [SSN], [PhoneNumber], [EmailAddress], [Status])
VALUES
	('Donald', 'Whatshisface', '05/11/2004', 'Male', '123-45-6789', '3195551111', 'donald@homelessshelter.com', 'Accepted'),
	('Janie', 'Whatsherface', '12/12/1999', 'Female', '123-45-6781', '3195552222', 'janie@homelessshelter.com', 'Declined')
GO


/* 
    <summary>
    Creator:            Darryl Shirley
    Created:            04/17/2024
    Summary:            Inserting Volunteer Questionnaire Records
    Last Updated By:    Darryl Shirley
    Last Updated:       04/17/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** inserting Volunteer_Questionnaire records ***'
GO
INSERT INTO [dbo].[Volunteer_Questionnaire]
	([VolunteerID], [SkillsList], [Vehicles], [PriorExperience], [StudentCheck], [SchoolName], [GroupWork])
VALUES
	('someones@gmail.com', 'Plays the guitar and can lift heavy things.', 'Can drive trucks and fork lifts', 1, 1, 'Kirkwood Community College', 0),
	('hers@gmail.com', 'Public Speaking, dancing', 'I do not have a license to drive any vehicles', 0, 0, 'N/A', 1)
GO

/* 
Creator:           	Seth Nerney
Created:            02/25/2024
Summary:            Inserting data for Repair Table
Last Updated By:    Seth Nerney
Last Updated:       02/25/2024
What Was Changed:   Initial Creation  */
print '' print'*** inserting test records into Repair ***'
GO
INSERT INTO [dbo].[Repair]
		([RequestID], [EmployeeID], [Status])
	VALUES
	(100000, "john@company.com", "Scheduled for repair"),
	(100000, "john@company.com", "Scheduled for repair"),
	(100001, "jack@home.com", "Needs repair"),
	(100001, "jack@home.com", "Scheduled for repair"),
	(100002, "bill@company.com", "Scheduled for repair"),
	(100003, "bill@company.com", "Scheduled for repair"),
	(100004, "bill@company.com", "Scheduled for repair"),
	(100004, "john@company.com", "Scheduled for repair")
GO