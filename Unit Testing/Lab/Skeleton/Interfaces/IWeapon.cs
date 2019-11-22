namespace Skeleton.Interfaces
{
    public interface IWeapon
    {
        int DurabilityPoints { get; }

        int AttackPoints { get; }

        void Attack(ITarget target);
    }
}
