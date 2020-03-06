using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.VisualRecognition.v3;
using IBM.Watson.VisualRecognition.v3.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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

        string arquivo;

        private void button1_Click(object sender, EventArgs e)
        {
            IamAuthenticator authenticator = new IamAuthenticator(apikey: "sU-ciZ0JvXBm800VEAyRakwHeKcNBV1NkkrNBRuBxPS1");
            VisualRecognitionService visualRecognition = new VisualRecognitionService("2018-03-19", authenticator);
            visualRecognition.SetServiceUrl("https://api.us-south.visual-recognition.watson.cloud.ibm.com/instances/1eae2afd-1a53-4887-988a-df2841a16885");
            DetailedResponse<ClassifiedImages> resultado;
            arquivo = CarregaFoto();

            try
            {
                // using (FileStream fs = File.OpenRead("./teste.jpg"))
                using (FileStream fs = File.OpenRead(arquivo))

                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        resultado = visualRecognition.Classify(
                        imagesFile: ms,
                        imagesFilename: "*.jpg",
                        classifierIds: new List<string>()
                        {"Defeitos_583836283"});

                    }
                }

       

                var json = JsonConvert.SerializeObject(resultado.Result.Images); // cria uma especie de Json     
            
                richTextBox.Text = Resultado_Final(json);
                textBoxcaminhoarquivo.Text = arquivo;
                MessageBox.Show(Resultado_Final(json));

            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }

        }

        public string Resultado_Final(string texto) // funçao tratamento de dados
        {
            var array_resultado = texto.Split('[', ']'); // array com o resultado, filtrado entre o especificado.
            string resultado_string = array_resultado[3].ToString();
            string final = resultado_string.Replace("{", "").Replace("}", "").Replace("\"", "");
            return final;
        }


        public string CarregaFoto()
        {
            string filename = string.Empty;
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;          
            }
            pictureBox.LoadAsync(filename);

            return filename;

            
        }

    }
}
