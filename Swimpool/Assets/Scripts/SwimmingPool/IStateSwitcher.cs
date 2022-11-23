public interface IStateSwitcher<T>
{
    void SwitchNextState();
    void Switcher(T t);
}

public interface IChangeActiveItem
{
    public void ActivateState();
    public void DesactivateState();
}