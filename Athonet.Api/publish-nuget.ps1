﻿# This script will publish to nuget using the api key in nuget-api-key.txt in the same folder.
# The api key issued by nuget.org should ideally only have permissions to update a single package
# with new versions.

$apiKeyFilename = "nuget-api-key.txt";
if(-not (Test-Path($apiKeyFilename))){
	Write-Output "$apiKeyFilename does not exist"
	exit 1;
}
$apiKey = Get-Content $apiKeyFilename;

dotnet build -c Release
dotnet pack -c Release

$mostRecentPackage = Get-ChildItem bin\Release\*.nupkg | Sort-Object LastWriteTime | Select-Object -last 1
Write-Output "Publishing $mostRecentPackage..."
# If you don't have nuget.exe - download from https://www.nuget.org/downloads and place in "C:\Users\xxx\AppData\Local\Microsoft\WindowsApps"
nuget.exe push -Source https://api.nuget.org/v3/index.json -ApiKey $apiKey "$mostRecentPackage"