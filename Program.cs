using System;
using System.Diagnostics;

class GitAutomation
{
    static void Main(string[] args)
    {
        string directory = args.Length > 0 ? args[0] : ".";
        string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        RunGitCommand($"cd {directory}");
        RunGitCommand($"git add .");
        RunGitCommand($"git commit -m \"😎🌲Automated commit at 😂 {currentDateTime}\"");
        RunGitCommand("git pull origin main");
        RunGitCommand("git push origin main");
    }

    static void RunGitCommand(string command)
    {
        ProcessStartInfo startInfo = new("cmd.exe", $"/c {command}")
        {
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = false
        };

        using Process process = Process.Start(startInfo)!;
        using StreamReader reader = process.StandardOutput;
        string result = reader.ReadToEnd();
        Console.WriteLine(result);
    }
}
