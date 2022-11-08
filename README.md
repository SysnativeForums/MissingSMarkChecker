# Missing s! Mark Checker
This tool whill enumerate the Deployments subkey of a given COMPONENTS hive and check for any disperencies between the number of p! and s! marks. If there is any missing
s!-p! mark pairs, then the tool will add the missing s! marks and safely unload the COMPONENTS hive.

Important Points:

1. The COMPONENTS hive alias should be **anything but** COMPONENTS, particularly if you're loading a hive which is not your own. This is to ensure that you don't inadvertently corrupt your own Component Store.

2. The file path can be anywhere and I recommend that you use the Copy as Path option from the context menu in order to provide your file paths to the application.

3. Please ensure that you create a back up of the COMPONENTS hive you're amending before running this application.

4. Please raise any issues under Issues.
