using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZBitmap
{
    public partial class HvsZ : Form
    {
        private Timer tmr = new Timer();
        private int bitmapWidth = Genesis.getWidth;
        private int bitmapHeight = Genesis.getHeight;
        private int timeInterval = Genesis.getTimeInterval;
        private int numHuman = 0;
        private int numZombie = 0;
        private int numEmpty = 0;

        public HvsZ()
        {
            InitializeComponent();
            tmr.Interval = timeInterval;
            /*
            chart1.Series["Creature"].Points[0].SetValueXY("Human", numHuman);
            chart1.Series["Creature"].Points[1].SetValueXY("Zombie", numZombie);
            */
            ///*
            chart1.Series["Human"].Points.AddXY("Human", numHuman);
            chart1.Series["Zombie"].Points.AddXY("Zombie", numHuman);
            chart1.Series["Empty"].Points.AddXY("Empty", numEmpty);
            //*/
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Genesis._Genesis();
            
            if (tmr.Enabled)
            {
                tmr.Stop();
            }
            else
            {
                tmr.Start();
                tmr.Tick += Tmr_Tick;
            }
        }
        
        private void Tmr_Tick(object sender, EventArgs e)
        {
            chart1.Series["Human"].Points.Clear();
            chart1.Series["Zombie"].Points.Clear();
            chart1.Series["Empty"].Points.Clear();
            txtException.Text = "";
            picWorld.Image = new Bitmap(bitmapWidth, bitmapHeight);

            txtTime.Text = DateTime.Now.ToString();
            char[,] cWorld = new char[bitmapWidth, bitmapHeight];
            cWorld = Genesis.GetWorld;
            numZombie = 0;
            numHuman = 0;
            numEmpty = 0;
            

            for(int y = 0; y<picWorld.Height;y++)
            {
                for(int x = 0; x<picWorld.Width; x++)
                {
                    switch(cWorld[x,y])
                    {
                        case 'H':
                            {
                                ((Bitmap)picWorld.Image).SetPixel(x, y, Color.FromArgb(120,0,255,0));
                                numHuman++;
                                break;
                            }
                        case 'Z':
                            {
                                ((Bitmap)picWorld.Image).SetPixel(x, y, Color.FromArgb(120,255,0,0 ));
                                numZombie++;
                                break;
                            }
                        default:
                            {
                                ((Bitmap)picWorld.Image).SetPixel(x, y, Color.FromArgb(255,0,0,0));
                                numEmpty++;
                                break;
                            }
                    }
                }
            }
            int sq = bitmapHeight * bitmapWidth;
            txtException.Text = ("Human: " + (int)Math.Round((double)(numHuman*100)/sq) + 
                                 "% Zombie: " + (int)Math.Round((double)(numZombie * 100) / sq) + 
                                 "% Empty Spot: " + (int)Math.Round((double)(numEmpty * 100) / sq)) + "%";
            /*
            chart1.Series["Creature"].Points[0].SetValueY(numHuman);
            chart1.Series["Creature"].Points[1].SetValueY(numZombie);
            */

            ///*
            chart1.Series["Human"].Points.AddY(numHuman);
            chart1.Series["Zombie"].Points.AddY(numZombie);
            chart1.Series["Empty"].Points.AddY(numEmpty);
            //*/
        }
    }
}
