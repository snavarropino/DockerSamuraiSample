Write-Host "Starting api" 
start-process  "dotnet.exe" -ArgumentList "c:\app\Samuraiapi.dll" -NoNewWindow 

Write-Host "Starting web" 
start-process  "dotnet.exe" -ArgumentList "c:\webapp\Samuraiweb.dll" -NoNewWindow 

ping -t localhost