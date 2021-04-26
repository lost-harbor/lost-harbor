// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using System;
using System.Collections.Generic;

namespace LogicSeed.LostHarbor.Core.Grid
{
  public struct Hex : IEquatable<Hex>
  {
    public static readonly List<Hex> Directions = new()
    { new(1, 0), new(1, -1), new(0, -1), new(-1, 0), new(-1, 1), new(0, 1) };
    public static readonly List<Hex> Diagonals = new()
    { new(2, -1), new(1, -2), new(-1, -1), new(-2, 1), new(-1, 2), new(1, 1) };

    public readonly int X;
    public readonly int Y;
    public int Z => -X - Y;

    public int Length => (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) / 2;

    public Hex(int x, int y)
    {
      X = x;
      Y = y;

      // Assert valid hex coordinates
      if (X + Y + Z != 0) throw new ArgumentException("Coordinates do not represent a valid hex.");
    }

    public int Distance(Hex other) => (this - other).Length;

    public static Hex Direction(int direction) =>
      0 <= direction && direction < 6
      ? Directions[direction]
      : throw new ArgumentOutOfRangeException(nameof(direction));
    public Hex Neighbor(int direction) => this + Direction(direction);

    public static Hex Diagonal(int direction) =>
      0 <= direction && direction < 6
      ? Diagonals[direction]
      : throw new ArgumentOutOfRangeException(nameof(direction));
    public Hex DiagonalNeighbor(int direction) => this + Diagonal(direction);

    public Hex RotateCCW() => new(-Z, -X);
    public Hex RotateCW() => new(-Y, -Z);

    public List<Hex> Line(Hex other)
    {
      HexF start = this;
      HexF end = other;
      var distance = Distance(other);
      var results = new List<Hex>();
      var step = 1.0 / Math.Max(distance, 1);

      for (int i = 0; i <= distance; i++)
      {
        results.Add(start.Lerp(end, step * i));
      }
      return results;
    }

    // Operator Overloads
    public static bool operator ==(Hex a, Hex b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(Hex a, Hex b) => !(a == b);
    public static bool operator <(Hex a, Hex b) => a.Length < b.Length;
    public static bool operator >(Hex a, Hex b) => a.Length > b.Length;
    public static bool operator <=(Hex a, Hex b) => a == b || a < b;
    public static bool operator >=(Hex a, Hex b) => a == b || a > b;

    public static Hex operator +(Hex a) => a;
    public static Hex operator -(Hex a) => new(-a.X, -a.Y);
    public static Hex operator +(Hex a, Hex b) => new(a.X + b.X, a.Y + b.Y);
    public static Hex operator -(Hex a, Hex b) => a + (-b);
    public static Hex operator *(Hex a, int b) => new(a.X + b, a.Y + b);
    // IEquatable
    public bool Equals(Hex other) => this == other;
    public override bool Equals(object obj) => obj is Hex hex && Equals(hex);
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);
    public override string ToString() => $"{X}, {Y}, {Z}";
  }
}
