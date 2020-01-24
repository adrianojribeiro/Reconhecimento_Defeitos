using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.VisualRecognition.v3;
using IBM.Watson.VisualRecognition.v3.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reconhecimento_Defeitos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            IamAuthenticator authenticator = new IamAuthenticator(apikey: "sU-ciZ0JvXBm800VEAyRakwHeKcNBV1NkkrNBRuBxPS1");

            VisualRecognitionService visualRecognition = new VisualRecognitionService("2018-03-19", authenticator);
            visualRecognition.SetServiceUrl("https://api.us-south.visual-recognition.watson.cloud.ibm.com/instances/1eae2afd-1a53-4887-988a-df2841a16885");
                       

            DetailedResponse<ClassifiedImages> resultado;

            using (FileStream fs = File.OpenRead("./teste.jpg"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    resultado = visualRecognition.Classify(
                        imagesFile: ms,
                        imagesFilename: "teste.jpg",
                        classifierIds: new List<string>()
                        {
                "Defeitos_583836283"
                        }
                        );
                }                                          

              //  MessageBox.Show(JsonConvert.SerializeObject(resultado, Formatting.Indented));            
            }
            MessageBox.Show(resultado.Response);
        }
    }
}
