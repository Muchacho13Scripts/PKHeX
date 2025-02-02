﻿using System;
using System.Buffers.Binary;
using System.ComponentModel;

namespace PKHeX.Core;

/// <summary>
/// Stores the <see cref="Timestamp"/> when the player created their save data.
/// </summary>
[TypeConverter(typeof(ExpandableObjectConverter))]
public sealed class AdventureStart8a : SaveBlock
{
    public AdventureStart8a(SaveFile sav, SCBlock block) : base(sav, block.Data) { }

    /// <summary>
    /// time_t (seconds since 1970 Epoch)
    /// </summary>
    public ulong Seconds
    {
        get => BinaryPrimitives.ReadUInt64LittleEndian(Data.AsSpan(Offset));
        set => BinaryPrimitives.WriteUInt64LittleEndian(Data.AsSpan(Offset), value);
    }

    private static DateTime Epoch => new(1970, 1, 1);

    public string AdventureStartTime => $"{Timestamp.Year:0000}-{Timestamp.Month:00}-{Timestamp.Day:00} {Timestamp.Hour:00}ː{Timestamp.Minute:00}ː{Timestamp.Second:00}"; // not :

    public DateTime Timestamp
    {
        get => Epoch.AddSeconds(Seconds);
        set => Seconds = (ulong)value.Subtract(Epoch).TotalSeconds;
    }
}
