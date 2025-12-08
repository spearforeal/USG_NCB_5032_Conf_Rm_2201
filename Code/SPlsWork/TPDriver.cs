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

namespace UserModule_TPDRIVER
{
    public class UserModuleClass_TPDRIVER : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput STARTUP;
        Crestron.Logos.SplusObjects.DigitalInput SHUTDOWNSUBPAGE;
        Crestron.Logos.SplusObjects.DigitalInput SHUTDOWNCONFIRM;
        Crestron.Logos.SplusObjects.DigitalInput SHUTDOWNCANCEL;
        Crestron.Logos.SplusObjects.DigitalInput STARTPAGETRIGGER;
        Crestron.Logos.SplusObjects.DigitalInput INDEXPAGETRIGGER;
        Crestron.Logos.SplusObjects.DigitalInput CLOSEALLPAGES;
        Crestron.Logos.SplusObjects.DigitalInput FOOTERCLOSE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> FOOTER;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU1SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU2SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU3SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU4SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU5SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU6SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU7SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU8SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU9SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU10SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU11SUB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MENU12SUB;
        Crestron.Logos.SplusObjects.DigitalOutput SYSTEMON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SYSTEMOFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput SHUTDOWNPAGE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput STARTPAGE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput INDEXPAGE_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> FOOTER_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU1SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU2SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU3SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU4SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU5SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU6SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU7SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU8SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU9SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU10SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU11SUB_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MENU12SUB_FB;
        ushort X = 0;
        private void FNCLOSEALLFOOTERS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 81;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)7; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 83;
                FOOTER_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 81;
                } 
            
            
            }
            
        private void FNCLOSEALLPAGES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 88;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)12; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 90;
                MENU_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 91;
                MENU1SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 92;
                MENU2SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 93;
                MENU3SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 94;
                MENU4SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 95;
                MENU5SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 96;
                MENU6SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 97;
                MENU7SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 98;
                MENU8SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 99;
                MENU9SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 100;
                MENU10SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 101;
                MENU11SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 102;
                MENU12SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 88;
                } 
            
            
            }
            
        object STARTPAGETRIGGER_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 107;
                Functions.Pulse ( 50, STARTPAGE_FB ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object INDEXPAGETRIGGER_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 111;
            Functions.Pulse ( 50, INDEXPAGE_FB ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object STARTUP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 115;
        STARTPAGE_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 116;
        SYSTEMON_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 117;
        SYSTEMOFF_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 118;
        SHUTDOWNPAGE_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 119;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)7; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 121;
            FOOTER_FB [ X]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 119;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHUTDOWNCONFIRM_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 126;
        INDEXPAGE_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 127;
        SYSTEMON_FB  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 128;
        SYSTEMOFF_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 129;
        SHUTDOWNPAGE_FB  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHUTDOWNSUBPAGE_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 133;
        SHUTDOWNPAGE_FB  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SHUTDOWNCANCEL_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 137;
        SHUTDOWNPAGE_FB  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CLOSEALLPAGES_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 141;
        FNCLOSEALLPAGES (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 145;
        FNCLOSEALLPAGES (  __context__  ) ; 
        __context__.SourceCodeLine = 146;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 148;
            MENU_FB [ X]  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 146;
            } 
        
        __context__.SourceCodeLine = 150;
        MENU_FB [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ )]  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU1SUB_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 154;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 156;
            if ( Functions.TestForTrue  ( ( MENU1SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 156;
                MENU1SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 157;
                MENU1SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 154;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU2SUB_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 162;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 164;
            if ( Functions.TestForTrue  ( ( MENU2SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 164;
                MENU2SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 165;
                MENU2SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 162;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU3SUB_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 171;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 173;
            if ( Functions.TestForTrue  ( ( MENU3SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 173;
                MENU3SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 174;
                MENU3SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 171;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU4SUB_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 180;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 182;
            if ( Functions.TestForTrue  ( ( MENU4SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 182;
                MENU4SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 183;
                MENU4SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 180;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU5SUB_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 188;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 190;
            if ( Functions.TestForTrue  ( ( MENU5SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 190;
                MENU5SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 191;
                MENU5SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 188;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU6SUB_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 196;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 198;
            if ( Functions.TestForTrue  ( ( MENU6SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 198;
                MENU6SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 199;
                MENU6SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 196;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU7SUB_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 204;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 206;
            if ( Functions.TestForTrue  ( ( MENU7SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 206;
                MENU7SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 207;
                MENU7SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 204;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU8SUB_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 212;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 214;
            if ( Functions.TestForTrue  ( ( MENU8SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 214;
                MENU8SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 215;
                MENU8SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 212;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU9SUB_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 220;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 222;
            if ( Functions.TestForTrue  ( ( MENU9SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 222;
                MENU9SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 223;
                MENU9SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 220;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU10SUB_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 228;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 230;
            if ( Functions.TestForTrue  ( ( MENU10SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 230;
                MENU10SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 231;
                MENU10SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 228;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU11SUB_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 236;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 238;
            if ( Functions.TestForTrue  ( ( MENU11SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 238;
                MENU11SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 239;
                MENU11SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 236;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MENU12SUB_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 244;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)12; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 246;
            if ( Functions.TestForTrue  ( ( MENU12SUB[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 246;
                MENU12SUB_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 247;
                MENU12SUB_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 244;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOOTER_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 252;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)7; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( X  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (X  >= __FN_FORSTART_VAL__1) && (X  <= __FN_FOREND_VAL__1) ) : ( (X  <= __FN_FORSTART_VAL__1) && (X  >= __FN_FOREND_VAL__1) ) ; X  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 254;
            if ( Functions.TestForTrue  ( ( FOOTER[ X ] .Value)  ) ) 
                {
                __context__.SourceCodeLine = 254;
                FOOTER_FB [ X]  .Value = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 255;
                FOOTER_FB [ X]  .Value = (ushort) ( 0 ) ; 
                }
            
            __context__.SourceCodeLine = 252;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FOOTERCLOSE_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 260;
        FNCLOSEALLFOOTERS (  __context__  ) ; 
        
        
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
        
        __context__.SourceCodeLine = 265;
        SYSTEMOFF_FB  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 266;
        STARTPAGE_FB  .Value = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    STARTUP = new Crestron.Logos.SplusObjects.DigitalInput( STARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( STARTUP__DigitalInput__, STARTUP );
    
    SHUTDOWNSUBPAGE = new Crestron.Logos.SplusObjects.DigitalInput( SHUTDOWNSUBPAGE__DigitalInput__, this );
    m_DigitalInputList.Add( SHUTDOWNSUBPAGE__DigitalInput__, SHUTDOWNSUBPAGE );
    
    SHUTDOWNCONFIRM = new Crestron.Logos.SplusObjects.DigitalInput( SHUTDOWNCONFIRM__DigitalInput__, this );
    m_DigitalInputList.Add( SHUTDOWNCONFIRM__DigitalInput__, SHUTDOWNCONFIRM );
    
    SHUTDOWNCANCEL = new Crestron.Logos.SplusObjects.DigitalInput( SHUTDOWNCANCEL__DigitalInput__, this );
    m_DigitalInputList.Add( SHUTDOWNCANCEL__DigitalInput__, SHUTDOWNCANCEL );
    
    STARTPAGETRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( STARTPAGETRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( STARTPAGETRIGGER__DigitalInput__, STARTPAGETRIGGER );
    
    INDEXPAGETRIGGER = new Crestron.Logos.SplusObjects.DigitalInput( INDEXPAGETRIGGER__DigitalInput__, this );
    m_DigitalInputList.Add( INDEXPAGETRIGGER__DigitalInput__, INDEXPAGETRIGGER );
    
    CLOSEALLPAGES = new Crestron.Logos.SplusObjects.DigitalInput( CLOSEALLPAGES__DigitalInput__, this );
    m_DigitalInputList.Add( CLOSEALLPAGES__DigitalInput__, CLOSEALLPAGES );
    
    FOOTERCLOSE = new Crestron.Logos.SplusObjects.DigitalInput( FOOTERCLOSE__DigitalInput__, this );
    m_DigitalInputList.Add( FOOTERCLOSE__DigitalInput__, FOOTERCLOSE );
    
    FOOTER = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        FOOTER[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( FOOTER__DigitalInput__ + i, FOOTER__DigitalInput__, this );
        m_DigitalInputList.Add( FOOTER__DigitalInput__ + i, FOOTER[i+1] );
    }
    
    MENU = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU__DigitalInput__ + i, MENU__DigitalInput__, this );
        m_DigitalInputList.Add( MENU__DigitalInput__ + i, MENU[i+1] );
    }
    
    MENU1SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU1SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU1SUB__DigitalInput__ + i, MENU1SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU1SUB__DigitalInput__ + i, MENU1SUB[i+1] );
    }
    
    MENU2SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU2SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU2SUB__DigitalInput__ + i, MENU2SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU2SUB__DigitalInput__ + i, MENU2SUB[i+1] );
    }
    
    MENU3SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU3SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU3SUB__DigitalInput__ + i, MENU3SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU3SUB__DigitalInput__ + i, MENU3SUB[i+1] );
    }
    
    MENU4SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU4SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU4SUB__DigitalInput__ + i, MENU4SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU4SUB__DigitalInput__ + i, MENU4SUB[i+1] );
    }
    
    MENU5SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU5SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU5SUB__DigitalInput__ + i, MENU5SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU5SUB__DigitalInput__ + i, MENU5SUB[i+1] );
    }
    
    MENU6SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU6SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU6SUB__DigitalInput__ + i, MENU6SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU6SUB__DigitalInput__ + i, MENU6SUB[i+1] );
    }
    
    MENU7SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU7SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU7SUB__DigitalInput__ + i, MENU7SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU7SUB__DigitalInput__ + i, MENU7SUB[i+1] );
    }
    
    MENU8SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU8SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU8SUB__DigitalInput__ + i, MENU8SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU8SUB__DigitalInput__ + i, MENU8SUB[i+1] );
    }
    
    MENU9SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU9SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU9SUB__DigitalInput__ + i, MENU9SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU9SUB__DigitalInput__ + i, MENU9SUB[i+1] );
    }
    
    MENU10SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU10SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU10SUB__DigitalInput__ + i, MENU10SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU10SUB__DigitalInput__ + i, MENU10SUB[i+1] );
    }
    
    MENU11SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU11SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU11SUB__DigitalInput__ + i, MENU11SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU11SUB__DigitalInput__ + i, MENU11SUB[i+1] );
    }
    
    MENU12SUB = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU12SUB[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MENU12SUB__DigitalInput__ + i, MENU12SUB__DigitalInput__, this );
        m_DigitalInputList.Add( MENU12SUB__DigitalInput__ + i, MENU12SUB[i+1] );
    }
    
    SYSTEMON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SYSTEMON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SYSTEMON_FB__DigitalOutput__, SYSTEMON_FB );
    
    SYSTEMOFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SYSTEMOFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SYSTEMOFF_FB__DigitalOutput__, SYSTEMOFF_FB );
    
    SHUTDOWNPAGE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( SHUTDOWNPAGE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( SHUTDOWNPAGE_FB__DigitalOutput__, SHUTDOWNPAGE_FB );
    
    STARTPAGE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( STARTPAGE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( STARTPAGE_FB__DigitalOutput__, STARTPAGE_FB );
    
    INDEXPAGE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( INDEXPAGE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( INDEXPAGE_FB__DigitalOutput__, INDEXPAGE_FB );
    
    FOOTER_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        FOOTER_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( FOOTER_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( FOOTER_FB__DigitalOutput__ + i, FOOTER_FB[i+1] );
    }
    
    MENU_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU_FB__DigitalOutput__ + i, MENU_FB[i+1] );
    }
    
    MENU1SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU1SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU1SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU1SUB_FB__DigitalOutput__ + i, MENU1SUB_FB[i+1] );
    }
    
    MENU2SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU2SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU2SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU2SUB_FB__DigitalOutput__ + i, MENU2SUB_FB[i+1] );
    }
    
    MENU3SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU3SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU3SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU3SUB_FB__DigitalOutput__ + i, MENU3SUB_FB[i+1] );
    }
    
    MENU4SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU4SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU4SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU4SUB_FB__DigitalOutput__ + i, MENU4SUB_FB[i+1] );
    }
    
    MENU5SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU5SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU5SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU5SUB_FB__DigitalOutput__ + i, MENU5SUB_FB[i+1] );
    }
    
    MENU6SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU6SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU6SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU6SUB_FB__DigitalOutput__ + i, MENU6SUB_FB[i+1] );
    }
    
    MENU7SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU7SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU7SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU7SUB_FB__DigitalOutput__ + i, MENU7SUB_FB[i+1] );
    }
    
    MENU8SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU8SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU8SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU8SUB_FB__DigitalOutput__ + i, MENU8SUB_FB[i+1] );
    }
    
    MENU9SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU9SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU9SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU9SUB_FB__DigitalOutput__ + i, MENU9SUB_FB[i+1] );
    }
    
    MENU10SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU10SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU10SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU10SUB_FB__DigitalOutput__ + i, MENU10SUB_FB[i+1] );
    }
    
    MENU11SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU11SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU11SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU11SUB_FB__DigitalOutput__ + i, MENU11SUB_FB[i+1] );
    }
    
    MENU12SUB_FB = new InOutArray<DigitalOutput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        MENU12SUB_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MENU12SUB_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MENU12SUB_FB__DigitalOutput__ + i, MENU12SUB_FB[i+1] );
    }
    
    
    STARTPAGETRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( STARTPAGETRIGGER_OnPush_0, false ) );
    INDEXPAGETRIGGER.OnDigitalPush.Add( new InputChangeHandlerWrapper( INDEXPAGETRIGGER_OnPush_1, false ) );
    STARTUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( STARTUP_OnPush_2, false ) );
    SHUTDOWNCONFIRM.OnDigitalPush.Add( new InputChangeHandlerWrapper( SHUTDOWNCONFIRM_OnPush_3, false ) );
    SHUTDOWNSUBPAGE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SHUTDOWNSUBPAGE_OnPush_4, false ) );
    SHUTDOWNCANCEL.OnDigitalPush.Add( new InputChangeHandlerWrapper( SHUTDOWNCANCEL_OnPush_5, false ) );
    CLOSEALLPAGES.OnDigitalPush.Add( new InputChangeHandlerWrapper( CLOSEALLPAGES_OnPush_6, false ) );
    for( uint i = 0; i < 12; i++ )
        MENU[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU_OnPush_7, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU1SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU1SUB_OnPush_8, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU2SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU2SUB_OnPush_9, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU3SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU3SUB_OnPush_10, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU4SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU4SUB_OnPush_11, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU5SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU5SUB_OnPush_12, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU6SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU6SUB_OnPush_13, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU7SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU7SUB_OnPush_14, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU8SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU8SUB_OnPush_15, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU9SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU9SUB_OnPush_16, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU10SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU10SUB_OnPush_17, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU11SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU11SUB_OnPush_18, false ) );
        
    for( uint i = 0; i < 12; i++ )
        MENU12SUB[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MENU12SUB_OnPush_19, false ) );
        
    for( uint i = 0; i < 7; i++ )
        FOOTER[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( FOOTER_OnPush_20, false ) );
        
    FOOTERCLOSE.OnDigitalPush.Add( new InputChangeHandlerWrapper( FOOTERCLOSE_OnPush_21, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_TPDRIVER ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint STARTUP__DigitalInput__ = 0;
const uint SHUTDOWNSUBPAGE__DigitalInput__ = 1;
const uint SHUTDOWNCONFIRM__DigitalInput__ = 2;
const uint SHUTDOWNCANCEL__DigitalInput__ = 3;
const uint STARTPAGETRIGGER__DigitalInput__ = 4;
const uint INDEXPAGETRIGGER__DigitalInput__ = 5;
const uint CLOSEALLPAGES__DigitalInput__ = 6;
const uint FOOTERCLOSE__DigitalInput__ = 7;
const uint FOOTER__DigitalInput__ = 8;
const uint MENU__DigitalInput__ = 15;
const uint MENU1SUB__DigitalInput__ = 27;
const uint MENU2SUB__DigitalInput__ = 39;
const uint MENU3SUB__DigitalInput__ = 51;
const uint MENU4SUB__DigitalInput__ = 63;
const uint MENU5SUB__DigitalInput__ = 75;
const uint MENU6SUB__DigitalInput__ = 87;
const uint MENU7SUB__DigitalInput__ = 99;
const uint MENU8SUB__DigitalInput__ = 111;
const uint MENU9SUB__DigitalInput__ = 123;
const uint MENU10SUB__DigitalInput__ = 135;
const uint MENU11SUB__DigitalInput__ = 147;
const uint MENU12SUB__DigitalInput__ = 159;
const uint SYSTEMON_FB__DigitalOutput__ = 0;
const uint SYSTEMOFF_FB__DigitalOutput__ = 1;
const uint SHUTDOWNPAGE_FB__DigitalOutput__ = 2;
const uint STARTPAGE_FB__DigitalOutput__ = 3;
const uint INDEXPAGE_FB__DigitalOutput__ = 4;
const uint FOOTER_FB__DigitalOutput__ = 5;
const uint MENU_FB__DigitalOutput__ = 12;
const uint MENU1SUB_FB__DigitalOutput__ = 24;
const uint MENU2SUB_FB__DigitalOutput__ = 36;
const uint MENU3SUB_FB__DigitalOutput__ = 48;
const uint MENU4SUB_FB__DigitalOutput__ = 60;
const uint MENU5SUB_FB__DigitalOutput__ = 72;
const uint MENU6SUB_FB__DigitalOutput__ = 84;
const uint MENU7SUB_FB__DigitalOutput__ = 96;
const uint MENU8SUB_FB__DigitalOutput__ = 108;
const uint MENU9SUB_FB__DigitalOutput__ = 120;
const uint MENU10SUB_FB__DigitalOutput__ = 132;
const uint MENU11SUB_FB__DigitalOutput__ = 144;
const uint MENU12SUB_FB__DigitalOutput__ = 156;

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
