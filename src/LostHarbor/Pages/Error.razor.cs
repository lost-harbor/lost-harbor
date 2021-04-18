// SPDX-License-Identifier: MIT
// Copyright ©2021 Marc King

using System;
using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Pages
{
  public class ErrorBase : ComponentBase
  {

    protected void GenerateError()
    {
      throw new Exception();
    }
  }
}
