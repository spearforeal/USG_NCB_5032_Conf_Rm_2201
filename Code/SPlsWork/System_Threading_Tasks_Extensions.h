namespace System.Threading.Tasks;
        // class declarations
         class ValueTask;

namespace System.Threading.Tasks.Sources;
        // class declarations
         class ValueTaskSourceOnCompletedFlags;
         class ValueTaskSourceStatus;
    static class ValueTaskSourceOnCompletedFlags // enum
    {
        static SIGNED_LONG_INTEGER None;
        static SIGNED_LONG_INTEGER UseSchedulingContext;
        static SIGNED_LONG_INTEGER FlowExecutionContext;
    };

    static class ValueTaskSourceStatus // enum
    {
        static SIGNED_LONG_INTEGER Pending;
        static SIGNED_LONG_INTEGER Succeeded;
        static SIGNED_LONG_INTEGER Faulted;
        static SIGNED_LONG_INTEGER Canceled;
    };

namespace System.Runtime.CompilerServices;
        // class declarations
         class AsyncMethodBuilderAttribute;
         class AsyncValueTaskMethodBuilder;
         class ConfiguredValueTaskAwaitable;
         class ValueTaskAwaiter;
     class AsyncValueTaskMethodBuilder 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION SetResult ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        ValueTask Task;
    };

     class ConfiguredValueTaskAwaitable 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ValueTaskAwaiter 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION GetResult ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

