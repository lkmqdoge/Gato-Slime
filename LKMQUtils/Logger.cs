using System;
using Godot;

namespace LKMQUtils;

public enum LogLevel
{
    INFO,
    DEBUG,
    WARNING,
    ERROR,
}

public static partial class Logger
{
    public static void Error(string message)
    {
        GD.PrintErr(new Entry(message, LogLevel.ERROR));
        GD.Print(System.Environment.StackTrace);
    }

    public static void Warning(string message)
    {
        GD.Print(new Entry(message, LogLevel.WARNING));
    }

    public static void Debug(string message)
    {
#if DEBUG
        GD.Print(new Entry(message, LogLevel.DEBUG));
#endif
    }

    public static void Info(string message)
    {
        GD.Print(new Entry(message, LogLevel.INFO));
    }

    internal static void Debug(Type type)
    {
        throw new NotImplementedException();
    }
}

public sealed record Entry
{
    public string Message { get; init; }
    public LogLevel LogLevel { get; init; }
    public DateTime Timestamp { get; init; }

    public Entry(string message, LogLevel logLevel)
    {
        Message = message.Trim();
        LogLevel = logLevel;
        Timestamp = DateTime.Now;
    }

    public override string ToString()
    {
        return $"[{LogLevel}] [{Timestamp.Hour}:{Timestamp.Minute}:{Timestamp.Second}] - {Message}";
    }
}
