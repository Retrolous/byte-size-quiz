using System.Windows.Forms;


namespace Petkunas__Lukas___Byte_size_Quiz
{

    // abstract class used to ensure that all gates derived from it have the appropriate methods and fields
    // inherits from picturebox so it can be displayed as one in the form
    public abstract class Gate : PictureBox
    {
        // used to determine the output from inputting any 2 values into a gate
        public abstract bool returnValue(bool value1, bool value2 = false);
        public int activeConnectionsTo = 0;
        public bool connectedFrom = false;
        public virtual int MaxConnectionsTo { get; } = 1;
    }
    public class Buffer : Gate
    {
        // buffer simply returns what was input
        // has one connection
        public override bool returnValue(bool value1, bool value2 = false)
        {
            return value1;
        }

        public override int MaxConnectionsTo { get; } = 1;
    }
    public class AndGate : Gate
    {
        // and gate returns true if both inputs true
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return value1 && value2;
        }

        public override int MaxConnectionsTo { get; } = 2;
    }

    public class NAndGate : Gate
    {
        // nand gate returns false only if both inputs true
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return !(value1 && value2);
        }

        public override int MaxConnectionsTo { get; } = 2;
    }
    public class NotGate : Gate
    {
        // not gate returns opposite of input value
        // has one connection
        public override bool returnValue(bool value1, bool value2 = false)
        {
            return !value1;
        }

        public override int MaxConnectionsTo { get; } = 1;
    }
    public class OrGate : Gate
    {
        // or gate returns true if at least one value is true
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return value1 || value2;
        }

        public override int MaxConnectionsTo { get; } = 2;
    }
    public class XOrGate : Gate
    {
        // xor gate returns true only if both values are different to each other
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return !((value1 && value2) || (!value1 && !value2));
        }

        public override int MaxConnectionsTo { get; } = 2;
    }
    public class XNOrGate : Gate
    {
        // xnor gate returns true only if both values are the same
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return (value1 && value2) || (!value1 && !value2);
        }

        public override int MaxConnectionsTo { get; } = 2;
    }
    public class NOrGate : Gate
    {
        // nor gate only returns true if both values are false
        // has two connections
        public override bool returnValue(bool value1, bool value2)
        {
            return (!value1 && !value2);
        }

        public override int MaxConnectionsTo { get; } = 2;
    }
}
