ShipIt Inventory Management
===========================

Copyright 2010.

# Setup Instructions

## Running the application

### With Visual Studio

To run the app via Visual Studio:

* Open the `ShipIt.sln` solution by going to `File` -> `Open` -> `Project/Solution`
* Download and install Microsoft.NETFramework.ReferenceAssemblies 1.0.0 from NuGet
* Add a connections.config to both the ShipIt and ShipItTest projects, adding a connection string to each e.g.

To run the app via Rider:

### Setting Up Project 
* Open the `ShipIt.sln` solution by going to `File` -> `Open` -> `Project/Solution`
* Download .NETFramework 4 Developer Pack
* This link might help: https://rider-support.jetbrains.com/hc/en-us/articles/207288089-Using-Project-Rider-under-Windows-without-Visual-Studio-prerequisites

* You might be prompted with this error in the log:
* The imported project "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\Microsoft\VisualStudio\v15.0\WebApplications\Microsoft.WebApplication.targets"
* You might be missing the workload for Web development build tools": `Microsoft.VisualStudio.Workload.WebBuildTools` 

* To solve Download Visual Studio or VisualStudio Installer
* You can install it by downloading the build tools installer from here (VS2017) or here (VS2019) then running
* Alternatively following this: https://stackoverflow.com/questions/44061932/ms-build-2017-microsoft-webapplication-targets-is-missing?noredirect=1&lq=1

* Change MSBuild by going to `File` -> `Setting` -> `Build/Excecution/Deployment` -> `Toolset and Build` -> `Use MSBuild Version` and choose the location you've saved you're MSBuild
* It should look something like this example: C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild 
* For example: C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild 

* Download and install Microsoft.NETFramework.ReferenceAssemblies 1.0.0 from NuGet
* Download and install VisualStudio.QualityTools.UnitTestFramework from NuGet

### Setting Up Connection 
* Add a connections.config to both the ShipIt and ShipItTest projects, adding a connection string to each e.g.
```
<connectionStrings>
  <add name="MyPostgres" providerName="System.Data.SqlClient" connectionString="Server=127.0.0.1;Port=5432;Database={YourDatabaseName};User Id=postgres; Password=password;" />
</connectionStrings>
```

### Connecting to a DataBase
* Download the latest version of PostgreSQL for your operating system from here: https://www.postgresql.org/download/ 
* This is a helpful guide to test your PostgreSQL connection: https://www.postgresqltutorial.com/install-postgresql/
* Follow the steps here: https://www.jetbrains.com/help/rider/Connecting_to_a_database.html?keymap=visual_studio to set up your database
* In the SQL Shell run \i C:/Training/Shipit/shipit-csharp/ShipIt/08-ShipIt-ConstructPostgresDatbase.sql. This will connect your database

### Testing 
* Download and install Microsoft_VisualStudio_QualityTools_UnitTestFramework.STW
* In order to run MSTest test, Rider needs to use a console unit test runner 
* Go to `File` -> `Settings` -> `Build, Execution, Deployment` -> `Unit Testing` -> MSTest
* Choose the version of VS you have, so change the path accordingly 
* Example path: `C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE`

### Deploy to Production

ShipIt is deployed on AWS Elastic Beanstalk with a postgres DB.
To update a running [AWS Elastic Beanstalk](https://aws.amazon.com/elasticbeanstalk/) instance:

* Install [AWS Toolkit for Visual Studio](https://aws.amazon.com/visualstudio/)
* Open the Warehouses-CSharp project in Visual Studio and add your AWS credentials to the AWS Toolkit
* Right click on the ShipIt project and select Publish to AWS
* Select the region your prod environment is running on and redeploy to that environment

To check the logs:  From the AWS console, go to `Services` -> `Elastic Beanstalk`, and
choose your instance from the dashboard.   Click `Logs` on the left, then `Request Logs`.

In the unlikely event that you need to change any of the injected configuration, for
example the database connection string or password, then these are available under
`Configuration` -> `Software`.

Information on the CPU utilisation, and network utilisation is available under `Monitoring`,
it may also be interesting to look at the utilisation or logs of the PostgreSQL database instance
which backs this application.  These are available under `Services` -> `RDS` -> `Databases`
-> `shipit`.

## Unit Tests

Run the tests in Visual Studio by right clicking on the `ShipItTest` project and
choosing "Run Tests".
