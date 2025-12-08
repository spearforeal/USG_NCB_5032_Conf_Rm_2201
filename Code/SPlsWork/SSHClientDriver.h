namespace SSHClientDriver;
        // class declarations
         class SshClientDevice;
     class SshClientDevice 
    {
        // class delegates
        delegate FUNCTION InitializedDataHandler ( INTEGER state );
        delegate FUNCTION ConnectionStateHandler ( INTEGER state );
        delegate FUNCTION ReceivedDataHandler ( SIMPLSHARPSTRING data );

        // class events

        // class functions
        FUNCTION Debug ( STRING message );
        FUNCTION Initialize ( STRING hostname , SIGNED_LONG_INTEGER port , STRING username , STRING password , STRING debugName );
        FUNCTION Connect ();
        FUNCTION Disconnect ();
        FUNCTION SendCommand ( STRING command );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER DebugEnable;

        // class properties
        DelegateProperty InitializedDataHandler InitializedData;
        DelegateProperty ConnectionStateHandler ConnectionState;
        DelegateProperty ReceivedDataHandler ReceivedData;
    };

