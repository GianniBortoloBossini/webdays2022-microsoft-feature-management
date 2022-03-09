using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace WebDays2022.Api.SessionManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class SlowController : ControllerBase
{
    [HttpGet("Unsafe", Name = "GetUnsafeData")]
    public async Task<IActionResult> GetUnsafeData([FromServices]IFeatureManager featureManager)
    {
        List<string> result = new();
        for (int i = 0; i < 10; i++)
        {
            var flagState = await featureManager.IsEnabledAsync(nameof(FeatureFlags.SlowEnabled));
            result.Add(flagState.ToString());
        } 
        return Ok(string.Join(", ", result));
    }

    [HttpGet("Safe", Name = "GetSafeData")]
    public async Task<IActionResult> GetSafeData([FromServices]IFeatureManagerSnapshot featureManagerSnapshot)
    {
        List<string> result = new();
        for (int i = 0; i < 10; i++)
        {
            var flagState = await featureManagerSnapshot.IsEnabledAsync(nameof(FeatureFlags.SlowEnabled));
            result.Add(flagState.ToString());
        } 
        return Ok(string.Join(", ", result));
    }
}
