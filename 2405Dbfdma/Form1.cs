using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace _405dma
{
    public partial class Form1 : Form
    {
        ushort wModuleNum;
        ushort wSelModuleID;
        ushort Module_Num;
        USBDAQ_DEVICE[] AvailModules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];       
        uint dwDataNum = 51200;
        ushort wSelectedChans = 3;
        uint[] AiBuf = new uint[51200 * 3];       
        private Point[] PointArray = null;
        double[][] chData = null;
        double rawData = 0;
        Thread saveDataThread;
        int savingCounter=0;
        Graphics gr;
        //private List<double[][]> chDataList;
        //private List<uint[]> testList;
        private List<double[]>[] saveDataList;

        public Form1()
        {
            InitializeComponent();
            Module_Num = USBDASK.INVALID_CARD_ID;
        }

        public static double[] sensitivityArr = {9.83, 10.4, 9.32 };
        
        #region Form_Initialize
        private void Form1_Load(object sender, EventArgs e)
        {
            ushort index;
            short iTemp;
            bool bFound;
            short err;
            string strTemp;

            gr = pbxDisplay.CreateGraphics();

            // scan the active USB DASK module
            err = USBDASK.UD_Device_Scan( out wModuleNum, out AvailModules[0]);
            if( err != USBDASK.NoError)
            {
                MessageBox.Show("UD_Device_Scan!!Error Code:" + err.ToString());
                Close();
                return;
            }


            // scan the active USB DASK module
            err = USBDASK.UD_Device_Scan(out wModuleNum, out AvailModules[0]);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_Device_Scan!!Error Code:" + err.ToString());
                Close();
                return;
            }
                        

            bFound = false;
            for( index =0; index < wModuleNum; index ++ )
            {
                if( AvailModules[index].wModuleType == USBDASK.USB_2405) 
                {
                    cbxSelBoard.Items.Add( AvailModules[index].wCardID.ToString() );
                    if( bFound == false )
                    {  
                        bFound = true;
                    }
                }
            }

            if( bFound == true )
            {
                cbxSelBoard.SelectedIndex = 0;
                strTemp = cbxSelBoard.SelectedItem.ToString();
                short.TryParse(strTemp, out iTemp);
                wSelModuleID = (ushort)iTemp;
            }
            else
                MessageBox.Show("No Active module found.");

            iTemp = USBDASK.UD_Register_Card(USBDASK.USB_2405, wSelModuleID);
            if (iTemp < 0)
            {
                MessageBox.Show("Register card Fail, Code:" + Module_Num.ToString());
                Close();
                return;
            }

            Module_Num = (ushort) iTemp;

            tbxYup.Text = "10G";
            tbxYdown.Text = "-10G";
            textYZero.Text = "0 G";
            pbxDisplay.BackColor = Color.Black;

            Initialize();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            short err;
            uint AccessCnt;
            
            gr.Dispose();

            if (Module_Num != USBDASK.INVALID_CARD_ID )            
                err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);

            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
            }

            if (Module_Num != USBDASK.INVALID_CARD_ID)
            {
                USBDASK.UD_Release_Card(Module_Num);
            }

        }

        private void Initialize()
        {
            PointArray = new Point[dwDataNum / 2];
            chData = new double[wSelectedChans][];
            chData[0] = new double[dwDataNum / 2];
            chData[1] = new double[dwDataNum / 2];
            chData[2] = new double[dwDataNum / 2];
            //chDataList = new List<double[][]>();
            //testList = new List<uint[]>();
            saveDataList = new List<double[]>[3];
            for (int i = 0; i < 3; i++)
            {
                saveDataList[i] = new List<double[]>();
            }
        }
        #endregion Form_Initialize

        private void btnStart_Click(object sender, EventArgs e)
        {
            short err;
            //double fActualRate;
            ushort i;
            ushort[] ChanArray = new ushort[wSelectedChans];
            ushort[] RangeArray = new ushort[wSelectedChans];

            //check saving path
            if (!Directory.Exists(txtSavePath.Text))
            {
                MessageBox.Show(txtSavePath.Text + "is not exist.");
                return;
            }

            // Configure AI Channel
            err = USBDASK.UD_AI_2405_Chan_Config(Module_Num, (USBDASK.P2405_AI_EnableIEPE| USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_PseudoDifferential),
                                           (USBDASK.P2405_AI_EnableIEPE | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_PseudoDifferential),
                                           (USBDASK.P2405_AI_EnableIEPE | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_PseudoDifferential),
                                           (USBDASK.P2405_AI_DisableIEPE | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_Differential));
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_2405_Chan_Config error = :" + err.ToString());
                Close();
                return;
            }

            // Configure trigger source
            err = USBDASK.UD_AI_2405_Trig_Config(Module_Num, USBDASK.P2405_AI_CONVSRC_INT, USBDASK.P2405_AI_TRGMOD_POST, USBDASK.P2405_AI_TRGSRC_SOFT, 0, 0, 0, 0);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_2405_Trig_Config error = :" + err.ToString());
                Close();
                return;
            }

            // Enable double-buffer
            err = USBDASK.UD_AI_AsyncDblBufferMode(Module_Num, true);
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_AsyncDblBufferMode error = :" + err.ToString());
                Close();
                return;
            }

            // Prepare the Channel Gain Queue
            
            for (i = 0; i < wSelectedChans; i++)
            {
                ChanArray[i] = i;
                RangeArray[i] = USBDASK.AD_B_10_V;
            }

            //err = USBDASK.UD_AI_ContReadChannel(Module_Num, 0, USBDASK.AD_B_10_V, AiBuf, dwDataNum, 100000.0, USBDASK.ASYNCH_OP);
            err = USBDASK.UD_AI_ContReadMultiChannels(Module_Num, wSelectedChans, ChanArray, RangeArray, AiBuf, dwDataNum * wSelectedChans, 25600.0, USBDASK.ASYNCH_OP);            
            if (err != USBDASK.NoError)
            {
                MessageBox.Show("UD_AI_ContReadMultiChannels error = :" + err.ToString());
                Close();
                return;
            }

            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            short err;
            uint AccessCnt;
            savingCounter = 0;
            if (saveDataThread!=null && saveDataThread.ThreadState != ThreadState.Running)
            {
                saveDataThread = new Thread(SaveData);
                saveDataThread.Start();
                saveDataThread.Join();
            }
            err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);
            timer1.Enabled = false;
            for (int i = 0; i < 3; i++)
            {
                saveDataList[i].Clear();
            }     

        }

        private void PlotData()
        {
            float fScaleX, fScaleY, fMidY;
            int index,Cur_Channel;
            //int I32Temp;
            //uint U32Temp;        
            

            pbxDisplay.Refresh();

            fScaleX = (float)pbxDisplay.Width / (float)PointArray.Length;
            //fScaleY = ((float)pbxDisplay.Height * (float)0.97) / (float)16777216.0;
            fScaleY = ((float)pbxDisplay.Height * (float)0.97) / (float)(Math.Pow(2,24));
            fMidY = (float)pbxDisplay.Height / 2;

            
            for (index = 0; index < dwDataNum/2; index++)
            {             
                PointArray[index].X = (int)(index * fScaleX);
            }
            #region Single channel AI
            //for (index = 0; index < dwSampleCnt; index++)
            //{
            //    U32Temp = (AiBuf[index]);

            //    if ( (U32Temp & 0x800000) != 0x00000000)
            //        U32Temp = (U32Temp | 0xFF000000);
                
            //    I32Temp = (int)U32Temp;
            //    PointArray[index].Y = (int)(fMidY - I32Temp * fScaleY);

            //}

            //gr.DrawLines(Pens.Yellow, PointArray);
            #endregion

            //double sum = 0, Rms = 0;

            //testList.Add((uint[])AiBuf.Clone());  //test
            
            for (Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)           
            {
                for (index = 0; index < dwDataNum / 2; index++)
                {
                    //USBDASK.UD_AI_VoltScale32(Module_Num, USBDASK.AD_B_10_V, 0, AiBuf[index * wSelectedChans + Cur_Channel], out chData[Cur_Channel][index]);
                    USBDASK.UD_AI_VoltScale32(Module_Num, USBDASK.AD_B_10_V, 0, AiBuf[index * wSelectedChans + Cur_Channel], out rawData);
                    
                    //convert unit form V to mVperG 
                    //chData[Cur_Channel][index] = chData[Cur_Channel][index] / sensitivityArr[Cur_Channel] * 1000;
                    chData[Cur_Channel][index] = rawData / sensitivityArr[Cur_Channel] * 1000;
                    

                    //PointArr[index].Y = (float)(chData[Cur_Channel][index]/sensitivityArr[Cur_Channel]/1000.0);
                    PointArray[index].Y = (int)(fMidY-(chData[Cur_Channel][index]*10));

                    rawData = 0;
                    //sum += Math.Pow(chData[0][index], 2);                 
                                                                     
                }
                saveDataList[Cur_Channel].Add((double[])chData[Cur_Channel].Clone());  //test

                //Rms = Math.Sqrt(sum / 5120);
                //txtTest.Text = Rms.ToString();                                           
                //txtTest.Text = DateTime.Now.ToString("HH:mm:ss");

                switch (Cur_Channel)
                {
                    case 0:
                        gr.DrawLines(Pens.Yellow, PointArray);                        
                        break;
                    case 1:
                        gr.DrawLines(Pens.LightGreen, PointArray);
                        break;
                    case 2:
                        gr.DrawLines(Pens.Blue, PointArray);
                        break;
                    case 3:
                        gr.DrawLines(Pens.Red, PointArray);
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short err;
            byte bStopped, bHalfReady;      
           

            #region AsyncDblOperation
            err = USBDASK.UD_AI_AsyncDblBufferHalfReady(Module_Num, out bHalfReady, out bStopped);           
            if( bHalfReady == 1 )         
            {               
                err = USBDASK.UD_AI_AsyncDblBufferTransfer32(Module_Num, AiBuf);
                if (err != USBDASK.NoError)
                {
                    MessageBox.Show("UD_AI_ContReadMultiChannels error = :" + err.ToString());
                    timer1.Enabled = false; // disable timer
                    return;
                }
                else
                {
                    PlotData(); //  display the DAQ data
                    //1. Array.Clone() just create an shallow copy.
                    //chDataList.Add((double[][])chData.Clone());
                }

                savingCounter++;
                if (savingCounter == 10)
                {
                    savingCounter = 0;
                    saveDataThread =new Thread(SaveData);
                    saveDataThread.Start();
                    saveDataThread.Join();

                    for (int i = 0; i < 3; i++)
                    {
                        saveDataList[i].Clear();
                    }                       
                }                   
                    
                txtTest.Text = savingCounter.ToString();
 
            }
            #endregion

        }

        private void SaveData()
        {
            string path = txtSavePath.Text + "\\";
            string[] fileName = { "X-axis", "Y-axis", "Z-axis" };
            string ext = ".txt";
            string timeStamp = DateTime.Now.ToString("yy:MM:ddHH:mm:ss");
            timeStamp = timeStamp.Replace(":", "");
            StreamWriter writer;

            /*
            for (int Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
            {
                writer = new StreamWriter(path + fileName[Cur_Channel] + "_" + timeStamp + ext);
                
                foreach (double[][] data in chDataList)
                {
                    for (int i = 0; i < dwDataNum / 2; i++)
                    {
                        writer.Write(data[Cur_Channel][i].ToString("0.0000") + "\r\n");
                    }
                }
                writer.Close();
            }*/
            /*
            for (int Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
            {
                writer = new StreamWriter(path + fileName[Cur_Channel] + "_" + timeStamp + ext);

                for (int j = 0; j < testList.Count; j++)
                {
                    for (int k = 0; k < testList[j].Length; k++)
                    {
                        writer.Write(testList[j][k * 3 + Cur_Channel].ToString("0.0000") + "\r\n");
                    }
                }
                writer.Close();
            }
            */
            for (int Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
            {
                writer = new StreamWriter(path + fileName[Cur_Channel] + "_" + timeStamp + ext);

                for (int j = 0; j < saveDataList[Cur_Channel].Count; j++)
                {
                    for (int k = 0; k < saveDataList[Cur_Channel][j].Length; k++)
                    {
                        writer.Write(saveDataList[Cur_Channel][j][k].ToString("0.0000") + "\r\n");
                    }
                }
                writer.Close();
            }         
        }

        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = fbd.SelectedPath;
            }
        }
    }
}