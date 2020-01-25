using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconhecimento_Defeitos
{
   public class Class
    {
        public class Classe
        {
            public string @class { get; set; }
            public double score { get; set; }
        }

        public class Classifier
        {
            public string name { get; set; }
            public string classifier_id { get; set; }
            public List<Class> classes { get; set; }
        }

        public class RootObject
        {
            public string image { get; set; }
            public List<Classifier> classifiers { get; set; }
        }





    }
}
