using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Realms;
using RiverGPSCounter.DataClass;
using RiverGPSCounter.DataObjects;
using RiverGPSCounter.Helper;
using RiverGPSCounter.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RiverGPSCounter
{
    public partial class Form1 : Form
    {
        RealmHelper realmHelper;

        FileHelper fileHelper;

        string[] filePaths;

        public Form1()
        {
            InitializeComponent();
            realmHelper = new RealmHelper();
            fileHelper = new FileHelper();
        }

        public async Task<bool> ProcessRiver<T>(ParsedRiver river)
            where T : IRiver
        {

            await realmHelper.ClearDatabase<T>();
            await realmHelper.FillDatabase<T>(river.gpsPoints!);
            await realmHelper.ComputeDistances<T>();

            return true;
        }

        public async void Process()
        {
            Debug.WriteLine("START");


            pnInput.Enabled = false;
            pbInfo.Style = ProgressBarStyle.Marquee;
            pbInfo.MarqueeAnimationSpeed = 30;

            foreach (var filePath in filePaths)
            {
                var riverObj = fileHelper.ReadFile(filePath);

                if (riverObj == null || riverObj.gpsPoints == null || riverObj.name == null)
                {
                    MessageBox.Show("Processing error");
                    return;
                }


                lbRiver.Text = string.Format("Zpracování øeky {0}. Prosím èekejte", riverObj.name);

                var simpleRiverName = TextUtils.ToAscii(riverObj.name);
                switch (simpleRiverName)
                {
                    case "Becva": 
                        await ProcessRiver<Becva>(riverObj); break;
                    case "Berounka": 
                        await ProcessRiver<Berounka>(riverObj); break;
                    case "Dyje": 
                        await ProcessRiver<Dyje>(riverObj); break;
                    case "Morava":
                    case "March":
                        await ProcessRiver<Morava>(riverObj); break;
                    case "Ohre": 
                        await ProcessRiver<Ohre>(riverObj); break;
                    case "Otava": 
                        await ProcessRiver<Otava>(riverObj); break;
                    case "Sazava": 
                        await ProcessRiver<Sazava>(riverObj); break;
                    case "Vltava": 
                        await ProcessRiver<Vltava>(riverObj); break;
                    case "Bilina": 
                        await ProcessRiver<Bilina>(riverObj); break;
                    case "Divoka Orlice": 
                        await ProcessRiver<DivokaOrlice>(riverObj); break;
                    case "Chrudimka": 
                        await ProcessRiver<Chrudimka>(riverObj); break;
                    case "Jihlava": 
                        await ProcessRiver<Jihlava>(riverObj); break;
                    case "Jizera": 
                        await ProcessRiver<Jizera>(riverObj); break;
                    case "Labe": 
                        await ProcessRiver<Labe>(riverObj); break;
                    case "Loucna": 
                        await ProcessRiver<Loucna>(riverObj); break;
                    case "Luznice": 
                        await ProcessRiver<Luznice>(riverObj); break;
                    case "Metuje":
                        await ProcessRiver<Metuje>(riverObj); break;
                    case "Mostenka":
                        await ProcessRiver<Mostenka>(riverObj); break;
                    case "Mze":
                        await ProcessRiver<Mze>(riverObj); break;
                    case "Nezarka": 
                        await ProcessRiver<Nezarka>(riverObj); break;
                    case "Nova reka": 
                        await ProcessRiver<NovaReka>(riverObj); break;
                    case "Odra": 
                        await ProcessRiver<Odra>(riverObj); break;
                    case "Opava": 
                        await ProcessRiver<Opava>(riverObj); break;
                    case "Ostravice": 
                        await ProcessRiver<Ostravice>(riverObj); break;
                    case "Orlice": 
                        await ProcessRiver<Orlice>(riverObj); break;
                    case "Ploucnice":
                        await ProcessRiver<Ploucnice>(riverObj); break;
                    case "Radbuza":
                        await ProcessRiver<Radbuza>(riverObj); break;
                    case "Svratka": 
                        await ProcessRiver<Svratka>(riverObj); break;
                    case "Ticha Orlice": 
                        await ProcessRiver<TichaOrlice>(riverObj); break;
                    case "Uhlava": 
                        await ProcessRiver<Uhlava>(riverObj); break;
                    case "Upa": 
                        await ProcessRiver<Upa>(riverObj); break;
                }
            }


            pbInfo.Style = ProgressBarStyle.Blocks;
            pbInfo.Value = 100;
            lbRiver.Text = string.Format("Zpracování vybraných øek bylo dokonèeno!");
            pnInput.Enabled = true;

            Debug.WriteLine("DONE");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePaths = openFileDialog1.FileNames;
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dwn = new DataDownloader();
            dwn.Show();
        }
    }

}
