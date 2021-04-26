// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

namespace LogicSeed.LostHarbor.Core.Grid
{
  public struct Layout
  {
    public readonly Orientation Orientation;
    public readonly PointF Size;
    public readonly PointF Origin;

    public Layout(Orientation orientation, PointF size, PointF origin)
    {
      Orientation = orientation;
      Size = size;
      Origin = origin;
    }
  }
}
