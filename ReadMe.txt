Ran Console App local, works (duh)
Deployed WebApp debug to B1 App Service in ExplorationPOC Sub. Worked.
Deployed WebApp debug to B3 App Service in IS Dev/Test Sub. Failed: System.DllNotFoundException: Failed to find library "libtesseract400.dll" for platform x64.
Deployed AzFunc release to B1 App Service in ExplorationPOC Sub. Failed: System.DllNotFoundException: Failed to find library "liblept1753.dll" for platform x64.
Note: Deploy and set function to 64 bits to give it the hint....