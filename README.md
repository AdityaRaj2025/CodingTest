# Question CSS2.1: CRUD GUI

# Login Page
Here is a simple login page for a railway task application. Users can log in with their role and password to access different functionalities of the application.

#### Usage
1. Run the application.
2. Select your role from the drop-down menu and input your password. The user name, which will automatically come from your system user account.
3. Click the "Login" button.
4. If the credentials are correct, you will be redirected to the main window of the application; otherwise, an error message will be displayed.

#### Assumptions
- This login page assumes the existence of two user roles: "Admin" and "Operator".
- The passwords for each role are hardcoded in the code for demonstration purposes. In a real-world scenario, passwords should be securely stored and managed, such as using encryption and proper authentication mechanisms.
  
![LOGIN](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotofLogin.png)

Figure: Login Page

# Crud Operations Page
The CRUD Operations page enables users to perform the following actions on route records within the application:
#### Create
#### Read
#### Update
#### Delete

### XML Data Storage

All route records within the application are stored and retrieved using XML format. The RouteLibrary provides functionalities for XML data management, including:

- **Loading Records**: Route records are loaded from the XML file `records.xml` upon application startup.
- **Saving Records**: Updated records are serialized and saved back to the XML file to persist changes.
- **Generating Reference Code**: A unique reference code is generated for each record based on the record's attributes and current timestamp.

![CrudPage](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotForCrudOperations.png)

Figure: Crud Windows

### Adding Records Functionality
The `Add Record` method facilitates the addition of new records within the application.

#### Functionality Overview
- This method is called when a user initiates the addition of a record.
- It opens a modal window (`AddRecordWindow`) for adding records.
- Upon completion of the modal window:
  - If the user confirms the addition, the method verifies the validity of the input data.
  - If the input data is valid, it assigns a reference code to the record and either adds the new record to the repository.
  - After adding the record, it refreshes the data grid to reflect the changes.

#### Data Validation
- The method ensures that the distance for the new record is not less than 0. If the distance is invalid, an error message is displayed, and the addition or update process is aborted.

#### Usage Instructions
- To add a new record, click on the "Add" button within the application. Complete the required fields in the popup window and click "Save".

![Add Record](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotOfAddData.png)

Figure: Add Record

### Updating Records Functionality
The `Update Record` method enables authorized users to update existing records within the application's data grid.

#### Functionality Overview
- When the user clicks on the "Update" button, this method is triggered to initiate the record update process.
- The method first checks if a record is selected in the data grid.
- If a record is selected:
  - It verifies the user's role to ensure that only users with administrative privileges can update records.
  - Initiates the update process by passing the selected record to the `AddOrUpdateRecord` method for editing.
- If no record is selected, it prompts the user to select a record for updating.

#### Usage Instructions
- Ensure that you have administrative privileges to update records.
- Select a record from the data grid that you want to update.
- Click on the "Update" button to initiate the update process.

![Update Record](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotOfUpdate.png)

Figure: Update Record

### Deleting Records Functionality
The `Delete Record` method is responsible for allowing authorized users to delete records from the application's data grid.

#### Functionality Overview
- When the user clicks on the "Delete" button, this method is invoked to initiate the record deletion process.
- The method first checks if a record is selected in the data grid.
- If a record is selected:
  - It verifies the user's role to ensure that only users with administrative privileges can delete records.
  - Displays a confirmation message to confirm the deletion.
  - If the user confirms the deletion, the selected record is deleted from the data grid and the associated repository.
  - The data grid is refreshed to reflect the updated record set.
- If no record is selected, it prompts the user to select a record for deletion.

#### Usage Instructions
- Ensure that you have administrative privileges to delete records.
- Select a record from the data grid that you want to delete.
- Click on the "Delete" button to initiate the deletion process.
- Confirm the deletion when prompted.


![Delete Record](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotOfDelete.png)

Figure: Delete Record

# Question CSS2.2: Library

# Data Layer Library Project
The data layer library project (`RouteLibrary`) is designed to manage route records and provides functionalities for CRUD operations using XML data storage.

#### Purpose
1. **Reusable Component**: The library project is intended to be consumed by multiple frontend projects, allowing for centralized data management across applications.
2. **Data Persistence**: Route records are stored and retrieved in XML format to ensure data persistence and portability.

#### Components
- **Record Class**: Defines the structure of a route record, including properties such as route title, stations, distance, status, creation datetime, and reference code.
- **IRecordRepository Interface**: Defines the contract for interacting with route records, including methods for loading, saving, adding, updating, and deleting records.
- **RecordRepository Class**: Implements the `IRecordRepository` interface and provides concrete implementations for CRUD operations using XML data storage.

### Design Pattern for Testability

The design of the data layer follows principles that promote testability, ensuring that all functions can be easily tested using unit tests.

#### Separation of Concerns
- The data layer separates concerns by providing an interface (`IRecordRepository`) that abstracts the underlying data access logic from the frontend projects.
- This allows for easy substitution of implementations, facilitating testing with mock objects or alternate data sources.

#### Dependency Injection
- Dependencies are injected into classes rather than being directly instantiated, enabling easier testing by allowing dependencies to be replaced with mock objects during unit tests.

#### Single Responsibility Principle
- Each class within the data layer has a single responsibility, such as managing records or serializing/deserializing XML data, making it easier to isolate and test individual components.

#### Unit Testability
- The data layer's design pattern makes all functions testable by decoupling dependencies, ensuring that unit tests can be written to verify the correctness of each function's behavior.

### Usage Instructions
1. Reference the `RouteLibrary` project in your frontend projects to utilize the provided functionalities for managing route records.
2. Use the `IRecordRepository` interface to interact with route records, ensuring consistency and adherence to the defined contract.
3. Implement the necessary frontend logic to display, add, update, and delete route records as per the requirements of your application.

### Future Enhancements
- Consider implementing additional data storage options (e.g., database integration) to provide scalability and performance improvements.
- Explore integration with testing frameworks to automate unit tests and ensure robustness and reliability of the data layer functionalities.


# Question CSS2.3: Read/Write

# Route Data CSV to XML Page
This functionality is for displaying railway track route data. It includes features to convert CSV data into XML format, display and filter route information, and import data into XML files.

#### Usage
1. Run the application.
2. Login
3. Click on the Track Data button. 
4. Browse for a CSV file containing route data using the "Browse" button.
5. All route data will show up on the data grid.
6. Optionally, filter route data by status or date range using the provided controls.
7. Click the "Import" button to save the data into an XML file in your local system.

![Route Data](https://github.com/AdityaRaj2025/RailwayRouteRecord/blob/main/ScreenshotOfTrack.png)

Figure: CSV to XML

# Tools and Frameworks Used

- **IDE**: Visual Studio 2022
- **Framework**: .NET Framework, Target 4.7.2
- **Unit Testing**: NUnit package library and NUnit3TestAdapter
