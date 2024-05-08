print '' print '*** Stored Procedures ***'
print '' print '*** using database masterhomelessdb ***'
GO
USE [masterhomelessdb]
GO

/*****************************************************************************
							SHELTER STORED PROCEDURES
*****************************************************************************/

/* 
<summary>
Creator:            Andrew larson
Created:            01/29/2024
Summary:            Create sp_select_homeless_shelter_by_zipcode
					the user can see what hours a shelter offers 
					that is in their zip code.
Last Updated By:    Andrew Larson
Last Updated:       01/29/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating sp_select_homeless_shelter_by_zipcode ***'
GO
CREATE PROCEDURE [dbo].[sp_select_homeless_shelter_by_zipcode]
(
	@ZipCode			[int]
)
AS
	BEGIN
		SELECT [Location].[LocationName], [Location].[Address], [Location].[City], 
		[Location].[State], [Location].[ZipCode], [HoursOfOperation].[HoursOfOperationString]
		FROM [Location]
		JOIN [HoursOfOperation] ON [Location].[LocationID] = [HoursOfOperation].[LocationID]
		WHERE [Location].[ZipCode] = @ZipCode
	END
GO

/*
    <summary>
    Creator:            Kirsten Stage
    Created:            02/01/2024
    Summary:            This is the stored procedure for obtaining the 
						list of current Shelter IDs.
    Last Updated By:    Kirsten Stage
    Last Updated:       02/01/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_shelterIDs ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_shelterIDs]
AS
	BEGIN
		SELECT 	[ShelterID]
		FROM 	[Shelter]
	END
GO

/*****************************************************************************
							ROOM STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator:            Jared Harvey
    Created:            04/05/2024
    Summary:            Gets Room by RoomID
    Last Updated By:    Jared Harvey
    Last Updated:       
    What Was Changed:   
    </summary>
*/
print '' print '*** creating sp_get_room_by_roomid ***'
GO
CREATE PROCEDURE [dbo].[sp_get_room_by_roomid]
(
	@RoomID		[int]
)
AS
	BEGIN
		SELECT RoomID, ShelterID, RoomNumber, Status
		FROM Room
		WHERE RoomID = @RoomID
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            04/12/2024
    Summary:            Gets Room by RoomNumber
    Last Updated By:    Jared Harvey
    Last Updated:       
    What Was Changed:   
    </summary>
*/
print '' print '*** creating sp_get_room_by_room_number ***'
GO
CREATE PROCEDURE [dbo].[sp_get_room_by_room_number]
(
	@ShelterID 		[nvarchar] (50),
	@RoomNumber		[int]
)
AS
	BEGIN
		SELECT RoomID, ShelterID, RoomNumber, Status
		FROM Room
		WHERE RoomNumber = @RoomNumber
		AND ShelterID = @ShelterID
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            03/01/2024
    Summary:            Updates room status
    Last Updated By:    Jared Harvey
    Last Updated:       03/01/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_update_room_status ***'
GO
CREATE PROCEDURE [dbo].[sp_update_room_status]
(
	@RoomID		[int],
	@Status		[nvarchar] (50)
)
AS
	BEGIN
		UPDATE [dbo].[Room]
		SET [Status] = @Status
		WHERE [RoomID] = @RoomID
	END
GO

/*
    <summary>
    Creator:            Kirsten Stage
    Created:            02/01/2024
    Summary:            This is the stored procedure for creating rooms.
    Last Updated By:    Kirsten Stage
    Last Updated:       02/01/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_create_room ***'
GO
CREATE PROCEDURE [dbo].[sp_create_room]
(
	@ShelterID		[nvarchar](50),
	@RoomNumber		[int],
	@Status			[nvarchar](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[Room]
			([ShelterID], [RoomNumber], [Status])
		VALUES
			(@ShelterID, @RoomNumber, @Status)
	END
GO

print '' print '*** sp_update_Room******'
GO
CREATE PROC sp_update_Room (
@RoomID int , @ShelterID nvarchar(50), @RoomNumber int , @Status nvarchar(50)
)
AS BEGIN
   UPDATE Room
SET ShelterID = @ShelterID, RoomNumber = @RoomNumber, Status = @Status 
WHERE RoomID = @RoomID; 
END
GO

print '' print '*** sp_delete_room_by_id******'
GO
CREATE PROC [sp_delete_room_by_id]
(
@RoomId  [int]
)
AS
BEGIN 


/*
    -- Delete records from UserSettings with FK references to client
    DELETE FROM [dbo].[UserSettings]
    WHERE [dbo].[UserSettings].clientID IN (SELECT clientID FROM [dbo].[client] WHERE RoomID = @RoomId);

    -- Delete clients associated with the room
    DELETE FROM [dbo].[client]
    WHERE [dbo].[client].RoomID = @RoomId;
*/
    -- Delete the room
    DELETE FROM [dbo].[room]
    WHERE roomID = @RoomId;
END
GO

print '' print '*** sp_select_rooms***'
GO
CREATE PROC sp_select_rooms
AS BEGIN
    SELECT [RoomId], [ShelterID], [RoomNumber],[Status]
    FROM [Room]
END
GO

/*
	<summary> 
	Creator:            Jared Harvey
	Created:            02/06/2024
	Summary:            Create sp_get_shelter_rooms stored procedure
	Last Updated By:    Jared Harvey
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation 
	</summary>
*/
print '' print '*** creating sp_get_shelter_rooms ***'
GO
CREATE PROCEDURE [dbo].[sp_get_shelter_rooms] (
	@ShelterID		[nvarchar] (50)
)
AS
	BEGIN
		SELECT	[RoomID], [ShelterID], [RoomNumber], [Status]
		FROM [Room]
		WHERE [Room].[ShelterID] = @ShelterID
	END
GO

/*
    <summary>
    Creator:            Kirsten Stage
    Created:            02/01/2024
    Summary:            This is the stored procedure for obtaining the 
						list of current Room Statuses.
    Last Updated By:    Kirsten Stage
    Last Updated:       02/01/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_room_statuses ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_room_statuses]
AS
	BEGIN
		SELECT 	[Status]
		FROM 	[RoomStatus]
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            03/01/2024
    Summary:            Returns a list of available rooms for shelter
    Last Updated By:    Jared Harvey
    Last Updated:       03/01/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_shelter_available_rooms ***'
GO
CREATE PROCEDURE [dbo].[sp_get_shelter_available_rooms] (
	@ShelterID		[NVARCHAR] (50)
)
AS
	BEGIN
		SELECT	[RoomID], [ShelterID], [RoomNumber], [Status]
		FROM [Room]
		WHERE [Room].[ShelterID] = @ShelterID
		AND [Room].[Status] = 'Available'
	END
GO

/*****************************************************************************
							HOUSEKEEPING STORED PROCEDURES
*****************************************************************************/

/*
	<summary> 
	Creator:            Jared Harvey
	Created:            02/12/2024
	Summary:            Create sp_get_housekeeping_tasks stored procedure
	Last Updated By:    Jared Harvey
	Last Updated:       02/12/2024
	What Was Changed:   Initial Creation 
	</summary>
*/
print '' print '*** creating sp_get_housekeeping_tasks ***'
GO
CREATE PROCEDURE [dbo].[sp_get_housekeeping_tasks] (
	@ShelterID		[nvarchar] (50)
)
AS
	BEGIN
		SELECT 	[TaskID], [HousekeepingTask].[RoomID], [HousekeepingTask].[EmployeeID], [Type], [Description], [Date], [HousekeepingTask].[Status], [Room].[RoomNumber], 
				[Employee].[FName], [Employee].[LName]
		FROM [HousekeepingTask]
		INNER JOIN [Room] ON [Room].[RoomID] = [HousekeepingTask].[RoomID]
		LEFT JOIN [Employee] ON [Employee].[EmployeeID] = [HousekeepingTask].[EmployeeID]
		WHERE [Room].[ShelterID] = @ShelterID
	END
GO

/*
	<summary> 
	Creator:			Jared Harvey
	Created:            04/27/2024
	Summary:            Updates the assigned housekeeper to task
	Last Updated By:    
	Last Updated:       
	What Was Changed:   
	</summary>
*/
print '' print '*** creating sp_update_assigned_housekeeper ***'
GO
CREATE PROCEDURE [dbo].[sp_update_assigned_housekeeper] (
	@TaskID			[int],
	@EmployeeID		[nvarchar] (255)
)
AS
	BEGIN
		UPDATE [dbo].[HousekeepingTask]
		SET [EmployeeID] = @EmployeeID,
			[Status] = "In Cleaning"
		WHERE [TaskID] = @TaskID;
	END
GO

/*
	<summary> 
	Creator:            Ethan McElree
	Created:            03/4/2024
	Summary:            Stored procedure for updating a housekeeping task status
	Last Updated By:    Ethan McElree
	Last Updated:       03/4/2024
	What Was Changed:   Initial Creation 
	</summary>
*/
print '' print '*** creating sp_update_housekeeping_task_status ***'
GO
CREATE PROCEDURE [dbo].[sp_update_housekeeping_task_status] (
	@TaskID		[int],
	@Status 	[nvarchar] (50)
)
AS
	BEGIN
		IF @Status = "Dirty"
			UPDATE [dbo].[HousekeepingTask]
			SET [Status] = @Status,
				[EmployeeID] = null
			WHERE [TaskID] = @TaskID;
		ELSE IF @Status = "Clean"
			BEGIN TRY
				BEGIN TRANSACTION
					UPDATE [dbo].[HousekeepingTask]
					SET [Status] = @Status
					WHERE [TaskID] = @TaskID;
			
					UPDATE [dbo].[Room]
					SET Status = 'Available'
					WHERE [Room].[RoomID] = (SELECT RoomID FROM HousekeepingTask WHERE TaskID = @TaskID)
					AND Status = 'Needs Housekeeping'
				COMMIT TRANSACTION
				SELECT @@ROWCOUNT
			END TRY
			BEGIN CATCH
				ROLLBACK TRANSACTION
				SELECT @@ROWCOUNT
			END CATCH
		ELSE
			UPDATE [dbo].[HousekeepingTask]
			SET [Status] = @Status
			WHERE [TaskID] = @TaskID;
	END
GO

/* 
	<summary>
	Creator:            Jared Harvey
	Created:            03/03/2024
	Summary:            This stored procedure creates a new maintenance request
	Last Updated By:    Jared Harvey
	Last Updated:       03/03/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** sp_insert_housekeeping_task ***'
GO
CREATE PROCEDURE sp_insert_housekeeping_task (
	@RoomID			[INT],
	@Type			[NVARCHAR] (50),
	@Description	[NVARCHAR] (255)
)
AS 
	BEGIN 
		INSERT INTO [dbo].[HousekeepingTask]
			([RoomID], [Type], [Description])
		VALUES
			(@RoomID, @Type, @Description)
	END
GO

/* 
	<summary>
	Creator:            Darryl Shirley
	Created:            01/31/2024
	Summary:            Create sp_add_volunteer_event Stored Procedure
	Last Updated By:    Darryl Shirley
	Last Updated:       02/07/2024
	What Was Changed:   Changed to an Update  
	Last Updated By:    Liam Easton
	Last Updated:       04/04/2024
	What Was Changed:   Changed name of sp from Add_Volunteer_Event to sp_add_volunteer_event to look more uniform
	</summary>
*/

print '' print '*** creating sp_add_volunteer_event ***'
GO
CREATE PROCEDURE [dbo].[sp_add_volunteer_event]
(
	@EventID				[int],
	@NewVolunteersNeeded	[int],
	@OldVolunteersNeeded	[int]
	
)
AS
	BEGIN
		UPDATE [Event]
			SET	[VolunteersNeeded] = @NewVolunteersNeeded
		WHERE	@EventID = [EventID]
			AND	@OldVolunteersNeeded = [VolunteersNeeded] 
		RETURN @@ROWCOUNT
			
	END
GO

/* 
	<summary>
	Creator:            Darryl Shirley
	Created:            01/31/2024
	Summary:            Create Select_All_Volunteer_Events Procedure
	Last Updated By:    Darryl Shirley
	Last Updated:       01/23/2024
	What Was Changed:   Initial creation  
	</summary>
*/
print '' print '**** creating sp_Select_All_Volunteer_Events ****'
GO
CREATE PROCEDURE [dbo].[sp_Select_All_Volunteer_Events]
AS
	BEGIN
		SELECT
			[EventID],
			[EventName],
			[Description],
			[VolunteersNeeded]
		FROM
			[Event]
		WHERE 
			[Active] = 1
	END
GO



/* 
<summary>
Creator:            Mitchell Stirmel
Created:            02/07/2024
Summary:            Create sp_view_maintenance_inventory
Last Updated By:    Darryl Shirley
Last Updated:       02/07/2024
What Was Changed:   Updated 
</summary>
*/
/*Create sp_view_maintenance_inventory*/
print '' print '**** creating sp_view_maintenance_inventory****'
GO
CREATE PROCEDURE [dbo].[sp_view_maintenance_inventory]
AS
	BEGIN
		SELECT
			[PartID],
			[Category],
			[Qty],
			[StockType]
		FROM
			[PartsInventory]
END
GO


/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            02/07/2024
	Summary:            Creation of stored procedure to view the updated time of the maintenance inventory.
	Last Updated By:    Mitchell Stirmel
	Last Updated:       02/07/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** sp_view_maintenance_inventory_update_time***'
GO
CREATE PROC sp_view_maintenance_inventory_update_time
AS BEGIN
    SELECT [UpdatedDate]
    FROM [PartsInventoryUpdatedDate]
    WHERE [ID] = 1
END
GO

/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            02/08/2024
	Summary:            This stored procedure will get the required fields from maintenance requests
	Last Updated By:    Jared Harvey
	Last Updated:       04/24/2024
	What Was Changed:   Added Urgency Field
	</summary>
*/
print '' print '*** sp_get_shelter_maintenance_requests ***'
GO
CREATE PROC sp_get_shelter_maintenance_requests
AS BEGIN 
    SELECT [Status], [RequestID], [RoomID], [Urgency], [TimeCreated], [Phone], [Requester], [Description]
    FROM [MaintenanceRequest]
END
GO

/*****************************************************************************
							SUPPLIER STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator:            Ethan McElree
    Created:            02/27/2024
    Summary:            Stored procedure for retrieving a supplier so its information can be updated.
    Last Updated By:    Ethan McElree
    Last Updated:       02/27/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** sp_retrieve_supplier ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_supplier]
(
	@SupplierName  [nvarchar](100)
)  
AS
BEGIN
    SELECT [VendorName], [VendorContactName], [VendorAddress], [VendorContactPhone], [VendorEmail]
    FROM [Vendor]
    WHERE [VendorName] = @SupplierName;
END
GO

/*
    <summary>
    Creator:            Ethan McElree
    Created:            02/27/2024
    Summary:            Stored procedure for updating a supplier after its information was edited.
    Last Updated By:    Ethan McElree
    Last Updated:       02/27/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** sp_update_supplier ***'
GO
CREATE PROCEDURE [dbo].[sp_update_supplier]
    @SupplierName [nvarchar](100),
    @NewSupplierAddress [nvarchar](100),
    @NewSupplierEmail [nvarchar](255),
    @NewSupplierContactPhone [nvarchar](11),
    @NewSupplierContactName [nvarchar](50)
AS
BEGIN
    UPDATE [dbo].[Vendor]
    SET [VendorAddress] = @NewSupplierAddress,
        [VendorEmail] = @NewSupplierEmail,
        [VendorContactPhone] = @NewSupplierContactPhone,
        [VendorContactName] = @NewSupplierContactName
    WHERE [VendorName] = @SupplierName;
END

/* 
Creator:            Ethan McElree
Created:            02/28/2024
Summary:            Stored procedure for selecting all of the supplier names.
Last Updated By:    Ethan McElree
Last Updated:       02/28/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_all_supplier_names ***'
GO
CREATE PROCEDURE sp_select_all_supplier_names
AS
BEGIN
    SELECT [VendorName] 
	FROM [dbo].[Vendor];
END
GO

/*****************************************************************************
							EVENT STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator: Abdalgader Ibrahim
    Created: 02/27/2024
    Summary: Stored procedure to Event Participants
    Last Updated By: Abdalgader Ibrahim
	</summary>
*/
print '' print '*** creating sp_get_event_participants ***'
GO
CREATE PROCEDURE [dbo].[sp_get_event_participants]
(
    @EventID  [INT]
)
AS
BEGIN
	SELECT [ParticipantName]
	FROM [EventParticipants]
	WHERE [EventID] = @EventID
 END
GO


/*
    <summary>
    Creator: Matthew Baccam
    Created: 02/07/2024
    Summary: Creating sp_update_employee_details
    Last Updated By: Matthew Baccam
    Created: 02/07/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_update_employee_details ***'
GO
CREATE PROCEDURE [dbo].[sp_update_employee_details]
(
	@UserID    [nvarchar] (100)
	, @OldFname         [nvarchar] (25) 
	, @OldLname         [nvarchar] (25) 
	, @OldPhone         [nvarchar] (15) 
	, @OldGender        BIT
	, @OldAccountStatus [bit]           
	, @OldZipCode       [int]           
	, @OldAddress       [nvarchar] (50) 
	, @OldStartDate     [date]    
	, @OldEndDate     	[date] = null                      
	, @NewFname         [nvarchar] (25) 
	, @NewLname         [nvarchar] (25) 
	, @NewPhone         [nvarchar] (15) 
	, @NewGender        BIT
	, @NewAccountStatus [bit]           
	, @NewZipCode       [int]           
	, @NewAddress       [nvarchar] (50) 
	, @NewStartDate     [date]      
	, @NewEndDate		[date] = null  
)
AS	
BEGIN
		UPDATE [Employee]
		SET 									
			[Fname] =	@NewFname         								
			, [Lname] =	@NewLname         								
			, [Phone] =	@NewPhone     
			, [Gender] = @NewGender      											
			, [AccountStatus] = @NewAccountStatus 											
			, [ZipCode] = @NewZipCode       									
			, [Address] = @NewAddress       					
			, [StartDate] = @NewStartDate  					
			, [EndDate] = @NewEndDate  
		WHERE
			[EmployeeID] = @UserID	
			AND [Fname] = @OldFname
			AND [Lname] = @OldLname	
			AND [Phone] = @OldPhone	
			AND [Gender] = @OldGender	
			AND [AccountStatus] = @OldAccountStatus		
			AND [ZipCode] = @OldZipCode	
			AND [Address] = @OldAddress	
			AND [StartDate] = @OldStartDate	
			OR [EndDate] = @OldEndDate										

	END
GO


/*
    <summary>
    Creator: Matthew Baccam
    Created: 02/07/2024
    Summary: Creating sp_update_client_details
    Last Updated By: Matthew Baccam
    Created: 02/07/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_update_client_details ***'
GO
CREATE PROCEDURE [dbo].[sp_update_client_details]
(
	  @UserID 				[nvarchar] (100)
	, @OldFname	           [nvarchar](25) 
	, @OldLname             [nvarchar](50) 
	, @OldGender        	BIT 
	, @OldAccomodations     [nvarchar](255)
	, @OldAccountStatus     [bit]          
	, @OldRegistrationDate  [Date]         
	, @OldExitDate          [Date] = null 
	, @NewFname	           	[nvarchar](25)    
	, @NewLname             [nvarchar](50)  
	, @NewGender        	BIT
	, @NewAccomodations     [nvarchar](255)
	, @NewAccountStatus     [bit]          
	, @NewRegistrationDate  [Date]         
	, @NewExitDate          [Date] = null              
)
AS	
BEGIN
		UPDATE [Client]
		SET 
			[Fname] = @NewFname
			, [Lname] = @NewLname
			, [Accomodations] = @NewAccomodations
			, [AccountStatus] = @NewAccountStatus
			, [Gender] = @NewGender
			, [RegistrationDate] = @NewRegistrationDate
			, [ExitDate] = @NewExitDate
		WHERE
			[ClientID] = @UserID
			AND [Fname] = @OldFname
			AND [Lname] = @OldLname
			AND [Gender] = @OldGender
			AND [Accomodations] = @OldAccomodations
			AND [AccountStatus] = @OldAccountStatus
			AND [RegistrationDate] = @OldRegistrationDate
			OR [ExitDate] = @OldExitDate

	END
GO


/*
    <summary>
    Creator:            Matthew Baccam
    Created:            03/21/2023
    Summary:            Create Client
    Last Updated By:    Matthew Baccam
    Last Updated:       03/21/2023
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_insert_client ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_client] (
	@UserID          [nvarchar](100)
	, @Fname             [nvarchar](25) 
	, @Lname             [nvarchar](50) 
	, @PasswordHash      [nvarchar](256)
	, @Gender            [bit]          
	, @Accomodations     [nvarchar](256)
	, @AccountStatus     [bit]          
	, @RegistrationDate  [Date]         
)
AS
	BEGIN
		INSERT INTO [dbo].[Client]
			(
				[ClientID]        
				, [Fname]           
				, [Lname]           
				, [PasswordHash]    
				, [Gender]          
				, [Accomodations]   
				, [AccountStatus]   
				, [RegistrationDate] 
			)
		VALUES
			(
				@UserID          
				, @Fname           
				, @Lname           
				, @PasswordHash    
				, @Gender          
				, @Accomodations   
				, @AccountStatus   
				, @RegistrationDate
			)
	END
GO

/*
    <summary>
    Creator:            Matthew Baccam
    Created:            03/21/2023
    Summary:            Create Employee
    Last Updated By:    Matthew Baccam
    Last Updated:       03/21/2023
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_insert_employee ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_employee] (
	@UserID    	 [nvarchar] (100)
	, @Fname         [nvarchar] (25) 
	, @Lname         [nvarchar] (25) 
	, @Phone         [nvarchar] (15) 
	, @Gender        [bit]           
	, @PasswordHash  [nvarchar] (256)
	, @AccountStatus [bit]           
	, @ZipCode       [int]           
	, @Address       [nvarchar] (50) 
	, @StartDate     [date]      	
)
AS
	BEGIN
		INSERT INTO [dbo].[Employee]
			(
				[EmployeeID]   
				, [Fname]        
				, [Lname]        
				, [Phone]        
				, [Gender]       
				, [PasswordHash] 
				, [AccountStatus]
				, [ZipCode]      
				, [Address]      
				, [StartDate]     
			)
		VALUES
			(
				@UserID    	
				, @Fname        
				, @Lname        
				, @Phone        
				, @Gender       
				, @PasswordHash 
				, @AccountStatus
				, @ZipCode      
				, @Address      
				, @StartDate     
			)
	END
GO

/*
    <summary>
    Creator:            Matthew Baccam
    Created:            03/21/2023
    Summary:            Create Volunteer
    Last Updated By:    Matthew Baccam
    Last Updated:       03/21/2023
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_insert_volunteer ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_volunteer] (
	@UserID	        	NVARCHAR(100)
	, @FirstName	                NVARCHAR(25) 
	, @LastName	                NVARCHAR(25) 
	, @Phone	                NVARCHAR(15) 
	, @Gender	            	BIT          
	, @PasswordHash	        NVARCHAR(255)
	, @AccountStatus	        BIT          
	, @RoleID	            	NVARCHAR(50)
	, @RegistrationDate	    DATETIME     
	, @Address 	            NVARCHAR(50) 
	, @ZipCode	            	INT          
)
AS
	BEGIN
		INSERT INTO [dbo].[Volunteer]
			(
				[VolunteerID]	   
				, [FirstName]	           
				, [LastName]	           
				, [Phone]	           
				, [Gender]	       
				, [PasswordHash]	   
				, [AccountStatus]	   
				, [RoleID]	       
				, [RegistrationDate]
				, [Address] 	       
				, [ZipCode]	       
			)
		VALUES
			(
				@UserID	   
				, @FirstName	       
				, @LastName	       
				, @Phone	       
				, @Gender	       
				, @PasswordHash	   
				, @AccountStatus	
				, @RoleID	       
				, @RegistrationDate
				, @Address 	       
				, @ZipCode	       
			)
	END
GO

/*
    <summary>
    Creator: Matthew Baccam
    Created: 02/07/2024
    Summary: Creating sp_check_if_email_is_valid
    Last Updated By: Matthew Baccam
    Created: 02/07/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_check_if_email_is_valid ***'
GO
CREATE PROCEDURE [dbo].[sp_check_if_email_is_valid]
(
	@UserID    [nvarchar] (100)
)
AS	
BEGIN
    SELECT
        (SELECT COUNT([EmployeeID]) FROM [Employee] WHERE [EmployeeID] = @UserID) AS EmployeeCount,
        (SELECT COUNT([VolunteerID]) FROM [Volunteer] WHERE [VolunteerID] = @UserID) AS VolunteerCount,
        (SELECT COUNT([ClientID]) FROM [Client] WHERE [ClientID] = @UserID) AS ClientCount
END
GO

print '' print '*** inserting New Event ***'
GO  
CREATE PROCEDURE sp_Create_Event   
    @EventName nvarchar(100),   
    @Description nvarchar(100),
    @VolunteersNeeded	int 
AS   
	INSERT INTO  Event (EventName, Description, VolunteersNeeded) 
	VALUES (@EventName, @Description, @VolunteersNeeded);
GO				

/* 
<summary>
Creator:            Darryl Shirley
Created:            01/31/2024
Summary:            Create Add_Volunteer_Event Stored Procedure
Last Updated By:    Darryl Shirley
Last Updated:       02/07/2024
What Was Changed:   Changed to an Update  
</summary>
*/
/*Create Add_Volunteer_Event field*/

print '' print '**** Add_Volunteer_Event ****'
GO
CREATE PROCEDURE [dbo].[Add_Volunteer_Event]
(
	@EventID				[int],
	@NewVolunteersNeeded	[int],
	@OldVolunteersNeeded	[int]
	
)
AS
	BEGIN
		UPDATE [Event]
			SET	[VolunteersNeeded] = @NewVolunteersNeeded
		WHERE	@EventID = [EventID]
			AND	@OldVolunteersNeeded = [VolunteersNeeded] 
		RETURN @@ROWCOUNT
			
	END
GO



/* 
<summary>
Creator:            Ethan McElree
Created:            03/25/2024
Summary:            Creating sp_get_all_locations
Last Updated By:    Ethan McElree
Last Updated:       03/25/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating sp_get_all_locations ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_locations]
AS 
	BEGIN
		SELECT [LocationID], [LocationName], [Address], [City], [State], [ZipCode]
		FROM [dbo].[Location]
	END
GO

/*****************************************************************************
						MAINTENTANCE STORED PROCEDURES
*****************************************************************************/
/*
    <summary>
    Creator: Liam Easton
    Created: 1/29/2024
    Summary: initial creation of the UpdateEmployeePasswordHash stored procedure
    Last Updated By: Liam Easton
    Last Updated: 1/29/2024
    What Was Changed: initial creation of the UpdateEmployeePasswordHash stored procedure
	Last Updated By: Liam Easton
    Last Updated: 04/04/2024
    What Was Changed: Changed procedure name from UpdateEmployeePasswordHash to sp_update_employee_passwordHash
    </summary>
*/
print '' print '*** creating procedure sp_update_employee_passwordHash ***'
GO
CREATE PROCEDURE [dbo].[sp_update_employee_passwordHash]
(
    @EmployeeID			[nvarchar](100),
	@NewPasswordHash	[nvarchar](100),
	@OldPasswordHash	[nvarchar](100)
)
AS	
	BEGIN
		UPDATE	[Employee]
		SET	    [PasswordHash] = @NewPasswordHash
		WHERE 	@EmployeeID = [EmployeeID]
		  AND   @OldPasswordHash = [PasswordHash]
		RETURN  @@ROWCOUNT
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 02/01/2024
    Summary: initial creation of the SelectEmployeePasswordHashByEmployeeID stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/01/2024
    What Was Changed: initial creation of the SelectEmployeePasswordHashByEmployeeID stored procedure
	Last Updated By: Liam Easton
    Last Updated: 04/04/2024
    What Was Changed: Changed name of procedure to sp_select_employee_passwordHash_by_employeeID
    </summary>
*/
print '' print '*** creating sp_select_employee_passwordHash_by_employeeID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_employee_passwordHash_by_employeeID]
(
	@EmployeeID			[nvarchar](100)
)
AS	
	BEGIN
		SELECT	[PasswordHash]
		FROM	[Employee]
		WHERE 	@EmployeeID = [EmployeeID]
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 02/01/2024
    Summary: initial creation of the SelectAllEmployeeEmails stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/01/2024
    What Was Changed: initial creation of the SelectAllEmployeeEmails stored procedure
    </summary>
*/
print '' print '*** creating SelectAllEmployeeEmails ***'
GO
CREATE PROCEDURE [dbo].[SelectAllEmployeeEmails]
AS	
 	BEGIN
		SELECT [EmployeeID]
		FROM	[Employee]
	END
GO


/*
    <summary> 
    Creator:            Matthew Baccam
    Created:            03/03/2024
    Summary:            Created sp_add_employee_role
    Last Updated By:    Matthew Baccam
    Last Updated:       03/03/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_add_employee_role ***' 
GO
CREATE PROCEDURE sp_add_employee_role(
	@EmployeeID	NVARCHAR(100) 
	, @RoleID	    NVARCHAR(50)  
) 
AS 
BEGIN
	INSERT INTO [EmployeeRole]
	([EmployeeID], [RoleID])
	VALUES 
	(@EmployeeID, @RoleID)	
	-- Updates so the count is correct after adding
    UPDATE [Role]
    SET [PositionsAvailable] = [PositionsAvailable] - 1
    WHERE [RoleID] = @RoleID
END 
GO

/*
    <summary> 
    Creator:            Matthew Baccam
    Created:            03/03/2024
    Summary:            Created sp_delete_employee_role
    Last Updated By:    Matthew Baccam
    Last Updated:       03/03/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_delete_employee_role ***' 
GO
CREATE PROCEDURE sp_delete_employee_role(
	@EmployeeID	NVARCHAR(100) 
	, @RoleID	    NVARCHAR(50)  
) 
AS 
BEGIN
	DELETE FROM [EmployeeRole]
	WHERE [EmployeeID] = @EmployeeID
	AND [RoleID] = @RoleID 
	-- Updates so the count is correct after removal
    UPDATE [Role]
    SET [PositionsAvailable] = [PositionsAvailable] + 1
    WHERE [RoleID] = @RoleID
END 
GO


/*
    <summary>
    Creator: Liam Easton
    Created: 02/08/2024
    Summary: initial creation of the sp_add_employee_shift stored procedure
    Last Updated By: Jared Harvey
    Last Updated: 02/01/2024
    What Was Changed: Renamed starthour and endhour to starttime and endtime
    </summary>
*/
print '' 
print '*** creating sp_add_employee_shift ***'
GO

CREATE PROCEDURE [dbo].[sp_add_employee_shift]
(
    @EmployeeID     [nvarchar](100),
    @StartTime      [DateTime],
    @EndTime        [DateTime]
)
AS  
	BEGIN
		INSERT INTO [Shift] 
			([EmployeeID], [StartTime], [EndTime])
		VALUES 
			(@EmployeeID, @StartTime, @EndTime)
	END
GO

/*
    <summary>
    Creator: Tyler Barz
    Created: 02/14/2024
    Summary: Creating sp_select_employee_details, for details post login
    Last Updated By: Tyler Barz
    Last Updated: 02/14/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_select_employee_details ***'
GO
CREATE PROCEDURE [dbo].[sp_select_employee_details]
(
	@EmployeeID	[nvarchar](100)
)
AS	
BEGIN
		SELECT	
		    [EmployeeID],
    		[Fname],
			[Lname],
			[Phone],
			[Gender],
			[AccountStatus], 
			[ZipCode],
			[Address],
			[StartDate],
			[EndDate]
		FROM  [Employee]
		WHERE [EmployeeID] = @EmployeeID
	END
GO

/*
    <summary>
    Creator: Tyler Barz
    Created: 02/14/2024
    Summary: Creating sp_select_volunteer_details, for details post login
    Last Updated By: Tyler Barz
    Last Updated: 02/14/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_select_volunteer_details ***'
GO
CREATE PROCEDURE [dbo].[sp_select_volunteer_details]
(
	@VolunteerID [nvarchar](100)
)
AS	
BEGIN
		SELECT	
		    [VolunteerID],
    		[FirstName],
			[LastName],
			[Phone],
			[Gender],
			[AccountStatus], 
			[RoleID],
			[ZipCode],
			[Address],
			[RegistrationDate]
		FROM  [Volunteer]
		WHERE [VolunteerID] = @VolunteerID
	END
GO

/*
	<summary>
	Creator:            Jared Harvey
	Created:            03/03/2024
	Summary:            This stored procedure creates a new maintenance request
	Last Updated By:    Jared Harvey
	Last Updated:       03/03/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** sp_insert_maintenance_request ***'
GO
CREATE PROCEDURE sp_insert_maintenance_request (
	@RoomID			[INT],
	@Urgency		[NVARCHAR] (50),
	@Requester		[NVARCHAR] (50),
	@Description	[NVARCHAR] (255),
	@Phone			[NVARCHAR]	(50)
)
AS 
	BEGIN 
		INSERT INTO [dbo].[MaintenanceRequest]
			([RoomID], [Urgency], [Requester], [Phone], [Description])
		VALUES
			(@RoomID, @Urgency, @Requester, @Phone, @Description)
	END
GO

/*****************************************************************************
						INVENTORY STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator: Anthony Talamantes
    Created: 02/12/2024
    Summary: Stored procedure to select all categories from PartsInventory
    Last Updated By: Anthony Talamantes
    Last Updated: 02/12/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_category'
GO
CREATE PROCEDURE [dbo].[sp_select_all_category]
AS
	BEGIN
		SELECT [Category]
		FROM [PartsInventory]
	END
GO


/* 
<summary>
Creator:            Matthew Baccam
Created:            04/24/2024
Summary:            Creation for sp_insert_ingredient stored procedure
Last Updated By:    Matthew Baccam
Last Updated:       04/24/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_insert_ingredient'
GO
CREATE PROCEDURE [dbo].[sp_insert_ingredient](
	@IngredientID			[NVARCHAR] (max)		
	, @RecipeID				[INT] 			
) AS
	BEGIN 
		INSERT INTO [RecipeIngredients] (
			[IngredientID]		
			, [RecipeID]		
		)
		VALUES (			
			@IngredientID			
			, @RecipeID	
		)
	END
GO

/* 
<summary>
Creator:            Matthew Baccam
Created:            01/30/2024
Summary:            Creation for sp_insert_recipe stored procedure
Last Updated By:    Matthew Baccam
Last Updated:       01/30/2024
What Was Changed:   Initial Creation  
Last Updated By:    Matthew Baccam
Last Updated:       04/24/2024
What Was Changed:   Added a return value so we can insert ingredients  
Last Updated By:    Matthew Baccam
Last Updated:       04/25/2024
What Was Changed:   Changed [RecipeImage] => NVARCHAR MAX, [RecipeDescription] => NVARCHAR MAX,
					 [Allergens] => NVARCHAR MAX, 
</summary>
*/
PRINT '' 
PRINT 'Creating sp_insert_recipe'
GO
CREATE PROCEDURE [dbo].[sp_insert_recipe](
	  @RecipeName				[nvarchar] (100)		
	, @RecipeDescription		[nvarchar] (max)  		
	, @Calories					[int] 					
	, @Allergens				[nvarchar] (max)		
	, @Vegen					[bit]  					
	, @PrepTime					[int]  								
	, @RecipeImage				[nvarchar] (max)			
	, @RecipeSteps				[TEXT]	
	, @Category					[nvarchar] (50)
	, @RecipeIDCreated 			[INT] OUTPUT			
) AS
	BEGIN 
		BEGIN TRY
			INSERT INTO [Recipe] (
				[RecipeName]		
				, [RecipeDescription]	
				, [Calories]			
				, [Allergens]			
				, [Vegen]				
				, [PrepTime]				
				, [RecipeImage]		
				, [RecipeSteps]		
				, [Category]		
			)
			VALUES (			
				@RecipeName			
				, @RecipeDescription	
				, @Calories			
				, @Allergens			
				, @Vegen				
				, @PrepTime			
				, @RecipeImage		
				, @RecipeSteps
				, @Category		
			)

			SET @RecipeIDCreated = SCOPE_IDENTITY() --Capturing the last IDENTITY record inserted after the insert statement works
		END TRY
		BEGIN CATCH
			SET @RecipeIDCreated = -1 --Setting the return value to -1 since the insert failed
		END CATCH
	END
GO

/* 
<summary>
Creator:            Andrew larson
Created:            02/12/2024
Summary:            Create sp_select_recipe_details_and_instructions_by_RecipeID to retrieve
					the image file name and the list of steps for preparing the recipe.
Last Updated By:    Andrew Larson
Last Updated:       02/12/2024
What Was Changed:   Initial Creation
</summary>
*/
print '' print '*** creating sp_select_recipe_details_and_instructions_by_RecipeID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_recipe_details_and_instructions_by_RecipeID]
(
	@RecipeID		[int]
)
AS
	BEGIN
		SELECT [RecipeImage], [RecipeSteps], [RecipeName]
		FROM [Recipe]																
		WHERE @RecipeID = [Recipe].[RecipeID]
	END
GO

/*
    <summary>
    Creator: Anthony Talamantes
    Created: 02/07/2024
    Summary: initial creation of the sp_select_all_vendors stored procedure
    Last Updated By: Anthony Talamantes
    Last Updated: 02/07/2024
    What Was Changed: Initial Creation 
    </summary>
*/
print '' print'*** creating sp_select_all_vendors ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_vendors]
AS
	BEGIN
		SELECT 
			[VendorID], [VendorName], [VendorAddress], [VendorEmail], [VendorContactPhone], [VendorContactName]
		FROM [Vendor]
	END
GO

/*
    <summary>
    Creator: Anthony Talamantes
    Created: 02/12/2024
    Summary: Stored procedure to add a part to PartsInventory
    Last Updated By: Anthony Talamantes
    Last Updated: 02/12/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print'*** creating sp_insert_part_to_inventory ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_part_to_inventory]
(
	@PartID					[nvarchar](255),
	@Category				[nvarchar](255),
	@Qty					[int],
	@StockType				[nvarchar](25)
)
AS
	BEGIN
		INSERT INTO [dbo].[PartsInventory]
			([PartID], [Category], [Qty], [StockType])
		VALUES
			(@PartID, @Category, @Qty, @StockType)
	END
GO

/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/31/2024
Summary:            Create sp_Select_All_Item_Inventory Stored Procedure
Last Updated By:    Anthony Talamantes
Last Updated:       02/07/2024
What Was Changed:   Changed to an Update  
</summary>
*/
print '' print'*** creating sp_Select_All_Item_Inventory ***'
GO
CREATE PROCEDURE [dbo].[sp_Select_All_Item_Inventory]
AS
	BEGIN
		SELECT 
			[ItemID], [ItemName], [ItemDescription], [QtyOnHand], [NormalStockQty], [ReorderPoint],
			[OnOrder]
		FROM [Item]
	END
GO

/* 
<summary>
Creator:            Anthony Talamantes
Created:            01/31/2024
Summary:            Create sp_Select_Item_From_Inventory Stored Procedure
Last Updated By:    Anthony Talamantes
Last Updated:       02/07/2024
What Was Changed:   Changed to an Update  
</summary>
*/
print '' print'*** creating sp_Select_Item_From_Inventory ***'
GO
CREATE PROCEDURE [dbo].[sp_Select_Item_From_Inventory]
(
    @ItemID [int]
)
AS
BEGIN
    SELECT 
        [ItemID], [ItemName], [ItemDescription], [QtyOnHand], [NormalStockQty], [ReorderPoint],
        [OnOrder]
    FROM [Item]
    WHERE [ItemID] = @ItemID
END
GO		

/* 
<summary>
Creator:            Mitchell Stirmel
Created:            02/20/2024
Summary:            This stored procedure updates the quantity on hand in the item table.
Last Updated By:    Mitchell Stirmel
Last Updated:       02/20/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print'*** creating sp_update_item_quantity_on_hand ***'
GO
CREATE PROCEDURE [dbo].[sp_update_item_quantity_on_hand]
(
    @ItemID 	[INT]
,	@QtyOnHand 	[INT]
)
AS
BEGIN
	UPDATE [Item]
	SET [QtyOnHand] = @QtyOnHand
	WHERE [ItemID] = @ItemID
END
GO

/*
	<summary>
    Creator: Matthew Baccam
    Created: 03/07/2024
    Summary: Creating sp_select_client_details_vm
    Last Updated By: Matthew Baccam
    Last Updated: 03/07/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_select_client_details_vm ***'
GO
CREATE PROCEDURE [dbo].[sp_select_client_details_vm]
(
	@ClientID [nvarchar](100)
)
AS	
BEGIN
		SELECT
		    [Client].[ClientID],
    		[Client].[Fname],
			[Client].[Lname],
			[Client].[Gender],
			[Client].[Accomodations],
			[Client].[AccountStatus], 
			[Client].[RegistrationDate],
			[Client].[ExitDate],
			[Stay].[StayID],
			[Stay].[ClientID],
			[Stay].[RoomID],
			[Stay].[InDate],
			[Stay].[OutDate],
			[Stay].[CheckedOut],
			[Room].[RoomID],
			[Room].[ShelterID],
			[Room].[RoomNumber],
			[Room].[Status]
		FROM  [Client]
		INNER JOIN [Stay]
		ON [Client].[ClientID] = [Stay].[ClientID]
		INNER JOIN [Room] 
		ON [Stay].[RoomID] = [Room].[RoomID]
		WHERE [Client].[ClientID] = @ClientID
	END
GO

/*
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of sp_select_resources_by_category
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_select_resources_by_category ***'
GO
CREATE PROCEDURE [dbo].[sp_select_resources_by_category]
(
	@Category			[nvarchar](50)
)
AS
	BEGIN
		SELECT 	[ResourceID], 
				[Category], 
				[Active]
		FROM 	[ResourcesNeeded]
		WHERE	@Category = [Category]
		  AND	ACTIVE = 1
	END
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of sp_select_resources_by_ID
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_select_resources_by_ID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_resources_by_ID]
(
	@ResourceID			[nvarchar](50)
)
AS
	BEGIN
		SELECT 	[ResourceID], 
				[Category], 
				[Active]
		FROM 	[ResourcesNeeded]
		WHERE	@ResourceID = [ResourceID]
	END
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of sp_select_all_categories
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_select_all_categories ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_categories]
AS
	BEGIN
		SELECT 	[Category]
		FROM 	[ResourceCategory]
	END
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of sp_deactivate_resource_by_ID
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_deactivate_resource_by_ID ***'
GO
CREATE PROCEDURE [dbo].[sp_deactivate_resource_by_ID]
(
	@ResourceID		[nvarchar](50)
)
AS
	BEGIN
		UPDATE 	[ResourcesNeeded]
		   SET  [Active] = 0
		WHERE   @ResourceID = [ResourceID]
	END
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            02/22/2024
	Summary:            Creation of sp_edit_resources_needed
	Last Updated By:    Kirsten Stage
	Last Updated:       02/22/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_edit_resources_needed ***'
GO
CREATE PROCEDURE [dbo].[sp_edit_resources_needed]
(
	@NewResourceID		[nvarchar](50),
	@NewCategory		[nvarchar](50),
	@NewActive			[bit],
	@OldResourceID		[nvarchar](50),
	@OldCategory		[nvarchar](50)
)
AS
	BEGIN
		UPDATE 	[ResourcesNeeded]
		SET 	[ResourceID] 	= @NewResourceID,
				[Category]		= @NewCategory,
				[Active]		= @NewActive
		WHERE 	[ResourceID] 	= @OldResourceID
		  AND	[Category] 		= @OldCategory
	END
GO

/*
	<summary>
	Creator:            Kirsten Stage
	Created:            02/08/2024
	Summary:            Creation of sp_select_actively_needed_resources
	Last Updated By:    Kirsten Stage
	Last Updated:       02/08/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_select_actively_needed_resources ***'
GO
CREATE PROCEDURE [dbo].[sp_select_actively_needed_resources]
AS
	BEGIN
		SELECT 	[ResourceID], [Category], [Active]
		FROM 	[ResourcesNeeded]
		WHERE	Active = 1
	END
GO

/* 
	<summary>
	Creator:            Mitchell Stirmel
	Created:            02/07/2024
	Summary:            This trigger will update the lastupdated field whenever the partsinventory table is modified in any way.
	Last Updated By:    Mitchell Stirmel
	Last Updated:       02/07/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** tr_partsinventory_update_insert_delete***'
GO
CREATE TRIGGER tr_partsinventory_update_insert_delete
ON [dbo].[PartsInventory]
AFTER UPDATE, INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON

    UPDATE [PartsInventoryUpdatedDate] 
    SET [UpdatedDate] = GETDATE()
    WHERE [ID] = 1
END
GO

/*
    <summary>
    Creator:            Mitchell Stirmel
    Created:            02/13/2024
    Summary:            This is the stored procedure for adding a vendor.
    Last Updated By:    Mitchell Stirmel
    Last Updated:       02/13/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_add_vendor ***'
GO
CREATE PROCEDURE [dbo].[sp_add_vendor]
(
	@VendorName	            [nvarchar](100),
	@VendorAddress		    [nvarchar](100),
	@VendorEmail			[nvarchar](255),
    @VendorContactPhone     [nvarchar](11),
    @VendorContactName      [nvarchar](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[Vendor]
			([VendorName], [VendorAddress], [VendorEmail], [VendorContactPhone], [VendorContactName])
		VALUES
			(@VendorName, @VendorAddress, @VendorEmail, @VendorContactPhone, @VendorContactName)
	END
GO

/*****************************************************************************
						SHIFT STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator: Liam Easton
    Created: 02/15/2024
    Summary: initial creation of the sp_remove_shift stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/15/2024
    What Was Changed: initial creation of the sp_remove_shift stored procedure
    </summary>
*/
print '' print '*** creating sp_remove_shift ***'
GO
CREATE PROCEDURE [dbo].[sp_remove_shift]
(
	@ShiftID [nvarchar](100)
)
AS	
BEGIN
		DELETE FROM	[Shift]
		WHERE @ShiftID = [ShiftID]
	END
GO

/*
	<summary> 
	Creator:            Jared Harvey
	Created:            02/06/2024
	Summary:            Create sp_get_department_shifts stored procedure
	Last Updated By:    Jared Harvey
	Last Updated:       02/06/2024
	What Was Changed:   Initial Creation 
	</summary>
*/
print '' print '*** creating sp_get_department_shifts ***'
GO
CREATE PROCEDURE [dbo].[sp_get_department_shifts] (
	@DepartmentID		[int]
)
AS
	BEGIN
		SELECT	[ShiftID], [Shift].[EmployeeID], [StartTime], [EndTime], [Employee].[FName], [Employee].[LName]
		FROM [Shift]
		INNER JOIN [Employee] ON [Employee].[EmployeeID] = [Shift].[EmployeeID]
		INNER JOIN [EmployeeRole] ON [EmployeeRole].[EmployeeID] = [Employee].[EmployeeID]
		INNER JOIN [Role] ON [Role].[RoleID] = [EmployeeRole].[RoleID]
		WHERE [Role].[DepartmentID] = @DepartmentID
	END
GO

/* 
<summary>
Creator:            Jared Harvey
Created:            02/13/2024
Summary:            Create sp_update_shift
Last Updated By:    Jared Harvey
Last Updated:       02/13/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating sp_update_shift ***'
GO
CREATE PROCEDURE [dbo].[sp_update_shift]
(
	@ShiftID			[INT],
	@OldEmployeeID		[NVARCHAR] (100),
	@OldStartTime		[DATETIME],
	@OldEndTime			[DATETIME],
	@NewEmployeeID		[NVARCHAR] (100),
	@NewStartTime		[DATETIME],
	@NewEndTime			[DATETIME]
)
AS
	BEGIN
		UPDATE [dbo].[Shift]
		SET [EmployeeID] = @NewEmployeeID,
			[StartTime] = @NewStartTime,
			[EndTime] = @NewEndTime
		WHERE 	[ShiftID] = @ShiftID
		AND		[EmployeeID] = @OldEmployeeID
		AND		[StartTime] = @OldStartTime
		AND		[EndTime] = @OldEndTime
	END
GO

/*****************************************************************************
						EMPLOYEE STORED PROCEDURES
*****************************************************************************/

/*
    <summary> 
    Creator:            Tyler Barz
    Created:            03/02/2024
    Summary:            Created sp_select_employee_roles, get employee roles, with role descriptions
    Last Updated By:    Tyler Barz
    Last Updated:       03/02/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_employee_roles ***' 
GO
CREATE PROCEDURE sp_select_employee_roles(
	@EmployeeID 	NVARCHAR(100)
) 
AS 
BEGIN
	SELECT
		[EmployeeRole].[RoleID],
		[Role].[Description]
	FROM
		[EmployeeRole]
	JOIN [Role] ON [EmployeeRole].[RoleID] = [Role].[RoleID]
	WHERE [EmployeeRole].[EmployeeID] = @EmployeeID
END 
GO

/*
    <summary>
    Creator:            Darryl Shirley
    Created:            02/21/2024
    Summary:            This is the stored procedure for obtaining the 
						list of current EmployeeIDs.
    Last Updated By:    Darryl Shirley
    Last Updated:       02/21/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_EmployeeIDs ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_EmployeeIDs]
AS
	BEGIN
		SELECT 	EmployeeID
		FROM 	[Employee]
	END
GO

/* 
	<summary>
	Creator:            Sagan DeWald
	Created:            02/08/2024
	Summary:            Stored procedure to attempt to match an ID and hash to an entry in the Employee table.
	Last Updated By:    Sagan DeWald
	Last Updated:       02/08/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating authenticate_employee stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_employee]
(
	@EmployeeID		[nvarchar](100),
	@PasswordHash	[nvarchar](256)
)
AS BEGIN
    SELECT 	
        COUNT([EmployeeID]) as 'Authenticated'
    FROM	
        [dbo].[Employee]
    WHERE	
        @EmployeeID = [EmployeeID] AND	
        @PasswordHash = [PasswordHash] AND	
        [AccountStatus] = 1
END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 1/29/2024
    Summary: initial creation of the UpdateEmployeePasswordHash stored procedure
    Last Updated By: Liam Easton
    Last Updated: 1/29/2024
    What Was Changed: initial creation of the UpdateEmployeePasswordHash stored procedure
    </summary>
*/
print '' print '*** creating procedure UpdateEmployeePasswordHash ***'
GO
CREATE PROCEDURE [dbo].[UpdateEmployeePasswordHash]
(
    @EmployeeID			[nvarchar](100),
	@NewPasswordHash	[nvarchar](100),
	@OldPasswordHash	[nvarchar](100)
)
AS	
	BEGIN
		UPDATE	[Employee]
		SET	    [PasswordHash] = @NewPasswordHash
		WHERE 	@EmployeeID = [EmployeeID]
		  AND   @OldPasswordHash = [PasswordHash]
		RETURN  @@ROWCOUNT
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/15/2024
    Summary:            This is the stored procedure for obtaining the 
						list of Employees in a department.
    Last Updated By:    Jared Harvey
    Last Updated:       02/15/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_department_employees ***'
GO
CREATE PROCEDURE [dbo].[sp_get_department_employees] (
	@DepartmentID 			[INT]
)
AS
	BEGIN
		SELECT 	[Employee].[EmployeeID], [FName], [LName], [Phone], [Gender], [AccountStatus], [ZipCode], [Address], [StartDate], [EndDate]
		FROM 	[Employee]
		INNER JOIN [EmployeeRole] ON [EmployeeRole].[EmployeeID] = [Employee].[EmployeeID]
		INNER JOIN [Role] ON [Role].[RoleID] = [EmployeeRole].[RoleID]
		WHERE [Role].[DepartmentID] = @DepartmentID
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 02/01/2024
    Summary: initial creation of the SelectEmployeePasswordHashByEmployeeID stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/01/2024
    What Was Changed: initial creation of the SelectEmployeePasswordHashByEmployeeID stored procedure
    </summary>
*/
print '' print '*** creating SelectEmployeePasswordHashByEmployeeID ***'
GO
CREATE PROCEDURE [dbo].[SelectEmployeePasswordHashByEmployeeID]
(
	@EmployeeID			[nvarchar](100)
)
AS	
	BEGIN
		SELECT	[PasswordHash]
		FROM	[Employee]
		WHERE 	@EmployeeID = [EmployeeID]
	END
GO

/*****************************************************************************
						CLIENT STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator: Miyada Abas
    Created: 02/27/2024
    Summary: Stored procedure to sp_signUp 
    Last Updated By: Miyada Abas
    Last Updated: 02/27/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** sp_signUp ***'
GO
CREATE PROC sp_signUp(@email NVARCHAR (25) , @password NVARCHAR(256), @employeeId NVARCHAR (100),@Fname  [nvarchar] (25) ,@Phone   [nvarchar] (15), @Gender [bit],
@AccountStatus [bit],@ZipCode [int],@Address [nvarchar] (50),@StartDate  [date], @EndDate [date]  )
AS BEGIN
    INSERT INTO Employee(Lname,PasswordHash,employeeId,Fname,Phone,Gender,AccountStatus,ZipCode,Address,StartDate,EndDate)
VALUES(@email,@password,@employeeId,@Fname,@Phone,@Gender,@AccountStatus,@ZipCode,@Address,@StartDate,@EndDate);
END
GO

/*
    <summary>
    Creator: Tyler Barz
    Created: 02/14/2024
    Summary: Creating sp_select_client_details, for details post login
    Last Updated By: Tyler Barz
    Last Updated: 02/14/2024
    What Was Changed: Inital creation
    </summary>
*/
print '' print '*** creating sp_select_client_details ***'
GO
CREATE PROCEDURE [dbo].[sp_select_client_details]
(
	@ClientID [nvarchar](100)
)
AS	
BEGIN
		SELECT	
		    [ClientID],
    		[Fname],
			[Lname],
			[Gender],
			[Accomodations],
			[AccountStatus], 
			[RegistrationDate],
			[ExitDate]
		FROM  [Client]
		WHERE [ClientID] = @ClientID
	END
GO

/* 
	<summary>
	Creator:            Sagan DeWald
	Created:            02/08/2024
	Summary:            Stored procedure to attempt to match an ID and hash to an entry in the Client table.
	Last Updated By:    Sagan DeWald
	Last Updated:       02/08/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating authenticate_client stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_client]
(
	@ClientID		[nvarchar](100),
	@PasswordHash	[nvarchar](256)
)
AS BEGIN
    SELECT 	
        COUNT([ClientID]) as 'Authenticated'
    FROM	
        [dbo].[Client]
    WHERE	
        @ClientID = [ClientID] AND	
        @PasswordHash = [PasswordHash] AND	
        [AccountStatus] = 1
END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/19/2024
    Summary:            Gets all clients
    Last Updated By:    Jared Harvey
    Last Updated:       02/19/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_all_clients ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_clients]
AS
	BEGIN
		SELECT [ClientID], [FName], [LName], [Gender], [Accomodations], [AccountStatus], [RegistrationDate], [ExitDate]
		FROM [dbo].[Client]
	END
GO

/*****************************************************************************
						STAY STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/19/2024
    Summary:            This stored procedure checks in a client 
						by creating a stay entry.
    Last Updated By:    Jared Harvey
    Last Updated:       02/19/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_assign_client_shelter ***'
GO
CREATE PROCEDURE [dbo].[sp_assign_client_shelter] (
	@ClientID 			[NVARCHAR] (100),
	@RoomID				[INT]
)
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				INSERT INTO [dbo].[Stay]
					([ClientID], [RoomID], [InDate], [OutDate])
				VALUES
					(@ClientID, @RoomID, CURRENT_TIMESTAMP, DATEADD(day, 1, CURRENT_TIMESTAMP))
		
				UPDATE [dbo].[Room]
				SET Status = 'Occupied'
				WHERE [Room].[RoomID] = @RoomID
			COMMIT TRANSACTION
			SELECT @@ROWCOUNT
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT @@ROWCOUNT
		END CATCH
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            03/22/2024
    Summary:            Returns the stay from stay id
    Last Updated By:    Jared Harvey
    Last Updated:       03/22/2024
    What Was Changed:   Changed it a wee bit innit
    </summary>
*/
print '' print '*** creating sp_get_stay ***'
GO
CREATE PROCEDURE [dbo].[sp_get_stay] (
	@StayID		[INT]
)
AS
	BEGIN
		SELECT [StayID], [ClientID], [RoomID], [InDate], [OutDate], [CheckedOut]
		FROM [Stay]
		WHERE StayID = @StayID
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/27/2024
    Summary:            Returns all Stays for a given shelter
    Last Updated By:    Jared Harvey
    Last Updated:       02/29/2024
    What Was Changed:   Changed it a wee bit innit
    </summary>
*/
print '' print '*** creating sp_get_all_stays_for_shelter ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_stays_for_shelter] (
	@ShelterID		[NVARCHAR] (50)
)
AS
	BEGIN
		SELECT [StayID], [ClientID], [Stay].[RoomID], [InDate], [OutDate], [CheckedOut], [Room].[RoomNumber]
		FROM [dbo].[Stay]
		INNER JOIN [Room] ON [Stay].[RoomID] = [Room].[RoomID]
		WHERE [Room].[ShelterID] = @ShelterID
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/28/2024
    Summary:            Creation of sp_update_stay
    Last Updated By:    Jared Harvey
    Last Updated:       02/28/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_update_stay ***'
GO
CREATE PROCEDURE [dbo].[sp_update_stay] (
	@StayID 		[INT],
	@OldClientID 	[NVARCHAR] (100),
	@OldRoomID		[INT],
	@OldInDate		[DATE],
	@OldOutDate		[DATE],
	@OldCheckedOut	[BIT],
	@NewClientID 	[NVARCHAR] (100),
	@NewRoomID		[INT],
	@NewInDate		[DATE],
	@NewOutDate		[DATE],
	@NewCheckedOut	[BIT]
)
AS
	BEGIN
		BEGIN TRY
			BEGIN TRANSACTION
				UPDATE 	[dbo].[Stay] 
				SET 	[ClientID] = @NewClientID, 
						[RoomID] = @NewRoomID, 
						[InDate] = @NewInDate,
						[OutDate] = @NewOutDate, 
						[CheckedOut] = @NewCheckedOut
				WHERE 	[Stay].[StayID] = @StayID
				AND		[ClientID] = @OldClientID 
				AND		[RoomID] = @OldRoomID 
				AND		[InDate] = @OldInDate
				AND		[OutDate] = @OldOutDate 
				AND		[CheckedOut] = @OldCheckedOut
				
			UPDATE [dbo].[Room]
			SET [Status] = 'Available'
			WHERE [RoomID] = @OldRoomID
			
			UPDATE [dbo].[Room]
			SET [Status] = 'Occupied'
			WHERE [RoomID] = @NewRoomID
			
			COMMIT TRANSACTION
			SELECT @@ROWCOUNT
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT 0
		END CATCH
	END
GO

/*
    <summary>
    Creator:            Jared Harvey
    Created:            02/29/2024
    Summary:            Creation of sp_delete_stay
    Last Updated By:    Jared Harvey
    Last Updated:       02/29/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_delete_stay ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_stay] (
	@StayID 		[INT]
)
AS
	BEGIN
		DELETE FROM [dbo].[Stay]
		WHERE [Stay].[StayID] = @StayID
	END
GO

/*****************************************************************************
						VOLUNTEER STORED PROCEDURES
*****************************************************************************/

/*
    <summary> 
    Creator:            Tyler Barz
    Created:            03/02/2024
    Summary:            Created sp_select_volunteer_role, get volunteer role, with its description
    Last Updated By:    Tyler Barz
    Last Updated:       03/02/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_volunteer_role ***' 
GO
CREATE PROCEDURE sp_select_volunteer_role(
	@VolunteerID 	NVARCHAR(100)
) 
AS 
BEGIN
	SELECT
		[Volunteer].[RoleID],
		[Role].[Description]
	FROM
		[Volunteer]
	JOIN [Role] ON [Volunteer].[RoleID] = [Role].[RoleID]
	WHERE [Volunteer].[VolunteerID] = @VolunteerID
END 
GO

/* 
	<summary>
	Creator:            Sagan DeWald
	Created:            02/08/2024
	Summary:            Stored procedure to attempt to match an ID and hash to an entry in the Volunteer table.
	Last Updated By:    Sagan DeWald
	Last Updated:       02/08/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating authenticate_volunteer stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_volunteer]
(
	@VolunteerID	[nvarchar](100),
	@PasswordHash	[nvarchar](255)
)
AS 
	BEGIN
		SELECT COUNT([VolunteerID]) as 'Authenticated'
		FROM [dbo].[Volunteer]
		WHERE 
			@VolunteerID = [VolunteerID] AND	
			@PasswordHash = [PasswordHash] AND	
			[AccountStatus] = 1
	END
GO

/* 
Creator:            Andrew Larson
Created:            02/18/2024
Summary:            Creation of sp_add_resources_needed
Last Updated By:    Andrew Larson
Last Updated:       02/18/2024
What Was Changed:   Initial Creation  */
print '' print '*** creating sp_add_resources_needed ***'
GO
CREATE PROCEDURE [dbo].[sp_add_resources_needed]
(
	@ResourceID	            [nvarchar](50),
	@Category		    	[nvarchar](50)
)	
AS
	BEGIN
		INSERT INTO [dbo].[ResourcesNeeded]
			([ResourceID], [Category])
		VALUES
			(@ResourceID, @Category)
	END
GO	

/*
	Creator:            Abdalgader Ibrahim
	Created:            02/20/2024
	Summary:            Create sp_Select_Event_VM Stored Procedure
	Last Updated By:    Abdalgader Ibrahim
	Last Updated:       02/20/2024
	What Was Changed:   Changed to an Update  
	</summary>
*/
print '' print'*** creating sp_Select_Event_VM  ***'
GO
CREATE PROCEDURE [dbo].[sp_Select_Event_VM]

AS
BEGIN
    SELECT DISTINCT 
			[Event].[EventID], [Event].[EventName], [Event].[Description], [Event].[VolunteersNeeded],
			[EventSchedule].[StartTime],[EventSchedule].[EndTime],[EventSchedule].[EventDay],
			[EventLocation].[Address]
		FROM [Event]  
		Inner JOIN [EventSchedule] 
		ON [Event].[EventID]=[EventSchedule].[EventID]
		INNER JOIN [EventLocation]
		ON [Event].[EventID]=[EventLocation].[EventID]
		WHERE [Event].[Active]= 1
	END
GO

/*
	Creator:            Matthew Baccam
	Created:            04/26/2024
	Summary:            Created sp_select_eventVM_by_ID
	Last Updated By:    Matthew Baccam
	Last Updated:       04/26/2024
	What Was Changed:   Initial creation  
	</summary>
*/
print '' print'*** creating sp_select_eventVM_by_ID  ***'
GO
CREATE PROCEDURE [dbo].[sp_select_eventVM_by_ID](
	@EventID [INT]
)
AS
BEGIN
    	SELECT 	
			[Event].[EventID], [Event].[EventName], [Event].[Description], [Event].[VolunteersNeeded],
			[EventSchedule].[StartTime],[EventSchedule].[EndTime],[EventSchedule].[EventDay],
			[EventLocation].[Address]
		FROM [Event]  
		Inner JOIN [EventSchedule] 
		ON [Event].[EventID]=[EventSchedule].[EventID]
		INNER JOIN [EventLocation]
		ON [Event].[EventID]=[EventLocation].[EventID]
		WHERE [Event].[Active]= 1 
		AND [Event].[EventID] = @EventID
	END
GO
/*
Creator:            Suliman Suliman
Created:            02/22/2024
Summary:            Create sp_select_all_kitchen_inventory_items Stored Procedure
Last Updated By:    
Last Updated:       
What Was Changed:     
</summary>
*/
print '' print '*** creating sp_select_all_kitchen_inventory_items ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_kitchen_inventory_items]
AS
	BEGIN
		SELECT 	[KitchenItemID], [ItemName], [QuantityInStock],[Category],[UnitCost],[Supplier],[ReorderQuantity]
		FROM 	[KitchenInventoryItem]
    END
GO

/* 
Creator:            Ethan McElree
Created:            04/15/2024
Summary:            Stored procedure for selecting kitchen inventory items by category.
Last Updated By:    Ethan McElree
Last Updated:       04/15/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_kitchen_inventory_item_by_category ***'
GO
CREATE PROCEDURE [dbo].[sp_select_kitchen_inventory_item_by_category]
    @Category nvarchar (50)
AS
BEGIN
	SELECT [KitchenItemID], [ItemName], [QuantityInStock], [Category], [UnitCost], [Supplier], [ReorderQuantity]
    FROM [dbo].[KitchenInventoryItem]
    WHERE Category = @Category;
END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 1/29/2024
    Summary: initial creation of the UpdateVolunteerPasswordHash stored procedure
    Last Updated By: Liam Easton
    Last Updated: 1/29/2024
    What Was Changed: initial creation of the UpdateVolunteerPasswordHash stored procedure
    </summary>
*/
print '' print '*** creating procedure UpdateVolunteerPasswordHash ***'
GO
CREATE PROCEDURE [dbo].[UpdateVolunteerPasswordHash]
(
	@VolunteerID		[nvarchar](100),
	@NewPasswordHash	[nvarchar](100),
	@OldPasswordHash	[nvarchar](100)
)
AS	
	BEGIN
		UPDATE	[Volunteer]
		SET	    [PasswordHash] = @NewPasswordHash
		WHERE 	@VolunteerID = [VolunteerID]
		  AND   @OldPasswordHash = [PasswordHash]
		RETURN  @@ROWCOUNT
	END
GO

-- /*
--     <summary>
--     Creator: Tyler Barz
--     Created: 02/14/2024
--     Summary: Creating sp_select_volunteer_details, for details post login
--     Last Updated By: Tyler Barz
--     Last Updated: 02/14/2024
--     What Was Changed: Inital creation
--     </summary>
-- */
-- print '' print '*** creating sp_select_volunteer_details ***'
-- GO
-- CREATE PROCEDURE [dbo].[sp_select_volunteer_details]
-- (
-- 	@VolunteerID [nvarchar](100)
-- )
-- AS	
-- BEGIN
-- 		SELECT	
-- 		    [VolunteerID],
--     		[Fname],
-- 			[Lname],
-- 			[Phone],
-- 			[Gender],
-- 			[AccountStatus], 
-- 			[RoleID],
-- 			[ZipCode],
-- 			[Address],
-- 			[RegistrationDate]
-- 		FROM  [Volunteer]
-- 		WHERE [VolunteerID] = @VolunteerID
-- 	END
-- GO

/* 
<summary>
Creator:            Matthew Baccam
Created:            02/15/2024
Summary:            Creation for sp_search_for_client_appointment_with_from_to
Last Updated By:    Matthew Baccam
Last Updated:       02/22/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_select_visit_by_visitID'
GO
CREATE PROCEDURE [dbo].[sp_select_visit_by_visitID](
		@VisitID [int]
) AS
	BEGIN 
		SELECT [VisitID]
			, [FirstName]
			, [LastName]
			, [CheckIn]
			, [CheckOut]
			, [VisitReason]
			, [Status]
		FROM [Visit]
		WHERE [VisitID] = @VisitID 
	END
GO

/* 
<summary>
Creator:            Matthew Baccam
Created:            02/15/2024
Summary:            Creation for sp_search_for_visits_with_from_to
Last Updated By:    Matthew Baccam
Last Updated:       02/08/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_search_for_visits_with_from_to'
GO
CREATE PROCEDURE [dbo].[sp_search_for_visits_with_from_to](
		@From [datetime]
		, @To [datetime]
) AS
	BEGIN 
		SELECT [VisitID]
			, [FirstName]
			, [LastName]
			, [CheckIn]
			, [CheckOut]
			, [VisitReason]
			, [Status]
		FROM [Visit]
		WHERE CONVERT(DATE, [CheckIn]) >= @From 
		AND CONVERT(DATE, [CheckOut]) <= @To 
	END
GO

/* 
<summary>
Creator:            Matthew Baccam
Created:            02/15/2024
Summary:            Creation for sp_update_visit_for_checkout_with_visitID
Last Updated By:    Matthew Baccam
Last Updated:       02/08/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_update_visit_for_checkout_with_visitID'
GO
CREATE PROCEDURE [dbo].[sp_update_visit_for_checkout_with_visitID](
		@VisitID [int]
		, @OldCheckOut [DateTime]
) AS
	BEGIN 
			UPDATE [Visit]
			SET [CheckOut] = GETDATE()
			, [Status] = 0
			WHERE [Visit].[VisitID] = @VisitID
			AND [CheckOut] = @OldCheckOut
	END
GO


/* 
<summary>
Creator:            Matthew Baccam
Created:            02/15/2024
Summary:            Creation for sp_update_visit_for_checkin_with_visitID
Last Updated By:    Matthew Baccam
Last Updated:       02/08/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_update_visit_for_checkin_with_visitID'
GO
CREATE PROCEDURE [dbo].[sp_update_visit_for_checkin_with_visitID](
		@VisitID [int]
		, @OldCheckIn [DateTime]
) AS
	BEGIN 
			UPDATE [Visit]
			SET [CheckIn] = GETDATE()
			, [Status] = 1
			WHERE [VisitID] = @VisitID
			AND [CheckIn] = @OldCheckIn
	END
GO


/* 
<summary>
Creator:            Matthew Baccam
Created:            02/08/2024
Summary:            Creation for sp_select_visit_count stored procedure
Last Updated By:    Matthew Baccam
Last Updated:       02/08/2024
What Was Changed:   Initial Creation  
</summary>
*/
PRINT '' 
PRINT 'Creating sp_select_visit_count'
GO
CREATE PROCEDURE [dbo].[sp_select_visit_count](
        @VisitDate [Date]
) AS
	BEGIN 
        SELECT COUNT([CheckIn])
        FROM [Visit]
        WHERE CAST([CheckIn] AS DATE) = @VisitDate
	END
GO

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure for creating a new visit
    Last Updated By:    Ibrahim Albashair
    Last Updated:       02/10/2024
    What Was Changed:   Initial Creation
    Last Updated By:    Matthew Baccam
    Last Updated:       02/28/2024
    What Was Changed:   Added the status field 
    </summary>
*/

print '' print '**** creating sp_view_visits_on_firstname ****'
GO
CREATE PROCEDURE [dbo].[sp_view_visits_on_firstname]
(	
	@FirstName		[NVARCHAR](100),
	@LastName		[NVARCHAR](100)
)
AS
	BEGIN
	
        SELECT [VisitID], [FirstName], [LastName], [CheckIn], [CheckOut], [VisitReason], [Status]
		FROM Visit
		WHERE @FirstName = [FirstName] AND @LastName = [LastName]
	END
GO 

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure for Deleting a visit
    Last Updated By:    Ibrahim Albashair
    Last Updated:       02/10/2024
    What Was Changed:   Initial Creation
    Last Updated By:    Matthew Baccam
    Last Updated:       04/04/2024
    What Was Changed:   Added the other table columns so a delete doesnt occur if someone updates by chance
    Last Updated By:    Mitchell Stirmel
    Last Updated:       04/10/2024
    What Was Changed:   Fixed error in stored procedure.
    </summary>
*/

print '' print '**** creating sp_delete_visit ****'
GO
CREATE PROCEDURE [dbo].[sp_delete_visit]
(	
	@VisitID       int
	, @FirstName     [NVARCHAR](100) 
	, @LastName      [NVARCHAR](100) 			
	, @CheckIn       [DateTime]		 			
	, @CheckOut      [DateTime]					
	, @VisitReason   [NVARCHAR](100) 			
	, @Status   		[BIT]	
)			
AS
	BEGIN
		DELETE FROM [Visit]
		WHERE [VisitID] = @VisitID
		AND [FirstName] = @FirstName
		AND [LastName] = @LastName
		AND [CheckIn] = @CheckIn
		AND [CheckOut] = @CheckOut
		AND [VisitReason] = @VisitReason
		AND [Status] = @Status		
	END
GO

/*****************************************************************************
						KITCHEN STORED PROCEDURES
*****************************************************************************/

/* 
Creator:            Ethan McElree
Created:            01/30/2024
Summary:            Stored procedure for creating a food menu.
Last Updated By:    Ethan McElree
Last Updated:       02/12/2024
What Was Changed:   Returned primary key 
*/
print '' print '*** creating sp_insert_food_menu ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_food_menu]
    @DayOfMeal          NVARCHAR(50),
    @MenuName           NVARCHAR(50),
    @MenuType           NVARCHAR(11),
    @DateLastModified   DATE
AS
BEGIN
    SET NOCOUNT ON;
		
    INSERT INTO [dbo].[WeekFoodMenu] ([DayOfMeal], [MenuName], [MenuType], [DateLastModified])
    VALUES (@DayOfMeal, @MenuName, @MenuType, @DateLastModified);
	
    SELECT @@IDENTITY;
END
GO

/* 
Creator:            Ethan McElree
Created:            01/30/2024
Summary:            Stored procedure for adding a meal to the menu.
Last Updated By:    Ethan McElree
Last Updated:       01/30/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_add_meal_to_menu ***'
GO
CREATE PROCEDURE [dbo].[sp_add_meal_to_menu]
    @MenuID           	INT,
    @RecipeID           INT,
    @EmployeeID   		NVARCHAR(100),
	@Category   		NVARCHAR(50)
AS
BEGIN   
	SET NOCOUNT ON;

    INSERT INTO [dbo].[MenuMeal] ([MenuID], [RecipeID], [EmployeeID], [Category])
    VALUES (@MenuID, @RecipeID, @EmployeeID, @Category);  	
END
GO

/* 
Creator:            Ethan McElree
Created:            01/31/2024
Summary:            Stored procedure for selecting all recipes.
Last Updated By:    Ethan McElree
Last Updated:       01/31/2024
What Was Changed:   Initial creation 
Last Updated By:    Matthew Baccam
Last Updated:       03/08/2024
What Was Changed:   made it read in all the data required because it was throwing errors because of that 
*/
print '' print '*** creating sp_select_all_recipes ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_recipes]
    
AS
BEGIN
	SELECT [RecipeID], [RecipeName], [RecipeDescription], [Calories], [Allergens], [Vegen], [PrepTime], [MenuID], [Category], [KitchenItemID], [RecipeSteps], [RecipeImage]
	FROM [dbo].[Recipe];
END
GO

/* 
Creator:            Ethan McElree
Created:            02/27/2024
Summary:            Stored procedure for selecting menu ids.
Last Updated By:    Ethan McElree
Last Updated:       02/27/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_all_menu_ids ***'
GO
CREATE PROCEDURE sp_select_all_menu_ids
AS
BEGIN
    SELECT [MenuID] 
	FROM [dbo].[WeekFoodMenu];
END
GO

/* 
Creator:            Ethan McElree
Created:            04/19/2024
Summary:            Stored procedure for selecting all food menus.
Last Updated By:    Ethan McElree
Last Updated:       04/19/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_all_week_food_menus ***'
GO
CREATE PROCEDURE sp_select_all_week_food_menus
AS
BEGIN
    SELECT [MenuID], [DayOfMeal], [MenuName], [MenuType], [DateLastModified] 
	FROM [dbo].[WeekFoodMenu];
END
GO

/* 
Creator:            Ethan McElree
Created:            02/05/2024
Summary:            Stored procedure for viewing the food menu.
Last Updated By:    Ethan McElree
Last Updated:       02/05/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_food_menu ***'
GO
CREATE PROCEDURE [dbo].[sp_select_food_menu]
    @MenuID INT
AS
BEGIN
    SELECT [MenuID], [DayOfMeal], [MenuName], [MenuType], [DateLastModified]
    FROM [dbo].[WeekFoodMenu]
    WHERE MenuID = @MenuID;
END
GO

/* 
Creator:            Ethan McElree
Created:            02/05/2024
Summary:            Stored procedure for getting the menu meals.
Last Updated By:    Ethan McElree
Last Updated:       02/05/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_food_menu_meals ***'
GO
CREATE PROCEDURE [dbo].[sp_select_food_menu_meals]
    @MenuID INT
AS
BEGIN
    SELECT [MealID], [MenuID], [RecipeID], [EmployeeID], [Category]
    FROM [dbo].[MenuMeal]
    WHERE MenuID = @MenuID;
END
GO

/* 
Creator:            Ethan McElree
Created:            02/06/2024
Summary:            Stored procedure for selecting recipes by the menu ID.
Last Updated By:    Ethan McElree
Last Updated:       02/06/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_recipes_by_menu ***'
GO
CREATE PROCEDURE [dbo].[sp_select_recipes_by_menu]
    @MenuID INT
AS
BEGIN
    SELECT [RecipeID], [RecipeName], [RecipeDescription], [Calories], [Allergens], [Vegen], [PrepTime], [MenuID], [Category], [KitchenItemID]
    FROM [dbo].[Recipe]
    WHERE MenuID = @MenuID;
END
GO

/* 
Creator:            Ethan McElree
Created:            03/18/2024
Summary:            Stored procedure for selecting recipes by category.
Last Updated By:    Ethan McElree
Last Updated:       03/18/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_recipes_by_category ***'
GO
CREATE PROCEDURE [dbo].[sp_select_recipes_by_category]
    @Category nvarchar (50)
AS
BEGIN
	SELECT [RecipeID], [RecipeName], [RecipeDescription], [Calories], [Allergens], [Vegen], [PrepTime], [MenuID], [Category], [KitchenItemID], 
	[RecipeSteps], [RecipeImage]
    FROM [dbo].[Recipe]
    WHERE Category = @Category;
END
GO

/* 
Creator:            Ethan McElree
Created:            02/12/2024
Summary:            Stored procedure for inserting recipes.
Last Updated By:    Ethan McElree
Last Updated:       02/12/2024
What Was Changed:   Initial creation 
Last Updated By:    Matthew Baccam
Last Updated:       04/25/2024
What Was Changed:   Changed [RecipeImage] => NVARCHAR MAX, [RecipeDescription] => NVARCHAR MAX,
					 [Allergens] => NVARCHAR MAX,  
*/
print '' print '*** creating sp_insert_recipe_for_menu ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_recipe_for_menu]
(
	@RecipeName 		NVARCHAR (100), 
	@RecipeDescription 	NVARCHAR (MAX), 
	@Calories			INT, 
	@Allergens			NVARCHAR (MAX), 
	@Vegen				bit, 
	@PrepTime			INT, 
	@MenuID				INT, 
	@Category			NVARCHAR (50), 
	@KitchenItemID		INT,
	@RecipeSteps		TEXT)
AS
BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO [dbo].[Recipe]
		([RecipeName], [RecipeDescription], [Calories], [Allergens], [Vegen], [PrepTime], [MenuID], [Category], [KitchenItemID], [RecipeSteps])
	VALUES
		(@RecipeName, @RecipeDescription, @Calories, @Allergens, @Vegen, @PrepTime, @MenuID, @Category, @KitchenItemID, @RecipeSteps)
    
END
GO

/* 
	<summary>
	Creator:            Ethan McElree
	Created:            02/19/2024
	Summary:            Creation of sp_delete_recipe
	Last Updated By:    Ethan McElree
	Last Updated:       02/19/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** inserting sp_delete_recipe ***'
GO
CREATE PROCEDURE sp_delete_recipe
    @RecipeName nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [dbo].[Recipe] WHERE [RecipeName] = @RecipeName)
    BEGIN
        DELETE FROM [dbo].[Recipe] WHERE [RecipeName] = @RecipeName;
	END
	ELSE
	BEGIN
		print 'Could not find item.';
	END
END
GO

/* 
<summary>
Creator:            Andrew larson
Created:            02/12/2024
Summary:            Create sp_select_ingredients_by_RecipeID to retrieve
					a list of ingredients for the matching RecipeID.
Last Updated By:    Andrew Larson
Last Updated:       02/12/2024
What Was Changed:   Initial Creation
</summary>
*/
print '' print '*** creating sp_select_ingredients_by_RecipeID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_ingredients_by_RecipeID]
(
	@RecipeID		[int]
)
AS
	BEGIN
		SELECT [IngredientID]
		FROM [RecipeIngredients]	
		JOIN [Recipe] ON [Recipe].[RecipeID] = [RecipeIngredients].[RecipeID]
		WHERE @RecipeID = [RecipeIngredients].[RecipeID]
	END
GO

/*****************************************************************************
						INCIDENT STORED PROCEDURES
*****************************************************************************/

/*
    Creator: Liam Easton
    Created: 02/25/2024
    Summary: initial creation of the sp_select_all_incident_reports stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/25/2024
    What Was Changed: initial creation of the sp_select_all_incident_reports stored procedure
    </summary>
*/
print '' print '*** creating sp_select_all_incident_reports ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_incident_reports]
AS
BEGIN
		SELECT [IncidentID], [Description], [IncidentStatus], [Reported], [ReportedBy], [Feedback], [Severity]
		FROM [Incident]
	END
GO

/* 
<summary>
Creator:            Darryl Shirley
Created:            01/31/2024
Summary:            Create sp_Add_Incident_Report Stored Procedure
Last Updated By:    Darryl Shirley
Last Updated:       02/07/2024
What Was Changed:   Changed to an Update  
</summary>
*/
print '' print '**** sp_Add_Incident_Report ****'
GO
CREATE PROCEDURE [dbo].[sp_Add_Incident_Report]
(
	@Description			[nvarchar](1000),
	@Reported				[nvarchar](100),
	@ReportedBy				[nvarchar](100),
	@Severity				[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[Incident]
			([Description], [Reported], [ReportedBy], [Severity])
		VALUES
			(@Description, @Reported, @ReportedBy, @Severity)
	END
GO

/*
    <summary>
    Creator:            Darryl Shirley
    Created:            02/21/2024
    Summary:            This is the stored procedure for obtaining the 
						list of current Incident Reports.
    Last Updated By:    Darryl Shirley
    Last Updated:       02/21/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_Incidents ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_Incidents]
AS
	BEGIN
		SELECT 	*
		FROM 	[Incident]
	END
GO

/*****************************************************************************
						VISIT STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure for creating a new visit
    Last Updated By:    Ibrahim Albashair
    Last Updated:       02/10/2024
    What Was Changed:   Initial Creation
    </summary>
*/

print '' print '**** creating sp_create_visit****'
GO
CREATE PROCEDURE [dbo].[sp_create_visit]
(	
	@FirstName		[NVARCHAR](100),
	@LastName		[NVARCHAR](100),
	@CheckIn		[NVARCHAR](100),
	@CheckOut		[NVARCHAR](100), 
	@VisitReason	[NVARCHAR](100) 
)
AS
	BEGIN
		INSERT INTO [Visit]
			([FirstName], [LastName], [CheckIn], [CheckOut], [VisitReason])
		VALUES
			(@FirstName, @LastName, @CheckIn, @CheckOut, @VisitReason)
	END
GO 

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/20/2024
    Summary:            This is the stored procedure for rescheduling a visit
    Last Updated By:    Ibrahim Albashair
    Last Updated:       02/10/2024
    What Was Changed:   Initial Creation
    </summary>
*/

print '' print '**** creating sp_reschedule_visit ****'
GO
CREATE PROCEDURE [dbo].[sp_reschedule_visit]
(	
	@VisitID       int,
	@CheckIn 	   NVARCHAR(255),
	@CheckOut	   NVARCHAR(255)
)
AS
	BEGIN
		UPDATE [Visit]
		SET [CheckIn] = @CheckIn, [CheckOut] = @CheckOut
		WHERE @VisitID = [VisitID]
	END
GO 

/*****************************************************************************
						SCHEDULE STORED PROCEDURES
*****************************************************************************/

/*
    <summary>
    Creator: Ethan McElree
    Created: 02/13/2024
    Summary: Creating the sp_create_schedule stored procedure
    Last Updated By: Ethan McElree
    Last Updated: 02/13/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_create_schedule ***'
GO
CREATE PROCEDURE [dbo].[sp_create_schedule]
(
	@ScheduleMonth		[nvarchar](50),
	@ScheduleWeek		[int],
	@ScheduleYear		[int],
	@ScheduleStartDate  [Date],
	@ScheduleEndDate	[Date]
)
AS
	BEGIN
		INSERT INTO [dbo].[Schedule] ([ScheduleMonth], [ScheduleWeek], [ScheduleYear], [ScheduleStartDate], [ScheduleEndDate])
		VALUES (@ScheduleMonth, @ScheduleWeek, @ScheduleYear, @ScheduleStartDate, @ScheduleEndDate);
	END
GO

/*
    <summary>
    Creator: Ethan McElree
    Created: 02/14/2024
    Summary: Creating the sp_check_schedule_exists stored procedure
    Last Updated By: Ethan McElree
    Last Updated: 02/14/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_check_schedule_exists ***'
GO
CREATE PROCEDURE [dbo].[sp_check_schedule_exists]
(
	@ScheduleMonth		[nvarchar](50),
	@ScheduleWeek		[int],
	@ScheduleYear		[int]
)
AS
	BEGIN
		SELECT [ScheduleMonth], [ScheduleWeek], [ScheduleYear]
		FROM [dbo].[Schedule]
		WHERE ScheduleMonth = @ScheduleMonth AND ScheduleWeek = @ScheduleWeek AND ScheduleYear = @ScheduleYear;		
	END
GO

/*****************************************************************************
						DEPARTMENT STORED PROCEDURES
*****************************************************************************/

/*
    <summary> 
    Creator:            Jared Harvey
    Created:            02/06/2024
    Summary:            Create sp_get_shelter_departments stored procedure
    Last Updated By:    Jared Harvey
    Last Updated:       02/06/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '** creating sp_get_shelter_departments ***'
GO
CREATE PROCEDURE [dbo].[sp_get_shelter_departments] (
    @ShelterID        [nvarchar] (50)
)
AS
    BEGIN
        SELECT [DepartmentID], [ShelterID], [DepartmentName], [Description]
        FROM [Department]
        WHERE [Department].[ShelterID] = @ShelterID
    END
GO

/*
    <summary>
    Creator: Anthony Talamantes
    Created: 02/12/2024
    Summary: Stored procedure to select all stock types from PartsInventory
    Last Updated By: Anthony Talamantes
    Last Updated: 02/12/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_stock_type'
GO
CREATE PROCEDURE [dbo].[sp_select_all_stock_type]
AS
	BEGIN
		SELECT [StockType]
		FROM [PartsInventory]
	END
GO

/*
    <summary>
    Creator: Anthony Talamantes
    Created: 02/20/2024
    Summary: Stored procedure to delete a part from PartsInventory
    Last Updated By: Anthony Talamantes
    Last Updated: 02/20/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_delete_part_from_parts_inventory ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_part_from_parts_inventory]
(
    @PartID  [nvarchar](255)
)
AS
BEGIN
    DELETE FROM [PartsInventory]
    WHERE [PartID] = @PartID
END
GO

/*
    <summary>
    Creator: Ethan McElree
    Created: 04/1/2024
    Summary: Stored procedure to get all volunteers
    Last Updated By: Ethan McElree
    Last Updated: 04/1/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_all_volunteers ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_volunteers]
AS
	BEGIN
		SELECT [VolunteerID], [FirstName], [LastName], [Phone], [Gender], [PasswordHash], [AccountStatus], [RoleID], [RegistrationDate], [Address], 
		[ZipCode]
		FROM [Volunteer]
	END
GO

/*
    <summary>
    Creator: Ethan McElree
    Created: 04/12/2024
    Summary: Stored procedure to get a volunteer by their id.
    Last Updated By: Ethan McElree
    Last Updated: 04/12/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_retrieve_volunteer_by_id ***'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_volunteer_by_id]
(
	@VolunteerID	[nvarchar](100)
)
AS
	BEGIN
		SELECT [VolunteerID], [FirstName], [LastName], [Phone], [Gender], [PasswordHash], [AccountStatus], [RoleID], [RegistrationDate], [Address], [ZipCode]
		FROM [Volunteer]
		WHERE [VolunteerID] = @VolunteerID;
	END
GO
/*
    <summary>
    Creator: Ethan McElree
    Created: 04/8/2024
    Summary: Stored procedure to delete a volunteer
    Last Updated By: Ethan McElree
    Last Updated: 04/8/2024
    What Was Changed: Initial Creation
    </summary>
*/ 
print '' print '*** creating sp_delete_volunteer ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_volunteer]
(
	@VolunteerID [nvarchar] (100)
)
AS
	BEGIN
		DELETE FROM [dbo].[Volunteer]
		WHERE [VolunteerID] = @VolunteerID
	END
GO

/*
    <summary>
    Creator: Abdalgader Ibrahim
    Created: 02/27/2024
    Summary: Stored procedure to Event Volunteers
    Last Updated By: Andrew Larson
    Last Updated: 03/20/2024
    What Was Changed: Added the VolunteerID to the select statement
    </summary>
*/
print '' print '*** creating sp_get_event_volunteers ***'
GO
CREATE PROCEDURE [dbo].[sp_get_event_volunteers]
(
    @EventID  [INT]
)
AS
BEGIN
	SELECT [Volunteer].[FirstName], [Volunteer].[LastName], [Volunteer].[VolunteerID]
	FROM [Volunteer]
	JOIN [VolunteerEventLine] ON [Volunteer].[VolunteerID] = [VolunteerEventLine].[VolunteerID]
	WHERE [VolunteerEventLine].[EventID] = @EventID
  
END

/*
	<summary>
    Creator: Liam Easton
    Created: 02/13/2024
    Summary: initial creation of the sp_select_all_employees stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/13/2024
    What Was Changed: initial creation of the sp_select_all_employees stored procedure
    </summary>
*/
print '' print '*** creating sp_select_all_employees ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_employees]
AS	
BEGIN
		SELECT	[EmployeeID], 
		[Fname], 
		[Lname], 
		[Phone], 
		[Gender], 
		[AccountStatus],
		[ZipCode],
		[Address],
		[StartDate]
		FROM	[Employee]
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 02/15/2024
    Summary: initial creation of the sp_select_all_shifts_from_employeeID stored procedure
    Last Updated By: Liam Easton
    Last Updated: 02/15/2024
    What Was Changed: initial creation of the sp_select_all_shifts_from_employeeID stored procedure
	Last Updated By: Liam Easton
    Last Updated: 04/04/2024
    What Was Changed: fixed typo in procedure name
    </summary>
*/
print '' print '*** creating sp_select_all_shifts_from_employeeID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_shifts_from_employeeID]
(
	@EmployeeID [nvarchar](100)
)
AS	
BEGIN
		SELECT	[ShiftID], 
		[EmployeeID], 
		[StartTime], 
		[EndTime] 
		FROM	[Shift]
		WHERE @EmployeeID = [EmployeeID]
	END
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 03/02/2024
    Summary: initial creation of the sp_get_all_submitted_incident_reports stored procedure
    Last Updated By: Andrew Larson
    Last Updated: 03/02/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_get_all_submitted_incident_reports ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_submitted_incident_reports]
(
	@employeeID [nvarchar](100)
)
AS	
BEGIN
		SELECT [IncidentID], [Description], [IncidentStatus], [Reported], [ReportedBy], [Feedback], [Severity]
		FROM [Incident]
		WHERE @employeeID = [ReportedBy]
	END
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 03/18/2024
    Summary: initial creation of the sp_Remove_VolunteerFromEvents stored procedure
    Last Updated By: Andrew Larson
    Last Updated: 03/18/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_Remove_VolunteerFromEvents ***'
GO
CREATE PROCEDURE [dbo].[sp_Remove_VolunteerFromEvents]
(
	@VolunteerID	NVARCHAR(100),
	@EventID		int
)
AS	
	BEGIN
		DELETE FROM VolunteerEventLine
		WHERE VolunteerID = @VolunteerID AND EventID = @EventID
		RETURN  @@ROWCOUNT
	END
GO

/*
    Creator:            Marwa Ibrahim
    Created:            02/20/2024
    Summary:            This is the stored procedure for creating MaintenanceRequest.
    Last Updated By:    Marwa Ibrahim
    Last Updated:       02/20/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_Create_maintenance_request ***'
GO
CREATE PROCEDURE [dbo].[sp_Create_maintenance_request]
(
	
	@_roomID		int,
	@_status		[nvarchar](50),
	@_requestor     [nvarchar](50),
	@_phone         [nvarchar](50),
	@_dateCreated   [DateTime],
	@_description   [nvarchar](255)
)
AS
	BEGIN
		INSERT INTO [dbo].[MaintenanceRequest]
			([RoomID], [Status], [Requester], [Phone], [TimeCreated], [Description])
		VALUES
			(@_roomID, @_status, @_requestor, @_phone, @_dateCreated, @_description)
	END
GO	

/*
    <summary> 
    Creator:            Kirsten Stage
    Created:            03/07/2024
    Summary:            Created sp_get_maintenance_request_by_status
    Last Updated By:    Kirsten Stage
    Last Updated:       03/07/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_get_maintenance_request_by_status ***'
GO
CREATE PROCEDURE [dbo].[sp_get_maintenance_request_by_status]
(
	@Status			[nvarchar](50)
)
AS
	BEGIN
		SELECT 	[RequestID], [RoomID], [Status], [Requester], [Phone],
				[TimeCreated], [Description]
		FROM 	[MaintenanceRequest]
		WHERE	@Status = [Status]
	END
GO

/*
    <summary> 
    Creator:            Kirsten Stage
    Created:            03/07/2024
    Summary:            Created sp_update_status_to_complete
    Last Updated By:    Kirsten Stage
    Last Updated:       03/07/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_update_status_to_complete ***'
GO
CREATE PROCEDURE [dbo].[sp_update_status_to_complete]
(
	@RequestID			[int]
)
AS
	BEGIN
		UPDATE 	[MaintenanceRequest]
		SET 	[Status] 		= 'Completed'
		WHERE 	[RequestID] 	= @RequestID
	END
GO

/* 
	<summary>
	Creator:            Matthew Baccam
	Created:            03/01/2024
	Summary:            Update maintenance request for suspension
	Last Updated By:    Matthew Baccam
	Last Updated:       03/01/2024
	What Was Changed:   Initial Creation  
	</summary>
*/
print '' print '*** sp_suspend_maintenance_request***'
GO
CREATE PROCEDURE [dbo].[sp_suspend_maintenance_request](
	@RequestID [INT]
	, @NewRequestDescription [NVARCHAR](50)
	, @OldRequestDescription [NVARCHAR](50)
)
AS
	BEGIN
		UPDATE [MaintenanceRequest]
		SET [Status] = 'Suspended'
		, [Description] = @NewRequestDescription
		WHERE [RequestID] = @RequestID
		AND [Description] = @OldRequestDescription
END
GO

/*
    <summary> 
    Creator:            Darryl Shirley
    Created:            03/04/2024
    Summary:            Created sp_add_volunteer_event_line_field
    Last Updated By:    Darryl Shirley
    Last Updated:       03/04/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_add_volunteer_event_line_field ***' 
GO
CREATE PROCEDURE sp_add_volunteer_event_line_field(
	@VolunteerID 	NVARCHAR(100),
	@EventID		INT
) 
AS 
BEGIN
	INSERT INTO [dbo].[VolunteerEventLine] ([VolunteerID], [EventID])
    VALUES (@VolunteerID, @EventID)
END 
GO


/*
    <summary>
    Creator:            Darryl Shirley
    Created:            03/04/2024
    Summary:            This is the stored procedure for obtaining the 
						list of current Volunteers.
    Last Updated By:    Ibrahim Albashair
    Last Updated:       03/18/2024
    What Was Changed:   Removed '*' from SELECT field and returned all values but passwordHash
						Added an INNER JOIN to retrieve Roles
    </summary>
*/
print '' print '*** creating sp_select_all_Volunteers ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_Volunteers]
AS
	BEGIN
		SELECT	
				[Volunteer].[VolunteerID],
		        [Volunteer].[FirstName],         
		        [Volunteer].[LastName],	          
		        [Volunteer].[Phone],	          
		        [Volunteer].[Gender],	      
		        [Volunteer].[AccountStatus],	
				[Role].[RoleId],
		        [Volunteer].[RegistrationDate],
		        [Volunteer].[Address], 	      
		        [Volunteer].[ZipCode]	      
		
		FROM 	[Volunteer] 
		INNER JOIN [Role] ON [Role].[RoleID] = [Volunteer].[RoleID]
	END
GO


/*
    <summary> 
    Creator:            Darryl Shirley
    Created:            03/04/2024
    Summary:            Created sp_select_all_volunteers_assigned_field
    Last Updated By:    Darryl Shirley
    Last Updated:       03/04/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_all_volunteers_assigned_field ***' 
GO
CREATE PROCEDURE sp_select_all_volunteers_assigned_field(
	@EventID		INT
) 
AS 
BEGIN
	SELECT 
		DISTINCT [Volunteer].[VolunteerID], 
			[FirstName],                 
            [LastName],	                         
            [Phone],
			[Gender],
			[PasswordHash],
            [AccountStatus],			
            [RegistrationDate],	         
            [Address], 	                     
            [ZipCode]	           
	FROM [Volunteer]
	INNER JOIN [VolunteerEventLine]
	ON [Volunteer].[VolunteerID] = [VolunteerEventLine].[VolunteerID]
	JOIN [Event]
	ON [VolunteerEventLine].[EventID] = [Event].[EventID]
	WHERE [Event].[EventID] = @EventID
END 
GO

/*
    <summary> 
    Creator:            Abdalgader Ibrahim
    Created:            03/05/2024
    Summary:            Created sp_select_EventType_IDs, get EventTypeIDs from EventType table. 
    Last Updated By:    Abdalgader Ibrahim
    Last Updated:       03/05/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_EventType_IDs ***' 
GO
CREATE PROCEDURE sp_select_EventType_IDs
AS 
BEGIN
	SELECT
		[EventType].[EventTypeID]
	FROM
		[EventType]
END 
GO
/*
    <summary> 
    Creator:            Abdalgader Ibrahim
    Created:            03/05/2024
    Summary:            Created sp_select_Client_IDs, get ClientIDs from Client table. 
    Last Updated By:    Abdalgader Ibrahim
    Last Updated:       03/05/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_Client_IDs ***' 
GO
CREATE PROCEDURE sp_select_Client_IDs
AS 
BEGIN
	SELECT
		[Client].[clientID]
	FROM
		[Client]
END 
GO
/*
    <summary> 
    Creator:            Abdalgader Ibrahim
    Created:            03/05/2024
    Summary:            Created sp_insert_event_request, insert event request. 
    Last Updated By:    Abdalgader Ibrahim
    Last Updated:       03/05/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_insert_event_request ***' 
GO
CREATE PROCEDURE sp_insert_event_request
(
	@ClientID nvarchar(100),
	@EventTypeID nvarchar(255),
	@Information text
	
)
AS 
BEGIN
	INSERT INTO [RequestEvent]
		([ClientID],[EventTypeID],[Information])
	VALUES
		(@ClientID, @EventTypeID,@Information )
END 
GO
/*
    <summary>
    Creator: Liam Easton
    Created: 03/03/2024
    Summary: initial creation of the sp_select_all_roles stored procedure
    Last Updated By: Liam Easton
    Last Updated: 03/03/2024
    What Was Changed: initial creation of the sp_select_all_roles stored procedure
    </summary>
*/
print '' print '*** creating sp_select_all_roles ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT [RoleID],
			   [DepartmentID],
			   [Description],
			   [PositionsAvailable]
		FROM   [Role]
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 03/04/2024
    Summary: initial creation of the sp_select_specific_roles stored procedure
    Last Updated By: Liam Easton
    Last Updated: 03/04/2024
    What Was Changed: initial creation of the sp_select_specific_roles stored procedure
    </summary>
*/
print '' print '*** creating sp_select_specific_roles ***'
GO
CREATE PROCEDURE [dbo].[sp_select_specific_roles]
(
    @RoleID NVARCHAR(50) 
)
AS
BEGIN
    SELECT  [Employee].[EmployeeID], 
            [EmployeeRole].[RoleID],
            [Employee].[Fname], 
            [Employee].[Lname], 
            [Employee].[Phone], 
            [Employee].[Gender], 
            [Employee].[AccountStatus],
            [Employee].[ZipCode],
            [Employee].[Address],
            [Employee].[StartDate]
    FROM    [Employee] Employee
    INNER JOIN [EmployeeRole] EmployeeRole ON EmployeeRole.[EmployeeID] = Employee.[EmployeeID]
    WHERE   EmployeeRole.[RoleID] = @RoleID
END
GO

/*
    <summary> 
    Creator:            Darryl Shirley
    Created:            03/04/2024
    Summary:            Created sp_select_all_volunteers_not_assigned_field
    Last Updated By:    Darryl Shirley
    Last Updated:       03/04/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
print '' print '*** creating sp_select_all_volunteers_not_assigned_field ***' 
GO
CREATE PROCEDURE sp_select_all_volunteers_not_assigned_field(
	@EventID		INT
) 
AS 
BEGIN
	WITH [assignedVolunteers] AS (
		SELECT 
			DISTINCT [Volunteer].[VolunteerID], 
			[FirstName],                 
            [LastName],	                         
            [Phone],
			[Gender],
			[PasswordHash],
            [AccountStatus],
			[RoleID],
            [RegistrationDate],	         
            [Address], 	                     
            [ZipCode]			
		FROM [Volunteer]
		INNER JOIN [VolunteerEventLine]
		ON [Volunteer].[VolunteerID] = [VolunteerEventLine].[VolunteerID]
		JOIN [Event]
		ON [VolunteerEventLine].[EventID] = [Event].[EventID]
		WHERE [Event].[EventID] = @EventID
	)

	SELECT  
		*
	FROM [Volunteer]
	WHERE NOT EXISTS (
		SELECT 1
		FROM [assignedVolunteers]
		WHERE [Volunteer].[VolunteerID] = [assignedVolunteers].[VolunteerID]
	)
END 
GO

/*
    <summary> 
    Creator:            Mitchell Stirmel
    Created:            03/04/2024
    Summary:            Deletes a vendor given its vendorID
    Last Updated By:    Mitchell Stirmel
    Last Updated:       03/04/2024
    What Was Changed:   Initial Creation 
    </summary>
*/
GO
print '' print '*** creating sp_delete_vendor_by_vendorid ***' 
GO
CREATE PROCEDURE sp_delete_vendor_by_vendorid(
	@VendorID	INT
) 
AS 
BEGIN
	DELETE FROM [Vendor]
	WHERE [Vendor].[VendorID] = @VendorID
END 
GO

/*
    <summary>
    Creator: Marwa Ibrahim
    Created: 02/15/2024
    Summary: initial creation of the sp_insert_reminder stored procedure
    Last Updated By: Marwa Ibrahim
    Last Updated: 02/15/2024
    What Was Changed: initial creation of the sp_insert_reminder stored procedure
    </summary>
*/

print '' print '*** creating sp_insert_reminder ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_reminder]
(
	@EmailTo			[nvarchar](100),
	@EmailFrom              [nvarchar](100),
	@Title			    [nvarchar](50) ,
    @Message                  [text]   ,
    @Frequency          [nvarchar](25) ,
    @Date                        [Date],
    @Read                       [bit]  ,
    @Deactivate                 [bit] 

)
AS	


BEGIN
		INSERT INTO [dbo].[Reminder]
			([EmailTo], [EmailFrom], [Title], [Message], [Frequency], [Date], [Read], [Deactivate])
		VALUES
			(@EmailTo, @EmailFrom, @Title, @Message, @Frequency, @Date, @Read, @Deactivate)
	END
GO

/*
    <summary> 
    Creator:            Suliman Suliman 
    Created:            03/02/2024
    Summary:            Deactivate a Room
    Last Updated By:    
    Last Updated:      
    What Was Changed:  
    </summary>
*/
GO
DROP PROCEDURE IF EXISTS [sp_deactivate_room]
GO
PRINT '' PRINT '*** Creating sp_deactivate_room ***'
GO
CREATE PROCEDURE [sp_deactivate_room]
(
		@RoomID          [int]
		
)
AS
BEGIN
	UPDATE[Room]
	SET [Status] = "Deactivated"
	WHERE @RoomID = [RoomID] 
	SELECT @@ROWCOUNT
END
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            02/05/2024
Summary:            Create stored procedure sp_select_item_by_itemId
Last Updated By:    Andres Garcia
Last Updated:       02/05/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print '*** creating sp_select_item_by_itemId ***'
GO
CREATE PROCEDURE [dbo].[sp_select_item_by_itemId]
(
	@ItemID [int]
)
AS
    BEGIN
        SELECT [ItemID],[ItemName],[ItemDescription],[QtyOnHand],[NormalStockQty],[ReorderPoint],[OnOrder]
        FROM   [Item]
		WHERE ItemID = @ItemID
    END
GO

	
/* 
<summary>
Creator:            Andres Garcia
Created:            02/06/2024
Summary:            Create stored procedure sp_edit_item_by_itemId
Last Updated By:    Andres Garcia
Last Updated:       02/06/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print '*** creating sp_edit_item_by_itemId ***'
GO
CREATE PROCEDURE [dbo].[sp_edit_item_by_itemId]
(
	@ItemID	  [int],	
	@ItemName [nvarchar] (50),
	@ItemDescription [nvarchar] (255),
	@QtyOnHand [int],
	@NormalStockQty [int],
	@ReorderPoint [int],
	@OnOrder [int]
	
)
AS
    BEGIN
        UPDATE Item
		SET ItemName = @ItemName,
			ItemDescription = @ItemDescription,
			QtyOnHand = @QtyOnHand,
			NormalStockQty = @NormalStockQty,
			ReorderPoint = @ReorderPoint,
			OnOrder = @OnOrder
        FROM   [Item]
		WHERE ItemID = @ItemID
    END
GO
	
/* 
<summary>
Creator:            Andres Garcia
Created:            02/13/2024
Summary:            Create stored procedure sp_schedule_repair
Last Updated By:    Andres Garcia
Last Updated:       02/13/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print '*** creating sp_schedule_repair ***'
GO
CREATE PROCEDURE [dbo].[sp_schedule_repair]
(
	@RequestID	  [int],	
	@EmployeeID [nvarchar] (100),
	@RepairDate [Date]
	
)
AS
    BEGIN
        INSERT INTO [dbo].[Repair]
		([RequestID],[EmployeeID],[RepairDate],[Status])
        VALUES
		(@RequestID, @EmployeeID, @RepairDate,'pending')
    END
GO

/* 
<summary>
Creator:            Andres Garcia
Created:            02/22/2024
Summary:            Create stored procedure sp_delete_inventory
Last Updated By:    Andres Garcia
Last Updated:       02/22/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print '*** creating sp_delete_inventory ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_inventory]
AS
    BEGIN
		UPDATE Item
		SET 
			QtyOnHand = 0
    END
GO

/* 
<summary>
Creator:            Seth Nerney
Created:            02/22/2024
Summary:            Create sp_get_all_appointments Stored Procedure
Last Updated By:    Seth Nerney
Last Updated:       02/22/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating sp_get_all_appointments ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_appointments]
AS
	BEGIN
		SELECT [ClientID], [LocationName], [AppointmentStartTime], [AppointmentEndTime], [AppointmentType], [AppointmentID]
		FROM [Appointment]
		INNER JOIN [Location] 
		ON [Appointment].[LocationID]=[Location].[LocationID]
	WHERE status =1
	END
GO

/* 
<summary>
Creator:            Ethan McElree
Created:            03/25/2024
Summary:            Create sp_create_appointment Stored Procedure
Last Updated By:    Ethan McElree
Last Updated:       03/25/2024
What Was Changed:   Initial Creation  
</summary>
*/
print '' print '*** creating sp_create_appointment ***'
GO
CREATE PROCEDURE [dbo].[sp_create_appointment]
(
	@ClientID 				[nvarchar](100),
	@LocationID 			[int], 
	@AppointmentStartTime 	[DateTime], 
	@AppointmentEndTime 	[DateTime], 
	@AppointmentType 		[nvarchar](25), 
	@Status 				[bit], 
	@EmployeeID 			[nvarchar](100)
)
AS
	BEGIN
		INSERT INTO [dbo].[Appointment]
		([ClientID], [LocationID], [AppointmentStartTime], [AppointmentEndTime], [AppointmentType], [Status], [EmployeeID])
		VALUES
		(@ClientID, @LocationID, @AppointmentStartTime, @AppointmentEndTime, @AppointmentType, @Status, @EmployeeID)
	END
GO

/* 
<summary>
Creator:            Miyada Abas
Created:            03/08/2024
Summary:            Create stored procedure sp_SelectAllHouseKeepingTask
Last Updated By:    Miyada Abas
Last Updated:       03/08/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print'*** creating sp_SelectAllHouseKeepingTask ***'
GO
CREATE PROCEDURE [dbo].[sp_SelectAllHouseKeepingTask]
AS
BEGIN
    SELECT 
        [TaskID], [RoomID], [EmployeeID], [Type], [Description], [Date],
        [Status]
    FROM [HousekeepingTask]
END
GO
   
/*
    <summary>
    Creator: Donald Winchester
    Created: 03/01/2024
    Summary: initial creation of the sp_confirm_maintenance_request stored procedure
    Last Updated By: Donald Winchester
    Last Updated: 03/01/2024
    What Was Changed: initial creation of the sp_confirm_maintenance_request stored procedure
    </summary>
*/

print '' print '*** creating sp_confirm_maintenance_request ***'
GO
CREATE PROCEDURE [dbo].[sp_confirm_maintenance_request]
(
	@RequestID [int],
	@Status [nvarchar](50)
)
AS
BEGIN 
SET @Status = 'In Progress';
    
    UPDATE [dbo].[MaintenanceRequest]
    SET [Status] = @Status
    WHERE [Status] = "Pending"
	AND [RequestID] = @RequestID
END
GO

   
/*
    <summary>
    Creator: Miyada Abas
    Created: 03/01/2024
    Summary: initial creation of the sp_confirm_maintenance_request stored procedure
    Last Updated By: Donald Winchester
    Last Updated: 03/01/2024
    What Was Changed: initial creation of the sp_confirm_maintenance_request stored procedure
    </summary>
*/
print '' print '*** creating sp_Remove_appointment ***'
GO
CREATE PROCEDURE [dbo].[sp_Remove_appointment]
(
	@ClientID [nvarchar] (100),
	
	@AppoitmentType [nvarchar] (25),
	@AppoitmentStartTime [datetime],
	@AppoitmentEndTime [datetime]
)
AS
BEGIN 
    UPDATE [dbo].[Appointment]
	Set [Status] =0

    WHERE [ClientID] = @ClientID
	
	AND [AppointmentType] = @AppoitmentType
	AND [AppointmentStartTime] = @AppoitmentStartTime
	AND [AppointmentEndTime] = @AppoitmentEndTime
END
GO

 
/*
    <summary>
    Creator: Mitchell Stirmel
    Created: 03/20/2024
    Summary: This stored procedure selects all details from the VolunteerApplication table for viewing.
    Last Updated By: Darryl Shirley
    Last Updated: 03/27/2024
    What Was Changed: Added a ReasonForStatus field
    </summary>
*/
print '' print '*** creating sp_select_volunteer_application ***'
GO
CREATE PROC [dbo].[sp_select_volunteer_application]
AS 
BEGIN 
	SELECT [ApplicationID], [ApplicantID], [Status], [DateApplied], [ReasonForStatus]
	FROM [VolunteerApplication]
END
GO

/*
	<summary> 
	Creator:            Kirsten Stage
	Created:            03/29/2024
	Summary:            Create sp_get_event_meals stored procedure
	Last Updated By:    Kirsten Stage
	Last Updated:       03/29/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_get_event_meals ***'
GO
CREATE PROCEDURE [dbo].[sp_get_event_meals] (
	@EventName			[nvarchar](100)
)
AS
	BEGIN
		SELECT 	[Event].[EventName], [EventSchedule].[EventDay], 
				[EventSchedule].[StartTime], [Food], [Beverages]
		FROM [EventMeal]
		FULL OUTER JOIN [Event] ON [Event].[EventID] = [EventMeal].[EventID]
		FULL OUTER JOIN [EventSchedule] 
			ON [EventSchedule].[EventID] = COALESCE([EventMeal].[EventID], [Event].[EventID])
		WHERE [Event].[EventName] = @EventName
	END
GO

/* 
	<summary>
	Creator:            Kirsten Stage
	Created:            04/01/2024
	Summary:            Creation of sp_select_all_event_names
	Last Updated By:    Kirsten Stage
	Last Updated:       04/01/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_select_all_event_names ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_event_names]
AS
	BEGIN
		SELECT 	[EventName]
		FROM 	[Event]
	END
GO


print '' print '*** creating sp_select_volunteer_application_by_id'
GO 
CREATE PROCEDURE [dbo].[sp_select_volunteer_application_by_id] (
	@ApplicationID 		[int]
)
AS 
BEGIN
	SELECT [Applicant].[GivenName], [Applicant].[FamilyName], [Applicant].[PhoneNumber], [Applicant].[Email],
			[VolunteerApplication].[ApplicationReason], [VolunteerApplication].[HoursDesired], [VolunteerApplication].[VolunteerConcerns]
	FROM [VolunteerApplication]
	INNER JOIN [Applicant]
	ON [Applicant].[ApplicantID] = [VolunteerApplication].[ApplicantID]
	WHERE [VolunteerApplication].[ApplicationID] = @ApplicationID
END

/*
	<summary> 
	Creator:            Sagan DeWald
	Created:            03/19/2024
	Summary:            Create sp_add_client_priority stored procedure.
	Last Updated By:    Sagan DeWald
	Last Updated:       03/19/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_add_client_priority ***'
GO
CREATE PROCEDURE [dbo].[sp_add_client_priority] (
	@ClientID			[nvarchar](100),
	@BasePriority		[int],
	@Deductions			[int],
	@NotableConvictions	[nvarchar](max),
	@OtherHousingSituation	[nvarchar](max)
)
AS
	BEGIN
		INSERT INTO [dbo].[ClientPriority]
			([Client], [BasePriority], [Deductions], [NotableConvictions], [OtherHousingSituation])
		VALUES
			(@ClientID, @BasePriority, @Deductions, @NotableConvictions, @OtherHousingSituation);
	END
GO

/*
	<summary> 
	Creator:            Sagan DeWald
	Created:            03/19/2024
	Summary:            Create sp_get_all_client_priorities stored procedure.
	Last Updated By:    Sagan DeWald
	Last Updated:       03/19/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_get_all_client_priorities ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_client_priorities]
AS
	BEGIN
		SELECT
			[ClientPriorityID], [Client], [BasePriority], [Deductions], [NotableConvictions], [OtherHousingSituation]
		FROM
			[dbo].[ClientPriority];
	END
GO

/*
	<summary> 
	Creator:            Sagan DeWald
	Created:            03/19/2024
	Summary:            Create sp_update_client_priority stored procedure.
	Last Updated By:    Sagan DeWald
	Last Updated:       03/19/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_update_client_priority ***'
GO
CREATE PROCEDURE [dbo].[sp_update_client_priority] (
	@ClientPriorityID	[int],
	@BasePriority		[int],
	@Deductions			[int],
	@NotableConvictions	[nvarchar](max),
	@OtherHousingSituation [nvarchar](max)
)
AS
	BEGIN
		UPDATE 
			[dbo].[ClientPriority]
		SET
			[BasePriority] = @BasePriority,
			[Deductions] = @Deductions,
			[NotableConvictions] = @NotableConvictions,
			[OtherHousingSituation] = @OtherHousingSituation
		WHERE
			[ClientPriorityID] = @ClientPriorityID;
	END
GO

/*
    <summary>
    Creator: Miyada Abas
    Created: 03/26/2024
    Summary: This stored procedure for get all room status 
    Last Updated By: Miyada Abas
	Last Updated: 03/26/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_all_room_status stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_room_status]
AS BEGIN
Select Status
FROM Room Status
END
GO
   
/*
    <summary>
    Creator: Abdalgader Ibrahim
    Created: 03/26/2024
    Summary: This stored procedure selects all Schedule details from the Schedule table for viewing.
    Last Updated By: Abdalgader Ibrahim
    Last Updated: 03/26/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_select_all_schedules ***'
GO
CREATE PROC [dbo].[sp_select_all_schedules]
AS 
BEGIN 
	SELECT [ScheduleID], [ScheduleMonth],[ScheduleWeek], [ScheduleYear], [ScheduleStartDate], [ScheduleEndDate]
	FROM [Schedule]
	ORDER BY [ScheduleStartDate] ASC 
END
GO

/* 
Creator:            Abdalgader Ibrahim
Created:            03/07/2024
Summary:            Stored procedure for selecting Schedule by the Schedule ID.
Last Updated By:    Abdalgader Ibrahim
Last Updated:       02/06/2024
What Was Changed:   Initial creation 
*/
print '' print '*** creating sp_select_shift_by_schedule_id ***'
GO
CREATE PROCEDURE [dbo].[sp_select_shift_by_schedule_id]
    @ScheduleID INT
AS
BEGIN
    SELECT [ShiftID],[Employee].[Fname],[Employee].[Lname],[StartTime],[EndTime],
	[Schedule].[ScheduleStartDate],[Schedule].[ScheduleEndDate]
    FROM [dbo].[Shift] 
	INNER JOIN [dbo].[Employee] ON [Employee].[EmployeeID] = [Shift].[EmployeeID]
	INNER JOIN [dbo].[Schedule] ON [Schedule].[ScheduleID] = [Shift].[ScheduleID]
    WHERE [Shift].[ScheduleID] = @ScheduleID;
END
GO
/*
    <summary>
    Creator: Darryl Shirley
    Created: 03/22/2024
    Summary: initial creation of the sp_select_all_applicants stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 03/22/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_select_all_applicants ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_applicants]
AS
	BEGIN
		SELECT *
		FROM   [Applicant]
	END
GO

/*
    <summary>
    Creator: Darryl Shirley
    Created: 03/22/2024
    Summary: initial creation of the sp_select_all_VolunteerApplications stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 03/22/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_select_all_VolunteerApplications ***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_VolunteerApplications]
AS
	BEGIN
		SELECT 
			[VolunteerApplication].[ApplicationID],
			[Applicant].[ApplicantID],
			[Applicant].[GivenName],
			[Applicant].[FamilyName],
			[Applicant].[PhoneNumber],
			[Applicant].[Email],
			[VolunteerApplication].[Status],
			[VolunteerApplication].[DateApplied],
			[VolunteerApplication].[ReasonForStatus]
		FROM   [Applicant]
		JOIN [VolunteerApplication]
		ON [Applicant].[ApplicantID] = [VolunteerApplication].[ApplicantID] 
	END
GO

/*
    <summary>
    Creator: Darryl Shirley
    Created: 03/27/2024
    Summary: initial creation of the sp_update_VolunteerApplicationStatus stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 03/27/2024
    What Was Changed: initial creation 
    </summary>
*/

print '' print '*** creating sp_update_VolunteerApplicationStatus ***'
GO
CREATE PROCEDURE [dbo].[sp_update_VolunteerApplicationStatus]
(
	@ApplicationID 			[int],
	@Status 				[nvarchar](50),
	@ReasonForStatus 		[nvarchar](255)
)
AS
BEGIN 
    
    UPDATE [dbo].[VolunteerApplication]
    SET [Status] = @Status,
		[ReasonForStatus] = @ReasonForStatus
    WHERE [ApplicationID] = @ApplicationID
END
GO

/*
Creator:            Marwa Ibrahim
Created:            03/6/2024
Summary:             sp_create_EventParticipants
Last Updated By:    Marwa Ibrahim
Last Updated:       
What Was Changed:   
</summary>
*/
print '' print '*** creating sp_create_EventParticipants ***'
GO
CREATE PROC [dbo].[sp_create_EventParticipants]
(
	@EventID		        [int]       ,
	@ParticipantName	[nvarchar](255) ,
	@Email			    [nvarchar](255)  , 
	@RegistrationDate    [DATE] 
)
AS
	BEGIN
		INSERT INTO [dbo].[EventParticipants]
			([EventID], [ParticipantName], [Email],[RegistrationDate])
		VALUES
			(@EventID, @ParticipantName, @Email	,@RegistrationDate)
	END
GO

/*
    <summary>
    Creator: Liam Easton
    Created: 04/03/2024
    Summary: initial creation of the sp_view_all_transportation_orders stored procedure
    Last Updated By: Liam Easton
    Last Updated: 04/03/2024
*/
print '' print '*** creating sp_view_all_transportation_orders ***'
GO
CREATE PROCEDURE [dbo].[sp_view_all_transportation_orders]
AS
	BEGIN
		SELECT 
			[TransportItem].[DayPosted],
			[TransportItem].[DayToPickUp],
			[TransportItem].[DayDroppedOff],
			[TransportItem].[AssignedDriver],
			[TransportItem].[Fulfilled],
			[TransportLine].[LineItemAmount],
			/* Vendor */
			[Vendor].[VendorName],
			/* Item */
			[Item].[ItemName],
			/* Location */
			[Location].[LocationName],
			[Location].[Address],
			[Location].[City],	      
			[Location].[State],
			[Location].[ZipCode]	         
		FROM   
			[TransportItem]
		JOIN 
			[TransportLine] ON [TransportItem].[TransportItemID] = [TransportLine].[TransportItemID]
		JOIN 
			[Vendor] ON [TransportLine].[VendorID] = [Vendor].[VendorID]
		JOIN 
			[Location] ON [TransportItem].[LocationID] = [Location].[LocationID]
		JOIN 
        	[Item] ON [TransportLine].[ItemID] = [Item].[ItemID]
	END
GO

/*
    <summary>
    Creator: Marwa Ibrahim
    Created: 01/23/2024
    Summary: initial creation of the sp_update_Event stored procedure
    Last Updated By: Marwa Ibrahim
    Last Updated: 01/23/2024
    What Was Changed: initial creation 
    </summary>
*/
print '' print '*** sp_Update_Event***'
GO
CREATE PROC sp_Update_Event(@EventID int, @EventName NVARCHAR(100), @Description NVARCHAR(100))
AS 
	BEGIN
		UPDATE Event
		SET EventName = @EventName, Description = @Description
		WHERE EventID = @EventID;
	END
GO


/*
    <summary>
    Creator: Darryl Shirley
    Created: 04/04/2024
    Summary: initial creation of the sp_select_volunteer_skills_by_volunteer_ID stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 04/04/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_select_volunteer_skills_by_volunteer_ID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_volunteer_skills_by_volunteer_ID]
(
	@VolunteerID		[nvarchar](100)
)
AS
	BEGIN
		SELECT 
			[Skills].[SkillID],
			[Skills].[SkillName]
			
		FROM   [Volunteer]
		JOIN [VolunteerSkills]
		ON [Volunteer].[VolunteerID] = [VolunteerSkills].[VolunteerID]
		JOIN [Skills]
		ON [VolunteerSkills].[SkillID] = [Skills].[SkillID]
		WHERE [Volunteer].[VolunteerID] = @VolunteerID 
	END
GO


/*
    <summary>
    Creator: Darryl Shirley
    Created: 04/04/2024
    Summary: initial creation of the sp_select_all_Volunteer_Skills_not_assigned stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 04/04/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_select_all_Volunteer_Skills_not_assigned***'
GO
CREATE PROCEDURE [dbo].[sp_select_all_Volunteer_Skills_not_assigned]
(
	@VolunteerID		[nvarchar](100)
)
AS
	BEGIN
	with [assignedSkills] AS
	(
		SELECT	
			[Skills].[SkillID],
			[Skills].[SkillName]
			
		FROM   [VolunteerSkills]
		JOIN [Skills]
		ON [VolunteerSkills].[SkillID] = [Skills].[SkillID]
		WHERE [VolunteerSkills].[VolunteerID] = @VolunteerID 
	)
	SELECT  
		*
	FROM [Skills]
	WHERE NOT EXISTS (
		SELECT 1
		FROM [assignedSkills]
		WHERE [Skills].[SkillID] = [assignedSkills].[SkillID]
	)
	END
GO


/*
    <summary>
    Creator: Darryl Shirley
    Created: 04/04/2024
    Summary: initial creation of the sp_insert_Volunteer_Skill stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 04/04/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_insert_Volunteer_Skill***'
GO
CREATE PROCEDURE [dbo].[sp_insert_Volunteer_Skill]
(
	@VolunteerID		[nvarchar](100),
	@SkillID			[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[VolunteerSkills]
			([VolunteerID], [SkillID])
		VALUES
			(@VolunteerID, @SkillID)
	END
GO

/*
    <summary>
    Creator: Darryl Shirley
    Created: 04/04/2024
    Summary: initial creation of the sp_delete_Volunteer_Skill stored procedure
    Last Updated By: Darryl Shirley
    Last Updated: 04/04/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_delete_Volunteer_Skill***'
GO
CREATE PROCEDURE [dbo].[sp_delete_Volunteer_Skill]
(
	@VolunteerID		[nvarchar](100),
	@SkillID			[int]
)
AS
	BEGIN
		DELETE FROM [dbo].[VolunteerSkills]
		WHERE [VolunteerID] = @VolunteerID
		AND [SkillID] = @SkillID
	END
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 03/31/2024
    Summary: initial creation of the sp_update_volunteer stored procedure
    Last Updated By: Andrew Larson
    Last Updated: 03/31/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_update_volunteer ***'
GO
CREATE PROCEDURE [dbo].[sp_update_volunteer]
(
	@VolunteerID	NVARCHAR(100),
	@NewFname		NVARCHAR(25),
	@NewLname		NVARCHAR(25),
	@NewPhone		NVARCHAR(15),
	@NewGender		BIT,
	@NewAddress		NVARCHAR(50),
	@NewZipCode		INT
)
AS	
	BEGIN
		UPDATE	[Volunteer]
		SET 	[Firstname] 	= @NewFname,
				[Lastname] 	= @NewLname,
				[Phone] 	= @NewPhone,
				[Gender] 	= @NewGender,
				[Address] 	= @NewAddress,
				[ZipCode] 	= @NewZipCode
		WHERE	[VolunteerID] = @VolunteerID
	END
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 04/07/2024
    Summary: initial creation of the sp_view_confiscated_items stored procedure
    Last Updated By: Andrew Larson
    Last Updated: 04/07/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_view_confiscated_items ***'
GO
CREATE PROCEDURE [dbo].[sp_view_confiscated_items]
AS	
	BEGIN
		SELECT [LogConfiscatedItemsID], [ItemsConfiscated], [ConfiscationDate], [ReasonForConfiscation]
		FROM [LogConfiscatedItem]
	END
GO

/*
    <summary>
    Creator: Andrew Larson
    Created: 04/15/2024
    Summary: initial creation of the sp_add_confiscated_item stored procedure
    Last Updated By: Andrew Larson
    Last Updated: 04/15/2024
    What Was Changed: Initial creation
    </summary>
*/
print '' print '*** creating sp_add_confiscated_item ***'
GO
CREATE PROCEDURE [dbo].[sp_add_confiscated_item] (
	@ItemsConfiscated	[nvarchar](100),
	@ReasonForConfiscation [text]
)
AS
	BEGIN
		INSERT INTO [dbo].[LogConfiscatedItem]
			([ItemsConfiscated], [ConfiscationDate], [ReasonForConfiscation])
		VALUES
			(@ItemsConfiscated, CONVERT(date, GETDATE()), @ReasonForConfiscation);
	END
GO

/* 
<summary>
Creator:            Marwa Ibrahim
Created:            03/27/2024
Summary:            Create sp_Update_Client_Password Stored Procedure
Last Updated By:    Marwa Ibrahim
Last Updated:       03/27/2024
What Was Changed:   Initial Creation  
</summary>
*/

print '' print '*** Update sp_Update_Client_Password ***'
GO
CREATE PROC [dbo].[sp_Update_Client_Password]
(
  @PasswordHash [nvarchar] (256),
  @ClientID   [nvarchar] (100)
)
AS 
BEGIN 
	Update [Client]
	Set [PasswordHash] = @PasswordHash
	Where [ClientID] = @ClientID
END
GO

/* 
<summary>
Creator:            Kirsten Stage
Created:            04/11/2024
Summary:            Create sp_create_fundraising_event
Last Updated By:    Kirsten Stage
Last Updated:       04/11/2024
What Was Changed:   Initial Creation
</summary>
*/
print '' print '*** creating sp_create_fundraising_event ***'
GO
CREATE PROCEDURE [dbo].[sp_create_fundraising_event]
(
	@EventName				[nvarchar](100),
	@FundraisingGoal		[money],
	@EventAddress			[nvarchar](100),
	@EventDate				[datetime],
	@StartTime				[datetime],
	@EndTime				[datetime],
	@EventDescription 		[text]
)
AS
	BEGIN
		INSERT INTO [dbo].[FundraisingEvent]
		([EventName], [FundraisingGoal], [EventAddress], [EventDate], [StartTime], [EndTime], [EventDescription])
		VALUES
		(@EventName, @FundraisingGoal, @EventAddress, @EventDate, @StartTime, @EndTime, @EventDescription)
	END
GO

/*
	<summary>
	Creator:            Kirsten Stage
	Created:            04/18/2024
	Summary:            Creation of sp_get_fundraising_events
	Last Updated By:    Kirsten Stage
	Last Updated:       04/18/2024
	What Was Changed:   Initial Creation
	</summary>
*/
print '' print '*** creating sp_get_fundraising_events ***'
GO
CREATE PROCEDURE [dbo].[sp_get_fundraising_events]
AS
	BEGIN
		SELECT 	[FundraisingID], [EventName], [FundraisingGoal], [EventAddress],
				[EventDate], [StartTime], [EndTime], [EventDescription]
		FROM 	[FundraisingEvent]
	END
GO

/*
    <summary>
    Creator: Ibrahim Albashair
    Created: 03/20/2024
    Summary: sp to select a volunteer using userID
    Last Updated By: Ibrahim Albashair
    Last Updated: 03/20/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_select_volunteer_by_ID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_volunteer_by_ID]
(
	@VolunteerID 		[nvarchar] (100)
)
AS
	BEGIN
		SELECT 
			[VolunteerID],
			[FirstName],         
			[LastName],	       
			[Phone],	       
			[Gender],	      
			[AccountStatus],	
			[RoleId],
			[RegistrationDate],
			[Address], 	      
			[ZipCode]	
		FROM [Volunteer]
		WHERE @VolunteerID = [VolunteerID]
	END
GO


/*
    <summary>
    Creator: Ibrahim Albashair
    Created: 03/20/2024
    Summary: sp to update Volunteer
    Last Updated By: Ibrahim Albashair
    Last Updated: 03/20/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_update_volunteer_details***'
GO
CREATE PROCEDURE [dbo].[sp_update_volunteer_details]
(
	@UserID						[nvarchar] (100),
	
	@NewFirstName				[nvarchar] (25),
	@NewLastName				[nvarchar] (25),
	@NewPhone					[nvarchar] (15),
	@NewAddress					[nvarchar] (50),
	@NewGender					 bit,
	@NewAccountStatus			 bit,
	@NewZipCode					 int,
	@NewRegistrationDate		 DATETIME	
)
AS
	BEGIN
		UPDATE [Volunteer]
		SET 
			[FirstName] = @NewFirstName ,
			[LastName] = @NewLastName ,
			[Phone] = @NewPhone,
			[Address] = @NewAddress,
			[AccountStatus] = @NewAccountStatus,
			[ZipCode] = @NewZipCode,
			[Gender] = @NewGender,
			[RegistrationDate] = @NewRegistrationDate
		WHERE 
		@UserID = [VolunteerID]			
	END
GO

/*
    <summary>
    Creator: Suliman
    Created: 03/20/2024
    Summary: This stored procedure change status to 1.
    Last Updated By: Suliman
    Last Updated: 03/26/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_accepting_volunteer_application ***'
GO
CREATE PROC [dbo].[sp_accepting_volunteer_application]
(@ApplicationID INT, @status [nvarchar] (50))
AS 
	BEGIN 
		UPDATE  [VolunteerApplication]
		SET [Status] = @status
		WHERE [ApplicationID] = @ApplicationID
	END
GO

/* 
	<summary>
	Creator:            Liam Easton
	Created:            04/18/2024
	Summary:            initial Creation
	</summary>
*/
print '' print '*** creating sp_select_event_by_EventID ***'
GO
CREATE PROCEDURE [dbo].[sp_select_event_by_EventID]
(
	@EventID			[int]
)
AS
	BEGIN
		SELECT [EventID],
			   [EventName],
			   [Description],
			   [VolunteersNeeded]
		FROM [Event]
		WHERE [EventID] = @EventID
	END
GO

/*
    <summary>
    Creator: Donald Winchester
    Created: 04/15/2024
    Summary: This stored procedure gets all membership applications.
    Last Updated By: Donald Winchester
    Last Updated: 04/15/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_get_membership_applications ***'
GO
CREATE PROC [dbo].[sp_get_membership_applications]
AS 
BEGIN 
	SELECT [FirstName], [LastName], [DateOfBirth], [Sex], [SSN], [PhoneNumber], [EmailAddress], [Status]
	FROM [MembershipApplications]
END
GO

/*
    <summary>
    Creator:            Donald Winchester
    Created:            04/19/2024
    Summary:            Volunteer Signup SP
    Last Updated By:    Donald Winchester
    Creator: Darryl Shirley
    Created: 04/17/2024
    Summary: This stored procedure gets the specific volunteer questionnaire .
    Last Updated By: Darryl Shirley
    Last Updated: 04/17/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** sp_get_volunteer_questionnaire_by_volunteer_ID***'
GO
CREATE PROCEDURE [dbo].[sp_get_volunteer_questionnaire_by_volunteer_ID]
(
	@VolunteerID	[nvarchar](100)
)
AS 
BEGIN 
	SELECT 
		[VolunteerID], 
		[SkillsList], 
		[Vehicles], 
		[PriorExperience], 
		[StudentCheck], 
		[SchoolName], 
		[GroupWork]
	FROM [Volunteer_Questionnaire]
	WHERE [VolunteerID] = @VolunteerID
END
GO

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure for viewing visits
    Last Updated By:    Ibrahim Albashair
    Last Updated:       02/10/2024
    What Was Changed:   Initial Creation
    </summary>
*/

print '' print '**** creating sp_view_all_visits ****'
GO
CREATE PROCEDURE [dbo].[sp_view_all_visits]
AS
	BEGIN	
        SELECT [VisitID], [FirstName], [LastName], [CheckIn], [CheckOut], [VisitReason], [Status]
		FROM Visit						
	END
GO 

/* 
<summary>
Creator:            Darryl Shirley
Created:            04/17/2024
Summary:            Create sp_create_volunteer_questionnaire
Last Updated By:    Darryl Shirley
Last Updated:       04/17/2024
What Was Changed:   Initial Creation
</summary>
*/
print '' print '*** creating sp_create_volunteer_questionnaire ***'
GO
CREATE PROCEDURE [dbo].[sp_create_volunteer_questionnaire]
(
	@VolunteerID				[nvarchar](100),
	@SkillList					[nvarchar](100),
	@Vehicles					[nvarchar](100),
	@PriorExperience			[BIT],
	@StudentCheck				[BIT],
	@SchoolName					[nvarchar](50),
	@GroupWork					[BIT]
)
AS
	BEGIN
		INSERT INTO [dbo].[Volunteer_Questionnaire]
		([VolunteerID], [SkillsList], [Vehicles], [PriorExperience], [StudentCheck], [SchoolName], [GroupWork])
		VALUES
		(@VolunteerID, @SkillList, @Vehicles, @PriorExperience, @StudentCheck, @SchoolName, @GroupWork)
		
	END
GO

/*
    <summary>
    Creator: Darryl Shirley
    Created: 04/17/2024
    Summary: This stored procedure gets all volunteer questionnaires.
    Last Updated By: Darryl Shirley
    Last Updated: 04/17/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** sp_get_all_volunteer_questionnaires***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_volunteer_questionnaires]
AS 
	BEGIN 
		SELECT
			[QuestionnaireID],
			[VolunteerID], 
			[SkillsList], 
			[Vehicles], 
			[PriorExperience], 
			[StudentCheck], 
			[SchoolName], 
			[GroupWork]
		FROM [Volunteer_Questionnaire]
	END
GO

/*
    <summary>
	Creator:            Andres Garcia
	Created:            4/18/2024
	Summary:            Create stored procedure sp_add_item
	Last Updated By:    Andres Garcia
	Last Updated:       02/06/2024
	What Was Changed:   Inital Creation  
	</summary>
*/
print '' print '*** creating sp_add_item ***'
GO
CREATE PROCEDURE [dbo].[sp_add_item]
(	
	@ItemName [nvarchar] (50),
	@ItemDescription [nvarchar] (255),
	@QtyOnHand [int],
	@NormalStockQty [int],
	@ReorderPoint [int],
	@OnOrder [int]
	
)
AS
    BEGIN
        Insert INTO [dbo].[Item]
		([ItemName], [ItemDescription], [QtyOnHand], [NormalStockQty], [ReorderPoint], [OnOrder])
		VALUES
		(@ItemName, @ItemDescription, @QtyOnHand, @NormalStockQty, @ReorderPoint, @OnOrder)
    END
GO


	
/* 
<summary>
Creator:            Andres Garcia
Created:            4/18/2024
Summary:            Create stored procedure sp_delete_item_by_id
Last Updated By:    Andres Garcia
Last Updated:       02/06/2024
What Was Changed:   Inital Creation  
</summary>
*/
print '' print '*** creating sp_delete_item_by_id ***'
GO
CREATE PROCEDURE [dbo].[sp_delete_item_by_id]
(	
	@ItemID [int]
	
)
AS
    BEGIN
        DELETE FROM [dbo].[Item]
		WHERE ItemID = @ItemID
    END
GO

/*
    <summary>
    Creator: Miyada Abas
    Created: 04/04/2024
    Summary: initial creation of the sp_deactivate_client_application stored procedure
    Last Updated By: Miyada Abas
    Last Updated: 04/04/2024
    What Was Changed: initial creation 
    </summary>
*/

print '' print '*** creating sp_deactivate_client_application ***'
GO
CREATE PROCEDURE [dbo].[sp_deactivate_client_application]
(
	@UserID			[nvarchar](100),
	@FirstName			[nvarchar] (25),
	@LastName			[nvarchar] (50),
	@Gender				[bit],
	@Accomadations		[nvarchar] (256),
	@AccountStatus		[bit],
	@RegistrationDate	[date]
)
AS
	BEGIN 
		
		UPDATE [dbo].[Client]
		SET [AccountStatus] = @AccountStatus
		WHERE [ClientID] = @UserID
		AND		[FName] = @FirstName
		AND		[LName]  = @LastName
		AND		[Gender]  = 	@Gender	
		AND		[Accomodations]  = @Accomadations
		AND		[RegistrationDate]  = 	@RegistrationDate
	END
GO


/*
Creator:            Marwa Ibrahim
Created:            02/23/2024
Summary:             sp_Delete_Event
Last Updated By:    Marwa Ibrahim
Last Updated:       02/28/2024
What Was Changed:   Changed to Delete  
</summary>
*/

print '' print '*** sp_Delete_Event***'
GO
CREATE PROC sp_Delete_Event(@EventID int)
AS BEGIN
    Update [Event]
    Set [Active] = 0
    WHERE [EventID] = @EventID
END
GO

/*
    <summary>
    Creator: Marwa Ibrahim
    Created: 03/14/2024
    Summary: initial creation of the sp_Cancel_Event_Signup stored procedure
    Last Updated By: Marwa Ibrahim
    Last Updated: 03/14/2024
    What Was Changed: initial creation of the sp_Cancel_Event_Signup stored procedure
    </summary>
*/
print '' print '*** sp_Cancel_Event_Signup******'
GO
CREATE PROC [sp_Cancel_Event_Signup]
(
@EventID  [int] ,
@ParticipantName [nvarchar] (255)

)
AS
BEGIN 
	Delete FROM EventParticipants
	WHERE @EventID = eventID 
	AND   @ParticipantName = ParticipantName
END
GO

/*
    <summary>
    Creator: Mitchell Stirmel
    Created: 04/20/2024
    Summary: Creates a volunteer application, and if need be, a new applicant for that application.
    Last Updated By: Mitchell Stirmel
    Last Updated: 04/20/2024
    What Was Changed: Initial Creation
    </summary>
*/
print '' print '*** creating sp_create_volunteer_application ***'
GO
CREATE PROC [dbo].[sp_create_volunteer_application]
(
	@GivenName [nvarchar](100)
,	@FamilyName[nvarchar](100)
,	@PhoneNumber[nvarchar](100)
,	@Email		[nvarchar](100)
,	@ApplicationReason [text]
,	@HoursDesired	[int]
,	@VolunteerConcerns [text]
)
AS 
BEGIN 
	DECLARE @count INT;
	DECLARE @applicantID INT;
	
	SELECT @count = COUNT([ApplicantID])
	FROM [Applicant]
	WHERE [Email] = @Email;

	IF @count <> 1
		BEGIN
		BEGIN TRY 
			BEGIN TRANSACTION
				INSERT INTO [Applicant] (
					[GivenName]
				, 	[FamilyName]
				, 	[PhoneNumber]
				, 	[Email]
				) VALUES (
					@GivenName
				,	@FamilyName
				,	@PhoneNumber
				,	@Email
				)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
		END CATCH
	END
	
	SELECT @applicantID = [ApplicantID]
	FROM [Applicant]
	WHERE [Email] = @Email
	

	INSERT INTO [VolunteerApplication]
	(
		[ApplicantID]
	,	[ApplicationReason]
	,	[HoursDesired]
	,	[VolunteerConcerns]
	) VALUES (
		@applicantID
	,	@ApplicationReason
	,	@HoursDesired
	,	@VolunteerConcerns
	)
END
GO

/*
    <summary>
    Creator:Miyada Abas
    Created: 04/11/2024
    Summary: initial creation of the sp_delete_transportation_orders stored procedure
    Last Updated By: Miyada Abas
    Last Updated: 04/11/2024
    What Was Changed: initial creation
    </summary>
*/
print '' print '*** creating sp_delete_transportation_orders***'
GO
CREATE PROCEDURE [dbo].[sp_delete_transportation_orders]
(
	@LineItemAmount		[decimal],
	@Vendor			[nvarchar] (100),
	@TransportItem		[nvarchar] (50)
	
)
AS
	BEGIN
	Declare @ItemID AS INT 
	SET  @ItemID = (Select ItemID From Item Where ItemName = @TransportItem)
	Declare @VendorID AS INT 
	SET @VendorID = (Select VendorID From Vendor Where VendorName = @Vendor)

		DELETE FROM [dbo].[TransportLine ]
		WHERE [ItemID] = @ItemID
		AND [VendorID] = @VendorID
	END
GO

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure for viewing Orders by AssignedDriver
    Last Updated By:    Ibrahim Albashair
    Last Updated:       04/19/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '*** creating sp_insert_volunteer_signup ***'
GO
CREATE PROCEDURE [dbo].[sp_insert_volunteer_signup] (
	@FirstName	                NVARCHAR(25) 
	, @LastName	                NVARCHAR(25) 
	, @Phone	                NVARCHAR(15) 
	, @Gender	            	BIT        
	, @AccountStatus	        BIT          
	, @PasswordHash				NVARCHAR(256)
	, @RoleID	            	NVARCHAR(50)
	, @VolunteerID				NVARCHAR(100)
	, @RegistrationDate	    DATETIME     
	, @Address 	            NVARCHAR(50) 
	, @ZipCode	            	INT          
)
AS
	BEGIN
		INSERT INTO [dbo].[Volunteer]
			(	  
				[FirstName]	           
				, [LastName]	           
				, [Phone]	           
				, [Gender]	         
				, [AccountStatus]	 
				, [PasswordHash]
				, [RoleID]	       
				, [VolunteerID]
				, [RegistrationDate]
				, [Address] 	       
				, [ZipCode]	       
			)
		VALUES
			(	  
				@FirstName	       
				, @LastName	       
				, @Phone	       
				, @Gender	       
				, @AccountStatus	
				, @PasswordHash
				, @RoleID	 
				, @VolunteerID
				, @RegistrationDate
				, @Address 	       
				, @ZipCode	       
		)
	END
GO

		

print '' print '**** creating sp_view_orders_by_driver ****'
GO
CREATE PROCEDURE [dbo].[sp_view_orders_by_driver]
(
	@AssignedDriver  [nvarchar](100)
)
AS
	BEGIN	
        SELECT 
		[TransportItemID],
		[ClientID],
		[LocationID],     
		[DayPosted],      
		[DayToPickUp],    
		[DayDroppedOff],  
		[AssignedDriver], 
		[Fulfilled]      
		FROM [TransportItem]	
		WHERE @AssignedDriver = [AssignedDriver]
	END
GO 

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure sp_create_transportation_order
    Last Updated By:    Ibrahim Albashair
    Last Updated:       04/19/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '**** creating sp_create_transportation_order ****'
GO
CREATE PROCEDURE [dbo].[sp_create_transportation_order]
(
	@ClientID  nvarchar(100),
	@LocationID int,
	@DayPosted  Date,
	@DayToPickUp Date,
	@DayDroppedOff Date,
	@AssignedDriver NVARCHAR(100),
	@Fulfilled bit
)
AS
	BEGIN	
	
		ALTER TABLE TransportItem 
		NOCHECK CONSTRAINT fk_TransportItemID_ClientID
		ALTER TABLE TransportItem
		NOCHECK CONSTRAINT fk_TransportItemID_LocationID
		ALTER TABLE TransportItem
		NOCHECK CONSTRAINT fk_TransportItemID_AssignedDriver
		
        INSERT INTO TransportItem		
		([ClientID], [LocationID], [DayPosted], [DayToPickUp], [DayDroppedOff], [AssignedDriver], [Fulfilled])
		VALUES
		(@ClientID, @LocationID, @DayPosted, @DayToPickUp, @DayDroppedOff, @AssignedDriver, @Fulfilled)
		
		ALTER TABLE TransportItem 
		CHECK CONSTRAINT fk_TransportItemID_ClientID
		ALTER TABLE TransportItem
		CHECK CONSTRAINT fk_TransportItemID_LocationID
		ALTER TABLE TransportItem
		CHECK CONSTRAINT fk_TransportItemID_AssignedDriver
     
	END
GO 

/*
    <summary>
    Creator:            Ibrahim Albashair
    Created:            02/10/2024
    Summary:            This is the stored procedure sp_delete_transportation_order
    Last Updated By:    Ibrahim Albashair
    Last Updated:       04/19/2024
    What Was Changed:   Initial Creation
    </summary>
*/
print '' print '**** creating sp_delete_transportation_order ****'
GO
CREATE PROCEDURE [dbo].[sp_delete_transportation_order]
(
	@OrderID  int
	
)
AS
	BEGIN	
						
        DELETE TransportItem
		WHERE @OrderID = [TransportItemID]
		
	END
GO 
/* 
	<summary>
	Creator:            Abdalgader Ibrahim
	Created:            04/08/2024
	Summary:            Create sp_update_employee_password Stored procedure.
	Last Updated By:    Abdalgader Ibrahim
	Last Updated:       04/08/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_update_employee_password ***'
GO
CREATE PROCEDURE [dbo].[sp_update_employee_password]
(
	@EmployeeID		[nvarchar](100),
	@PasswordHash	[nvarchar](256)
)
AS BEGIN
    UPDATE 	
        [Employee]
    SET	
        [PasswordHash] = @PasswordHash
    WHERE	
        @EmployeeID = [EmployeeID]
END
GO

/*****************************************************************************
						DONATIONS STORED PROCEDURES
*****************************************************************************/

print '' print '*** retriving all donations stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_donations_select_all]

AS 
	BEGIN
		SELECT 	[DonationID],[DonationTypeID],[DonatorID],[DonationName],[Amount],[DonationsDate],[Active]
		FROM [dbo].[Donations]
	END
GO

print '' print '*** retriving all donators stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_donators_select_all]

AS 
	BEGIN
		SELECT 	[DonatorID],[FamilyName],[PhoneNumber],[Email],[Address]
		FROM [dbo].[Donator]
	END
GO

print '' print '*** retriving all donationType stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_donationtype_select_all]

AS 
	BEGIN
		SELECT [DonationTypeID],[TypeName]
		FROM [dbo].[DonationType]
	END
GO

print '' print '***  Update donations stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_Update_donations]
(
	@DonationID INT ,
	@DonationTypeID INT ,
	@DonatorID INT,
	@DonationName nvarchar (50),
	@Amount nvarchar (50) ,
	@DonationsDate Date ,
	@Active Bit 
)
AS 
	BEGIN
		UPDATE [dbo].[Donations]
		SET DonationTypeID = @DonationTypeID, 
			DonatorID = @DonatorID, 
			DonationName = @DonationName,
			Amount = @Amount,
			DonationsDate = @DonationsDate,
			Active = @Active
		WHERE DonationID = @DonationID;  
	END
GO

/*
    <summary>
    Creator: Miyada Abas
    Created: 04/04/2024
    Summary: initial creation of the sp_get_all_items stored procedure
    Last Updated By: Miyada Abas
    Last Updated: 04/04/2024
    What Was Changed: initial creation 
    </summary>
*/

print '' print '*** creating sp_get_all_items ***'
GO
CREATE PROCEDURE [dbo].[sp_get_all_items]

AS
BEGIN 
    SELECT
			[ItemID],
			[ItemName], 
			[ItemDescription], 
			[QtyOnHand], 
			[NormalStockQty], 
			[ReorderPoint],  
			[OnOrder]
		FROM [Item]
	END
GO


/*
	<summary>
	Creator:            Liam Easton
	Created:            04/23/2024
	Summary:            sp_create_donation initial creation
	</summary>   
*/
print '' print '*** creating sp_create_donation ***'
GO
CREATE PROCEDURE [dbo].[sp_create_donation]
(
	@DonationTypeID	    [int],		
	@DonationName		[nvarchar](50),	
	@Amount				[nvarchar](50),	
	@DonationsDate		[date],			
	@Active				[bit]	
)
AS 
	BEGIN
		INSERT INTO [dbo].[Donations]
			([DonationTypeID],[DonationName],[Amount],[DonationsDate],[Active]) 
		VALUES
		(
			@DonationTypeID,		
			@DonationName,	
			@Amount,			
			@DonationsDate,	
			@Active			
		)
	END
GO

/*
	<summary>
	Creator:            Seth Nerney
	Created:            04/25/2024
	Summary:            sp_get_shelter_scheduled_repairs
	</summary> 
*/
print '' print '*** creating sp_get_shelter_scheduled_repairs ***' 
GO 
CREATE PROCEDURE [dbo].[sp_get_shelter_scheduled_repairs]
(
	@Status		[nvarchar](50)
)
AS
	BEGIN
		SELECT [RepairID], [Repair].[RequestID], [EmployeeID], [Repair].[Status], [Description], [TimeCreated]
		FROM 	[Repair] INNER JOIN [MaintenanceRequest] ON [MaintenanceRequest].[RequestID] = [Repair].[RequestID]
		WHERE	@Status = [Repair].[Status]
	END
GO

/* 
	<summary>
	Creator:            Sagan DeWald
	Created:            02/23/2024
	Summary:            Marks an incident as hidden from a selected user by inserting into the HiddenIncident table. Checks if the user exists in any of the three user tables first, returns 0 if not.
	Last Updated By:    Sagan DeWald
	Last Updated:       02/23/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_hide_incident stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_hide_incident]
(
	@IncidentId	[int],
	@UserId		[nvarchar](100)
)
AS BEGIN
	IF (SELECT COUNT([ClientID]) FROM [dbo].[Client] WHERE @UserId = [ClientID]) > 0
	BEGIN
		INSERT INTO [dbo].[HiddenIncident]
			([TargetUser], [IncidentID])
		VALUES
			(@UserId, @IncidentId)
		RETURN
			@@ROWCOUNT;
	END
	ELSE IF (SELECT COUNT([EmployeeID]) FROM [dbo].[Employee] WHERE @UserId = [EmployeeID]) > 0
	BEGIN
		INSERT INTO [dbo].[HiddenIncident]
			([TargetUser], [IncidentID])
		VALUES
			(@UserId, @IncidentId)
		RETURN
			@@ROWCOUNT;
	END
	ELSE IF (SELECT COUNT([VolunteerID]) FROM [dbo].[Volunteer] WHERE @UserId = [VolunteerID]) > 0
	BEGIN
		INSERT INTO [dbo].[HiddenIncident]
			([TargetUser], [IncidentID])
		VALUES
			(@UserId, @IncidentId)
		RETURN
			@@ROWCOUNT;
	END
	ELSE
	BEGIN
		RETURN 0;
	END
END
GO

/* 
	<summary>
	Creator:            Sagan DeWald
	Created:            02/25/2024
	Summary:            Returns a selection of incidents based on who they are meant to be hidden from.
	Last Updated By:    Sagan DeWald
	Last Updated:       02/25/2024
	What Was Changed:   Initial creation.
	</summary>
*/
print '' print '*** creating sp_select_hidden_incidents_by_user_id stored procedure ***'
GO
CREATE PROCEDURE [dbo].[sp_select_hidden_incidents_by_user_id]
(
	@TargetUser [nvarchar](100)
)
AS BEGIN
	SELECT
		[HiddenIncidentID],
		[TargetUser],
		[IncidentID]
	FROM
		[dbo].[HiddenIncident]
	WHERE
		[TargetUser] = @TargetUser
END
GO
