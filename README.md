## FlatBuffers
In order to use Flat buffers, we need to first define a schema in a .fbs file.
Once we have the schema ready, we need to compile the .fbs file using a **flatc** compiler to generate a code based on the language of choice. In our case, it's CSharp.
> You can download **flatc** release version from here - https://github.com/google/flatbuffers/releases

## Compiler command
flatc generates a .cs file which contains classes that can be used within our program.

>flatc.exe --csharp schema.fbs
#

Unline ProtoBuff, FlatBuffers does not have any nuget package. You need to directly include Google's .NET FlatBuffers project to your solution in order to work with Flat Buffers.

>You can download the project from here - https://github.com/google/flatbuffers/tree/master/net

<b>Note: </b>Google.FlatBuffers project is the source from Google. There is no Nuget package to integrate Google Flatbuffers directly in our project.
