namespace AssignmentDay3.Models;

public class LogData
{
    public string Schema { get; set; }
    public string Host { get; set; }
    public string Path { get; set; }
    public string QueryString { get; set; }
    public string Body { get; set; }
    
    public override string ToString() => 
        $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]\n" +
        $"Schema: {Schema}\n" +
        $"Host: {Host}\n" +
        $"Path: {Path}\n" +
        $"QueryString: {QueryString}\n" +
        $"Body: {Body}\n" +
        new string('-', 50) + "\n";
}