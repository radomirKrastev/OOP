namespace MilitaryElite.SoldierInterfaces
{
    using System.Collections.Generic;

    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }

        void AddMission(Mission mission);
    }
}
