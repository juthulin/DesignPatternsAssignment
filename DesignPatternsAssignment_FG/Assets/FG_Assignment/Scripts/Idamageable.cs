using System;

public interface Idamageable : IIdentifiable
{
    void TakeDamage(ValueType amount);
}
