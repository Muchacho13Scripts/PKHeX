﻿using System;
using System.ComponentModel;

namespace PKHeX.Core;

/// <summary>
/// Stores the position of the player.
/// </summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class Coordinates8a : SaveBlock
{
    public Coordinates8a(SaveFile sav, SCBlock block) : base(sav, block.Data) { }
    public float X { get => ReadSingleLittleEndian(Data.AsSpan(Offset + 0x50)); set => WriteSingleLittleEndian(Data.AsSpan(Offset + 0x50), value); }
    public float Z { get => ReadSingleLittleEndian(Data.AsSpan(Offset + 0x54)); set => WriteSingleLittleEndian(Data.AsSpan(Offset + 0x54), value); }
    public float Y { get => ReadSingleLittleEndian(Data.AsSpan(Offset + 0x58)); set => WriteSingleLittleEndian(Data.AsSpan(Offset + 0x58), value); }
}
