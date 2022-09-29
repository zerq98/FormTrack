namespace FormTrackClient.Views.UserControls;

public partial class ActivityPanelContorl : ContentView
{
    public string LabelImage
    {
        get
        {
            return (string)GetValue(LabelImageProperty);
        }
        private set
        {
            SetValue(LabelImageProperty, value);
        }
    }

    public static readonly BindableProperty LabelImageProperty = BindableProperty.Create(
  propertyName: "LabelImage",
  returnType: typeof(string),
  declaringType: typeof(ContentView),
  defaultValue: string.Empty,
  defaultBindingMode: BindingMode.OneWay,
  propertyChanged: RightContentPropertyChanged);

    private static void RightContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ActivityPanelContorl)bindable;
        control.BackgroundImage.Source = (string)newValue;
    }

    public string LabelText
    {
        get
        {
            return (string)GetValue(LabelTextProperty);
        }
        private set
        {
            SetValue(LabelTextProperty, value);
        }
    }

    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(
  propertyName: "LabelText",
  returnType: typeof(string),
  declaringType: typeof(ContentView),
  defaultValue: string.Empty,
  defaultBindingMode: BindingMode.OneWay,
  propertyChanged: LabelTextPropertyChanged);

    private static void LabelTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ActivityPanelContorl)bindable;
        control.ActivityText.Text = (string)newValue;
    }

    public ActivityPanelContorl()
    {
        InitializeComponent();
    }
}