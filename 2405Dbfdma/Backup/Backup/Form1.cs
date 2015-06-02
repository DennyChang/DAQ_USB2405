using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _405dma
{
    public partial class Form1 : Form
    {
        ushort wModuleNum;
        ushort wSelModuleID;
        ushort Module_Num;
        USBDAQ_DEVICE[] AvailModules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];
        uint dwDataNum = 20480;
        uint[] AiBuf = new uint[20480];
        Graphics gr;

        public Form1()
        {
            InitializeComponent();

            Module_Num = USBDASK.INVALID_CARD_ID;
        }

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

            tbxYup.Text = "10V";
            tbxYdown.Text = "-10V";
            textYZero.Text = "0V";
            pbxDisplay.BackColor = Color.Black;

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

        private void btnStart_Click(object sender, EventArgs e)
        {
            short err;
            double fActualRate;

            // Configure AI Channel
            err = USBDASK.UD_AI_2405_Chan_Config(Module_Num, (USBDASK.P2405_AI_DisableIEPE | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_Differential),
                                           (USBDASK.P2405_AI_DisableIEPE | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_Differential),
                                           (USBDASK.P2405_AI_DisableIEPE | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_Differential),
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

            err = USBDASK.UD_AI_ContReadChannel(Module_Num, 0, USBDASK.AD_B_10_V, AiBuf, dwDataNum, 10000.0, USBDASK.ASYNCH_OP);
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

            err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);
            timer1.Enabled = false;

        }

        private void PlotData()
        {
            float fScaleX, fScaleY, fMidY;
            ushort index;
            int I32Temp;
            uint U32Temp;
            uint dwSampleCnt;
            Point[] PointArray = new Point[dwDataNum/2];

            pbxDisplay.Refresh();

            dwSampleCnt = dwDataNum / 2;  // half-buffer
            fScaleX = (float)pbxDisplay.Width / (float)PointArray.Length;
            fScaleY = ((float)pbxDisplay.Height * (float)0.97) / (float)16777216.0;
            fMidY = (float)pbxDisplay.Height / 2;

            for (index = 0; index < dwSampleCnt; index++)
            {
                PointArray[index].X = (int)(index * fScaleX);
            }
            
            for (index = 0; index < dwSampleCnt; index++)
            {
                U32Temp = (AiBuf[index]);

                if ( (U32Temp & 0x800000) != 0x00000000)
                    U32Temp = (U32Temp | 0xFF000000);
                
                I32Temp = (int)U32Temp;
                PointArray[index].Y = (int)(fMidY - I32Temp * fScaleY);

            }

            gr.DrawLines(Pens.Yellow, PointArray);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short err;
            byte bStopped, bHalfReady;
            
            err = USBDASK.UD_AI_AsyncDblBufferHalfReady(Module_Num, out bHalfReady, out bStopped);

            if( bHalfReady == 1 )
            {
                err = USBDASK.UD_AI_AsyncDblBufferTransfer32(Module_Num, AiBuf);
                if( err != USBDASK.NoError )
                {
                    MessageBox.Show("UD_AI_ContReadMultiChannels error = :" + err.ToString());
                    timer1.Enabled = false; // disable timer
                    return;
                }
                else
                    PlotData(); //  display the DAQ data
            }

        }
    }
}