
public abstract class CreepStateBase
{
    protected CreepCtrl creepCtrl;

    public CreepStateBase(CreepCtrl creepCtrl)
    {
        this.creepCtrl = creepCtrl;
    }
    public abstract void Execute();

    public abstract void OnExit();

    public abstract void OnEnter();
}