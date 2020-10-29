using System.Collections.Generic;

namespace BasicEssentials.Model
{
    public class ResponsePoke
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Result> results { get; set; }
    }
    
    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    } 
    
}