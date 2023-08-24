using MauiReactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Pages
{

    [Scaffold(typeof(Syncfusion.Maui.Core.SfView))]
    public abstract class SfView { }

    [Scaffold(typeof(Syncfusion.Maui.Inputs.SfMaskedEntry))]
    public partial class SfMaskedEntry { }

    [Scaffold(typeof(Syncfusion.Maui.Core.SfContentView))]
    public abstract class SfContentView { }

    [Scaffold(typeof(Syncfusion.Maui.Core.SfTextInputLayout))]
    public partial class SfTextInputLayout
    {
        public SfTextInputLayout Content(Func<VisualNode> render)
        {
            this.Set(Syncfusion.Maui.Core.SfTextInputLayout.ContentProperty,
                new MauiControls.DataTemplate(() => TemplateHost.Create(render()).NativeElement));

            return this;
        }
    }

    internal class MainPageState
    {
        public int Counter { get; set; }
    }

    internal class MainPage : Component<MainPageState>
    {
        public override VisualNode Render()
        {
            return new ContentPage
        {
            new ScrollView
            {
                new VerticalStackLayout
                {
                    new Label("Should be here --->>"),
                    new SfTextInputLayout()
                    {
                        new Entry().Text("Entry in SfTextInputLayout")
                    }.Hint("Hint").ContainerType(Syncfusion.Maui.Core.ContainerType.Filled)
                     .Content(() => new Entry().Text("Entry in SfTextInputLayout - content")),
                    new Label("<<---"),

                    new Image("dotnet_bot.png")
                        .HeightRequest(200)
                        .HCenter()
                        .Set(Microsoft.Maui.Controls.SemanticProperties.DescriptionProperty, "Cute dot net bot waving hi to you!"),

                    new Label("Hello, World!")
                        .FontSize(32)
                        .HCenter(),

                    new Label("Welcome to MauiReactor: MAUI with superpowers!")
                        .FontSize(18)
                        .HCenter(),

                    new Button(State.Counter == 0 ? "Click me" : $"Clicked {State.Counter} times!")
                        .OnClicked(()=>SetState(s => s.Counter ++))
                        .HCenter()
                }
                .VCenter()
                .Spacing(25)
                .Padding(30, 0)
            }
        };
        }
    }
}