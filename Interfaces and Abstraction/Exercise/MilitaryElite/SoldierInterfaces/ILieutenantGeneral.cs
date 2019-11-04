namespace MilitaryElite.SoldierInterfaces
{
    using System.Collections.Generic;
    using Soldiers;

    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }

        void AddPrivate(Private @private);
    }
}
