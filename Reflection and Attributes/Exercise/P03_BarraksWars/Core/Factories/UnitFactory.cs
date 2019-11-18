namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var unitClassPath = $"{typeof(AppEntryPoint).Namespace}.Models.Units.";

            Type classType = Type.GetType(unitClassPath + unitType);

            IUnit unit = (IUnit)Activator.CreateInstance(classType);

            return unit;
        }
    }
}
