namespace PresetDriver;
        // class declarations
         class PresetClient;
         class PresetFileManager;
         class PresetConfig;
         class PresetRecord;
     class PresetClient 
    {
        // class delegates
        delegate FUNCTION InitializedEvent ( INTEGER state );
        delegate FUNCTION WindowPresetChangedDelegate ( INTEGER value );
        delegate FUNCTION OutputValueChangedDelegate ( INTEGER index , INTEGER value );
        delegate FUNCTION PresetCountHandler ( INTEGER count );
        delegate FUNCTION PresetNameHandler ( INTEGER index , SIMPLSHARPSTRING name );
        delegate FUNCTION UshortValue ( INTEGER value );

        // class events

        // class functions
        FUNCTION Debug ( STRING message );
        FUNCTION Initialize ( STRING debugName );
        FUNCTION RecallPresetByIndex ( INTEGER index );
        FUNCTION RecallPresetByName ( SIMPLSHARPSTRING name );
        FUNCTION RequestWindowPreset1 ();
        FUNCTION RequestWindowPreset2 ();
        FUNCTION RequestOutput ( INTEGER index );
        FUNCTION RequestAllOutputs ();
        SIGNED_LONG_INTEGER_FUNCTION SavePresets ();
        SIGNED_LONG_INTEGER_FUNCTION OverwriteCurrentPreset8 ( INTEGER window , INTEGER o1 , INTEGER o2 , INTEGER o3 , INTEGER o4 , INTEGER o5 , INTEGER o6 , INTEGER o7 , INTEGER o8 );
        SIGNED_LONG_INTEGER_FUNCTION OverwriteCurrentPreset20Masked ( INTEGER window1 , INTEGER window2 , LONG_INTEGER applyMask , INTEGER o1 , INTEGER o2 , INTEGER o3 , INTEGER o4 , INTEGER o5 , INTEGER o6 , INTEGER o7 , INTEGER o8 , INTEGER o9 , INTEGER o10 , INTEGER o11 , INTEGER o12 , INTEGER o13 , INTEGER o14 , INTEGER o15 , INTEGER o16 , INTEGER o17 , INTEGER o18 , INTEGER o19 , INTEGER o20 );
        FUNCTION SetFileName ( SIMPLSHARPSTRING name );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER DebugEnable;
        STRING _fileName[];

        // class properties
        DelegateProperty InitializedEvent Initialized;
        DelegateProperty WindowPresetChangedDelegate WindowPresetChanged;
        DelegateProperty WindowPresetChangedDelegate WindowPreset2Changed;
        DelegateProperty OutputValueChangedDelegate OutputValueChanged;
        DelegateProperty PresetCountHandler OnPresetCount;
        DelegateProperty PresetNameHandler OnPresetName;
        DelegateProperty UshortValue Output1Changed;
        DelegateProperty UshortValue Output2Changed;
        DelegateProperty UshortValue Output3Changed;
        DelegateProperty UshortValue Output4Changed;
        DelegateProperty UshortValue Output5Changed;
        DelegateProperty UshortValue Output6Changed;
        DelegateProperty UshortValue Output7Changed;
        DelegateProperty UshortValue Output8Changed;
        DelegateProperty UshortValue Output9Changed;
        DelegateProperty UshortValue Output10Changed;
        DelegateProperty UshortValue Output11Changed;
        DelegateProperty UshortValue Output12Changed;
        DelegateProperty UshortValue Output13Changed;
        DelegateProperty UshortValue Output14Changed;
        DelegateProperty UshortValue Output15Changed;
        DelegateProperty UshortValue Output16Changed;
        DelegateProperty UshortValue Output17Changed;
        DelegateProperty UshortValue Output18Changed;
        DelegateProperty UshortValue Output19Changed;
        DelegateProperty UshortValue Output20Changed;
    };

     class PresetConfig 
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

     class PresetRecord 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER windowPreset1;
        INTEGER windowPreset2;
    };

