using BindableProps;
using Microsoft.Maui.Controls.Shapes;
using System.Runtime.CompilerServices;

namespace AppListaCompras.Libraries.Components;

public partial class HorizontalLine : ContentView
{

    [BindableProp]
    private Color _stroke;
    public HorizontalLine()
	{
		InitializeComponent();
	}
    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (Window?.Width != null && sLine != null)
        {
            sLine.X2 = Window.Width;
        }

        if (propertyName == "Stroke")
        {
            sLine.Stroke = Stroke;
        }
    }
}