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

namespace UserModule_CONFIG_SYSTEM_GROUPANALOG
{
    public class UserModuleClass_CONFIG_SYSTEM_GROUPANALOG : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VALUE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> VALUE_FB;
        StringParameter MANAGERNAME;
        InOutArray<StringParameter> PROPERTYNAME;
        ConfigSystem.Simpl.ConfigValueGroup THECONFIG;
        CrestronString [] CHANGEDPROPERTIES;
        ushort CHANGEDCOUNT = 0;
        ushort GLOBALCOUNTER = 0;
        private void MODULEINITIALIZE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 32;
            CHANGEDCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 33;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)32; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 35;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PROPERTYNAME[ I ] ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 37;
                    THECONFIG . Register ( MANAGERNAME  .ToString(), PROPERTYNAME[ I ] .ToString(), (ushort)( I )) ; 
                    } 
                
                __context__.SourceCodeLine = 33;
                } 
            
            __context__.SourceCodeLine = 40;
            // RegisterEvent( THECONFIG , ONVALUECHANGED , ONVALUECHANGEDHANDLER ) 
            try { g_criticalSection.Enter(); THECONFIG .OnValueChanged  += ONVALUECHANGEDHANDLER; } finally { g_criticalSection.Leave(); }
            ; 
            
            }
            
        object VALUE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 44;
                THECONFIG . SetSingleAnalog ( PROPERTYNAME[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .ToString(), (ushort)( VALUE[ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ] .UshortValue )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public void ONVALUECHANGEDHANDLER ( object __sender__ /*ConfigSystem.Simpl.ConfigValueGroup SENDER */, ConfigSystem.Data.ConfigEventArgs E ) 
        { 
        ConfigValueGroup  SENDER  = (ConfigValueGroup )__sender__;
        try
        {
            SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
            
            __context__.SourceCodeLine = 48;
            VALUE_FB [ E.PropIndex]  .Value = (ushort) ( E.ValueAsAnalog() ) ; 
            
            
        }
        finally { ObjectFinallyHandler(); }
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 52;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 53;
            MODULEINITIALIZE (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        CHANGEDPROPERTIES  = new CrestronString[ 33 ];
        for( uint i = 0; i < 33; i++ )
            CHANGEDPROPERTIES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, this );
        
        VALUE = new InOutArray<AnalogInput>( 32, this );
        for( uint i = 0; i < 32; i++ )
        {
            VALUE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VALUE__AnalogSerialInput__ + i, VALUE__AnalogSerialInput__, this );
            m_AnalogInputList.Add( VALUE__AnalogSerialInput__ + i, VALUE[i+1] );
        }
        
        VALUE_FB = new InOutArray<AnalogOutput>( 32, this );
        for( uint i = 0; i < 32; i++ )
        {
            VALUE_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( VALUE_FB__AnalogSerialOutput__ + i, this );
            m_AnalogOutputList.Add( VALUE_FB__AnalogSerialOutput__ + i, VALUE_FB[i+1] );
        }
        
        MANAGERNAME = new StringParameter( MANAGERNAME__Parameter__, this );
        m_ParameterList.Add( MANAGERNAME__Parameter__, MANAGERNAME );
        
        PROPERTYNAME = new InOutArray<StringParameter>( 32, this );
        for( uint i = 0; i < 32; i++ )
        {
            PROPERTYNAME[i+1] = new StringParameter( PROPERTYNAME__Parameter__ + i, PROPERTYNAME__Parameter__, this );
            m_ParameterList.Add( PROPERTYNAME__Parameter__ + i, PROPERTYNAME[i+1] );
        }
        
        
        for( uint i = 0; i < 32; i++ )
            VALUE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( VALUE_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        THECONFIG  = new ConfigSystem.Simpl.ConfigValueGroup();
        
        
    }
    
    public UserModuleClass_CONFIG_SYSTEM_GROUPANALOG ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint VALUE__AnalogSerialInput__ = 0;
    const uint VALUE_FB__AnalogSerialOutput__ = 0;
    const uint MANAGERNAME__Parameter__ = 10;
    const uint PROPERTYNAME__Parameter__ = 11;
    
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
