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

namespace UserModule_NVX_STREAM_ROUTING
{
    public class UserModuleClass_NVX_STREAM_ROUTING : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> VIDEO_SOURCE;
        InOutArray<Crestron.Logos.SplusObjects.StringInput> ENCODER_STREAM_LOCATION;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> DECODER_STREAM_LOCATION;
        ushort X = 0;
        ushort Y = 0;
        object VIDEO_SOURCE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 11;
                X = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                __context__.SourceCodeLine = 12;
                Y = (ushort) ( VIDEO_SOURCE[ X ] .UshortValue ) ; 
                __context__.SourceCodeLine = 14;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Y > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 16;
                    DECODER_STREAM_LOCATION [ X]  .UpdateValue ( ENCODER_STREAM_LOCATION [ Y ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 18;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Y == 0))  ) ) 
                        { 
                        __context__.SourceCodeLine = 20;
                        DECODER_STREAM_LOCATION [ X]  .UpdateValue ( " "  ) ; 
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
        
        VIDEO_SOURCE = new InOutArray<AnalogInput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            VIDEO_SOURCE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( VIDEO_SOURCE__AnalogSerialInput__ + i, VIDEO_SOURCE__AnalogSerialInput__, this );
            m_AnalogInputList.Add( VIDEO_SOURCE__AnalogSerialInput__ + i, VIDEO_SOURCE[i+1] );
        }
        
        ENCODER_STREAM_LOCATION = new InOutArray<StringInput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            ENCODER_STREAM_LOCATION[i+1] = new Crestron.Logos.SplusObjects.StringInput( ENCODER_STREAM_LOCATION__AnalogSerialInput__ + i, ENCODER_STREAM_LOCATION__AnalogSerialInput__, 100, this );
            m_StringInputList.Add( ENCODER_STREAM_LOCATION__AnalogSerialInput__ + i, ENCODER_STREAM_LOCATION[i+1] );
        }
        
        DECODER_STREAM_LOCATION = new InOutArray<StringOutput>( 128, this );
        for( uint i = 0; i < 128; i++ )
        {
            DECODER_STREAM_LOCATION[i+1] = new Crestron.Logos.SplusObjects.StringOutput( DECODER_STREAM_LOCATION__AnalogSerialOutput__ + i, this );
            m_StringOutputList.Add( DECODER_STREAM_LOCATION__AnalogSerialOutput__ + i, DECODER_STREAM_LOCATION[i+1] );
        }
        
        
        for( uint i = 0; i < 128; i++ )
            VIDEO_SOURCE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( VIDEO_SOURCE_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_NVX_STREAM_ROUTING ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint VIDEO_SOURCE__AnalogSerialInput__ = 0;
    const uint ENCODER_STREAM_LOCATION__AnalogSerialInput__ = 128;
    const uint DECODER_STREAM_LOCATION__AnalogSerialOutput__ = 0;
    
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
