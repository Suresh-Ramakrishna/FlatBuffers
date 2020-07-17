using Google.FlatBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBuffers
{
    class Helper
    {

        public static Offset<ScalarType> BuildScalarType(FlatBufferBuilder fbb)
        {
            ScalarType.StartScalarType(fbb);
            ScalarType.AddByteType(fbb, 1);
            ScalarType.AddUbyteType(fbb, 2);
            ScalarType.AddBoolType(fbb, true);
            ScalarType.AddShortType(fbb, 3);
            ScalarType.AddUshortType(fbb, 4);
            ScalarType.AddInttype(fbb, 5);
            ScalarType.AddUintType(fbb, 6);
            ScalarType.AddFloatType(fbb, 7.05f);
            ScalarType.AddLongType(fbb, 8);
            ScalarType.AddUlongType(fbb, 9);
            ScalarType.AddDoubleType(fbb, 10.125);
            ScalarType.AddDoubleType(fbb, 11.05); //Note: AddDoubleType is invoked twice, DoubleType field will be set to value passed by last invocation.
            return ScalarType.EndScalarType(fbb);
        }
        public static Offset<ComplexType> BuildComplexType(FlatBufferBuilder fbb)
        {
            StringOffset stringOffset = fbb.CreateString("Some random string");

            ComplexType.StartIntVectorTypeVector(fbb, 5);
            var intVectorOffset = BuildVector(fbb);

            ComplexType.StartComplexType(fbb);
            ComplexType.AddStringType(fbb, stringOffset);
            ComplexType.AddIntVectorType(fbb, intVectorOffset);
            ComplexType.AddEnumType(fbb, Color.Green);
            ComplexType.AddStructType(fbb, Axis.CreateAxis(fbb, 1.1f, 2.1f, 3.1f));
            return ComplexType.EndComplexType(fbb);
        }
        public static VectorOffset BuildVector(FlatBufferBuilder fbb, bool isByte = false)
        {
            for (int i = 4; i >= 0; i--) //Note 1st item should be added in last index.
            {
                if(isByte)
                    fbb.AddByte((byte)i);
                else
                    fbb.AddInt(i);
            }
            return fbb.EndVector();
        }

        public static Offset<Monster> BuildMonster(FlatBufferBuilder fbb)
        {
            var sword = Weapon.CreateWeapon(fbb, fbb.CreateString("Sword"), 3);
            var axe = Weapon.CreateWeapon(fbb, fbb.CreateString("Axe"), 5);

            Monster.StartInventoryVector(fbb, 5);
            var inventoryOffset = BuildVector(fbb, true); ;

            var weapons = new Offset<Weapon>[2] { sword, axe };
            var weaponsOffset = Monster.CreateWeaponsVector(fbb, weapons);

            Monster.StartPathVector(fbb, 2); //Vector of structs
            Vec3.CreateVec3(fbb, 1.0f, 2.0f, 3.0f);
            Vec3.CreateVec3(fbb, 4.0f, 5.0f, 6.0f);
            var path = fbb.EndVector();

            var nameOffset = fbb.CreateString("Orc");
            Monster.StartMonster(fbb);
            Monster.AddPos(fbb, Vec3.CreateVec3(fbb, 1.0f, 2.0f, 3.0f));
            Monster.AddHp(fbb, 300);
            Monster.AddName(fbb, nameOffset);
            Monster.AddInventory(fbb, inventoryOffset);
            Monster.AddColor(fbb, Color.Red);
            Monster.AddWeapons(fbb, weaponsOffset);
            Monster.AddEquippedType(fbb, Equipment.Weapon); //Type of union stored
            Monster.AddEquipped(fbb, axe.Value); // Value of union
            Monster.AddPath(fbb, path);
            return Monster.EndMonster(fbb);
        }
    }
}
