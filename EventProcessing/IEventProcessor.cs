namespace pantry_service.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}