// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct ScalarType : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static ScalarType GetRootAsScalarType(ByteBuffer _bb) { return GetRootAsScalarType(_bb, new ScalarType()); }
  public static ScalarType GetRootAsScalarType(ByteBuffer _bb, ScalarType obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public ScalarType __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public sbyte ByteType { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetSbyte(o + __p.bb_pos) : (sbyte)0; } }
  public byte UbyteType { get { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public bool BoolType { get { int o = __p.__offset(8); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public short ShortType { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)0; } }
  public ushort UshortType { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetUshort(o + __p.bb_pos) : (ushort)0; } }
  public int Inttype { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public uint UintType { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public float FloatType { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  public long LongType { get { int o = __p.__offset(20); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  public ulong UlongType { get { int o = __p.__offset(22); return o != 0 ? __p.bb.GetUlong(o + __p.bb_pos) : (ulong)0; } }
  public double DoubleType { get { int o = __p.__offset(24); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }

  public static Offset<ScalarType> CreateScalarType(FlatBufferBuilder builder,
      sbyte byteType = 0,
      byte ubyteType = 0,
      bool boolType = false,
      short shortType = 0,
      ushort ushortType = 0,
      int inttype = 0,
      uint uintType = 0,
      float floatType = 0.0f,
      long longType = 0,
      ulong ulongType = 0,
      double doubleType = 0.0) {
    builder.StartTable(11);
    ScalarType.AddDoubleType(builder, doubleType);
    ScalarType.AddUlongType(builder, ulongType);
    ScalarType.AddLongType(builder, longType);
    ScalarType.AddFloatType(builder, floatType);
    ScalarType.AddUintType(builder, uintType);
    ScalarType.AddInttype(builder, inttype);
    ScalarType.AddUshortType(builder, ushortType);
    ScalarType.AddShortType(builder, shortType);
    ScalarType.AddBoolType(builder, boolType);
    ScalarType.AddUbyteType(builder, ubyteType);
    ScalarType.AddByteType(builder, byteType);
    return ScalarType.EndScalarType(builder);
  }

  public static void StartScalarType(FlatBufferBuilder builder) { builder.StartTable(11); }
  public static void AddByteType(FlatBufferBuilder builder, sbyte byteType) { builder.AddSbyte(0, byteType, 0); }
  public static void AddUbyteType(FlatBufferBuilder builder, byte ubyteType) { builder.AddByte(1, ubyteType, 0); }
  public static void AddBoolType(FlatBufferBuilder builder, bool boolType) { builder.AddBool(2, boolType, false); }
  public static void AddShortType(FlatBufferBuilder builder, short shortType) { builder.AddShort(3, shortType, 0); }
  public static void AddUshortType(FlatBufferBuilder builder, ushort ushortType) { builder.AddUshort(4, ushortType, 0); }
  public static void AddInttype(FlatBufferBuilder builder, int inttype) { builder.AddInt(5, inttype, 0); }
  public static void AddUintType(FlatBufferBuilder builder, uint uintType) { builder.AddUint(6, uintType, 0); }
  public static void AddFloatType(FlatBufferBuilder builder, float floatType) { builder.AddFloat(7, floatType, 0.0f); }
  public static void AddLongType(FlatBufferBuilder builder, long longType) { builder.AddLong(8, longType, 0); }
  public static void AddUlongType(FlatBufferBuilder builder, ulong ulongType) { builder.AddUlong(9, ulongType, 0); }
  public static void AddDoubleType(FlatBufferBuilder builder, double doubleType) { builder.AddDouble(10, doubleType, 0.0); }
  public static Offset<ScalarType> EndScalarType(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<ScalarType>(o);
  }
};
