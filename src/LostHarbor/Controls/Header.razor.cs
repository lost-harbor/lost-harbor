// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Controls
{
  public class HeaderBase : ComponentBase
  {
    protected int CurrentCount { get; set; } = 0;

    protected void IncrementCount()
    {
      CurrentCount++;
    }
  }
}
