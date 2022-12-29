using Microsoft.AspNetCore.Components;

namespace IFS.DB.WebApp.Helpers.EventHanderBinding;

public class ChangeEventBinding
{
    public event EventHandler<ChangeEventArgs>? ChangeEventHandler;

    public void Invoke(object sender, ChangeEventArgs args)
        => ChangeEventHandler?.Invoke(sender, args);
}