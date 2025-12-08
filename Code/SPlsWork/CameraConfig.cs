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

namespace UserModule_CAMERACONFIG
{
    public class UserModuleClass_CAMERACONFIG : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput CAM1;
        Crestron.Logos.SplusObjects.DigitalInput CAM2;
        Crestron.Logos.SplusObjects.DigitalInput CAM3;
        Crestron.Logos.SplusObjects.DigitalInput CAM4;
        Crestron.Logos.SplusObjects.DigitalInput CAM5;
        Crestron.Logos.SplusObjects.DigitalInput CAM6;
        Crestron.Logos.SplusObjects.AnalogOutput VISIBLECOUNT;
        ushort GCOUNT = 0;
        private void RECALC (  SplusExecutionContext __context__ ) 
            { 
            ushort C = 0;
            
            
            __context__.SourceCodeLine = 130;
            C = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 131;
            if ( Functions.TestForTrue  ( ( CAM1  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 131;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( CAM2  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 132;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 133;
            if ( Functions.TestForTrue  ( ( CAM3  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 133;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 134;
            if ( Functions.TestForTrue  ( ( CAM4  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 134;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 135;
            if ( Functions.TestForTrue  ( ( CAM5  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 135;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 136;
            if ( Functions.TestForTrue  ( ( CAM6  .Value)  ) ) 
                {
                __context__.SourceCodeLine = 136;
                C = (ushort) ( (C + 1) ) ; 
                }
            
            __context__.SourceCodeLine = 138;
            GCOUNT = (ushort) ( C ) ; 
            __context__.SourceCodeLine = 139;
            VISIBLECOUNT  .Value = (ushort) ( GCOUNT ) ; 
            
            }
            
        object CAM1_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 185;
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
            
            __context__.SourceCodeLine = 235;
            WaitForInitializationComplete ( ) ; 
            __context__.SourceCodeLine = 236;
            RECALC (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        CAM1 = new Crestron.Logos.SplusObjects.DigitalInput( CAM1__DigitalInput__, this );
        m_DigitalInputList.Add( CAM1__DigitalInput__, CAM1 );
        
        CAM2 = new Crestron.Logos.SplusObjects.DigitalInput( CAM2__DigitalInput__, this );
        m_DigitalInputList.Add( CAM2__DigitalInput__, CAM2 );
        
        CAM3 = new Crestron.Logos.SplusObjects.DigitalInput( CAM3__DigitalInput__, this );
        m_DigitalInputList.Add( CAM3__DigitalInput__, CAM3 );
        
        CAM4 = new Crestron.Logos.SplusObjects.DigitalInput( CAM4__DigitalInput__, this );
        m_DigitalInputList.Add( CAM4__DigitalInput__, CAM4 );
        
        CAM5 = new Crestron.Logos.SplusObjects.DigitalInput( CAM5__DigitalInput__, this );
        m_DigitalInputList.Add( CAM5__DigitalInput__, CAM5 );
        
        CAM6 = new Crestron.Logos.SplusObjects.DigitalInput( CAM6__DigitalInput__, this );
        m_DigitalInputList.Add( CAM6__DigitalInput__, CAM6 );
        
        VISIBLECOUNT = new Crestron.Logos.SplusObjects.AnalogOutput( VISIBLECOUNT__AnalogSerialOutput__, this );
        m_AnalogOutputList.Add( VISIBLECOUNT__AnalogSerialOutput__, VISIBLECOUNT );
        
        
        CAM1.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        CAM2.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        CAM3.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        CAM4.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        CAM5.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        CAM6.OnDigitalChange.Add( new InputChangeHandlerWrapper( CAM1_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_CAMERACONFIG ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint CAM1__DigitalInput__ = 0;
    const uint CAM2__DigitalInput__ = 1;
    const uint CAM3__DigitalInput__ = 2;
    const uint CAM4__DigitalInput__ = 3;
    const uint CAM5__DigitalInput__ = 4;
    const uint CAM6__DigitalInput__ = 5;
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
