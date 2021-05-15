using System;
using System.Diagnostics;

string[] Stages = {"/etc/runit/1", "/etc/runit/2", "/etc/runit/3"};
string shell = "/bin/sh";

Console.WriteLine("Janit v0.1");
for (int i = 1; i <= Stages.Length; i++)
{
    Console.WriteLine($"enter stage: {i}");
    var process = Process.Start(new ProcessStartInfo()
    {
        FileName = Stages[i],
        Arguments = "0"
    });
    try
    {
        await process.WaitForExitAsync();
    }
    catch (Exception exc)
    {
        Console.WriteLine(exc);
    }
    Console.WriteLine($"leave stage: {i}");
}