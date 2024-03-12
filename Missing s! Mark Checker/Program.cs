using Microsoft.Win32;
using Missing_s__Mark_Checker;

const string hive = "C";

var arguments = Environment.GetCommandLineArgs();
var path = arguments[1];

RegistryKey deployments = default!;

try
{
    HiveLoader.GrantPrivileges();
    var result = HiveLoader.LoadHive(path, hive);
    HiveLoader.RevokePrivileges();

    if (result != 0)
    {
        Console.WriteLine("Unable to load the registy hive");
        return;
    }

    Console.WriteLine("Reading Deployments subkey, please wait...");

    deployments = HiveLoader.HKLM.OpenSubKey($@"{hive}\CanonicalData\Deployments", true)!;

    foreach (var deploymentName in deployments!.GetSubKeyNames())
    {
        var deployment = deployments.OpenSubKey(deploymentName, true)!;
        
        var values = deployment.GetValueNames();

        var sMarks = values.Where(v => v.StartsWith("s!"));
        var pMarks = values.Where(v => v.StartsWith("p!"));

        if (pMarks.Count() > sMarks.Count())
        {
            foreach (var pMark in pMarks)
            {
                var value = deployment.GetValue(pMark)!;
                var dataType = deployment.GetValueKind(pMark);
                var sMark = pMark.Replace("p!", "s!");

                deployment.SetValue(sMark, value, dataType);
            }
        }

        deployment.Close();
    }

    Console.WriteLine("The repair(s) - if any - have been completed...");
}
catch (Exception e)
{
    Console.WriteLine($"An exception has occured: {e.Message}");
}
finally
{
    HiveLoader.GrantPrivileges();
    
    if (deployments is not null) deployments.Close();
    var result = HiveLoader.UnloadHive(hive);
    HiveLoader.HKLM.Close();

    HiveLoader.RevokePrivileges();

    if (result == 0) Console.WriteLine("Successfully unloaded hive");

    Console.WriteLine("Please press any key to exit...");
    Console.ReadKey();
}
