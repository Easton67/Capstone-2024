/* check to see if the database exists, if so, drop it*/
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'masterhomelessdb')
BEGIN
	DROP DATABASE masterhomelessdb
	print '' print '*** dropping database homelessdb ***'
END
GO

print '' print '*** creating database homelessdb ***'
GO
CREATE DATABASE [masterhomelessdb]
GO

print '' print '*** using database homelessdb ***'
GO
USE [masterhomelessdb]
GO

/*****************************************************************************
							TABLE CREATION
*****************************************************************************/

/* 
<summary>
Creator:            Liam Easton
Created:            01/19/2024
Summary:            Creation for LogConfiscatedItem table
Last Updated By:    ???
Last Updated:       ???
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating LogConfiscatedItem Table ***'
GO
CREATE TABLE [dbo].[LogConfiscatedItem] 
(
	[LogConfiscatedItemsID]    [int] IDENTITY(100000,1)   NOT NULL,
	[ItemsConfiscated]   	   [nvarchar](100)            NOT NULL,
	[ConfiscationDate]	       [date]			          NOT NULL,
	[ReasonForConfiscation]	   [text]			          NOT NULL
)
GO


/*Creating Event Table
CREATOR: Matthew Baccam
CREATED: 1/25/2023
SUMMARY: ??
LAST UPDATED BY: Darryl Shirley
LAST UPDATED: 02/07/2024
WHAT WAS CHANGED: Added new volunteerNeeded field to table
LAST UPDATE BY: Marwa ibrahim
LAST UPDATE: 04/22/2024
WHAT WAS CHANGE: Added Active Coulmn bit Default 1
*/
print '' print '*** creating Event Table ***'
GO
CREATE TABLE [dbo].[Event](
    [EventID]       	[INT] IDENTITY(100000,1)    NOT NULL,
    [EventName]     	[NVARCHAR](100)             NOT NULL,
    [Description]   	[NVARCHAR](100)             NOT NULL,
	[VolunteersNeeded]	[INT]	NOT NULL,
	[Active] [bit] DEFAULT 1,
	CONSTRAINT [pk_Event_EventID] PRIMARY KEY ([EventID])
)
GO

/*
Creator: Wyatt Asher
Created: 1/26/2024
Summary: This is the table for the dates and times of events.
Last Updated By: Wyatt Asher
Last Updated: 1/26/2024
What Was Changed: Initial Commit
*/
print '' print '*** creating EventSchedule table ***'
GO
CREATE TABLE [dbo].[EventSchedule] (
    [EventScheduleID]       [int]          IDENTITY(100000, 1) UNIQUE NOT NULL,
    [EventID]               [int]          NOT NULL,
    [StartTime]             [datetime]     NOT NULL,
    [EndTime]               [datetime]     NOT NULL,
    [EventDay]              [date]         NOT NULL,

    CONSTRAINT [fk_EventSchedule_EventID] FOREIGN KEY([EventID])
        REFERENCES [dbo].[Event] ([EventID]),
        
    CONSTRAINT [pk_EventScheduleID] PRIMARY KEY([EventScheduleID])
)
GO

/*
   <summary>
   Creator: Donald Winchester
   Created: 1/24/2024
   Summary: This creates the ServiceType table.
   Last Updated By: Donald Winchester
   Last Updated: 1/24/2024
   What Was Changed: Initial Creation
   Last Updated By: Liam Easton
   Last Updated: 4/11/2024
   What Was Changed: changed from just an int to identity
   </summary>
*/
print " " print '*** creating ServiceType table ***'
GO
CREATE TABLE [dbo].[ServiceType] (
    [ServiceTypeID]     [INT]             IDENTITY(100000, 1) NOT NULL,
    [TypeName]          [NVARCHAR](50)    NOT NULL,
    [Description]       [NVARCHAR](250)   NOT NULL,
	CONSTRAINT [pk_ServiceTypeID] PRIMARY KEY([ServiceTypeID])
)
GO

/* 
	<summary>
	Creator:            Liam Easton
	Created:            01/19/2024
	Summary:            Creation for Location table
	Last Updated By:    Liam Easton
	Last Updated:       01/19/2023
	What Was Changed:   ???  
	</summary> 
*/
print '' print '*** creating Location Table ***'
GO
CREATE TABLE [dbo].[Location] 
(
	[LocationID]      [int] IDENTITY(100000,1)   NOT NULL,
	[LocationName] 	  [nvarchar](50)          	 NOT NULL,
	[Address]		  [nvarchar](50)			 NOT NULL,
	[City] 	          [nvarchar](100)            NOT NULL,
	[State] 		  [nvarchar](100)            NOT NULL,
	[ZipCode]	      [int]		                 NOT NULL,
	CONSTRAINT [pk_LocationID] PRIMARY KEY ([LocationID])
)
GO

/*
	<summary>
	Creator: Seth Nerney
	Created: 1/25/2024
	Summary: This table holds data about the grant application letter
	Last Updated By: Seth Nerney
	Last Updated: 1/25/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating GrantApplicationLetter table ***'
GO
CREATE TABLE [dbo].[GrantApplicationLetter] (
	[GrantApplicationLetterID]	[int] IDENTITY(100000, 1) 	NOT NULL,
	[GrantName]				    [nvarchar](25),
	[SubmissionDate]		    [DATE],
	[ResubmissionDate]		    [DATE],
	CONSTRAINT [pk_GrantApplicationLetterID] PRIMARY KEY([GrantApplicationLetterID]),
)
GO


/*
	<summary>
	Creator: Seth Nerney
	Created: 1/25/2024
	Summary: This table holds data about the partners
	Last Updated By: Seth Nerney
	Last Updated: 1/25/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating Partners table ***'
GO
CREATE TABLE [dbo].[Partners] (
	[PartnerID]				[int] IDENTITY(100000, 1) 	NOT NULL,
	[Email]					[nvarchar](50)				NOT NULL,
	[GivenName]				[nvarchar](25)				NOT NULL,
	[FamilyName]			[nvarchar](25)				NOT NULL,
	[Organization]			[nvarchar](50),
	[CurrentPartner]		[bit]		DEFAULT 0,
	CONSTRAINT [pk_PartnerID] PRIMARY KEY([PartnerID])
)
GO


/* Skills Table */
print '' print '*** creating  skills table ***'
GO
CREATE TABLE [dbo].[Skills] (
    [SkillID]          [int]  IDENTITY(100000, 1)    NOT NULL,
	[SkillName]        [nvarchar]     (50)           NOT NULL,
	CONSTRAINT [pk_SkillID] PRIMARY KEY ([SkillID])  
)
GO

/* 
	<summary>
	Creator:            Anthony Talamantes
	Created:            01/24/2024
	Summary:            Creation for Applicant table
	Last Updated By:    Anthony Talamantes
	Last Updated:       01/24/2024
	What Was Changed:   ???
	</summary>
*/
print '' print '*** creating Applicant table ***'
GO
CREATE TABLE [dbo].[Applicant] (
	[ApplicantID]	  [int] IDENTITY(100000, 1) 	      NOT NULL,
    [GivenName]	      [nvarchar](50)       				  NOT NULL,
	[FamilyName]	  [nvarchar](50)       				  NOT NULL,
	[PhoneNumber]	  [nvarchar](12)       				  NOT NULL,
    [Email]		      [nvarchar](250)       			  NOT NULL,

	CONSTRAINT [pk_ApplicantID] PRIMARY KEY([ApplicantID])
)
GO

/*
	<summary>
	Creator: Marwa ibrahim
	created: 01/25/2024
	Summary: Transport Vehicle table
	Last updated By: Darryl Shirley
	Last Updated: 1-26-2024
	What was changed/updated: Edited insert table values
	</summary>
*/
print '' print '*** creating Transport Vehicle table ***'
GO
CREATE TABLE [dbo].[TransportVehicle] (
    [VehicleIdentificationNumber]           [nvarchar] (17) 	  UNIQUE   	NOT NULL,
	[InsurancePolicyNumber]        			[nvarchar] (50)       UNIQUE    NOT NULL,
	[VehicleYear]       					[int]             				NOT NULL,
	[VehicleMake]       					[nvarchar] (50)             	NOT NULL,
	[VehicleModel]        					[nvarchar] (50)             	NOT NULL,
	[VehicleColor]    						[nvarchar]   (50)      			NOT NULL,
	CONSTRAINT   [pk_VehicleIdentificationNumber] PRIMARY KEY ([VehicleIdentificationNumber])
)
GO


/* 
	<summary>
	CREATOR: Sagan Dewald
	CREATED: 1/24/2023
	SUMMARY: Vendor table
	LAST UPDATED BY: Mitchell Stirmel
	LAST UPDATED: 02/13/2024
	WHAT WAS CHANGED: Removed state and city fields. Added email field
	</summary>
*/

print '' print '*** creating vendor table ***'
GO
CREATE TABLE [dbo].[Vendor] (
	[VendorID]		        [int] IDENTITY(100000, 1)   NOT NULL,
	[VendorName]	        [nvarchar](100)				          NOT NULL,
	[VendorAddress]         [nvarchar](100)                       NOT NULL,
	[VendorEmail]			[nvarchar](255)						  NOT NULL,
    [VendorContactPhone]    [nvarchar](11)                        NOT NULL,
    [VendorContactName]     [nvarchar](50)                        NOT NULL,
	CONSTRAINT [pk_VendorID] PRIMARY KEY([VendorID])
)
GO

/* 
	<summary>
	Creator:            Jared Harvey
	Created:            01/23/2024
	Summary:            Create Shelter Table
	Last Updated By:    Jared Harvey
	Last Updated:       01/23/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** creating Shelter table ***'
GO
CREATE TABLE [dbo].[Shelter] (
	[ShelterID]		[nvarchar] 	(50)					NOT NULL,
	[Address]		[nvarchar] 	(50)					NOT NULL,
	[Capacity]		[int]								NOT NULL,
	CONSTRAINT [pk_ShelterID] PRIMARY KEY ([ShelterID]),
	CONSTRAINT [ak_Shelter_Address] UNIQUE([Address])
)
GO

/* 
    <summary>
    Creator: Donald Winchester
    Created: 1/24/2024
    Summary: This creates the Department table.
    Last Updated By: Jared Harvey
    Last Updated: 02/07/2024
    What Was Changed: Changed DepartmentID back to an INT and added a foreign key refrencing the Shelter table.
    </summary>
*/
print " " print '** creating Department table ***'
GO
CREATE TABLE [dbo].[Department] (
    [DepartmentID] 		[INT] IDENTITY(100000, 1) 	NOT NULL,
	[ShelterID]			[nvarchar](50)				NOT NULL,
	[DepartmentName]	[nvarchar](50)				NOT NULL,
    [Description] 		[nvarchar](255) 			NOT NULL,
	CONSTRAINT [fk_Department_ShelterID] FOREIGN KEY ([ShelterID])
	    REFERENCES [dbo].[Shelter] ([ShelterID]),
    CONSTRAINT [pk_Department] PRIMARY KEY ([DepartmentID])
)
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create Order table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   Initial Creation  
Last Updated By:    Mitchell Stirmel
Last Updated:       03/04/2024
What Was Changed:   ON DELETE CASCADE addition for vendor deletion  
</summary>
*/
print '' print '*** creating Order table ***'
GO
CREATE TABLE [dbo].[Order] (
    [OrderNo]   	[int] IDENTITY(100000,1)    	 NOT NULL,
    [OrderDate]     [DATE] 		             	 NOT NULL,
	[VendorID]		[int]						 NOT NULL,
    [TotalItems]    [int] 		              	 NOT NULL,
	[OrderNotes]    [nvarchar] (255)             NOT NULL
	CONSTRAINT [pk_Order] PRIMARY KEY ([OrderNo]),
    
	CONSTRAINT [fk_Order_VendorID] FOREIGN KEY ([VendorID])
	    REFERENCES [dbo].[Vendor] ([VendorID]) ON DELETE CASCADE
    
)
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create Item table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating Item table ***'
GO
CREATE TABLE [dbo].[Item] (
    [ItemID]    		 [int] IDENTITY(100000,1)    	 NOT NULL,
    [ItemName]     		 [nvarchar] (50)             NOT NULL,
    [ItemDescription]    [nvarchar] (255)            NOT NULL,
	[QtyOnHand]			 [int]						 NOT NULL,
	[NormalStockQty]	 [int]						 NOT NULL,
	[ReorderPoint]		 [int]						 NOT NUll,
	[OnOrder]			 [int]						 NOT NULL,
	CONSTRAINT [pk_Item] PRIMARY KEY ([ItemID])
)
GO

/* 
Creator:            Ethan McElree
Created:            01/19/2024
Summary:            Creation for KitchenInventoryItem table
Last Updated By:    Andrew Larson
Last Updated:       02/02/2024
What Was Changed:   Fixed various issues that were causing errors on the Insert statments 
*/
print '' print '*** creating KitchenInventoryItem table ***'
GO
CREATE TABLE [dbo].[KitchenInventoryItem] (
	[KitchenItemID]			[int]  	IDENTITY(100000,1)		NOT NULL,
	[ItemName]				[nvarchar] (50)					NOT NULL,
	[QuantityInStock]		[int]   						NULL DEFAULT 0,
	[Category]				[nvarchar] (50) 				NOT NULL,
	[UnitCost]				[decimal] (9, 2)				NULL DEFAULT 0.00,
	[Supplier]				[nvarchar] (50)  				NOT NULL,
	[ReorderQuantity]		[int]  							NULL DEFAULT 0,
	CONSTRAINT [pk_KitchenItemID] PRIMARY KEY([KitchenItemID])
)
GO

/* 
	<summary>
	Creator:            Ethan McElree
	Created:            01/19/2024
	Summary:            Creation for WeekFoodMenu table
	Last Updated By:    Andrew Larson
	Last Updated:       02/09/2024
	What Was Changed:   Updated MenuID to an INT IDENTITY field instead of type 'Date'
	</summary>
*/
print '' print '*** creating WeekFoodMenu table ***'
GO
CREATE TABLE [dbo].[WeekFoodMenu] (
	[MenuID]				[int]IDENTITY(100000,1)  			NOT NULL,
	[DayOfMeal]				[nvarchar] (50) 					NOT NULL,
	[MenuName]				[nvarchar] (50) 					NOT NULL,
	[MenuType]				[nvarchar] (11) 					NOT NULL,
	[DateLastModified]		[Date],
	CONSTRAINT [pk_MenuID] PRIMARY KEY([MenuID])
)
GO

/*
Creator: Wyatt Asher
Created: 1/22/2024
Summary: This is the table for employee records.
Last Updated By: Wyatt Asher
Last Updated: 1/22/2024
What Was Changed: Initial Commit
*/
print '' print '*** creating Employee table ***'
GO
CREATE TABLE [dbo].[Employee] (
    [EmployeeID]    [nvarchar] (100)    NOT NULL UNIQUE,
    [Fname]         [nvarchar] (25)     NOT NULL,
    [Lname]         [nvarchar] (25)     NOT NULL,
    [Phone]         [nvarchar] (15)     NOT NULL,
    [Gender]        [bit]               NOT NULL,
    [PasswordHash]  [nvarchar] (256)    NOT NULL,
    [AccountStatus] [bit]               NOT NULL DEFAULT 1,
    [ZipCode]       [int]               NOT NULL,
    [Address]       [nvarchar] (50)     NOT NULL,
    [StartDate]     [date]              NOT NULL,
    [EndDate]       [date],
        
    CONSTRAINT [pk_EmployeeID] PRIMARY KEY([EmployeeID])
)
GO


/* 
Creator:            Jared Harvey
Created:            01/23/2024
Summary:            Create ShelterEmployee Table
Last Updated By:    ???
Last Updated:       ???
What Was Changed:   ???  */
print '' print '*** creating ShelterEmployee table ***'
GO
CREATE TABLE [dbo].[ShelterEmployee] (
	[EmployeeID]	[nvarchar](100)						NOT NULL,
	[ShelterID]		[nvarchar](50)						NOT NULL,
	CONSTRAINT	[fk_ShelterEmployee_EmployeeID]	FOREIGN KEY ([EmployeeID])
		REFERENCES	[dbo].[Employee] ([EmployeeID]),
	CONSTRAINT	[fk_ShelterEmployee_ShelterID]	FOREIGN KEY ([ShelterID])
		REFERENCES	[dbo].[Shelter] ([ShelterID]) ON DELETE CASCADE,
	CONSTRAINT [pk_ShelterEmployee] PRIMARY KEY ([EmployeeID], [ShelterID])
)
GO

/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Creation for Reminder table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   ???
</summary>
*/
print '' print '*** creating Reminder table ***'
GO
CREATE TABLE [dbo].[Reminder] (
	[ReminderID]	[int] IDENTITY(100000, 1) 	  NOT NULL,
	[EmailTo]		[nvarchar](100)       		  NOT NULL,
	[EmailFrom]		[nvarchar](100)       		  NOT NULL,
    [Title]		    [nvarchar](50)       		  NOT NULL,
    [Message]       [text]                        NOT NULL,
    [Frequency]     [nvarchar](25)                NOT NULL,
    [Date]          [date]                        NOT NULL,
    [Read]          [bit]                         NOT NULL,
    [Deactivate]    [bit]                         NOT NULL,

	CONSTRAINT [pk_ReminderID] PRIMARY KEY([ReminderID])
)
GO


/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Creation for Message table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   ???
</summary>
*/
print '' print '*** creating Message table ***'
GO
CREATE TABLE [dbo].[Message] (
    [MessageID]	    [int] IDENTITY(100000, 1) 	  NOT NULL,
    [EmailTo]		[nvarchar](100)       		  NOT NULL,
    [EmailFrom]		[nvarchar](100)       		  NOT NULL,
    [Title]		    [nvarchar](50)       		  NOT NULL,
    [Message]       [text]                        NOT NULL,
    [Date]          [date]                        NOT NULL,
    [Read]          [bit]                         NOT NULL,
    [CheckedOff]    [bit]                         NOT NULL,
    [RemindOnDate]  [date]                        NOT NULL,
    [HideFromView]  [bit]                         NOT NULL,

	CONSTRAINT [pk_MessageID] PRIMARY KEY([MessageID])
)
GO

/*
<summary>
Creator: Darryl Shirley
created: 01/22/2024
Summary: Service Providers table
Last updated By: Darryl Shirley
Last Updated: 1-26-2024
What was changed/updated: updated test records
</summary>
*/
print '' print '*** creating Service Providers table ***'
GO
CREATE TABLE [dbo].[ServiceProviders](
	[ServiceProviderID]	[nvarchar] (100)	  NOT NULL,
	[ServiceDate] 		[Date]				  NOT NULL,
	[ContactPerson]	 	[nvarchar] (75)		  NOT NULL,
	[ContactEmail]	 	[nvarchar] (100)	  NOT NULL,
	[ContactPhone]	 	[nvarchar] (15)	      NOT NULL,
	[Address]	 		[nvarchar] (50)		  NOT NULL,
	[ProviderType]	 	[nvarchar] (25)		  NOT NULL,
	
	CONSTRAINT [pk_ServiceProviderID] PRIMARY KEY([ServiceProviderID])
	
)
GO

/* 
<summary>
Creator:            Tyler Barz
Created:            01/19/2024
Summary:            Creation for Role table
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   I added a foreign key constraint for department
					and changed the primary key to just be the role name
</summary>
*/
print '' print '*** creating Role Table ***'
GO
CREATE TABLE Role (
    [RoleID]	            NVARCHAR(50)            NOT NULL,
	[DepartmentID]			INT						NOT NULL,
    [Description]	        NVARCHAR(255)           NOT NULL,
    [PositionsAvailable]	INT                     NOT NULL,
	CONSTRAINT	[fk_Role_DepartmentID]	FOREIGN KEY ([DepartmentID])
		REFERENCES	[dbo].[Department] ([DepartmentID]),
    CONSTRAINT [pk_Role] PRIMARY KEY ([RoleID])
)
GO

/*
	<summary>
	Creator: Andrew Larson
	Created: 1/23/2024
	Summary: This table holds data about the
		service provider applications.
	Last Updated By: Andrew Larson
	Last Updated: 1/23/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating ServiceProviderApplication table ***'
GO
CREATE TABLE [dbo].[ServiceProviderApplication] (
	[ServiceProviderApplicationID]	[int]			NOT NULL,
	[GivenName]						[nvarchar](50)	NOT NULL,
	[FamilyName]					[nvarchar](50)	NOT NULL,
	[Organization]					[nvarchar](50)	NULL,
	[ApplicationDate]				[date]			NOT NULL,
	[CurrentStatus]					[bit]			NOT NULL,
	CONSTRAINT [pk_ServiceProviderApplicationID] PRIMARY KEY ([ServiceProviderApplicationID])
)
GO


/*
	<summary>
	Creator: Andrew Larson
	Created: 1/23/2024
	Summary: This table holds data about the donation type.
	Last Updated By: Andrew Larson
	Last Updated: 1/23/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating DonationType table ***'
GO
CREATE TABLE [dbo].[DonationType] (
	[DonationTypeID]	[int] IDENTITY(100000, 1)	NOT NULL,
	[TypeName]			[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_DonationTypeID]	PRIMARY KEY ([DonationTypeID]),
	CONSTRAINT [ak_DonationTypeID]	UNIQUE ([DonationTypeID])
)
GO

/*
	<summary>
	Creator: Andrew Larson
	Created: 1/23/2024
	Summary: This table holds data about the donator.
	Last Updated By: Andrew Larson
	Last Updated: 1/23/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating Donator table ***'
GO
CREATE TABLE [dbo].[Donator] (
	[DonatorID] 		[int] IDENTITY(100000, 1)	NOT NULL,
	[FamilyName]		[nvarchar](50)				NOT NULL,
	[PhoneNumber]		[nvarchar](11)				NOT NULL,
	[Email]				[nvarchar](250)				NOT NULL,
	[Address]			[nvarchar](250)				NOT NULL,
	CONSTRAINT [pk_DonatorID]	PRIMARY KEY ([DonatorID]),
	CONSTRAINT [ak_DonatorID]	UNIQUE ([DonatorID]),
	CONSTRAINT [ak_Email]		UNIQUE ([Email])		
)
GO

/*
	<summary>
	Creator:            Kirsten Stage
	Created:            02/01/2024
	Summary:            Create RoomStatus Table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/01/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating RoomStatus table ***'
GO
CREATE TABLE [dbo].[RoomStatus] (
	[Status]		[nvarchar](50),
	CONSTRAINT [pk_Status] PRIMARY KEY([Status])
)
GO

/*
	<summary>
	Creator:            Jared Harvey
	Created:            02/12/2024
	Summary:            Create CleaningStatus Table
	Last Updated By:    Jared Harvey
	Last Updated:       02/12/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating CleaningStatus table ***'
GO
CREATE TABLE [dbo].[CleaningStatus] (
	[Status]		[nvarchar](50),
	CONSTRAINT [pk_CleaningStatus] PRIMARY KEY([Status])
)
GO

/* 
	<summary>
	Creator:            Jared Harvey
	Created:            01/23/2024
	Summary:            Create Room Table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/01/2024
	What Was Changed:   
		Made 'Status' a foreign key
	</summary>
*/
print '' print '*** creating Room table ***'
GO
CREATE TABLE [dbo].[Room] (
	[RoomID]		[int] 		IDENTITY(100000, 1)		NOT NULL,
	[ShelterID]		[nvarchar]	(50)					NOT NULL,
	[RoomNumber]	[int]								NOT NULL,
	[Status]		[nvarchar] 	(50)					NOT NULL,
	CONSTRAINT	[fk_Room_ShelterID]	FOREIGN KEY ([ShelterID])
		REFERENCES	[dbo].[Shelter] ([ShelterID]) ON DELETE CASCADE,
	CONSTRAINT	[fk_Room_Status]	FOREIGN KEY ([Status])
		REFERENCES	[dbo].[RoomStatus] ([Status])ON DELETE CASCADE,
	CONSTRAINT [pk_RoomID] PRIMARY KEY ([RoomID])
	
)
GO

/* 
<summary>
Creator:            Tyler Barz
Created:            01/19/2024
Summary:            Creation for Volunteer table
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   Changed RoleID from type INT to type NVARCHAR(50)
</summary>
 */
print '' print '*** creating Volunteer Table ***'
GO
CREATE TABLE Volunteer (
    [VolunteerID]	        NVARCHAR(100)   NOT NULL,                
    [FirstName]	                NVARCHAR(25)    NOT NULL,                
    [LastName]	                NVARCHAR(25)    NOT NULL,                
    [Phone]	                NVARCHAR(15)    NOT NULL,                
    [Gender]	            BIT             NOT NULL, 
	[PasswordHash]			NVARCHAR(256)	NOT NULL,
    [AccountStatus]	        BIT             NOT NULL,    
    [RoleID]	            NVARCHAR(50)	NOT NULL,    
    [RegistrationDate]	    DATETIME        NOT NULL,            
    [Address] 	            NVARCHAR(50)    NOT NULL,                
    [ZipCode]	            INT             NOT NULL,    
    CONSTRAINT [pk_Volunteer] PRIMARY KEY ([VolunteerID]),
    CONSTRAINT [fk_Volunteer_RoleID] FOREIGN KEY ([RoleID])
        REFERENCES [Role]([RoleID]) ON DELETE CASCADE
)
GO

/*
Creator: Wyatt Asher
Created: 1/22/2024
Summary: This is the table any incidents that transpire in the shelter.
Last Updated By: Wyatt Asher
Last Updated: 1/22/2024
What Was Changed: Initial Commit
*/
print '' print '*** creating Incident table ***'
GO
CREATE TABLE [dbo].[Incident] (
    [IncidentID]        [int] IDENTITY(100000, 1)    UNIQUE NOT NULL,
    [Description]       [nvarchar] (1000)                  NOT NULL,
    [IncidentStatus]    [nvarchar] (10)  DEFAULT 'unread'  NOT NULL,
    [Reported]          [nvarchar] (100)                   NOT NULL,
    [ReportedBy]        [nvarchar] (100)                   NOT NULL,
    [Feedback]          [nvarchar] (1000)                      NULL,
    [Severity]          [int]   DEFAULT 1                  NOT NULL,

    CONSTRAINT [fk_Incident_ReportedBy] FOREIGN KEY([ReportedBy])
        REFERENCES [dbo].[Employee] ([EmployeeID]),
        
    CONSTRAINT [pk_Incident] PRIMARY KEY([IncidentID])
)
GO

/*
<summary>
Creator: Wyatt Asher
Created: 1/25/2024
Summary: This is the IncidentParty table.
Last Updated By: Wyatt Asher
Last Updated: 1/25/2024
What Was Changed: Initial Commit
</summary>
*/
print '' print '*** creating IncidentParty table ***'
GO
CREATE TABLE [dbo].[IncidentParty] (
    [IncidentPartyID]        [int] IDENTITY(100000, 1)    UNIQUE NOT NULL,
    [IncidentID]             [int]                              NOT NULL,
    [Description]            [text]                             NOT NULL,
    [IncidentRole]           [nvarchar] (25)                    NOT NULL,

    CONSTRAINT [fk_IncidentParty_IncidentID] FOREIGN KEY([IncidentID])
        REFERENCES [dbo].[Incident] ([IncidentID]),
        
    CONSTRAINT [pk_IncidentParty] PRIMARY KEY([IncidentPartyID])
)
GO

/* 
	<summary>
	Creator:            Jared Harvey
	Created:            01/23/2024
	Summary:            Create MaintenanceRequest Table
	Last Updated By:    Jared Harvey
	Last Updated:       03/03/2024
	What Was Changed:   Added default status set to 'Pending'
						Added default timecreated set to current_timestamp
						Added Urgency field because a gas pipe 
						bursting would take precedence over
						a leaky toilet
	</summary>
*/
print '' print '*** creating MaintenanceRequest table ***'
GO
CREATE TABLE [dbo].[MaintenanceRequest] (
	[RequestID]		[int] 		IDENTITY(100000, 1)		NOT NULL,
	[RoomID]		[int]								NOT NULL,
	[Urgency] 		[NVARCHAR]  (50)					NOT NULL,
	[Status]		[nvarchar]	(50)					NOT NULL DEFAULT 'Pending',
	[Requester]		[nvarchar] 	(50)					NOT NULL,
	[Phone]			[nvarchar]	(50)					NULL,
	[TimeCreated]	[DateTime]							NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[Description]	[nvarchar]	(255)					NOT NULL,
	CONSTRAINT	[fk_MaintenanceRequest_RoomID]	FOREIGN KEY ([RoomID])
		REFERENCES	[dbo].[Room] ([RoomID]) ON DELETE CASCADE,
	CONSTRAINT [pk_RequestID] PRIMARY KEY ([RequestID])
)
GO

/* 
<summary>
Creator:            Tyler Barz
Created:            01/19/2024
Summary:            Creation for EmployeeRole table
Last Updated By:    Jared Harvey
Last Updated:       02/07/2024
What Was Changed:   Changed RoleID from type INT to type NVARCHAR(50)
					and added compound primary key constraint.
</summary>
 */
print '' print '*** creating EmployeeRole table ***'
GO
CREATE TABLE EmployeeRole (
    EmployeeID	NVARCHAR(100)   			NOT NULL,
    RoleID	    NVARCHAR(50)             	NOT NULL,
    CONSTRAINT [fk_EmployeeRole_EmployeeID] FOREIGN KEY ([EmployeeID])
        REFERENCES [Employee]([EmployeeID]),
    CONSTRAINT [fk_EmployeeRole_RoleID] FOREIGN KEY ([RoleID])
        REFERENCES [Role]([RoleID]),
	CONSTRAINT [pk_EmployeeRole] PRIMARY KEY ([EmployeeID], [RoleID])
)
GO

/* 
	<summary>
	Creator:            Jared Harvey
	Created:            01/23/2024
	Summary:            Create HousekeepingTask Table
	Last Updated By:    Jared Harvey
	Last Updated:       01/23/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** creating HousekeepingTask table ***'
GO
CREATE TABLE [dbo].[HousekeepingTask] (
	[TaskID]		[int] 		IDENTITY(100000, 1)		NOT NULL,
	[RoomID]		[int]								NOT NULL,
	[EmployeeID]	[nvarchar]	(100)					NULL,
	[Type]			[nvarchar]	(50)					NOT NULL,
	[Description]	[nvarchar]	(255)					NOT NULL,
	[Date]			[DateTime]							NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[Status]		[nvarchar]	(50)					NOT NULL DEFAULT 'Dirty',
	CONSTRAINT	[fk_HousekeepingTask_RoomID]	FOREIGN KEY ([RoomID])
		REFERENCES	[dbo].[Room] ([RoomID]) ON DELETE CASCADE,
	CONSTRAINT	[fk_HousekeepingTask_EmployeeID]	FOREIGN KEY ([EmployeeID])
		REFERENCES	[dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
	CONSTRAINT	[fk_Room_CleaningStatus]	FOREIGN KEY ([Status])
		REFERENCES	[dbo].[CleaningStatus] ([Status]),
	CONSTRAINT [pk_TaskID] PRIMARY KEY ([TaskID])
)
GO

/*
	<summary> 
	Creator:            Jared Harvey
	Created:            01/23/2024
	Summary:            Create Repair Table
	Last Updated By:    Jared Harvey
	Last Updated:       01/23/2024
	What Was Changed:   Initial Creation
						
	</summary>
*/
print '' print '*** creating Repair table ***'
GO
CREATE TABLE [dbo].[Repair] (
	[RepairID]		[int] 		IDENTITY(100000, 1)		NOT NULL,
	[RequestID]		[int]								NOT NULL,
	[EmployeeID]	[nvarchar](100)						NOT NULL,
	[RepairDate]	[Date],
	[Status]		[nvarchar] 	(50)					NOT NULL,
	CONSTRAINT	[fk_Repair_RequestID]	FOREIGN KEY ([RequestID])
		REFERENCES	[dbo].[MaintenanceRequest] ([RequestID]) ON DELETE CASCADE,
	CONSTRAINT	[fk_Repair_EmployeeID]	FOREIGN KEY ([EmployeeID])
		REFERENCES	[dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
	CONSTRAINT [pk_RepairID] PRIMARY KEY ([RepairID])
	
)
GO


/* 
	<summary>
	Creator:            Ethan McElree
	Created:            01/19/2024
	Summary:            Creation for Recipe table
	Last Updated By:    Ethan McElree
	Last Updated:       02/27/2024
	What Was Changed:   Removed NOT NULL from RecipeImage 
						because I don't think an image should be necessary
	</summary>
*/
print '' print '*** creating Recipe table ***'
GO
CREATE TABLE [dbo].[Recipe] (
	[RecipeID]				[int]  IDENTITY(100000, 1)		NOT NULL,
	[RecipeName]			[nvarchar] (100)				NOT NULL,
	[RecipeDescription]		[nvarchar] (max)  				NOT NULL,
	[Calories]				[int] 							NOT NULL,
	[Allergens]				[nvarchar] (max)				NOT NULL,
	[Vegen]					[bit]  							NOT NULL,
	[PrepTime]				[int]  							NOT NULL,
	[MenuID]				[int]  								NULL,
	[Category]				[nvarchar] (50)  				NOT	NULL,
	[KitchenItemID]			[int]  								NULL,
	[RecipeImage]			[nvarchar] (max)					NULL,
	[RecipeSteps]			[TEXT]							NOT NULL,
	
	CONSTRAINT [fk_MenuID] FOREIGN KEY([MenuID])
		REFERENCES [dbo].[WeekFoodMenu]([MenuID]),
	CONSTRAINT [fk_KitchenItemID] FOREIGN KEY([KitchenItemID])
		REFERENCES [dbo].[KitchenInventoryItem]([KitchenItemID]),
	CONSTRAINT [pk_RecipeID] PRIMARY KEY([RecipeID])
	
)
GO

/* 
	<summary>
	Creator:            Ethan McElree
	Created:            01/19/2024
	Summary:            Creation for MenuMeal table
	Last Updated By:    Andrew Larson
	Last Updated:       02/09/2024
	What Was Changed:   Fixed MealID making it an IDENTIFY field, 
						and updated MenuID to an INT
	</summary>
*/
print '' print '*** creating MenuMeal table ***'
GO
CREATE TABLE [dbo].[MenuMeal] (
	[MealID]				[int]IDENTITY(100000, 1)		NOT NULL,
	[MenuID]				[int]							NOT NULL,
	[RecipeID]				[int]  							NOT NULL,
	[EmployeeID]			[nvarchar](100) 				NOT NULL,
	[Category]				[nvarchar] (50)					NOT NULL,
	CONSTRAINT [fk_MenuMeal_MenuID] FOREIGN KEY([MenuID])
		REFERENCES [dbo].[WeekFoodMenu]([MenuID]),
	CONSTRAINT [fk_RecipeID] FOREIGN KEY([RecipeID])
		REFERENCES [dbo].[Recipe]([RecipeID]) ON DELETE CASCADE,
	CONSTRAINT [fk_EmployeeID] FOREIGN KEY([EmployeeID])
		REFERENCES [dbo].[Employee]([EmployeeID]) ON UPDATE CASCADE,
	CONSTRAINT [pk_MealID] PRIMARY KEY([MealID])
)
GO

/* 
	<summary>
	Creator:            Ethan McElree
	Created:            01/19/2024
	Summary:            Creation for RecipeIngredients table
	Last Updated By:    Ethan McElree
	Last Updated:       01/19/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating RecipeIngredients table ***'
GO
CREATE TABLE [dbo].[RecipeIngredients] (
	[IngredientID]					[nvarchar] (50)  					NOT NULL,
	[RecipeID]						[int]								NOT NULL,
	[Quantity]						[float]   		DEFAULT	1			NOT NULL,
	[UnitOfMeasurement]				[nvarchar] (50) DEFAULT '1'			NOT NULL,
	
	CONSTRAINT [fk_REcipeIngredients_RecipeID] FOREIGN KEY([RecipeID])
		REFERENCES [dbo].[Recipe]([RecipeID]) ON DELETE CASCADE,
	CONSTRAINT [pk_IngredientID] PRIMARY KEY([IngredientID])
	
)
GO

/* 
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Creation for Client table
Last Updated By:    Jared Harvey
Last Updated:       02/29/2024
What Was Changed:   Removed Shelter and Room foreign keys 
*/
print '' print '*** creating Client table ***'
GO
CREATE TABLE [dbo].[Client] (
    [ClientID]          [nvarchar](100)          NOT NULL,
    [Fname]             [nvarchar](25)           NOT NULL,
    [Lname]             [nvarchar](50)           NOT NULL,
    [PasswordHash]      [nvarchar](256)          NOT NULL,
    [Gender]            [bit]                    NOT NULL,
    [Accomodations]     [nvarchar](256)          NOT NULL,
    [AccountStatus]     [bit]                    NOT NULL DEFAULT 1,
    [RegistrationDate]  [Date]                   NOT NULL,
    [ExitDate]          [Date]                   NULL,
    CONSTRAINT [pk_ClientID] PRIMARY KEY([ClientID])
)
GO

/* 
<summary>
Creator:            Jared Harvey
Created:            02/19/2024
Summary:            Creation for Stay table
Last Updated By:    Jared Harvey
Last Updated:       02/19/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating Stay Table ***'
GO
CREATE TABLE [dbo].[Stay] 
(
	[StayID]     	[INT] 		IDENTITY(100000, 1)    	NOT NULL,
	[ClientID]   	[NVARCHAR] (100)             		NOT NULL,
	[RoomID]		[INT]								NOT NULL,
	[InDate]		[DATE]								NOT NULL,
	[OutDate]		[DATE]								NOT NULL,
	[CheckedOut]	[bit]								NOT NULL DEFAULT 0,
    CONSTRAINT [fk_Stay_ClientID] FOREIGN KEY([ClientID])
		REFERENCES [dbo].[Client]([ClientID]),
    CONSTRAINT [fk_Stay_RoomID] FOREIGN KEY([RoomID])
		REFERENCES [dbo].[Room]([RoomID])
)
GO

/* 
<summary>
Creator:            Liam Easton
Created:            01/19/2024
Summary:            Creation for UserSettings table
Last Updated By:    Liam Easton
Last Updated:       01/19/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating UserSettings Table ***'
GO
CREATE TABLE [dbo].[UserSettings] 
(
	[ClientID]     [nvarchar](100)    NOT NULL,
	[UIMode]   	   [bit]              NOT NULL,

	
    CONSTRAINT [fk_UserSettings_ClientID] FOREIGN KEY([ClientID])
		REFERENCES [dbo].[Client]([ClientID])
    
)
GO

/*
<summary>
Creator: Darryl Shirley
created: 01/22/2024
Summary: Service table
Last updated By: Darryl Shirley
Last Updated: 1-26-2024
What was changed/updated: Added foreign key
</summary>
*/
print '' print '*** creating Services table ***'
GO
CREATE TABLE [dbo].[Services](
	[ServicesID]			[int] IDENTITY(100000, 1) NOT NULL,
	[ServiceTypeID] 		[int]					  NOT NULL,
	
	CONSTRAINT [pk_ServicesID] PRIMARY KEY([ServicesID]),
	
	CONSTRAINT [fk_Services_ServiceTypeID] FOREIGN KEY([ServiceTypeID])
		REFERENCES[dbo].[ServiceType]([ServiceTypeID])
	
	
)
GO

/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Creation for GroupAppointment table
Last Updated By:    Anthony Talamantes
Last Updated:       01/24/2024
What Was Changed:   ???
</summary>
*/
print '' print '*** creating GroupAppointment table ***'
GO
CREATE TABLE [dbo].[GroupAppointment] (
	[GroupAppointmentID]	[int] IDENTITY(100000, 1) 	NOT NULL,
	[ClientID]	            [nvarchar](100) 			NOT NULL,
	[LocationID]	        [int]       				NOT NULL,
    [AppointmentDateTime]   [DateTime]       	      	NOT NULL,
    [AppointmentType]       [nvarchar](25)              NOT NULL,

    
	CONSTRAINT [fk_GroupAppointment_ClientID] FOREIGN KEY([ClientID])
		REFERENCES [dbo].[Client]([ClientID]),

    CONSTRAINT [fk_GroupAppointment_LocationID] FOREIGN KEY([LocationID])
		REFERENCES [dbo].[Location]([LocationID]),
	

	CONSTRAINT [pk_GroupAppointmentID] PRIMARY KEY([GroupAppointmentID])
)
GO

/* 
<summary>
Creator:            Liam Easton
Created:            01/19/2024
Summary:            Creation for MembersLine table
Last Updated By:    Liam Easton
Last Updated:       01/19/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating MembersLine Table ***'
GO
CREATE TABLE [dbo].[MembersLine] 
(
	[ClientID]             [nvarchar](100)   NOT NULL,
	[GroupAppointmentID]   [int]   NOT NULL,
	[ClientAttendend]	   [bit]   NOT NULL,
	
	
	CONSTRAINT [fk_MembersLine_ClientID] FOREIGN KEY([ClientID])
		REFERENCES [dbo].[Client]([ClientID]),
	CONSTRAINT [fk_MembersLine_GroupAppointmentID] FOREIGN KEY([GroupAppointmentID])
		REFERENCES [dbo].[GroupAppointment]([GroupAppointmentID])
	
)
GO

/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/24/2024
Summary:            Creation for Appointment table
Last Updated By:    Seth Nerney
Last Updated:       02/13/2024
What Was Changed:   AppointmentStartTime and AppointmentEndTime added
</summary>
*/
print '' print '*** creating Appointment table ***'
GO
CREATE TABLE [dbo].[Appointment] (
	[AppointmentID]	        [int] IDENTITY(100000, 1) 	NOT NULL,
	[ClientID]	            [nvarchar](100)				NOT NULL,
	[LocationID]	        [int]       				NOT NULL,
	[AppointmentStartTime]	[DateTime]					NOT NULL,
	[AppointmentEndTime]	[DateTime]					NOT NULL,
    [AppointmentType]       [nvarchar](25)       		NOT NULL,
    [Status]                [bit]                       NOT NULL,
    [EmployeeID]            [nvarchar](100)             NOT NULL,

    CONSTRAINT [fk_Appointment_ClientID] FOREIGN KEY([ClientID])
		REFERENCES [dbo].[Client]([ClientID]),

    CONSTRAINT [fk_Appointment_LocationID] FOREIGN KEY([LocationID])
		REFERENCES [dbo].[Location]([LocationID]),

    CONSTRAINT [fk_Appointment_EmployeeID] FOREIGN KEY([EmployeeID])
		REFERENCES [dbo].[Employee]([EmployeeID]),

	CONSTRAINT [pk_Appointment] PRIMARY KEY([AppointmentID])
)
GO


/*
	<summary>
	Creator: Seth Nerney
	Created: 1/25/2024
	Summary: This table holds data about the grant application
	Last Updated By: Seth Nerney
	Last Updated: 1/25/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating GrantApplication table ***'
GO
CREATE TABLE [dbo].[GrantApplication] (
	[GrantApplicationID]				[int] IDENTITY(100000, 1)	NOT NULL,
	[GrantApplicationLetterID]			[int],
	CONSTRAINT [pk_GrantApplicationID]	PRIMARY KEY([GrantApplicationID]),
	CONSTRAINT [fk_GrantApplication_GrantApplicationLetterID] FOREIGN KEY([GrantApplicationLetterID])
		REFERENCES [dbo].[GrantApplicationLetter]([GrantApplicationLetterID]),
)
GO


/*
	<summary>
	Creator: Seth Nerney
	Created: 1/25/2024
	Summary: This table holds data about the pledge level
	Last Updated By: Seth Nerney
	Last Updated: 1/25/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating PledgeLevel table ***'
GO
CREATE TABLE [dbo].[PledgeLevel] (
	[PledgeLevelID]			[int] IDENTITY(100000, 1)	NOT NULL,
	[Pledgelevel]			[int]						NOT NULL,
	[DonationAmount]		[float] DEFAULT 0,
	[PledgeDate]			[date]						NOT NULL,
	[PartnerID]				[int]						NOT NULL,

	CONSTRAINT [pk_PledgeLevelID] PRIMARY KEY([PledgeLevelID]),
	CONSTRAINT [fk_PledgeLevel_PartnerID] FOREIGN KEY([PartnerID])
		REFERENCES [dbo].[Partners]([PartnerID]),
)
GO

/*
	<summary>
	Creator: Andrew Larson
	Created: 1/23/2024
	Summary: This table holds data about the donations.
	Last Updated By: Andrew Larson
	Last Updated: 1/23/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating Donations table ***'
GO
CREATE TABLE [dbo].[Donations] (
	[DonationID]		[int] IDENTITY(100000, 1)	NOT NULL,
	[DonationTypeID]	[int]						NOT NULL,
	[DonatorID]			[int]						NULL,
	[DonationName]		[nvarchar](50)				NOT NULL,
	[Amount]			[nvarchar](50)				NOT NULL, /**	Was originally NULL but not sure why	**/
	[DonationsDate]		[date]						NOT NULL,
	[Active]			[bit]						NOT NULL,

	CONSTRAINT [pk_DonationID] PRIMARY KEY ([DonationID]),
	CONSTRAINT [ak_DonationID] UNIQUE ([DonationID]),
	CONSTRAINT [fk_DonationType_DonationTypeID] FOREIGN KEY ([DonationTypeID]) 
		REFERENCES [dbo].[DonationType]([DonationTypeID]),
	CONSTRAINT [fk_Donator_DonatorID] FOREIGN KEY ([DonatorID]) 
		REFERENCES [dbo].[Donator]([DonatorID])	
)


/*
	<summary>
	CREATOR: Matthew Baccam
	CREATED: 1/25/2023
	SUMMARY: ??
	LAST UPDATED BY: ??
	LAST UPDATED: ??
	WHAT WAS CHANGED: ??
	</summary>
*/
PRINT '' PRINT '*** creating DonationLine table ***'
GO
CREATE TABLE [dbo].[DonationLine](
	[DonationLineID]    [INT] IDENTITY(100000,1)      NOT NULL,
    [DonationID]        [INT]                         NOT NULL,
	CONSTRAINT [pk_DonationLine_DonationLineID] PRIMARY KEY ([DonationLineID]),
	CONSTRAINT [fk_DonationLine_DonationID] FOREIGN KEY ([DonationID]) 
        REFERENCES [dbo].[Donations]([DonationID])
)
GO


/*
	<summary>
	Creator: Seth Nerney
	Created: 1/25/2024
	Summary: This table holds data about the partner and their donations
	Last Updated By: Seth Nerney
	Last Updated: 1/25/2024
	What Was Changed: Initial Creation
	</summary>
*/
print '' print '*** creating PartnerLine table ***'
GO
CREATE TABLE [dbo].[PartnerLine] (
	[PartnerLineID]			[int] IDENTITY(100000, 1) 	NOT NULL,
	[PartnerID]				[int]						NOT NULL,
	[DonationsID]			[int]						NOT NULL,
	[Description]			[nvarchar](250),
	CONSTRAINT [pk_PartnerLineID] PRIMARY KEY([PartnerLineID]),
	CONSTRAINT [fk_PartnerLine_PartnerID] FOREIGN KEY([PartnerID])
		REFERENCES [dbo].[Partners]([PartnerID])
)
GO


/*
	<summary>
	CREATOR: Matthew Baccam
	CREATED: 1/25/2023
	SUMMARY: ??
	LAST UPDATED BY: Tyler Barz
	LAST UPDATED: 01/26/2024
	WHAT WAS CHANGED: Fixed formatting
	</summary>
*/
PRINT '' PRINT '*** creating ContactDescription table ***'
GO
CREATE TABLE [dbo].[ContactDescription](
	[ContactID]         [INT]            IDENTITY(100000,1)  NOT NULL,
    [Description]       [NVARCHAR](250)                      NOT NULL,
    [PartnerID]         [INT]                                NOT NULL,
	CONSTRAINT [pk_ContactDescription_ContactID] PRIMARY KEY ([ContactID]), 
	CONSTRAINT [fk_ContactDescription_PartnerID] FOREIGN KEY ([PartnerID]) 
        REFERENCES [dbo].[Partners]([PartnerID])
)
GO


/*
	<summary>
	Creator: Darryl Shirley
	created: 01/22/2024
	Summary: Volunteer Event History table
	Last updated By:Darryl Shirley
	Last Updated:1-26-2024
	What was changed/updated: added comment
	</summary>
*/
print '' print '*** creating Volunteer Event History table ***'
GO
CREATE TABLE [dbo].[VolunteerEventHistory](
	[VolunteerID]	[nvarchar](100) 			  NOT NULL,
	[EventID] 		[int]					      NOT NULL,
	
	CONSTRAINT [fk_VolunteerEventHistory_VolunteerID] FOREIGN KEY([VolunteerID])
		REFERENCES[dbo].[Volunteer]([VolunteerID]) ON DELETE CASCADE,
	CONSTRAINT [fk_VolunteerEventHistory_EventID] FOREIGN KEY([EventID])
		REFERENCES[dbo].[Event]([EventID]),
	CONSTRAINT [pk_VolunteerEventHistory] PRIMARY KEY ([VolunteerID], [EventID])
	
)
GO


/*
	<summary>
	Creator: Donald Winchester
	Created: 1/24/2024
	Summary: This creates the VolunteerEventSignup table.
	Last Updated By: Donald Winchester
	Last Updated: 1/26/2024
	What Was Changed: An error regarding duplicate constraint key 
	names was fixed.
	Writer's Note: Doesn't work because the Volunteer and Event tables aren't in here.
	</summary>
*/
print " " print '*** creating VolunteerEventSignup table ***'
GO
CREATE TABLE [dbo].[VolunteerEventSignup] (
    [VolunteerID]   [nvarchar](100)    NOT NULL,
    [EventID]       [INT]              NOT NULL,
    [Description]   [DATETIME]         NOT NULL,
	
	CONSTRAINT [fk_VolunteerEventSignup_VolunteerID] FOREIGN KEY([VolunteerID])
		REFERENCES [dbo].[Volunteer]([VolunteerID]) ON DELETE CASCADE,
	CONSTRAINT [fk_VolunteerEventSignup_EventID] FOREIGN KEY([EventID])
		REFERENCES [dbo].[Event]([EventID]),	
	CONSTRAINT [pk_VolunteerEventSignup] PRIMARY KEY([VolunteerID], [EventID])
	
)
GO

/*
	<summary>
	Creator: Darryl Shirley
	created: 01/22/2024
	Summary: Volunteer Questionnaire table
	Last updated By: Darryl Shirley
	Last Updated: 4-19-2024
	What was changed/updated: added skillsList, vehicles, priorExperience, studentCheck, schoolname, and groupwork fields
	</summary>
*/
print '' print '*** creating Volunteer Questionnaire table ***'
GO
CREATE TABLE [dbo].[Volunteer_Questionnaire](
	[QuestionnaireID]	[int] IDENTITY(100000, 1) 				  NOT NULL,
	[VolunteerID] 		[nvarchar](100)			  				  NOT NULL,
	[SkillsList]		[nvarchar](100)					  				  ,
	[Vehicles]			[nvarchar](100)									  ,
	[PriorExperience]	[BIT]							NOT NULL DEFAULT 0,
	[StudentCheck]		[BIT]							NOT NULL DEFAULT 0,
	[SchoolName]		[nvarchar](50)									  ,
	[GroupWork]			[BIT]											  ,
	[DateApplied] 		[Datetime]		NOT NULL DEFAULT CURRENT_TIMESTAMP,
	
	CONSTRAINT [pk_QuestionnaireID] PRIMARY KEY([QuestionnaireID]),
	CONSTRAINT [fk_Volunteer_Questionnaire_VolunteerID] FOREIGN KEY([VolunteerID])
		REFERENCES[dbo].[Volunteer]([VolunteerID]) ON DELETE CASCADE
	
)
GO

/* Volunteer Skills Table */
print '' print '*** creating volunteer skills table ***'
GO
CREATE TABLE [dbo].[VolunteerSkills] (
    [VolunteerID]    [nvarchar](100)      	NOT NULL,
	[SkillID]        [int]                	NOT NULL

	CONSTRAINT   [pk_VolunteerID_SkillID] PRIMARY KEY ([VolunteerID], [SkillID]),
    CONSTRAINT [fk_VolunteerSkills_VolunteerID] FOREIGN KEY([VolunteerID])
	    REFERENCES [dbo].[Volunteer]([VolunteerID]) ON DELETE CASCADE,
    CONSTRAINT [fk_VolunteerSkills_SkillID] FOREIGN KEY([SkillID])
	    REFERENCES [dbo].[Skills]([SkillID])
	
)
GO

/*
	<summary>
	Creator: Darryl Shirley
	created: 01/22/2024
	Summary: Volunteer Application table
	Last updated By: Darryl Shirley
	Last Updated: 1-26-2024
	What was changed/updated: added comment
	Last updated By: Mitchell Stirmel
	Last Updated: 04/03/2024
	What was changed/updated: Updated table to include some application information.
	</summary>
*/

/*
    [ApplicantID]      [int] IDENTITY(100000, 1)           NOT NULL,
    [GivenName]          [nvarchar](50)                         NOT NULL,
    [FamilyName]      [nvarchar](50)                         NOT NULL,
    [PhoneNumber]      [nvarchar](12)                         NOT NULL,
    [Email]              [nvarchar](250)                     NOT NULL,
    What we get from the applicant table
    need: 
    Reason for applying
    Hours desired
    Any concerns
*/
print '' print '*** creating Volunteer Application table ***'
GO
CREATE TABLE [dbo].[VolunteerApplication](
	[ApplicationID]		[int] IDENTITY(100000, 1) NOT NULL,
	[ApplicantID]	 	[int]					  NOT NULL,
	[Status]	 		[nvarchar] (50)			  NOT NULL DEFAULT 'Awaiting Review',
	[DateApplied] 		[Datetime]				  NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[ReasonForStatus]	[nvarchar](255)			  NOT NULL DEFAULT 'No status reason available yet',
	[ApplicationReason]	[text]		   			  NOT NULL,
	[HoursDesired]		[int]					  NOT NULL,
	[VolunteerConcerns]	[text]					  NOT NUll

	CONSTRAINT [pk_ApplicationID] PRIMARY KEY([ApplicationID]),
	CONSTRAINT [fk_Volunteer_Application_ApplicantID] FOREIGN KEY([ApplicantID])
		REFERENCES[dbo].[Applicant]([ApplicantID])
)
GO

/*
	<summary>
	Creator: Gishe Tuke
	Created: 1/25/2024
	Summary: This table holds data about the VendorLocation.
	Last Updated By: Gishe Tuke
	Last Updated: 1/26/2024
	What Was Changed: Initial Creation
	Last Updated By:    Mitchell Stirmel
	Last Updated:       03/04/2024
	What Was Changed:   ON DELETE CASCADE addition for vendor deletion
	</summary>
*/
PRINT '' print '*** creating VendorLocation table ***'
GO
CREATE TABLE [dbo].[VendorLocation] (
    [StreetAddress] [nvarchar](50) PRIMARY KEY NOT NULL,
    [VendorID] [int] NOT NULL,
    [City] [nvarchar](50) NOT NULL,
    [State] [char](2) NOT NULL,
    [Zipcode] [nvarchar](10) NOT NULL,
    [Notes] [nvarchar](255),

    CONSTRAINT [fk_VendorLocation_Vendor] FOREIGN KEY ([VendorID]) 
		REFERENCES [Vendor]([VendorID]) ON DELETE CASCADE
)
GO

/* 
	<summary>	
	CREATOR: Sagan Dewald
	CREATED: 1/24/2023
	SUMMARY: initial creation
	LAST UPDATED BY: Tyler Barz
	LAST UPDATED: 01/26/2024
	WHAT WAS CHANGED: Removed location start/end, changed to foreign key of location
	LAST UPDATED BY: Ibrahim ALbashaor
	LAST UPDATED: 04/25/2024
	WHAT WAS CHANGED: Added Cascade Delete
	</summary>
*/
print '' print '*** creating TransportItem table ***'
GO
CREATE TABLE [dbo].[TransportItem] (
    [TransportItemID]       [int] IDENTITY(100000, 1)           NOT NULL,
    [ClientID]              [nvarchar](100)                      NULL,
    [LocationID]            [int]		                         NULL,
    [DayPosted]             [Date]                              NOT NULL,
    [DayToPickUp]           [Date]                              NOT NULL,
    [DayDroppedOff]         [Date]                              NULL,
    [AssignedDriver]        [nvarchar](100)                     NULL,
    [Fulfilled]             [bit]                               NULL,

    CONSTRAINT [pk_TransportItemID] PRIMARY KEY([TransportItemID]),
    CONSTRAINT [fk_TransportItemID_ClientID] FOREIGN KEY([ClientID]) 
		REFERENCES [dbo].[Client]([ClientID]) ON DELETE CASCADE,
    CONSTRAINT [fk_TransportItemID_LocationID] FOREIGN KEY([LocationID]) 
		REFERENCES [dbo].[Location]([LocationID]) ON DELETE CASCADE,
    CONSTRAINT [fk_TransportItemID_AssignedDriver] FOREIGN KEY([AssignedDriver]) 
		REFERENCES [dbo].[Employee]([EmployeeID])ON DELETE CASCADE
)
GO

/* 
	<summary>
	CREATOR: Sagan Dewald
	CREATED: 1/24/2023
	Last Updated By:    Mitchell Stirmel
	Last Updated:       03/04/2024
	What Was Changed:   ON DELETE CASCADE addition for vendor deletion
	Last Updated By:    Liam Easton
	Last Updated:       04/04/2024
	What Was Changed:   Adding ItemID foreign key reference to 
						reference the item you want to transport
	</summary>
*/
print '' print '*** creating transportline table ***'
GO
CREATE TABLE [dbo].[TransportLine] (
    [TransportLineID]       [int] IDENTITY(100000, 1)           NOT NULL,
	[ItemID]				[int]								NOT NULL,
    [LineItemAmount]        [money]                             NOT NULL,
    [TransportItemID]       [int]                   			NOT NULL,
    [VendorID]              [int] 					            NOT NULL,

    CONSTRAINT [pk_TransportLineID] PRIMARY KEY([TransportLineID]),
	CONSTRAINT [fk_TransportLine_ItemID] FOREIGN KEY([ItemID]) 
		REFERENCES [dbo].[Item]([ItemID])ON DELETE CASCADE,
    CONSTRAINT [fk_TransportLine_TransportItemID] FOREIGN KEY([TransportItemID]) 
		REFERENCES [dbo].[TransportItem]([TransportItemID])ON DELETE CASCADE,
    CONSTRAINT [fk_TransportLine_VendorID] FOREIGN KEY([VendorID]) 
		REFERENCES [dbo].[Vendor]([VendorID]) ON DELETE CASCADE
)
GO

/*
	<summary>
	Creator: Gishe Tuke
	Created: 1/25/2024
	Summary: This table holds data about the VendorLine.
	Last Updated By: Gishe Tuke
	Last Updated: 1/26/2024
	What Was Changed: Initial Creation  
	Last Updated By:    Mitchell Stirmel
	Last Updated:       03/04/2024
	What Was Changed:   ON DELETE CASCADE addition for vendor deletion
	</summary>
*/

PRINT '' print '*** creating VendorLine table ***'
GO
CREATE TABLE [dbo].[VendorLine] (
    [VendorID] [int] NOT NULL,
    [EventID] [int] NOT NULL,

    CONSTRAINT [pk_VendorLine] PRIMARY KEY ([VendorID], [EventID]),
    CONSTRAINT [fk_VendorLine_Vendor] FOREIGN KEY ([VendorID]) 
		REFERENCES [Vendor]([VendorID]) ON DELETE CASCADE,
    CONSTRAINT [fk_VendorLine_Events] FOREIGN KEY ([EventID]) 
		REFERENCES [Event]([EventID])
)
GO

/*
	CREATOR: Matthew Baccam
	CREATED: 1/25/2023
	SUMMARY: initial creation
	LAST UPDATED BY: Matthew Baccam
	LAST UPDATED: 1/25/2023
	WHAT WAS CHANGED: initial creation
*/
PRINT '' PRINT '*** creating EventType table ***'
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeID]       [NVARCHAR](255)    NOT NULL,
    [EventID]           [INT]              NOT NULL,
    [Information]       [TEXT]             NOT NULL,
    CONSTRAINT [pk_EventType_EventTypeID] PRIMARY KEY ([EventTypeID]), 
    CONSTRAINT [fk_EventType_EventID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Event]([EventID])
)
GO

/*
	<summary>
	Creator: Gishe Tuke
	Created: 1/25/2024
	Summary: This table holds data about the EventLocation.
	Last Updated By: Gishe Tuke
	Last Updated: 1/26/2024
	What Was Changed: Initial Creation
	</summary>
*/
PRINT '' print '*** creating EventLocation table ***'
GO
CREATE TABLE [dbo].[EventLocation] (
    [Address] [nvarchar](255) PRIMARY KEY NOT NULL,
    [Zipcode] [int] NOT NULL,
    [EventID] [int] IDENTITY(100000, 1) UNIQUE,
    CONSTRAINT [fk_EventLocation_Event] FOREIGN KEY ([EventID]) REFERENCES [Event]([EventID])
)
GO

/*
	<summary>
	Creator: Gishe Tuke
	Created: 1/25/2024
	Summary: This table holds data about the RequestEvent.
	Last Updated By: Tyler Barz
	Last Updated: 1/27/2024
	What Was Changed: Changed client datatype, and requesteventid constraints
	</summary>
*/
PRINT '' print '*** creating RequestEvent table ***'
GO
CREATE TABLE [dbo].[RequestEvent] (
    [RequestEventID] [int] IDENTITY(100000, 1) PRIMARY KEY NOT NULL,
    [ClientID] [nvarchar](100) NOT NULL,
    [EventTypeID] [nvarchar](255) NOT NULL,
    [Information] [TEXT] NOT NULL,

    CONSTRAINT [fk_RequestEvent_Client] FOREIGN KEY ([ClientID]) 
		REFERENCES [Client]([ClientID]),
    CONSTRAINT [fk_RequestEvent_EventType] FOREIGN KEY ([EventTypeID]) 
		REFERENCES [EventType]([EventTypeID])
)
GO

/*
	<summary>
	Creator: Marwa ibrahim
	created: 01/25/2024
	Summary: Volunteer Event Line table
	Last updated By: Darryl Shirley
	Last Updated: 1-26-2024
	What was changed/updated: added comment
	</summary>
*/
print '' print '*** creating VolunteerEventLine table ***'
GO
CREATE TABLE [dbo].[VolunteerEventLine] (
    [VolunteerID]       [nvarchar] (100)   NOT NULL,
	[EventID]           [int]              NOT NULL,

	CONSTRAINT [pk_VolunteerID_EventID] PRIMARY KEY ([VolunteerID], [EventID]),
    CONSTRAINT [fk_VolunteerEventLine_VolunteerID] FOREIGN KEY([VolunteerID])
	    REFERENCES [dbo].[Volunteer]([VolunteerID]) ON DELETE CASCADE,
    CONSTRAINT [fk_VolunteerEventLine_EventID] FOREIGN KEY([EventID])
	    REFERENCES [dbo].[Event]([EventID])
)
GO

/*
	<summary>
	Creator: Wyatt Asher
	Created: 1/22/2024
	Summary: This is the table that links employees to events they helped
	at.
	Last Updated By: Wyatt Asher
	Last Updated: 1/22/2024
	What Was Changed: Initial Commit
	</summary>
*/
print '' print '*** creating EmployeeEventLine table ***'
GO
CREATE TABLE [dbo].[EmployeeEventLine] (
    [EmployeeID]    [nvarchar] (100)    NOT NULL,
    [EventID]       [int]               NOT NULL,

    CONSTRAINT [fk_EmployeeEventLine_EmployeeID] FOREIGN KEY([EmployeeID])
        REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [fk_EmployeeEventLine_EventID] FOREIGN KEY([EventID])
        REFERENCES [dbo].[Event] ([EventID]),
    CONSTRAINT [pk_EmployeeEventLine] PRIMARY KEY([EmployeeID], [EventID])
)
GO

/*
<Summary>
Creator: Miyada Abas
created: 01/26/2024
Summary: Event Participants table
Last updated By: Darryl Shirley
Last Updated: 1-26-2024
What was changed/updated: Convereted to T-SQL
</Summary>
*/
print '' print '*** creating Event Participants table ***'
GO
CREATE TABLE [dbo].[EventParticipants] (
	[ParticipantID]    [INT] IDENTITY(100000, 1) NOT NULL,
	[EventID] 	  	   [INT] 				     NOT NULL,
	[ParticipantName]  [nvarchar](255)           NOT NULL,
	[Email] 		   [nvarchar](255) 		  	 NOT NULL,
	[RegistrationDate] [DATE] 				     NOT NULL,
	
	CONSTRAINT [pk_ParticipantID] PRIMARY KEY([ParticipantID]),
	
	CONSTRAINT [fk_EventParticipants_EventID] FOREIGN KEY([EventID])
		REFERENCES[dbo].[Event]([EventID])
)
GO
 

 /*
<Summary>
Creator: Miyada Abas
created: 01/26/2024
Summary: EmployeeSource table
Last updated By: Darryl Shirley
Last Updated: 1-26-2024
What was changed/updated: Convereted to T-SQL
</Summary>
*/
print '' print '*** creating Source table ***'
GO
CREATE TABLE [dbo].[Source] (
	[SourceID]    [INT] IDENTITY(100000, 1) NOT NULL,
	[SourceName]  [nvarchar](255) 		 	NOT NULL,
	[Description] [nvarchar](255) 		 	NOT NULL,
	
	CONSTRAINT [pk_SourceID] PRIMARY KEY([SourceID])
)
GO 

/*
<Summary>
Creator: Miyada Abas
created: 01/22/2024
Summary: EmployeeType table
Last updated By: Darryl Shirley
Last Updated: 1-26-2024
What was changed/updated: Convereted to T-SQL
</Summary>
*/
print '' print '*** creating EmployeeType table ***'
GO
CREATE TABLE [dbo].[Type] (
	[TypeID]            [INT] IDENTITY(100000, 1) NOT NULL,
	[TypeName]          [nvarchar](255) 			 NOT NULL,
	[Description]      [nvarchar](255) 			 NOT NULL,
	
	CONSTRAINT [pk_TypeID] PRIMARY KEY([TypeID])
)
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create SpecialPurchaseRequest table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating SpecialPurchaseRequest table ***'
GO
CREATE TABLE [dbo].[SpecialPurchaseRequest] (
    [SpecialPurchaseNo]   				[int] IDENTITY(100000,1)    	 NOT NULL,
    [SpecialPurchaseDate]   			[DATE] 				    	 NOT NULL,
    [SpecialPurchaseTotalItems]    		[int] 					   	 NOT NULL,
	[SpecialPurchaseNotes]    			[nvarchar] (255) 		   	 NOT NULL,
	CONSTRAINT [pk_SpecialPurchaseRequest] PRIMARY KEY ([SpecialPurchaseNo])
)
GO


/* 
<summary>
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create SpecialRequestLine table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   ??? 
</summary>
 */
print '' print '*** creating SpecialRequestLine table ***'
GO
CREATE TABLE [dbo].[SpecialRequestLine] (
    [SprSequence]   		[int] IDENTITY(100000,1)     NOT NULL,
    [SpecialPurchaseNo]  	[int] 				    	 NOT NULL,
    [SprQtyOrdered]    		[int] 					   	 NOT NULL,
	[SprQtyShipped]    		[int] 			 		   	 NOT NULL,
	[ItemID]				[int]						 NOT NULL,
	CONSTRAINT [pk_SpecialRequestLine] PRIMARY KEY ([SprSequence]),
    
	CONSTRAINT [fk_SpecialRequestLine] FOREIGN KEY ([ItemID])
	REFERENCES [dbo].[Item] ([ItemID])
    
)
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            01/23/2024
Summary:            Create OrderLineItem table
Last Updated By:    Andres Garcia
Last Updated:       01/23/2024
What Was Changed:   ???  
</summary>
*/
print '' print '*** creating OrderLineItem table ***'
GO
CREATE TABLE [dbo].[OrderLineItem] (
    [Sequence]   		[int] IDENTITY(100000,1)     NOT NULL,
    [OrderNo]   		[int] 				    	 NOT NULL,
    [QtyOrdered]    	[int] 		              	 NOT NULL,
	[QtyShipped]    	[int] 			             NOT NULL,
    [ItemID]    		[int] 					   	 NOT NULL,
	CONSTRAINT [pk_OrderLineItem] PRIMARY KEY ([Sequence]),
    
	CONSTRAINT [fk_OrderLineItem_OrderNo] FOREIGN KEY ([OrderNo])
	    REFERENCES [dbo].[Order] ([OrderNo]),
	CONSTRAINT [fk_OrderLineItem_ItemID] FOREIGN KEY ([ItemID])
	    REFERENCES [dbo].[Item] ([ItemID])
    
	)
GO


/* 
	<summary>
	Creator:            Andres Garcia
	Created:            01/23/2024
	Summary:            Create ExceptionLine table
	Last Updated By:    Andres Garcia
	Last Updated:       01/23/2024
	What Was Changed:   ???  
	</summary>
*/
print '' print '*** creating ExceptionLine table ***'
GO
CREATE TABLE [dbo].[ExceptionLine] (
    [ExceptionOrderNo]   	[int] IDENTITY(100000,1)     NOT NULL,
    [Sequence]   			[int] 				    	 NOT NULL,
    [QtyDifference]    		[int] 					   	 NOT NULL,
	CONSTRAINT [pk_ExceptionLine] PRIMARY KEY ([ExceptionOrderNo]),
	CONSTRAINT [fk_ExceptionLine_Sequence] FOREIGN KEY ([Sequence])
		REFERENCES [dbo].[OrderLineItem] ([Sequence])
)
GO

/* 
    <summary>
    Creator:            Mitchell Stirmel
    Created:            01/31/2024
    Summary:            Creation of the PartsInventory table
    Last Updated By:    Darryl Shirley
    Last Updated:       01/31/2024
    What Was Changed:   Added Stocktype 
    </summary>
*/
print '' print '*** creating PartsInventory table ***'
GO 
CREATE TABLE [dbo].[PartsInventory] (
	[PartID]			[nvarchar](255)					NOT NULL,
	[Category]			[nvarchar](255)					NOT NULL,
	[Qty]				[int]							NOT NULL DEFAULT 0,
	[StockType]			[nvarchar](25)					NOT NULL,
	CONSTRAINT [pk_PartsInventory] PRIMARY KEY ([PartID])
)
GO

/* 
<summary>
Creator:            Andrew larson
Created:            01/29/2024
Summary:            Create HoursOfOperation table
Last Updated By:    Andrew Larson
Last Updated:       01/29/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating HoursOfOperation table ***'
GO
CREATE TABLE [dbo].[HoursOfOperation] (
		[HoursOfOperationID]		[int] IDENTITY(100000,1)	NOT NULL,
		[HoursOfOperationString]	[nvarchar](50)				NOT NULL,
		[LocationID]				[int]						NOT NULL,
	CONSTRAINT [pk_HoursOfOperationID] PRIMARY KEY ([HoursOfOperationID]),
	CONSTRAINT [fk_Location_LocationID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Location]([LocationID])
)
GO

/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            02/02/2024
	Summary:            Creation of the PartsInventoryUpdatedDate table
	Last Updated By:    Mitchell Stirmel
	Last Updated:       01/31/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** creating PartsInventoryUpdatedDate table ***'
GO 
CREATE TABLE [dbo].[PartsInventoryUpdatedDate] (
	[UpdatedDate]		[DATETIME]						NOT	NULL,
	[ID]				[INT]							NOT NULL DEFAULT 1,
	CONSTRAINT [pk_PartsInventoryUpdatedDate] PRIMARY KEY ([ID])
)
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of the ResourceCategory table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating ResourceCategory table ***'
GO 
CREATE TABLE [dbo].[ResourceCategory] (
	[Category]		[nvarchar](50)			NOT NULL,
	CONSTRAINT [pk_ResourceCategory] PRIMARY KEY ([Category])
)
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of the ResourcesNeeded table
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating ResourcesNeeded table ***'
GO 
CREATE TABLE [dbo].[ResourcesNeeded] (
	[ResourceID]	[nvarchar](50)			NOT NULL, /*Product Name*/
	[Category]		[nvarchar](50)			NOT NULL,
	[Active]		[bit]					NOT NULL DEFAULT 1,
	CONSTRAINT [pk_ResourcesNeeded] PRIMARY KEY ([ResourceID]),
	CONSTRAINT [fk_ResourcesNeeded_Category] FOREIGN KEY([Category])
		REFERENCES [dbo].[ResourceCategory]([Category])
)
GO

/* 
	<summary>
	Creator:            Ibrahim Albashair
	Created:            02/09/2024
	Summary:            Create Visits Table
	Last Updated By:    Matthew Baccam
	Last Updated:       03/07/2024
	What Was Changed:   Added status field
	</summary>
*/
print '' print '*** creating Visit table ***'
GO
CREATE TABLE [dbo].[Visit] (
	[VisitID]		[int]	IDENTITY(100000, 1)				NOT NULL,
	[FirstName]     [NVARCHAR](100) 						NOT NULL,
	[LastName]      [NVARCHAR](100) 					    NOT NULL,
	[CheckIn]       [DateTime]		 						NOT NULL,
	[CheckOut]      [DateTime]								NOT NULL,
	[VisitReason]   [NVARCHAR](100) 						NOT NULL,	
	[Status]   		[BIT] DEFAULT 0							NOT NULL,
	CONSTRAINT [pk_VisitID] PRIMARY KEY ([VisitID])
)
GO

/*
<summary>
Creator:            Ethan McElree
Created:            02/13/2024
Summary:            Create Schedule table
Last Updated By:    Ethan McElree
Last Updated:       02/13/2024
What Was Changed:   Initial  
</summary>
*/
print '' print '*** creating Schedule table ***'
GO
CREATE TABLE [dbo].[Schedule] (
	[ScheduleID]			[int] IDENTITY(100000,1)         NOT NULL,    
    [ScheduleMonth]    		[nvarchar](50) 				     NOT NULL,
    [ScheduleWeek]    		[int] 				     		 NOT NULL,
	[ScheduleYear]			[int]							 NOT NULL,
	[ScheduleStartDate]     [Date] 							NULL,
	[ScheduleEndDate]     	[Date] 							NULL,
	CONSTRAINT [pk_ScheduleID] PRIMARY KEY ([ScheduleID]),
	CONSTRAINT [ck_Schedule_Week_Range] CHECK (ScheduleWeek >= 1 AND ScheduleWeek <= 4)
)
GO

/*
Creator: Kirsten Stage
Created: 3/29/2024
Summary: This is the table for event meals.
Last Updated By: Kirsten Stage
Last Updated: 3/29/2024
What Was Changed: Initial Creation
*/
print '' print '*** creating EventMeal table ***'
GO
CREATE TABLE [dbo].[EventMeal] (
    [EventMealID]       [int]                IDENTITY(100000, 1) UNIQUE NOT NULL,
    [EventID]           [int]                NOT NULL,
    [Food]              [nvarchar](100)      NOT NULL,
    [Beverages]         [nvarchar](100)      NOT NULL,

    CONSTRAINT [fk_EventMeal_EventID] FOREIGN KEY([EventID])
        REFERENCES [dbo].[Event] ([EventID]),
    CONSTRAINT [pk_EventMealID] PRIMARY KEY([EventMealID])
)
GO

	/*
	<summary>
	Creator:            Sagan DeWald
	Created:            03/19/2024
	Summary:            Create ClientPriority table
	Last Updated By:    Sagan DeWald
	Last Updated:       03/19/2024
	What Was Changed:   Initial creation.  
	</summary>
*/
print '' print '*** creating ClientPriority table ***'
GO
CREATE TABLE [dbo].[ClientPriority] (
	[ClientPriorityID]			[int] IDENTITY(100000,1)        NOT NULL, 
	[Client]					[nvarchar](100)					NOT NULL UNIQUE,
	[BasePriority]				[int] 							NOT NULL,
	[Deductions]				[int] 							NOT NULL DEFAULT 0,
	[NotableConvictions]		[nvarchar](max)					NOT NULL DEFAULT '',
	[OtherHousingSituation]		[nvarchar](max)					NOT NULL DEFAULT '',
	CONSTRAINT [pk_ClientPriorityID] PRIMARY KEY([ClientPriorityID]),
	CONSTRAINT [fk_ClientPriority_Client] FOREIGN KEY([Client]) REFERENCES [dbo].[Client]([ClientID]) ON DELETE CASCADE
)
GO

/*
	<summary> 
	Creator:            Jared Harvey
	Created:            02/06/2024
	Summary:            Create Shift Table
	Last Updated By:    Jared Harvey
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation 
	</summary>
*/
print '' print '*** creating Shift table ***'
GO
CREATE TABLE [dbo].[Shift] (
	[ShiftID]		[int] 		IDENTITY(100000, 1)		NOT NULL,
	[EmployeeID]	[nvarchar]	(100)					NOT NULL,
	[StartTime]		[DateTime]							NOT NULL,
	[EndTime]		[DateTime]							NOT NULL,
	[ScheduleID]	[int]								NULL,

	CONSTRAINT	[fk_Shift_EmployeeID]	FOREIGN KEY ([EmployeeID])
		REFERENCES	[dbo].[Employee] ([EmployeeID]) ON DELETE CASCADE,
	CONSTRAINT	[fk_Shift_ScheduleID]	FOREIGN KEY ([ScheduleID])
		REFERENCES	[dbo].[Schedule] ([ScheduleID]) ON DELETE CASCADE,
	CONSTRAINT [pk_ShiftID] PRIMARY KEY ([ShiftID])
)
GO

/*
Creator: Kirsten Stage
Created: 4/11/2024
Summary: This is the table for fundraising events.
Last Updated By: Kirsten Stage
Last Updated: 4/11/2024
What Was Changed: Initial Creation
*/
print '' print '*** creating FundraisingEvent table ***'
GO
CREATE TABLE [dbo].[FundraisingEvent] (
	[FundraisingID]		[int]				IDENTITY(100000, 1) UNIQUE NOT NULL,
	[EventName]			[nvarchar](100)		NOT NULL,
	[FundraisingGoal]	[money]				NOT NULL,
	[EventAddress]		[nvarchar](100)		NOT NULL,
	[EventDate]			[datetime]			NOT NULL,
	[StartTime]			[datetime]			NOT NULL,
	[EndTime]			[datetime]			NOT NULL,
	[EventDescription]	[text]				NOT NULL,
	CONSTRAINT [pk_FundraisingEvent] PRIMARY KEY([FundraisingID])
)
GO

/*
Creator: Donald Winchester
Created: 4/15/2024
Summary: This is the table for membership applications.
Last Updated By: Donald Winchester
Last Updated: 4/15/2024
What Was Changed: Initial Creation
*/
print '' print '*** creating MembershipApplications table ***'
GO
CREATE TABLE [dbo].[MembershipApplications] (
	[MembershipApplicationsID]		[int]				IDENTITY(100000, 1) UNIQUE NOT NULL,
	[FirstName]			[nvarchar](50)		NOT NULL,
	[LastName]	[nvarchar](50)			NOT NULL,
	[DateOfBirth]		[nvarchar](50)		NOT NULL,
	[Sex]			[nvarchar](10)			NOT NULL,
	[SSN]			[nvarchar](20)			NOT NULL,
	[PhoneNumber]			[nvarchar](20)			NOT NULL,
	[EmailAddress]	[nvarchar](100)				NOT NULL,
	[Status]		[nvarchar](50)				NOT NULL,
	CONSTRAINT [pk_MembershipApplications] PRIMARY KEY([MembershipApplicationsID])
)
GO

/*
	Creator: Sagan DeWald
	Created: 2/23/2024
	Summary: Stores which incidents should be hidden from which users, so that incidents can be "deleted" as described in UC 1.6.5
	Last Updated By: Sagan DeWald
	Last Updated: 2/23/2024
	What Was Changed: Initial Commit
*/
print '' print '*** creating HiddenIncident table ***'
GO
CREATE TABLE [dbo].[HiddenIncident] (
    [HiddenIncidentID]		[int] IDENTITY(100000, 1)   UNIQUE NOT NULL,
	[TargetUser]			[nvarchar] (100)			NOT NULL,
	[IncidentID]			[int]						NOT NULL,
	CONSTRAINT [fk_HiddenIncident_IncidentID] FOREIGN KEY([IncidentID]) REFERENCES [dbo].[Incident]([IncidentID]),
    CONSTRAINT [pk_HiddenIncidentID] PRIMARY KEY([HiddenIncidentID])
)
GO