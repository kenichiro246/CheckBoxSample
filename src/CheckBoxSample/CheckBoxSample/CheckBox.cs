using Xamarin.Forms;

namespace CheckBoxSample
{
    public class CheckBox : Button
    {
        public CheckBox()
        {
            this.Clicked += ((s, e) =>
              {
                  IsCheck = !IsCheck;
              });
            Image = getImageFileName(false);
            this.BackgroundColor = Color.White;
        }

        public static BindableProperty IsCheckProperty = 
            BindableProperty.Create(nameof(IsCheck),typeof(bool), typeof(CheckBox), false,
                propertyChanged: CheckedValueChanged);

        public bool IsCheck
        {
            get { return (bool)GetValue(IsCheckProperty); }
            set { SetValue(IsCheckProperty, value); }
        }

        private static void CheckedValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Button).Image = getImageFileName((bool)newValue);
        }

        private static string getImageFileName(bool value)
        {
            return value ? "icon_check_b96.png" : "icon_check_empty_b96.png";
        }
    }
}
