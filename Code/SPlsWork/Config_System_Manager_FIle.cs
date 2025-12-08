using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using ConfigSystem;
using ConfigSystem.Simpl;
using ConfigSystem.Preset;
using ConfigSystem.Manager;
using ConfigSystem.Data;
using Crestron.SimplSharp.SimplSharpCloudClient;
using Crestron.SimplSharp.Python;

namespace UserModule_CONFIG_SYSTEM_MANAGER_FILE
{
    public class UserModuleClass_CONFIG_SYSTEM_MANAGER_FILE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput LOAD;
        Crestron.Logos.SplusObjects.DigitalInput SAVE;
        Crestron.Logos.SplusObjects.StringInput OVERRIDESTORAGELOCATION;
        Crestron.Logos.SplusObjects.StringInput OVERRIDEPROGRAMNAME;
        Crestron.Logos.SplusObjects.StringInput OVERRIDEFILENAME;
        Crestron.Logos.SplusObjects.StringInput OVERRIDEENCODING;
        Crestron.Logos.SplusObjects.DigitalOutput LOADINGFB;
        Crestron.Logos.SplusObjects.DigitalOutput SAVINGFB;
        Crestron.Logos.SplusObjects.DigitalOutput FILELOADED;
        Crestron.Logos.SplusObjects.DigitalOutput FILESAVED;
        Crestron.Logos.SplusObjects.DigitalOutput FILEMISSING;
        Crestron.Logos.SplusObjects.DigitalOutput FILEINVALID;
        Crestron.Logos.SplusObjects.DigitalOutput UNSAVEDCHANGES;
        Crestron.Logos.SplusObjects.StringOutput FILEMESSAGE;
        StringParameter FILE_NAME;
        StringParameter STORAGE_LOCATION;
        StringParameter PROGRAM_NAME;
        StringParameter FILE_MODE;
        StringParameter FILE_ENCODING;
        ConfigSystem.Manager.FileManager MANAGER;
        CrestronString CLOCALPATH;
        CrestronString OSTORAGELOCATION;
        CrestronString OPROGRAMNAME;
        CrestronString OFILENAME;
        private void SETFILEPATH (  SplusExecutionContext __context__ ) 
            { 
            CrestronString LSTORAGELOCATION;
            LSTORAGELOCATION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            CrestronString LPROGRAMNAME;
            LPROGRAMNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            CrestronString LFILENAME;
            LFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
            
            
            __context__.SourceCodeLine = 67;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( OSTORAGELOCATION ) > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 68;
                LSTORAGELOCATION  .UpdateValue ( OSTORAGELOCATION  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 70;
                LSTORAGELOCATION  .UpdateValue ( STORAGE_LOCATION  ) ; 
                }
            
            __context__.SourceCodeLine = 72;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( OPROGRAMNAME ) > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 73;
                LPROGRAMNAME  .UpdateValue ( OPROGRAMNAME  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 75;
                LPROGRAMNAME  .UpdateValue ( PROGRAM_NAME  ) ; 
                }
            
            __context__.SourceCodeLine = 77;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( OFILENAME ) > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 78;
                LFILENAME  .UpdateValue ( OFILENAME  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 80;
                LFILENAME  .UpdateValue ( FILE_NAME  ) ; 
                }
            
            __context__.SourceCodeLine = 83;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PROGRAM_NAME  != ""))  ) ) 
                {
                __context__.SourceCodeLine = 83;
                CLOCALPATH  .UpdateValue ( "\\" + LSTORAGELOCATION + "\\" + LPROGRAMNAME + "\\" + LFILENAME  ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 84;
                CLOCALPATH  .UpdateValue ( "\\" + LSTORAGELOCATION + "\\" + LFILENAME  ) ; 
                }
            
            __context__.SourceCodeLine = 86;
            MANAGER . Initialize ( CLOCALPATH .ToString()) ; 
            
            }
            
        private void MODULEINITIALIZE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 90;
            MANAGER . SetMode ( FILE_MODE  .ToSimplSharpString()) ; 
            __context__.SourceCodeLine = 91;
            SETFILEPATH (  __context__  ) ; 
            __context__.SourceCodeLine = 92;
            MANAGER . SetEncoding ( FILE_ENCODING  .ToString()) ; 
            __context__.SourceCodeLine = 94;
            // RegisterEvent( MANAGER , ONLOADINGSTATUSCHANGED , ONLOADINGSTATUSCHANGEDHANDLER ) 
            try { g_criticalSection.Enter(); MANAGER .OnLoadingStatusChanged  += ONLOADINGSTATUSCHANGEDHANDLER; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 95;
            // RegisterEvent( MANAGER , ONVALUESCHANGED , ONVALUESCHANGEDHANDLER ) 
            try { g_criticalSection.Enter(); MANAGER .OnValuesChanged  += ONVALUESCHANGEDHANDLER; } finally { g_criticalSection.Leave(); }
            ; 
            
            }
            
        private void SENDCONFIGMESSAGE (  SplusExecutionContext __context__, CrestronString MESSAGE ) 
            { 
            
            __context__.SourceCodeLine = 100;
            MakeString ( FILEMESSAGE , "{0}", MESSAGE ) ; 
            
            }
            
        object LOAD_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 104;
                MANAGER . LoadRequest ( ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SAVE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 109;
            MANAGER . SaveRequest ( ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object OVERRIDESTORAGELOCATION_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 114;
        OSTORAGELOCATION  .UpdateValue ( OVERRIDESTORAGELOCATION  ) ; 
        __context__.SourceCodeLine = 115;
        SETFILEPATH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OVERRIDEPROGRAMNAME_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 120;
        OPROGRAMNAME  .UpdateValue ( OVERRIDEPROGRAMNAME  ) ; 
        __context__.SourceCodeLine = 121;
        SETFILEPATH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OVERRIDEFILENAME_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 126;
        OFILENAME  .UpdateValue ( OVERRIDEFILENAME  ) ; 
        __context__.SourceCodeLine = 127;
        SETFILEPATH (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object OVERRIDEENCODING_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 132;
        MANAGER . SetEncoding ( OVERRIDEENCODING .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void ONLOADINGSTATUSCHANGEDHANDLER ( object __sender__ /*ConfigSystem.Manager.FileManager SENDER */, ConfigSystem.Manager.FileStatusEventArgs ARGS ) 
    { 
    FileManager  SENDER  = (FileManager )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 137;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.LoadingComplete == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 139;
            SENDCONFIGMESSAGE (  __context__ , "Config Loaded") ; 
            __context__.SourceCodeLine = 140;
            FILELOADED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 144;
            FILELOADED  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 147;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.SaveComplete == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 149;
            SENDCONFIGMESSAGE (  __context__ , "Config Saved") ; 
            __context__.SourceCodeLine = 150;
            FILESAVED  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 154;
            FILESAVED  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 157;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.NonexistentConfig == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 159;
            SENDCONFIGMESSAGE (  __context__ , "Config File Missing") ; 
            __context__.SourceCodeLine = 160;
            FILEMISSING  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 164;
            FILEMISSING  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 167;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.InvalidConfig == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 169;
            SENDCONFIGMESSAGE (  __context__ , "Config File Invalid") ; 
            __context__.SourceCodeLine = 170;
            FILEINVALID  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 174;
            FILEINVALID  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 177;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.LoadingInProgress == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 179;
            SENDCONFIGMESSAGE (  __context__ , "Config Beginning Load") ; 
            __context__.SourceCodeLine = 180;
            LOADINGFB  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 184;
            LOADINGFB  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 187;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ARGS.SavingInProgress == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 189;
            SENDCONFIGMESSAGE (  __context__ , "Config Beginning Save") ; 
            __context__.SourceCodeLine = 190;
            SAVINGFB  .Value = (ushort) ( 1 ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 194;
            SAVINGFB  .Value = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 197;
        UNSAVEDCHANGES  .Value = (ushort) ( 0 ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public void ONVALUESCHANGEDHANDLER ( object __sender__ /*ConfigSystem.Manager.FileManager SENDER */, EventArgs ARGS ) 
    { 
    FileManager  SENDER  = (FileManager )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 202;
        SENDCONFIGMESSAGE (  __context__ , "Values have Changed") ; 
        __context__.SourceCodeLine = 203;
        FILELOADED  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 204;
        FILESAVED  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 205;
        FILEMISSING  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 206;
        FILEINVALID  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 207;
        UNSAVEDCHANGES  .Value = (ushort) ( 1 ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 212;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 214;
        MODULEINITIALIZE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    CLOCALPATH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    OSTORAGELOCATION  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    OPROGRAMNAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    OFILENAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
    
    LOAD = new Crestron.Logos.SplusObjects.DigitalInput( LOAD__DigitalInput__, this );
    m_DigitalInputList.Add( LOAD__DigitalInput__, LOAD );
    
    SAVE = new Crestron.Logos.SplusObjects.DigitalInput( SAVE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE__DigitalInput__, SAVE );
    
    LOADINGFB = new Crestron.Logos.SplusObjects.DigitalOutput( LOADINGFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( LOADINGFB__DigitalOutput__, LOADINGFB );
    
    SAVINGFB = new Crestron.Logos.SplusObjects.DigitalOutput( SAVINGFB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SAVINGFB__DigitalOutput__, SAVINGFB );
    
    FILELOADED = new Crestron.Logos.SplusObjects.DigitalOutput( FILELOADED__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILELOADED__DigitalOutput__, FILELOADED );
    
    FILESAVED = new Crestron.Logos.SplusObjects.DigitalOutput( FILESAVED__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILESAVED__DigitalOutput__, FILESAVED );
    
    FILEMISSING = new Crestron.Logos.SplusObjects.DigitalOutput( FILEMISSING__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILEMISSING__DigitalOutput__, FILEMISSING );
    
    FILEINVALID = new Crestron.Logos.SplusObjects.DigitalOutput( FILEINVALID__DigitalOutput__, this );
    m_DigitalOutputList.Add( FILEINVALID__DigitalOutput__, FILEINVALID );
    
    UNSAVEDCHANGES = new Crestron.Logos.SplusObjects.DigitalOutput( UNSAVEDCHANGES__DigitalOutput__, this );
    m_DigitalOutputList.Add( UNSAVEDCHANGES__DigitalOutput__, UNSAVEDCHANGES );
    
    OVERRIDESTORAGELOCATION = new Crestron.Logos.SplusObjects.StringInput( OVERRIDESTORAGELOCATION__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( OVERRIDESTORAGELOCATION__AnalogSerialInput__, OVERRIDESTORAGELOCATION );
    
    OVERRIDEPROGRAMNAME = new Crestron.Logos.SplusObjects.StringInput( OVERRIDEPROGRAMNAME__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( OVERRIDEPROGRAMNAME__AnalogSerialInput__, OVERRIDEPROGRAMNAME );
    
    OVERRIDEFILENAME = new Crestron.Logos.SplusObjects.StringInput( OVERRIDEFILENAME__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( OVERRIDEFILENAME__AnalogSerialInput__, OVERRIDEFILENAME );
    
    OVERRIDEENCODING = new Crestron.Logos.SplusObjects.StringInput( OVERRIDEENCODING__AnalogSerialInput__, 50, this );
    m_StringInputList.Add( OVERRIDEENCODING__AnalogSerialInput__, OVERRIDEENCODING );
    
    FILEMESSAGE = new Crestron.Logos.SplusObjects.StringOutput( FILEMESSAGE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FILEMESSAGE__AnalogSerialOutput__, FILEMESSAGE );
    
    FILE_NAME = new StringParameter( FILE_NAME__Parameter__, this );
    m_ParameterList.Add( FILE_NAME__Parameter__, FILE_NAME );
    
    STORAGE_LOCATION = new StringParameter( STORAGE_LOCATION__Parameter__, this );
    m_ParameterList.Add( STORAGE_LOCATION__Parameter__, STORAGE_LOCATION );
    
    PROGRAM_NAME = new StringParameter( PROGRAM_NAME__Parameter__, this );
    m_ParameterList.Add( PROGRAM_NAME__Parameter__, PROGRAM_NAME );
    
    FILE_MODE = new StringParameter( FILE_MODE__Parameter__, this );
    m_ParameterList.Add( FILE_MODE__Parameter__, FILE_MODE );
    
    FILE_ENCODING = new StringParameter( FILE_ENCODING__Parameter__, this );
    m_ParameterList.Add( FILE_ENCODING__Parameter__, FILE_ENCODING );
    
    
    LOAD.OnDigitalPush.Add( new InputChangeHandlerWrapper( LOAD_OnPush_0, false ) );
    SAVE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_OnPush_1, false ) );
    OVERRIDESTORAGELOCATION.OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDESTORAGELOCATION_OnChange_2, false ) );
    OVERRIDEPROGRAMNAME.OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDEPROGRAMNAME_OnChange_3, false ) );
    OVERRIDEFILENAME.OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDEFILENAME_OnChange_4, false ) );
    OVERRIDEENCODING.OnSerialChange.Add( new InputChangeHandlerWrapper( OVERRIDEENCODING_OnChange_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    MANAGER  = new ConfigSystem.Manager.FileManager();
    
    
}

public UserModuleClass_CONFIG_SYSTEM_MANAGER_FILE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint LOAD__DigitalInput__ = 0;
const uint SAVE__DigitalInput__ = 1;
const uint OVERRIDESTORAGELOCATION__AnalogSerialInput__ = 0;
const uint OVERRIDEPROGRAMNAME__AnalogSerialInput__ = 1;
const uint OVERRIDEFILENAME__AnalogSerialInput__ = 2;
const uint OVERRIDEENCODING__AnalogSerialInput__ = 3;
const uint LOADINGFB__DigitalOutput__ = 0;
const uint SAVINGFB__DigitalOutput__ = 1;
const uint FILELOADED__DigitalOutput__ = 2;
const uint FILESAVED__DigitalOutput__ = 3;
const uint FILEMISSING__DigitalOutput__ = 4;
const uint FILEINVALID__DigitalOutput__ = 5;
const uint UNSAVEDCHANGES__DigitalOutput__ = 6;
const uint FILEMESSAGE__AnalogSerialOutput__ = 0;
const uint FILE_NAME__Parameter__ = 10;
const uint STORAGE_LOCATION__Parameter__ = 11;
const uint PROGRAM_NAME__Parameter__ = 12;
const uint FILE_MODE__Parameter__ = 13;
const uint FILE_ENCODING__Parameter__ = 14;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
