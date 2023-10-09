# Usage
1. Add ```using Alsterverse.Imageflow.Optimizely;``` to the top of your statup.cs 
1. Add ```services.AddImageflowOptimizelyBlobService();``` to your startup.cs

By default the following path prefixes are configured for Imageflow to take action on:
- ```/episerver/cms/globalassets/```
- ```/globalassets/```
- ```/episerver/cms/siteassets/```
- ```/siteassets/```
- ```/episerver/cms/contentassets/```
- ```/contentassets/```

You can change these using the option parameter:
```
services.AddImageflowOptimizelyBlobService(options => {
    options.Prefixes = new[]{ "/globalassets/" }
});
```