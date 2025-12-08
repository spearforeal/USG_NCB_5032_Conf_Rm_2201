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

namespace UserModule_NIOX
{
    public class UserModuleClass_NIOX : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput DEBUG;
        Crestron.Logos.SplusObjects.DigitalInput UP;
        Crestron.Logos.SplusObjects.DigitalInput DOWN;
        Crestron.Logos.SplusObjects.DigitalInput ALLON;
        Crestron.Logos.SplusObjects.DigitalInput ALLOFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SCENE;
        Crestron.Logos.SplusObjects.DigitalOutput DEBUG_FB;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        UShortParameter ALL_CHANNEL;
        UShortParameter STEP_PCT;
        UShortParameter INIT_DELAY_CS;
        UShortParameter REPEAT_CS;
        ushort HOLDUP = 0;
        ushort HOLDDOWN = 0;
        ushort DEBUGENABLE = 0;
        private void SENDSCENE (  SplusExecutionContext __context__, ushort N ) 
            { 
            ushort B0 = 0;
            ushort B1 = 0;
            ushort B2 = 0;
            ushort B3 = 0;
            ushort CK1 = 0;
            ushort CK2 = 0;
            
            
            __context__.SourceCodeLine = 58;
            B0 = (ushort) ( 165 ) ; 
            __context__.SourceCodeLine = 58;
            B1 = (ushort) ( 6 ) ; 
            __context__.SourceCodeLine = 58;
            B2 = (ushort) ( 133 ) ; 
            __context__.SourceCodeLine = 58;
            B3 = (ushort) ( N ) ; 
            __context__.SourceCodeLine = 59;
            CK1 = (ushort) ( ((B0 ^ B2) ^ 255) ) ; 
            __context__.SourceCodeLine = 60;
            CK2 = (ushort) ( ((B1 ^ B3) ^ 255) ) ; 
            __context__.SourceCodeLine = 61;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2}{3}{4}{5}", Functions.Chr ( (B0 & 255) ) , Functions.Chr ( (B1 & 255) ) , Functions.Chr ( (B2 & 255) ) , Functions.Chr ( (B3 & 255) ) , Functions.Chr ( (CK1 & 255) ) , Functions.Chr ( (CK2 & 255) ) ) ; 
            
            }
            
        private void SENDEXERT (  SplusExecutionContext __context__, ushort CH , ushort ACTION , ushort AMOUNT ) 
            { 
            ushort B0 = 0;
            ushort B1 = 0;
            ushort B2 = 0;
            ushort B3 = 0;
            ushort B4 = 0;
            ushort B5 = 0;
            ushort CK1 = 0;
            ushort CK2 = 0;
            
            
            __context__.SourceCodeLine = 68;
            B0 = (ushort) ( 165 ) ; 
            __context__.SourceCodeLine = 68;
            B1 = (ushort) ( 8 ) ; 
            __context__.SourceCodeLine = 68;
            B2 = (ushort) ( 122 ) ; 
            __context__.SourceCodeLine = 68;
            B3 = (ushort) ( CH ) ; 
            __context__.SourceCodeLine = 68;
            B4 = (ushort) ( ACTION ) ; 
            __context__.SourceCodeLine = 68;
            B5 = (ushort) ( AMOUNT ) ; 
            __context__.SourceCodeLine = 69;
            CK1 = (ushort) ( (((B0 ^ B2) ^ B4) ^ 255) ) ; 
            __context__.SourceCodeLine = 70;
            CK2 = (ushort) ( (((B1 ^ B3) ^ B5) ^ 255) ) ; 
            __context__.SourceCodeLine = 71;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2}{3}{4}{5}{6}{7}", Functions.Chr ( (B0 & 255) ) , Functions.Chr ( (B1 & 255) ) , Functions.Chr ( (B2 & 255) ) , Functions.Chr ( (B3 & 255) ) , Functions.Chr ( (B4 & 255) ) , Functions.Chr ( (B5 & 255) ) , Functions.Chr ( (CK1 & 255) ) , Functions.Chr ( (CK2 & 255) ) ) ; 
            
            }
            
        private void STEPUP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 76;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 3 ), (ushort)( STEP_PCT  .Value )) ; 
            
            }
            
        private void STEPDOWN (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 77;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 4 ), (ushort)( STEP_PCT  .Value )) ; 
            
            }
            
        private void ALLONFUNC (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 78;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 1 ), (ushort)( 0 )) ; 
            
            }
            
        private void ALLOFFFUNC (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 79;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 2 ), (ushort)( 0 )) ; 
            
            }
            
        private void SETDEBUG (  SplusExecutionContext __context__, ushort VAL ) 
            { 
            
            __context__.SourceCodeLine = 82;
            DEBUGENABLE = (ushort) ( Functions.BoolToInt (VAL != 0) ) ; 
            __context__.SourceCodeLine = 83;
            DEBUG_FB  .Value = (ushort) ( DEBUGENABLE ) ; 
            
            }
            
        private void UPTICK (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 89;
            if ( Functions.TestForTrue  ( ( HOLDUP)  ) ) 
                { 
                __context__.SourceCodeLine = 91;
                STEPUP (  __context__  ) ; 
                __context__.SourceCodeLine = 92;
                CreateWait ( "UPREPEAT" , REPEAT_CS  .Value , UPREPEAT_Callback ) ;
                } 
            
            
            }
            
        public void UPREPEAT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 92;
            UPTICK (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void DOWNTICK (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 98;
        if ( Functions.TestForTrue  ( ( HOLDDOWN)  ) ) 
            { 
            __context__.SourceCodeLine = 100;
            STEPDOWN (  __context__  ) ; 
            __context__.SourceCodeLine = 101;
            CreateWait ( "DOWNREPEAT" , REPEAT_CS  .Value , DOWNREPEAT_Callback ) ;
            } 
        
        
        }
        
    public void DOWNREPEAT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 101;
            DOWNTICK (  __context__  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object SCENE_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IDX = 0;
        
        
        __context__.SourceCodeLine = 110;
        IDX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 111;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IDX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IDX <= 4 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 111;
            SENDSCENE (  __context__ , (ushort)( IDX )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UP_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 116;
        HOLDUP = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 117;
        STEPUP (  __context__  ) ; 
        __context__.SourceCodeLine = 118;
        CreateWait ( "UPSTART" , INIT_DELAY_CS  .Value , UPSTART_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void UPSTART_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 118;
            UPTICK (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UP_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 122;
        HOLDUP = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 123;
        CancelWait ( "UPSTART" ) ; 
        __context__.SourceCodeLine = 124;
        CancelWait ( "UPREPEAT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOWN_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 129;
        HOLDDOWN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 130;
        STEPDOWN (  __context__  ) ; 
        __context__.SourceCodeLine = 131;
        CreateWait ( "DOWNSTART" , INIT_DELAY_CS  .Value , DOWNSTART_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void DOWNSTART_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 131;
            DOWNTICK (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object DOWN_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 135;
        HOLDDOWN = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 136;
        CancelWait ( "DOWNSTART" ) ; 
        __context__.SourceCodeLine = 137;
        CancelWait ( "DOWNREPEAT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void KILLWAITS (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 141;
    HOLDUP = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 142;
    HOLDDOWN = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 143;
    CancelWait ( "UPSTART" ) ; 
    __context__.SourceCodeLine = 144;
    CancelWait ( "UPREPEAT" ) ; 
    __context__.SourceCodeLine = 145;
    CancelWait ( "DOWNSTART" ) ; 
    __context__.SourceCodeLine = 146;
    CancelWait ( "DOWNREPEAT" ) ; 
    
    }
    
object ALLON_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 150;
        KILLWAITS (  __context__  ) ; 
        __context__.SourceCodeLine = 151;
        ALLONFUNC (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLOFF_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 156;
        KILLWAITS (  __context__  ) ; 
        __context__.SourceCodeLine = 157;
        ALLOFFFUNC (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEBUG_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 162;
        SETDEBUG (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEBUG_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 166;
        SETDEBUG (  __context__ , (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    UP = new Crestron.Logos.SplusObjects.DigitalInput( UP__DigitalInput__, this );
    m_DigitalInputList.Add( UP__DigitalInput__, UP );
    
    DOWN = new Crestron.Logos.SplusObjects.DigitalInput( DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( DOWN__DigitalInput__, DOWN );
    
    ALLON = new Crestron.Logos.SplusObjects.DigitalInput( ALLON__DigitalInput__, this );
    m_DigitalInputList.Add( ALLON__DigitalInput__, ALLON );
    
    ALLOFF = new Crestron.Logos.SplusObjects.DigitalInput( ALLOFF__DigitalInput__, this );
    m_DigitalInputList.Add( ALLOFF__DigitalInput__, ALLOFF );
    
    SCENE = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SCENE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SCENE__DigitalInput__ + i, SCENE__DigitalInput__, this );
        m_DigitalInputList.Add( SCENE__DigitalInput__ + i, SCENE[i+1] );
    }
    
    DEBUG_FB = new Crestron.Logos.SplusObjects.DigitalOutput( DEBUG_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( DEBUG_FB__DigitalOutput__, DEBUG_FB );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    ALL_CHANNEL = new UShortParameter( ALL_CHANNEL__Parameter__, this );
    m_ParameterList.Add( ALL_CHANNEL__Parameter__, ALL_CHANNEL );
    
    STEP_PCT = new UShortParameter( STEP_PCT__Parameter__, this );
    m_ParameterList.Add( STEP_PCT__Parameter__, STEP_PCT );
    
    INIT_DELAY_CS = new UShortParameter( INIT_DELAY_CS__Parameter__, this );
    m_ParameterList.Add( INIT_DELAY_CS__Parameter__, INIT_DELAY_CS );
    
    REPEAT_CS = new UShortParameter( REPEAT_CS__Parameter__, this );
    m_ParameterList.Add( REPEAT_CS__Parameter__, REPEAT_CS );
    
    UPREPEAT_Callback = new WaitFunction( UPREPEAT_CallbackFn );
    DOWNREPEAT_Callback = new WaitFunction( DOWNREPEAT_CallbackFn );
    UPSTART_Callback = new WaitFunction( UPSTART_CallbackFn );
    DOWNSTART_Callback = new WaitFunction( DOWNSTART_CallbackFn );
    
    for( uint i = 0; i < 4; i++ )
        SCENE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SCENE_OnPush_0, false ) );
        
    UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( UP_OnPush_1, false ) );
    UP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( UP_OnRelease_2, false ) );
    DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOWN_OnPush_3, false ) );
    DOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DOWN_OnRelease_4, false ) );
    ALLON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLON_OnPush_5, false ) );
    ALLOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLOFF_OnPush_6, false ) );
    DEBUG.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEBUG_OnPush_7, false ) );
    DEBUG.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DEBUG_OnRelease_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_NIOX ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction UPREPEAT_Callback;
private WaitFunction DOWNREPEAT_Callback;
private WaitFunction UPSTART_Callback;
private WaitFunction DOWNSTART_Callback;


const uint DEBUG__DigitalInput__ = 0;
const uint UP__DigitalInput__ = 1;
const uint DOWN__DigitalInput__ = 2;
const uint ALLON__DigitalInput__ = 3;
const uint ALLOFF__DigitalInput__ = 4;
const uint SCENE__DigitalInput__ = 5;
const uint DEBUG_FB__DigitalOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint ALL_CHANNEL__Parameter__ = 10;
const uint STEP_PCT__Parameter__ = 11;
const uint INIT_DELAY_CS__Parameter__ = 12;
const uint REPEAT_CS__Parameter__ = 13;

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
