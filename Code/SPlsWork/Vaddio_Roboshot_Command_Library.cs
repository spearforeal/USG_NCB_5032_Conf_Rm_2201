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

namespace UserModule_VADDIO_ROBOSHOT_COMMAND_LIBRARY
{
    public class UserModuleClass_VADDIO_ROBOSHOT_COMMAND_LIBRARY : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput PAN_LEFT_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput PAN_LEFT_LOW;
        Crestron.Logos.SplusObjects.DigitalInput PAN_RIGHT_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput PAN_RIGHT_LOW;
        Crestron.Logos.SplusObjects.DigitalInput TILT_UP_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput TILT_UP_LOW;
        Crestron.Logos.SplusObjects.DigitalInput TILT_DOWN_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput TILT_DOWN_LOW;
        Crestron.Logos.SplusObjects.DigitalInput ZOOM_IN_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput ZOOM_IN_LOW;
        Crestron.Logos.SplusObjects.DigitalInput ZOOM_OUT_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput ZOOM_OUT_LOW;
        Crestron.Logos.SplusObjects.DigitalInput FOCUS_NEAR_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput FOCUS_NEAR_LOW;
        Crestron.Logos.SplusObjects.DigitalInput FOCUS_FAR_HIGH;
        Crestron.Logos.SplusObjects.DigitalInput FOCUS_FAR_LOW;
        Crestron.Logos.SplusObjects.DigitalInput PAN_STOP;
        Crestron.Logos.SplusObjects.DigitalInput TILT_STOP;
        Crestron.Logos.SplusObjects.DigitalInput ZOOM_STOP;
        Crestron.Logos.SplusObjects.DigitalInput FOCUS_STOP;
        Crestron.Logos.SplusObjects.AnalogInput PANSPEEDHIGH;
        Crestron.Logos.SplusObjects.AnalogInput PANSPEEDLOW;
        Crestron.Logos.SplusObjects.AnalogInput TILTSPEEDHIGH;
        Crestron.Logos.SplusObjects.AnalogInput TILTSPEEDLOW;
        Crestron.Logos.SplusObjects.AnalogInput ZOOMSPEEDHIGH;
        Crestron.Logos.SplusObjects.AnalogInput ZOOMSPEEDLOW;
        Crestron.Logos.SplusObjects.AnalogInput FOCUSSPEEDHIGH;
        Crestron.Logos.SplusObjects.AnalogInput FOCUSSPEEDLOW;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        CrestronString CMD__DOLLAR__;
        CrestronString SPD__DOLLAR__;
        private ushort CLAMPSPEED (  SplusExecutionContext __context__, ushort S ) 
            { 
            
            __context__.SourceCodeLine = 44;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( S < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 46;
                return (ushort)( 1) ; 
                } 
            
            __context__.SourceCodeLine = 48;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( S > 24 ))  ) ) 
                { 
                __context__.SourceCodeLine = 50;
                return (ushort)( 24) ; 
                } 
            
            __context__.SourceCodeLine = 52;
            return (ushort)( S) ; 
            
            }
            
        private void SENDCMDWITHSPEED (  SplusExecutionContext __context__, CrestronString BASE__DOLLAR__ , ushort SPEED ) 
            { 
            
            __context__.SourceCodeLine = 56;
            SPEED = (ushort) ( CLAMPSPEED( __context__ , (ushort)( SPEED ) ) ) ; 
            __context__.SourceCodeLine = 57;
            TX__DOLLAR__  .UpdateValue ( BASE__DOLLAR__ + " " + Functions.ItoA (  (int) ( SPEED ) ) + "\u000D"  ) ; 
            
            }
            
        private void SENDCMDWITHOUTSPEED (  SplusExecutionContext __context__, CrestronString CMD__DOLLAR__ ) 
            { 
            
            __context__.SourceCodeLine = 61;
            TX__DOLLAR__  .UpdateValue ( CMD__DOLLAR__ + "\u000D"  ) ; 
            
            }
            
        object PAN_LEFT_HIGH_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 65;
                SENDCMDWITHSPEED (  __context__ , "camera pan left", (ushort)( PANSPEEDHIGH  .UshortValue )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object PAN_LEFT_LOW_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 69;
            SENDCMDWITHSPEED (  __context__ , "camera pan left", (ushort)( PANSPEEDLOW  .UshortValue )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object PAN_RIGHT_HIGH_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 73;
        SENDCMDWITHSPEED (  __context__ , "camera pan right", (ushort)( PANSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PAN_RIGHT_LOW_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 77;
        SENDCMDWITHSPEED (  __context__ , "camera pan right", (ushort)( PANSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_UP_HIGH_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 81;
        SENDCMDWITHSPEED (  __context__ , "camera tilt up", (ushort)( TILTSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_UP_LOW_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        SENDCMDWITHSPEED (  __context__ , "camera tilt up", (ushort)( TILTSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_DOWN_HIGH_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 89;
        SENDCMDWITHSPEED (  __context__ , "camera tilt down", (ushort)( TILTSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_DOWN_LOW_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 93;
        SENDCMDWITHSPEED (  __context__ , "camera tilt down", (ushort)( TILTSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ZOOM_IN_HIGH_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 97;
        SENDCMDWITHSPEED (  __context__ , "camera zoom in", (ushort)( ZOOMSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ZOOM_IN_LOW_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 101;
        SENDCMDWITHSPEED (  __context__ , "camera zoom in", (ushort)( ZOOMSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ZOOM_OUT_HIGH_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 105;
        SENDCMDWITHSPEED (  __context__ , "camera zoom out", (ushort)( ZOOMSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ZOOM_OUT_LOW_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 109;
        SENDCMDWITHSPEED (  __context__ , "camera zoom out", (ushort)( ZOOMSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOCUS_FAR_HIGH_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 113;
        SENDCMDWITHSPEED (  __context__ , "camera focus far", (ushort)( FOCUSSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOCUS_FAR_LOW_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 117;
        SENDCMDWITHSPEED (  __context__ , "camera focus far", (ushort)( FOCUSSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOCUS_NEAR_HIGH_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 121;
        SENDCMDWITHSPEED (  __context__ , "camera focus near", (ushort)( FOCUSSPEEDHIGH  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOCUS_NEAR_LOW_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 125;
        SENDCMDWITHSPEED (  __context__ , "camera focus near", (ushort)( FOCUSSPEEDLOW  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PAN_STOP_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 129;
        SENDCMDWITHOUTSPEED (  __context__ , "camera pan stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TILT_STOP_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 133;
        SENDCMDWITHOUTSPEED (  __context__ , "camera tilt stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ZOOM_STOP_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 137;
        SENDCMDWITHOUTSPEED (  __context__ , "camera zoom stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOCUS_STOP_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        SENDCMDWITHOUTSPEED (  __context__ , "camera focus stop") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 80, this );
    SPD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    
    PAN_LEFT_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( PAN_LEFT_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( PAN_LEFT_HIGH__DigitalInput__, PAN_LEFT_HIGH );
    
    PAN_LEFT_LOW = new Crestron.Logos.SplusObjects.DigitalInput( PAN_LEFT_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( PAN_LEFT_LOW__DigitalInput__, PAN_LEFT_LOW );
    
    PAN_RIGHT_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( PAN_RIGHT_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( PAN_RIGHT_HIGH__DigitalInput__, PAN_RIGHT_HIGH );
    
    PAN_RIGHT_LOW = new Crestron.Logos.SplusObjects.DigitalInput( PAN_RIGHT_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( PAN_RIGHT_LOW__DigitalInput__, PAN_RIGHT_LOW );
    
    TILT_UP_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( TILT_UP_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_UP_HIGH__DigitalInput__, TILT_UP_HIGH );
    
    TILT_UP_LOW = new Crestron.Logos.SplusObjects.DigitalInput( TILT_UP_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_UP_LOW__DigitalInput__, TILT_UP_LOW );
    
    TILT_DOWN_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( TILT_DOWN_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_DOWN_HIGH__DigitalInput__, TILT_DOWN_HIGH );
    
    TILT_DOWN_LOW = new Crestron.Logos.SplusObjects.DigitalInput( TILT_DOWN_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_DOWN_LOW__DigitalInput__, TILT_DOWN_LOW );
    
    ZOOM_IN_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( ZOOM_IN_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( ZOOM_IN_HIGH__DigitalInput__, ZOOM_IN_HIGH );
    
    ZOOM_IN_LOW = new Crestron.Logos.SplusObjects.DigitalInput( ZOOM_IN_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( ZOOM_IN_LOW__DigitalInput__, ZOOM_IN_LOW );
    
    ZOOM_OUT_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( ZOOM_OUT_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( ZOOM_OUT_HIGH__DigitalInput__, ZOOM_OUT_HIGH );
    
    ZOOM_OUT_LOW = new Crestron.Logos.SplusObjects.DigitalInput( ZOOM_OUT_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( ZOOM_OUT_LOW__DigitalInput__, ZOOM_OUT_LOW );
    
    FOCUS_NEAR_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( FOCUS_NEAR_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( FOCUS_NEAR_HIGH__DigitalInput__, FOCUS_NEAR_HIGH );
    
    FOCUS_NEAR_LOW = new Crestron.Logos.SplusObjects.DigitalInput( FOCUS_NEAR_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( FOCUS_NEAR_LOW__DigitalInput__, FOCUS_NEAR_LOW );
    
    FOCUS_FAR_HIGH = new Crestron.Logos.SplusObjects.DigitalInput( FOCUS_FAR_HIGH__DigitalInput__, this );
    m_DigitalInputList.Add( FOCUS_FAR_HIGH__DigitalInput__, FOCUS_FAR_HIGH );
    
    FOCUS_FAR_LOW = new Crestron.Logos.SplusObjects.DigitalInput( FOCUS_FAR_LOW__DigitalInput__, this );
    m_DigitalInputList.Add( FOCUS_FAR_LOW__DigitalInput__, FOCUS_FAR_LOW );
    
    PAN_STOP = new Crestron.Logos.SplusObjects.DigitalInput( PAN_STOP__DigitalInput__, this );
    m_DigitalInputList.Add( PAN_STOP__DigitalInput__, PAN_STOP );
    
    TILT_STOP = new Crestron.Logos.SplusObjects.DigitalInput( TILT_STOP__DigitalInput__, this );
    m_DigitalInputList.Add( TILT_STOP__DigitalInput__, TILT_STOP );
    
    ZOOM_STOP = new Crestron.Logos.SplusObjects.DigitalInput( ZOOM_STOP__DigitalInput__, this );
    m_DigitalInputList.Add( ZOOM_STOP__DigitalInput__, ZOOM_STOP );
    
    FOCUS_STOP = new Crestron.Logos.SplusObjects.DigitalInput( FOCUS_STOP__DigitalInput__, this );
    m_DigitalInputList.Add( FOCUS_STOP__DigitalInput__, FOCUS_STOP );
    
    PANSPEEDHIGH = new Crestron.Logos.SplusObjects.AnalogInput( PANSPEEDHIGH__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PANSPEEDHIGH__AnalogSerialInput__, PANSPEEDHIGH );
    
    PANSPEEDLOW = new Crestron.Logos.SplusObjects.AnalogInput( PANSPEEDLOW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( PANSPEEDLOW__AnalogSerialInput__, PANSPEEDLOW );
    
    TILTSPEEDHIGH = new Crestron.Logos.SplusObjects.AnalogInput( TILTSPEEDHIGH__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TILTSPEEDHIGH__AnalogSerialInput__, TILTSPEEDHIGH );
    
    TILTSPEEDLOW = new Crestron.Logos.SplusObjects.AnalogInput( TILTSPEEDLOW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( TILTSPEEDLOW__AnalogSerialInput__, TILTSPEEDLOW );
    
    ZOOMSPEEDHIGH = new Crestron.Logos.SplusObjects.AnalogInput( ZOOMSPEEDHIGH__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ZOOMSPEEDHIGH__AnalogSerialInput__, ZOOMSPEEDHIGH );
    
    ZOOMSPEEDLOW = new Crestron.Logos.SplusObjects.AnalogInput( ZOOMSPEEDLOW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ZOOMSPEEDLOW__AnalogSerialInput__, ZOOMSPEEDLOW );
    
    FOCUSSPEEDHIGH = new Crestron.Logos.SplusObjects.AnalogInput( FOCUSSPEEDHIGH__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FOCUSSPEEDHIGH__AnalogSerialInput__, FOCUSSPEEDHIGH );
    
    FOCUSSPEEDLOW = new Crestron.Logos.SplusObjects.AnalogInput( FOCUSSPEEDLOW__AnalogSerialInput__, this );
    m_AnalogInputList.Add( FOCUSSPEEDLOW__AnalogSerialInput__, FOCUSSPEEDLOW );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    
    PAN_LEFT_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( PAN_LEFT_HIGH_OnPush_0, false ) );
    PAN_LEFT_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( PAN_LEFT_LOW_OnPush_1, false ) );
    PAN_RIGHT_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( PAN_RIGHT_HIGH_OnPush_2, false ) );
    PAN_RIGHT_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( PAN_RIGHT_LOW_OnPush_3, false ) );
    TILT_UP_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_UP_HIGH_OnPush_4, false ) );
    TILT_UP_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_UP_LOW_OnPush_5, false ) );
    TILT_DOWN_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_DOWN_HIGH_OnPush_6, false ) );
    TILT_DOWN_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_DOWN_LOW_OnPush_7, false ) );
    ZOOM_IN_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZOOM_IN_HIGH_OnPush_8, false ) );
    ZOOM_IN_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZOOM_IN_LOW_OnPush_9, false ) );
    ZOOM_OUT_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZOOM_OUT_HIGH_OnPush_10, false ) );
    ZOOM_OUT_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZOOM_OUT_LOW_OnPush_11, false ) );
    FOCUS_FAR_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOCUS_FAR_HIGH_OnPush_12, false ) );
    FOCUS_FAR_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOCUS_FAR_LOW_OnPush_13, false ) );
    FOCUS_NEAR_HIGH.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOCUS_NEAR_HIGH_OnPush_14, false ) );
    FOCUS_NEAR_LOW.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOCUS_NEAR_LOW_OnPush_15, false ) );
    PAN_STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( PAN_STOP_OnPush_16, false ) );
    TILT_STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( TILT_STOP_OnPush_17, false ) );
    ZOOM_STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( ZOOM_STOP_OnPush_18, false ) );
    FOCUS_STOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOCUS_STOP_OnPush_19, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_VADDIO_ROBOSHOT_COMMAND_LIBRARY ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint PAN_LEFT_HIGH__DigitalInput__ = 0;
const uint PAN_LEFT_LOW__DigitalInput__ = 1;
const uint PAN_RIGHT_HIGH__DigitalInput__ = 2;
const uint PAN_RIGHT_LOW__DigitalInput__ = 3;
const uint TILT_UP_HIGH__DigitalInput__ = 4;
const uint TILT_UP_LOW__DigitalInput__ = 5;
const uint TILT_DOWN_HIGH__DigitalInput__ = 6;
const uint TILT_DOWN_LOW__DigitalInput__ = 7;
const uint ZOOM_IN_HIGH__DigitalInput__ = 8;
const uint ZOOM_IN_LOW__DigitalInput__ = 9;
const uint ZOOM_OUT_HIGH__DigitalInput__ = 10;
const uint ZOOM_OUT_LOW__DigitalInput__ = 11;
const uint FOCUS_NEAR_HIGH__DigitalInput__ = 12;
const uint FOCUS_NEAR_LOW__DigitalInput__ = 13;
const uint FOCUS_FAR_HIGH__DigitalInput__ = 14;
const uint FOCUS_FAR_LOW__DigitalInput__ = 15;
const uint PAN_STOP__DigitalInput__ = 16;
const uint TILT_STOP__DigitalInput__ = 17;
const uint ZOOM_STOP__DigitalInput__ = 18;
const uint FOCUS_STOP__DigitalInput__ = 19;
const uint PANSPEEDHIGH__AnalogSerialInput__ = 0;
const uint PANSPEEDLOW__AnalogSerialInput__ = 1;
const uint TILTSPEEDHIGH__AnalogSerialInput__ = 2;
const uint TILTSPEEDLOW__AnalogSerialInput__ = 3;
const uint ZOOMSPEEDHIGH__AnalogSerialInput__ = 4;
const uint ZOOMSPEEDLOW__AnalogSerialInput__ = 5;
const uint FOCUSSPEEDHIGH__AnalogSerialInput__ = 6;
const uint FOCUSSPEEDLOW__AnalogSerialInput__ = 7;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;

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
