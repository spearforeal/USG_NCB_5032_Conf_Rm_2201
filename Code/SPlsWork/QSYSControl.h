namespace QSYSControlV4_2;
        // class declarations
         class QSYSNamedControl;
         class Events;
         class QSYSCoreEvent;
         class QSYSStatusEvent;
         class QSYSNamedControlEvent;
         class QSYSNamedComponent;
         class JSON;
         class ResultGetStatus;
         class ParamsGetStatusResult;
         class ParamsGetStatus;
         class JSONResult;
         class JSONResultList;
         class JSONListChoicesFormatted;
         class JSONBoolResult;
         class JSONPollGroupResponse;
         class JSONPollGroupResponseParams;
         class JSONErrorResponse;
         class JSONErrorArgs;
         class CreateDestroyChangeGroup;
         class ParamsCreateDestroyChangeGroup;
         class JSONAddRemoveNamedControls;
         class JSONParamsAddRemoveNamedControls;
         class JSONAutoPoll;
         class JSONAutoPollParams;
         class JSONLogin;
         class ParamsJSONLogin;
         class SetNamedControl;
         class ParamsSetNamedControl;
         class SetComponentControl;
         class ParamsSetComponentControl;
         class ControlsSetComponentControl;
         class SetNamedControlString;
         class ParamsSetNamedControlString;
         class JSONSnapShot;
         class JSONSnapShotParams;
         class JSONNoOp;
         class HTMLFormat;
         class QSYSCore;
         class QSYSNamedControlChangeArgs;
         class QSYSCoreChangeArgs;
         class QSYSStatusChangeArgs;
         class QSYSMain;
     class QSYSNamedControl 
    {
        // class delegates
        delegate FUNCTION ListItemSelected ( SIMPLSHARPSTRING SelectedItem );
        delegate FUNCTION ListItemCount ( INTEGER ItemCount );

        // class events
        EventHandler OnNamedControlEvent ( QSYSNamedControl sender, QSYSNamedControlChangeArgs e );

        // class functions
        FUNCTION AddNamedControl ( STRING Name , INTEGER _ID );
        FUNCTION AddListNamedControl ( STRING Name , INTEGER _ID , SIGNED_LONG_INTEGER Size );
        FUNCTION TriggerBtnDown ();
        FUNCTION TriggerBtn ();
        FUNCTION TriggerBtnUp ();
        FUNCTION ListItemSelect ( SIGNED_LONG_INTEGER item );
        FUNCTION SnapShotSave ( INTEGER bank );
        FUNCTION SnapShotLoad ( INTEGER bank );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        STRING NamedControl[];
        INTEGER ID;
        QSYSNamedControlEvent myNamedControlEvent;
        INTEGER Poll;
        SIGNED_INTEGER RampTime;
        SIGNED_INTEGER dbValue;
        INTEGER RelValue;
        STRING StringValue[];
        SIGNED_INTEGER DirValue;

        // class properties
        DelegateProperty ListItemSelected delItemSelected;
        DelegateProperty ListItemCount delItemCount;
        INTEGER _Poll;
        SIGNED_INTEGER _dbValue;
        SIGNED_INTEGER _dbValueRamp;
        INTEGER _RelValue;
        INTEGER _RelValueRamp;
        STRING _StringValue[];
        SIGNED_INTEGER _dirValue;
    };

     class Events 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QSYSCoreEvent 
    {
        // class delegates

        // class events
        EventHandler OnCoreEvent ( QSYSCoreEvent sender, QSYSCoreChangeArgs e );

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QSYSStatusEvent 
    {
        // class delegates

        // class events
        EventHandler OnCoreStatusEvent ( QSYSStatusEvent sender, QSYSStatusChangeArgs e );

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QSYSNamedControlEvent 
    {
        // class delegates

        // class events
        EventHandler OnNamedControlEvent ( QSYSNamedControlEvent sender, QSYSNamedControlChangeArgs e );

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class QSYSNamedComponent 
    {
        // class delegates

        // class events
        EventHandler OnComponentControlEvent ( QSYSNamedComponent sender, QSYSNamedControlChangeArgs e );

        // class functions
        FUNCTION AddControl ( STRING Name , INTEGER _ID );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        STRING Component[];
        INTEGER ID;
        QSYSNamedControlEvent myComponentControlEvent;

        // class properties
    };

     class JSON 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class ResultGetStatus 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        STRING method[];
        ParamsGetStatusResult Params;
    };

     class ParamsGetStatusResult 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Platform[];
        STRING State[];
        STRING DesignName[];
        STRING DesignCode[];
        ParamsGetStatus Status;
    };

     class ParamsGetStatus 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER Code;
        STRING String[];
    };

     class JSONResult 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        JSONResultList result;
    };

     class JSONResultList 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING sValue[];
    };

     class JSONListChoicesFormatted 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Text[];
        STRING TextColor[];
        STRING Icon[];
    };

     class JSONBoolResult 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
    };

     class JSONPollGroupResponse 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        STRING method[];
        JSONPollGroupResponseParams params;
    };

     class JSONPollGroupResponseParams 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Id[];
    };

     class JSONErrorResponse 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        JSONErrorArgs error;
    };

     class JSONErrorArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER code;
        STRING message[];
    };

     class CreateDestroyChangeGroup 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        ParamsCreateDestroyChangeGroup params;
    };

     class ParamsCreateDestroyChangeGroup 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Id[];
    };

     class JSONAddRemoveNamedControls 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        JSONParamsAddRemoveNamedControls params;
    };

     class JSONParamsAddRemoveNamedControls 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Id[];
    };

     class JSONAutoPoll 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        JSONAutoPollParams params;
    };

     class JSONAutoPollParams 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Id[];
    };

     class JSONLogin 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        STRING method[];
        SIGNED_LONG_INTEGER id;
        ParamsJSONLogin params;
    };

     class ParamsJSONLogin 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING User[];
        STRING Password[];
    };

     class SetNamedControl 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        ParamsSetNamedControl params;
    };

     class ParamsSetNamedControl 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
    };

     class SetComponentControl 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        ParamsSetComponentControl params;
    };

     class ParamsSetComponentControl 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        ControlsSetComponentControl controls;
    };

     class ControlsSetComponentControl 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class SetNamedControlString 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        ParamsSetNamedControlString params;
    };

     class ParamsSetNamedControlString 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Value[];
    };

     class JSONSnapShot 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        JSONSnapShotParams params;
    };

     class JSONSnapShotParams 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        SIGNED_LONG_INTEGER Bank;
    };

     class JSONNoOp 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING jsonrpc[];
        SIGNED_LONG_INTEGER id;
        STRING method[];
        ParamsJSONLogin params;
    };

     class QSYSCore 
    {
        // class delegates
        delegate FUNCTION CoreIntializeStatus ( INTEGER CoreInitValue );
        delegate FUNCTION CoreErrorsLogged ( INTEGER ErrorCount );

        // class events
        EventHandler onCoreChangeEvent ( QSYSCore sender, QSYSCoreChangeArgs e );
        EventHandler onCoreStatusChangeEvent ( QSYSCore sender, QSYSStatusChangeArgs e );

        // class functions
        FUNCTION QSYSSendData ( STRING data );
        FUNCTION Reconnect ();
        FUNCTION QSYSCustomString ( STRING sData );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER CoreID;
        STRING User[];
        STRING Pin[];
        INTEGER CoreDebug;
        QSYSCoreEvent CoreEvent;
        QSYSStatusEvent StatusEvent;

        // class properties
        DelegateProperty CoreIntializeStatus delInitialized;
        DelegateProperty CoreErrorsLogged delCoreErrors;
        SIGNED_LONG_INTEGER _pollRate;
        STRING _CoreIPAddress[];
    };

     class QSYSNamedControlChangeArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER relValue;
        SIGNED_INTEGER dBValue;
        STRING sValue[];
        SIGNED_INTEGER dirValue;
        INTEGER lIndex;
        STRING lsValue[];
        STRING lfsValue[];
    };

     class QSYSCoreChangeArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_INTEGER Status;
    };

     class QSYSStatusChangeArgs 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Platform[];
        STRING State[];
        STRING DesignName[];
        STRING DesignCode[];
        INTEGER IsRedundant;
        INTEGER IsEmulator;
    };

    static class QSYSMain 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        static STRING progslot[];

        // class properties
    };

