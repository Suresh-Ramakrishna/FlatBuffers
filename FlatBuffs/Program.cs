using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatBuffers;

namespace FlatBuffs
{
    class Program
    {
        static void Main(string[] args)
        {
            ScalarTypesBuilder();
            ComplexTypesBuilder();
            MonstaerTypesBuilder();
        }
        static void ScalarTypesBuilder()
        {
            FlatBufferBuilder builder = new FlatBufferBuilder(1024); //initial buffer size
            ScalarTypes.StartScalarTypes(builder);
            ScalarTypes.AddByteType(builder, 1);
            ScalarTypes.AddUbyteType(builder, 2);
            ScalarTypes.AddBoolType(builder, true);
            ScalarTypes.AddShortType(builder, 3);
            ScalarTypes.AddUshortType(builder, 4);
            ScalarTypes.AddInttype(builder, 5);
            ScalarTypes.AddUintType(builder, 6);
            ScalarTypes.AddFloatType(builder, 7.05f);
            ScalarTypes.AddLongType(builder, 8);
            ScalarTypes.AddUlongType(builder, 9);
            ScalarTypes.AddDoubleType(builder, 10.125);
            ScalarTypes.AddDoubleType(builder, 11.05); //Note: AddDoubleType is invoked twice, DoubleType field will be set to value passed by last invocation.

            var scalarType = ScalarTypes.EndScalarTypes(builder);
            builder.Finish(scalarType.Value);
            byte[] serializedBuffer = builder.SizedByteArray();

            var buffer = new ByteBuffer(serializedBuffer);
            var deserializedScalarType = ScalarTypes.GetRootAsScalarTypes(buffer);
        }
        static void ComplexTypesBuilder()
        {
            FlatBufferBuilder builder = new FlatBufferBuilder(1024); //initial buffer size
            StringOffset stringOffset = builder.CreateString("Some random string");

            ComplexTypes.StartIntVectorTypeVector(builder, 5);
            for (int i = 4; i >= 0; i--) //Note 1st item should be added in last index.
            {
                builder.AddInt(i);
            }
            var intVectorOffset = builder.EndVector();
            ComplexTypes.StartComplexTypes(builder);
            ComplexTypes.AddStringType(builder, stringOffset);
            ComplexTypes.AddIntVectorType(builder, intVectorOffset);
            ComplexTypes.AddEnumType(builder, Color.Green);
            ComplexTypes.AddStructType(builder, Axis.CreateAxis(builder, 1.1f, 2.1f, 3.1f));
            var complexrType = ComplexTypes.EndComplexTypes(builder);
            
            builder.Finish(complexrType.Value);
            byte[] serializedBuffer = builder.SizedByteArray();

            var buffer = new ByteBuffer(serializedBuffer);
            var deserializedScalarType = ComplexTypes.GetRootAsComplexTypes(buffer);

            deserializedScalarType.GetIntVectorTypeArray(); // To get array
        }
        static void MonstaerTypesBuilder()
        {
            var builder = new FlatBufferBuilder(1024);

            var sword = Weapon.CreateWeapon(builder, builder.CreateString("Sword"), 3);
            var axe = Weapon.CreateWeapon(builder, builder.CreateString("Axe"), 5);

            Monster.StartInventoryVector(builder, 10);
            for (int i = 9; i >= 0; i--)
                builder.AddByte((byte)i);
            var inventoryOffset = builder.EndVector();

            var weapons = new Offset<Weapon>[2] { sword, axe };
            var weaponsOffset = Monster.CreateWeaponsVector(builder, weapons);

            Monster.StartPathVector(builder, 2); //Vector of structs
            Vec3.CreateVec3(builder, 1.0f, 2.0f, 3.0f);
            Vec3.CreateVec3(builder, 4.0f, 5.0f, 6.0f);
            var path = builder.EndVector();

            var nameOffset = builder.CreateString("Orc");
            Monster.StartMonster(builder);
            Monster.AddPos(builder, Vec3.CreateVec3(builder, 1.0f, 2.0f, 3.0f));
            Monster.AddHp(builder, 300);
            Monster.AddName(builder, nameOffset);
            Monster.AddInventory(builder, inventoryOffset);
            Monster.AddColor(builder, Color.Red);
            Monster.AddWeapons(builder, weaponsOffset);
            Monster.AddEquippedType(builder, Equipment.Weapon); //Type of union stored
            Monster.AddEquipped(builder, axe.Value); // Value of union
            Monster.AddPath(builder, path);
            var orc = Monster.EndMonster(builder);

            builder.Finish(orc.Value); 
            byte[] serializedBuffer = builder.SizedByteArray(); //Gets serialized instance as byte array

            var buffer = new ByteBuffer(serializedBuffer);
            var monster = Monster.GetRootAsMonster(buffer); // Gets deserialized object

        }
    }
}
