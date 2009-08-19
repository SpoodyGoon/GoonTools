; IsGTKSharpInstalled
 ;
 ; Usage:
 ;   Call IsGTKSharpInstalled
 ;   Pop $0
 ;   StrCmp $0 1 found.GTKSharp no.GTKSharp
 ; Contact:
 ;   Questions about this script may sent to the author,
 ;   Clint Herron, at HanClinto at gmail dot com

Function IsGTKSharpInstalled
   Push $0
   Push $1
   Push $2
   Push $3
   Push $4
   Push $5

   ;$0 is the top-level enumeration index we're searching (product)
   ;$1 is the second-level enumeration index we're searching (version)
   ;$2 is the top-level name we're searching (product)
   ;$3 is the second-level name we're searching (version)
   ;$4 is the last-level enumeration index we're searching (individual key)
   ;$5 is the last-level name we're searching (individual key)

   StrCpy $0 0 ; Start at the beginning of the Novell products

   ProductEnumStart:

     EnumRegKey $2 HKEY_LOCAL_MACHINE \
       "Software\Novell" $0

     IntOp $0 $0 + 1 ; Increment our counter

     ; No more products to search, give up!
     StrCmp $2 "" noGTKSharp

     ; Search within the product for version
     StrCpy $1 0
     VersionEnumStart:
       EnumRegKey $3 HKEY_LOCAL_MACHINE \
         "Software\Novell\$2" $1

       IntOp $1 $1 + 1
       StrCmp $3 "" ProductEnumStart

       ; Search within this version for the key we're looking for
       StrCpy $4 0
       KeyEnumStart:
         EnumRegValue $5 HKEY_LOCAL_MACHINE \
           "Software\Novell\$2\$3" $4

         IntOp $4 $4 + 1
         StrCmp $5 "GtkSharpIsInstalled" foundGTKSharp
         StrCmp $5 "" VersionEnumStart
       Goto KeyEnumStart
     Goto VersionEnumStart
   Goto ProductEnumStart

   noGTKSharp:
     StrCpy $0 0
     Goto done

   foundGTKSharp:
;    MessageBox MB_OK|MB_ICONSTOP "GTKSharp was found at $2\$3\$5"
     StrCpy $0 1

   done:
     Pop $5
     Pop $4
     Pop $3
     Pop $2
     Pop $1
     Exch $0
FunctionEnd