namespace Логгер;

public interface ILogger
{
   void LogInformation(string message);
   void LogError(Exception exception, string? additionalMessage = null);
}

public class ConsoleLogger : ILogger
{
   public void LogInformation(string message)
   {
      Console.WriteLine(message);
   }

   public void LogError(Exception exception, string? additionalMessage = null)
   {
      Console.WriteLine(exception.Message);
      if (additionalMessage != null)
      {
         Console.WriteLine(additionalMessage);
      }
   }
}

public class FileLogger : ILogger
{
   public void LogInformation(string message)
   {
      using var sw = File.AppendText("log.txt");
      sw.WriteLine(message);
   }

   public void LogError(Exception exception, string? additionalMessage = null)
   {
      using var sw = File.AppendText("log.txt");
      sw.WriteLine(exception.Message);
      if (additionalMessage != null)
      {
         sw.WriteLine(additionalMessage);
      }
   }
}

public class CompositeLogger : ILogger
{
   private readonly List<ILogger> _loggers;
   public CompositeLogger(List<ILogger> loggers)
   {
      _loggers = loggers;
   }

   public void LogInformation(string message)
   {
      foreach (var logger in _loggers)
      {
         logger.LogInformation(message);
      }
   }

   public void LogError(Exception exception, string? additionalMessage = null)
   {
      foreach (var logger in _loggers)
      {
         logger.LogError(exception, additionalMessage);
      }
   }
}