public class EventLog
{
    private string actor;
    private string verb;
    private string sceneObject;

    public EventLog(string actor, string verb, string sceneObject)
    {
        this.actor = actor;
        this.verb = verb;
        this.sceneObject = sceneObject;
    }

    public override string ToString()
    {
        return string.Format("{0};{1};{2}", this.actor, this.verb, this.sceneObject);
    }
}