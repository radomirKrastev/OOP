namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = typeof(AppEntryPoint).Assembly;

            Type classType = assembly.GetTypes().First(x => x.Name == unitType);

            IUnit unit = (IUnit)Activator.CreateInstance(classType);

            return unit;
        }
    }
}
