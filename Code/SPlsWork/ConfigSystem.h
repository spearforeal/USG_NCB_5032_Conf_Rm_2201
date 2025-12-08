namespace ConfigSystem;
        // class declarations
         class ConfigSystemStatics;
         class Logger;
     class ConfigSystemStatics 
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

    static class Logger 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION Debug ( STRING message );
        static FUNCTION Warn ( STRING message );
        static FUNCTION Error ( STRING message );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace ConfigSystem.Simpl;
        // class declarations
         class ConfigValue;
         class ConfigValueGroup;
           class ConfigEventArgs;
     class ConfigValue 
    {
        // class delegates

        // class events
        EventHandler OnValueChanged ( ConfigValue sender, ConfigEventArgs e );

        // class functions
        FUNCTION Register ( STRING managerName , STRING valueName , INTEGER simplIndex );
        FUNCTION SetSingleAnalog ( INTEGER newValue );
        FUNCTION SetSingleDigital ( INTEGER newValue );
        FUNCTION ToggleSingleDigital ();
        FUNCTION SetSingleSerial ( STRING newValue );
        FUNCTION SetBlockAnalog ( INTEGER i , INTEGER newValue );
        FUNCTION SetBlockDigital ( INTEGER i , INTEGER newValue );
        FUNCTION ToggleBlockDigital ( INTEGER i );
        FUNCTION SetBlockSerial ( INTEGER i , STRING newValue );
        FUNCTION RaiseOnValueChanged ( SIGNED_LONG_INTEGER index , STRING newValue );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER SimplIndex;
        STRING Name[];
    };

     class ConfigValueGroup 
    {
        // class delegates

        // class events
        EventHandler OnValueChanged ( ConfigValueGroup sender, ConfigEventArgs e );

        // class functions
        FUNCTION Register ( STRING managerName , STRING valueName , INTEGER valueIndex );
        FUNCTION SetSingleAnalog ( STRING name , INTEGER value );
        FUNCTION SetSingleDigital ( STRING name , INTEGER value );
        FUNCTION ToggleSingleDigital ( STRING name );
        FUNCTION SetSingleSerial ( STRING name , STRING value );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace ConfigSystem.Preset;
        // class declarations
         class PresetClient;
         class PresetConnector;
         class PresetInstance;
         class PresetManager;
     class PresetClient 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Register ( STRING managerName , STRING name , INTEGER Load , INTEGER array );
        FUNCTION TellManagerYourValue ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Load;
        STRING Name[];
        STRING ManagerName[];
    };

     class PresetConnector 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION RegisterManager ( STRING name , PresetManager m );
        static FUNCTION RegisterClient ( PresetClient c );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PresetInstance 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        STRING Name[];

        // class properties
    };

     class PresetManager 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION RegisterModule ( STRING managerName );
        FUNCTION RegisterClient ( PresetClient c );
        FUNCTION RecallPreset ( INTEGER index );
        STRING_FUNCTION GetName ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
    };

namespace ConfigSystem.Manager;
        // class declarations
         class FileManager;
         class FileManagerBase;
         class FileStatusEventArgs;
         class MultiFileManager;
     class FileManager 
    {
        // class delegates

        // class events
        EventHandler OnValuesChanged ( FileManager sender, EventArgs e );
        EventHandler OnLoadingStatusChanged ( FileManager sender, FileStatusEventArgs e );

        // class functions
        FUNCTION Initialize ( STRING file );
        FUNCTION SetMode ( SIMPLSHARPSTRING mode );
        FUNCTION SaveRequest ();
        FUNCTION LoadRequest ();
        FUNCTION NotifyChanges ();
        FUNCTION NotifyChangeStatus ( FileStatusEventArgs e );
        STRING_FUNCTION GetEncoding ();
        FUNCTION SetEncoding ( STRING e );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING FileName[];
    };

     class FileManagerBase 
    {
        // class delegates

        // class events
        EventHandler OnValuesChanged ( FileManagerBase sender, EventArgs e );
        EventHandler OnLoadingStatusChanged ( FileManagerBase sender, FileStatusEventArgs e );

        // class functions
        FUNCTION SetMode ( SIMPLSHARPSTRING mode );
        FUNCTION SaveRequest ();
        FUNCTION LoadRequest ();
        FUNCTION NotifyChanges ();
        FUNCTION NotifyChangeStatus ( FileStatusEventArgs e );
        STRING_FUNCTION GetEncoding ();
        FUNCTION SetEncoding ( STRING e );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class FileStatusEventArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        FileStatusEventArgs Loaded;
        FileStatusEventArgs Saved;
        FileStatusEventArgs Nonexistent;
        FileStatusEventArgs Invalid;
        FileStatusEventArgs Loading;
        FileStatusEventArgs Saving;
        INTEGER LoadingComplete;
        INTEGER SaveComplete;
        INTEGER NonexistentConfig;
        INTEGER InvalidConfig;
        INTEGER LoadingInProgress;
        INTEGER SavingInProgress;
    };

     class MultiFileManager 
    {
        // class delegates

        // class events
        EventHandler OnValuesChanged ( MultiFileManager sender, EventArgs e );
        EventHandler OnLoadingStatusChanged ( MultiFileManager sender, FileStatusEventArgs e );

        // class functions
        FUNCTION Initialize ( STRING path , STRING ext );
        FUNCTION SetMode ( SIMPLSHARPSTRING mode );
        FUNCTION SaveRequest ();
        FUNCTION LoadRequest ();
        FUNCTION NotifyChanges ();
        FUNCTION NotifyChangeStatus ( FileStatusEventArgs e );
        STRING_FUNCTION GetEncoding ();
        FUNCTION SetEncoding ( STRING e );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING FilePath[];
        STRING FileExtension[];
    };

namespace ConfigSystem.Data;
        // class declarations
         class ConfigEventArgs;
         class ConfigValueManager;
         class OneIndexedArray;
         class ValueChangedEventArgs;
     class ConfigEventArgs 
    {
        // class delegates

        // class events

        // class functions
        INTEGER_FUNCTION ValueAsAnalog ();
        INTEGER_FUNCTION ValueAsDigital ();
        STRING_FUNCTION ValueAsSerial ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Prop[];
        INTEGER PropIndex;
        INTEGER ValueIndex;
        STRING NewValue[];
    };

     class OneIndexedArray 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Set ( SIGNED_LONG_INTEGER index , STRING v );
        STRING_FUNCTION Get ( SIGNED_LONG_INTEGER index );
        FUNCTION Add ( STRING item );
        FUNCTION Clear ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

