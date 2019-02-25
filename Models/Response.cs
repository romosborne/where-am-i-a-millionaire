using System.Collections.Generic;

using Newtonsoft.Json;

namespace where_am_i_a_millionaire.Models{
    public class Response {
        public string OriginalCurrency{get;set;}
        public double OriginalAmount{get;set;}
        public List<Something> Results {get;set;}
    }

    public class Something {
        public string Currency {get;set;}
        public double Amount {get;set;}
    }
}