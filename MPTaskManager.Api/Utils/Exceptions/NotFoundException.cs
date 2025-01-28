namespace MPTaskManager.Api.Utils.Exceptions; 
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}