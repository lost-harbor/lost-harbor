using Microsoft.AspNetCore.Components;

namespace LogicSeed.LostHarbor.Pages
{
  public class CounterBase : ComponentBase
  {
    protected int CurrentCount { get; set; } = 0;

    protected void IncrementCount()
    {
      CurrentCount++;
    }
  }
}
