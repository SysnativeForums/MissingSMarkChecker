# Missing s! Mark Checker
This tool whill enumerate the Deployments subkey of a given COMPONENTS hive and check for any disperencies between the number of p! and s! marks. If there is any missing
s!-p! mark pairs, then the tool will add the missing s! marks and safely unload the COMPONENTS hive.

Instructions:

There is two methods for using the tool:

1. Drag and drop the COMPONENTS hive onto the .exe file, it will prompt you for an alias for the hive to be loaded
2. Load the .exe file and then enter the alias and path manually, you can use the Copy as Path option from the Windows right-click context menu to get this. You do not need to remove the double quotes.

Important Points:

1. The COMPONENTS hive alias should be **anything but** COMPONENTS, particularly if you're loading a hive which is not your own. This is to ensure that you don't inadvertently corrupt your own Component Store.

2. The file path can be anywhere and I recommend that you use the Copy as Path option from the context menu in order to provide your file paths to the application.

3. Please ensure that you create a back up of the COMPONENTS hive you're amending before running this application.

4. Please raise any issues under Issues.
