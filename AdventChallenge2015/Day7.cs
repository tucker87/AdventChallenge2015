using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventChallenege2015
{
    internal class Day7
    {
        private List<Wire> Wires { get; } = new List<Wire>();
        private List<Gate> Gates { get; } = new List<Gate>();
        public ushort Solve1(List<string> input)
        {
            foreach (var instruction in input)
            {
                var gate = GetGate(instruction);
                Gates.Add(gate);
                var wireNames = WireNames(instruction);
                AttachToGate(new[]{ wireNames[0], wireNames[1]}, gate);
                AttachFromGate(wireNames[2], gate);
            }

            return Wires.First(x => x.Name == "a").Output;
        }

        public ushort Solve2(List<string> input)
        {
            var overrideB = Solve1(input);

            foreach (var gate in Gates)
            {
                if (gate.Wires.Any(x => x.Name == "b"))
                    for(var i = 0; i < gate.Wires.Count; i++)
                    {
                        if (gate.Wires[i].Name == "b")
                            gate.Wires[i] = new EndWire(overrideB) { Name = "b" };
                    }
            }

            Wires.Remove(Wires.First(x => x.Name == "b"));
            foreach (var gate in Gates)
                gate.Reset();

            return Wires.First(x => x.Name == "a").Output;
        }

        private static Gate GetGate(string instruction)
        {
            if (instruction.Contains("NOT"))
                return new Gate((value, unused) => (ushort)~value);

            if (instruction.Contains("AND"))
                return new Gate((value1, value2) => (ushort)(value1 & value2));

            if (instruction.Contains("OR"))
                return new Gate((value1, value2) => (ushort)(value1 | value2));

            if (instruction.Contains("LSHIFT"))
                return new Gate((value1, value2) => (ushort)(value1 << value2));

            if (instruction.Contains("RSHIFT"))
                return new Gate((value1, value2) => (ushort)(value1 >> value2));

            return new Gate((value1, unused) => value1);
        }

        private static List<string> WireNames(string instruction)
        {
            var instructions = instruction.Split(' ').Where(x => x != "->").ToList();
            
            var value1 = instructions[0] != "NOT" 
                ? instructions[0] 
                : instructions[1];

            instructions = instructions.Where(x => x != "NOT").ToList();

            var value2 = "";
            if (instructions.Count > 2)
                value2 = instructions[2];

            var target = instructions.Count == 2 
                ? instructions[1] 
                : instructions[3];

            return new List<string> { value1, value2, target };
        }

        private void AttachToGate(IReadOnlyList<string> wireNames, Gate gate)
        {
            foreach (var wireName in wireNames)
            {
                if (Wires.Count(x => x.Name == wireName) > 0)
                    gate.Wires.Add(Wires.First(x => x.Name == wireName));
                else
                {
                    ushort hardValue;
                    if (ushort.TryParse(wireName, out hardValue))
                    {
                        var wire = new EndWire(hardValue);
                        Wires.Add(wire);
                        gate.Wires.Add(wire);
                    }
                    else if (string.IsNullOrEmpty(wireName))
                    {
                        var wire = new EndWire(0);
                        gate.Wires.Add(wire);
                    }
                    else
                    {
                        var wire = new Wire {Name = wireName};
                        Wires.Add(wire);
                        gate.Wires.Add(wire);
                    }
                }
            }
        }

        private void AttachFromGate(string target, Gate gate)
        {
            var wire = Wires.FirstOrDefault(x => x.Name == target);
            if (wire != null)
                wire.Input = gate;
            else
                Wires.Add(new Wire{ Name = target, Input = gate });
        }
    }

    class Wire
    {
        public virtual string Name { get; set; }
        public Gate Input { get; set; }

        public virtual ushort Output => Input.Output;

        public override string ToString()
        {
            return Name;
        }
    }

    class EndWire : Wire
    {
        private string _name;

        public EndWire(ushort hardValue)
        {
            Output = hardValue;
        }

        public override string Name
        {
            get { return string.IsNullOrEmpty(_name) ? "EndWire" : _name; }
            set { _name = value; }
        }

        public override ushort Output { get; }
    }

    class Gate
    {
        public Gate(Func<ushort, ushort, ushort> func)
        {
            Function = func;
        }

        public List<Wire> Wires { get; set; } = new List<Wire>();
        public Func<ushort, ushort, ushort> Function { get; set; }

        private ushort? _output;
        public ushort Output => (ushort)(_output ?? (_output = Function.Invoke(Wires[0].Output, Wires[1].Output)));

        public void Reset()
        {
            _output = null;
        }
    }
}