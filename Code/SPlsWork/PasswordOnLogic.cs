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

namespace UserModule_PASSWORDONLOGIC
{
    public class UserModuleClass_PASSWORDONLOGIC : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput START;
        Crestron.Logos.SplusObjects.DigitalInput BACK;
        Crestron.Logos.SplusObjects.DigitalInput PASSWORD_CORRECT;
        Crestron.Logos.SplusObjects.DigitalInput ENABLEPASSWORDONSTART;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MODE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> ENABLE_PASSWORD_ON_MODE;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORD_PAGE_START_FB;
        Crestron.Logos.SplusObjects.DigitalOutput PASSWORD_PAGE_FB;
        Crestron.Logos.SplusObjects.DigitalOutput PASS_START;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> PASS_MODE;
        ushort PENDINGTYPE = 0;
        ushort PENDINGINDEX = 0;
        private void SHOWSTARTPAGE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 24;
            PENDINGTYPE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 25;
            PENDINGINDEX = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 26;
            PASSWORD_PAGE_START_FB  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 27;
            PASSWORD_PAGE_FB  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void SHOWMODEPAGE (  SplusExecutionContext __context__, ushort IDX ) 
            { 
            
            __context__.SourceCodeLine = 31;
            PENDINGTYPE = (ushort) ( 2 ) ; 
            __context__.SourceCodeLine = 32;
            PENDINGINDEX = (ushort) ( IDX ) ; 
            __context__.SourceCodeLine = 33;
            PASSWORD_PAGE_START_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 34;
            PASSWORD_PAGE_FB  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void SHOWPASSWORDPAGE (  SplusExecutionContext __context__, ushort TYPE , ushort IDX ) 
            { 
            
            __context__.SourceCodeLine = 39;
            PENDINGTYPE = (ushort) ( TYPE ) ; 
            __context__.SourceCodeLine = 40;
            PENDINGINDEX = (ushort) ( IDX ) ; 
            __context__.SourceCodeLine = 41;
            PASSWORD_PAGE_FB  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void CLEARPAGES (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 45;
            PASSWORD_PAGE_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 46;
            PASSWORD_PAGE_START_FB  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 47;
            PENDINGTYPE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 48;
            PENDINGINDEX = (ushort) ( 0 ) ; 
            
            }
            
        private void ACTIONPRESS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 52;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PENDINGTYPE == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 54;
                Functions.Pulse ( 50, PASS_START ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 56;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (PENDINGTYPE == 2))  ) ) 
                    { 
                    __context__.SourceCodeLine = 58;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( PENDINGINDEX >= 1 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( PENDINGINDEX <= 7 ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 60;
                        Functions.Pulse ( 50, PASS_MODE [ PENDINGINDEX] ) ; 
                        } 
                    
                    } 
                
                }
            
            __context__.SourceCodeLine = 63;
            CLEARPAGES (  __context__  ) ; 
            
            }
            
        object START_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 67;
                if ( Functions.TestForTrue  ( ( ENABLEPASSWORDONSTART  .Value)  ) ) 
                    { 
                    __context__.SourceCodeLine = 69;
                    SHOWSTARTPAGE (  __context__  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 73;
                    Functions.Pulse ( 50, PASS_START ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object MODE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort N = 0;
            
            
            __context__.SourceCodeLine = 81;
            N = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
            __context__.SourceCodeLine = 82;
            if ( Functions.TestForTrue  ( ( ENABLE_PASSWORD_ON_MODE[ N ] .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 84;
                SHOWMODEPAGE (  __context__ , (ushort)( N )) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 88;
                Functions.Pulse ( 50, PASS_MODE [ N] ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object BACK_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 94;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( PASSWORD_PAGE_FB  .Value ) || Functions.TestForTrue ( PASSWORD_PAGE_START_FB  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 96;
            CLEARPAGES (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PASSWORD_CORRECT_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 101;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( PASSWORD_PAGE_FB  .Value ) || Functions.TestForTrue ( PASSWORD_PAGE_START_FB  .Value )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 103;
            ACTIONPRESS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    START = new Crestron.Logos.SplusObjects.DigitalInput( START__DigitalInput__, this );
    m_DigitalInputList.Add( START__DigitalInput__, START );
    
    BACK = new Crestron.Logos.SplusObjects.DigitalInput( BACK__DigitalInput__, this );
    m_DigitalInputList.Add( BACK__DigitalInput__, BACK );
    
    PASSWORD_CORRECT = new Crestron.Logos.SplusObjects.DigitalInput( PASSWORD_CORRECT__DigitalInput__, this );
    m_DigitalInputList.Add( PASSWORD_CORRECT__DigitalInput__, PASSWORD_CORRECT );
    
    ENABLEPASSWORDONSTART = new Crestron.Logos.SplusObjects.DigitalInput( ENABLEPASSWORDONSTART__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLEPASSWORDONSTART__DigitalInput__, ENABLEPASSWORDONSTART );
    
    MODE = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MODE__DigitalInput__ + i, MODE__DigitalInput__, this );
        m_DigitalInputList.Add( MODE__DigitalInput__ + i, MODE[i+1] );
    }
    
    ENABLE_PASSWORD_ON_MODE = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        ENABLE_PASSWORD_ON_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_PASSWORD_ON_MODE__DigitalInput__ + i, ENABLE_PASSWORD_ON_MODE__DigitalInput__, this );
        m_DigitalInputList.Add( ENABLE_PASSWORD_ON_MODE__DigitalInput__ + i, ENABLE_PASSWORD_ON_MODE[i+1] );
    }
    
    PASSWORD_PAGE_START_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORD_PAGE_START_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASSWORD_PAGE_START_FB__DigitalOutput__, PASSWORD_PAGE_START_FB );
    
    PASSWORD_PAGE_FB = new Crestron.Logos.SplusObjects.DigitalOutput( PASSWORD_PAGE_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASSWORD_PAGE_FB__DigitalOutput__, PASSWORD_PAGE_FB );
    
    PASS_START = new Crestron.Logos.SplusObjects.DigitalOutput( PASS_START__DigitalOutput__, this );
    m_DigitalOutputList.Add( PASS_START__DigitalOutput__, PASS_START );
    
    PASS_MODE = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        PASS_MODE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( PASS_MODE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( PASS_MODE__DigitalOutput__ + i, PASS_MODE[i+1] );
    }
    
    
    START.OnDigitalPush.Add( new InputChangeHandlerWrapper( START_OnPush_0, false ) );
    for( uint i = 0; i < 7; i++ )
        MODE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MODE_OnPush_1, false ) );
        
    BACK.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACK_OnPush_2, false ) );
    PASSWORD_CORRECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( PASSWORD_CORRECT_OnPush_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PASSWORDONLOGIC ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint START__DigitalInput__ = 0;
const uint BACK__DigitalInput__ = 1;
const uint PASSWORD_CORRECT__DigitalInput__ = 2;
const uint ENABLEPASSWORDONSTART__DigitalInput__ = 3;
const uint MODE__DigitalInput__ = 4;
const uint ENABLE_PASSWORD_ON_MODE__DigitalInput__ = 11;
const uint PASSWORD_PAGE_START_FB__DigitalOutput__ = 0;
const uint PASSWORD_PAGE_FB__DigitalOutput__ = 1;
const uint PASS_START__DigitalOutput__ = 2;
const uint PASS_MODE__DigitalOutput__ = 3;

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
