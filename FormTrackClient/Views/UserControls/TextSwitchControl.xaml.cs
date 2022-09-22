namespace FormTrackClient.Views.UserControls;

public partial class TextSwitchControl : ContentView
{
    public double LabelWidth
    {
        get
        {
            return MainLayout.Width / 2;
        }
    }

    public string RightContent
    {
        get
        {
            return (string)GetValue(RightContentProperty);
        }
        private set
        {
            SetValue(RightContentProperty, value);
        }
    }

    public static readonly BindableProperty RightContentProperty = BindableProperty.Create(
  propertyName: "RightContent",
  returnType: typeof(string),
  declaringType: typeof(ContentView),
  defaultValue: string.Empty,
  defaultBindingMode: BindingMode.OneWay,
  propertyChanged: RightContentPropertyChanged);

    private static void RightContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (TextSwitchControl)bindable;
        control.RightLabel.Text = (string)newValue;
    }

    public string LeftContent
    {
        get
        {
            return (string)GetValue(LeftContentProperty);
        }
        private set
        {
            SetValue(LeftContentProperty, value);
        }
    }

    public static readonly BindableProperty LeftContentProperty = BindableProperty.Create(
  propertyName: "LeftContent",
  returnType: typeof(string),
  declaringType: typeof(ContentView),
  defaultValue: string.Empty,
  defaultBindingMode: BindingMode.OneWay,
  propertyChanged: LeftContentPropertyChanged);

    private static void LeftContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (TextSwitchControl)bindable;
        control.LeftLabel.Text = (string)newValue;
    }

    public TextSwitchControl()
    {
        InitializeComponent();
        LeftLabel.WidthRequest = 200;
        RightLabel.WidthRequest = 240;
        Highlight.WidthRequest = 200;
        RightLabel.TranslateTo(-60, 0);
    }

    private void Label_Tapped(object sender, EventArgs e)
    {
        if (((Label)sender).Text == LeftLabel.Text)
        {
            Highlight.TranslateTo(0, 0);
            IsLeftSelected = true;
        }
        else
        {
            Highlight.TranslateTo(180, 0);
            IsLeftSelected = false;
        }
    }
    public bool IsLeftSelected
    {
        get
        {
            return (bool)GetValue(IsLeftSelectedProperty);
        }
        private set
        {
            SetValue(IsLeftSelectedProperty, value);
        }
    }

    public static readonly BindableProperty IsLeftSelectedProperty =
    BindableProperty.Create(nameof(IsLeftSelected), typeof(bool), typeof(TextSwitchControl), false,BindingMode.TwoWay);
}