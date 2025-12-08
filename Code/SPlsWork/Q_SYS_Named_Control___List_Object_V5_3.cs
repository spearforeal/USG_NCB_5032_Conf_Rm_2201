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
using QSYSControlV4_2;

namespace UserModule_Q_SYS_NAMED_CONTROL___LIST_OBJECT_V5_3
{
    public class UserModuleClass_Q_SYS_NAMED_CONTROL___LIST_OBJECT_V5_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE_NAMED_CONTROL;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_POLL;
        Crestron.Logos.SplusObjects.AnalogInput DIRECT_SELECT;
        Crestron.Logos.SplusObjects.AnalogOutput LIST_COUNT;
        Crestron.Logos.SplusObjects.StringOutput SELECTED_STRING;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> UNFORMATTED_STRING_OUT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> FORMATTED_STRING_OUT;
        Crestron.Logos.SplusObjects.DigitalOutput ERROR;
        UShortParameter CORE_ID;
        StringParameter NAMEDCONTROL;
        UShortParameter TEXT_SIZE;
        ushort GIID = 0;
        CrestronString GSNAMEDCONTROL;
        ushort GITEXTSIZE = 0;
        CrestronString GSLISTITEMFORMATTED;
        CrestronString GSLISTITEMUNFORMATTED;
        QSYSControlV4_2.QSYSNamedControl MYNAMEDCONTROL;
        public void NAMEDCONTROLEVENT ( object __sender__ /*QSYSControlV4_2.QSYSNamedControlEvent SENDER */, QSYSControlV4_2.QSYSNamedControlChangeArgs E ) 
            { 
            QSYSNamedControlEvent  SENDER  = (QSYSNamedControlEvent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 67;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( E.lIndex > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 69;
                    UNFORMATTED_STRING_OUT [ E.lIndex]  .UpdateValue ( E . lsValue  ) ; 
                    __context__.SourceCodeLine = 70;
                    FORMATTED_STRING_OUT [ E.lIndex]  .UpdateValue ( E . lfsValue  ) ; 
                    } 
                
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_ITEMSELECTED ( SimplSharpString SELECTEDITEM ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 76;
                SELECTED_STRING  .UpdateValue ( SELECTEDITEM  .ToString()  ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        public void CBF_ITEMCOUNT ( ushort ITEMCOUNT ) 
            { 
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 81;
                LIST_COUNT  .Value = (ushort) ( ITEMCOUNT ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object INITIALIZE_NAMED_CONTROL_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 87;
                MYNAMEDCONTROL . AddListNamedControl ( GSNAMEDCONTROL .ToString(), (ushort)( GIID ), (int)( GITEXTSIZE )) ; 
                __context__.SourceCodeLine = 88;
                // RegisterEvent( MYNAMEDCONTROL , ONNAMEDCONTROLEVENT , NAMEDCONTROLEVENT ) 
                try { g_criticalSection.Enter(); MYNAMEDCONTROL .OnNamedControlEvent  += NAMEDCONTROLEVENT; } finally { g_criticalSection.Leave(); }
                ; 
                __context__.SourceCodeLine = 90;
                Functions.Delay (  (int) ( 5 ) ) ; 
                __context__.SourceCodeLine = 92;
                if ( Functions.TestForTrue  ( ( ENABLE_POLL  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 94;
                    MYNAMEDCONTROL . _Poll = (ushort) ( ENABLE_POLL  .Value ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object DIRECT_SELECT_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 101;
            MYNAMEDCONTROL . ListItemSelect ( (int)( DIRECT_SELECT  .IntValue )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ENABLE_POLL_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 107;
        MYNAMEDCONTROL . _Poll = (ushort) ( ENABLE_POLL  .Value ) ; 
        
        
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
        
        __context__.SourceCodeLine = 119;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 120;
        GIID = (ushort) ( CORE_ID  .Value ) ; 
        __context__.SourceCodeLine = 121;
        GSNAMEDCONTROL  .UpdateValue ( NAMEDCONTROL  ) ; 
        __context__.SourceCodeLine = 122;
        GITEXTSIZE = (ushort) ( TEXT_SIZE  .Value ) ; 
        __context__.SourceCodeLine = 123;
        // RegisterDelegate( MYNAMEDCONTROL , DELITEMSELECTED , CBF_ITEMSELECTED ) 
        MYNAMEDCONTROL .delItemSelected  = CBF_ITEMSELECTED; ; 
        __context__.SourceCodeLine = 124;
        // RegisterDelegate( MYNAMEDCONTROL , DELITEMCOUNT , CBF_ITEMCOUNT ) 
        MYNAMEDCONTROL .delItemCount  = CBF_ITEMCOUNT; ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    GSNAMEDCONTROL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    GSLISTITEMFORMATTED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    GSLISTITEMUNFORMATTED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    
    INITIALIZE_NAMED_CONTROL = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE_NAMED_CONTROL__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE_NAMED_CONTROL__DigitalInput__, INITIALIZE_NAMED_CONTROL );
    
    ENABLE_POLL = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_POLL__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_POLL__DigitalInput__, ENABLE_POLL );
    
    ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( ERROR__DigitalOutput__, ERROR );
    
    DIRECT_SELECT = new Crestron.Logos.SplusObjects.AnalogInput( DIRECT_SELECT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DIRECT_SELECT__AnalogSerialInput__, DIRECT_SELECT );
    
    LIST_COUNT = new Crestron.Logos.SplusObjects.AnalogOutput( LIST_COUNT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LIST_COUNT__AnalogSerialOutput__, LIST_COUNT );
    
    SELECTED_STRING = new Crestron.Logos.SplusObjects.StringOutput( SELECTED_STRING__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SELECTED_STRING__AnalogSerialOutput__, SELECTED_STRING );
    
    UNFORMATTED_STRING_OUT = new InOutArray<StringOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        UNFORMATTED_STRING_OUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( UNFORMATTED_STRING_OUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( UNFORMATTED_STRING_OUT__AnalogSerialOutput__ + i, UNFORMATTED_STRING_OUT[i+1] );
    }
    
    FORMATTED_STRING_OUT = new InOutArray<StringOutput>( 500, this );
    for( uint i = 0; i < 500; i++ )
    {
        FORMATTED_STRING_OUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( FORMATTED_STRING_OUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( FORMATTED_STRING_OUT__AnalogSerialOutput__ + i, FORMATTED_STRING_OUT[i+1] );
    }
    
    CORE_ID = new UShortParameter( CORE_ID__Parameter__, this );
    m_ParameterList.Add( CORE_ID__Parameter__, CORE_ID );
    
    TEXT_SIZE = new UShortParameter( TEXT_SIZE__Parameter__, this );
    m_ParameterList.Add( TEXT_SIZE__Parameter__, TEXT_SIZE );
    
    NAMEDCONTROL = new StringParameter( NAMEDCONTROL__Parameter__, this );
    m_ParameterList.Add( NAMEDCONTROL__Parameter__, NAMEDCONTROL );
    
    
    INITIALIZE_NAMED_CONTROL.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_NAMED_CONTROL_OnPush_0, false ) );
    DIRECT_SELECT.OnAnalogChange.Add( new InputChangeHandlerWrapper( DIRECT_SELECT_OnChange_1, false ) );
    ENABLE_POLL.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_POLL_OnChange_2, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    MYNAMEDCONTROL  = new QSYSControlV4_2.QSYSNamedControl();
    
    
}

public UserModuleClass_Q_SYS_NAMED_CONTROL___LIST_OBJECT_V5_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE_NAMED_CONTROL__DigitalInput__ = 0;
const uint ENABLE_POLL__DigitalInput__ = 1;
const uint DIRECT_SELECT__AnalogSerialInput__ = 0;
const uint LIST_COUNT__AnalogSerialOutput__ = 0;
const uint SELECTED_STRING__AnalogSerialOutput__ = 1;
const uint UNFORMATTED_STRING_OUT__AnalogSerialOutput__ = 2;
const uint FORMATTED_STRING_OUT__AnalogSerialOutput__ = 502;
const uint ERROR__DigitalOutput__ = 0;
const uint CORE_ID__Parameter__ = 10;
const uint NAMEDCONTROL__Parameter__ = 11;
const uint TEXT_SIZE__Parameter__ = 12;

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
