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
        Crestron.Logos.SplusObjects.DigitalInput POLL;
        Crestron.Logos.SplusObjects.DigitalInput UP;
        Crestron.Logos.SplusObjects.DigitalInput DOWN;
        Crestron.Logos.SplusObjects.DigitalInput ALLON;
        Crestron.Logos.SplusObjects.DigitalInput ALLOFF;
        Crestron.Logos.SplusObjects.AnalogInput CHANNEL_ID;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SCENE;
        Crestron.Logos.SplusObjects.StringInput RX__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput DEBUG_FB;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput CHANNEL_ID_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> CHANNEL_ON;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> CHANNEL_LEVEL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> SCENESTATUS;
        UShortParameter ALL_CHANNEL;
        UShortParameter STEP_PCT;
        UShortParameter INIT_DELAY_CS;
        UShortParameter REPEAT_CS;
        ushort HOLDUP = 0;
        ushort HOLDDOWN = 0;
        ushort DEBUGENABLE = 0;
        ushort CURRENTCHANNEL = 0;
        CrestronString RXBUFF__DOLLAR__;
        private void SETCHANNEL (  SplusExecutionContext __context__, ushort CH ) 
            { 
            
            __context__.SourceCodeLine = 62;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CH < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 64;
                CH = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 66;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CH > 255 ))  ) ) 
                { 
                __context__.SourceCodeLine = 68;
                CH = (ushort) ( 255 ) ; 
                } 
            
            __context__.SourceCodeLine = 70;
            CURRENTCHANNEL = (ushort) ( CH ) ; 
            __context__.SourceCodeLine = 71;
            CHANNEL_ID_FB  .Value = (ushort) ( CURRENTCHANNEL ) ; 
            
            }
            
        private ushort GETACTIVECHANNEL (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 76;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( CURRENTCHANNEL < 1 ))  ) ) 
                { 
                __context__.SourceCodeLine = 78;
                return (ushort)( ALL_CHANNEL  .Value) ; 
                } 
            
            __context__.SourceCodeLine = 80;
            return (ushort)( CURRENTCHANNEL) ; 
            
            }
            
        private ushort GETBYTE (  SplusExecutionContext __context__, CrestronString SOURCE , ushort INDEX ) 
            { 
            CrestronString ONE__DOLLAR__;
            ONE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            ushort VAL = 0;
            
            
            __context__.SourceCodeLine = 87;
            ONE__DOLLAR__  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( INDEX ) ,  (int) ( 1 ) )  ) ; 
            __context__.SourceCodeLine = 88;
            VAL = (ushort) ( Functions.GetC( ONE__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 89;
            return (ushort)( VAL) ; 
            
            }
            
        private ushort GETPOLLDATABYTE (  SplusExecutionContext __context__, CrestronString PACKET__DOLLAR__ , ushort DATAINDEX ) 
            { 
            ushort BYTEINDEX = 0;
            
            
            __context__.SourceCodeLine = 94;
            BYTEINDEX = (ushort) ( (4 + DATAINDEX) ) ; 
            __context__.SourceCodeLine = 95;
            return (ushort)( GETBYTE( __context__ , PACKET__DOLLAR__ , (ushort)( BYTEINDEX ) )) ; 
            
            }
            
        private void SENDPOLL (  SplusExecutionContext __context__ ) 
            { 
            ushort B0 = 0;
            ushort B1 = 0;
            ushort B2 = 0;
            ushort B3 = 0;
            ushort CK1 = 0;
            ushort CK2 = 0;
            
            
            __context__.SourceCodeLine = 101;
            B0 = (ushort) ( 165 ) ; 
            __context__.SourceCodeLine = 102;
            B1 = (ushort) ( 5 ) ; 
            __context__.SourceCodeLine = 103;
            B2 = (ushort) ( 12 ) ; 
            __context__.SourceCodeLine = 104;
            CK1 = (ushort) ( (255 ^ (B0 ^ B2)) ) ; 
            __context__.SourceCodeLine = 105;
            CK2 = (ushort) ( (255 ^ B1) ) ; 
            __context__.SourceCodeLine = 106;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2}{3}{4}", Functions.Chr ( (B0 & 255) ) , Functions.Chr ( (B1 & 255) ) , Functions.Chr ( (B2 & 255) ) , Functions.Chr ( (CK1 & 255) ) , Functions.Chr ( (CK2 & 255) ) ) ; 
            
            }
            
        private void SENDSCENE (  SplusExecutionContext __context__, ushort N ) 
            { 
            ushort B0 = 0;
            ushort B1 = 0;
            ushort B2 = 0;
            ushort B3 = 0;
            ushort CK1 = 0;
            ushort CK2 = 0;
            
            
            __context__.SourceCodeLine = 112;
            B0 = (ushort) ( 165 ) ; 
            __context__.SourceCodeLine = 112;
            B1 = (ushort) ( 6 ) ; 
            __context__.SourceCodeLine = 112;
            B2 = (ushort) ( 133 ) ; 
            __context__.SourceCodeLine = 112;
            B3 = (ushort) ( N ) ; 
            __context__.SourceCodeLine = 113;
            CK1 = (ushort) ( ((B0 ^ B2) ^ 255) ) ; 
            __context__.SourceCodeLine = 114;
            CK2 = (ushort) ( ((B1 ^ B3) ^ 255) ) ; 
            __context__.SourceCodeLine = 115;
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
            
            
            __context__.SourceCodeLine = 122;
            B0 = (ushort) ( 165 ) ; 
            __context__.SourceCodeLine = 122;
            B1 = (ushort) ( 8 ) ; 
            __context__.SourceCodeLine = 122;
            B2 = (ushort) ( 122 ) ; 
            __context__.SourceCodeLine = 122;
            B3 = (ushort) ( CH ) ; 
            __context__.SourceCodeLine = 122;
            B4 = (ushort) ( ACTION ) ; 
            __context__.SourceCodeLine = 122;
            B5 = (ushort) ( AMOUNT ) ; 
            __context__.SourceCodeLine = 123;
            CK1 = (ushort) ( (((B0 ^ B2) ^ B4) ^ 255) ) ; 
            __context__.SourceCodeLine = 124;
            CK2 = (ushort) ( (((B1 ^ B3) ^ B5) ^ 255) ) ; 
            __context__.SourceCodeLine = 125;
            MakeString ( TX__DOLLAR__ , "{0}{1}{2}{3}{4}{5}{6}{7}", Functions.Chr ( (B0 & 255) ) , Functions.Chr ( (B1 & 255) ) , Functions.Chr ( (B2 & 255) ) , Functions.Chr ( (B3 & 255) ) , Functions.Chr ( (B4 & 255) ) , Functions.Chr ( (B5 & 255) ) , Functions.Chr ( (CK1 & 255) ) , Functions.Chr ( (CK2 & 255) ) ) ; 
            
            }
            
        private void STEPUP (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 130;
            SENDEXERT (  __context__ , (ushort)( GETACTIVECHANNEL( __context__ ) ), (ushort)( 3 ), (ushort)( STEP_PCT  .Value )) ; 
            
            }
            
        private void STEPDOWN (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 131;
            SENDEXERT (  __context__ , (ushort)( GETACTIVECHANNEL( __context__ ) ), (ushort)( 4 ), (ushort)( STEP_PCT  .Value )) ; 
            
            }
            
        private void ALLONFUNC (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 132;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 1 ), (ushort)( 0 )) ; 
            
            }
            
        private void ALLOFFFUNC (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 133;
            SENDEXERT (  __context__ , (ushort)( ALL_CHANNEL  .Value ), (ushort)( 2 ), (ushort)( 0 )) ; 
            
            }
            
        private void SETDEBUG (  SplusExecutionContext __context__, ushort VAL ) 
            { 
            
            __context__.SourceCodeLine = 136;
            DEBUGENABLE = (ushort) ( Functions.BoolToInt (VAL != 0) ) ; 
            __context__.SourceCodeLine = 137;
            DEBUG_FB  .Value = (ushort) ( DEBUGENABLE ) ; 
            
            }
            
        private void HANDLEACK (  SplusExecutionContext __context__, CrestronString PACKET__DOLLAR__ ) 
            { 
            ushort CMDSUBJECT = 0;
            
            ushort CODE = 0;
            
            
            __context__.SourceCodeLine = 144;
            CMDSUBJECT = (ushort) ( GETBYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 4 ) ) ) ; 
            __context__.SourceCodeLine = 145;
            CODE = (ushort) ( GETBYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 5 ) ) ) ; 
            __context__.SourceCodeLine = 146;
            if ( Functions.TestForTrue  ( ( DEBUGENABLE)  ) ) 
                { 
                __context__.SourceCodeLine = 148;
                Print( "Niox Ack: sub=0x{0:X2} code=0x{1:X2}\r\n", CMDSUBJECT, CODE) ; 
                } 
            
            
            }
            
        private void HANDLEPOLLRESPONSE (  SplusExecutionContext __context__, CrestronString PACKET__DOLLAR__ ) 
            { 
            ushort B0 = 0;
            ushort B1 = 0;
            
            ushort I = 0;
            ushort LEVEL = 0;
            ushort S = 0;
            
            ushort SBYTE = 0;
            
            
            __context__.SourceCodeLine = 156;
            B0 = (ushort) ( GETPOLLDATABYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 0 ) ) ) ; 
            __context__.SourceCodeLine = 157;
            CHANNEL_ON [ 9]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 1) != 0) ) ; 
            __context__.SourceCodeLine = 158;
            CHANNEL_ON [ 10]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 2) != 0) ) ; 
            __context__.SourceCodeLine = 159;
            CHANNEL_ON [ 11]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 4) != 0) ) ; 
            __context__.SourceCodeLine = 160;
            CHANNEL_ON [ 12]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 8) != 0) ) ; 
            __context__.SourceCodeLine = 161;
            CHANNEL_ON [ 13]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 16) != 0) ) ; 
            __context__.SourceCodeLine = 162;
            CHANNEL_ON [ 14]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 32) != 0) ) ; 
            __context__.SourceCodeLine = 163;
            CHANNEL_ON [ 15]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 64) != 0) ) ; 
            __context__.SourceCodeLine = 164;
            CHANNEL_ON [ 16]  .Value = (ushort) ( Functions.BoolToInt ((B0 & 128) != 0) ) ; 
            __context__.SourceCodeLine = 165;
            B1 = (ushort) ( GETPOLLDATABYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 1 ) ) ) ; 
            __context__.SourceCodeLine = 166;
            CHANNEL_ON [ 1]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 1) != 0) ) ; 
            __context__.SourceCodeLine = 167;
            CHANNEL_ON [ 2]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 2) != 0) ) ; 
            __context__.SourceCodeLine = 168;
            CHANNEL_ON [ 3]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 4) != 0) ) ; 
            __context__.SourceCodeLine = 169;
            CHANNEL_ON [ 4]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 8) != 0) ) ; 
            __context__.SourceCodeLine = 170;
            CHANNEL_ON [ 5]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 16) != 0) ) ; 
            __context__.SourceCodeLine = 171;
            CHANNEL_ON [ 6]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 32) != 0) ) ; 
            __context__.SourceCodeLine = 172;
            CHANNEL_ON [ 7]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 64) != 0) ) ; 
            __context__.SourceCodeLine = 173;
            CHANNEL_ON [ 8]  .Value = (ushort) ( Functions.BoolToInt ((B1 & 128) != 0) ) ; 
            __context__.SourceCodeLine = 174;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)16; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 176;
                LEVEL = (ushort) ( GETPOLLDATABYTE( __context__ , PACKET__DOLLAR__ , (ushort)( (I + 1) ) ) ) ; 
                __context__.SourceCodeLine = 177;
                CHANNEL_LEVEL [ I]  .Value = (ushort) ( LEVEL ) ; 
                __context__.SourceCodeLine = 174;
                } 
            
            __context__.SourceCodeLine = 179;
            S = (ushort) ( GETPOLLDATABYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 18 ) ) ) ; 
            __context__.SourceCodeLine = 180;
            SCENESTATUS [ 1]  .Value = (ushort) ( (S / 16) ) ; 
            __context__.SourceCodeLine = 181;
            SCENESTATUS [ 2]  .Value = (ushort) ( (S & 15) ) ; 
            __context__.SourceCodeLine = 182;
            S = (ushort) ( GETPOLLDATABYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 19 ) ) ) ; 
            __context__.SourceCodeLine = 183;
            SCENESTATUS [ 3]  .Value = (ushort) ( (S / 16) ) ; 
            __context__.SourceCodeLine = 184;
            SCENESTATUS [ 4]  .Value = (ushort) ( (S & 15) ) ; 
            __context__.SourceCodeLine = 185;
            if ( Functions.TestForTrue  ( ( DEBUGENABLE)  ) ) 
                { 
                __context__.SourceCodeLine = 187;
                Print( "Poll response parsed. \r\n") ; 
                } 
            
            
            }
            
        private void PROCESSRX (  SplusExecutionContext __context__ ) 
            { 
            ushort BUFLEN = 0;
            ushort SYNCPOS = 0;
            ushort PKTLEN = 0;
            ushort SUBJECT = 0;
            
            CrestronString PACKET__DOLLAR__;
            PACKET__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 64, this );
            
            
            __context__.SourceCodeLine = 194;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 196;
                BUFLEN = (ushort) ( Functions.Length( RXBUFF__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 197;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( BUFLEN < 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 199;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 201;
                SYNCPOS = (ushort) ( Functions.Find( "\u00A5" , RXBUFF__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 202;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYNCPOS == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 204;
                    RXBUFF__DOLLAR__  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 205;
                    return ; 
                    } 
                
                __context__.SourceCodeLine = 207;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SYNCPOS > 1 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 209;
                    RXBUFF__DOLLAR__  .UpdateValue ( Functions.Mid ( RXBUFF__DOLLAR__ ,  (int) ( SYNCPOS ) ,  (int) ( ((BUFLEN - SYNCPOS) + 1) ) )  ) ; 
                    __context__.SourceCodeLine = 210;
                    BUFLEN = (ushort) ( Functions.Length( RXBUFF__DOLLAR__ ) ) ; 
                    __context__.SourceCodeLine = 211;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( BUFLEN < 5 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 213;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 215;
                    PKTLEN = (ushort) ( GETBYTE( __context__ , RXBUFF__DOLLAR__ , (ushort)( 2 ) ) ) ; 
                    __context__.SourceCodeLine = 216;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( BUFLEN < PKTLEN ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 218;
                        return ; 
                        } 
                    
                    __context__.SourceCodeLine = 220;
                    PACKET__DOLLAR__  .UpdateValue ( Functions.Mid ( RXBUFF__DOLLAR__ ,  (int) ( 1 ) ,  (int) ( PKTLEN ) )  ) ; 
                    __context__.SourceCodeLine = 221;
                    RXBUFF__DOLLAR__  .UpdateValue ( Functions.Mid ( RXBUFF__DOLLAR__ ,  (int) ( (PKTLEN + 1) ) ,  (int) ( (BUFLEN - PKTLEN) ) )  ) ; 
                    __context__.SourceCodeLine = 222;
                    SUBJECT = (ushort) ( GETBYTE( __context__ , PACKET__DOLLAR__ , (ushort)( 3 ) ) ) ; 
                    __context__.SourceCodeLine = 223;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SUBJECT == 4))  ) ) 
                        { 
                        __context__.SourceCodeLine = 225;
                        HANDLEACK (  __context__ , PACKET__DOLLAR__) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 227;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SUBJECT == 13))  ) ) 
                            { 
                            __context__.SourceCodeLine = 229;
                            HANDLEPOLLRESPONSE (  __context__ , PACKET__DOLLAR__) ; 
                            } 
                        
                        }
                    
                    } 
                
                __context__.SourceCodeLine = 194;
                } 
            
            
            }
            
        private void UPTICK (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 237;
            if ( Functions.TestForTrue  ( ( HOLDUP)  ) ) 
                { 
                __context__.SourceCodeLine = 239;
                STEPUP (  __context__  ) ; 
                __context__.SourceCodeLine = 240;
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
                
            
            __context__.SourceCodeLine = 240;
            UPTICK (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void DOWNTICK (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 246;
        if ( Functions.TestForTrue  ( ( HOLDDOWN)  ) ) 
            { 
            __context__.SourceCodeLine = 248;
            STEPDOWN (  __context__  ) ; 
            __context__.SourceCodeLine = 249;
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
            
            
            __context__.SourceCodeLine = 249;
            DOWNTICK (  __context__  ) ; 
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
object POLL_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 257;
        SENDPOLL (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CHANNEL_ID_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 261;
        SETCHANNEL (  __context__ , (ushort)( CHANNEL_ID  .UshortValue )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SCENE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IDX = 0;
        
        
        __context__.SourceCodeLine = 266;
        IDX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 267;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IDX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IDX <= 4 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 267;
            SENDSCENE (  __context__ , (ushort)( IDX )) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object UP_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 272;
        HOLDUP = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 273;
        STEPUP (  __context__  ) ; 
        __context__.SourceCodeLine = 274;
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
        
            
            __context__.SourceCodeLine = 274;
            UPTICK (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object UP_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 278;
        HOLDUP = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 279;
        CancelWait ( "UPSTART" ) ; 
        __context__.SourceCodeLine = 280;
        CancelWait ( "UPREPEAT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOWN_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 285;
        HOLDDOWN = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 286;
        STEPDOWN (  __context__  ) ; 
        __context__.SourceCodeLine = 287;
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
        
            
            __context__.SourceCodeLine = 287;
            DOWNTICK (  __context__  ) ; 
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object DOWN_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 291;
        HOLDDOWN = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 292;
        CancelWait ( "DOWNSTART" ) ; 
        __context__.SourceCodeLine = 293;
        CancelWait ( "DOWNREPEAT" ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

private void KILLWAITS (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 297;
    HOLDUP = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 298;
    HOLDDOWN = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 299;
    CancelWait ( "UPSTART" ) ; 
    __context__.SourceCodeLine = 300;
    CancelWait ( "UPREPEAT" ) ; 
    __context__.SourceCodeLine = 301;
    CancelWait ( "DOWNSTART" ) ; 
    __context__.SourceCodeLine = 302;
    CancelWait ( "DOWNREPEAT" ) ; 
    
    }
    
object ALLON_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 306;
        KILLWAITS (  __context__  ) ; 
        __context__.SourceCodeLine = 307;
        ALLONFUNC (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ALLOFF_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 312;
        KILLWAITS (  __context__  ) ; 
        __context__.SourceCodeLine = 313;
        ALLOFFFUNC (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEBUG_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 318;
        SETDEBUG (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DEBUG_OnRelease_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 322;
        SETDEBUG (  __context__ , (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    RXBUFF__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 512, this );
    
    DEBUG = new Crestron.Logos.SplusObjects.DigitalInput( DEBUG__DigitalInput__, this );
    m_DigitalInputList.Add( DEBUG__DigitalInput__, DEBUG );
    
    POLL = new Crestron.Logos.SplusObjects.DigitalInput( POLL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL__DigitalInput__, POLL );
    
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
    
    CHANNEL_ON = new InOutArray<DigitalOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        CHANNEL_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( CHANNEL_ON__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( CHANNEL_ON__DigitalOutput__ + i, CHANNEL_ON[i+1] );
    }
    
    CHANNEL_ID = new Crestron.Logos.SplusObjects.AnalogInput( CHANNEL_ID__AnalogSerialInput__, this );
    m_AnalogInputList.Add( CHANNEL_ID__AnalogSerialInput__, CHANNEL_ID );
    
    CHANNEL_ID_FB = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_ID_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CHANNEL_ID_FB__AnalogSerialOutput__, CHANNEL_ID_FB );
    
    CHANNEL_LEVEL = new InOutArray<AnalogOutput>( 16, this );
    for( uint i = 0; i < 16; i++ )
    {
        CHANNEL_LEVEL[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( CHANNEL_LEVEL__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( CHANNEL_LEVEL__AnalogSerialOutput__ + i, CHANNEL_LEVEL[i+1] );
    }
    
    SCENESTATUS = new InOutArray<AnalogOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        SCENESTATUS[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( SCENESTATUS__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( SCENESTATUS__AnalogSerialOutput__ + i, SCENESTATUS[i+1] );
    }
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( RX__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
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
    
    POLL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_OnPush_0, false ) );
    CHANNEL_ID.OnAnalogChange.Add( new InputChangeHandlerWrapper( CHANNEL_ID_OnChange_1, false ) );
    for( uint i = 0; i < 4; i++ )
        SCENE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SCENE_OnPush_2, false ) );
        
    UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( UP_OnPush_3, false ) );
    UP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( UP_OnRelease_4, false ) );
    DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( DOWN_OnPush_5, false ) );
    DOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DOWN_OnRelease_6, false ) );
    ALLON.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLON_OnPush_7, false ) );
    ALLOFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ALLOFF_OnPush_8, false ) );
    DEBUG.OnDigitalPush.Add( new InputChangeHandlerWrapper( DEBUG_OnPush_9, false ) );
    DEBUG.OnDigitalRelease.Add( new InputChangeHandlerWrapper( DEBUG_OnRelease_10, false ) );
    
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
const uint POLL__DigitalInput__ = 1;
const uint UP__DigitalInput__ = 2;
const uint DOWN__DigitalInput__ = 3;
const uint ALLON__DigitalInput__ = 4;
const uint ALLOFF__DigitalInput__ = 5;
const uint CHANNEL_ID__AnalogSerialInput__ = 0;
const uint SCENE__DigitalInput__ = 6;
const uint RX__DOLLAR____AnalogSerialInput__ = 1;
const uint DEBUG_FB__DigitalOutput__ = 0;
const uint TX__DOLLAR____AnalogSerialOutput__ = 0;
const uint CHANNEL_ID_FB__AnalogSerialOutput__ = 1;
const uint CHANNEL_ON__DigitalOutput__ = 1;
const uint CHANNEL_LEVEL__AnalogSerialOutput__ = 2;
const uint SCENESTATUS__AnalogSerialOutput__ = 18;
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
