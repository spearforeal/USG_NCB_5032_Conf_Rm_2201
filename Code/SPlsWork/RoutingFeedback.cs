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

namespace UserModule_ROUTINGFEEDBACK
{
    public class UserModuleClass_ROUTINGFEEDBACK : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> FEEDBACK;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> INPUT_NAMES;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> OUTPUT_SOURCE_FB;
        ushort X = 0;
        ushort Y = 0;
        object FEEDBACK_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 11;
                X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 12;
                Y = (ushort) ( FEEDBACK[ X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 13;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Y > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 15;
                    OUTPUT_SOURCE_FB [ X]  .UpdateValue ( INPUT_NAMES [ Y ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 17;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Y == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 19;
                        OUTPUT_SOURCE_FB [ X]  .UpdateValue ( "No Source"  ) ; 
                        } 
                    
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        FEEDBACK = new InOutArray<AnalogInput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            FEEDBACK[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( FEEDBACK__AnalogSerialInput__ + i, FEEDBACK__AnalogSerialInput__, this );
            m_AnalogInputList.Add( FEEDBACK__AnalogSerialInput__ + i, FEEDBACK[i+1] );
        }
        
        INPUT_NAMES = new InOutArray<StringInput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            INPUT_NAMES[i+1] = new Crestron.Logos.SplusObjects.StringInput( INPUT_NAMES__AnalogSerialInput__ + i, INPUT_NAMES__AnalogSerialInput__, 100, this );
            m_StringInputList.Add( INPUT_NAMES__AnalogSerialInput__ + i, INPUT_NAMES[i+1] );
        }
        
        OUTPUT_SOURCE_FB = new InOutArray<StringOutput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            OUTPUT_SOURCE_FB[i+1] = new Crestron.Logos.SplusObjects.StringOutput( OUTPUT_SOURCE_FB__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( OUTPUT_SOURCE_FB__AnalogSerialOutput__ + i, OUTPUT_SOURCE_FB[i+1] );
        }
        
        
        for( uint i = 0; i < 128; i++ )
            FEEDBACK[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( FEEDBACK_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_ROUTINGFEEDBACK ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint FEEDBACK__AnalogSerialInput__ = 0;
    const uint INPUT_NAMES__AnalogSerialInput__ = 128;
    const uint OUTPUT_SOURCE_FB__AnalogSerialOutput__ = 0;
    
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
