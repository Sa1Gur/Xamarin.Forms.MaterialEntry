using Xamarin.Forms;

namespace MaterialEntry
{
    public class MyMaterialEntry : Entry
    {
        #region Bindable Properties
        public static readonly BindableProperty MyHighlightColorProperty = BindableProperty.Create(nameof(MyHighlightColor), typeof(Color), typeof(MyMaterialEntry));

        public static readonly BindableProperty MyHandleColorProperty = BindableProperty.Create(nameof(MyHandleColor), typeof(Color), typeof(MyMaterialEntry));

        public static readonly BindableProperty MyTintColorProperty = BindableProperty.Create(nameof(MyTintColor), typeof(Color), typeof(MyMaterialEntry));
        #endregion

        #region Properties
        public Color MyHighlightColor
        {
            get => (Color)GetValue(MyHighlightColorProperty);
            set => SetValue(MyHighlightColorProperty, value);
        }
        public Color MyHandleColor
        {
            get => (Color)GetValue(MyHandleColorProperty);
            set => SetValue(MyHandleColorProperty, value);
        }
        public Color MyTintColor
        {
            get => (Color)GetValue(MyTintColorProperty);
            set => SetValue(MyTintColorProperty, value);
        }
        #endregion
    }
}