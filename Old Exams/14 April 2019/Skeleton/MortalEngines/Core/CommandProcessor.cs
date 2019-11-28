namespace MortalEngines.Core
{
    using System;
    using Contracts;    

    public class CommandProcessor : ICommandProcessor
    {
        private IMachinesManager machinesManager;

        public CommandProcessor()
        {
            this.machinesManager = new MachinesManager();
        }

        public void ExecuteCommand(string command)
        {
            string[] commandParts = command.Split();
            string commandName = commandParts[0];

            string result = string.Empty;

            try
            {
                if (commandName == "HirePilot")
                {
                    string pilotName = commandParts[1];

                    result = this.machinesManager.HirePilot(pilotName);
                }
                else if (commandName == "PilotReport")
                {
                    string pilotName = commandParts[1];

                    result = this.machinesManager.PilotReport(pilotName);
                }
                else if (commandName == "ManufactureTank")
                {
                    string tankName = commandParts[1];
                    double attack = double.Parse(commandParts[2]);
                    double defence = double.Parse(commandParts[3]);

                    result = this.machinesManager.ManufactureTank(tankName, attack, defence);
                }
                else if (commandName == "ManufactureFighter")
                {
                    string name = commandParts[1];
                    double attack = double.Parse(commandParts[2]);
                    double defence = double.Parse(commandParts[3]);

                    result = this.machinesManager.ManufactureFighter(name, attack, defence);
                }
                else if (commandName == "MachineReport")
                {
                    string name = commandParts[1];

                    result = this.machinesManager.MachineReport(name);
                }
                else if (commandName == "AggressiveMode")
                {
                    string name = commandParts[1];

                    result = this.machinesManager.ToggleFighterAggressiveMode(name);
                }
                else if (commandName == "DefenseMode")
                {
                    string name = commandParts[1];

                    result = this.machinesManager.ToggleTankDefenseMode(name);
                }
                else if (commandName == "Engage")
                {
                    string pilotName = commandParts[1];
                    string machineName = commandParts[2];

                    result = this.machinesManager.EngageMachine(pilotName, machineName);
                }
                else if (commandName == "Attack")
                {
                    string attackingMachine = commandParts[1];
                    string defendingMachine = commandParts[2];

                    result = this.machinesManager.AttackMachines(attackingMachine, defendingMachine);
                }
            }
            catch (ArgumentNullException ex)
            {
                result = $"Error:{ex.Message}";
            }
            catch (NullReferenceException ex)
            {
                result = $"Error:{ex.Message}";
            }
            catch (Exception ex)
            {
                result = $"Error:{ex.Message}";
            } 
            finally
            {
                Console.WriteLine(result);
            }            
        }
    }
}
