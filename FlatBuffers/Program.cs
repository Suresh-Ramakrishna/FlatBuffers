using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.FlatBuffers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlatBuffers
{
    class Program
    {
        static void Main(string[] args)
        {
            AssertScalarType();
            AssertComplexType();
            AssertMonsterType();
            AssertObject();
        }
        static void AssertScalarType()
        {
            //initial buffer size
            FlatBufferBuilder fbb = new FlatBufferBuilder(1024);
            var scalarTypeOffset = Helper.BuildScalarType(fbb);
            fbb.Finish(scalarTypeOffset.Value);

            byte[] serializedData = fbb.SizedByteArray();
            var buffer = new ByteBuffer(serializedData);
            var dScalarType = ScalarType.GetRootAsScalarType(buffer);
            Assert.IsTrue(dScalarType.BoolType);
        }
        static void AssertComplexType()
        {
            //initial buffer size
            FlatBufferBuilder fbb = new FlatBufferBuilder(1024);
            var complexTypeOffset = Helper.BuildComplexType(fbb);
            fbb.Finish(complexTypeOffset.Value);

            byte[] serializedBuffer = fbb.SizedByteArray();
            var buffer = new ByteBuffer(serializedBuffer);
            var dComplexType = ComplexType.GetRootAsComplexType(buffer);

            var intVector = dComplexType.GetIntVectorTypeArray(); // To get array
            Assert.AreEqual(intVector.Length, 5);
        }
        static void AssertMonsterType()
        {
            FlatBufferBuilder fbb = new FlatBufferBuilder(1024);
            var monsterTypeOffset = Helper.BuildMonster(fbb);
            fbb.Finish(monsterTypeOffset.Value);
            byte[] serializedBuffer = fbb.SizedByteArray(); //Gets serialized instance as byte array

            var buffer = new ByteBuffer(serializedBuffer);
            var dMonster = Monster.GetRootAsMonster(buffer); // Gets deserialized object

            Assert.AreEqual(Color.Red, dMonster.Color);
        }
        static void AssertObject()
        {
            var fbuilder = new FlatBufferBuilder(50);
            fbuilder.StartTable(2); //Creates a table with 2 fields. These fields only has index and no Name
            fbuilder.AddInt(0, 10, int.MinValue);
            fbuilder.AddLong(1, 20, long.MinValue);
            var offset = fbuilder.EndTable();
            fbuilder.Finish(offset);
            var keyBytes = fbuilder.SizedByteArray();

            var byteBuffer = new ByteBuffer(keyBytes);
            var bb_pos = byteBuffer.GetInt(byteBuffer.Position) + byteBuffer.Position; //+ byteBuffer.Position is needed when a file has multiple objects to read
            var table = new Table(bb_pos, byteBuffer);
            var offs = 4;
            var t0 = table.bb.GetInt(table.__offset(offs) + table.bb_pos);
            offs += 2;
            var t1 = table.bb.GetLong(table.__offset(offs) + table.bb_pos);
        }
    }
}
