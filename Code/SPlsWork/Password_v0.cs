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

namespace UserModule_PASSWORD_V0
{
    public class UserModuleClass_PASSWORD_V0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput STORE;
        Crestron.Logos.SplusObjects.DigitalInput RECALL;
        Crestron.Logos.SplusObjects.DigitalInput ENTER;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        Crestron.Logos.SplusObjects.DigitalInput STARS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> KEYPAD;
        Crestron.Logos.SplusObjects.StringInput BACKDOOR__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput USERPININ__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput STORE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput STORED;
        Crestron.Logos.SplusObjects.DigitalOutput PASS;
        Crestron.Logos.SplusObjects.DigitalOutput FAIL;
        Crestron.Logos.SplusObjects.DigitalOutput STARS_FB;
        Crestron.Logos.SplusObjects.AnalogOutput FAILS;
        Crestron.Logos.SplusObjects.StringOutput PASSWORD__DOLLAR__;
        ushort MODE = 0;
        ushort FAILCOUNT = 0;
        ushort MASKON = 0;
        ushort [] KPAD;
        CrestronString COMP__DOLLAR__;
        CrestronString PWRD__DOLLAR__;
        CrestronString USERPIN__DOLLAR__;
        CrestronString MASTERPIN__DOLLAR__;
        private void CLEARFX (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 16;
            MODE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 17;
            STORE_FB  .Value = (ushort) ( MODE ) ; 
            __context__.SourceCodeLine = 18;
            COMP__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 19;
            PWRD__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 20;
            PASSWORD__DOLLAR__  .UpdateValue ( PWRD__DOLLAR__  ) ; 
            
            }
            
        private void APPLYMASK (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 25;
            PWRD__DOLLAR__  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 26;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( MASKON ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( COMP__DOLLAR__ ) > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 28;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( COMP__DOLLAR__ ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 30;
                    PWRD__DOLLAR__  .UpdateValue ( PWRD__DOLLAR__ + "*"  ) ; 
                    __context__.SourceCodeLine = 28;
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 35;
                PWRD__DOLLAR__  .UpdateValue ( COMP__DOLLAR__  ) ; 
                } 
            
            __context__.SourceCodeLine = 37;
            PASSWORD__DOLLAR__  .UpdateValue ( PWRD__DOLLAR__  ) ; 
            
            }
            
        object STORE_OnRelease_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 40;
                MODE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 40;
                STORE_FB  .Value = (ushort) ( 1 ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RECALL_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 41;
            MODE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 41;
            STORE_FB  .Value = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object KEYPAD_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 45;
        I = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 46;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( COMP__DOLLAR__ ) < 16 ))  ) ) 
            { 
            __context__.SourceCodeLine = 48;
            COMP__DOLLAR__  .UpdateValue ( COMP__DOLLAR__ + Functions.ItoA (  (int) ( KPAD[ I ] ) )  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 52;
            COMP__DOLLAR__  .UpdateValue ( Functions.Right ( COMP__DOLLAR__ ,  (int) ( (16 - 1) ) ) + Functions.ItoA (  (int) ( KPAD[ I ] ) )  ) ; 
            } 
        
        __context__.SourceCodeLine = 55;
        APPLYMASK (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENTER_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 59;
        if ( Functions.TestForTrue  ( ( MODE)  ) ) 
            { 
            __context__.SourceCodeLine = 61;
            USERPIN__DOLLAR__  .UpdateValue ( COMP__DOLLAR__  ) ; 
            __context__.SourceCodeLine = 62;
            CLEARFX (  __context__  ) ; 
            __context__.SourceCodeLine = 63;
            Functions.Pulse ( 20, STORED ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 67;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (COMP__DOLLAR__ == USERPIN__DOLLAR__) ) || Functions.TestForTrue ( Functions.BoolToInt (COMP__DOLLAR__ == MASTERPIN__DOLLAR__) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 69;
                Functions.Pulse ( 80, PASS ) ; 
                __context__.SourceCodeLine = 70;
                FAILCOUNT = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 71;
                FAILS  .Value = (ushort) ( FAILCOUNT ) ; 
                __context__.SourceCodeLine = 72;
                CLEARFX (  __context__  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 76;
                Functions.Pulse ( 80, FAIL ) ; 
                __context__.SourceCodeLine = 77;
                FAILCOUNT = (ushort) ( (FAILCOUNT + 1) ) ; 
                __context__.SourceCodeLine = 78;
                FAILS  .Value = (ushort) ( FAILCOUNT ) ; 
                __context__.SourceCodeLine = 79;
                COMP__DOLLAR__  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 80;
                APPLYMASK (  __context__  ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLEAR_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 84;
        CLEARFX (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STARS_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        MASKON = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 85;
        STARS_FB  .Value = (ushort) ( MASKON ) ; 
        __context__.SourceCodeLine = 85;
        APPLYMASK (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object STARS_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 86;
        MASKON = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 86;
        STARS_FB  .Value = (ushort) ( MASKON ) ; 
        __context__.SourceCodeLine = 86;
        APPLYMASK (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKDOOR__DOLLAR___OnChange_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 87;
        MASTERPIN__DOLLAR__  .UpdateValue ( BACKDOOR__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object USERPININ__DOLLAR___OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 88;
        USERPIN__DOLLAR__  .UpdateValue ( USERPININ__DOLLAR__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 92;
        CLEARFX (  __context__  ) ; 
        __context__.SourceCodeLine = 93;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 94;
        MODE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 95;
        STORE_FB  .Value = (ushort) ( MODE ) ; 
        __context__.SourceCodeLine = 96;
        FAILCOUNT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 97;
        FAILS  .Value = (ushort) ( FAILCOUNT ) ; 
        __context__.SourceCodeLine = 98;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)9; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 100;
            KPAD [ I] = (ushort) ( I ) ; 
            __context__.SourceCodeLine = 98;
            } 
        
        __context__.SourceCodeLine = 102;
        KPAD [ 10] = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    KPAD  = new ushort[ 11 ];
    COMP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    PWRD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    USERPIN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    MASTERPIN__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
    
    STORE = new Crestron.Logos.SplusObjects.DigitalInput( STORE__DigitalInput__, this );
    m_DigitalInputList.Add( STORE__DigitalInput__, STORE );
    
    RECALL = new Crestron.Logos.SplusObjects.DigitalInput( RECALL__DigitalInput__, this );
    m_DigitalInputList.Add( RECALL__DigitalInput__, RECALL );
    
    ENTER = new Crestron.Logos.SplusObjects.DigitalInput( ENTER__DigitalInput__, this );
    m_DigitalInputList.Add( ENTER__DigitalInput__, ENTER );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    STARS = new Crestron.Logos.SplusObjects.DigitalInput( STARS__DigitalInput__, this );
    m_DigitalInputList.Add( STARS__DigitalInput__, STARS );
    
    KEYPAD = new InOutArray<DigitalInput>( 10, this );
    for( uint i = 0; i < 10; i++ )
    {
        KEYPAD[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( KEYPAD__DigitalInput__ + i, KEYPAD__DigitalInput__, this );
        m_DigitalInputList.Add( KEYPAD__DigitalInput__ + i, KEYPAD[i+1] );
    }
    
    STORE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( STORE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( STORE_FB__DigitalOutput__, STORE_FB );
    
    STORED = new Crestron.Logos.SplusObjects.DigitalOutput( STORED__DigitalOutput__, this );
    m_DigitalOutputList.Add( STORED__DigitalOutput__, STORED );
    
    PASS = new Crestron.Logos.SplusObjects.DigitalOutput( PASS__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASS__DigitalOutput__, PASS );
    
    FAIL = new Crestron.Logos.SplusObjects.DigitalOutput( FAIL__DigitalOutput__, this );
    m_DigitalOutputList.Add( FAIL__DigitalOutput__, FAIL );
    
    STARS_FB = new Crestron.Logos.SplusObjects.DigitalOutput( STARS_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( STARS_FB__DigitalOutput__, STARS_FB );
    
    FAILS = new Crestron.Logos.SplusObjects.AnalogOutput( FAILS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( FAILS__AnalogSerialOutput__, FAILS );
    
    BACKDOOR__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( BACKDOOR__DOLLAR____AnalogSerialInput__, 16, this );
    m_StringInputList.Add( BACKDOOR__DOLLAR____AnalogSerialInput__, BACKDOOR__DOLLAR__ );
    
    USERPININ__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( USERPININ__DOLLAR____AnalogSerialInput__, 16, this );
    m_StringInputList.Add( USERPININ__DOLLAR____AnalogSerialInput__, USERPININ__DOLLAR__ );
    
    PASSWORD__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( PASSWORD__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( PASSWORD__DOLLAR____AnalogSerialOutput__, PASSWORD__DOLLAR__ );
    
    
    STORE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( STORE_OnRelease_0, false ) );
    RECALL.OnDigitalRelease.Add( new InputChangeHandlerWrapper( RECALL_OnRelease_1, false ) );
    for( uint i = 0; i < 10; i++ )
        KEYPAD[i+1].OnDigitalRelease.Add( new InputChangeHandlerWrapper( KEYPAD_OnRelease_2, false ) );
        
    ENTER.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ENTER_OnRelease_3, false ) );
    CLEAR.OnDigitalRelease.Add( new InputChangeHandlerWrapper( CLEAR_OnRelease_4, false ) );
    STARS.OnDigitalPush.Add( new InputChangeHandlerWrapper( STARS_OnPush_5, false ) );
    STARS.OnDigitalRelease.Add( new InputChangeHandlerWrapper( STARS_OnRelease_6, false ) );
    BACKDOOR__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( BACKDOOR__DOLLAR___OnChange_7, false ) );
    USERPININ__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( USERPININ__DOLLAR___OnChange_8, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PASSWORD_V0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint STORE__DigitalInput__ = 0;
const uint RECALL__DigitalInput__ = 1;
const uint ENTER__DigitalInput__ = 2;
const uint CLEAR__DigitalInput__ = 3;
const uint STARS__DigitalInput__ = 4;
const uint KEYPAD__DigitalInput__ = 5;
const uint BACKDOOR__DOLLAR____AnalogSerialInput__ = 0;
const uint USERPININ__DOLLAR____AnalogSerialInput__ = 1;
const uint STORE_FB__DigitalOutput__ = 0;
const uint STORED__DigitalOutput__ = 1;
const uint PASS__DigitalOutput__ = 2;
const uint FAIL__DigitalOutput__ = 3;
const uint STARS_FB__DigitalOutput__ = 4;
const uint FAILS__AnalogSerialOutput__ = 0;
const uint PASSWORD__DOLLAR____AnalogSerialOutput__ = 1;

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
