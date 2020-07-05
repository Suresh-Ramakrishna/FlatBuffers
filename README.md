## FlatBuffers
In order to use Flat buffers, we need to first define a schema in a .fbs file.
Once we have the schema ready, we need to compile the .fbs file using a **flatc** compiler to generate a code based on the language of choice. In our case, it's CSharp.

## Compiler command
flatc generates a .cs file which contains classes that can be used within our program.

>flatc.exe --csharp schema.fbs
#
