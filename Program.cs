using System;
using System.Diagnostics;

class GitAutomation
{
    static void Main(string[] args)
    {

        string directory = args.Length > 0 ? args[0] : ".";
        string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"Args {args[0]}");
        Console.WriteLine($"Directory: {directory}");
        WriteTextToFile($@"{directory}\README.md", $"😎🌲Automated commit at 😂 {currentDateTime}");

        RunGitCommand($"cd {directory} && git add .");
        RunGitCommand($"cd {directory} && git commit -m \"Automated commit at {currentDateTime}\"");
        RunGitCommand($"cd {directory} && git push origin master");
        
        Console.WriteLine("Done");
        Console.ReadLine();
    }

    static void RunGitCommand(string command)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "cmd.exe",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new() { StartInfo = startInfo };
        process.Start();
        process.StandardInput.WriteLine(command);
        process.StandardInput.Flush();
        process.StandardInput.Close();
        process.WaitForExit();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
    }

    static void WriteTextToFile(string path, string text)
    {
        using StreamWriter writer = new(path, true);
        writer.WriteLine(text);
    }
}
