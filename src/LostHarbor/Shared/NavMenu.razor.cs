// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Shared
{
  public class NavMenuBase : ComponentBase
  {
    protected bool CollapseNavMenu { get; private set; } = true;

    protected string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
      CollapseNavMenu = !CollapseNavMenu;
    }
  }
}
