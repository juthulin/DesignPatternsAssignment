public class CommandDealDamage : ICommand
{
    private Idamageable  _obj;
    private AttackSchema _attackSchema;

    public CommandDealDamage(Idamageable obj, AttackSchema attackSchema)
    {
        this._obj = obj;
        _attackSchema = attackSchema;
    }

    public void Execute()
    {
        _obj.TakeDamage(_attackSchema.damageAmount);
    }
}