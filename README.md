# Sitecore Pegasus

Sitecore Pegasus introduces a simple HTTP Request layer, captured through the Sitecore HttpRequestBegin pipeline, that enables automated deployments through the Sitecore Azure module.


## Instructions for Use

The latest release versions of the Sitecore.Pegasus package can be found in the build directory

### Installing the Package

Ensure that the website project is set to run with .NET Framework 4.0, and you have the Sitecore Azure module installed. 

Install the package via Nuget.

Installing the package will do the following:

* Add a new `azuredeployment` section to your `web.config` file. You can set configuration options in this section, including the applicable Azure Subscription Id, and the request path that the package will monitor.

* Add a `Sitecore.Pegasus.config` Sitecore include file to the `App_Config\include` folder.

###Using the Package

#### Using the  Package - Invoke a Deployment

Issue a POST request to `/<requestPath>/deploy`, and optionally pass a GUID parameter in the x-www-form-urlencoded form-data specifying the GUID of the deployment to deploy.

Example:

    POST /mysitecoresite/azure/deploy HTTP/1.1
    Host: mysitecoresite
    Cache-Control: no-cache
    
    ----WebKitFormBoundaryE19zNvXGzXaLvS5C
    Content-Disposition: form-data; name="deployment"
    
    {110d559f-dea5-42ea-9c1c-8a5df7e70ef9}
    ----WebKitFormBoundaryE19zNvXGzXaLvS5C

#### Using the  Package - Invoke a Deployment Swap

Issue a POST request to `/<requestPath>/swap`, and optionally pass a GUID parameter in the x-www-form-urlencoded form-data specifying the GUID of the deployment to swap.

Example:

    POST /mysitecoresite/azure/swap HTTP/1.1
    Host: mysitecoresite
    Cache-Control: no-cache
    
    ----WebKitFormBoundaryE19zNvXGzXaLvS5C
    Content-Disposition: form-data; name="deployment"
    
    {110d559f-dea5-42ea-9c1c-8a5df7e70ef9}
    ----WebKitFormBoundaryE19zNvXGzXaLvS5C


### Configuration Options

Shown below is a fully specified configuration section for Sitecore.Pegasus:

	<azuredeployment 
		enabled="true" 
		subscriptionId="110d559f-dea5-42ea-9c1c-8a5df7e70ef9" 
		requestPath="/sitecoreapi/azure/" />



Default configuration:

* enabled = true
* subscriptionId = ""
* requestPath = "/sitecoreapi/azure/"