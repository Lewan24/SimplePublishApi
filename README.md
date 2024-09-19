# SimplePublishApi

# Information
This is gonna be a simple Api project<br>
to run specific .bat file while valid request is sent.

## Purpose
Need to automate few console commands while master branch on other repo<br>
is updated. Then Api will invoke .bat file to update existing repo.

## Additional
This project could be as template for this type simple api project

## How to run
1. Configure port in run settings<br>
2. Configure settings in appsettings.json (it's not included into project), there's template:<br>
```json
"AppSettings": {
    "ExecuteFilePath": "",
    "ExecuteFileName": "",
    "HostingUrls": "http://localhost:50000/" 
  }
```
- <b>ExecuteFileName</b> - Path to the file that will be executed<br>
if it's empty, then it will run in project directory.<br>
- <b>ExecuteFileName</b> - File name that will be executed<br>
if empty, then the file "run.bat" will be run.<br>
- <b>HostingUrls</b> - Urls and ports that are gonna be set on start<br>
if empty then it will be set from run properties.<br><br>

Then run api while in project folder:<br>
```bash
dotnet run --watch
```

