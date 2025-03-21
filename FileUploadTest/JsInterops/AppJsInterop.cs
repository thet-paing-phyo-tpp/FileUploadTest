
using Microsoft.JSInterop;

namespace FileUploadTest.JsInterops;

public class AppJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _ModuleTask;
    private readonly IJSRuntime _JSRuntime;

    public AppJsInterop(IJSRuntime JSRuntime)
    {
        _JSRuntime = JSRuntime;
        _ModuleTask = new(() => _JSRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./app.js").AsTask());
    }

    public async ValueTask ShowMessage(string message)
    {
        var module = await _ModuleTask.Value;
        await module.InvokeVoidAsync("ShowMessage", message);
    }

    public async ValueTask UploadFile()
    {
        var module = await _ModuleTask.Value;
        await module.InvokeVoidAsync("UploadFile");
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}
