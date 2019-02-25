using System.Collections.Generic;

namespace where_am_i_a_millionaire.Models{
    public class ExchangeResponse{
        public Dictionary<string, double> Rates {get;set;}
        public string @Base {get;set;}
    }
}