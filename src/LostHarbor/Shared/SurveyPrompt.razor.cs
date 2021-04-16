using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Shared
{
  public class SurveyPromptBase : ComponentBase
  {
    // Demonstrates how a parent component can supply parameters
    [Parameter]
    public string Title { get; set; }
  }
}
