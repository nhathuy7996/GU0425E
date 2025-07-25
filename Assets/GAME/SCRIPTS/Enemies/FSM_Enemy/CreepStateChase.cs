using UnityEngine;
public class CreepStateChase : CreepStateBase
{
    Transform _target;
    public CreepStateChase(CreepCtrl creepCtrl) : base(creepCtrl)
    {
    }

    public override void Execute()
    {
        //Truy duoi player
        //DetectPlayer == null => changeStatePatrol
        // Distance == () => atk

    }

    public override void OnEnter()
    {
        _target = this.creepCtrl.DetectPlayer();
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }
}