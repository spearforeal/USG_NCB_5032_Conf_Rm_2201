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

namespace UserModule_DESTCONFIG
{
    public class UserModuleClass_DESTCONFIG : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DESTVIS;
        Crestron.Logos.SplusObjects.AnalogOutput VISIBLECOUNT;
        ushort GCOUNT = 0;
        private void RECALC (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            ushort C = 0;
            
            
            __context__.SourceCodeLine = 10;
            C = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 11;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)20; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 13;
                if ( Functions.TestForTrue  ( ( DESTVIS[ I ] .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 13;
                    C = (ushort) ( (C + 1) ) ; 
                    }
                
                __context__.SourceCodeLine = 11;
                } 
            
            __context__.SourceCodeLine = 15;
            GCOUNT = (ushort) ( C ) ; 
            __context__.SourceCodeLine = 16;
            VISIBLECOUNT  .Value = (ushort) ( GCOUNT ) ; 
            
            }
            
        object DESTVIS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 21;
                RECALC (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 25;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 26;
            RECALC (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        DESTVIS = new InOutArray<DigitalInput>( 20, this );
        for( uint i = 0; i < 20; i++ )
        {
            DESTVIS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DESTVIS__DigitalInput__ + i, DESTVIS__DigitalInput__, this );
            m_DigitalInputList.Add( DESTVIS__DigitalInput__ + i, DESTVIS[i+1] );
        }
        
        VISIBLECOUNT = new Crestron.Logos.SplusObjects.AnalogOutput( VISIBLECOUNT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( VISIBLECOUNT__AnalogSerialOutput__, VISIBLECOUNT );
        
        
        for( uint i = 0; i < 20; i++ )
            DESTVIS[i+1].OnDigitalChange.Add( new InputChangeHandlerWrapper( DESTVIS_OnChange_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_DESTCONFIG ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint DESTVIS__DigitalInput__ = 0;
    const uint VISIBLECOUNT__AnalogSerialOutput__ = 0;
    
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
