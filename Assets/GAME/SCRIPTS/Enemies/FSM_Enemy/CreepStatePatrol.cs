
using UnityEngine;
public class CreepStatePatrol : CreepStateBase
{

    Vector2? _target = null;

    public CreepStatePatrol(CreepCtrl creepCtrl) : base(creepCtrl)
    {
        Debug.LogError("Create CreepStatePatrol");
    }


    public override void Execute()
    {
        Debug.LogError("Execute patrol state");
        if (_target == null || Vector2.Distance((Vector2)_target, this.creepCtrl.transform.position) < 0.5f)
        {
            ResetTarget();
        }

        Vector2 dir = (Vector2)_target - (Vector2)this.creepCtrl.transform.position;
        dir = dir.normalized;
        this.creepCtrl.transform.Translate(dir * this.creepCtrl.Speed * Time.deltaTime);

        if (this.creepCtrl.DetectPlayer() != null)
        {
            this.creepCtrl.ChangeState(typeof(CreepStateChase));
        }
         
    }
    

    void ResetTarget()
    {
        this._target = new Vector2(Random.Range(-5, 6), Random.Range(3, 6));
    }

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {
        
    }
}