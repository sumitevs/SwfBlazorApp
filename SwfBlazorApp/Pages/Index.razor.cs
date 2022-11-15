using SwfBlazorApp.Components.Widgets;

namespace SwfBlazorApp.Pages
{
    public partial class Index
    {
        public List<Type> Widgets { get; set; } = new List<Type>() { typeof(DeviceCountWidget), typeof(InboxWidget)};
    }
}
