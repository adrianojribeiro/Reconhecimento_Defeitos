using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconhecimento_Defeitos
{
   public class Classificacao
    {
        public class Class
        {
            public string @class { get; set; }
            public double score { get; set; }
        }

        public class Classifier
        {
            public string classifier_id { get; set; }
            public string name { get; set; }
            public List<Class> classes { get; set; }
        }

        public class Image
        {
            public List<Classifier> classifiers { get; set; }
            public string image { get; set; }
        }

        public class RootObject
        {
            public List<Image> images { get; set; }
            public int images_processed { get; set; }
            public int custom_classes { get; set; }
        }
    }
}
