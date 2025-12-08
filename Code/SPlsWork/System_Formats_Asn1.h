namespace System.Formats.Asn1;
        // class declarations
         class Asn1Tag;
         class AsnContentException;
         class AsnEncodingRules;
         class AsnDecoder;
         class AsnReader;
         class AsnReaderOptions;
         class AsnWriter;
         class TagClass;
         class UniversalTagNumber;
     class AsnContentException 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Message[];
        STRING StackTrace[];
        STRING HelpLink[];
        STRING Source[];
        SIGNED_LONG_INTEGER HResult;
    };

    static class AsnEncodingRules // enum
    {
        static SIGNED_LONG_INTEGER BER;
        static SIGNED_LONG_INTEGER CER;
        static SIGNED_LONG_INTEGER DER;
    };

    static class AsnDecoder 
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

     class AsnReaderOptions 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER UtcTimeTwoDigitYearMax;
    };

    static class TagClass // enum
    {
        static SIGNED_LONG_INTEGER Universal;
        static SIGNED_LONG_INTEGER Application;
        static SIGNED_LONG_INTEGER ContextSpecific;
        static SIGNED_LONG_INTEGER Private;
    };

    static class UniversalTagNumber // enum
    {
        static SIGNED_LONG_INTEGER EndOfContents;
        static SIGNED_LONG_INTEGER Boolean;
        static SIGNED_LONG_INTEGER Integer;
        static SIGNED_LONG_INTEGER BitString;
        static SIGNED_LONG_INTEGER OctetString;
        static SIGNED_LONG_INTEGER Null;
        static SIGNED_LONG_INTEGER ObjectIdentifier;
        static SIGNED_LONG_INTEGER ObjectDescriptor;
        static SIGNED_LONG_INTEGER InstanceOf;
        static SIGNED_LONG_INTEGER Real;
        static SIGNED_LONG_INTEGER Enumerated;
        static SIGNED_LONG_INTEGER Embedded;
        static SIGNED_LONG_INTEGER UTF8String;
        static SIGNED_LONG_INTEGER RelativeObjectIdentifier;
        static SIGNED_LONG_INTEGER Time;
        static SIGNED_LONG_INTEGER SequenceOf;
        static SIGNED_LONG_INTEGER Set;
        static SIGNED_LONG_INTEGER NumericString;
        static SIGNED_LONG_INTEGER PrintableString;
        static SIGNED_LONG_INTEGER TeletexString;
        static SIGNED_LONG_INTEGER VideotexString;
        static SIGNED_LONG_INTEGER IA5String;
        static SIGNED_LONG_INTEGER UtcTime;
        static SIGNED_LONG_INTEGER GeneralizedTime;
        static SIGNED_LONG_INTEGER GraphicString;
        static SIGNED_LONG_INTEGER ISO646String;
        static SIGNED_LONG_INTEGER GeneralString;
        static SIGNED_LONG_INTEGER UniversalString;
        static SIGNED_LONG_INTEGER UnrestrictedCharacterString;
        static SIGNED_LONG_INTEGER BMPString;
        static SIGNED_LONG_INTEGER Date;
        static SIGNED_LONG_INTEGER TimeOfDay;
        static SIGNED_LONG_INTEGER DateTime;
        static SIGNED_LONG_INTEGER Duration;
        static SIGNED_LONG_INTEGER ObjectIdentifierIRI;
        static SIGNED_LONG_INTEGER RelativeObjectIdentifierIRI;
    };

