using MaterialEntry.iOS.Renderers;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(MyMaterialEntryRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace MaterialEntry.iOS.Renderers
{
    public class MyMaterialEntryRenderer : MaterialEntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || sender == null) return;

            if (sender is MyMaterialEntry customEntry)
            {
                UITextField textField = Control;
                textField.BorderStyle = UITextBorderStyle.None;
                textField.TintColor = customEntry.MyHandleColor.ToUIColor();
            }
        }
    }
}
