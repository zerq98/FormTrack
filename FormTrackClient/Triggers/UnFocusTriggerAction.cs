namespace FormTrackClient.Triggers
{
    public class UnFocusTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry entry)
        {
            entry.IsEnabled = false;
            entry.IsEnabled = true;
        }
    }
}