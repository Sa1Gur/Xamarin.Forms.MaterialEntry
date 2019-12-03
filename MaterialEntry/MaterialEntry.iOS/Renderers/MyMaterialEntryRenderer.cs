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
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            TintCustomization(Control, e.NewElement as MyMaterialEntry);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);            

            TintCustomization(Control, sender as MyMaterialEntry);
        }

        private void TintCustomization(UITextField Control, MyMaterialEntry customEntry)
        {
            if (Control == null) return;

            if (customEntry != null)
            {
                UITextField textField = Control;
                textField.BorderStyle = UITextBorderStyle.None;
                textField.TintColor = customEntry.MyHandleColor.ToUIColor();
            }
        }
    }
}
