namespace Microsoft.Extensions.Logging;
        // class declarations
         class EventId;
         class LogDefineOptions;
         class LoggerExtensions;
         class LoggerExternalScopeProvider;
         class LoggerFactoryExtensions;
         class LoggerMessage;
         class LoggerMessageAttribute;
         class LogLevel;
     class LogDefineOptions 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class LoggerExtensions 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class LoggerExternalScopeProvider 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class LoggerFactoryExtensions 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class LoggerMessage 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class LoggerMessageAttribute 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER EventId;
        STRING EventName[];
        LogLevel Level;
        STRING Message[];
    };

    static class LogLevel // enum
    {
        static SIGNED_LONG_INTEGER Trace;
        static SIGNED_LONG_INTEGER Debug;
        static SIGNED_LONG_INTEGER Information;
        static SIGNED_LONG_INTEGER Warning;
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER Critical;
        static SIGNED_LONG_INTEGER None;
    };

namespace Microsoft.Extensions.Logging.Abstractions;
        // class declarations
         class NullLogger;
         class NullLoggerFactory;
         class NullLoggerProvider;
     class NullLogger 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        NullLogger Instance;
    };

     class NullLoggerFactory 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Dispose ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory Instance;

        // class properties
    };

     class NullLoggerProvider 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Dispose ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        NullLoggerProvider Instance;
    };

namespace Microsoft.Extensions.Internal;
        // class declarations

