# JewelryStoreWebApp
Jewellery Web Application

Both API and WebApp(Front end) is placed in same solution. We can split later on, for the ease of testing and running i kept both in same solution.

Project should start in "Multiple Startup Projects" mode. Start both the JewelryStoreWebApp and JewelryStoreAPIs.

Propertied to be Set before running:
In JewelryStoreWebApp Project:
  appsettings.json file
      "LoginApi": To provide the Authentication API url
      "FetchCustomerAPI": To Provide the user xml check API
      "OutputFilePath": Outpu file path to save the "Print to File" text file
      
 In JewelryStoreAPIs Project:
  appsettings.json file     
"CustomersSecretXML":To Provide the xml input file for authentication check; Currently its fetcing from resource folder.

In ModelLayer Project:
Resources folder: Employee details xml file(in xml format).


