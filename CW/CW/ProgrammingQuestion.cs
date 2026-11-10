using System.Collections.Generic;

namespace Petkunas__Lukas___Byte_size_Quiz
{
    // class which represents a question in Challenge 1
    class ProgrammingQuestion
    {
        public string Text { get; set; }
        public string ReturnType { get; set; }
        public string CorrectReturn { get; set; }
        public string PrewrittenText { get; set; }
        public Dictionary<string, int> TargetTimes { get; set; } = new Dictionary<string, int> { };
        public Dictionary<string, List<string>> RequiredKeywords;
    }
}
