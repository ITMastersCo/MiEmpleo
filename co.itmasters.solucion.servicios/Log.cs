using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using System.Configuration;

namespace co.itmasters.solucion.servicios
{
    public static class Log
    {
        static readonly LogWriter _logger;
        public static string ERROR = "Error";
        public static string DEBUG = "Debug";

        static Log()
        {
            // The formatter is responsible for the look of the message. Notice the tokens:
            // {timestamp}, {newline}, {message}, {category}
            TextFormatter formatter = new TextFormatter("{timestamp(local)} :" + " {category} :" + " {message}");
            String path = ConfigurationManager.AppSettings["ArchivoLog"];

            // Log messages to a log file. Use the formatter mentioned above as well as the header and footer specified.
            FlatFileTraceListener logFileListener = new FlatFileTraceListener(path, "","", formatter);

            // My collection of TraceListeners. I am only using one.  Could add more.
            LogSource mainLogSource = new LogSource("MainLogSource", SourceLevels.All);
            mainLogSource.Listeners.Add(logFileListener);

            // Assigning a non-existant LogSource for Logging Application Block Specials Sources I don't care about.
            // Used to say "don't log".
            LogSource nonExistantLogSource = new LogSource("Empty");

            // I want all messages with a category of "Error" or "Debug" to get distributed to all TraceListeners in my mainLogSource.
            IDictionary<string, LogSource> traceSources = new Dictionary<string, LogSource>();
            traceSources.Add("Error", mainLogSource);
            traceSources.Add("Debug", mainLogSource);

            // Let's glue it all together. No filters at this time. I won't log a couple of the Special
            // Sources: All Events and Events not using "Error" or "Debug" categories.
            _logger = new LogWriter(new ILogFilter[0], traceSources, nonExistantLogSource,  nonExistantLogSource,  mainLogSource,
                            "Error",false,  true);
        }

        ///// <summary>
        ///// Writes an Error to the log.
        ///// </summary>
        ///// <param name="message">Error Message</param>
        //public static void Write(string message)
        //{
        //    Write(message, "Error");
        //}


        /// <summary>
        /// Writes a message to the log using the specified
        /// category.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        public static void Write(string message, string category)
        {
            LogEntry entry = new LogEntry();
            entry.Categories.Add(category);
            entry.Message = message;
            _logger.Write(entry);
        }

    }
}
