namespace TcpClientGenericSPlus;
        // class declarations
         class AnalogTransmitEventArgs;
         class ConsolePrintAsciiHexStrings;
         class SerialTransmitEventArgs;
         class TcpClientGeneric;
     class AnalogTransmitEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Message;
    };

     class ConsolePrintAsciiHexStrings 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION Print ( STRING str , STRING prepend );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class SerialTransmitEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Message[];
    };

     class TcpClientGeneric 
    {
        // class delegates

        // class events
        EventHandler OnSocketChangeSPlusEvent ( TcpClientGeneric sender, AnalogTransmitEventArgs connectedState );
        EventHandler OnDataRxEventSPlus ( TcpClientGeneric sender, SerialTransmitEventArgs args );

        // class functions
        FUNCTION SendString ( STRING str );
        FUNCTION KeepAlive ();
        FUNCTION Connect ();
        FUNCTION EnableKeepAlive ();
        FUNCTION DisableKeepAlive ();
        STRING_FUNCTION GetValidUserPass ( STRING pass );
        FUNCTION Disconnect ();
        FUNCTION DisconnectAndDispose ();
        FUNCTION SetSplitCharacter ( STRING splitOn );
        FUNCTION EnableDebug ();
        FUNCTION DisableDebug ();
        FUNCTION EnableRemoveNullCharacters ();
        FUNCTION DisableRemoveNullCharacters ();
        FUNCTION SendResponseToSPlus ( STRING response );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        STRING Address[];
        SIGNED_LONG_INTEGER Port;
        STRING Username[];
        STRING Password[];
        STRING LoginPrompt[];
        STRING PasswordPrompt[];
        STRING LoginSuccess[];
        STRING LoginFailure[];
        STRING DisconnectCommand[];
        SIGNED_LONG_INTEGER RxBufferSize;
        STRING DebugName[];
        static INTEGER Connected;
        static INTEGER Disconnected;

        // class properties
    };

