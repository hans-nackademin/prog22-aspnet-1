namespace _01_ServiceLifeTimes.Services;

public class TransientService
{
    private Guid id;

    public TransientService()
    {
        id = Guid.NewGuid();
    }

    public Guid GetId() => id;
}
