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

namespace UserModule_ANALOGROUTER
{
    public class UserModuleClass_ANALOGROUTER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput SOURCE0;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SOURCE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DESTSEL;
        Crestron.Logos.SplusObjects.DigitalOutput SOURCE0_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> SOURCE_FB;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DEST;
        ushort SOURCEVALUE = 0;
        private void SETFEEDBACK (  SplusExecutionContext __context__, ushort SRCINDEX ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 22;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)25; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 24;
                SOURCE_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 22;
                } 
            
            __context__.SourceCodeLine = 26;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SRCINDEX == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 28;
                SOURCE0_FB  .Value = (ushort) ( 1 ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 32;
                SOURCE0_FB  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 33;
                SOURCE_FB [ SRCINDEX]  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            }
            
        private void ROUTETODEST (  SplusExecutionContext __context__, ushort D ) 
            { 
            
            __context__.SourceCodeLine = 39;
            DEST [ D]  .Value = (ushort) ( SOURCEVALUE ) ; 
            
            }
            
        object SOURCE0_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 42;
                SOURCEVALUE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 43;
                SETFEEDBACK (  __context__ , (ushort)( SOURCEVALUE )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SOURCE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort N = 0;
            
            
            __context__.SourceCodeLine = 48;
            N = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 49;
            SOURCEVALUE = (ushort) ( N ) ; 
            __context__.SourceCodeLine = 50;
            SETFEEDBACK (  __context__ , (ushort)( N )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object DESTSEL_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort N = 0;
        
        
        __context__.SourceCodeLine = 55;
        N = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 56;
        ROUTETODEST (  __context__ , (ushort)( N )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    SOURCE0 = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE0__DigitalInput__, this );
    m_DigitalInputList.Add( SOURCE0__DigitalInput__, SOURCE0 );
    
    SOURCE = new InOutArray<DigitalInput>( 25, this );
    for( uint i = 0; i < 25; i++ )
    {
        SOURCE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SOURCE__DigitalInput__ + i, SOURCE__DigitalInput__, this );
        m_DigitalInputList.Add( SOURCE__DigitalInput__ + i, SOURCE[i+1] );
    }
    
    DESTSEL = new InOutArray<DigitalInput>( 25, this );
    for( uint i = 0; i < 25; i++ )
    {
        DESTSEL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DESTSEL__DigitalInput__ + i, DESTSEL__DigitalInput__, this );
        m_DigitalInputList.Add( DESTSEL__DigitalInput__ + i, DESTSEL[i+1] );
    }
    
    SOURCE0_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE0_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SOURCE0_FB__DigitalOutput__, SOURCE0_FB );
    
    SOURCE_FB = new InOutArray<DigitalOutput>( 25, this );
    for( uint i = 0; i < 25; i++ )
    {
        SOURCE_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( SOURCE_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( SOURCE_FB__DigitalOutput__ + i, SOURCE_FB[i+1] );
    }
    
    DEST = new InOutArray<AnalogOutput>( 25, this );
    for( uint i = 0; i < 25; i++ )
    {
        DEST[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DEST__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DEST__AnalogSerialOutput__ + i, DEST[i+1] );
    }
    
    
    SOURCE0.OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE0_OnPush_0, false ) );
    for( uint i = 0; i < 25; i++ )
        SOURCE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SOURCE_OnPush_1, false ) );
        
    for( uint i = 0; i < 25; i++ )
        DESTSEL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DESTSEL_OnPush_2, false ) );
        
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_ANALOGROUTER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SOURCE0__DigitalInput__ = 0;
const uint SOURCE__DigitalInput__ = 1;
const uint DESTSEL__DigitalInput__ = 26;
const uint SOURCE0_FB__DigitalOutput__ = 0;
const uint SOURCE_FB__DigitalOutput__ = 1;
const uint DEST__AnalogSerialOutput__ = 0;

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
