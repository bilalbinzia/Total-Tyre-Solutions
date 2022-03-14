using CButtonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System32;

namespace ControlLibrary
{
    public class TAButton : CButton
    {
        //private System.ComponentModel.Container components = null;
        public TAButton()
        {
            InitializeComponent();            
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //            components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        private void InitializeComponent()
        {
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;            
            //this.BackColor = StaticInfo.ctrBackColor;
            //this.ForeColor = StaticInfo.ctrLabelForeColor;

            //this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            //this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            //this.ForeColor = System.Drawing.Color.White;
            //this.Location = new System.Drawing.Point(12, 83);
            CButtonLib.cBlendItems cBlendItems1 = new CButtonLib.cBlendItems();

            cBlendItems1.iColor = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))))};
            cBlendItems1.iPoint = new float[] {
        0F,
        0.5F,
        1F};
            this.ColorFillBlend = cBlendItems1;
            this.DesignerSelected = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.ImageIndex = 0;
            this.Name = "button1";
            this.Size = new System.Drawing.Size(276, 39);
            this.TabIndex = 11662;
            this.Text = "button1";            
            this.TextShadow = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            
            //this.Margin = new System.Windows.Forms.Padding(0);
            //this.Name = "button1";
            //this.Size = new System.Drawing.Size(75, 23);
            //this.TabIndex = 23;
            //this.Text = "button1";
            //this.UseVisualStyleBackColor = false;
            //this.MouseLeave += new System.EventHandler(btn_MouseLeave);
            //this.MouseHover += new System.EventHandler(this.btn_MouseHover);
            
        }

        //private void btn_MouseHover(object sender, EventArgs e)
        //{
        //    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(183)))), ((int)(((byte)(84)))));
        //}
        //private void btn_MouseLeave(object sender, EventArgs e)
        //{
        //    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
        //}
    }
}
