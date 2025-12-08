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

namespace UserModule_CONFIG_SYSTEM_BLOCKDIGITAL
{
    public class UserModuleClass_CONFIG_SYSTEM_BLOCKDIGITAL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SETON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SETOFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> TOGGLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> ONFB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> OFFFB;
        StringParameter MANAGERNAME;
        StringParameter VALUENAME;
        ConfigSystem.Simpl.ConfigValue THECONFIG;
        private void MODULEINITIALIZE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 29;
            THECONFIG . Register ( MANAGERNAME  .ToString(), VALUENAME  .ToString(), (ushort)( 1 )) ; 
            __context__.SourceCodeLine = 31;
            // RegisterEvent( THECONFIG , ONVALUECHANGED , ONVALUECHANGEDHANDLER ) 
            try { g_criticalSection.Enter(); THECONFIG .OnValueChanged  += ONVALUECHANGEDHANDLER; } finally { g_criticalSection.Leave(); }
            ; 
            
            }
            
        object SETON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 35;
                THECONFIG . SetBlockDigital ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 1 )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SETOFF_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 40;
            THECONFIG . SetBlockDigital ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ), (ushort)( 0 )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object TOGGLE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 45;
        THECONFIG . ToggleBlockDigital ( (ushort)( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void ONVALUECHANGEDHANDLER ( object __sender__ /*ConfigSystem.Simpl.ConfigValue SENDER */, ConfigSystem.Data.ConfigEventArgs ARGS ) 
    { 
    ConfigValue  SENDER  = (ConfigValue )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 50;
        ONFB [ ARGS.ValueIndex]  .Value = (ushort) ( ARGS.ValueAsDigital() ) ; 
        __context__.SourceCodeLine = 51;
        OFFFB [ ARGS.ValueIndex]  .Value = (ushort) ( Functions.Not( ARGS.ValueAsDigital() ) ) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 55;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 57;
        MODULEINITIALIZE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SETON = new InOutArray<DigitalInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        SETON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SETON__DigitalInput__ + i, SETON__DigitalInput__, this );
        m_DigitalInputList.Add( SETON__DigitalInput__ + i, SETON[i+1] );
    }
    
    SETOFF = new InOutArray<DigitalInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        SETOFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SETOFF__DigitalInput__ + i, SETOFF__DigitalInput__, this );
        m_DigitalInputList.Add( SETOFF__DigitalInput__ + i, SETOFF[i+1] );
    }
    
    TOGGLE = new InOutArray<DigitalInput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( TOGGLE__DigitalInput__ + i, TOGGLE__DigitalInput__, this );
        m_DigitalInputList.Add( TOGGLE__DigitalInput__ + i, TOGGLE[i+1] );
    }
    
    ONFB = new InOutArray<DigitalOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        ONFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( ONFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( ONFB__DigitalOutput__ + i, ONFB[i+1] );
    }
    
    OFFFB = new InOutArray<DigitalOutput>( 32, this );
    for( uint i = 0; i < 32; i++ )
    {
        OFFFB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( OFFFB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( OFFFB__DigitalOutput__ + i, OFFFB[i+1] );
    }
    
    MANAGERNAME = new StringParameter( MANAGERNAME__Parameter__, this );
    m_ParameterList.Add( MANAGERNAME__Parameter__, MANAGERNAME );
    
    VALUENAME = new StringParameter( VALUENAME__Parameter__, this );
    m_ParameterList.Add( VALUENAME__Parameter__, VALUENAME );
    
    
    for( uint i = 0; i < 32; i++ )
        SETON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SETON_OnPush_0, false ) );
        
    for( uint i = 0; i < 32; i++ )
        SETOFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SETOFF_OnPush_1, false ) );
        
    for( uint i = 0; i < 32; i++ )
        TOGGLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( TOGGLE_OnPush_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    THECONFIG  = new ConfigSystem.Simpl.ConfigValue();
    
    
}

public UserModuleClass_CONFIG_SYSTEM_BLOCKDIGITAL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SETON__DigitalInput__ = 0;
const uint SETOFF__DigitalInput__ = 32;
const uint TOGGLE__DigitalInput__ = 64;
const uint ONFB__DigitalOutput__ = 0;
const uint OFFFB__DigitalOutput__ = 32;
const uint MANAGERNAME__Parameter__ = 10;
const uint VALUENAME__Parameter__ = 11;

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
