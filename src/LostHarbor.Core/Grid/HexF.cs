// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using System;

namespace LogicSeed.LostHarbor.Core.Grid
{
  public struct HexF
  {
    public readonly double X;
    public readonly double Y;
    public double Z => -X - Y;

    public HexF(double x, double y)
    {
      X = x;
      Y = y;

      // Assert valid HexF coordinates
      if (Math.Round(X + Y + Z) != 0) throw new ArgumentException("Coordinates do not represent a valid HexF.");
    }

    public Hex ToHex()
    {
      int xInt = (int)Math.Round(X);
      int yInt = (int)Math.Round(Y);
      int zInt = (int)Math.Round(Z);
      double xDiff = Math.Abs(xInt - X);
      double yDiff = Math.Abs(yInt - Y);
      double zDiff = Math.Abs(zInt - Z);
      if (xDiff > yDiff && xDiff > zDiff)
      {
        xInt = -yInt - zInt;
      }
      else if (yDiff > zDiff)
      {
        yInt = -xInt - zInt;
      }
      return new Hex(xInt, yInt);
    }
    public static implicit operator Hex(HexF hexF) => hexF.ToHex();
    public static implicit operator HexF(Hex hex) => new(hex.X + 1e-6, hex.Y + 1e-6);

    public HexF Lerp(HexF b, double t) => new(X * (1.0 - t) + b.X * t, Y * (1.0 - t) + b.Y * t);
  }
}
