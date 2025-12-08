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

namespace UserModule_Q_SYS_NAMED_CONTROL_OBJECT_V5_3
{
    public class UserModuleClass_Q_SYS_NAMED_CONTROL_OBJECT_V5_3 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE_NAMED_CONTROL;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_POLL;
        Crestron.Logos.SplusObjects.DigitalInput TRIGGER;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VERIFY_VALUE;
        Crestron.Logos.SplusObjects.StringInput STRING_IN;
        Crestron.Logos.SplusObjects.AnalogInput DIR_VALUE_IN;
        Crestron.Logos.SplusObjects.AnalogInput REL_VALUE_IN;
        Crestron.Logos.SplusObjects.AnalogInput REL_VALUE_IN_RAMP;
        Crestron.Logos.SplusObjects.AnalogInput DB_VALUE_IN;
        Crestron.Logos.SplusObjects.AnalogInput DB_VALUE_IN_RAMP;
        Crestron.Logos.SplusObjects.AnalogInput SNAPSHOT_SAVE;
        Crestron.Logos.SplusObjects.AnalogInput SNAPSHOT_RECALL;
        Crestron.Logos.SplusObjects.StringOutput STRING_OUT_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ERROR;
        Crestron.Logos.SplusObjects.AnalogOutput DIR_VALUE_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput REL_VALUE_OUT;
        Crestron.Logos.SplusObjects.AnalogOutput DB_VALUE_OUT;
        UShortParameter CORE_ID;
        StringParameter NAMEDCONTROL;
        UShortParameter RAMP_TIME;
        ushort GIID = 0;
        CrestronString GSNAMEDCONTROL;
        QSYSControlV4_2.QSYSNamedControl MYNAMEDCONTROL;
        public void NAMEDCONTROLEVENT ( object __sender__ /*QSYSControlV4_2.QSYSNamedControlEvent SENDER */, QSYSControlV4_2.QSYSNamedControlChangeArgs E ) 
            { 
            QSYSNamedControlEvent  SENDER  = (QSYSNamedControlEvent )__sender__;
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 71;
                REL_VALUE_OUT  .Value = (ushort) ( E.relValue ) ; 
                __context__.SourceCodeLine = 72;
                DB_VALUE_OUT  .Value = (ushort) ( E.dBValue ) ; 
                __context__.SourceCodeLine = 73;
                STRING_OUT_FB  .UpdateValue ( E . sValue  ) ; 
                __context__.SourceCodeLine = 74;
                DIR_VALUE_OUT  .Value = (ushort) ( E.dirValue ) ; 
                
                
            }
            finally { ObjectFinallyHandler(); }
            }
            
        object VERIFY_VALUE_OnRelease_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort I = 0;
                
                
                __context__.SourceCodeLine = 81;
                if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 84;
                    I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
                    __context__.SourceCodeLine = 85;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_1__ = ((int)I);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 89;
                                MYNAMEDCONTROL . _RelValue = (ushort) ( REL_VALUE_IN  .UshortValue ) ; 
                                } 
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                                { 
                                __context__.SourceCodeLine = 93;
                                MYNAMEDCONTROL . _dbValue = (short) ( DB_VALUE_IN  .ShortValue ) ; 
                                } 
                            
                            } 
                            
                        }
                        
                    
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INITIALIZE_NAMED_CONTROL_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 101;
            MYNAMEDCONTROL . RampTime = (short) ( RAMP_TIME  .Value ) ; 
            __context__.SourceCodeLine = 102;
            MYNAMEDCONTROL . AddNamedControl ( GSNAMEDCONTROL .ToString(), (ushort)( GIID )) ; 
            __context__.SourceCodeLine = 103;
            // RegisterEvent( MYNAMEDCONTROL , ONNAMEDCONTROLEVENT , NAMEDCONTROLEVENT ) 
            try { g_criticalSection.Enter(); MYNAMEDCONTROL .OnNamedControlEvent  += NAMEDCONTROLEVENT; } finally { g_criticalSection.Leave(); }
            ; 
            __context__.SourceCodeLine = 105;
            Functions.Delay (  (int) ( 5 ) ) ; 
            __context__.SourceCodeLine = 107;
            if ( Functions.TestForTrue  ( ( ENABLE_POLL  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 109;
                MYNAMEDCONTROL . _Poll = (ushort) ( ENABLE_POLL  .Value ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object REL_VALUE_IN_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 116;
        if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 117;
            MYNAMEDCONTROL . _RelValue = (ushort) ( REL_VALUE_IN  .UshortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REL_VALUE_IN_RAMP_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 121;
        if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 122;
            MYNAMEDCONTROL . _RelValueRamp = (ushort) ( REL_VALUE_IN_RAMP  .UshortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DB_VALUE_IN_OnChange_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 126;
        if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 127;
            MYNAMEDCONTROL . _dbValue = (short) ( DB_VALUE_IN  .ShortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DB_VALUE_IN_RAMP_OnChange_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 131;
        if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 132;
            MYNAMEDCONTROL . _dbValueRamp = (short) ( DB_VALUE_IN_RAMP  .ShortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STRING_IN_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 136;
        if ( Functions.TestForTrue  ( ( INITIALIZE_NAMED_CONTROL  .Value)  ) ) 
            {
            __context__.SourceCodeLine = 137;
            MYNAMEDCONTROL . _StringValue  =  ( STRING_IN  )  .ToString() ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIR_VALUE_IN_OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        MYNAMEDCONTROL . _dirValue = (short) ( DIR_VALUE_IN  .ShortValue ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SNAPSHOT_SAVE_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 145;
        MYNAMEDCONTROL . SnapShotSave ( (ushort)( SNAPSHOT_SAVE  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SNAPSHOT_RECALL_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 149;
        MYNAMEDCONTROL . SnapShotLoad ( (ushort)( SNAPSHOT_RECALL  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_POLL_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 156;
        MYNAMEDCONTROL . _Poll = (ushort) ( ENABLE_POLL  .Value ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TRIGGER_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 160;
        MYNAMEDCONTROL . TriggerBtnDown ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TRIGGER_OnRelease_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 164;
        MYNAMEDCONTROL . TriggerBtnUp ( ) ; 
        
        
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
        
        __context__.SourceCodeLine = 179;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 180;
        GIID = (ushort) ( CORE_ID  .Value ) ; 
        __context__.SourceCodeLine = 181;
        GSNAMEDCONTROL  .UpdateValue ( NAMEDCONTROL  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    GSNAMEDCONTROL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 500, this );
    
    INITIALIZE_NAMED_CONTROL = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE_NAMED_CONTROL__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE_NAMED_CONTROL__DigitalInput__, INITIALIZE_NAMED_CONTROL );
    
    ENABLE_POLL = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_POLL__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_POLL__DigitalInput__, ENABLE_POLL );
    
    TRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( TRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( TRIGGER__DigitalInput__, TRIGGER );
    
    VERIFY_VALUE = new InOutArray<DigitalInput>( 2, this );
    for( uint i = 0; i < 2; i++ )
    {
        VERIFY_VALUE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VERIFY_VALUE__DigitalInput__ + i, VERIFY_VALUE__DigitalInput__, this );
        m_DigitalInputList.Add( VERIFY_VALUE__DigitalInput__ + i, VERIFY_VALUE[i+1] );
    }
    
    ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( ERROR__DigitalOutput__, ERROR );
    
    DIR_VALUE_IN = new Crestron.Logos.SplusObjects.AnalogInput( DIR_VALUE_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DIR_VALUE_IN__AnalogSerialInput__, DIR_VALUE_IN );
    
    REL_VALUE_IN = new Crestron.Logos.SplusObjects.AnalogInput( REL_VALUE_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( REL_VALUE_IN__AnalogSerialInput__, REL_VALUE_IN );
    
    REL_VALUE_IN_RAMP = new Crestron.Logos.SplusObjects.AnalogInput( REL_VALUE_IN_RAMP__AnalogSerialInput__, this );
    m_AnalogInputList.Add( REL_VALUE_IN_RAMP__AnalogSerialInput__, REL_VALUE_IN_RAMP );
    
    DB_VALUE_IN = new Crestron.Logos.SplusObjects.AnalogInput( DB_VALUE_IN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DB_VALUE_IN__AnalogSerialInput__, DB_VALUE_IN );
    
    DB_VALUE_IN_RAMP = new Crestron.Logos.SplusObjects.AnalogInput( DB_VALUE_IN_RAMP__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DB_VALUE_IN_RAMP__AnalogSerialInput__, DB_VALUE_IN_RAMP );
    
    SNAPSHOT_SAVE = new Crestron.Logos.SplusObjects.AnalogInput( SNAPSHOT_SAVE__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SNAPSHOT_SAVE__AnalogSerialInput__, SNAPSHOT_SAVE );
    
    SNAPSHOT_RECALL = new Crestron.Logos.SplusObjects.AnalogInput( SNAPSHOT_RECALL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( SNAPSHOT_RECALL__AnalogSerialInput__, SNAPSHOT_RECALL );
    
    DIR_VALUE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( DIR_VALUE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DIR_VALUE_OUT__AnalogSerialOutput__, DIR_VALUE_OUT );
    
    REL_VALUE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( REL_VALUE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( REL_VALUE_OUT__AnalogSerialOutput__, REL_VALUE_OUT );
    
    DB_VALUE_OUT = new Crestron.Logos.SplusObjects.AnalogOutput( DB_VALUE_OUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( DB_VALUE_OUT__AnalogSerialOutput__, DB_VALUE_OUT );
    
    STRING_IN = new Crestron.Logos.SplusObjects.StringInput( STRING_IN__AnalogSerialInput__, 500, this );
    m_StringInputList.Add( STRING_IN__AnalogSerialInput__, STRING_IN );
    
    STRING_OUT_FB = new Crestron.Logos.SplusObjects.StringOutput( STRING_OUT_FB__AnalogSerialOutput__, this );
    m_StringOutputList.Add( STRING_OUT_FB__AnalogSerialOutput__, STRING_OUT_FB );
    
    CORE_ID = new UShortParameter( CORE_ID__Parameter__, this );
    m_ParameterList.Add( CORE_ID__Parameter__, CORE_ID );
    
    RAMP_TIME = new UShortParameter( RAMP_TIME__Parameter__, this );
    m_ParameterList.Add( RAMP_TIME__Parameter__, RAMP_TIME );
    
    NAMEDCONTROL = new StringParameter( NAMEDCONTROL__Parameter__, this );
    m_ParameterList.Add( NAMEDCONTROL__Parameter__, NAMEDCONTROL );
    
    
    for( uint i = 0; i < 2; i++ )
        VERIFY_VALUE[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( VERIFY_VALUE_OnRelease_0, false ) );
        
    INITIALIZE_NAMED_CONTROL.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_NAMED_CONTROL_OnPush_1, false ) );
    REL_VALUE_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( REL_VALUE_IN_OnChange_2, true ) );
    REL_VALUE_IN_RAMP.OnAnalogChange.Add( new InputChangeHandlerWrapper( REL_VALUE_IN_RAMP_OnChange_3, true ) );
    DB_VALUE_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( DB_VALUE_IN_OnChange_4, true ) );
    DB_VALUE_IN_RAMP.OnAnalogChange.Add( new InputChangeHandlerWrapper( DB_VALUE_IN_RAMP_OnChange_5, true ) );
    STRING_IN.OnSerialChange.Add( new InputChangeHandlerWrapper( STRING_IN_OnChange_6, true ) );
    DIR_VALUE_IN.OnAnalogChange.Add( new InputChangeHandlerWrapper( DIR_VALUE_IN_OnChange_7, true ) );
    SNAPSHOT_SAVE.OnAnalogChange.Add( new InputChangeHandlerWrapper( SNAPSHOT_SAVE_OnChange_8, true ) );
    SNAPSHOT_RECALL.OnAnalogChange.Add( new InputChangeHandlerWrapper( SNAPSHOT_RECALL_OnChange_9, true ) );
    ENABLE_POLL.OnDigitalChange.Add( new InputChangeHandlerWrapper( ENABLE_POLL_OnChange_10, false ) );
    TRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( TRIGGER_OnPush_11, false ) );
    TRIGGER.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TRIGGER_OnRelease_12, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    MYNAMEDCONTROL  = new QSYSControlV4_2.QSYSNamedControl();
    
    
}

public UserModuleClass_Q_SYS_NAMED_CONTROL_OBJECT_V5_3 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITIALIZE_NAMED_CONTROL__DigitalInput__ = 0;
const uint ENABLE_POLL__DigitalInput__ = 1;
const uint TRIGGER__DigitalInput__ = 2;
const uint VERIFY_VALUE__DigitalInput__ = 3;
const uint STRING_IN__AnalogSerialInput__ = 0;
const uint DIR_VALUE_IN__AnalogSerialInput__ = 1;
const uint REL_VALUE_IN__AnalogSerialInput__ = 2;
const uint REL_VALUE_IN_RAMP__AnalogSerialInput__ = 3;
const uint DB_VALUE_IN__AnalogSerialInput__ = 4;
const uint DB_VALUE_IN_RAMP__AnalogSerialInput__ = 5;
const uint SNAPSHOT_SAVE__AnalogSerialInput__ = 6;
const uint SNAPSHOT_RECALL__AnalogSerialInput__ = 7;
const uint STRING_OUT_FB__AnalogSerialOutput__ = 0;
const uint ERROR__DigitalOutput__ = 0;
const uint DIR_VALUE_OUT__AnalogSerialOutput__ = 1;
const uint REL_VALUE_OUT__AnalogSerialOutput__ = 2;
const uint DB_VALUE_OUT__AnalogSerialOutput__ = 3;
const uint CORE_ID__Parameter__ = 10;
const uint NAMEDCONTROL__Parameter__ = 11;
const uint RAMP_TIME__Parameter__ = 12;

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
