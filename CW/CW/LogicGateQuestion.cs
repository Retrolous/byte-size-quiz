using System.Collections.Generic;


namespace Petkunas__Lukas___Byte_size_Quiz
{
    // class representing a question in challenge 2
    class LogicGateQuestion
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Difficulty { get; set; }
        public int MinimumConnections { get; set; }
        public bool CorrectReturn { get; set; }
        public Dictionary<string, int> TargetAttempts{ get; set; } = new Dictionary<string, int> { };
        public List<string> AvailableGates { get; set; } = new List<string> { };
    }
}
