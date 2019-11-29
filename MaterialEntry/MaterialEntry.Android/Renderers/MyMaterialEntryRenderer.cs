using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Text;
using Android.Widget;
using Java.Lang;
using MaterialEntry.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(MyMaterialEntryRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace MaterialEntry.Droid.Renderers
{
    public class MyMaterialEntryRenderer : MaterialEntryRenderer
    {
        public MyMaterialEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (e.NewElement is MyMaterialEntry customEntry)
            {
                EditText.SetHighlightColor(color: customEntry.MyHighlightColor.ToAndroid());

                try
                {
                    JNIEnv.SetField(EditText.Handle, JNIEnv.GetFieldID(JNIEnv.FindClass(typeof(TextView)), "mCursorDrawableRes", "I"), 0);
                    using (var textViewTemplate = new TextView(EditText.Context))
                    {
                        var field = textViewTemplate.Class.GetDeclaredField("mEditor");
                        field.Accessible = true;
                        var editor = field.Get(EditText);

                        string[]
                        fieldsNames = { "mTextSelectHandleLeftRes", "mTextSelectHandleRightRes", "mTextSelectHandleRes" },
                        drawablesNames = { "mSelectHandleLeft", "mSelectHandleRight", "mSelectHandleCenter" };

                        for (int index = 0; index < fieldsNames.Length && index < drawablesNames.Length; index++)
                        {
                            field = textViewTemplate.Class.GetDeclaredField(fieldsNames[index]);
                            field.Accessible = true;
                            Drawable handleDrawable = ContextCompat.GetDrawable(Context, field.GetInt(EditText));

                            handleDrawable.SetColorFilter(new PorterDuffColorFilter(customEntry.MyHighlightColor.ToAndroid(), PorterDuff.Mode.SrcIn));

                            field = editor.Class.GetDeclaredField(drawablesNames[index]);
                            field.Accessible = true;
                            field.Set(editor, handleDrawable);
                        }
                    }
                }
                catch (NoSuchFieldError)
                {
                }
                catch (NoSuchFieldException)
                {
                }
                catch (ReflectiveOperationException)
                {
                }                
            }
        }
    }
}
