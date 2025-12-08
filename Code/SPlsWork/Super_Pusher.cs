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

namespace UserModule_SUPER_PUSHER
{
    public class UserModuleClass_SUPER_PUSHER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput PREVIOUS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> PUSHES;
        Crestron.Logos.SplusObjects.DigitalOutput PUSHED;
        Crestron.Logos.SplusObjects.DigitalOutput RELEASED;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PUSHES_FB;
        UShortParameter PUSH_TIME;
        UShortParameter RELEASE_DELAY;
        UShortParameter MODE;
        ushort DEFINED = 0;
        ushort ENABLED = 0;
        ushort P = 0;
        object ENABLE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 67;
                ENABLED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 68;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (MODE  .Value == 0) ) && Functions.TestForTrue ( Functions.BoolToInt ( _SplusNVRAM.STORE[ 0 ] > 0 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 70;
                    PUSHES_FB [ _SplusNVRAM.STORE[ 0 ]]  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 72;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (MODE  .Value == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 74;
                    PUSHES_FB [ 1]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 75;
                    _SplusNVRAM.STORE [ 0] = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 76;
                    _SplusNVRAM.STORE [ 1] = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ENABLE_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 82;
            ENABLED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 83;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)DEFINED; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 85;
                PUSHES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 83;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object PUSHES_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 92;
        P = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 93;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLE  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 95;
            Functions.Pulse ( PUSH_TIME  .Value, PUSHED ) ; 
            __context__.SourceCodeLine = 96;
            Functions.Delay (  (int) ( RELEASE_DELAY  .Value ) ) ; 
            __context__.SourceCodeLine = 97;
            Functions.Pulse ( PUSH_TIME  .Value, RELEASED ) ; 
            __context__.SourceCodeLine = 98;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MODE  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 100;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)DEFINED; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 102;
                    PUSHES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 100;
                    } 
                
                __context__.SourceCodeLine = 104;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] == _SplusNVRAM.STORE[ 1 ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 106;
                    PUSHES_FB [ P]  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 107;
                    _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                    __context__.SourceCodeLine = 108;
                    _SplusNVRAM.STORE [ 1] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 110;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] != _SplusNVRAM.STORE[ 1 ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 112;
                        _SplusNVRAM.STORE [ 1] = (ushort) ( _SplusNVRAM.STORE[ 0 ] ) ; 
                        __context__.SourceCodeLine = 113;
                        PUSHES_FB [ P]  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 114;
                        _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 117;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MODE  .Value == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 119;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] == _SplusNVRAM.STORE[ 1 ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 121;
                    PUSHES_FB [ P]  .Value = (ushort) ( PUSHES[ P ] .Value ) ; 
                    __context__.SourceCodeLine = 122;
                    _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                    __context__.SourceCodeLine = 123;
                    _SplusNVRAM.STORE [ 1] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 125;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] != _SplusNVRAM.STORE[ 1 ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 127;
                        PUSHES_FB [ P]  .Value = (ushort) ( PUSHES[ P ] .Value ) ; 
                        __context__.SourceCodeLine = 128;
                        _SplusNVRAM.STORE [ 1] = (ushort) ( _SplusNVRAM.STORE[ 0 ] ) ; 
                        __context__.SourceCodeLine = 129;
                        PUSHES_FB [ P]  .Value = (ushort) ( PUSHES[ P ] .Value ) ; 
                        __context__.SourceCodeLine = 130;
                        _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 133;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MODE  .Value == 2))  ) ) 
                { 
                __context__.SourceCodeLine = 135;
                Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
                __context__.SourceCodeLine = 136;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] == _SplusNVRAM.STORE[ 1 ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 138;
                    Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
                    __context__.SourceCodeLine = 139;
                    _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                    __context__.SourceCodeLine = 140;
                    _SplusNVRAM.STORE [ 1] = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 142;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] != _SplusNVRAM.STORE[ 1 ]))  ) ) 
                        { 
                        __context__.SourceCodeLine = 144;
                        _SplusNVRAM.STORE [ 1] = (ushort) ( _SplusNVRAM.STORE[ 0 ] ) ; 
                        __context__.SourceCodeLine = 145;
                        Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
                        __context__.SourceCodeLine = 146;
                        _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 149;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MODE  .Value == 3))  ) ) 
                { 
                __context__.SourceCodeLine = 151;
                CreateWait ( "DELAY_TIMEOUT" , RELEASE_DELAY  .Value , DELAY_TIMEOUT_Callback ) ;
                } 
            
            } 
        
        __context__.SourceCodeLine = 169;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLE  .Value == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 171;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)DEFINED; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 173;
                PUSHES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 171;
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void DELAY_TIMEOUT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 153;
            Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
            __context__.SourceCodeLine = 154;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] == _SplusNVRAM.STORE[ 1 ]))  ) ) 
                { 
                __context__.SourceCodeLine = 156;
                Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
                __context__.SourceCodeLine = 157;
                _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                __context__.SourceCodeLine = 158;
                _SplusNVRAM.STORE [ 1] = (ushort) ( 1 ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 160;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (_SplusNVRAM.STORE[ 0 ] != _SplusNVRAM.STORE[ 1 ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 162;
                    _SplusNVRAM.STORE [ 1] = (ushort) ( _SplusNVRAM.STORE[ 0 ] ) ; 
                    __context__.SourceCodeLine = 163;
                    Functions.Pulse ( 5, PUSHES_FB [ P] ) ; 
                    __context__.SourceCodeLine = 164;
                    _SplusNVRAM.STORE [ 0] = (ushort) ( P ) ; 
                    } 
                
                }
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object PUSHES_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort P = 0;
        
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 181;
        P = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 182;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MODE  .Value > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 184;
            PUSHES_FB [ P]  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PREVIOUS_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        ushort BACK = 0;
        
        
        __context__.SourceCodeLine = 191;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLED == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 193;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)DEFINED; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 195;
                PUSHES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 193;
                } 
            
            __context__.SourceCodeLine = 197;
            BACK = (ushort) ( _SplusNVRAM.STORE[ 0 ] ) ; 
            __context__.SourceCodeLine = 198;
            _SplusNVRAM.STORE [ 0] = (ushort) ( _SplusNVRAM.STORE[ 1 ] ) ; 
            __context__.SourceCodeLine = 199;
            _SplusNVRAM.STORE [ 1] = (ushort) ( BACK ) ; 
            __context__.SourceCodeLine = 200;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MODE  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 202;
                PUSHES_FB [ _SplusNVRAM.STORE[ 0 ]]  .Value = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 204;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MODE  .Value > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 206;
                Functions.Pulse ( 5, PUSHES_FB [ _SplusNVRAM.STORE[ 0 ]] ) ; 
                } 
            
            __context__.SourceCodeLine = 208;
            Functions.Pulse ( PUSH_TIME  .Value, PUSHED ) ; 
            __context__.SourceCodeLine = 209;
            Functions.Delay (  (int) ( RELEASE_DELAY  .Value ) ) ; 
            __context__.SourceCodeLine = 210;
            Functions.Pulse ( PUSH_TIME  .Value, RELEASED ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort P = 0;
    
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 217;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 100 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( DEFINED  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (DEFINED  >= __FN_FORSTART_VAL__1) && (DEFINED  <= __FN_FOREND_VAL__1) ) : ( (DEFINED  <= __FN_FORSTART_VAL__1) && (DEFINED  >= __FN_FOREND_VAL__1) ) ; DEFINED  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 219;
            if ( Functions.TestForTrue  ( ( IsSignalDefined( PUSHES[ DEFINED ] ))  ) ) 
                {
                __context__.SourceCodeLine = 220;
                break ; 
                }
            
            __context__.SourceCodeLine = 217;
            } 
        
        __context__.SourceCodeLine = 222;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 223;
        Functions.Delay (  (int) ( 25 ) ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    _SplusNVRAM.STORE  = new ushort[ 3 ];
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    PREVIOUS = new Crestron.Logos.SplusObjects.DigitalInput( PREVIOUS__DigitalInput__, this );
    m_DigitalInputList.Add( PREVIOUS__DigitalInput__, PREVIOUS );
    
    PUSHES = new InOutArray<DigitalInput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        PUSHES[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( PUSHES__DigitalInput__ + i, PUSHES__DigitalInput__, this );
        m_DigitalInputList.Add( PUSHES__DigitalInput__ + i, PUSHES[i+1] );
    }
    
    PUSHED = new Crestron.Logos.SplusObjects.DigitalOutput( PUSHED__DigitalOutput__, this );
    m_DigitalOutputList.Add( PUSHED__DigitalOutput__, PUSHED );
    
    RELEASED = new Crestron.Logos.SplusObjects.DigitalOutput( RELEASED__DigitalOutput__, this );
    m_DigitalOutputList.Add( RELEASED__DigitalOutput__, RELEASED );
    
    PUSHES_FB = new InOutArray<DigitalOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        PUSHES_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PUSHES_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PUSHES_FB__DigitalOutput__ + i, PUSHES_FB[i+1] );
    }
    
    PUSH_TIME = new UShortParameter( PUSH_TIME__Parameter__, this );
    m_ParameterList.Add( PUSH_TIME__Parameter__, PUSH_TIME );
    
    RELEASE_DELAY = new UShortParameter( RELEASE_DELAY__Parameter__, this );
    m_ParameterList.Add( RELEASE_DELAY__Parameter__, RELEASE_DELAY );
    
    MODE = new UShortParameter( MODE__Parameter__, this );
    m_ParameterList.Add( MODE__Parameter__, MODE );
    
    DELAY_TIMEOUT_Callback = new WaitFunction( DELAY_TIMEOUT_CallbackFn );
    
    ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_OnPush_0, false ) );
    ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENABLE_OnRelease_1, false ) );
    for( uint i = 0; i < 100; i++ )
        PUSHES[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( PUSHES_OnPush_2, false ) );
        
    for( uint i = 0; i < 100; i++ )
        PUSHES[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( PUSHES_OnRelease_3, false ) );
        
    PREVIOUS.OnDigitalPush.Add( new InputChangeHandlerWrapper( PREVIOUS_OnPush_4, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SUPER_PUSHER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction DELAY_TIMEOUT_Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint PREVIOUS__DigitalInput__ = 1;
const uint PUSHES__DigitalInput__ = 2;
const uint PUSHED__DigitalOutput__ = 0;
const uint RELEASED__DigitalOutput__ = 1;
const uint PUSHES_FB__DigitalOutput__ = 2;
const uint PUSH_TIME__Parameter__ = 10;
const uint RELEASE_DELAY__Parameter__ = 11;
const uint MODE__Parameter__ = 12;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort [] STORE;
            
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
