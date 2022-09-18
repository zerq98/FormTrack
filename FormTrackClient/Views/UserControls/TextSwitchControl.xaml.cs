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

    public bool IsLeftSelected { get; private set; }

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
            Highlight.TranslateTo(220, 0);
            IsLeftSelected = false;
        }
    }
}