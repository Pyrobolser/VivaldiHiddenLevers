# VivaldiHiddenLevers
Vivaldi code project powered by HiddenLevers

## Setup

### Back-end
- Clone the repository
- Start the **VivaldiHiddenLevers** solution
- Let Visual Studio restore the NuGet packages or do it with a right-click on the solution and select **_Restore NuGet Packages_**
- Right-click on the solution and select **_Build Solution_**
- Ensure that the project **VivaldiHiddenLevers.WebUI** in the **Presentation** folder is setup as the Startup project:
  - Navigate to the folder in Visual Studio
  - Right-click the project and select **_Set as StartUp Project_**
- Restore the Environment Variables in _appsettings.json_

### Front-end
- Navigate to _VivaldiHiddenLevers\VivaldiHiddenLevers.WebUI\ClientApp_ with your favorite command-line tool
- Execute `npm install` to restore the NPM packages


## Start

### Back-end
- Start with the default IIS Express configuration
- You can navigate to http://localhost:2735/swagger/index.html for the Swagger page

### Front-end
- Navigate to _VivaldiHiddenLevers\VivaldiHiddenLevers.WebUI\ClientApp_ with your favorite command-line tool
- Execute `npm start` to start the script and **ng server** automatically
- You can navigate to http://localhost:4200/ for the front-end 
  
