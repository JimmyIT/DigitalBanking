using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace IFS.DB.WebApp.Pages.BaseComponents.TabLoigcal;

public class TabState
{
    public int CurrentActive { get; set; }

    public Func<int, Action> SetActive => index => () =>
    {
        CurrentActive = index;
    };

    public string ClassStatus(int index, string activeClass, string inactiveClass = "")
    {
        return CurrentActive == index ? activeClass : inactiveClass;
    }

}